using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.GY.Measurement.COSDv9GYMeasurementTCategoryFinalPretreatment;

[DataOrigin("COSD")]
[Description("COSD V9 GY Measurement T Category Final Pretreatment")]
[SourceQuery("COSDv9GYMeasurementTCategoryFinalPretreatment.xml")]
internal class COSDv9GYMeasurementTCategoryFinalPretreatmentRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? TCategoryFinalPretreatment { get; set; }
}
