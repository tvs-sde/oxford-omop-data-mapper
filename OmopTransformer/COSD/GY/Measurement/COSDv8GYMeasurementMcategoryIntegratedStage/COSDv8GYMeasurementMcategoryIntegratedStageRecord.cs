using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.GY.Measurement.COSDv8GYMeasurementMcategoryIntegratedStage;

[DataOrigin("COSD")]
[Description("COSD V8 GY Measurement Mcategory Integrated Stage")]
[SourceQuery("COSDv8GYMeasurementMcategoryIntegratedStage.xml")]
internal class COSDv8GYMeasurementMcategoryIntegratedStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? MCategoryIntegratedStage { get; set; }
}
