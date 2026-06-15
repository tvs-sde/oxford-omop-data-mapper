using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CR.Measurement.COSDv9CRMeasurementMcategoryIntegratedStage;

[DataOrigin("COSD")]
[Description("COSD v9 CR Measurement Mcategory Integrated Stage")]
[SourceQuery("COSDv9CRMeasurementMcategoryIntegratedStage.xml")]
internal class COSDv9CRMeasurementMcategoryIntegratedStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? MCategoryIntegratedStage { get; set; }
}
