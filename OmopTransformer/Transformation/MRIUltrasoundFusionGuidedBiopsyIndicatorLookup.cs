using OmopTransformer.Annotations;

namespace OmopTransformer.Transformation;

[Description("MRI ULTRASOUND FUSION GUIDED BIOPSY INDICATOR")]
internal class MRIUltrasoundFusionGuidedBiopsyIndicatorLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } =
        new()
        {
            { "Y", new ValueWithNote(null, "Yes - MRI ultrasound fusion guided biopsy was performed") },
            { "N", new ValueWithNote(null, "No - MRI ultrasound fusion guided biopsy was not performed") },
            { "9", new ValueWithNote(null, "Not Known (Not Recorded)") },
        };

    public string[] ColumnNotes => Array.Empty<string>();
}
