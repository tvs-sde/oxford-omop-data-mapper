using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.BR.Measurements.CosdV9BreastMeasurementMcategoryIntegratedStage;

[DataOrigin("COSD")]
[Description("COSD V9 Breast Measurement M Category Integrated Stage")]
[SourceQuery("CosdV9BreastMeasurementMcategoryIntegratedStage.xml")]
internal class CosdV9BreastMeasurementMcategoryIntegratedStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? MCategoryIntegratedStage { get; set; }
}
