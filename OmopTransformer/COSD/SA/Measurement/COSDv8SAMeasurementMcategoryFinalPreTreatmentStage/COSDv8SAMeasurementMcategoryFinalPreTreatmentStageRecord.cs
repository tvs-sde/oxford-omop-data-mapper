using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.SA.Measurement.COSDv8SAMeasurementMcategoryFinalPreTreatmentStage;

[DataOrigin("COSD")]
[Description("COSD v8 SA Measurement Mcategory Final Pre Treatment Stage")]
[SourceQuery("COSDv8SAMeasurementMcategoryFinalPreTreatmentStage.xml")]
internal class COSDv8SAMeasurementMcategoryFinalPreTreatmentStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? McategoryFinalPreTreatment { get; set; }
}
