using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Lung.Measurements.CosdV9LungMeasurementTNMcategoryFinalPreTreatmentStage;

[DataOrigin("COSD")]
[Description("COSD V9 Lung Measurement TNM Category Final Pre Treatment Stage")]
[SourceQuery("CosdV9LungMeasurementTNMcategoryFinalPreTreatmentStage.xml")]
internal class CosdV9LungMeasurementTNMcategoryFinalPreTreatmentStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? TnmStageGroupingFinalPretreatment { get; set; }
}
