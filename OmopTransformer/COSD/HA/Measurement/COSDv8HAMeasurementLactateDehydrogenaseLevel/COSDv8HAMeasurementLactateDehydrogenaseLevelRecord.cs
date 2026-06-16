using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.HA.Measurement.COSDv8HAMeasurementLactateDehydrogenaseLevel;

[DataOrigin("COSD")]
[Description("COSD V8 HA Measurement Lactate Dehydrogenase Level")]
[SourceQuery("COSDv8HAMeasurementLactateDehydrogenaseLevel.xml")]
internal class COSDv8HAMeasurementLactateDehydrogenaselevelRecord
{
    public string? NhsNumber { get; set; }
    public string? ClinicalDateCancerDiagnosis { get; set; }
    public string? LactateDehydrogenaseLevel { get; set; }
}
