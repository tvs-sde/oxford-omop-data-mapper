using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Colorectal.Measurements.CosdV8MeasurementSynchronousTumourIndicator;

[DataOrigin("COSD")]
[Description("COSD V8 Measurement Synchronous Tumour Indicator")]
[SourceQuery("CosdV8MeasurementSynchronousTumourIndicator.xml")]
internal class CosdV8MeasurementSynchronousTumourIndicatorRecord
{
    public string? NhsNumber { get; set; }
    public string? ClinicalDateCancerDiagnosis { get; set; }
    public string? SynchronousTumourIndicator { get; set; }
}