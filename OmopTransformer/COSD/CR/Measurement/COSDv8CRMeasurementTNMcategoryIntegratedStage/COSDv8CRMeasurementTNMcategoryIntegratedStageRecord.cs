using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CR.Measurement.COSDv8CRMeasurementTNMcategoryIntegratedStage;

[Serializable]
[DataOrigin("COSD")]
[Description("COSD V8 CR Measurement TNM Category Integrated Stage")]
[SourceQuery("COSDv8CRMeasurementTNMcategoryIntegratedStage.xml")]
internal class COSDv8CRMeasurementTNMcategoryIntegratedStageRecord
{
    public string? NhsNumber { get; init; }
    public string? MeasurementDate { get; init; }
    public string? TnmStageGroupingIntegrated { get; init; }
}
