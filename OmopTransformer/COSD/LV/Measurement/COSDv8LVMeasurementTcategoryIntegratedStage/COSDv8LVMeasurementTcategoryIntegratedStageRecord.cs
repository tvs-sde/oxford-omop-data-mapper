using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.LV.Measurement.COSDv8LVMeasurementTcategoryIntegratedStage;

[DataOrigin("COSD")]
[Description("COSD v8 LV Measurement Tcategory Integrated Stage")]
[SourceQuery("COSDv8LVMeasurementTcategoryIntegratedStage.xml")]
internal class COSDv8LVMeasurementTcategoryIntegratedStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? TCategoryIntegratedStage { get; set; }
}
