using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Colorectal.Measurements.CosdV8MeasurementTumourHeightAboveAnalVerge;

[DataOrigin("COSD")]
[Description("COSD V8 Measurement Tumour Height Above Anal Verge")]
[SourceQuery("CosdV8MeasurementTumourHeightAboveAnalVerge.xml")]
internal class CosdV8MeasurementTumourHeightAboveAnalVergeRecord
{
    public string? NhsNumber { get; set; }
    public string? ClinicalDateCancerDiagnosis { get; set; }
    public string? TumourHeightAboveAnalVerge { get; set; }
}