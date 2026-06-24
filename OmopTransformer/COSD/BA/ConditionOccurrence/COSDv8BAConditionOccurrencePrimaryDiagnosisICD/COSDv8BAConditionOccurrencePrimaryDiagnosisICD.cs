using OmopTransformer.Annotations;
using OmopTransformer.Omop.ConditionOccurrence;
using OmopTransformer.Transformation;

namespace OmopTransformer.COSD.BA.ConditionOccurrence.COSDv8BAConditionOccurrencePrimaryDiagnosisICD;

internal class COSDv8BAConditionOccurrencePrimaryDiagnosisICD : OmopConditionOccurrence<COSDv8BAConditionOccurrencePrimaryDiagnosisICDRecord>
{
    [CopyValue(nameof(Source.NHSNumber))]
    public override string? nhs_number { get; set; }

    [Transform(typeof(DateConverter), nameof(Source.ClinicalDateCancerDiagnosis))]
    public override DateTime? condition_start_date { get; set; }

    [Transform(typeof(DateConverter), nameof(Source.ClinicalDateCancerDiagnosis))]
    public override DateTime? condition_end_date { get; set; }

    [ConstantValue(32828, "EHR episode record")]
    public override int? condition_type_concept_id { get; set; }

    [Transform(typeof(Icd10StandardNonStandardSelector), nameof(Source.PrimaryDiagnosisICD))]
    public override int? condition_source_concept_id { get; set; }

    [Transform(typeof(StandardConditionConceptSelector), useOmopTypeAsSource: true, nameof(condition_source_concept_id))]
    public override int[]? condition_concept_id { get; set; }

    [CopyValue(nameof(Source.PrimaryDiagnosisICD))]
    public override string? condition_source_value { get; set; }
}
