using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.UG.Measurement.COSDv9UGMeasurementTCategoryFinalPretreatment;

[DataOrigin("COSD")]
[Description("COSD V9 UG Measurement T Category Final Pretreatment")]
[SourceQuery("COSDv9UGMeasurementTCategoryFinalPretreatment.xml")]
internal class COSDv9UGMeasurementTCategoryFinalPretreatmentRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? TCategoryFinalPretreatment { get; set; }
}
