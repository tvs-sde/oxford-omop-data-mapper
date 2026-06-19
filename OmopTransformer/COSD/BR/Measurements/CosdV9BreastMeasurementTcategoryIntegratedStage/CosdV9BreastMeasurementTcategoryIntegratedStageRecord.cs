using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Breast.Measurements.CosdV9BreastMeasurementTcategoryIntegratedStage;

[DataOrigin("COSD")]
[Description("COSD V9 Breast Measurement T Category Integrated Stage")]
[SourceQuery("CosdV9BreastMeasurementTcategoryIntegratedStage.xml")]
internal class CosdV9BreastMeasurementTcategoryIntegratedStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? TCategoryIntegratedStage { get; set; }
}
