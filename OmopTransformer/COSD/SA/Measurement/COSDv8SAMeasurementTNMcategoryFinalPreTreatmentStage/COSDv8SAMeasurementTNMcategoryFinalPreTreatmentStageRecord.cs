using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.SA.Measurement.COSDv8SAMeasurementTNMcategoryFinalPreTreatmentStage;

[DataOrigin("COSD")]
[Description("COSD v8 SA Measurement TNMcategory Final Pre Treatment Stage")]
[SourceQuery("COSDv8SAMeasurementTNMcategoryFinalPreTreatmentStage.xml")]
internal class COSDv8SAMeasurementTNMcategoryFinalPreTreatmentStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? TnmStageGroupingFinalPretreatment { get; set; }
}
