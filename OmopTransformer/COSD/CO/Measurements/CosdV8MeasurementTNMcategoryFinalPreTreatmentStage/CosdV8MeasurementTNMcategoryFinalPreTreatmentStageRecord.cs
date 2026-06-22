using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Colorectal.Measurements.CosdV8MeasurementTNMcategoryFinalPreTreatmentStage;

[DataOrigin("COSD")]
[Description("COSD V8 Measurement TNM Category Final Pre Treatment Stage")]
[SourceQuery("CosdV8MeasurementTNMcategoryFinalPreTreatmentStage.xml")]
internal class CosdV8MeasurementTNMcategoryFinalPreTreatmentStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? TnmStageGroupingFinalPretreatment { get; set; }
}