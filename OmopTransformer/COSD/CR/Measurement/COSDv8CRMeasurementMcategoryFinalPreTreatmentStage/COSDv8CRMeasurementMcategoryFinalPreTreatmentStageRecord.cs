using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CR.Measurement.COSDv8CRMeasurementMcategoryFinalPreTreatmentStage;

[Serializable]
[DataOrigin("COSD")]
[Description("COSD V8 CR Measurement Mcategory Final Pre Treatment Stage")]
[SourceQuery("COSDv8CRMeasurementMcategoryFinalPreTreatmentStage.xml")]
internal class COSDv8CRMeasurementMcategoryFinalPreTreatmentStageRecord
{
    public string? NhsNumber { get; init; }
    public string? MeasurementDate { get; init; }
    public string? McategoryFinalPreTreatment { get; init; }
}
