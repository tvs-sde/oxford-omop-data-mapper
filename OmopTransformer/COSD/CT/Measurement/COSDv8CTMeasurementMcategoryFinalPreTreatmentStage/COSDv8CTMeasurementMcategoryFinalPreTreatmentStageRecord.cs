using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CT.Measurement.COSDv8CTMeasurementMcategoryFinalPreTreatmentStage;

[Serializable]
[DataOrigin("COSD")]
[Description("COSD V8 CT Measurement Mcategory Final Pre Treatment Stage")]
[SourceQuery("COSDv8CTMeasurementMcategoryFinalPreTreatmentStage.xml")]
internal class COSDv8CTMeasurementMcategoryFinalPreTreatmentStageRecord
{
    public string? NhsNumber { get; init; }
    public string? MeasurementDate { get; init; }
    public string? McategoryFinalPreTreatment { get; init; }
}
