using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Colorectal.Measurements.CosdV9MeasurementTNMcategoryFinalPreTreatmentStage;

[DataOrigin("COSD")]
[Description("COSD V9 Measurement TNM Category Final Pre Treatment Stage")]
[SourceQuery("CosdV9MeasurementTNMcategoryFinalPreTreatmentStage.xml")]
internal class CosdV9MeasurementTNMcategoryFinalPreTreatmentStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? TnmStageGroupingFinalPretreatment { get; set; }
}