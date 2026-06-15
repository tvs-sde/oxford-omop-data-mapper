using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.UG.Measurement.COSDv9UGMeasurementNCategoryIntegratedStage;

[DataOrigin("COSD")]
[Description("COSD V9 UG Measurement N Category Integrated Stage")]
[SourceQuery("COSDv9UGMeasurementNCategoryIntegratedStage.xml")]
internal class COSDv9UGMeasurementNCategoryIntegratedStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? NCategoryIntegratedStage { get; set; }
}
