using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.UR.Measurement.COSDv8URMeasurementTcategoryFinalPreTreatmentStage;

[DataOrigin("COSD")]
[Description("COSD V8 UR Measurement Tcategory Final Pre Treatment Stage")]
[SourceQuery("COSDv8URMeasurementTcategoryFinalPreTreatmentStage.xml")]
internal class COSDv8URMeasurementTcategoryFinalPreTreatmentStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? TcategoryFinalPreTreatment { get; set; }
}
