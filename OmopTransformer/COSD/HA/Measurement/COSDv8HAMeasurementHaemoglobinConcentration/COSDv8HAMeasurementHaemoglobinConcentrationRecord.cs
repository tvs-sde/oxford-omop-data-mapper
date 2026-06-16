using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.HA.Measurement.COSDv8HAMeasurementHaemoglobinConcentration;

[DataOrigin("COSD")]
[Description("COSD V8 HA Measurement Haemoglobin Concentration")]
[SourceQuery("COSDv8HAMeasurementHaemoglobinConcentration.xml")]
internal class COSDv8HAMeasurementHaemoglobinConcentrationRecord
{
    public string? NhsNumber { get; set; }
    public string? ClinicalDateCancerDiagnosis { get; set; }
    public string? HaemoglobinConcentration { get; set; }
}
