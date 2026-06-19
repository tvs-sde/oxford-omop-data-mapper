using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Lung.Measurements.CosdV9LungMeasurementTNMcategoryIntegratedStage;

[DataOrigin("COSD")]
[Description("COSD V9 Lung Measurement TNM Category Integrated Stage")]
[SourceQuery("CosdV9LungMeasurementTNMcategoryIntegratedStage.xml")]
internal class CosdV9LungMeasurementTNMcategoryIntegratedStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? TnmStageGroupingIntegrated { get; set; }
}
