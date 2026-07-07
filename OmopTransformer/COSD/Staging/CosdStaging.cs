using System.IO.Compression;
using System.Text.RegularExpressions;
using System.Xml;
using DuckDB.NET.Data;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace OmopTransformer.COSD.Staging;

internal class CosdStaging : ICosdStaging
{
    private readonly ILogger<CosdStaging> _logger;
    private readonly StagingOptions _options;
    private readonly Configuration _configuration;

    public CosdStaging(ILogger<CosdStaging> logger, StagingOptions options, IOptions<Configuration> configuration)
    {
        _logger = logger;
        _options = options;
        _configuration = configuration.Value;
    }

    public async Task StageData(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Staging COSD data.");

        if (!File.Exists(_options.FileName))
        {
            _logger.LogError("File does not exist or is inaccessible. {0}", _options.FileName);
            Environment.ExitCode = (int)ExitCodes.FileDoesNotExist;
            return;
        }

        var connection = new DuckDBConnection(_configuration.ConnectionString!);
        await connection.OpenAsync(cancellationToken);

        using var archive = ZipFile.OpenRead(_options.FileName);

        _logger.LogInformation("Found {0} entries.", archive.Entries.Count);

        int recordNumber = 0;

        foreach (var entry in archive.Entries)
        {
            cancellationToken.ThrowIfCancellationRequested();

            _logger.LogInformation("Staging {0}. Record number {1}.", entry.Name, recordNumber++);

            var json = await ConvertToXmlToJsonNoComments(entry, cancellationToken);

            var type = GetCosdType(json);

            if (type == CosdType.Unknown)
            {
                _logger.LogError("Could not determine COSD type for entry {0}. Skipping.", entry.Name);

                throw new NotSupportedException("Unknown COSD type.");
            }

            if (type == CosdType.Cosd81 || type == CosdType.Cosd901)
            {
                string tableName = type == CosdType.Cosd81 ? "cosd_staging_81" : "cosd_staging_901";

                using var appender = connection.CreateAppender("omop_staging", tableName);

                JObject root = JObject.Parse(json);

                var cosdRoot = root.SelectToken("$.COSD:COSD");

                foreach (var token in cosdRoot!.Children<JToken>())
                {
                    if (token is JProperty property)
                    {
                        var arrays = property.Children<JArray>();

                        if (arrays.Any() == false)
                            continue;

                        foreach (var array in arrays)
                        {
                            foreach (var record in array.OfType<JObject>())
                            {
                                var dbRow = appender.CreateRow();

                                dbRow
                                    .AppendValue(Path.GetFileName(_options.FileName))
                                    .AppendValue(entry.Name)
                                    .AppendValue(GetCosdCancerType(entry.Name))
                                    .AppendValue(record.ToString())
                                    .EndRow();
                            }
                        }
                        
                    }
                }
            }
        }

        _logger.LogInformation("Staging complete.");
    }

    private static async Task<string> ConvertToXmlToJsonNoComments (ZipArchiveEntry entry, CancellationToken cancellationToken)
    {
        await using var stream = entry.Open();
        using var memoryStream = new MemoryStream();
        await stream.CopyToAsync(memoryStream, cancellationToken);

        memoryStream.Seek(0, SeekOrigin.Begin);

        var xmlDoc = new XmlDocument
        {
            XmlResolver = null // mitigate XXE attack surface
        };

        using var xmlReader = XmlReader.Create(memoryStream, new XmlReaderSettings
        {
            DtdProcessing = DtdProcessing.Prohibit
        });

        xmlDoc.Load(xmlReader);

        var commentNodes = xmlDoc.SelectNodes("//comment()");
        if (commentNodes is not null)
        {
            var toRemove = new List<XmlNode>();
            foreach (XmlNode node in commentNodes)
            {
                toRemove.Add(node);
            }

            foreach (var node in toRemove)
            {
                node.ParentNode?.RemoveChild(node);
            }
        }

        return JsonConvert.SerializeXmlNode(xmlDoc);
    }

    private static string GetCosdCancerType(string filename)
    {
        const string cancerTypeKey = "type";

        var matches = Regex.Match(filename, @"COSD_INFOFLEX\((?<type>\w{2})\)_.+");

        if (matches.Success && matches.Groups.ContainsKey(cancerTypeKey))
        {
            return matches.Groups[cancerTypeKey].Value.ToUpperInvariant();
        }

        throw new InvalidDataException($"Could not determine COSD cancer type from filename: {filename}. Expected format: COSD_INFOFLEX(BR)_RTH_2020-03-01_2020-03-31_2020-05-18T12_18_38.xml");
    }

    private static CosdType GetCosdType(string json)
    {
        string trimmed = json[..1000];

        if (trimmed.Contains("http://www.datadictionary.nhs.uk/messages/COSD-v9-0-1"))
        {
            return CosdType.Cosd901;
        }

        if (trimmed.Contains("http://www.datadictionary.nhs.uk/messages/COSD-v8-1"))
        {
            return CosdType.Cosd81;
        }

        return CosdType.Unknown;
    }

    private class CosdType
    {
        private CosdType() { }

        public static readonly CosdType Cosd81 = new ();
        public static readonly CosdType Cosd901 = new ();
        public static readonly CosdType Unknown = new ();
    }
}