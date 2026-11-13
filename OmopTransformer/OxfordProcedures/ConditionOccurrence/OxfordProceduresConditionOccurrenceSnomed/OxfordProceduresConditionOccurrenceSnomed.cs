using OmopTransformer.Annotations;

namespace OmopTransformer.OxfordProcedures.ConditionOccurrence.OxfordProceduresConditionOccurrenceSnomed;

internal class OxfordProceduresConditionOccurrenceSnomed : OxfordProceduresConditionOccurrence<OxfordProceduresConditionOccurrenceSnomedRecord>
{
    [Transform(typeof(SnomedSelector), nameof(Source.concept_code))]
    public override int? condition_source_concept_id { get; set; }
}
