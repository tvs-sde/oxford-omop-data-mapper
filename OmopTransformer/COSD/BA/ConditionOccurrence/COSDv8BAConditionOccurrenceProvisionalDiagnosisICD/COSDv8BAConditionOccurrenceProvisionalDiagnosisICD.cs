using OmopTransformer.Annotations;
using OmopTransformer.Omop.ConditionOccurrence;
using OmopTransformer.Transformation;

namespace OmopTransformer.COSD.BA.ConditionOccurrence.COSDv8BAConditionOccurrenceProvisionalDiagnosisICD;

internal class COSDv8BAConditionOccurrenceProvisionalDiagnosisICD : OmopConditionOccurrence<COSDv8BAConditionOccurrenceProvisionalDiagnosisICDRecord>
{
    [CopyValue(nameof(Source.NHSNumber))]
    public override string? nhs_number { get; set; }

    [Transform(typeof(DateConverter), nameof(Source.CancerMultiTeamDiscussionDate))]
    public override DateTime? condition_start_date { get; set; }

    [Transform(typeof(DateConverter), nameof(Source.ClinicalDateCancerDiagnosis))]
    public override DateTime? condition_end_date { get; set; }

    [ConstantValue(32828, "EHR episode record")]
    public override int? condition_type_concept_id { get; set; }

    [Transform(typeof(Icd10StandardNonStandardSelector), nameof(Source.ProvisionalDiagnosisICD))]
    public override int? condition_source_concept_id { get; set; }

    [Transform(typeof(StandardConditionConceptSelector), useOmopTypeAsSource: true, nameof(condition_source_concept_id))]
    public override int[]? condition_concept_id { get; set; }

    [CopyValue(nameof(Source.ProvisionalDiagnosisICD))]
    public override string? condition_source_value { get; set; }
}
