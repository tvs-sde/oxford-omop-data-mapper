using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.LV.Measurement.COSDv9LVMeasurementMcategoryFinalPreTreatmentStage;

[DataOrigin("COSD")]
[Description("COSD V9 LV Measurement Mcategory Final Pre Treatment Stage")]
[SourceQuery("COSDv9LVMeasurementMcategoryFinalPreTreatmentStage.xml")]
internal class COSDv9LVMeasurementMcategoryFinalPreTreatmentStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? McategoryFinalPreTreatment { get; set; }
}
