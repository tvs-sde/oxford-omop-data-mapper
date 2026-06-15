using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.LV.Measurement.COSDv8LVMeasurementTumourLaterality;

[DataOrigin("COSD")]
[Description("COSD v8 LV Measurement Tumour Laterality")]
[SourceQuery("COSDv8LVMeasurementTumourLaterality.xml")]
internal class COSDv8LVMeasurementTumourLateralityRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? TumourLaterality { get; set; }
}
