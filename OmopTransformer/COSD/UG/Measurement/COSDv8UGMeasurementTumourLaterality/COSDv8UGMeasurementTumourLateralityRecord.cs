using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.UG.Measurement.COSDv8UGMeasurementTumourLaterality;

[DataOrigin("COSD")]
[Description("COSD V8 UG Measurement Tumour Laterality")]
[SourceQuery("COSDv8UGMeasurementTumourLaterality.xml")]
internal class COSDv8UGMeasurementTumourLateralityRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? TumourLaterality { get; set; }
}
