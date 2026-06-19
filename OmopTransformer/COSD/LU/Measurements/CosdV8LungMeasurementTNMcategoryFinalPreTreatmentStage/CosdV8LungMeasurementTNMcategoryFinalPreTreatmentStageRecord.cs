using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Lung.Measurements.CosdV8LungMeasurementTNMcategoryFinalPreTreatmentStage;

[DataOrigin("COSD")]
[Description("COSD V8 Lung Measurement TNM Category Final Pre Treatment Stage")]
[SourceQuery("CosdV8LungMeasurementTNMcategoryFinalPreTreatmentStage.xml")]
internal class CosdV8LungMeasurementTNMcategoryFinalPreTreatmentStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? TnmStageGroupingFinalPretreatment { get; set; }
}
