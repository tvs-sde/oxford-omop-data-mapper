using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Breast.Measurements.CosdV9BreastMeasurementTNMcategoryFinalPreTreatmentStage;

[DataOrigin("COSD")]
[Description("COSD V9 Breast Measurement TNM Category Final Pre-Treatment Stage")]
[SourceQuery("CosdV9BreastMeasurementTNMcategoryFinalPreTreatmentStage.xml")]
internal class CosdV9BreastMeasurementTNMcategoryFinalPreTreatmentStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? TnmStageGroupingFinalPretreatment { get; set; }
}
