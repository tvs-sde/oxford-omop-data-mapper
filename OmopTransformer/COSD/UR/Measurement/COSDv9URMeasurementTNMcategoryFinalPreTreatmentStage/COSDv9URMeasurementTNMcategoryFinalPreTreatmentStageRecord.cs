using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.UR.Measurement.COSDv9URMeasurementTNMcategoryFinalPreTreatmentStage;

[DataOrigin("COSD")]
[Description("COSD V9 UR Measurement TNM Category Final Pre Treatment Stage")]
[SourceQuery("COSDv9URMeasurementTNMcategoryFinalPreTreatmentStage.xml")]
internal class COSDv9URMeasurementTNMcategoryFinalPreTreatmentStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? TnmStageGroupingFinalPretreatment { get; set; }
}
