using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.HN.Measurement.COSDv9HNMeasurementTCategoryFinalPretreatment;

[DataOrigin("COSD")]
[Description("COSD V9 HN Measurement T Category Final Pretreatment")]
[SourceQuery("COSDv9HNMeasurementTCategoryFinalPretreatment.xml")]
internal class COSDv9HNMeasurementTCategoryFinalPretreatmentRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? TCategoryFinalPretreatment { get; set; }
}
