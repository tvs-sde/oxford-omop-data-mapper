namespace OmopTransformer;

internal class DataDictionaryUrlResolver
{
    private readonly Dictionary<string, string?> _urlByOrigin;
    private static readonly HttpClient Client = new HttpClient();
    
    static DataDictionaryUrlResolver()
    {
        Client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/120.0.0.0 Safari/537.36");
    }

    private DataDictionaryUrlResolver(Dictionary<string, string?> urlByOrigin)
    {
        _urlByOrigin = urlByOrigin ?? throw new ArgumentNullException(nameof(urlByOrigin));
    }

    public string? GetUrl(string originFilename)
    {
        _urlByOrigin.TryGetValue(originFilename, out var value);

        return value;
    }
        
    public static async Task<DataDictionaryUrlResolver> CreateAsync(QueryLocator queryLocator)
    {
        var allOrigins =
            queryLocator
                .Queries
                .Values
                .SelectMany(
                    query =>
                        query!
                            .Explanation!
                            .Explanations!
                            .SelectMany(explanation => explanation.Origin == null ? [] : explanation.Origin!))
                .Distinct()
                .ToList();

        var resolutionTasks =
            allOrigins
                .Select(
                    origin =>
                        new
                        {
                            origin,
                            task = TryResolveDataDictionaryUrl(origin)
                        })
                .ToList();

        await Task.WhenAll(resolutionTasks.Select(task => task.task));

        var urlByOrigin =
            resolutionTasks
                .ToDictionary(
                    keySelector: key => key.origin,
                    elementSelector: elementSelector => elementSelector.task.Result);

        return new DataDictionaryUrlResolver(urlByOrigin);
    }

    private static async Task<string?> TryResolveDataDictionaryUrl(string origin)
    {
        string originFileName = ConvertOriginToHtmlFilenameNoExtension(origin);

        string url = GetUrlText(originFileName, finalUnderscore: false);

        if (await GetHttpStatusCodeAsync(url))
            return url;

        url = GetUrlText(originFileName, finalUnderscore: true);

        if (await GetHttpStatusCodeAsync(url))
            return url;

        return null;
    }

    private static string ConvertOriginToHtmlFilenameNoExtension(string origin)
    {
        var originParts = origin.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(originPart => originPart.ToLower());

        return string.Join('_', originParts);
    }
        
    private static string GetUrlText(string originFilename, bool finalUnderscore)
    {
        return ("https://www.datadictionary.nhs.uk/data_elements/" + originFilename + (finalUnderscore ? "_" : "") + ".html").Replace("(", "_").Replace(")", "_");
    }

    private static async Task<bool> GetHttpStatusCodeAsync(string url)
    {
        try
        {
            var response = await Client.GetAsync(url);
            return response.IsSuccessStatusCode;
        }
        catch (HttpRequestException)
        {
            return false;
        }
    }
}