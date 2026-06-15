using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CR.Measurement.COSDv9CRMeasurementTcategoryFinalPretreatmentStage;

[DataOrigin("COSD")]
[Description("COSD v9 CR Measurement Tcategory Final Pretreatment Stage")]
[SourceQuery("COSDv9CRMeasurementTcategoryFinalPretreatmentStage.xml")]
internal class COSDv9CRMeasurementTcategoryFinalPretreatmentStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? TCategoryFinalPretreatment { get; set; }
}
