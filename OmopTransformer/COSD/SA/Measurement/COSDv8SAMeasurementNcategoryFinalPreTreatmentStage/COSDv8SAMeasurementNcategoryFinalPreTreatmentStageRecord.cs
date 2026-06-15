using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.SA.Measurement.COSDv8SAMeasurementNcategoryFinalPreTreatmentStage;

[DataOrigin("COSD")]
[Description("COSD v8 SA Measurement Ncategory Final Pre Treatment Stage")]
[SourceQuery("COSDv8SAMeasurementNcategoryFinalPreTreatmentStage.xml")]
internal class COSDv8SAMeasurementNcategoryFinalPreTreatmentStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? NcategoryFinalPreTreatment { get; set; }
}
