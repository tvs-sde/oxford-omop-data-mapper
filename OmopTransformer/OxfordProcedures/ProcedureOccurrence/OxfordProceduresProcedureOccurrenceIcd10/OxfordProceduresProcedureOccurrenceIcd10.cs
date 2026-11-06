using OmopTransformer.Annotations;

namespace OmopTransformer.OxfordProcedures.ProcedureOccurrence.OxfordProceduresProcedureOccurrenceIcd10;

internal class OxfordProceduresProcedureOccurrenceIcd10 : OxfordProceduresProcedureOccurrence<OxfordProceduresProcedureOccurrenceIcd10Record>
{
    [Transform(typeof(Icd10StandardNonStandardSelector), nameof(Source.concept_code))]
    public override int? procedure_source_concept_id { get; set; }
}
