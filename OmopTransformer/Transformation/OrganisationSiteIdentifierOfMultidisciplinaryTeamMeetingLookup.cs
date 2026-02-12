using OmopTransformer.Annotations;

namespace OmopTransformer.Transformation;

[Description("ORGANISATION SITE IDENTIFIER (OF MULTIDISCIPLINARY TEAM MEETING)")]
internal class OrganisationSiteIdentifierOfMultidisciplinaryTeamMeetingLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } =
        new()
        {
            { "89999", new ValueWithNote(null, "Non-NHS UK provider where no organisation site identifier has been issued") },
            { "89997", new ValueWithNote(null, "Non-UK provider where no organisation site identifier has been issued") },
        };

    public string[] ColumnNotes => Array.Empty<string>();
}
