using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.LV.Measurement.COSDv8LVMeasurementNcategoryIntegratedStage;

[DataOrigin("COSD")]
[Description("COSD v8 LV Measurement Ncategory Integrated Stage")]
[SourceQuery("COSDv8LVMeasurementNcategoryIntegratedStage.xml")]
internal class COSDv8LVMeasurementNcategoryIntegratedStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? NCategoryIntegratedStage { get; set; }
}
