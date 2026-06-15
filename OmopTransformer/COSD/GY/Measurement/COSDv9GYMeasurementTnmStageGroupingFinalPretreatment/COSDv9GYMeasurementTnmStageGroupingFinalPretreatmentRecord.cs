using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.GY.Measurement.COSDv9GYMeasurementTnmStageGroupingFinalPretreatment;

[DataOrigin("COSD")]
[Description("COSD V9 GY Measurement Tnm Stage Grouping Final Pretreatment")]
[SourceQuery("COSDv9GYMeasurementTnmStageGroupingFinalPretreatment.xml")]
internal class COSDv9GYMeasurementTnmStageGroupingFinalPretreatmentRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? TnmStageGroupingFinalPretreatment { get; set; }
}
