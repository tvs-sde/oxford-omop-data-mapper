using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Colorectal.Measurements.CosdV9MeasurementMcategoryIntegratedStage;

[DataOrigin("COSD")]
[Description("COSD V9 Measurement M Category Integrated Stage")]
[SourceQuery("CosdV9MeasurementMcategoryIntegratedStage.xml")]
internal class CosdV9MeasurementMcategoryIntegratedStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? MCategoryIntegratedStage { get; set; }
}