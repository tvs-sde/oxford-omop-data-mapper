using OmopTransformer.Annotations;

namespace OmopTransformer.OxfordProcedures.ProcedureOccurrence.OxfordProceduresProcedureOccurrenceOpcs4;

internal class OxfordProceduresProcedureOccurrenceOpcs4 : OxfordProceduresProcedureOccurrence<OxfordProceduresProcedureOccurrenceOpcs4Record>
{
    [Transform(typeof(Opcs4Selector), nameof(Source.concept_code))]
    public override int? procedure_source_concept_id { get; set; }
}
