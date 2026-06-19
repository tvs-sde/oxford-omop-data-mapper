using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Lung.Measurements.CosdV8LungMeasurementNcategoryIntegratedStage;

[DataOrigin("COSD")]
[Description("COSD V8 Lung Measurement N Category Integrated Stage")]
[SourceQuery("CosdV8LungMeasurementNcategoryIntegratedStage.xml")]
internal class CosdV8LungMeasurementNcategoryIntegratedStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? NCategoryIntegratedStage { get; set; }
}
