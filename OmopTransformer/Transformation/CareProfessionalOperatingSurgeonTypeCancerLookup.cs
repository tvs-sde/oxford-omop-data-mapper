using OmopTransformer.Annotations;

namespace OmopTransformer.Transformation;

[Description("CARE PROFESSIONAL OPERATING SURGEON TYPE (CANCER)")]
internal class CareProfessionalOperatingSurgeonTypeCancerLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } =
        new()
        {
            { "NU", new ValueWithNote(null, "Nurse") },
            { "TS", new ValueWithNote(null, "Trainee Specialist Doctor") },
            { "CS", new ValueWithNote(null, "Consultant Surgeon (other than Plastic Surgeon)") },
            { "CD", new ValueWithNote(null, "Consultant Dermatologist") },
            { "CPS", new ValueWithNote(null, "Consultant Plastic Surgeon") },
            { "HP", new ValueWithNote(null, "Hospital Practitioner") },
            { "SI", new ValueWithNote(null, "General Practitioner with an Extended Role (GPwER)") },
            { "GP", new ValueWithNote(null, "General Practitioner") },
            { "OO", new ValueWithNote(null, "Other care professional (not listed)") },
        };

    public string[] ColumnNotes => Array.Empty<string>();
}
