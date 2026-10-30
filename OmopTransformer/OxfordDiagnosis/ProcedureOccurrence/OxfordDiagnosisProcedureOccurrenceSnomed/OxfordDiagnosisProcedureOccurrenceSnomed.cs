using OmopTransformer.Annotations;

namespace OmopTransformer.OxfordDiagnosis.ProcedureOccurrence.OxfordDiagnosisProcedureOccurrenceSnomed;

internal class OxfordDiagnosisProcedureOccurrenceSnomed : OxfordDiagnosisProcedureOccurrence<OxfordDiagnosisProcedureOccurrenceSnomedRecord>
{
    [Transform(typeof(SnomedSelector), nameof(Source.concept_code))]
    public override int? procedure_source_concept_id { get; set; }
}
