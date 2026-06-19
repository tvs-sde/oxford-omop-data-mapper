using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Breast.Measurements.CosdV9BreastMeasurementNcategoryFinalPreTreatmentStage;

[DataOrigin("COSD")]
[Description("COSD V9 Breast Measurement N Category Final Pre-Treatment Stage")]
[SourceQuery("CosdV9BreastMeasurementNcategoryFinalPreTreatmentStage.xml")]
internal class CosdV9BreastMeasurementNcategoryFinalPreTreatmentStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? NcategoryFinalPreTreatment { get; set; }
}
