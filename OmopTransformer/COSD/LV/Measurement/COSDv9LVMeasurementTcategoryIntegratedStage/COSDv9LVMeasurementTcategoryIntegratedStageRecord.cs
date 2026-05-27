using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.LV.Measurement.COSDv9LVMeasurementTcategoryIntegratedStage;

[DataOrigin("COSD")]
[Description("COSD V9 LV Measurement Tcategory Integrated Stage")]
[SourceQuery("COSDv9LVMeasurementTcategoryIntegratedStage.xml")]
internal class COSDv9LVMeasurementTcategoryIntegratedStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? TCategoryIntegratedStage { get; set; }
}
