using OmopTransformer.Annotations;
using OmopTransformer.Omop.ConditionOccurrence;
using OmopTransformer.Transformation;

namespace OmopTransformer.COSD.Core.ConditionOccurrence.CosdV9HAConditionOccurrenceSecondaryDiagnosisIcd;

internal class CosdV9HAConditionOccurrenceSecondaryDiagnosisIcd : OmopConditionOccurrence<CosdV9HAConditionOccurrenceSecondaryDiagnosisIcdRecord>
{
    [CopyValue(nameof(Source.NhsNumber))]
    public override string? nhs_number { get; set; }

    [Transform(typeof(DateConverter), nameof(Source.DateOfPrimaryDiagnosisClinicallyAgreed))]
    public override DateTime? condition_start_date { get; set; }

    [ConstantValue(32828, "EHR episode record")]
    public override int? condition_type_concept_id { get; set; }

    [Transform(typeof(Icd10StandardNonStandardSelector), nameof(Source.SecondaryDiagnosisIcd))]
    public override int? condition_source_concept_id { get; set; }

    [Transform(typeof(StandardConditionConceptSelector), useOmopTypeAsSource: true, nameof(condition_source_concept_id))]
    public override int[]? condition_concept_id { get; set; }

    [CopyValue(nameof(Source.SecondaryDiagnosisIcd))]
    public override string? condition_source_value { get; set; }
}
