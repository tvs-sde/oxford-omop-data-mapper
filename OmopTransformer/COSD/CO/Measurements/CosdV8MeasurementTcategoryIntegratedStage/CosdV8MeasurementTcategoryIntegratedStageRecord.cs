using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Colorectal.Measurements.CosdV8MeasurementTcategoryIntegratedStage;

[DataOrigin("COSD")]
[Description("COSD V8 Measurement T Category Integrated Stage")]
[SourceQuery("CosdV8MeasurementTcategoryIntegratedStage.xml")]
internal class CosdV8MeasurementTcategoryIntegratedStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? TCategoryIntegratedStage { get; set; }
}