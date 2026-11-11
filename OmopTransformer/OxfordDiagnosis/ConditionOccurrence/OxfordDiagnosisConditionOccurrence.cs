using OmopTransformer.Annotations;
using OmopTransformer.Omop.ConditionOccurrence;
using OmopTransformer.Transformation;

namespace OmopTransformer.OxfordDiagnosis.ConditionOccurrence;

internal abstract class OxfordDiagnosisConditionOccurrence<T> : OmopConditionOccurrence<T>
    where T : OxfordDiagnosisRecord
{
    [CopyValue(nameof(Source.patient_identifier_value))]
    public override string? nhs_number { get; set; }

    [Transform(typeof(DateConverter), nameof(Source.diagnosis_date))]
    public override DateTime? condition_start_date { get; set; }

    [Transform(typeof(DateConverter), nameof(Source.diagnosis_datetime))]
    public override DateTime? condition_start_datetime { get; set; }

    [ConstantValue(32817, "EHR")]
    public override int? condition_type_concept_id { get; set; }

    [Transform(typeof(StandardConditionConceptSelector), useOmopTypeAsSource: true, nameof(condition_source_concept_id))]
    public override int[]? condition_concept_id { get; set; }

    [CopyValue(nameof(Source.diagnosis_code))]
    public override string? condition_source_value { get; set; }
}
