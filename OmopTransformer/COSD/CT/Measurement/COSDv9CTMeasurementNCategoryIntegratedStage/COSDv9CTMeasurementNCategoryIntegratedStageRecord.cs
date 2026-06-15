using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CT.Measurement.COSDv9CTMeasurementNCategoryIntegratedStage;

[DataOrigin("COSD")]
[Description("COSD v9 CT Measurement N Category Integrated Stage")]
[SourceQuery("COSDv9CTMeasurementNCategoryIntegratedStage.xml")]
internal class COSDv9CTMeasurementNCategoryIntegratedStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? NCategoryIntegratedStage { get; set; }
}
