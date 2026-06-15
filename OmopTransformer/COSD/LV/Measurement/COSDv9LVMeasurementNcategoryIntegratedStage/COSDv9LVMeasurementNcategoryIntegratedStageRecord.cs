using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.LV.Measurement.COSDv9LVMeasurementNcategoryIntegratedStage;

[DataOrigin("COSD")]
[Description("COSD V9 LV Measurement Ncategory Integrated Stage")]
[SourceQuery("COSDv9LVMeasurementNcategoryIntegratedStage.xml")]
internal class COSDv9LVMeasurementNcategoryIntegratedStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? NCategoryIntegratedStage { get; set; }
}
