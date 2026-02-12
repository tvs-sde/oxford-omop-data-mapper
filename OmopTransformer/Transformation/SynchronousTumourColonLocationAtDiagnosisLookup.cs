using OmopTransformer.Annotations;

namespace OmopTransformer.Transformation;

[Description("SYNCHRONOUS TUMOUR COLON LOCATION (AT DIAGNOSIS)")]
internal class SynchronousTumourColonLocationAtDiagnosisLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } =
        new()
        {
            { "01", new ValueWithNote(null, "Caecum") },
            { "02", new ValueWithNote(null, "Appendix") },
            { "03", new ValueWithNote(null, "Ascending Colon") },
            { "04", new ValueWithNote(null, "Hepatic Flexure") },
            { "05", new ValueWithNote(null, "Transverse Colon") },
            { "06", new ValueWithNote(null, "Splenic Flexure") },
            { "07", new ValueWithNote(null, "Descending Colon") },
            { "08", new ValueWithNote(null, "Sigmoid Colon") },
            { "09", new ValueWithNote(null, "Rectosigmoid") },
            { "10", new ValueWithNote(null, "Rectum") },
        };

    public string[] ColumnNotes => Array.Empty<string>();
}