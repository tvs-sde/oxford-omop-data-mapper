using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.HN.Measurement.COSDv9HNMeasurementNCategoryFinalPretreatment;

[DataOrigin("COSD")]
[Description("COSD V9 HN Measurement N Category Final Pretreatment")]
[SourceQuery("COSDv9HNMeasurementNCategoryFinalPretreatment.xml")]
internal class COSDv9HNMeasurementNCategoryFinalPretreatmentRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? NCategoryFinalPretreatment { get; set; }
}
