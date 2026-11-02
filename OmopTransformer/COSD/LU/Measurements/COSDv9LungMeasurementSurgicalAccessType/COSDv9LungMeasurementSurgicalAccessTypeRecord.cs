using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.LU.Measurement.COSDv9LungMeasurementSurgicalAccessType;

[DataOrigin("COSD")]
[Description("COSD V9 Lung Measurement Surgical Access Type")]
[SourceQuery("COSDv9LungMeasurementSurgicalAccessType.xml")]
internal class COSDv9LungMeasurementSurgicalAccessTypeRecord
{
    public string? NhsNumber { get; set; }
    public DateOnly? Date { get; set; }
    public string? SurgicalAccessType { get; set; }
}
