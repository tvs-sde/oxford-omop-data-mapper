using OmopTransformer.Annotations;

namespace OmopTransformer.OxfordClinicalObservationsVitalSigns.Measurement.OxfordVitalSignsOxygenConcentration;

[DataOrigin("OxfordClinicalObservationsVitalSigns")]
[Description("Oxford vital signs: delivered oxygen concentration.")]
[SourceQuery("OxfordVitalSignsOxygenConcentration.xml")]
internal class OxfordVitalSignsOxygenConcentrationRecord
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
