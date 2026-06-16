using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.HA.Measurement.COSDv8HAMeasurementFinalPreTreatmentTCategory;

[DataOrigin("COSD")]
[Description("COSD V8 HA Measurement Final Pre Treatment Tcategory")]
[SourceQuery("COSDv8HAMeasurementFinalPreTreatmentTCategory.xml")]
internal class COSDv8HAMeasurementFinalPreTreatmentTCategoryRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? FinalPreTreatmentTCategory { get; set; }
}
