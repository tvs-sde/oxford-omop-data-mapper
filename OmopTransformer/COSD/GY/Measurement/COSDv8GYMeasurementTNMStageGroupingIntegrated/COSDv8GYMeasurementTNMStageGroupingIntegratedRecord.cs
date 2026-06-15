using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.GY.Measurement.COSDv8GYMeasurementTNMStageGroupingIntegrated;

[DataOrigin("COSD")]
[Description("COSD V8 GY Measurement TNM Stage Grouping Integrated")]
[SourceQuery("COSDv8GYMeasurementTNMStageGroupingIntegrated.xml")]
internal class COSDv8GYMeasurementTNMStageGroupingIntegratedRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? TnmStageGroupingIntegrated { get; set; }
}
