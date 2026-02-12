using OmopTransformer.Annotations;

namespace OmopTransformer.Transformation;

[Description("NUMBER OF EXTRANODAL SITES CODE")]
internal class NumberOfExtranodalSitesCodeLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } =
        new()
        {
            { "0", new ValueWithNote(null, "0 extranodal sites") },
            { "1", new ValueWithNote(null, "1 extranodal site") },
            { "2", new ValueWithNote(null, "More than 1 extranodal sites") },
        };

    public string[] ColumnNotes => Array.Empty<string>();
}
