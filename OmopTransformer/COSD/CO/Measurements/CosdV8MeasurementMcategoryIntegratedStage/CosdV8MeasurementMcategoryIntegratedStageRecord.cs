using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Colorectal.Measurements.CosdV8MeasurementMcategoryIntegratedStage;

[DataOrigin("COSD")]
[Description("COSD V8 Measurement M Category Integrated Stage")]
[SourceQuery("CosdV8MeasurementMcategoryIntegratedStage.xml")]
internal class CosdV8MeasurementMcategoryIntegratedStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? MCategoryIntegratedStage { get; set; }
}