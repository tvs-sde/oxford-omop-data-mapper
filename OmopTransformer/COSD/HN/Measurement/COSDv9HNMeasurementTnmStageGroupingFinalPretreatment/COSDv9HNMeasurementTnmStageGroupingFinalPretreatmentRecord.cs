using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.HN.Measurement.COSDv9HNMeasurementTnmStageGroupingFinalPretreatment;

[DataOrigin("COSD")]
[Description("COSD V9 HN Measurement Tnm Stage Grouping Final Pretreatment")]
[SourceQuery("COSDv9HNMeasurementTnmStageGroupingFinalPretreatment.xml")]
internal class COSDv9HNMeasurementTnmStageGroupingFinalPretreatmentRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? TnmStageGroupingFinalPretreatment { get; set; }
}
