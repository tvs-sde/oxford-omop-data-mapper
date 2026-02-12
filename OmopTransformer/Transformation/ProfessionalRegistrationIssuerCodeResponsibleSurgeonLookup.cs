using OmopTransformer.Annotations;

namespace OmopTransformer.Transformation;

[Description("PROFESSIONAL REGISTRATION ISSUER CODE (RESPONSIBLE SURGEON)")]
internal class ProfessionalRegistrationIssuerCodeResponsibleSurgeonLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } =
        new()
        {
            { "02", new ValueWithNote(null, "General Dental Council") },
            { "03", new ValueWithNote(null, "General Medical Council") },
            { "04", new ValueWithNote(null, "General Optical Council") },
            { "08", new ValueWithNote(null, "Health and Care Professions Council") },
            { "09", new ValueWithNote(null, "Nursing and Midwifery Council") },
        };

    public string[] ColumnNotes => Array.Empty<string>();
}
