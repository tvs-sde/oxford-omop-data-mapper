using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.GY.Measurement.COSDv8GYMeasurementTcategoryFinalPreTreatmentStage;

[DataOrigin("COSD")]
[Description("COSD V8 GY Measurement Tcategory Final Pre Treatment Stage")]
[SourceQuery("COSDv8GYMeasurementTcategoryFinalPreTreatmentStage.xml")]
internal class COSDv8GYMeasurementTcategoryFinalPreTreatmentStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? TcategoryFinalPreTreatment { get; set; }
}
