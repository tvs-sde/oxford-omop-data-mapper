using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.HA.Measurement.COSDv9HAMeasurementNCategoryFinalPretreatment;

[DataOrigin("COSD")]
[Description("COSD V9 HA Measurement N Category Final Pretreatment")]
[SourceQuery("COSDv9HAMeasurementNCategoryFinalPretreatment.xml")]
internal class COSDv9HAMeasurementNCategoryFinalPretreatmentRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? NCategoryFinalPretreatment { get; set; }
}
