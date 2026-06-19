using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Lung.Measurements.CosdV9LungMeasurementMcategoryFinalPreTreatmentStage;

[DataOrigin("COSD")]
[Description("COSD V9 Lung Measurement M Category Final Pre Treatment Stage")]
[SourceQuery("CosdV9LungMeasurementMcategoryFinalPreTreatmentStage.xml")]
internal class CosdV9LungMeasurementMcategoryFinalPreTreatmentStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? McategoryFinalPreTreatment { get; set; }
}
