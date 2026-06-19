using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Breast.Measurements.CosdV9BreastMeasurementNcategoryIntegratedStage;

[DataOrigin("COSD")]
[Description("COSD V9 Breast Measurement N Category Integrated Stage")]
[SourceQuery("CosdV9BreastMeasurementNcategoryIntegratedStage.xml")]
internal class CosdV9BreastMeasurementNcategoryIntegratedStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? NCategoryIntegratedStage { get; set; }
}
