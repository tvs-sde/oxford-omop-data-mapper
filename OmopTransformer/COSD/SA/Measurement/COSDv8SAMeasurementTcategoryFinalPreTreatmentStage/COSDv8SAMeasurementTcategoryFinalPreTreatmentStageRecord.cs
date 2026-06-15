using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.SA.Measurement.COSDv8SAMeasurementTcategoryFinalPreTreatmentStage;

[DataOrigin("COSD")]
[Description("COSD v8 SA Measurement Tcategory Final Pre Treatment Stage")]
[SourceQuery("COSDv8SAMeasurementTcategoryFinalPreTreatmentStage.xml")]
internal class COSDv8SAMeasurementTcategoryFinalPreTreatmentStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? TcategoryFinalPreTreatment { get; set; }
}
