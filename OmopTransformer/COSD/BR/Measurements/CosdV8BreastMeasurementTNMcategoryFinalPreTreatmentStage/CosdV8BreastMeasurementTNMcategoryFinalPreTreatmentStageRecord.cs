using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Breast.Measurements.CosdV8BreastMeasurementTNMcategoryFinalPreTreatmentStage;

[DataOrigin("COSD")]
[Description("COSD V8 Breast Measurement TNM Category Final Pre Treatment Stage")]
[SourceQuery("CosdV8BreastMeasurementTNMcategoryFinalPreTreatmentStage.xml")]
internal class CosdV8BreastMeasurementTNMcategoryFinalPreTreatmentStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? TnmStageGroupingFinalPretreatment { get; set; }
}
