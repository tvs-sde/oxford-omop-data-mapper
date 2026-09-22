using OmopTransformer.Annotations;
using OmopTransformer.Omop.Observation;
using OmopTransformer.Transformation;

namespace OmopTransformer.COSD.Colorectal.Observation.CosdV8AlcoholHistoryCancerPast;

[Notes("Notes", DocumentationNotes.ApproximatedDatesWarning)]
internal class CosdV8AlcoholHistoryCancerPast : OmopObservation<CosdV8AlcoholHistoryCancerPastRecord>
{
    [CopyValue(nameof(Source.NhsNumber))]
    public override string? nhs_number { get; set; }

    [ConstantValue(1340204, "History of event")]
    public override int[]? observation_concept_id { get; set; }

    [CopyValue(nameof(Source.Date))]
    public override DateOnly? observation_date { get; set; }

    [CopyValue(nameof(Source.Date))]
    public override DateTime? observation_datetime { get; set; }

    [ConstantValue(32828, "`EHR episode record`")]
    public override int? observation_type_concept_id { get; set; }

    [CopyValue(nameof(Source.AlcoholHistoryCancerPast))]
    public override string? value_source_value { get; set; }

    [Transform(typeof(HistoryOfAlcoholLookup), nameof(Source.AlcoholHistoryCancerPast))]
    public override int? value_as_concept_id { get; set; }
}
