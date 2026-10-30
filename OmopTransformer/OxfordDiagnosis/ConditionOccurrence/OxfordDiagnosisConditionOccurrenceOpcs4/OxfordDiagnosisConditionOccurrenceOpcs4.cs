using OmopTransformer.Annotations;

namespace OmopTransformer.OxfordDiagnosis.ConditionOccurrence.OxfordDiagnosisConditionOccurrenceOpcs4;

internal class OxfordDiagnosisConditionOccurrenceOpcs4 : OxfordDiagnosisConditionOccurrence<OxfordDiagnosisOpcs4Record>
{
    [Transform(typeof(Opcs4Selector), nameof(Source.concept_code))]
    public override int? condition_source_concept_id { get; set; }
}
