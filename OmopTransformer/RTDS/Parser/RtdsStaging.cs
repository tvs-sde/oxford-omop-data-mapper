using System.IO.Compression;
using Microsoft.Extensions.Logging;
using OmopTransformer.RTDS.Staging;

namespace OmopTransformer.RTDS.Parser;

internal class RtdsStaging : IRtdsStaging
{
    private readonly ILogger<RtdsStaging> _logger;
    private readonly StagingOptions _options;
    private readonly IRtdsInserter _inserter;
    
    public RtdsStaging(ILogger<RtdsStaging> logger, StagingOptions options, IRtdsInserter inserter)
    {
        _logger = logger;
        _options = options;
        _inserter = inserter;
    }

    public async Task StageData(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Staging RTDS data. {0}", _options.FileName);

        bool isDirectory = Directory.Exists(_options.FileName);
        bool isFile = File.Exists(_options.FileName);

        if (!isDirectory && !isFile)
        {
            _logger.LogError("File does not exist or is inaccessible. {0}", _options.FileName);
            Environment.ExitCode = (int)ExitCodes.FileDoesNotExist;
            return;
        }

        var rawData =
            isFile
                ?
                await GetZipData(_options.FileName!, cancellationToken)
                :
                await GetDirectoryData(_options.FileName!, cancellationToken);

        var records = new RtdsParser(rawData).Parse();

        await _inserter.Insert(records, cancellationToken);

        _logger.LogInformation("Staging complete.");
    }
    
    private async Task<RtdsRawData> GetZipData(string path, CancellationToken cancellationToken)
    {
        async Task<string> GetStringFromEntry(ZipArchive archive, string fileName)
        {
            var entry = archive.Entries.Single(entry => entry.Name.StartsWith(fileName));

            await using var stream = entry.Open();
            StreamReader reader = new StreamReader(stream);
            return await reader.ReadToEndAsync(cancellationToken);
        }
        
        using var archive = ZipFile.OpenRead(path);

        _logger.LogInformation("Reading zip file.");
        
        // Look for the file that starts the file name that we're looking for, because sometimes we see '5..csv' instead of '5.csv', or 'PASDATA.csv .csv'
        return
            new RtdsRawData(
                demographics: await GetStringFromEntry(archive, "1."),
                attendances: await GetStringFromEntry(archive, "2a."),
                plans: await GetStringFromEntry(archive, "2b."),
                prescriptions: await GetStringFromEntry(archive, "3."),
                exposures: await GetStringFromEntry(archive, "4."),
                diagnosesCourses: await GetStringFromEntry(archive, "5."),
                pasData: await GetStringFromEntry(archive, "PAS"),
                sourceFileName: path);
    }

    private async Task<RtdsRawData> GetDirectoryData(string path, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Reading directory.");

        return
            new RtdsRawData(
                demographics: await ReadAllTextWithBaseDirectoryAsync("1.csv"),
                attendances: await ReadAllTextWithBaseDirectoryAsync("2a.csv"),
                plans: await ReadAllTextWithBaseDirectoryAsync("2b.csv"),
                prescriptions: await ReadAllTextWithBaseDirectoryAsync("3.csv"),
                exposures: await ReadAllTextWithBaseDirectoryAsync("4.csv"),
                diagnosesCourses: await ReadAllTextWithBaseDirectoryAsync("5.csv"),
                pasData: null,
                sourceFileName: path);

        async Task<string> ReadAllTextWithBaseDirectoryAsync(string fileName)
        {
            return await File.ReadAllTextAsync(Path.Combine(path, fileName), cancellationToken);
        }
    }
}