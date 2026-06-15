using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CT.Measurement.COSDv9CTMeasurementMCategoryFinalPretreatment;

[DataOrigin("COSD")]
[Description("COSD v9 CT Measurement M Category Final Pretreatment")]
[SourceQuery("COSDv9CTMeasurementMCategoryFinalPretreatment.xml")]
internal class COSDv9CTMeasurementMCategoryFinalPretreatmentRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? MCategoryFinalPretreatment { get; set; }
}
