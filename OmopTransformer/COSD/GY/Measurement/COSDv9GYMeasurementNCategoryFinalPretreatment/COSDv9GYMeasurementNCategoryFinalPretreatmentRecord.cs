using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.GY.Measurement.COSDv9GYMeasurementNCategoryFinalPretreatment;

[DataOrigin("COSD")]
[Description("COSD V9 GY Measurement N Category Final Pretreatment")]
[SourceQuery("COSDv9GYMeasurementNCategoryFinalPretreatment.xml")]
internal class COSDv9GYMeasurementNCategoryFinalPretreatmentRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? NCategoryFinalPretreatment { get; set; }
}
