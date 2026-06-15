using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.LV.Measurement.COSDv9LVMeasurementNcategoryFinalPreTreatmentStage;

[DataOrigin("COSD")]
[Description("COSD V9 LV Measurement Ncategory Final Pre Treatment Stage")]
[SourceQuery("COSDv9LVMeasurementNcategoryFinalPreTreatmentStage.xml")]
internal class COSDv9LVMeasurementNcategoryFinalPreTreatmentStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? NcategoryFinalPreTreatment { get; set; }
}
