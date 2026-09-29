using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.LU.Measurement.COSDv8LungMeasurementSurgicalAccessType;

[DataOrigin("COSD")]
[Description("COSD V8 Lung Measurement Surgical Access Type")]
[SourceQuery("COSDv8LungMeasurementSurgicalAccessType.xml")]
internal class COSDv8LungMeasurementSurgicalAccessTypeRecord
{
    public string? NhsNumber { get; set; }
    public DateOnly? Date { get; set; }
    public string? SurgicalAccessType { get; set; }
}
