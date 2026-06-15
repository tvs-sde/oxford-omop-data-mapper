using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.HN.Measurement.COSDv9HNMeasurementMCategoryFinalPretreatment;

[DataOrigin("COSD")]
[Description("COSD V9 HN Measurement M Category Final Pretreatment")]
[SourceQuery("COSDv9HNMeasurementMCategoryFinalPretreatment.xml")]
internal class COSDv9HNMeasurementMCategoryFinalPretreatmentRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? MCategoryFinalPretreatment { get; set; }
}
