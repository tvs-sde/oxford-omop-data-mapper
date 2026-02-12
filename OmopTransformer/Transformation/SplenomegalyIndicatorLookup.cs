using OmopTransformer.Annotations;

namespace OmopTransformer.Transformation;

[Description("SPLENOMEGALY INDICATOR")]
internal class SplenomegalyIndicatorLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } =
        new()
        {
            { "Y", new ValueWithNote(null, "Yes - the patient has splenomegaly.") },
            { "N", new ValueWithNote(null, "No - the patient does not have splenomegaly.") },
        };

    public string[] ColumnNotes => Array.Empty<string>();
}