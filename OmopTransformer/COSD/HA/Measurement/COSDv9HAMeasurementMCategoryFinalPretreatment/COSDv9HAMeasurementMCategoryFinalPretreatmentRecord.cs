using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.HA.Measurement.COSDv9HAMeasurementMCategoryFinalPretreatment;

[DataOrigin("COSD")]
[Description("COSD V9 HA Measurement M Category Final Pretreatment")]
[SourceQuery("COSDv9HAMeasurementMCategoryFinalPretreatment.xml")]
internal class COSDv9HAMeasurementMCategoryFinalPretreatmentRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? MCategoryFinalPretreatment { get; set; }
}
