using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.UR.Measurement.COSDv8URMeasurementNcategoryFinalPreTreatmentStage;

[DataOrigin("COSD")]
[Description("COSD V8 UR Measurement Ncategory Final Pre Treatment Stage")]
[SourceQuery("COSDv8URMeasurementNcategoryFinalPreTreatmentStage.xml")]
internal class COSDv8URMeasurementNcategoryFinalPreTreatmentStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? NcategoryFinalPreTreatment { get; set; }
}
