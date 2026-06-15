using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.UG.Measurement.COSDv8UGMeasurementFinalPretreatmentTNMStageGrouping;

[DataOrigin("COSD")]
[Description("COSD V8 UG Measurement Final Pretreatment TNM Stage Grouping")]
[SourceQuery("COSDv8UGMeasurementFinalPretreatmentTNMStageGrouping.xml")]
internal class COSDv8UGMeasurementFinalPretreatmentTNMStageGroupingRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? FinalPreTreatmentTNMStageGrouping { get; set; }
}
