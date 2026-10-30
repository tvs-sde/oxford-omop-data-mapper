using OmopTransformer.Annotations;
using OmopTransformer.Omop.Observation;
using OmopTransformer.Transformation;

namespace OmopTransformer.COSD.CR.Observation.COSDv8CRObservationSmokingStatusCancer;

internal class COSDv8CRObservationSmokingStatusCancer : OmopObservation<COSDv8CRObservationSmokingStatusCancerRecord>
{
    [CopyValue(nameof(Source.NhsNumber))]
    public override string? nhs_number { get; set; }

    [Transform(typeof(DateOnlyConverter), nameof(Source.DateOfPrimaryDiagnosisClinicallyAgreed))]
    public override DateOnly? observation_date { get; set; }

    [Transform(typeof(DateConverter), nameof(Source.DateOfPrimaryDiagnosisClinicallyAgreed))]
    public override DateTime? observation_datetime { get; set; }

    [ConstantValue(32828, "EHR episode record")]
    public override int? observation_type_concept_id { get; set; }

    [ConstantValue(648645, "Smoking status")]
    public override int[]? observation_concept_id { get; set; }

    [CopyValue(nameof(Source.SmokingStatusCancer))]
    public override string? observation_source_value { get; set; }

    [CopyValue(nameof(Source.SmokingStatusCancer))]
    public override string? value_source_value { get; set; }

    [Transform(typeof(SmokingStatusLookup), nameof(Source.SmokingStatusCancer))]
    public override int? value_as_concept_id { get; set; }
}
