using OmopTransformer.Annotations;
using OmopTransformer.Omop.Observation;
using OmopTransformer.Transformation;

namespace OmopTransformer.COSD.HA.Observation.COSDv8HAObservationSmokingStatusCancer;

internal class COSDv8HAObservationSmokingStatusCancer : OmopObservation<COSDv8HAObservationSmokingStatusCancerRecord>
{
    [CopyValue(nameof(Source.NhsNumber))]
    public override string? nhs_number { get; set; }

    [Transform(typeof(DateOnlyConverter), nameof(Source.DateOfPrimaryDiagnosisClinicallyAgreed))]
    public override DateOnly? observation_date { get; set; }

    [Transform(typeof(DateConverter), nameof(Source.DateOfPrimaryDiagnosisClinicallyAgreed))]
    public override DateTime? observation_datetime { get; set; }

    [ConstantValue(32828, "EHR episode record")]
    public override int? observation_type_concept_id { get; set; }

    [ConstantValue(43054909, "Tobacco smoking status")]
    public override int? observation_source_concept_id { get; set; }

    [Transform(typeof(StandardObservationConceptSelector), useOmopTypeAsSource: true, nameof(observation_source_concept_id))]
    public override int[]? observation_concept_id { get; set; }

    [CopyValue(nameof(Source.SmokingStatusCancer))]
    public override string? observation_source_value { get; set; }

    [CopyValue(nameof(Source.SmokingStatusCancer))]
    public override string? value_source_value { get; set; }
}
