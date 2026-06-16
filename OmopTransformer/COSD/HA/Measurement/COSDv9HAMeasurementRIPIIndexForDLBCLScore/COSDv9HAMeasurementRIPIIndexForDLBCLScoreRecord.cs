using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.HA.Measurement.COSDv9HAMeasurementRIPIIndexForDLBCLScore;

[DataOrigin("COSD")]
[Description("COSD V9 HA Measurement RIPI Index For DLBCL Score")]
[SourceQuery("COSDv9HAMeasurementRIPIIndexForDLBCLScore.xml")]
internal class COSDv9HAMeasurementRIPIIndexForDLBCLScoreRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? RIPIIndexForDLBCLScore { get; set; }
}
