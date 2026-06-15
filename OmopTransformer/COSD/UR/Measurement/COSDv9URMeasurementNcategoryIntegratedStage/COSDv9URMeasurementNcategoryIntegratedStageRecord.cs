using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.UR.Measurement.COSDv9URMeasurementNcategoryIntegratedStage;

[DataOrigin("COSD")]
[Description("COSD V9 UR Measurement Ncategory Integrated Stage")]
[SourceQuery("COSDv9URMeasurementNcategoryIntegratedStage.xml")]
internal class COSDv9URMeasurementNcategoryIntegratedStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? NcategoryIntegratedStage { get; set; }
}
