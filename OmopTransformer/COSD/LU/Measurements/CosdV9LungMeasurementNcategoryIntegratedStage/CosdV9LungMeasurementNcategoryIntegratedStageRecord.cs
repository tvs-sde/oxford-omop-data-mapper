using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Lung.Measurements.CosdV9LungMeasurementNcategoryIntegratedStage;

[DataOrigin("COSD")]
[Description("COSD V9 Lung Measurement N Category Integrated Stage")]
[SourceQuery("CosdV9LungMeasurementNcategoryIntegratedStage.xml")]
internal class CosdV9LungMeasurementNcategoryIntegratedStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? NCategoryIntegratedStage { get; set; }
}
