using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.GY.Measurement.COSDv9GYMeasurementNCategoryIntegratedStage;

[DataOrigin("COSD")]
[Description("COSD V9 GY Measurement N Category Integrated Stage")]
[SourceQuery("COSDv9GYMeasurementNCategoryIntegratedStage.xml")]
internal class COSDv9GYMeasurementNCategoryIntegratedStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? NCategoryIntegratedStage { get; set; }
}
