using OmopTransformer.Annotations;

namespace OmopTransformer.OxfordDiagnosis.DeviceExposure.OxfordDiagnosisDeviceExposureSnomed;

internal class OxfordDiagnosisDeviceExposureSnomed : OxfordDiagnosisDeviceExposure<OxfordDiagnosisDeviceExposureSnomedRecord>
{
    [Transform(typeof(SnomedSelector), nameof(Source.concept_code))]
    public override int? device_source_concept_id { get; set; }
}
