using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.LV.Measurement.COSDv9LVMeasurementTNMStageGroupingFinalPreTreatmentStage;

[DataOrigin("COSD")]
[Description("COSD V9 LV Measurement TNM Stage Grouping Final Pre Treatment Stage")]
[SourceQuery("COSDv9LVMeasurementTNMStageGroupingFinalPreTreatmentStage.xml")]
internal class COSDv9LVMeasurementTNMStageGroupingFinalPreTreatmentStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? TnmStageGroupingFinalPretreatment { get; set; }
}
