using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Colorectal.Measurements.CosdV9MeasurementTcategoryIntegratedStage;

[DataOrigin("COSD")]
[Description("COSD V9 Measurement T Category Integrated Stage")]
[SourceQuery("CosdV9MeasurementTcategoryIntegratedStage.xml")]
internal class CosdV9MeasurementTcategoryIntegratedStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? TCategoryIntegratedStage { get; set; }
}