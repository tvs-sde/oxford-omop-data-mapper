using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.GY.Measurement.COSDv8GYMeasurementMcategoryFinalPreTreatmentStage;

[DataOrigin("COSD")]
[Description("COSD V8 GY Measurement Mcategory Final Pre Treatment Stage")]
[SourceQuery("COSDv8GYMeasurementMcategoryFinalPreTreatmentStage.xml")]
internal class COSDv8GYMeasurementMcategoryFinalPreTreatmentStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? McategoryFinalPreTreatment { get; set; }
}
