using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.UG.Measurement.COSDv9UGMeasurementTnmStageGroupingFinalPretreatment;

[DataOrigin("COSD")]
[Description("COSD V9 UG Measurement Tnm Stage Grouping Final Pretreatment")]
[SourceQuery("COSDv9UGMeasurementTnmStageGroupingFinalPretreatment.xml")]
internal class COSDv9UGMeasurementTnmStageGroupingFinalPretreatmentRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? TnmStageGroupingFinalPretreatment { get; set; }
}
