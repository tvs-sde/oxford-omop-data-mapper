using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.SK.Measurement.COSDv9SKMeasurementTCategoryFinalPretreatment;

[DataOrigin("COSD")]
[Description("COSD V9 SK Measurement T Category Final Pretreatment")]
[SourceQuery("COSDv9SKMeasurementTCategoryFinalPretreatment.xml")]
internal class COSDv9SKMeasurementTCategoryFinalPretreatmentRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? TCategoryFinalPretreatment { get; set; }
}
