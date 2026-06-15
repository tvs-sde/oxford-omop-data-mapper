using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.UG.Measurement.COSDv8UGMeasurementIntegratedStageNCategory;

[DataOrigin("COSD")]
[Description("COSD V8 UG Measurement Integrated Stage N Category")]
[SourceQuery("COSDv8UGMeasurementIntegratedStageNCategory.xml")]
internal class COSDv8UGMeasurementIntegratedStageNCategoryRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? IntegratedStageNCategory { get; set; }
}
