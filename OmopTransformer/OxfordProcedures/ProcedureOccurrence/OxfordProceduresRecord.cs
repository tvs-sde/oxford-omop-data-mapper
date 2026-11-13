namespace OmopTransformer.OxfordProcedures.ProcedureOccurrence;

internal abstract class OxfordProceduresRecord
{
    public string? patient_identifier_value { get; set; }
    public string? clinical_date { get; set; }
    public string? clinical_datetime { get; set; }
    public string? clinical_code { get; set; }
    public string? concept_code { get; set; }
}
