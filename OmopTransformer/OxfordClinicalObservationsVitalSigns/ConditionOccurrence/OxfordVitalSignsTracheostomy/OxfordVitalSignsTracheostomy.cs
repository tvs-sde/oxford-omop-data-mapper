using OmopTransformer.Annotations;
using OmopTransformer.Omop.ConditionOccurrence;
using OmopTransformer.Transformation;

namespace OmopTransformer.OxfordClinicalObservationsVitalSigns.ConditionOccurrence.OxfordVitalSignsTracheostomy;

internal class OxfordVitalSignsTracheostomy : OmopConditionOccurrence<OxfordVitalSignsTracheostomyRecord>
{
    [CopyValue(nameof(Source.patient_identifier_value))]
    public override string? nhs_number { get; set; }

    [CopyValue(nameof(Source.record_connection_identifier))]
    public override string? RecordConnectionIdentifier { get; set; }

    [Transform(typeof(DateConverter), nameof(Source.EVENT_END_DT_TM))]
    public override DateTime? condition_start_date { get; set; }

    [Transform(typeof(DateConverter), nameof(Source.EVENT_END_DT_TM))]
    public override DateTime? condition_start_datetime { get; set; }

    [ConstantValue(32817, "EHR")]
    public override int? condition_type_concept_id { get; set; }

    [ConstantValue(4201387, "Tracheostomy present (SNOMED CT 302108003)")]
    public override int? condition_source_concept_id { get; set; }

    [ConstantValue(4201387, "Tracheostomy present (SNOMED CT 302108003)")]
    public override int[]? condition_concept_id { get; set; }

    [CopyValue(nameof(Source.EVENT))]
    public override string? condition_source_value { get; set; }
}
