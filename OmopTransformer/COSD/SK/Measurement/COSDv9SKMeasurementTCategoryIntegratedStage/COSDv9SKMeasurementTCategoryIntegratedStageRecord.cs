using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.SK.Measurement.COSDv9SKMeasurementTCategoryIntegratedStage;

[DataOrigin("COSD")]
[Description("COSD V9 SK Measurement T Category Integrated Stage")]
[SourceQuery("COSDv9SKMeasurementTCategoryIntegratedStage.xml")]
internal class COSDv9SKMeasurementTCategoryIntegratedStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? TCategoryIntegratedStage { get; set; }
}
