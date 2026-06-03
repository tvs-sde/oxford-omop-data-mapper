using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.BA.Measurement.COSDv9BAMeasurementTCategoryFinalPretreatment;

[DataOrigin("COSD")]
[Description("COSD V9 BA Measurement T Category Final Pretreatment")]
[SourceQuery("COSDv9BAMeasurementTCategoryFinalPretreatment.xml")]
internal class COSDv9BAMeasurementTCategoryFinalPretreatmentRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? TCategoryFinalPretreatment { get; set; }
}
