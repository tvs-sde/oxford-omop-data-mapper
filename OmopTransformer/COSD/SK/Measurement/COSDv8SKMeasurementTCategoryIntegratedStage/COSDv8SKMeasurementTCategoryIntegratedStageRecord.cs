using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.SK.Measurement.COSDv8SKMeasurementTCategoryIntegratedStage;

[DataOrigin("COSD")]
[Description("COSD v8 SK Measurement TCategory Integrated Stage")]
[SourceQuery("COSDv8SKMeasurementTCategoryIntegratedStage.xml")]
internal class COSDv8SKMeasurementTCategoryIntegratedStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? TcategoryIntegratedStage { get; set; }
}
