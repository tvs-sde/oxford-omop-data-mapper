using OmopTransformer.Annotations;
using OmopTransformer.Omop.Observation;
using OmopTransformer.OxfordDiagnosis.ConditionOccurrence;
using OmopTransformer.Transformation;

namespace OmopTransformer.OxfordDiagnosis.Observation;

internal abstract class OxfordDiagnosisObservation<T> : OmopObservation<T>
    where T : OxfordDiagnosisRecord
{
    [CopyValue(nameof(Source.patient_identifier_value))]
    public override string? nhs_number { get; set; }

    [Transform(typeof(DateOnlyConverter), nameof(Source.diagnosis_date))]
    public override DateOnly? observation_date { get; set; }

    [Transform(typeof(DateConverter), nameof(Source.diagnosis_datetime))]
    public override DateTime? observation_datetime { get; set; }

    [ConstantValue(32817, "EHR")]
    public override int? observation_type_concept_id { get; set; }

    [Transform(typeof(StandardObservationConceptSelector), useOmopTypeAsSource: true, nameof(observation_source_concept_id))]
    public override int[]? observation_concept_id { get; set; }

    [CopyValue(nameof(Source.diagnosis_code))]
    public override string? observation_source_value { get; set; }
}
