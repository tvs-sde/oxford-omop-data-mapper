using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Breast.Measurements.CosdV8BreastMeasurementMcategoryFinalPreTreatmentStage;

[DataOrigin("COSD")]
[Description("COSD V8 Breast Measurement M Category Final Pre Treatment Stage")]
[SourceQuery("CosdV8BreastMeasurementMcategoryFinalPreTreatmentStage.xml")]
internal class CosdV8BreastMeasurementMcategoryFinalPreTreatmentStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? McategoryFinalPreTreatment { get; set; }
}
