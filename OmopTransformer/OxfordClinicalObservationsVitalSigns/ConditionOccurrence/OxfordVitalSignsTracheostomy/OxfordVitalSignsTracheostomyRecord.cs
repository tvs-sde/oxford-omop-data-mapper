using OmopTransformer.Annotations;

namespace OmopTransformer.OxfordClinicalObservationsVitalSigns.ConditionOccurrence.OxfordVitalSignsTracheostomy;

[DataOrigin("OxfordClinicalObservationsVitalSigns")]
[Description("Oxford tracheostomy-in-situ condition from Yes answers only.")]
[SourceQuery("OxfordVitalSignsTracheostomy.xml")]
internal class OxfordVitalSignsTracheostomyRecord
{
    public string? patient_identifier_value { get; set; }
    public string? EVENT_END_DT_TM { get; set; }
    public string? EVENT { get; set; }
    public string? record_connection_identifier { get; set; }
}
