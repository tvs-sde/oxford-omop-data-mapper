using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.SK.Measurement.COSDv8SKMeasurementTumourLaterality;

[DataOrigin("COSD")]
[Description("COSD V8 SK Measurement Tumour Laterality")]
[SourceQuery("COSDv8SKMeasurementTumourLaterality.xml")]
internal class COSDv8SKMeasurementTumourLateralityRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? TumourLaterality { get; set; }
}
