using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.HA.Measurement.COSDv8HAMeasurementFinalPreTreatmentMCategory;

[DataOrigin("COSD")]
[Description("COSD V8 HA Measurement Final Pre Treatment Mcategory")]
[SourceQuery("COSDv8HAMeasurementFinalPreTreatmentMCategory.xml")]
internal class COSDv8HAMeasurementFinalPreTreatmentMCategoryRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? FinalPreTreatmentMCategory { get; set; }
}
