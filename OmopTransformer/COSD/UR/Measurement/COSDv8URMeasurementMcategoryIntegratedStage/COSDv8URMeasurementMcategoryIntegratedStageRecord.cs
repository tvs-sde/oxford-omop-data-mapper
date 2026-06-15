using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.UR.Measurement.COSDv8URMeasurementMcategoryIntegratedStage;

[DataOrigin("COSD")]
[Description("COSD V8 UR Measurement Mcategory Integrated Stage")]
[SourceQuery("COSDv8URMeasurementMcategoryIntegratedStage.xml")]
internal class COSDv8URMeasurementMcategoryIntegratedStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? McategoryIntegratedStage { get; set; }
}
