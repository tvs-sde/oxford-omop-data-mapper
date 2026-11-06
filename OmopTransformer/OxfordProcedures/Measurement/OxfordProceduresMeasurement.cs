using OmopTransformer.Annotations;
using OmopTransformer.Omop.Measurement;
using OmopTransformer.OxfordProcedures.ProcedureOccurrence;
using OmopTransformer.Transformation;

namespace OmopTransformer.OxfordProcedures.Measurement;

internal abstract class OxfordProceduresMeasurement<T> : OmopMeasurement<T>
    where T : OxfordProceduresRecord
{
    [CopyValue(nameof(Source.patient_identifier_value))]
    public override string? nhs_number { get; set; }

    [Transform(typeof(DateConverter), nameof(Source.clinical_date))]
    public override DateTime? measurement_date { get; set; }

    [Transform(typeof(DateConverter), nameof(Source.clinical_datetime))]
    public override DateTime? measurement_datetime { get; set; }

    [ConstantValue(32817, "EHR")]
    public override int? measurement_type_concept_id { get; set; }

    [Transform(typeof(StandardMeasurementConceptSelector), useOmopTypeAsSource: true, nameof(measurement_source_concept_id))]
    public override int[]? measurement_concept_id { get; set; }

    [CopyValue(nameof(Source.clinical_code))]
    public override string? measurement_source_value { get; set; }
}
