using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.UR.Observation.COSDv8URObservationAsaPhysicalStatusClassificationSystemCode;

[DataOrigin("COSD")]
[Description("COSD V8 UR Observation Asa Physical Status Classification System Code")]
[SourceQuery("COSDv8URObservationAsaPhysicalStatusClassificationSystemCode.xml")]
internal class COSDv8URObservationAsaPhysicalStatusClassificationSystemCodeRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? AsaPhysicalStatusClassificationSystemCode { get; set; }
}
