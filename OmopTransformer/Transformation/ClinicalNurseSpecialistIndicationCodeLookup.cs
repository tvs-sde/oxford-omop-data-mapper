using OmopTransformer.Annotations;

namespace OmopTransformer.Transformation;

[Description("CLINICAL NURSE SPECIALIST INDICATION CODE")]
internal class ClinicalNurseSpecialistIndicationCodeLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } =
        new()
        {
            { "Y1", new ValueWithNote(null, "Yes - Clinical Nurse Specialist present when patient given diagnosis") },
            { "Y2", new ValueWithNote(null, "Yes - but Clinical Nurse Specialist not present when patient given diagnosis (Retired 1 April 2015)") },
            { "Y3", new ValueWithNote(null, "Yes - Clinical Nurse Specialist not present when patient given diagnosis but saw patient during same consultant clinic session") },
            { "Y4", new ValueWithNote(null, "Yes - Clinical Nurse Specialist not present during consultant clinic session when patient given diagnosis but saw patient at other time") },
            { "Y5", new ValueWithNote(null, "Yes - Clinical Nurse Specialist not present when patient given diagnosis but patient was seen by a trained member of the Clinical Nurse Specialist team") },
            { "NI", new ValueWithNote(null, "No - patient not seen at all by Clinical Nurse Specialist but Clinical Nurse Specialist informed of diagnosis") },
            { "NN", new ValueWithNote(null, "No - patient not seen at all by Clinical Nurse Specialist and Clinical Nurse Specialist not informed of diagnosis") },
            { "99", new ValueWithNote(null, "Not Known (Not Recorded)") },
        };

    public string[] ColumnNotes => Array.Empty<string>();
}
