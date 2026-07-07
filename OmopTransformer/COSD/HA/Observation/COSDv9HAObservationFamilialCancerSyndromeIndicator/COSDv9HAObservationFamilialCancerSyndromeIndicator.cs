using OmopTransformer.Annotations;
using OmopTransformer.Omop.Observation;
using OmopTransformer.Transformation;

namespace OmopTransformer.COSD.HA.Observation.COSDv9HAObservationFamilialCancerSyndromeIndicator;

internal class COSDv9HAObservationFamilialCancerSyndromeIndicator : OmopObservation<COSDv9HAObservationFamilialCancerSyndromeIndicatorRecord>
{
    [CopyValue(nameof(Source.NhsNumber))]
    public override string? nhs_number { get; set; }

    [Transform(typeof(DateOnlyConverter), nameof(Source.DateOfPrimaryDiagnosisClinicallyAgreed))]
    public override DateOnly? observation_date { get; set; }

    [Transform(typeof(DateConverter), nameof(Source.DateOfPrimaryDiagnosisClinicallyAgreed))]
    public override DateTime? observation_datetime { get; set; }

    [ConstantValue(32828, "EHR episode record")]
    public override int? observation_type_concept_id { get; set; }

    [ConstantValue(4171594, "Family history of malignant neoplasm")]
    public override int? observation_source_concept_id { get; set; }

    [Transform(typeof(StandardObservationConceptSelector), useOmopTypeAsSource: true, nameof(observation_source_concept_id))]
    public override int[]? observation_concept_id { get; set; }

    [CopyValue(nameof(Source.FamilialCancerSyndromeIndicator))]
    public override string? observation_source_value { get; set; }

    [CopyValue(nameof(Source.FamilialCancerSyndromeIndicator))]
    public override string? value_source_value { get; set; }
}
