using OmopTransformer.Annotations;

namespace OmopTransformer.Transformation;

[Description("MEMBER OF SPECIALIST MULTIDISCIPLINARY TEAM INDICATOR")]
internal class MemberOfSpecialistMultidisciplinaryTeamIndicatorLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } =
        new()
        {
            { "Y", new ValueWithNote(null, "Yes - care professional is a member of the specialist multidisciplinary team") },
            { "N", new ValueWithNote(null, "No - care professional is not a member of the specialist multidisciplinary team") },
            { "9", new ValueWithNote(null, "Not Known (Not Recorded)") },
        };

    public string[] ColumnNotes => Array.Empty<string>();
}
