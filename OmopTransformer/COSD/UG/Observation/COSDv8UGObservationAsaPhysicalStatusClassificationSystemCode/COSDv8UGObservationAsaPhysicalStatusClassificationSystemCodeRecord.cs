using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.UG.Observation.COSDv8UGObservationAsaPhysicalStatusClassificationSystemCode;

[DataOrigin("COSD")]
[Description("COSD V8 UG Observation Asa Physical Status Classification System Code")]
[SourceQuery("COSDv8UGObservationAsaPhysicalStatusClassificationSystemCode.xml")]
internal class COSDv8UGObservationAsaPhysicalStatusClassificationSystemCodeRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? AsaPhysicalStatusClassificationSystemCode { get; set; }
}
