using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.UR.Measurement.COSDv9URMeasurementNcategoryFinalPreTreatmentStage;

[DataOrigin("COSD")]
[Description("COSD V9 UR Measurement Ncategory Final Pre Treatment Stage")]
[SourceQuery("COSDv9URMeasurementNcategoryFinalPreTreatmentStage.xml")]
internal class COSDv9URMeasurementNcategoryFinalPreTreatmentStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? NcategoryFinalPreTreatment { get; set; }
}
