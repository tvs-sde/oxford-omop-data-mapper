using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.UG.Measurement.COSDv9UGMeasurementTCategoryIntegratedStage;

[DataOrigin("COSD")]
[Description("COSD V9 UG Measurement T Category Integrated Stage")]
[SourceQuery("COSDv9UGMeasurementTCategoryIntegratedStage.xml")]
internal class COSDv9UGMeasurementTCategoryIntegratedStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? TCategoryIntegratedStage { get; set; }
}
