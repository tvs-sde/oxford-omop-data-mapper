using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.UG.Measurement.COSDv8UGMeasurementFinalPretreatmentMCategory;

[DataOrigin("COSD")]
[Description("COSD V8 UG Measurement Final Pretreatment M Category")]
[SourceQuery("COSDv8UGMeasurementFinalPretreatmentMCategory.xml")]
internal class COSDv8UGMeasurementFinalPretreatmentMCategoryRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? FinalPreTreatmentMCategory { get; set; }
}
