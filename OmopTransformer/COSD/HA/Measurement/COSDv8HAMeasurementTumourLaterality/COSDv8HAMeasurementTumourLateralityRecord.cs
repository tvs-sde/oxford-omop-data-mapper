using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.HA.Measurement.COSDv8HAMeasurementTumourLaterality;

[DataOrigin("COSD")]
[Description("COSD V8 HA Measurement Tumour Laterality")]
[SourceQuery("COSDv8HAMeasurementTumourLaterality.xml")]
internal class COSDv8HAMeasurementTumourLateralityRecord
{
    public string? NhsNumber { get; set; }
    public string? ClinicalDateCancerDiagnosis { get; set; }
    public string? TumourLaterality { get; set; }
}
