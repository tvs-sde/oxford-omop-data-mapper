using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Breast.Measurements.CosdV8BreastMeasurementTumourLaterality;

[DataOrigin("COSD")]
[Description("COSD V8 Breast Measurement Tumour Laterality")]
[SourceQuery("CosdV8BreastMeasurementTumourLaterality.xml")]
internal class CosdV8BreastMeasurementTumourLateralityRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? TumourLaterality { get; set; }
}
