using OmopTransformer.Annotations;
using OmopTransformer.Omop.DeviceExposure;
using OmopTransformer.OxfordDiagnosis.ConditionOccurrence;
using OmopTransformer.Transformation;

namespace OmopTransformer.OxfordDiagnosis.DeviceExposure;

internal abstract class OxfordDiagnosisDeviceExposure<T> : OmopDeviceExposure<T>
    where T : OxfordDiagnosisRecord
{
    [CopyValue(nameof(Source.patient_identifier_value))]
    public override string? nhs_number { get; set; }

    [Transform(typeof(DateConverter), nameof(Source.diagnosis_date))]
    public override DateTime? device_exposure_start_date { get; set; }

    [Transform(typeof(DateConverter), nameof(Source.diagnosis_datetime))]
    public override DateTime? device_exposure_start_datetime { get; set; }

    [ConstantValue(32817, "EHR")]
    public override int? device_type_concept_id { get; set; }

    [Transform(typeof(StandardDeviceConceptSelector), useOmopTypeAsSource: true, nameof(device_source_concept_id))]
    public override int[]? device_concept_id { get; set; }

    [CopyValue(nameof(Source.diagnosis_code))]
    public override string? device_source_value { get; set; }
}
