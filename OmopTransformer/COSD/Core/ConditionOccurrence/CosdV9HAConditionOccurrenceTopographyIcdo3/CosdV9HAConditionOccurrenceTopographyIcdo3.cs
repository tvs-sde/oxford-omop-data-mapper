using OmopTransformer.Annotations;
using OmopTransformer.Omop.ConditionOccurrence;
using OmopTransformer.Transformation;

namespace OmopTransformer.COSD.Core.ConditionOccurrence.CosdV9HAConditionOccurrenceTopographyIcdo3;

internal class CosdV9HAConditionOccurrenceTopographyIcdo3 : OmopConditionOccurrence<CosdV9HAConditionOccurrenceTopographyIcdo3Record>
{
    [CopyValue(nameof(Source.NhsNumber))]
    public override string? nhs_number { get; set; }

    [Transform(typeof(DateConverter), nameof(Source.DateOfPrimaryDiagnosisClinicallyAgreed))]
    public override DateTime? condition_start_date { get; set; }

    [ConstantValue(32828, "EHR episode record")]
    public override int? condition_type_concept_id { get; set; }

    [Transform(typeof(Icdo3Selector), nameof(Source.TopographyIcdo3))]
    public override int? condition_source_concept_id { get; set; }

    [Transform(typeof(StandardConditionConceptSelector), useOmopTypeAsSource: true, nameof(condition_source_concept_id))]
    public override int[]? condition_concept_id { get; set; }

    [CopyValue(nameof(Source.TopographyIcdo3))]
    public override string? condition_source_value { get; set; }
}
