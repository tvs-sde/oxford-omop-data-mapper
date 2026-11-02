using CsvHelper;

namespace OmopTransformer;

internal static class CsvReaderExtensions
{
    public static CsvReader CreateReader(TextReader reader)
    {
        return CsvReader.Create(reader, new CsvReaderOptions
        {
            Separator = ',',
            FormatProvider = System.Globalization.CultureInfo.InvariantCulture,
            MalformedData = CsvMalformedDataHandling.Throw,
            MissingField = CsvMissingFieldHandling.Throw,
            IncludeValuesInExceptions = false
        });
    }

    public static string? GetFieldOrNullWhenEmpty(this CsvReader reader, string name)
    {
        ArgumentNullException.ThrowIfNull(reader, nameof(reader));
        ArgumentNullException.ThrowIfNull(reader, nameof(name));
            
        var value = reader.GetString(name);

        if (value == null)
            return null;

        return value.IsEmpty() ? null : value;
    }

    public static string? GetFieldOrNullWhenEmptyIfExists(this CsvReader reader, string name)
    {
        ArgumentNullException.ThrowIfNull(reader, nameof(reader));
        ArgumentNullException.ThrowIfNull(reader, nameof(name));

        if (reader.TryGetFieldIndex(name, out _))
        {
            return reader.GetFieldOrNullWhenEmpty(name);
        }

        return null;
    }
}