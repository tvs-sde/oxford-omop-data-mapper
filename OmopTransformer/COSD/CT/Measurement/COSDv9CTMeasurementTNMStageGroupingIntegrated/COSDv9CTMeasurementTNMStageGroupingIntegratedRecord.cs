using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CT.Measurement.COSDv9CTMeasurementTNMStageGroupingIntegrated;

[DataOrigin("COSD")]
[Description("COSD V9 CT Measurement TNM Stage Grouping Integrated")]
[SourceQuery("COSDv9CTMeasurementTNMStageGroupingIntegrated.xml")]
internal class COSDv9CTMeasurementTNMStageGroupingIntegratedRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? TnmStageGroupingIntegrated { get; set; }
}
