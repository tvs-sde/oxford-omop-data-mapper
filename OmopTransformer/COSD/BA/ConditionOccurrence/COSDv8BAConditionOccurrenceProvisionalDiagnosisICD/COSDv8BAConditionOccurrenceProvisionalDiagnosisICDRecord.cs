using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.BA.ConditionOccurrence.COSDv8BAConditionOccurrenceProvisionalDiagnosisICD;

[DataOrigin("COSD")]
[Description("COSD V8 BA Condition Occurrence Provisional Diagnosis ICD")]
[SourceQuery("COSDv8BAConditionOccurrenceProvisionalDiagnosisICD.xml")]
internal class COSDv8BAConditionOccurrenceProvisionalDiagnosisICDRecord
{
    public string? NHSNumber { get; set; }
    public string? CancerMultiTeamDiscussionDate { get; set; }
    public string? ClinicalDateCancerDiagnosis { get; set; }
    public string? ProvisionalDiagnosisICD { get; set; }
}
