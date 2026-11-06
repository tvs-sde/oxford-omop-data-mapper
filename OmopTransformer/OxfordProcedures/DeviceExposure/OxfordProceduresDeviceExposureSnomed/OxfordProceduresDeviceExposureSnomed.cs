using OmopTransformer.Annotations;

namespace OmopTransformer.OxfordProcedures.DeviceExposure.OxfordProceduresDeviceExposureSnomed;

internal class OxfordProceduresDeviceExposureSnomed : OxfordProceduresDeviceExposure<OxfordProceduresDeviceExposureSnomedRecord>
{
    [Transform(typeof(SnomedSelector), nameof(Source.concept_code))]
    public override int? device_source_concept_id { get; set; }
}
