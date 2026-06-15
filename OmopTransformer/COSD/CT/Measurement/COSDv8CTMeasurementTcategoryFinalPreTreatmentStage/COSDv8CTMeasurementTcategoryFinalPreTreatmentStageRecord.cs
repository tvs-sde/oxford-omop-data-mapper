using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CT.Measurement.COSDv8CTMeasurementTcategoryFinalPreTreatmentStage;

[DataOrigin("COSD")]
[Description("COSD V8 CT Measurement Tcategory Final Pre Treatment Stage")]
[SourceQuery("COSDv8CTMeasurementTcategoryFinalPreTreatmentStage.xml")]
internal class COSDv8CTMeasurementTcategoryFinalPreTreatmentStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? TcategoryFinalPreTreatment { get; set; }
}
