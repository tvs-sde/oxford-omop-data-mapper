using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.UG.Measurement.COSDv8UGMeasurementFinalPretreatmentNCategory;

[DataOrigin("COSD")]
[Description("COSD V8 UG Measurement Final Pretreatment N Category")]
[SourceQuery("COSDv8UGMeasurementFinalPretreatmentNCategory.xml")]
internal class COSDv8UGMeasurementFinalPretreatmentNCategoryRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? FinalPreTreatmentNCategory { get; set; }
}
