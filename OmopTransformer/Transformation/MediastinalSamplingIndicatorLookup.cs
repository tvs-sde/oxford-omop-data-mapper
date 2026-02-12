using OmopTransformer.Annotations;

namespace OmopTransformer.Transformation;

[Description("MEDIASTINAL SAMPLING INDICATOR")]
internal class MediastinalSamplingIndicatorLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } =
        new()
        {
            { "Y", new ValueWithNote(null, "Yes - patient had mediastinoscopy, mediastinotomy, open mediastinal sampling, or other mediastinal biopsy") },
            { "N", new ValueWithNote(null, "No - patient did not have mediastinoscopy, mediastinotomy, open mediastinal sampling, or other mediastinal biopsy") },
            { "9", new ValueWithNote(null, "Not Known (Not Recorded)") },
        };

    public string[] ColumnNotes => Array.Empty<string>();
}
