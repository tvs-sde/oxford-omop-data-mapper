using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.UR.Observation.COSDv8URObservationPersonStatedSexualOrientationCodeAtDiagnosis;

[DataOrigin("COSD")]
[Description("COSD V8 UR Observation Person Stated Sexual Orientation Code At Diagnosis")]
[SourceQuery("COSDv8URObservationPersonStatedSexualOrientationCodeAtDiagnosis.xml")]
internal class COSDv8URObservationPersonStatedSexualOrientationCodeAtDiagnosisRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? PersonStatedSexualOrientationCodeAtDiagnosis { get; set; }
}
