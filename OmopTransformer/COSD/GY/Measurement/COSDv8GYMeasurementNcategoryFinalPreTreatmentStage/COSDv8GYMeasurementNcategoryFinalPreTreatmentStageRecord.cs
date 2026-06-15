using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.GY.Measurement.COSDv8GYMeasurementNcategoryFinalPreTreatmentStage;

[DataOrigin("COSD")]
[Description("COSD V8 GY Measurement Ncategory Final Pre Treatment Stage")]
[SourceQuery("COSDv8GYMeasurementNcategoryFinalPreTreatmentStage.xml")]
internal class COSDv8GYMeasurementNcategoryFinalPreTreatmentStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? NcategoryFinalPreTreatment { get; set; }
}
