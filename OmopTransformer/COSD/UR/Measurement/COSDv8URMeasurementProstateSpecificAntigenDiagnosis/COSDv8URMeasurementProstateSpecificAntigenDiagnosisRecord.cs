using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.UR.Measurement.COSDv8URMeasurementProstateSpecificAntigenDiagnosis;

[DataOrigin("COSD")]
[Description("COSD V8 UR Measurement Prostate Specific Antigen Diagnosis")]
[SourceQuery("COSDv8URMeasurementProstateSpecificAntigenDiagnosis.xml")]
internal class COSDv8URMeasurementProstateSpecificAntigenDiagnosisRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? ProstateSpecificAntigenDiagnosis { get; set; }
}
