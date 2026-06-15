using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.SK.Measurement.COSDv8SKMeasurementMCategoryIntegratedStage;

[DataOrigin("COSD")]
[Description("COSD v8 SK Measurement MCategory Integrated Stage")]
[SourceQuery("COSDv8SKMeasurementMCategoryIntegratedStage.xml")]
internal class COSDv8SKMeasurementMCategoryIntegratedStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? McategoryIntegratedStage { get; set; }
}
