using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.SA.Measurement.COSDv8SAMeasurementTumourLaterality;

[DataOrigin("COSD")]
[Description("COSD v8 SA Measurement Tumour Laterality")]
[SourceQuery("COSDv8SAMeasurementTumourLaterality.xml")]
internal class COSDv8SAMeasurementTumourLateralityRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? TumourLaterality { get; set; }
}
