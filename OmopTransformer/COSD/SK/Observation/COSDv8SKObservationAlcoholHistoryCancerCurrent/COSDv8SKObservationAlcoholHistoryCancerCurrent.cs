using OmopTransformer.Annotations;
using OmopTransformer.Omop.Observation;
using OmopTransformer.Transformation;

namespace OmopTransformer.COSD.SK.Observation.COSDv8SKObservationAlcoholHistoryCancerCurrent;

internal class COSDv8SKObservationAlcoholHistoryCancerCurrent : OmopObservation<COSDv8SKObservationAlcoholHistoryCancerCurrentRecord>
{
    [CopyValue(nameof(Source.NhsNumber))]
    public override string? nhs_number { get; set; }

    [Transform(typeof(DateOnlyConverter), nameof(Source.DateOfPrimaryDiagnosisClinicallyAgreed))]
    public override DateOnly? observation_date { get; set; }

    [Transform(typeof(DateConverter), nameof(Source.DateOfPrimaryDiagnosisClinicallyAgreed))]
    public override DateTime? observation_datetime { get; set; }

    [ConstantValue(32828, "EHR episode record")]
    public override int? observation_type_concept_id { get; set; }

    [CopyValue(nameof(Source.AlcoholHistoryCancerCurrent))]
    public override string? observation_source_value { get; set; }

    [ConstantValue(4266612, "Eating feeding / drinking observable")]
    public override int[]? observation_concept_id { get; set; }

    [Transform(typeof(AlcoholHistoryCancerPastLookup), nameof(Source.AlcoholHistoryCancerCurrent))]
    public override int? value_as_concept_id { get; set; }

    [CopyValue(nameof(Source.AlcoholHistoryCancerCurrent))]
    public override string? value_source_value { get; set; }
}
