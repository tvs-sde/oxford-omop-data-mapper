using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CT.Measurement.COSDv9CTMeasurementNCategoryFinalPretreatment;

[DataOrigin("COSD")]
[Description("COSD v9 CT Measurement N Category Final Pretreatment")]
[SourceQuery("COSDv9CTMeasurementNCategoryFinalPretreatment.xml")]
internal class COSDv9CTMeasurementNCategoryFinalPretreatmentRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? NCategoryFinalPretreatment { get; set; }
}
