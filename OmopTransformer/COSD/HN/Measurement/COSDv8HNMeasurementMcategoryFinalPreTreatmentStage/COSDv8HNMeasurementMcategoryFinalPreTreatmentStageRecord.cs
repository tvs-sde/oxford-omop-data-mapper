using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.HN.Measurement.COSDv8HNMeasurementMcategoryFinalPreTreatmentStage;

[DataOrigin("COSD")]
[Description("COSD v8 HN Measurement Mcategory Final Pre Treatment Stage")]
[SourceQuery("COSDv8HNMeasurementMcategoryFinalPreTreatmentStage.xml")]
internal class COSDv8HNMeasurementMcategoryFinalPreTreatmentStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? McategoryFinalPreTreatment { get; set; }
}
