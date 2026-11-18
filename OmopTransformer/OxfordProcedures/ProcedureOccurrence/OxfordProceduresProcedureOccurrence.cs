using OmopTransformer.Annotations;
using OmopTransformer.Omop.ProcedureOccurrence;
using OmopTransformer.Transformation;

namespace OmopTransformer.OxfordProcedures.ProcedureOccurrence;

internal abstract class OxfordProceduresProcedureOccurrence<T> : OmopProcedureOccurrence<T>
    where T : OxfordProceduresRecord
{
    [CopyValue(nameof(Source.patient_identifier_value))]
    public override string? nhs_number { get; set; }

    [Transform(typeof(DateConverter), nameof(Source.clinical_date))]
    public override DateTime? procedure_date { get; set; }

    [Transform(typeof(DateConverter), nameof(Source.clinical_datetime))]
    public override DateTime? procedure_datetime { get; set; }

    [ConstantValue(32817, "EHR")]
    public override int? procedure_type_concept_id { get; set; }

    [Transform(typeof(StandardProcedureConceptSelector), useOmopTypeAsSource: true, nameof(procedure_source_concept_id))]
    public override int[]? procedure_concept_id { get; set; }

    [CopyValue(nameof(Source.clinical_code))]
    public override string? procedure_source_value { get; set; }
}
