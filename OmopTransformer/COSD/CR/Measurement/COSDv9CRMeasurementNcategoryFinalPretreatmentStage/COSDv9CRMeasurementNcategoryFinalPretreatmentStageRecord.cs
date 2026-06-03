using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CR.Measurement.COSDv9CRMeasurementNcategoryFinalPretreatmentStage;

[DataOrigin("COSD")]
[Description("COSD v9 CR Measurement Ncategory Final Pretreatment Stage")]
[SourceQuery("COSDv9CRMeasurementNcategoryFinalPretreatmentStage.xml")]
internal class COSDv9CRMeasurementNcategoryFinalPretreatmentStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? NCategoryFinalPretreatment { get; set; }
}
