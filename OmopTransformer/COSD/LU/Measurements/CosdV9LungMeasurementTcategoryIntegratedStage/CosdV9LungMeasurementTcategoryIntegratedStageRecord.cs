using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Lung.Measurements.CosdV9LungMeasurementTcategoryIntegratedStage;

[DataOrigin("COSD")]
[Description("COSD V9 Lung Measurement T Category Integrated Stage")]
[SourceQuery("CosdV9LungMeasurementTcategoryIntegratedStage.xml")]
internal class CosdV9LungMeasurementTcategoryIntegratedStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? TCategoryIntegratedStage { get; set; }
}
