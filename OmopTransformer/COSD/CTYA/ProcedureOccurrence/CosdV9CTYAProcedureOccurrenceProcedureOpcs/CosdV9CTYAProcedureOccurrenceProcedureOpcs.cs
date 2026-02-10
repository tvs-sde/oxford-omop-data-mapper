using OmopTransformer.Annotations;
using OmopTransformer.Omop.ProcedureOccurrence;
using OmopTransformer.Transformation;

namespace OmopTransformer.COSD.CTYA.ProcedureOccurrence.CosdV9CTYAProcedureOccurrenceProcedureOpcs;

[Notes(
    "Duplicates",
    "COSD data contains numerous duplicated records due to repeated submissions that include the same records.  The latest record may occasionally have a NULL field that was previously populated.  We observed this for address fields, date of birth and other personal details, but did not observe it for procedure data.",
    "In order to avoid true duplicates occurring in the data, we have included distinct records for  NHSNumber (person_id) , PrimaryProcedureOpcs(procedure_concept_id), ProcedureOpcs(procedure_concept_id), ProcedureDate (procedure_date) and excluded all duplicates.  The tool will handle things a little differently, as each new submission will have to be dealt with as it arrives.")]
internal class CosdV9CTYAProcedureOccurrenceProcedureOpcs : OmopProcedureOccurrence<CosdV9CTYAProcedureOccurrenceProcedureOpcsRecord>
{
    [CopyValue(nameof(Source.NhsNumber))]
    public override string? nhs_number { get; set; }

    [Transform(typeof(StandardProcedureConceptSelector), useOmopTypeAsSource: true, nameof(procedure_source_concept_id))]
    public override int[]? procedure_concept_id { get; set; }

    [Transform(typeof(Opcs4Selector), nameof(Source.ProcedureOpcsCode))]
    public override int? procedure_source_concept_id { set; get; }

    [Transform(typeof(DateConverter), nameof(Source.ProcedureDate))]
    public override DateTime? procedure_date { get; set; }

    [Transform(typeof(DateConverter), nameof(Source.ProcedureDate))]
    public override DateTime? procedure_datetime { get; set; }
    
    [ConstantValue(32828, "`EHR episode record`")]
    public override int? procedure_type_concept_id { get; set; }

    [CopyValue(nameof(Source.ProcedureOpcsCode))]
    public override string? procedure_source_value { get; set; }

    [ConstantValue(1, "One")]
    public override int? quantity { get; set; }
}
