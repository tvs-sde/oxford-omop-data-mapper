using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.SA.Measurement.COSDv8SAMeasurementMcategoryIntegratedStage;

[DataOrigin("COSD")]
[Description("COSD v8 SA Measurement Mcategory Integrated Stage")]
[SourceQuery("COSDv8SAMeasurementMcategoryIntegratedStage.xml")]
internal class COSDv8SAMeasurementMcategoryIntegratedStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? McategoryIntegratedStage { get; set; }
}
