using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.GY.Measurement.COSDv9GYMeasurementTnmStageGroupingIntegrated;

[DataOrigin("COSD")]
[Description("COSD V9 GY Measurement Tnm Stage Grouping Integrated")]
[SourceQuery("COSDv9GYMeasurementTnmStageGroupingIntegrated.xml")]
internal class COSDv9GYMeasurementTnmStageGroupingIntegratedRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? TnmStageGroupingIntegrated { get; set; }
}
