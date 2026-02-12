using OmopTransformer.Annotations;

namespace OmopTransformer.Transformation;

[Description("ORGANISATION SITE IDENTIFIER (OF PROVIDER FIRST SEEN NON PRIMARY CANCER PATHWAY)")]
internal class OrganisationSiteIdentifierOfProviderFirstSeenNonPrimaryCancerPathwayLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } =
        new()
        {
            { "89999", new ValueWithNote(null, "Non-NHS UK Provider where no organisation site identifier has been issued") },
            { "89997", new ValueWithNote(null, "Non-UK Provider where no organisation site identifier has been issued") },
        };

    public string[] ColumnNotes => Array.Empty<string>();
}
