using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.SK.Measurement.COSDv8SKMeasurementNCategoryFinalPretreatment;

[DataOrigin("COSD")]
[Description("COSD v8 SK Measurement NCategory Final Pretreatment")]
[SourceQuery("COSDv8SKMeasurementNCategoryFinalPretreatment.xml")]
internal class COSDv8SKMeasurementNCategoryFinalPretreatmentRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? NcategoryFinalPreTreatment { get; set; }
}
