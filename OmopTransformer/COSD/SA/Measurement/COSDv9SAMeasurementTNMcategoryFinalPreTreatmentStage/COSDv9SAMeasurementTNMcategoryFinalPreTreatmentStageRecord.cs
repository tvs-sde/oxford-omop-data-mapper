using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.SA.Measurement.COSDv9SAMeasurementTNMcategoryFinalPreTreatmentStage;

[DataOrigin("COSD")]
[Description("COSD V9 SA Measurement TNM Category Final Pre Treatment Stage")]
[SourceQuery("COSDv9SAMeasurementTNMcategoryFinalPreTreatmentStage.xml")]
internal class COSDv9SAMeasurementTNMcategoryFinalPreTreatmentStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? TnmStageGroupingFinalPretreatment { get; set; }
}
