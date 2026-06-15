using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.HN.Measurement.COSDv9HNMeasurementMCategoryIntegratedStage;

[DataOrigin("COSD")]
[Description("COSD V9 HN Measurement M Category Integrated Stage")]
[SourceQuery("COSDv9HNMeasurementMCategoryIntegratedStage.xml")]
internal class COSDv9HNMeasurementMCategoryIntegratedStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? MCategoryIntegratedStage { get; set; }
}
