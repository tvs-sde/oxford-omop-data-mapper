using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.HN.Measurement.COSDv8HNMeasurementNcategoryFinalPreTreatmentStage;

[DataOrigin("COSD")]
[Description("COSD v8 HN Measurement Ncategory Final Pre Treatment Stage")]
[SourceQuery("COSDv8HNMeasurementNcategoryFinalPreTreatmentStage.xml")]
internal class COSDv8HNMeasurementNcategoryFinalPreTreatmentStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? NcategoryFinalPreTreatment { get; set; }
}
