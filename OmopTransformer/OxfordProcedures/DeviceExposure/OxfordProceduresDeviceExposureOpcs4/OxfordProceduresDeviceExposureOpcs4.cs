using OmopTransformer.Annotations;

namespace OmopTransformer.OxfordProcedures.DeviceExposure.OxfordProceduresDeviceExposureOpcs4;

internal class OxfordProceduresDeviceExposureOpcs4 : OxfordProceduresDeviceExposure<OxfordProceduresDeviceExposureOpcs4Record>
{
    [Transform(typeof(Opcs4Selector), nameof(Source.concept_code))]
    public override int? device_source_concept_id { get; set; }
}
