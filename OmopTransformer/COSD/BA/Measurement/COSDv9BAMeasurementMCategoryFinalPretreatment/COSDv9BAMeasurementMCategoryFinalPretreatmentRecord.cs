using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.BA.Measurement.COSDv9BAMeasurementMCategoryFinalPretreatment;

[DataOrigin("COSD")]
[Description("COSD V9 BA Measurement M Category Final Pretreatment")]
[SourceQuery("COSDv9BAMeasurementMCategoryFinalPretreatment.xml")]
internal class COSDv9BAMeasurementMCategoryFinalPretreatmentRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? MCategoryFinalPretreatment { get; set; }
}
