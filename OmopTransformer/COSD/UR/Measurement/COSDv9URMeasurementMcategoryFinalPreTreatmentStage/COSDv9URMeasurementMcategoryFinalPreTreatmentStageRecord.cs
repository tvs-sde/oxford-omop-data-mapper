using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.UR.Measurement.COSDv9URMeasurementMcategoryFinalPreTreatmentStage;

[DataOrigin("COSD")]
[Description("COSD V9 UR Measurement Mcategory Final Pre Treatment Stage")]
[SourceQuery("COSDv9URMeasurementMcategoryFinalPreTreatmentStage.xml")]
internal class COSDv9URMeasurementMcategoryFinalPreTreatmentStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? McategoryFinalPreTreatment { get; set; }
}
