using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.UG.Measurement.COSDv9UGMeasurementNCategoryFinalPretreatment;

[DataOrigin("COSD")]
[Description("COSD V9 UG Measurement N Category Final Pretreatment")]
[SourceQuery("COSDv9UGMeasurementNCategoryFinalPretreatment.xml")]
internal class COSDv9UGMeasurementNCategoryFinalPretreatmentRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? NCategoryFinalPretreatment { get; set; }
}
