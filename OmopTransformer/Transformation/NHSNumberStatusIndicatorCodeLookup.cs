using OmopTransformer.Annotations;

namespace OmopTransformer.Transformation;

[Description("NHS NUMBER STATUS INDICATOR CODE")]
internal class NHSNumberStatusIndicatorCodeLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } =
        new()
        {
            { "01", new ValueWithNote(null, "Number present and verified") },
            { "02", new ValueWithNote(null, "Number present but not traced") },
            { "03", new ValueWithNote(null, "Trace required") },
            { "04", new ValueWithNote(null, "Trace attempted - no match or multiple match found") },
            { "05", new ValueWithNote(null, "Trace needs to be resolved (NHS Number or patient detail conflict)") },
            { "06", new ValueWithNote(null, "Trace in progress") },
            { "07", new ValueWithNote(null, "Number not present and trace not required") },
            { "08", new ValueWithNote(null, "Trace postponed (baby under six weeks old)") },
        };

    public string[] ColumnNotes => Array.Empty<string>();
}
