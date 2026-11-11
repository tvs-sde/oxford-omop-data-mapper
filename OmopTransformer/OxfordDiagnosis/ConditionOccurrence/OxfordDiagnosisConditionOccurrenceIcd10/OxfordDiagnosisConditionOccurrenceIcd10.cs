using OmopTransformer.Annotations;

namespace OmopTransformer.OxfordDiagnosis.ConditionOccurrence.OxfordDiagnosisConditionOccurrenceIcd10;

internal class OxfordDiagnosisConditionOccurrenceIcd10 : OxfordDiagnosisConditionOccurrence<OxfordDiagnosisIcd10Record>
{
    [Transform(typeof(Icd10StandardNonStandardSelector), nameof(Source.concept_code))]
    public override int? condition_source_concept_id { get; set; }
}
