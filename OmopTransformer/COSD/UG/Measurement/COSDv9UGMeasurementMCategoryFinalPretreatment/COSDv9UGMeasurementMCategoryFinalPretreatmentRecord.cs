using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.UG.Measurement.COSDv9UGMeasurementMCategoryFinalPretreatment;

[DataOrigin("COSD")]
[Description("COSD V9 UG Measurement M Category Final Pretreatment")]
[SourceQuery("COSDv9UGMeasurementMCategoryFinalPretreatment.xml")]
internal class COSDv9UGMeasurementMCategoryFinalPretreatmentRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? MCategoryFinalPretreatment { get; set; }
}
