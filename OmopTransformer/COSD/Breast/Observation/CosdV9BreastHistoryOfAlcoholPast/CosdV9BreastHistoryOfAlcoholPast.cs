using OmopTransformer.Annotations;
using OmopTransformer.Omop.Observation;
using OmopTransformer.Transformation;

namespace OmopTransformer.COSD.Breast.Observation.CosdV9BreastHistoryOfAlcoholPast;

[Notes("Notes", DocumentationNotes.ApproximatedDatesWarning)]
internal class CosdV9BreastHistoryOfAlcoholPast : OmopObservation<CosdV9BreastHistoryOfAlcoholPastRecord>
{
    [CopyValue(nameof(Source.NhsNumber))]
    public override string? nhs_number { get; set; }

    [ConstantValue(35609491, "Alcohol units consumed per week")]
    public override int[]? observation_concept_id { get; set; }

    [CopyValue(nameof(Source.Date))]
    public override DateOnly? observation_date { get; set; }

    [CopyValue(nameof(Source.Date))]
    public override DateTime? observation_datetime { get; set; }

    [ConstantValue(32828, "`EHR episode record`")]
    public override int? observation_type_concept_id { get; set; }

    [CopyValue(nameof(Source.HistoryOfAlcoholPast))]
    public override string? value_as_string { get; set; }

    [ConstantValue(2000500004, "History Of Alcohol (Past)")]
    public override int? observation_source_concept_id { get; set; }
}
