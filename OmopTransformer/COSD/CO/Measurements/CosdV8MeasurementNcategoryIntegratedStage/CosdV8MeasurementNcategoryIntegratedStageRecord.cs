using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Colorectal.Measurements.CosdV8MeasurementNcategoryIntegratedStage;

[DataOrigin("COSD")]
[Description("COSD V8 Measurement N Category Integrated Stage")]
[SourceQuery("CosdV8MeasurementNcategoryIntegratedStage.xml")]
internal class CosdV8MeasurementNcategoryIntegratedStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? NCategoryIntegratedStage { get; set; }
}