using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.UR.Measurement.COSDv9URMeasurementTumourLaterality;

[DataOrigin("COSD")]
[Description("COSD V9 UR Measurement Tumour Laterality")]
[SourceQuery("COSDv9URMeasurementTumourLaterality.xml")]
internal class COSDv9URMeasurementTumourLateralityRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? TumourLaterality { get; set; }
}
