using OmopTransformer.Annotations;

namespace OmopTransformer.Transformation;

[Description("CANCER METASTATIC DISEASE TYPE")]
internal class CancerMetastaticDiseaseTypeLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } =
        new()
        {
            { "01", new ValueWithNote(null, "Local") },
            { "02", new ValueWithNote(null, "Regional") },
            { "03", new ValueWithNote(null, "Distant") }
        };

    public string[] ColumnNotes => Array.Empty<string>();
}
