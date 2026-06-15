using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.SK.Measurement.COSDv9SKMeasurementNCategoryIntegratedStage;

[DataOrigin("COSD")]
[Description("COSD V9 SK Measurement N Category Integrated Stage")]
[SourceQuery("COSDv9SKMeasurementNCategoryIntegratedStage.xml")]
internal class COSDv9SKMeasurementNCategoryIntegratedStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? NCategoryIntegratedStage { get; set; }
}
