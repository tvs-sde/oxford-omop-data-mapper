using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Colorectal.Measurements.CosdV9MeasurementSynchronousTumourIndicator;

[DataOrigin("COSD")]
[Description("COSD V9 Measurement Synchronous Tumour Indicator")]
[SourceQuery("CosdV9MeasurementSynchronousTumourIndicator.xml")]
internal class CosdV9MeasurementSynchronousTumourIndicatorRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? SynchronousTumourIndicator { get; set; }
}