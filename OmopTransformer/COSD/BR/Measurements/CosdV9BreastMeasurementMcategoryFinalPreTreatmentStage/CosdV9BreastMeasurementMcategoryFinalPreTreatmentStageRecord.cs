using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Breast.Measurements.CosdV9BreastMeasurementMcategoryFinalPreTreatmentStage;

[DataOrigin("COSD")]
[Description("COSD V9 Breast Measurement M Category Final Pre-Treatment Stage")]
[SourceQuery("CosdV9BreastMeasurementMcategoryFinalPreTreatmentStage.xml")]
internal class CosdV9BreastMeasurementMcategoryFinalPreTreatmentStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? McategoryFinalPreTreatment { get; set; }
}
