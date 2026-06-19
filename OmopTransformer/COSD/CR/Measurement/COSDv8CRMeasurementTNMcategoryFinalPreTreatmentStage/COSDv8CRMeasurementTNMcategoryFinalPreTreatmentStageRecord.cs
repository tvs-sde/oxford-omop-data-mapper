using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CR.Measurement.COSDv8CRMeasurementTNMcategoryFinalPreTreatmentStage;

[Serializable]
[DataOrigin("COSD")]
[Description("COSD V8 CR Measurement TNM Category Final Pre Treatment Stage")]
[SourceQuery("COSDv8CRMeasurementTNMcategoryFinalPreTreatmentStage.xml")]
internal class COSDv8CRMeasurementTNMcategoryFinalPreTreatmentStageRecord
{
    public string? NhsNumber { get; init; }
    public string? MeasurementDate { get; init; }
    public string? TnmStageGroupingFinalPretreatment { get; init; }
}
