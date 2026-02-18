using OmopTransformer.Annotations;
using OmopTransformer.Omop.ConditionOccurrence;
using OmopTransformer.Transformation;

namespace OmopTransformer.COSD.Core.ConditionOccurrence.CosdV9HAConditionOccurrenceProgressionIcd;

internal class CosdV9HAConditionOccurrenceProgressionIcd : OmopConditionOccurrence<CosdV9HAConditionOccurrenceProgressionIcdRecord>
{
    [CopyValue(nameof(Source.NhsNumber))]
    public override string? nhs_number { get; set; }

    [Transform(typeof(DateConverter), nameof(Source.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed))]
    public override DateTime? condition_start_date { get; set; }

    [ConstantValue(32828, "EHR episode record")]
    public override int? condition_type_concept_id { get; set; }

    [Transform(typeof(Icd10StandardNonStandardSelector), nameof(Source.ProgressionIcd))]
    public override int? condition_source_concept_id { get; set; }

    [Transform(typeof(StandardConditionConceptSelector), useOmopTypeAsSource: true, nameof(condition_source_concept_id))]
    public override int[]? condition_concept_id { get; set; }

    [CopyValue(nameof(Source.ProgressionIcd))]
    public override string? condition_source_value { get; set; }
}
