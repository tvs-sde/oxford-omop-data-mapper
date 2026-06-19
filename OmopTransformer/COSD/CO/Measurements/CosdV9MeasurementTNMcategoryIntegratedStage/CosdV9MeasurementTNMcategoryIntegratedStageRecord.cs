using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Colorectal.Measurements.CosdV9MeasurementTNMcategoryIntegratedStage;

[DataOrigin("COSD")]
[Description("COSD V9 Measurement TNM Category Integrated Stage")]
[SourceQuery("CosdV9MeasurementTNMcategoryIntegratedStage.xml")]
internal class CosdV9MeasurementTNMcategoryIntegratedStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? TnmStageGroupingIntegrated { get; set; }
}