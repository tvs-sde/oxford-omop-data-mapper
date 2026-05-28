using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.UG.Measurement.COSDv8UGMeasurementIntegratedStageTNMStageGrouping;

[DataOrigin("COSD")]
[Description("COSD V8 UG Measurement Integrated Stage TNM Stage Grouping")]
[SourceQuery("COSDv8UGMeasurementIntegratedStageTNMStageGrouping.xml")]
internal class COSDv8UGMeasurementIntegratedStageTNMStageGroupingRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? IntegratedStageTNMStageGrouping { get; set; }
}
