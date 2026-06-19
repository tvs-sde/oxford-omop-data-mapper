using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Lung.Measurements.CosdV8LungMeasurementTcategoryFinalPreTreatmentStage;

[DataOrigin("COSD")]
[Description("COSD V8 Lung Measurement T Category Final Pre Treatment Stage")]
[SourceQuery("CosdV8LungMeasurementTcategoryFinalPreTreatmentStage.xml")]
internal class CosdV8LungMeasurementTcategoryFinalPreTreatmentStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? TcategoryFinalPreTreatment { get; set; }
}
