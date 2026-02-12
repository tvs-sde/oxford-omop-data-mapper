using OmopTransformer.Annotations;

namespace OmopTransformer.Transformation;

[Description("CONSULTANT CODE")]
internal class ConsultantCodeLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } =
        new()
        {
            { "C9999998", new ValueWithNote(null, "Consultant, General Medical Council reference number not known") },
            { "CD999998", new ValueWithNote(null, "Dental consultant: General Medical Council reference number / General Dental Council registration number not known") },
            { "D9999998", new ValueWithNote(null, "Dentist, General Dental Practitioner code not known") },
            { "M9999998", new ValueWithNote(null, "Midwife") },
            { "N9999998", new ValueWithNote(null, "Nurse") },
            { "H9999998", new ValueWithNote(null, "Other health care professional") },
        };

    public string[] ColumnNotes => Array.Empty<string>();
}
