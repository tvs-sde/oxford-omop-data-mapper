using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.LV.Measurement.COSDv8LVMeasurementMcategoryIntegratedStage;

[DataOrigin("COSD")]
[Description("COSD v8 LV Measurement Mcategory Integrated Stage")]
[SourceQuery("COSDv8LVMeasurementMcategoryIntegratedStage.xml")]
internal class COSDv8LVMeasurementMcategoryIntegratedStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? MCategoryIntegratedStage { get; set; }
}
