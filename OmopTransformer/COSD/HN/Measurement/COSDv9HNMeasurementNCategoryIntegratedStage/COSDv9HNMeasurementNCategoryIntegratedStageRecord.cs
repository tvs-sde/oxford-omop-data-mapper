using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.HN.Measurement.COSDv9HNMeasurementNCategoryIntegratedStage;

[DataOrigin("COSD")]
[Description("COSD V9 HN Measurement N Category Integrated Stage")]
[SourceQuery("COSDv9HNMeasurementNCategoryIntegratedStage.xml")]
internal class COSDv9HNMeasurementNCategoryIntegratedStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? NCategoryIntegratedStage { get; set; }
}
