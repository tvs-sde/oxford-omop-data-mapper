using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.LV.Measurement.COSDv9LVMeasurementTNMStageGroupingIntegrated;

[DataOrigin("COSD")]
[Description("COSD V9 LV Measurement TNM Stage Grouping Integrated")]
[SourceQuery("COSDv9LVMeasurementTNMStageGroupingIntegrated.xml")]
internal class COSDv9LVMeasurementTNMStageGroupingIntegratedRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? TnmStageGroupingIntegrated { get; set; }
}
