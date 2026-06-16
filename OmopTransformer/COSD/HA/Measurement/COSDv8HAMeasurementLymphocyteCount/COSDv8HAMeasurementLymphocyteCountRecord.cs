using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.HA.Measurement.COSDv8HAMeasurementLymphocyteCount;

[DataOrigin("COSD")]
[Description("COSD V8 HA Measurement Lymphocyte Count")]
[SourceQuery("COSDv8HAMeasurementLymphocyteCount.xml")]
internal class COSDv8HAMeasurementLymphocyteCountRecord
{
    public string? NhsNumber { get; set; }
    public string? ClinicalDateCancerDiagnosis { get; set; }
    public string? LymphocyteCount { get; set; }
}
