using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CT.Measurement.COSDv8CTMeasurementTNMStageGroupingFinalPreTreatmentStage;

[DataOrigin("COSD")]
[Description("COSD V8 CT Measurement TNM Stage Grouping Final Pre Treatment Stage")]
[SourceQuery("COSDv8CTMeasurementTNMStageGroupingFinalPreTreatmentStage.xml")]
internal class COSDv8CTMeasurementTNMStageGroupingFinalPreTreatmentStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? TNMStageGroupingFinalPreTreatment { get; set; }
}
