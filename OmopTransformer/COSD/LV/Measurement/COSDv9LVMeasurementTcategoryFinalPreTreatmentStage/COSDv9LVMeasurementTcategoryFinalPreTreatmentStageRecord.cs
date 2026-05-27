using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.LV.Measurement.COSDv9LVMeasurementTcategoryFinalPreTreatmentStage;

[DataOrigin("COSD")]
[Description("COSD V9 LV Measurement Tcategory Final Pre Treatment Stage")]
[SourceQuery("COSDv9LVMeasurementTcategoryFinalPreTreatmentStage.xml")]
internal class COSDv9LVMeasurementTcategoryFinalPreTreatmentStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? TcategoryFinalPreTreatment { get; set; }
}
