using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.GY.Measurement.COSDv9GYMeasurementMCategoryFinalPretreatment;

[DataOrigin("COSD")]
[Description("COSD V9 GY Measurement M Category Final Pretreatment")]
[SourceQuery("COSDv9GYMeasurementMCategoryFinalPretreatment.xml")]
internal class COSDv9GYMeasurementMCategoryFinalPretreatmentRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? MCategoryFinalPretreatment { get; set; }
}
