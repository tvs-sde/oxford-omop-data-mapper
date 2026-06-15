using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.UR.Measurement.COSDv8URMeasurementTcategoryIntegratedStage;

[DataOrigin("COSD")]
[Description("COSD V8 UR Measurement Tcategory Integrated Stage")]
[SourceQuery("COSDv8URMeasurementTcategoryIntegratedStage.xml")]
internal class COSDv8URMeasurementTcategoryIntegratedStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? TcategoryIntegratedStage { get; set; }
}
