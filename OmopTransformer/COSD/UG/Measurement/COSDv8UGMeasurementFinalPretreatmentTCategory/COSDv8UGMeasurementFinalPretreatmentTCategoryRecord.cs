using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.UG.Measurement.COSDv8UGMeasurementFinalPretreatmentTCategory;

[DataOrigin("COSD")]
[Description("COSD V8 UG Measurement Final Pretreatment T Category")]
[SourceQuery("COSDv8UGMeasurementFinalPretreatmentTCategory.xml")]
internal class COSDv8UGMeasurementFinalPretreatmentTCategoryRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? FinalPreTreatmentTCategory { get; set; }
}
