using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.SA.Measurement.COSDv8SAMeasurementTNMcategoryIntegratedStage;

[DataOrigin("COSD")]
[Description("COSD v8 SA Measurement TNMcategory Integrated Stage")]
[SourceQuery("COSDv8SAMeasurementTNMcategoryIntegratedStage.xml")]
internal class COSDv8SAMeasurementTNMcategoryIntegratedStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? TnmStageGroupingIntegrated { get; set; }
}
