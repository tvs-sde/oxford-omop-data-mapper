using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Lung.Measurements.CosdV8LungMeasurementTumourLaterality;

[DataOrigin("COSD")]
[Description("COSD V8 Lung Measurement Tumour Laterality")]
[SourceQuery("CosdV8LungMeasurementTumourLaterality.xml")]
internal class CosdV8LungMeasurementTumourLateralityRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? TumourLaterality { get; set; }
}
