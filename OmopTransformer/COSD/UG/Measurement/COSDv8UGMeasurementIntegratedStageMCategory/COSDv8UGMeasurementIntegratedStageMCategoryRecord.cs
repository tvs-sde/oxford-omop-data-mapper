using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.UG.Measurement.COSDv8UGMeasurementIntegratedStageMCategory;

[DataOrigin("COSD")]
[Description("COSD V8 UG Measurement Integrated Stage M Category")]
[SourceQuery("COSDv8UGMeasurementIntegratedStageMCategory.xml")]
internal class COSDv8UGMeasurementIntegratedStageMCategoryRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? IntegratedStageMCategory { get; set; }
}
