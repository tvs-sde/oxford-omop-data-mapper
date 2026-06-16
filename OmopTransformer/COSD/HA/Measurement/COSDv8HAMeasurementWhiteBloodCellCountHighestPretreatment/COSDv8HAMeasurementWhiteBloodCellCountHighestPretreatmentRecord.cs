using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.HA.Measurement.COSDv8HAMeasurementWhiteBloodCellCountHighestPretreatment;

[DataOrigin("COSD")]
[Description("COSD V8 HA Measurement White Blood Cell Count Highest Pretreatment")]
[SourceQuery("COSDv8HAMeasurementWhiteBloodCellCountHighestPretreatment.xml")]
internal class COSDv8HAMeasurementWhiteBloodCellCountHighestPretreatmentRecord
{
    public string? NhsNumber { get; set; }
    public string? ClinicalDateCancerDiagnosis { get; set; }
    public string? WhiteBloodCellCountHighestPretreatment { get; set; }
}
