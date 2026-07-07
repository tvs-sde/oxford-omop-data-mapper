using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Colorectal.Measurements.CosdV9MeasurementNcategoryIntegratedStage;

[DataOrigin("COSD")]
[Description("COSD V9 Measurement N Category Integrated Stage")]
[SourceQuery("CosdV9MeasurementNcategoryIntegratedStage.xml")]
internal class CosdV9MeasurementNcategoryIntegratedStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? NCategoryIntegratedStage { get; set; }
}