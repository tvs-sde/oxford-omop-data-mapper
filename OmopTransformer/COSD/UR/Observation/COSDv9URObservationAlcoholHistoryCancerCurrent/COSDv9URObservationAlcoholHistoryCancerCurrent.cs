using OmopTransformer.Annotations;
using OmopTransformer.Omop.Observation;
using OmopTransformer.Transformation;

namespace OmopTransformer.COSD.UR.Observation.COSDv9URObservationAlcoholHistoryCancerInLastThreeMonths;

internal class COSDv9URObservationAlcoholHistoryCancerInLastThreeMonths : OmopObservation<COSDv9URObservationAlcoholHistoryCancerInLastThreeMonthsRecord>
{
    [CopyValue(nameof(Source.NhsNumber))]
    public override string? nhs_number { get; set; }

    [Transform(typeof(DateOnlyConverter), nameof(Source.DateOfPrimaryDiagnosisClinicallyAgreed))]
    public override DateOnly? observation_date { get; set; }

    [Transform(typeof(DateConverter), nameof(Source.DateOfPrimaryDiagnosisClinicallyAgreed))]
    public override DateTime? observation_datetime { get; set; }

    [ConstantValue(32828, "EHR episode record")]
    public override int? observation_type_concept_id { get; set; }

    [CopyValue(nameof(Source.AlcoholHistoryCancerInLastThreeMonths))]
    public override string? observation_source_value { get; set; }

    [ConstantValue(35609491, "Alcohol units consumed per week")]
    public override int[]? observation_concept_id { get; set; }

    [Transform(typeof(AlcoholHistoryCancerInLastThreeMonthsLookup), nameof(Source.AlcoholHistoryCancerInLastThreeMonths))]
    public override int? value_as_concept_id { get; set; }

    [CopyValue(nameof(Source.AlcoholHistoryCancerInLastThreeMonths))]
    public override string? value_source_value { get; set; }
}
