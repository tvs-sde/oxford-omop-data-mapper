using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.HN.Measurement.COSDv9HNMeasurementTCategoryIntegratedStage;

[DataOrigin("COSD")]
[Description("COSD V9 HN Measurement T Category Integrated Stage")]
[SourceQuery("COSDv9HNMeasurementTCategoryIntegratedStage.xml")]
internal class COSDv9HNMeasurementTCategoryIntegratedStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? TCategoryIntegratedStage { get; set; }
}
