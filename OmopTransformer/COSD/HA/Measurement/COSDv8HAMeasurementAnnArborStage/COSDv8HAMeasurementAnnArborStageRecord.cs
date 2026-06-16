using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.HA.Measurement.COSDv8HAMeasurementAnnArborStage;

[DataOrigin("COSD")]
[Description("COSD V8 HA Measurement Ann Arbor Stage")]
[SourceQuery("COSDv8HAMeasurementAnnArborStage.xml")]
internal class COSDv8HAMeasurementAnnArborStageRecord
{
    public string? NhsNumber { get; set; }
    public string? ClinicalDateCancerDiagnosis { get; set; }
    public string? AnnArborStage { get; set; }
}
