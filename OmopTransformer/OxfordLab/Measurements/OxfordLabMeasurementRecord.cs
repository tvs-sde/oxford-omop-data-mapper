using OmopTransformer.Annotations;

namespace OmopTransformer.OxfordLab.Measurements.OxfordLabMeasurement;

[DataOrigin("OxfordLab")]
[Description("Oxford Lab Measurement")]
[SourceQuery("OxfordLabMeasurement.xml")]
internal class OxfordLabMeasurementRecord
{
    public string? NHS_NUMBER { get; set; }
    public string? EVENT { get; set; }
    public string? EVENT_START_DT_TM { get; set; }
    public string? RESULT_VALUE { get; set; }
    public string? RESULT_UNITS { get; set; }
    public string? NORMAL_LOW { get; set; }
    public string? NORMAL_HIGH { get; set; }
}