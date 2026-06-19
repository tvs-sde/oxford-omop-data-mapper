using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Lung.Measurements.CosdV8LungMeasurementNcategoryFinalPreTreatmentStage;

[DataOrigin("COSD")]
[Description("COSD V8 Lung Measurement N Category (Final Pretreatment)")]
[SourceQuery("CosdV8LungMeasurementNcategoryFinalPreTreatmentStage.xml")]
internal class CosdV8LungMeasurementNcategoryFinalPreTreatmentStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? NcategoryFinalPreTreatment { get; set; }
}