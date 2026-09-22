using OmopTransformer.Annotations;
using OmopTransformer.Omop.Observation;
using OmopTransformer.Transformation;

namespace OmopTransformer.COSD.CT.Observation.COSDv9CTObservationAlcoholHistoryCancerInLastThreeMonths;

internal class COSDv9CTObservationAlcoholHistoryCancerInLastThreeMonths : OmopObservation<COSDv9CTObservationAlcoholHistoryCancerInLastThreeMonthsRecord>
{
    [CopyValue(nameof(Source.NhsNumber))]
    public override string? nhs_number { get; set; }

    [Transform(typeof(DateOnlyConverter), nameof(Source.DateOfPrimaryDiagnosisClinicallyAgreed))]
    public override DateOnly? observation_date { get; set; }

    [Transform(typeof(DateConverter), nameof(Source.DateOfPrimaryDiagnosisClinicallyAgreed))]
    public override DateTime? observation_datetime { get; set; }

    [ConstantValue(32828, "EHR episode record")]
    public override int? observation_type_concept_id { get; set; }

    [ConstantValue(35609491, "Alcohol units consumed per week")]
    public override int? observation_source_concept_id { get; set; }

    [Transform(typeof(StandardObservationConceptSelector), useOmopTypeAsSource: true, nameof(observation_source_concept_id))]
    public override int[]? observation_concept_id { get; set; }

    [CopyValue(nameof(Source.AlcoholHistoryCancerInLastThreeMonths))]
    public override string? observation_source_value { get; set; }

    [CopyValue(nameof(Source.AlcoholHistoryCancerInLastThreeMonths))]
    public override string? value_source_value { get; set; }
}
