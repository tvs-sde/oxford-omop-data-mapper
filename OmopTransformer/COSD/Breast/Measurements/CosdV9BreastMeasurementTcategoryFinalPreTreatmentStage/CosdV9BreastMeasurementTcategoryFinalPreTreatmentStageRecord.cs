using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Breast.Measurements.CosdV9BreastMeasurementTcategoryFinalPreTreatmentStage;

[DataOrigin("COSD")]
[Description("COSD V9 Breast Measurement T Category Final Pre-Treatment Stage")]
[SourceQuery("CosdV9BreastMeasurementTcategoryFinalPreTreatmentStage.xml")]
internal class CosdV9BreastMeasurementTcategoryFinalPreTreatmentStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? TcategoryFinalPreTreatment { get; set; }
}
