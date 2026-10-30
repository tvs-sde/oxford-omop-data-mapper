using OmopTransformer.Annotations;

namespace OmopTransformer.OxfordDiagnosis.ProcedureOccurrence.OxfordDiagnosisProcedureOccurrenceIcd10;

internal class OxfordDiagnosisProcedureOccurrenceIcd10 : OxfordDiagnosisProcedureOccurrence<OxfordDiagnosisProcedureOccurrenceIcd10Record>
{
    [Transform(typeof(Icd10StandardNonStandardSelector), nameof(Source.concept_code))]
    public override int? procedure_source_concept_id { get; set; }
}
