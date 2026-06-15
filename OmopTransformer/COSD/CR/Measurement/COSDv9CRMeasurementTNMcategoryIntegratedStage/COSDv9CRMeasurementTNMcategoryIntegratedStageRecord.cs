using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CR.Measurement.COSDv9CRMeasurementTNMcategoryIntegratedStage;

[DataOrigin("COSD")]
[Description("COSD v9 CR Measurement TNM Category Integrated Stage")]
[SourceQuery("COSDv9CRMeasurementTNMcategoryIntegratedStage.xml")]
internal class COSDv9CRMeasurementTNMcategoryIntegratedStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? TnmStageGroupingIntegrated { get; set; }
}
