using OmopTransformer.Annotations;

namespace OmopTransformer.Transformation;

[Description("CARE PROFESSIONAL SENIOR OPERATING SURGEON GRADE (CANCER)")]
internal class CareProfessionalSeniorOperatingSurgeonGradeCancerLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } =
        new()
        {
            { "S", new ValueWithNote(null, "Subspecialist Gynaecological Oncologist") },
            { "C", new ValueWithNote(null, "Consultant Gynaecologist (not subspecialist)") },
            { "F", new ValueWithNote(null, "Sub-Specialty Fellow (Retired 01 April 2018)") },
            { "A", new ValueWithNote(null, "Associate Specialist / Staff Grade (Retired 01 April 2018)") },
            { "N", new ValueWithNote(null, "Non-Training Sub-Consultant Grade") },
            { "R", new ValueWithNote(null, "Specialist Registrar / ST3+ (Retired 01 April 2018)") },
            { "O", new ValueWithNote(null, "Senior House Officer / ST1 or ST2 (Retired 01 April 2018)") },
            { "T", new ValueWithNote(null, "Trainee including Subspecialty Fellow and ST Trainee") },
            { "G", new ValueWithNote(null, "General Surgeon / other surgical specialty") },
            { "Z", new ValueWithNote(null, "Colposcopist Not Otherwise Specified") },
        };

    public string[] ColumnNotes => Array.Empty<string>();
}
