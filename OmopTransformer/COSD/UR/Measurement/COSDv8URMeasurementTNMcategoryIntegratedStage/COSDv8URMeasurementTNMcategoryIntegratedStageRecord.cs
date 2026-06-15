using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.UR.Measurement.COSDv8URMeasurementTNMcategoryIntegratedStage;

[DataOrigin("COSD")]
[Description("COSD V8 UR Measurement TNMcategory Integrated Stage")]
[SourceQuery("COSDv8URMeasurementTNMcategoryIntegratedStage.xml")]
internal class COSDv8URMeasurementTNMcategoryIntegratedStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? TnmStageGroupingIntegrated { get; set; }
}
