using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.BA.Measurement.COSDv9BAMeasurementNCategoryFinalPretreatment;

[DataOrigin("COSD")]
[Description("COSD V9 BA Measurement N Category Final Pretreatment")]
[SourceQuery("COSDv9BAMeasurementNCategoryFinalPretreatment.xml")]
internal class COSDv9BAMeasurementNCategoryFinalPretreatmentRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? NCategoryFinalPretreatment { get; set; }
}
