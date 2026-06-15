using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.UR.Measurement.COSDv9URMeasurementMcategoryIntegratedStage;

[DataOrigin("COSD")]
[Description("COSD V9 UR Measurement Mcategory Integrated Stage")]
[SourceQuery("COSDv9URMeasurementMcategoryIntegratedStage.xml")]
internal class COSDv9URMeasurementMcategoryIntegratedStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? McategoryIntegratedStage { get; set; }
}
