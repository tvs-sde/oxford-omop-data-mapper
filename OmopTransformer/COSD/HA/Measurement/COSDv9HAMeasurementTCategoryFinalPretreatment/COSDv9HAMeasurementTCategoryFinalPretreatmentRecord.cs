using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.HA.Measurement.COSDv9HAMeasurementTCategoryFinalPretreatment;

[DataOrigin("COSD")]
[Description("COSD V9 HA Measurement T Category Final Pretreatment")]
[SourceQuery("COSDv9HAMeasurementTCategoryFinalPretreatment.xml")]
internal class COSDv9HAMeasurementTCategoryFinalPretreatmentRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? TCategoryFinalPretreatment { get; set; }
}
