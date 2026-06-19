using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Breast.Measurements.CosdV8BreastMeasurementTcategoryIntegratedStage;

[DataOrigin("COSD")]
[Description("COSD V8 Breast Measurement T Category Integrated Stage")]
[SourceQuery("CosdV8BreastMeasurementTcategoryIntegratedStage.xml")]
internal class CosdV8BreastMeasurementTcategoryIntegratedStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? TCategoryIntegratedStage { get; set; }
}
