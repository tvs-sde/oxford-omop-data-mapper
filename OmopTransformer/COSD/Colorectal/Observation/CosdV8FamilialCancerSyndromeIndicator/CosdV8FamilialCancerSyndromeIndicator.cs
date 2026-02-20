using OmopTransformer.Annotations;
using OmopTransformer.Omop.Observation;
using OmopTransformer.Transformation;

namespace OmopTransformer.COSD.Colorectal.Observation.CosdV8FamilialCancerSyndromeIndicator;

[Notes("Notes", DocumentationNotes.ApproximatedDatesWarning)]
internal class CosdV8FamilialCancerSyndromeIndicator : OmopObservation<CosdV8FamilialCancerSyndromeIndicatorRecord>
{
    [CopyValue(nameof(Source.NhsNumber))]
    public override string? nhs_number { get; set; }

    [ConstantValue(4171594, "Family history of malignant neoplasm")]
    public override int[]? observation_concept_id { get; set; }

    [CopyValue(nameof(Source.Date))]
    public override DateOnly? observation_date { get; set; }

    [CopyValue(nameof(Source.Date))]
    public override DateTime? observation_datetime { get; set; }

    [ConstantValue(32828, "`EHR episode record`")]
    public override int? observation_type_concept_id { get; set; }

    [CopyValue(nameof(Source.FamilialCancerSyndromeIndicator))]
    public override string? value_as_string { get; set; }

    [ConstantValue(2000500005, "Familial Cancer (Indicator)")]
    public override int? observation_source_concept_id { get; set; }
}
