using OmopTransformer.Annotations;

namespace OmopTransformer.OxfordClinicalObservationsVitalSigns.Measurement.OxfordVitalSignsHeartRate;

[DataOrigin("OxfordClinicalObservationsVitalSigns")]
[Description("Oxford vital signs: heart rate.")]
[SourceQuery("OxfordVitalSignsHeartRate.xml")]
internal class OxfordVitalSignsHeartRateRecord
{
    public string? patient_identifier_value { get; set; }
    public string? EVENT_END_DT_TM { get; set; }
    public string? EVENT { get; set; }
    public string? RESULT_VALUE { get; set; }
    public string? RESULT_UNITS { get; set; }
    public string? NORMAL_LOW { get; set; }
    public string? NORMAL_HIGH { get; set; }
    public string? record_connection_identifier { get; set; }
}
