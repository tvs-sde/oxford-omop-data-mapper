using OmopTransformer.Annotations;

namespace OmopTransformer.Transformation;

[Description("Lookup menopausal status concept.")]
internal class MenopausalStatusLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } =
        new()
        {
            { "1", new ValueWithNote("4331463", "Premenopausal state") },
            { "2", new ValueWithNote("45757505", "Perimenopausal state") },
            { "3", new ValueWithNote("4295261", "Postmenopausal state") }
        };

    public string[] ColumnNotes =>
    [
        "[Menopausal Status](https://digital.nhs.uk/ndrs/data/data-sets/cosd/cosd-user-guide-v10/core---clinical-nurse-specialist)"
    ];
}