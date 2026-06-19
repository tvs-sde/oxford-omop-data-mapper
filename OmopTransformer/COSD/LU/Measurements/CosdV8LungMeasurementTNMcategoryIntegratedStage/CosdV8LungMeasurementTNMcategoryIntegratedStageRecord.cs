using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Lung.Measurements.CosdV8LungMeasurementTNMcategoryIntegratedStage;

[DataOrigin("COSD")]
[Description("COSD V8 Lung Measurement TNM Category Integrated Stage")]
[SourceQuery("CosdV8LungMeasurementTNMcategoryIntegratedStage.xml")]
internal class CosdV8LungMeasurementTNMcategoryIntegratedStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? TnmStageGroupingIntegrated { get; set; }
}
