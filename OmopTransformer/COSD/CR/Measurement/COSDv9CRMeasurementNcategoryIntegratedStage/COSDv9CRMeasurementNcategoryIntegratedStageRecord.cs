using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CR.Measurement.COSDv9CRMeasurementNcategoryIntegratedStage;

[DataOrigin("COSD")]
[Description("COSD v9 CR Measurement Ncategory Integrated Stage")]
[SourceQuery("COSDv9CRMeasurementNcategoryIntegratedStage.xml")]
internal class COSDv9CRMeasurementNcategoryIntegratedStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? NCategoryIntegratedStage { get; set; }
}
