using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.LV.Measurement.COSDv8LVMeasurementTNMStageGroupingIntegrated;

[DataOrigin("COSD")]
[Description("COSD v8 LV Measurement TNM Stage Grouping Integrated")]
[SourceQuery("COSDv8LVMeasurementTNMStageGroupingIntegrated.xml")]
internal class COSDv8LVMeasurementTNMStageGroupingIntegratedRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? TnmStageGroupingIntegrated { get; set; }
}
