using OmopTransformer.Annotations;
using OmopTransformer.Omop.Observation;
using OmopTransformer.Transformation;

namespace OmopTransformer.COSD.CT.Observation.COSDv9CTObservationCancerTreatmentIntent;

internal class COSDv9CTObservationCancerTreatmentIntent : OmopObservation<COSDv9CTObservationCancerTreatmentIntentRecord>
{
    [CopyValue(nameof(Source.NhsNumber))]
    public override string? nhs_number { get; set; }

    [Transform(typeof(DateOnlyConverter), nameof(Source.TreatmentStartDateCancer))]
    public override DateOnly? observation_date { get; set; }

    [Transform(typeof(DateConverter), nameof(Source.TreatmentStartDateCancer))]
    public override DateTime? observation_datetime { get; set; }

    [ConstantValue(32828, "EHR episode record")]
    public override int? observation_type_concept_id { get; set; }

    [ConstantValue(4194400, "Treatment intent")]
    public override int? observation_source_concept_id { get; set; }

    [Transform(typeof(StandardObservationConceptSelector), useOmopTypeAsSource: true, nameof(observation_source_concept_id))]
    public override int[]? observation_concept_id { get; set; }

    [CopyValue(nameof(Source.CancerTreatmentIntent))]
    public override string? observation_source_value { get; set; }

    [CopyValue(nameof(Source.CancerTreatmentIntent))]
    public override string? value_source_value { get; set; }
}
