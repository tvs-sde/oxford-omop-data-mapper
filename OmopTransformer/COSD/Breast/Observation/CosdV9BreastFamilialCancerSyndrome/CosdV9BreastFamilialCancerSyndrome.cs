using OmopTransformer.Annotations;
using OmopTransformer.Omop.Observation;
using OmopTransformer.Transformation;

namespace OmopTransformer.COSD.Breast.Observation.CosdV9BreastFamilialCancerSyndrome;

[Notes("Notes", DocumentationNotes.ApproximatedDatesWarning)]
internal class CosdV9BreastFamilialCancerSyndrome : OmopObservation<CosdV9BreastFamilialCancerSyndromeRecord>
{
    [CopyValue(nameof(Source.NhsNumber))]
    public override string? nhs_number { get; set; }

    [ConstantValue(44782478, "Hereditary cancer-predisposing syndrome")]
    public override int[]? observation_concept_id { get; set; }

    [CopyValue(nameof(Source.Date))]
    public override DateOnly? observation_date { get; set; }

    [CopyValue(nameof(Source.Date))]
    public override DateTime? observation_datetime { get; set; }

    [ConstantValue(32828, "`EHR episode record`")]
    public override int? observation_type_concept_id { get; set; }

    [CopyValue(nameof(Source.FamilialCancerSyndrome))]
    public override string? value_as_string { get; set; }

    [ConstantValue(2000500005, "Familial Cancer (Indicator)")]
    public override int? observation_source_concept_id { get; set; }
}
