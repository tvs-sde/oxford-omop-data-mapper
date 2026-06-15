using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.UR.Measurement.COSDv9URMeasurementTcategoryIntegratedStage;

[DataOrigin("COSD")]
[Description("COSD V9 UR Measurement Tcategory Integrated Stage")]
[SourceQuery("COSDv9URMeasurementTcategoryIntegratedStage.xml")]
internal class COSDv9URMeasurementTcategoryIntegratedStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? TcategoryIntegratedStage { get; set; }
}
