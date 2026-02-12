using OmopTransformer.Annotations;

namespace OmopTransformer.Transformation;

[Description("OTHER NON BREAST LOCALLY ADVANCED METASTATIC MALIGNANCY INDICATOR")]
internal class OtherNonBreastLocallyAdvancedMetastaticMalignancyIndicatorLookup : ILookup
{
    public Dictionary<string, ValueWithNote> Mappings { get; } =
        new()
        {
            { "Y", new ValueWithNote(null, "Yes - the patient has another non-breast locally advanced or metastatic malignancy") },
            { "N", new ValueWithNote(null, "No - the patient does not have any other non-breast locally advanced or metastatic malignancy") },
        };

    public string[] ColumnNotes => Array.Empty<string>();
}
