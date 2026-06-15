using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CT.Measurement.COSDv8CTMeasurementTNMStageGroupingIntegrated;

[DataOrigin("COSD")]
[Description("COSD V8 CT Measurement TNM Stage Grouping Integrated")]
[SourceQuery("COSDv8CTMeasurementTNMStageGroupingIntegrated.xml")]
internal class COSDv8CTMeasurementTNMStageGroupingIntegratedRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? TNMStageGroupingIntegrated { get; set; }
}
