using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.GY.Measurement.COSDv9GYMeasurementTCategoryIntegratedStage;

[DataOrigin("COSD")]
[Description("COSD V9 GY Measurement T Category Integrated Stage")]
[SourceQuery("COSDv9GYMeasurementTCategoryIntegratedStage.xml")]
internal class COSDv9GYMeasurementTCategoryIntegratedStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? TCategoryIntegratedStage { get; set; }
}
