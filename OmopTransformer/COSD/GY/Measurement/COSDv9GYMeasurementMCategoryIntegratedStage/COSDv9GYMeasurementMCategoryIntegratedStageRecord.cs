using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.GY.Measurement.COSDv9GYMeasurementMCategoryIntegratedStage;

[DataOrigin("COSD")]
[Description("COSD V9 GY Measurement M Category Integrated Stage")]
[SourceQuery("COSDv9GYMeasurementMCategoryIntegratedStage.xml")]
internal class COSDv9GYMeasurementMCategoryIntegratedStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? MCategoryIntegratedStage { get; set; }
}
