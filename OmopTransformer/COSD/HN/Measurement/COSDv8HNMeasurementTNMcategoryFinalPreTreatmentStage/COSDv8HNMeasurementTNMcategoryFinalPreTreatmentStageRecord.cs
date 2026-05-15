using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.HN.Measurement.COSDv8HNMeasurementTNMcategoryFinalPreTreatmentStage;

[DataOrigin("COSD")]
[Description("COSD v8 HN Measurement TNMcategory Final Pre Treatment Stage")]
[SourceQuery("COSDv8HNMeasurementTNMcategoryFinalPreTreatmentStage.xml")]
internal class COSDv8HNMeasurementTNMcategoryFinalPreTreatmentStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? TnmStageGroupingFinalPretreatment { get; set; }
}
