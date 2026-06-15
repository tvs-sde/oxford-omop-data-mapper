using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.HN.Measurement.COSDv8HNMeasurementTumourLaterality;

[DataOrigin("COSD")]
[Description("COSD v8 HN Measurement Tumour Laterality")]
[SourceQuery("COSDv8HNMeasurementTumourLaterality.xml")]
internal class COSDv8HNMeasurementTumourLateralityRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? TumourLaterality { get; set; }
}
