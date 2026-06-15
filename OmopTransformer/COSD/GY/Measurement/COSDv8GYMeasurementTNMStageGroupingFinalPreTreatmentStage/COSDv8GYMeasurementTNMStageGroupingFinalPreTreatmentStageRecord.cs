using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.GY.Measurement.COSDv8GYMeasurementTNMStageGroupingFinalPreTreatmentStage;

[DataOrigin("COSD")]
[Description("COSD V8 GY Measurement TNM Stage Grouping Final Pre Treatment Stage")]
[SourceQuery("COSDv8GYMeasurementTNMStageGroupingFinalPreTreatmentStage.xml")]
internal class COSDv8GYMeasurementTNMStageGroupingFinalPreTreatmentStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? TnmStageGroupingFinalPretreatment { get; set; }
}
