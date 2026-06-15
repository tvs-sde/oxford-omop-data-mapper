using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.SK.Measurement.COSDv8SKMeasurementTCategoryFinalPretreatment;

[DataOrigin("COSD")]
[Description("COSD v8 SK Measurement TCategory Final Pretreatment")]
[SourceQuery("COSDv8SKMeasurementTCategoryFinalPretreatment.xml")]
internal class COSDv8SKMeasurementTCategoryFinalPretreatmentRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? TcategoryFinalPreTreatment { get; set; }
}
