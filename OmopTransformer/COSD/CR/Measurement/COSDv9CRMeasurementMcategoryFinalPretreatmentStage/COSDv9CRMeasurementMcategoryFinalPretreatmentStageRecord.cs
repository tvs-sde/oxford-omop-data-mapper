using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CR.Measurement.COSDv9CRMeasurementMcategoryFinalPretreatmentStage;

[DataOrigin("COSD")]
[Description("COSD v9 CR Measurement Mcategory Final Pretreatment Stage")]
[SourceQuery("COSDv9CRMeasurementMcategoryFinalPretreatmentStage.xml")]
internal class COSDv9CRMeasurementMcategoryFinalPretreatmentStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? MCategoryFinalPretreatment { get; set; }
}
