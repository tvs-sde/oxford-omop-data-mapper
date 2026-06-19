using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Breast.Measurements.CosdV9BreastMeasurementTNMcategoryIntegratedStage;

[DataOrigin("COSD")]
[Description("COSD V9 Breast Measurement TNM Category Integrated Stage")]
[SourceQuery("CosdV9BreastMeasurementTNMcategoryIntegratedStage.xml")]
internal class CosdV9BreastMeasurementTNMcategoryIntegratedStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? TnmStageGroupingIntegrated { get; set; }
}
