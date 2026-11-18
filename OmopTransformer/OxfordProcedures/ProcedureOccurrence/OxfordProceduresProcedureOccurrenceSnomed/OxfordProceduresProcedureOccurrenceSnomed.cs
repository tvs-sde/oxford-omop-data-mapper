using OmopTransformer.Annotations;

namespace OmopTransformer.OxfordProcedures.ProcedureOccurrence.OxfordProceduresProcedureOccurrenceSnomed;

internal class OxfordProceduresProcedureOccurrenceSnomed : OxfordProceduresProcedureOccurrence<OxfordProceduresProcedureOccurrenceSnomedRecord>
{
    [Transform(typeof(SnomedSelector), nameof(Source.concept_code))]
    public override int? procedure_source_concept_id { get; set; }
}
