using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CT.Measurement.COSDv9CTMeasurementTNMStageGroupingFinalPretreatment;

[DataOrigin("COSD")]
[Description("COSD V9 CT Measurement TNM Stage Grouping Final Pretreatment")]
[SourceQuery("COSDv9CTMeasurementTNMStageGroupingFinalPretreatment.xml")]
internal class COSDv9CTMeasurementTNMStageGroupingFinalPretreatmentRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? TnmStageGroupingFinalPretreatment { get; set; }
}
