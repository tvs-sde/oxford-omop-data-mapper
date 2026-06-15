using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.SA.Measurement.COSDv9SAMeasurementTNMcategoryIntegratedStage;

[DataOrigin("COSD")]
[Description("COSD V9 SA Measurement TNM Category Integrated Stage")]
[SourceQuery("COSDv9SAMeasurementTNMcategoryIntegratedStage.xml")]
internal class COSDv9SAMeasurementTNMcategoryIntegratedStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? TnmStageGroupingIntegrated { get; set; }
}
