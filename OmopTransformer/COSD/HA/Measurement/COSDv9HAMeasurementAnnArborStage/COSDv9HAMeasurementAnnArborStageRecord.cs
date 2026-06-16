using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.HA.Measurement.COSDv9HAMeasurementAnnArborStage;

[DataOrigin("COSD")]
[Description("COSD V9 HA Measurement Ann Arbor Stage")]
[SourceQuery("COSDv9HAMeasurementAnnArborStage.xml")]
internal class COSDv9HAMeasurementAnnArborStageRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? AnnArborStage { get; set; }
}
