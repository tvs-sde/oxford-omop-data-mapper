using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.HA.Measurement.COSDv9HAMeasurementTnmStageGroupingFinalPretreatment;

[DataOrigin("COSD")]
[Description("COSD V9 HA Measurement Tnm Stage Grouping Final Pretreatment")]
[SourceQuery("COSDv9HAMeasurementTnmStageGroupingFinalPretreatment.xml")]
internal class COSDv9HAMeasurementTnmStageGroupingFinalPretreatmentRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? TnmStageGroupingFinalPretreatment { get; set; }
}
