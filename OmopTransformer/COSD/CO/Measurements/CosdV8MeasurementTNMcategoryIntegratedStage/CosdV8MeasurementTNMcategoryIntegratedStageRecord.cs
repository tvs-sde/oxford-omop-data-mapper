using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Colorectal.Measurements.CosdV8MeasurementTNMcategoryIntegratedStage;

[DataOrigin("COSD")]
[Description("COSD V8 Measurement TNM Category Integrated Stage")]
[SourceQuery("CosdV8MeasurementTNMcategoryIntegratedStage.xml")]
internal class CosdV8MeasurementTNMcategoryIntegratedStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? TnmStageGroupingIntegrated { get; set; }
}