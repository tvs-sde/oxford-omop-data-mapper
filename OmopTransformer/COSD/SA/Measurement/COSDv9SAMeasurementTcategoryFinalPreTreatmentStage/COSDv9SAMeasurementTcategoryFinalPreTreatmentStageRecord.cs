using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.SA.Measurement.COSDv9SAMeasurementTcategoryFinalPreTreatmentStage;

[DataOrigin("COSD")]
[Description("COSD V9 SA Measurement Tcategory Final Pre Treatment Stage")]
[SourceQuery("COSDv9SAMeasurementTcategoryFinalPreTreatmentStage.xml")]
internal class COSDv9SAMeasurementTcategoryFinalPreTreatmentStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? TCategoryFinalPretreatment { get; set; }
}
