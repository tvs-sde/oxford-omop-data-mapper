using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.GY.Measurement.COSDv8GYMeasurementNcategoryIntegratedStage;

[DataOrigin("COSD")]
[Description("COSD V8 GY Measurement Ncategory Integrated Stage")]
[SourceQuery("COSDv8GYMeasurementNcategoryIntegratedStage.xml")]
internal class COSDv8GYMeasurementNcategoryIntegratedStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? NCategoryIntegratedStage { get; set; }
}
