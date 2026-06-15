using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CT.Measurement.COSDv9CTMeasurementTCategoryFinalPretreatment;

[DataOrigin("COSD")]
[Description("COSD V9 CT Measurement T Category Final Pretreatment")]
[SourceQuery("COSDv9CTMeasurementTCategoryFinalPretreatment.xml")]
internal class COSDv9CTMeasurementTCategoryFinalPretreatmentRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? TCategoryFinalPretreatment { get; set; }
}
