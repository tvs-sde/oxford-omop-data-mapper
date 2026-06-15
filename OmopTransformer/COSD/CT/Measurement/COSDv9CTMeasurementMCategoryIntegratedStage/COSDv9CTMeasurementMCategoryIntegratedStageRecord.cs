using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CT.Measurement.COSDv9CTMeasurementMCategoryIntegratedStage;

[DataOrigin("COSD")]
[Description("COSD v9 CT Measurement M Category Integrated Stage")]
[SourceQuery("COSDv9CTMeasurementMCategoryIntegratedStage.xml")]
internal class COSDv9CTMeasurementMCategoryIntegratedStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? MCategoryIntegratedStage { get; set; }
}
