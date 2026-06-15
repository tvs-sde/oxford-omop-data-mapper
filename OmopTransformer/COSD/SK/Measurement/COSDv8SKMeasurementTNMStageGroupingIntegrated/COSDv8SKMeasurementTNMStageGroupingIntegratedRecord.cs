using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.SK.Measurement.COSDv8SKMeasurementTNMStageGroupingIntegrated;

[DataOrigin("COSD")]
[Description("COSD V8 SK Measurement TNM Stage Grouping Integrated")]
[SourceQuery("COSDv8SKMeasurementTNMStageGroupingIntegrated.xml")]
internal class COSDv8SKMeasurementTNMStageGroupingIntegratedRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? TnmStageGroupingIntegrated { get; set; }
}
