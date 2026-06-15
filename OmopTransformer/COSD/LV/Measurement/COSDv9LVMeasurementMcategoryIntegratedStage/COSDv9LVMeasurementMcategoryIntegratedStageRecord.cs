using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.LV.Measurement.COSDv9LVMeasurementMcategoryIntegratedStage;

[DataOrigin("COSD")]
[Description("COSD V9 LV Measurement Mcategory Integrated Stage")]
[SourceQuery("COSDv9LVMeasurementMcategoryIntegratedStage.xml")]
internal class COSDv9LVMeasurementMcategoryIntegratedStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? MCategoryIntegratedStage { get; set; }
}
