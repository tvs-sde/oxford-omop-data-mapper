using OmopTransformer.Annotations;
using OmopTransformer.Omop.ConditionOccurrence;
using OmopTransformer.Transformation;

namespace OmopTransformer.COSD.LV.ConditionOccurrence.COSDv9LVConditionOccurrencePrimaryDiagnosisICD;

internal class COSDv9LVConditionOccurrencePrimaryDiagnosisICD : OmopConditionOccurrence<COSDv9LVConditionOccurrencePrimaryDiagnosisICDRecord>
{
    [CopyValue(nameof(Source.NhsNumber))]
    public override string? nhs_number { get; set; }

    [Transform(typeof(DateConverter), nameof(Source.DateOfPrimaryDiagnosisClinicallyAgreed))]
    public override DateTime? condition_start_date { get; set; }

    [Transform(typeof(DateConverter), nameof(Source.DateOfPrimaryDiagnosisClinicallyAgreed))]
    public override DateTime? condition_start_datetime { get; set; }

    [ConstantValue(32828, "EHR episode record")]
    public override int? condition_type_concept_id { get; set; }

    [Transform(typeof(Icd10StandardSelector), nameof(Source.PrimaryDiagnosisIcd))]
    public override int? condition_source_concept_id { get; set; }

    [Transform(typeof(StandardConditionConceptSelector), useOmopTypeAsSource: true, nameof(condition_source_concept_id))]
    public override int[]? condition_concept_id { get; set; }

    [CopyValue(nameof(Source.PrimaryDiagnosisIcd))]
    public override string? condition_source_value { get; set; }
}
