namespace OmopTransformer.OxfordDiagnosis.ConditionOccurrence;

internal abstract class OxfordDiagnosisRecord
{
    public string? patient_identifier_value { get; set; }
    public string? diagnosis_date { get; set; }
    public string? diagnosis_datetime { get; set; }
    public string? diagnosis_code { get; set; }
    public string? concept_code { get; set; }
}
