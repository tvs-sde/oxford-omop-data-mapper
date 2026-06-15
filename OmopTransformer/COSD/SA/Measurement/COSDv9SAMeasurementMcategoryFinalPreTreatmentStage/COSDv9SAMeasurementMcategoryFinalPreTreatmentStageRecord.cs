using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.SA.Measurement.COSDv9SAMeasurementMcategoryFinalPreTreatmentStage;

[DataOrigin("COSD")]
[Description("COSD V9 SA Measurement Mcategory Final Pre Treatment Stage")]
[SourceQuery("COSDv9SAMeasurementMcategoryFinalPreTreatmentStage.xml")]
internal class COSDv9SAMeasurementMcategoryFinalPreTreatmentStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? MCategoryFinalPretreatment { get; set; }
}
