using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.HN.Measurement.COSDv8HNMeasurementTcategoryFinalPreTreatmentStage;

[DataOrigin("COSD")]
[Description("COSD v8 HN Measurement Tcategory Final Pre Treatment Stage")]
[SourceQuery("COSDv8HNMeasurementTcategoryFinalPreTreatmentStage.xml")]
internal class COSDv8HNMeasurementTcategoryFinalPreTreatmentStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? TcategoryFinalPreTreatment { get; set; }
}
