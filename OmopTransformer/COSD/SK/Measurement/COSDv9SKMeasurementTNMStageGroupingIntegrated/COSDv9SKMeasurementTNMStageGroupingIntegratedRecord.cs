using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.SK.Measurement.COSDv9SKMeasurementTNMStageGroupingIntegrated;

[DataOrigin("COSD")]
[Description("COSD V9 SK Measurement TNM Stage Grouping Integrated")]
[SourceQuery("COSDv9SKMeasurementTNMStageGroupingIntegrated.xml")]
internal class COSDv9SKMeasurementTNMStageGroupingIntegratedRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? TnmStageGroupingIntegrated { get; set; }
}
