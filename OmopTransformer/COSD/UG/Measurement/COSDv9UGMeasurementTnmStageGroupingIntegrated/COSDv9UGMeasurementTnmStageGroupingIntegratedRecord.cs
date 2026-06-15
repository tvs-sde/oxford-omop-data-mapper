using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.UG.Measurement.COSDv9UGMeasurementTnmStageGroupingIntegrated;

[DataOrigin("COSD")]
[Description("COSD V9 UG Measurement Tnm Stage Grouping Integrated")]
[SourceQuery("COSDv9UGMeasurementTnmStageGroupingIntegrated.xml")]
internal class COSDv9UGMeasurementTnmStageGroupingIntegratedRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? TnmStageGroupingIntegrated { get; set; }
}
