using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.HN.Measurement.COSDv9HNMeasurementTnmStageGroupingIntegrated;

[DataOrigin("COSD")]
[Description("COSD V9 HN Measurement Tnm Stage Grouping Integrated")]
[SourceQuery("COSDv9HNMeasurementTnmStageGroupingIntegrated.xml")]
internal class COSDv9HNMeasurementTnmStageGroupingIntegratedRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? TnmStageGroupingIntegrated { get; set; }
}
