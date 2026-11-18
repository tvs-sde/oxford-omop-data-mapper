using OmopTransformer.Annotations;

namespace OmopTransformer.OxfordProcedures.ConditionOccurrence.OxfordProceduresConditionOccurrenceOpcs4;

internal class OxfordProceduresConditionOccurrenceOpcs4 : OxfordProceduresConditionOccurrence<OxfordProceduresConditionOccurrenceOpcs4Record>
{
    [Transform(typeof(Opcs4Selector), nameof(Source.concept_code))]
    public override int? condition_source_concept_id { get; set; }
}
