using OmopTransformer.Annotations;

namespace OmopTransformer.Transformation;

[Description("REVISED INTERNATIONAL STAGING SYSTEM STAGE FOR MULTIPLE MYELOMA")]
internal class RevisedInternationalStagingSystemStageForMultipleMyelomaLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } =
        new()
        {
            { "1", new ValueWithNote(null, "Stage I: International Staging System stage I and standard risk chromosomal abnormalities (CA) detected by iFISH and normal LDH.") },
            { "2", new ValueWithNote(null, "Stage II: Not R-ISS stage I or III.") },
            { "3", new ValueWithNote(null, "Stage III: International Staging System stage III and either high risk CA detected by iFISH or high LDH.") },
        };

    public string[] ColumnNotes => Array.Empty<string>();
}
