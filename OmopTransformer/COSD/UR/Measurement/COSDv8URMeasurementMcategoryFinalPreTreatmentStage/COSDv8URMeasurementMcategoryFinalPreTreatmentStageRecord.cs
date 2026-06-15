using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.UR.Measurement.COSDv8URMeasurementMcategoryFinalPreTreatmentStage;

[DataOrigin("COSD")]
[Description("COSD V8 UR Measurement Mcategory Final Pre Treatment Stage")]
[SourceQuery("COSDv8URMeasurementMcategoryFinalPreTreatmentStage.xml")]
internal class COSDv8URMeasurementMcategoryFinalPreTreatmentStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? McategoryFinalPreTreatment { get; set; }
}
