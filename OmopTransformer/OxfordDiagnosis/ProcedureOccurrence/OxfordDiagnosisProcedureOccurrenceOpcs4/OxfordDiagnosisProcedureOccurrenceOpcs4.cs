using OmopTransformer.Annotations;

namespace OmopTransformer.OxfordDiagnosis.ProcedureOccurrence.OxfordDiagnosisProcedureOccurrenceOpcs4;

internal class OxfordDiagnosisProcedureOccurrenceOpcs4 : OxfordDiagnosisProcedureOccurrence<OxfordDiagnosisProcedureOccurrenceOpcs4Record>
{
    [Transform(typeof(Opcs4Selector), nameof(Source.concept_code))]
    public override int? procedure_source_concept_id { get; set; }
}
