using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.UR.Measurement.COSDv8URMeasurementTNMcategoryFinalPreTreatmentStage;

[DataOrigin("COSD")]
[Description("COSD V8 UR Measurement TNMcategory Final Pre Treatment Stage")]
[SourceQuery("COSDv8URMeasurementTNMcategoryFinalPreTreatmentStage.xml")]
internal class COSDv8URMeasurementTNMcategoryFinalPreTreatmentStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? TnmStageGroupingFinalPreTreatment { get; set; }
}
