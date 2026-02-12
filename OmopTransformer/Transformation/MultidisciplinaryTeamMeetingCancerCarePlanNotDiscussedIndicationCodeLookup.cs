using OmopTransformer.Annotations;

namespace OmopTransformer.Transformation;

[Description("MULTIDISCIPLINARY TEAM MEETING CANCER CARE PLAN NOT DISCUSSED INDICATION CODE")]
internal class MultidisciplinaryTeamMeetingCancerCarePlanNotDiscussedIndicationCodeLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } =
        new()
        {
            { "1", new ValueWithNote(null, "The patient's Cancer Care Plan was not discussed at a multidisciplinary team meeting") },
            { "2", new ValueWithNote(null, "Not Known (Cancer Care Plan discussion status is not known)") },
        };

    public string[] ColumnNotes => Array.Empty<string>();
}
