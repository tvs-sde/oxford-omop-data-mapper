using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Lung.Measurements.CosdV8LungMeasurementMcategoryFinalPreTreatmentStage;

[DataOrigin("COSD")]
[Description("COSD V8 Lung Measurement M Category (Final Pretreatment)")]
[SourceQuery("CosdV8LungMeasurementMcategoryFinalPreTreatmentStage.xml")]
internal class CosdV8LungMeasurementMcategoryFinalPreTreatmentStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? McategoryFinalPreTreatment { get; set; }
}