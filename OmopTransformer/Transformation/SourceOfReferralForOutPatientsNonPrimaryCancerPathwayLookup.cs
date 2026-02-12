using OmopTransformer.Annotations;

namespace OmopTransformer.Transformation;

[Description("SOURCE OF REFERRAL FOR OUT-PATIENTS (NON PRIMARY CANCER PATHWAY)")]
internal class SourceOfReferralForOutPatientsNonPrimaryCancerPathwayLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } =
        new()
        {
            { "01", new ValueWithNote(null, "Consultant initiated following an emergency admission.") },
            { "02", new ValueWithNote(null, "Consultant initiated following a domiciliary consultation.") },
            { "10", new ValueWithNote(null, "Consultant initiated following an Emergency Care Attendance (including Minor Injuries, Walk In Centres and Urgent Treatment Centres).") },
            { "11", new ValueWithNote(null, "Consultant initiated: Other (not listed).") },
            { "03", new ValueWithNote(null, "Consultant not initiated following a referral from a general medical practitioner.") },
            { "92", new ValueWithNote(null, "Consultant not initiated following a referral from a general dental practitioner.") },
            { "12", new ValueWithNote(null, "Consultant not initiated following a referral from a GP with an Extended Role (GPwER) or dentist with enhanced skills (DES).") },
            { "04", new ValueWithNote(null, "Consultant not initiated following a referral from an emergency care department (including Minor Injuries Units, Walk In Centres and Urgent Treatment Centres).") },
            { "05", new ValueWithNote(null, "Consultant not initiated following a referral from a consultant, other than in an emergency care department.") },
            { "06", new ValueWithNote(null, "Consultant not initiated following a self-referral.") },
            { "07", new ValueWithNote(null, "Consultant not initiated following a referral from a prosthetist.") },
            { "13", new ValueWithNote(null, "Consultant not initiated following a referral from a specialist nurse (secondary care).") },
            { "14", new ValueWithNote(null, "Consultant not initiated following a referral from an allied health professional.") },
            { "15", new ValueWithNote(null, "Consultant not initiated following a referral from an optometrist.") },
            { "16", new ValueWithNote(null, "Consultant not initiated following a referral from an orthoptist.") },
            { "17", new ValueWithNote(null, "Consultant not initiated following a referral from a national screening programme.") },
            { "93", new ValueWithNote(null, "Consultant not initiated following a referral from a community dental service.") },
            { "97", new ValueWithNote(null, "Consultant not initiated following a referral: Other (not listed).") },
        };

    public string[] ColumnNotes => Array.Empty<string>();
}