using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.SK.Measurement.COSDv8SKMeasurementNCategoryIntegratedStage;

[DataOrigin("COSD")]
[Description("COSD v8 SK Measurement NCategory Integrated Stage")]
[SourceQuery("COSDv8SKMeasurementNCategoryIntegratedStage.xml")]
internal class COSDv8SKMeasurementNCategoryIntegratedStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? NcategoryIntegratedStage { get; set; }
}
