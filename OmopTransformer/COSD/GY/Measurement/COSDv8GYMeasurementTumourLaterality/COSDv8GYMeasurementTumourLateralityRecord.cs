using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.GY.Measurement.COSDv8GYMeasurementTumourLaterality;

[DataOrigin("COSD")]
[Description("COSD V8 GY Measurement Tumour Laterality")]
[SourceQuery("COSDv8GYMeasurementTumourLaterality.xml")]
internal class COSDv8GYMeasurementTumourLateralityRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? TumourLaterality { get; set; }
}
