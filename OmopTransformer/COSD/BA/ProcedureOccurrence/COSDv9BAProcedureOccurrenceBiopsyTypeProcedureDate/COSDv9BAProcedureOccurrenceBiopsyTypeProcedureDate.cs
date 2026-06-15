using OmopTransformer.Annotations;
using OmopTransformer.Omop.ProcedureOccurrence;
using OmopTransformer.Transformation;

namespace OmopTransformer.COSD.BA.ProcedureOccurrence.COSDv9BAProcedureOccurrenceBiopsyTypeProcedureDate;

/// <summary>
/// COSD V9 BA - Biopsy Type Procedures
/// Maps biopsy type coded procedures to OMOP procedure_occurrence
/// </summary>
internal class COSDv9BAProcedureOccurrenceBiopsyTypeProcedureDate : OmopProcedureOccurrence<COSDv9BAProcedureOccurrenceBiopsyTypeProcedureDateRecord>
{
    [CopyValue(nameof(Source.NhsNumber))]
    public override string? nhs_number { get; set; }

    [Transform(typeof(DateConverter), nameof(Source.ProcedureDate))]
    public override DateTime? procedure_date { get; set; }

    [CopyValue(nameof(Source.BiopsyType))]
    public override string? procedure_source_value { get; set; }

    [Transform(typeof(BiopsyAnaestheticTypeLookup), nameof(Source.BiopsyType))]
    public override int? procedure_source_concept_id { get; set; }

    [Transform(typeof(BiopsyAnaestheticTypeLookup), nameof(Source.BiopsyType))]
    public override int[]? procedure_concept_id { get; set; }

    [ConstantValue(32828, "`EHR episode record`")]
    public override int? procedure_type_concept_id { get; set; }
}
