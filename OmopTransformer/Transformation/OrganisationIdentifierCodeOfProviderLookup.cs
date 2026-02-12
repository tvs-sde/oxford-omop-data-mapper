using OmopTransformer.Annotations;

namespace OmopTransformer.Transformation;

[Description("ORGANISATION IDENTIFIER (CODE OF PROVIDER)")]
internal class OrganisationIdentifierCodeOfProviderLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } =
        new()
        {
            { "89997", new ValueWithNote(null, "Non-UK provider where no organisation identifier has been issued") },
            { "89999", new ValueWithNote(null, "Non-NHS UK provider where no organisation identifier has been issued") },
        };

    public string[] ColumnNotes => Array.Empty<string>();
}
