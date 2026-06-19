using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Lung.Measurements.CosdV8LungMeasurementMcategoryIntegratedStage;

[DataOrigin("COSD")]
[Description("COSD V8 Lung Measurement M Category (Integrated Stage)")]
[SourceQuery("CosdV8LungMeasurementMcategoryIntegratedStage.xml")]
internal class CosdV8LungMeasurementMcategoryIntegratedStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? MCategoryIntegratedStage { get; set; }
}