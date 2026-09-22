using OmopTransformer.Annotations;
using OmopTransformer.Omop.Observation;
using OmopTransformer.Transformation;

namespace OmopTransformer.COSD.HN.Observation.COSDv8HNObservationAlcoholHistoryCancerCurrent;

internal class COSDv8HNObservationAlcoholHistoryCancerCurrent : OmopObservation<COSDv8HNObservationAlcoholHistoryCancerCurrentRecord>
{
    [CopyValue(nameof(Source.NhsNumber))]
    public override string? nhs_number { get; set; }

    [Transform(typeof(DateOnlyConverter), nameof(Source.DateOfPrimaryDiagnosisClinicallyAgreed))]
    public override DateOnly? observation_date { get; set; }

    [Transform(typeof(DateConverter), nameof(Source.DateOfPrimaryDiagnosisClinicallyAgreed))]
    public override DateTime? observation_datetime { get; set; }

    [ConstantValue(32828, "EHR episode record")]
    public override int? observation_type_concept_id { get; set; }

    [ConstantValue(4266612, "Eating feeding / drinking observable")]
    public override int[]? observation_concept_id { get; set; }

    [CopyValue(nameof(Source.AlcoholHistoryCancerCurrent))]
    public override string? observation_source_value { get; set; }

    [CopyValue(nameof(Source.AlcoholHistoryCancerCurrent))]
    public override string? value_source_value { get; set; }

    [Transform(typeof(HistoryOfAlcoholLookup), nameof(Source.AlcoholHistoryCancerCurrent))]
    public override int? value_as_concept_id { get; set; }
}
