using OmopTransformer.Annotations;
using OmopTransformer.Omop.Observation;
using OmopTransformer.OxfordProcedures.ProcedureOccurrence;
using OmopTransformer.Transformation;

namespace OmopTransformer.OxfordProcedures.Observation;

internal abstract class OxfordProceduresObservation<T> : OmopObservation<T>
    where T : OxfordProceduresRecord
{
    [CopyValue(nameof(Source.patient_identifier_value))]
    public override string? nhs_number { get; set; }

    [Transform(typeof(DateOnlyConverter), nameof(Source.clinical_date))]
    public override DateOnly? observation_date { get; set; }

    [Transform(typeof(DateConverter), nameof(Source.clinical_datetime))]
    public override DateTime? observation_datetime { get; set; }

    [ConstantValue(32817, "EHR")]
    public override int? observation_type_concept_id { get; set; }

    [Transform(typeof(StandardObservationConceptSelector), useOmopTypeAsSource: true, nameof(observation_source_concept_id))]
    public override int[]? observation_concept_id { get; set; }

    [CopyValue(nameof(Source.clinical_code))]
    public override string? observation_source_value { get; set; }
}
