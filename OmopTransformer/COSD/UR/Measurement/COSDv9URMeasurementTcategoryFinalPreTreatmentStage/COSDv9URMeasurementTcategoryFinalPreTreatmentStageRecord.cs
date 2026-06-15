using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.UR.Measurement.COSDv9URMeasurementTcategoryFinalPreTreatmentStage;

[DataOrigin("COSD")]
[Description("COSD V9 UR Measurement Tcategory Final Pre Treatment Stage")]
[SourceQuery("COSDv9URMeasurementTcategoryFinalPreTreatmentStage.xml")]
internal class COSDv9URMeasurementTcategoryFinalPreTreatmentStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? TcategoryFinalPreTreatment { get; set; }
}
