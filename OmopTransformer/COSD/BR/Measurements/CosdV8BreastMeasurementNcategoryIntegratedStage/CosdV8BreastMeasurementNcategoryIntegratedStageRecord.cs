using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Breast.Measurements.CosdV8BreastMeasurementNcategoryIntegratedStage;

[DataOrigin("COSD")]
[Description("COSD V8 Breast Measurement N Category Integrated Stage")]
[SourceQuery("CosdV8BreastMeasurementNcategoryIntegratedStage.xml")]
internal class CosdV8BreastMeasurementNcategoryIntegratedStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? NCategoryIntegratedStage { get; set; }
}
