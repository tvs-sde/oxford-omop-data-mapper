using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.UR.Measurement.COSDv8URMeasurementTumourLaterality;

[DataOrigin("COSD")]
[Description("COSD V8 UR Measurement Tumour Laterality")]
[SourceQuery("COSDv8URMeasurementTumourLaterality.xml")]
internal class COSDv8URMeasurementTumourLateralityRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? TumourLaterality { get; set; }
}
