using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Breast.Measurements.CosdV8BreastMeasurementNcategoryFinalPreTreatmentStage;

[DataOrigin("COSD")]
[Description("COSD V8 Breast Measurement N Category Final Pre Treatment Stage")]
[SourceQuery("CosdV8BreastMeasurementNcategoryFinalPreTreatmentStage.xml")]
internal class CosdV8BreastMeasurementNcategoryFinalPreTreatmentStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? NcategoryFinalPreTreatment { get; set; }
}
