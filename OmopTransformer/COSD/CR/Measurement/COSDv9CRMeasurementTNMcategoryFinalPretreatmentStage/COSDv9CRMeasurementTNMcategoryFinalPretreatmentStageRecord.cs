using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CR.Measurement.COSDv9CRMeasurementTNMcategoryFinalPretreatmentStage;

[DataOrigin("COSD")]
[Description("COSD v9 CR Measurement TNM Category Final Pretreatment Stage")]
[SourceQuery("COSDv9CRMeasurementTNMcategoryFinalPretreatmentStage.xml")]
internal class COSDv9CRMeasurementTNMcategoryFinalPretreatmentStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? TnmStageGroupingFinalPretreatment { get; set; }
}
