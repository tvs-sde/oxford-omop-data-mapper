using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.BA.Measurement.COSDv9BAMeasurementTnmStageGroupingFinalPretreatment;

[DataOrigin("COSD")]
[Description("COSD V9 BA Measurement Tnm Stage Grouping Final Pretreatment")]
[SourceQuery("COSDv9BAMeasurementTnmStageGroupingFinalPretreatment.xml")]
internal class COSDv9BAMeasurementTnmStageGroupingFinalPretreatmentRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? TnmStageGroupingFinalPretreatment { get; set; }
}
