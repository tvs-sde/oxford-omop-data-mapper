using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.UR.Measurement.COSDv9URMeasurementProstateSpecificAntigenDiagnosis;

[DataOrigin("COSD")]
[Description("COSD V9 UR Measurement Prostate Specific Antigen Diagnosis")]
[SourceQuery("COSDv9URMeasurementProstateSpecificAntigenDiagnosis.xml")]
internal class COSDv9URMeasurementProstateSpecificAntigenDiagnosisRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? ProstateSpecificAntigenDiagnosis { get; set; }
}
