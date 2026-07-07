using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CR.Measurement.COSDv8CRMeasurementMcategoryIntegratedStage;

[Serializable]
[DataOrigin("COSD")]
[Description("COSD V8 CR Measurement Mcategory Integrated Stage")]
[SourceQuery("COSDv8CRMeasurementMcategoryIntegratedStage.xml")]
internal class COSDv8CRMeasurementMcategoryIntegratedStageRecord
{
    public string? NhsNumber { get; init; }
    public string? MeasurementDate { get; init; }
    public string? MCategoryIntegratedStage { get; init; }
}
