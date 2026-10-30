using OmopTransformer.Annotations;

namespace OmopTransformer.OxfordDiagnosis.ConditionOccurrence.OxfordDiagnosisConditionOccurrenceSnomed;

internal class OxfordDiagnosisConditionOccurrenceSnomed : OxfordDiagnosisConditionOccurrence<OxfordDiagnosisSnomedRecord>
{
    [Transform(typeof(SnomedSelector), nameof(Source.concept_code))]
    public override int? condition_source_concept_id { get; set; }
}
