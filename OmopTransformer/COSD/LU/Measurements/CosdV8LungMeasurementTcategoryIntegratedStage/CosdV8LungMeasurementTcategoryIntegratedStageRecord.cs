using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Lung.Measurements.CosdV8LungMeasurementTcategoryIntegratedStage;

[DataOrigin("COSD")]
[Description("COSD V8 Lung Measurement T Category Integrated Stage")]
[SourceQuery("CosdV8LungMeasurementTcategoryIntegratedStage.xml")]
internal class CosdV8LungMeasurementTcategoryIntegratedStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? TCategoryIntegratedStage { get; set; }
}
