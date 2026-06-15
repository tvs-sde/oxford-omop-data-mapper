using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.HN.Measurement.COSDv8HNMeasurementTNMcategoryIntegratedStage;

[DataOrigin("COSD")]
[Description("COSD v8 HN Measurement TNMcategory Integrated Stage")]
[SourceQuery("COSDv8HNMeasurementTNMcategoryIntegratedStage.xml")]
internal class COSDv8HNMeasurementTNMcategoryIntegratedStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? TnmStageGroupingIntegrated { get; set; }
}
