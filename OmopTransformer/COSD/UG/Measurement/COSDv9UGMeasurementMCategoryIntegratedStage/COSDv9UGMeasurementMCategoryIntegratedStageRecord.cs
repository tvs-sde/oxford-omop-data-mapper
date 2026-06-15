using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.UG.Measurement.COSDv9UGMeasurementMCategoryIntegratedStage;

[DataOrigin("COSD")]
[Description("COSD V9 UG Measurement M Category Integrated Stage")]
[SourceQuery("COSDv9UGMeasurementMCategoryIntegratedStage.xml")]
internal class COSDv9UGMeasurementMCategoryIntegratedStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? MCategoryIntegratedStage { get; set; }
}
