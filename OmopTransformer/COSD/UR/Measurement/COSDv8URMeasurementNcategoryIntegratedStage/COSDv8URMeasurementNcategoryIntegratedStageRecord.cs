using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.UR.Measurement.COSDv8URMeasurementNcategoryIntegratedStage;

[DataOrigin("COSD")]
[Description("COSD V8 UR Measurement Ncategory Integrated Stage")]
[SourceQuery("COSDv8URMeasurementNcategoryIntegratedStage.xml")]
internal class COSDv8URMeasurementNcategoryIntegratedStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? NcategoryIntegratedStage { get; set; }
}
