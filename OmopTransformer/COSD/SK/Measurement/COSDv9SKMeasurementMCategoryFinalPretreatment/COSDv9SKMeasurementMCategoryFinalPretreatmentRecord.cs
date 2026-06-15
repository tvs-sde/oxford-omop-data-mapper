using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.SK.Measurement.COSDv9SKMeasurementMCategoryFinalPretreatment;

[DataOrigin("COSD")]
[Description("COSD V9 SK Measurement M Category Final Pretreatment")]
[SourceQuery("COSDv9SKMeasurementMCategoryFinalPretreatment.xml")]
internal class COSDv9SKMeasurementMCategoryFinalPretreatmentRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? MCategoryFinalPretreatment { get; set; }
}
