using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.HN.Measurement.COSDv8HNMeasurementMcategoryIntegratedStage;

[DataOrigin("COSD")]
[Description("COSD v8 HN Measurement Mcategory Integrated Stage")]
[SourceQuery("COSDv8HNMeasurementMcategoryIntegratedStage.xml")]
internal class COSDv8HNMeasurementMcategoryIntegratedStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? McategoryIntegratedStage { get; set; }
}
