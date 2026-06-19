using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Lung.Measurements.CosdV9LungMeasurementMcategoryIntegratedStage;

[DataOrigin("COSD")]
[Description("COSD V9 Lung Measurement M Category Integrated Stage")]
[SourceQuery("CosdV9LungMeasurementMcategoryIntegratedStage.xml")]
internal class CosdV9LungMeasurementMcategoryIntegratedStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? MCategoryIntegratedStage { get; set; }
}
