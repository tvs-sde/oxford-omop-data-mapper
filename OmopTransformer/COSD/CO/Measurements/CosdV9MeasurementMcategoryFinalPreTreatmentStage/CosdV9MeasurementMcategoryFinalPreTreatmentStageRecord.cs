using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Colorectal.Measurements.CosdV9MeasurementMcategoryFinalPreTreatmentStage;

[DataOrigin("COSD")]
[Description("COSD V9 Measurement M Category Final Pre Treatment Stage")]
[SourceQuery("CosdV9MeasurementMcategoryFinalPreTreatmentStage.xml")]
internal class CosdV9MeasurementMcategoryFinalPreTreatmentStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? McategoryFinalPreTreatment { get; set; }
}