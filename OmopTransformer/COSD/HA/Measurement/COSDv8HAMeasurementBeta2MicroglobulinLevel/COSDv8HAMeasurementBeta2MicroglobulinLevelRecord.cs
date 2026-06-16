using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.HA.Measurement.COSDv8HAMeasurementBeta2MicroglobulinLevel;

[DataOrigin("COSD")]
[Description("COSD V8 HA Measurement Beta 2 Microglobulin Level")]
[SourceQuery("COSDv8HAMeasurementBeta2MicroglobulinLevel.xml")]
internal class COSDv8HAMeasurementBeta2MicroglobulinLevelRecord
{
    public string? NhsNumber { get; set; }
    public string? ClinicalDateCancerDiagnosis { get; set; }
    public string? Beta2MicroglobulinLevel { get; set; }
}
