using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.SA.Measurement.COSDv9SAMeasurementNcategoryFinalPreTreatmentStage;

[DataOrigin("COSD")]
[Description("COSD V9 SA Measurement Ncategory Final Pre Treatment Stage")]
[SourceQuery("COSDv9SAMeasurementNcategoryFinalPreTreatmentStage.xml")]
internal class COSDv9SAMeasurementNcategoryFinalPreTreatmentStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? NCategoryFinalPretreatment { get; set; }
}
