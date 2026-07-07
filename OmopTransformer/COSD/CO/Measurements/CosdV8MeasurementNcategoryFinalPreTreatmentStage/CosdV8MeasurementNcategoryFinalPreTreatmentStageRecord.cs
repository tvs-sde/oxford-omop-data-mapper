using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Colorectal.Measurements.CosdV8MeasurementNcategoryFinalPreTreatmentStage;

[DataOrigin("COSD")]
[Description("COSD V8 Measurement N Category Final Pre Treatment Stage")]
[SourceQuery("CosdV8MeasurementNcategoryFinalPreTreatmentStage.xml")]
internal class CosdV8MeasurementNcategoryFinalPreTreatmentStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? NcategoryFinalPreTreatment { get; set; }
}