using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.SK.Measurement.COSDv9SKMeasurementNCategoryFinalPretreatment;

[DataOrigin("COSD")]
[Description("COSD V9 SK Measurement N Category Final Pretreatment")]
[SourceQuery("COSDv9SKMeasurementNCategoryFinalPretreatment.xml")]
internal class COSDv9SKMeasurementNCategoryFinalPretreatmentRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? NCategoryFinalPretreatment { get; set; }
}
