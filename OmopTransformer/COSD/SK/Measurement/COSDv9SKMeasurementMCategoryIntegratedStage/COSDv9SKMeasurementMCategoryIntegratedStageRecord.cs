using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.SK.Measurement.COSDv9SKMeasurementMCategoryIntegratedStage;

[DataOrigin("COSD")]
[Description("COSD V9 SK Measurement M Category Integrated Stage")]
[SourceQuery("COSDv9SKMeasurementMCategoryIntegratedStage.xml")]
internal class COSDv9SKMeasurementMCategoryIntegratedStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? MCategoryIntegratedStage { get; set; }
}
