using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Colorectal.Measurements.CosdV8MeasurementTumourLaterality;

[DataOrigin("COSD")]
[Description("COSD V8 Measurement Tumour Laterality")]
[SourceQuery("CosdV8MeasurementTumourLaterality.xml")]
internal class CosdV8MeasurementTumourLateralityRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? TumourLaterality { get; set; }
}