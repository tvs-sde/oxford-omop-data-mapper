using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.UG.Measurement.COSDv8UGMeasurementIntegratedStageTCategory;

[DataOrigin("COSD")]
[Description("COSD V8 UG Measurement Integrated Stage T Category")]
[SourceQuery("COSDv8UGMeasurementIntegratedStageTCategory.xml")]
internal class COSDv8UGMeasurementIntegratedStageTCategoryRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? IntegratedStageTCategory { get; set; }
}
