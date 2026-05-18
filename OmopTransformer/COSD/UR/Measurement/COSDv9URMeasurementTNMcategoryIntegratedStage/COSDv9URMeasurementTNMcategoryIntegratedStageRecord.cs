using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.UR.Measurement.COSDv9URMeasurementTNMcategoryIntegratedStage;

[DataOrigin("COSD")]
[Description("COSD V9 UR Measurement TNM Category Integrated Stage")]
[SourceQuery("COSDv9URMeasurementTNMcategoryIntegratedStage.xml")]
internal class COSDv9URMeasurementTNMcategoryIntegratedStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? TnmStageGroupingIntegrated { get; set; }
}
