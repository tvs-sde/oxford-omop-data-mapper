using OmopTransformer.Annotations;
using OmopTransformer.Omop.Measurement;
using OmopTransformer.OxfordDiagnosis.ConditionOccurrence;
using OmopTransformer.Transformation;

namespace OmopTransformer.OxfordDiagnosis.Measurement;

internal abstract class OxfordDiagnosisMeasurement<T> : OmopMeasurement<T>
    where T : OxfordDiagnosisRecord
{
    [CopyValue(nameof(Source.patient_identifier_value))]
    public override string? nhs_number { get; set; }

    [Transform(typeof(DateConverter), nameof(Source.diagnosis_date))]
    public override DateTime? measurement_date { get; set; }

    [Transform(typeof(DateConverter), nameof(Source.diagnosis_datetime))]
    public override DateTime? measurement_datetime { get; set; }

    [ConstantValue(32817, "EHR")]
    public override int? measurement_type_concept_id { get; set; }

    [Transform(typeof(StandardMeasurementConceptSelector), useOmopTypeAsSource: true, nameof(measurement_source_concept_id))]
    public override int[]? measurement_concept_id { get; set; }

    [CopyValue(nameof(Source.diagnosis_code))]
    public override string? measurement_source_value { get; set; }
}
