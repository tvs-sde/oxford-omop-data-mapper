using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.SK.Measurement.COSDv8SKMeasurementTNMStageGroupingFinalPretreatment;

[DataOrigin("COSD")]
[Description("COSD V8 SK Measurement TNM Stage Grouping Final Pretreatment")]
[SourceQuery("COSDv8SKMeasurementTNMStageGroupingFinalPretreatment.xml")]
internal class COSDv8SKMeasurementTNMStageGroupingFinalPretreatmentRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? TnmStageGroupingFinalPreTreatment { get; set; }
}
