using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.HA.Measurement.COSDv9HAMeasurementBinetStage;

[DataOrigin("COSD")]
[Description("COSD V9 HA Measurement Binet Stage")]
[SourceQuery("COSDv9HAMeasurementBinetStage.xml")]
internal class COSDv9HAMeasurementBinetStageRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? BinetStage { get; set; }
}
