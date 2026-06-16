using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.HA.Measurement.COSDv8HAMeasurementFinalPreTreatmentNCategory;

[DataOrigin("COSD")]
[Description("COSD V8 HA Measurement Final Pre Treatment Ncategory")]
[SourceQuery("COSDv8HAMeasurementFinalPreTreatmentNCategory.xml")]
internal class COSDv8HAMeasurementFinalPreTreatmentNCategoryRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? FinalPreTreatmentNCategory { get; set; }
}
