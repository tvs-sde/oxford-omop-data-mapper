using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.SK.Measurement.COSDv8SKMeasurementMCategoryFinalPretreatment;

[DataOrigin("COSD")]
[Description("COSD v8 SK Measurement MCategory Final Pretreatment")]
[SourceQuery("COSDv8SKMeasurementMCategoryFinalPretreatment.xml")]
internal class COSDv8SKMeasurementMCategoryFinalPretreatmentRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? McategoryFinalPreTreatment { get; set; }
}
