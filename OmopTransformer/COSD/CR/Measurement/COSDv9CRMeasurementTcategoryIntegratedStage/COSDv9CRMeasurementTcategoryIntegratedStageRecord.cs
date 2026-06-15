using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CR.Measurement.COSDv9CRMeasurementTcategoryIntegratedStage;

[DataOrigin("COSD")]
[Description("COSD v9 CR Measurement Tcategory Integrated Stage")]
[SourceQuery("COSDv9CRMeasurementTcategoryIntegratedStage.xml")]
internal class COSDv9CRMeasurementTcategoryIntegratedStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? TCategoryIntegratedStage { get; set; }
}
