using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CT.Measurement.COSDv9CTMeasurementTCategoryIntegratedStage;

[DataOrigin("COSD")]
[Description("COSD V9 CT Measurement T Category Integrated Stage")]
[SourceQuery("COSDv9CTMeasurementTCategoryIntegratedStage.xml")]
internal class COSDv9CTMeasurementTCategoryIntegratedStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? TCategoryIntegratedStage { get; set; }
}
