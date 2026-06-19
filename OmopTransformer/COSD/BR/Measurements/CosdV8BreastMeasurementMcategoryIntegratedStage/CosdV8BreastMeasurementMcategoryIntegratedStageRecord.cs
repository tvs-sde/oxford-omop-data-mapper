using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Breast.Measurements.CosdV8BreastMeasurementMcategoryIntegratedStage;

[DataOrigin("COSD")]
[Description("COSD V8 Breast Measurement M Category Integrated Stage")]
[SourceQuery("CosdV8BreastMeasurementMcategoryIntegratedStage.xml")]
internal class CosdV8BreastMeasurementMcategoryIntegratedStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? MCategoryIntegratedStage { get; set; }
}
