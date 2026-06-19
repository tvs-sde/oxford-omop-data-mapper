using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Breast.Measurements.CosdV8BreastMeasurementTcategoryFinalPreTreatmentStage;

[DataOrigin("COSD")]
[Description("COSD V8 Breast Measurement T Category Final Pre Treatment Stage")]
[SourceQuery("CosdV8BreastMeasurementTcategoryFinalPreTreatmentStage.xml")]
internal class CosdV8BreastMeasurementTcategoryFinalPreTreatmentStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? TcategoryFinalPreTreatment { get; set; }
}
