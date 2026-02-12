using OmopTransformer.Annotations;

namespace OmopTransformer.Transformation;

[Description("EXCISION TYPE (CENTRAL NERVOUS SYSTEM TUMOURS)")]
internal class ExcisionTypeCentralNervousSystemTumoursLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } =
        new()
        {
            { "1", new ValueWithNote(null, "Limited (Less than 50%)") },
            { "2", new ValueWithNote(null, "Partial (50-69%)") },
            { "3", new ValueWithNote(null, "Subtotal (70-95%)") },
            { "4", new ValueWithNote(null, "Total Macroscopic") },
            { "5", new ValueWithNote(null, "Extent Uncertain") },
            { "6", new ValueWithNote(null, "Cerebrospinal fluid (CSF) Division Procedure") },
            { "9", new ValueWithNote(null, "Not Known (Not Recorded)") },
        };

    public string[] ColumnNotes => Array.Empty<string>();
}
