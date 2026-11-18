using OmopTransformer.Annotations;
using OmopTransformer.Omop.ConditionOccurrence;
using OmopTransformer.OxfordProcedures.ProcedureOccurrence;
using OmopTransformer.Transformation;

namespace OmopTransformer.OxfordProcedures.ConditionOccurrence;

internal abstract class OxfordProceduresConditionOccurrence<T> : OmopConditionOccurrence<T>
    where T : OxfordProceduresRecord
{
    [CopyValue(nameof(Source.patient_identifier_value))]
    public override string? nhs_number { get; set; }

    [Transform(typeof(DateConverter), nameof(Source.clinical_date))]
    public override DateTime? condition_start_date { get; set; }

    [Transform(typeof(DateConverter), nameof(Source.clinical_datetime))]
    public override DateTime? condition_start_datetime { get; set; }

    [ConstantValue(32817, "EHR")]
    public override int? condition_type_concept_id { get; set; }

    [Transform(typeof(StandardConditionConceptSelector), useOmopTypeAsSource: true, nameof(condition_source_concept_id))]
    public override int[]? condition_concept_id { get; set; }

    [CopyValue(nameof(Source.clinical_code))]
    public override string? condition_source_value { get; set; }
}
