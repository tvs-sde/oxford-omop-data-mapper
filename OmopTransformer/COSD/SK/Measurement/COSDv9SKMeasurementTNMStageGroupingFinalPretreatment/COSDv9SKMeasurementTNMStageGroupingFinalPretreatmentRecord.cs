using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.SK.Measurement.COSDv9SKMeasurementTNMStageGroupingFinalPretreatment;

[DataOrigin("COSD")]
[Description("COSD V9 SK Measurement TNM Stage Grouping Final Pretreatment")]
[SourceQuery("COSDv9SKMeasurementTNMStageGroupingFinalPretreatment.xml")]
internal class COSDv9SKMeasurementTNMStageGroupingFinalPretreatmentRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? TnmStageGroupingFinalPretreatment { get; set; }
}
