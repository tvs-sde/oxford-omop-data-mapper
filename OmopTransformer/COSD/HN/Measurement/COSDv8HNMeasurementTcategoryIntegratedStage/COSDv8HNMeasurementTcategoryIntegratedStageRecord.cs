using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.HN.Measurement.COSDv8HNMeasurementTcategoryIntegratedStage;

[DataOrigin("COSD")]
[Description("COSD v8 HN Measurement Tcategory Integrated Stage")]
[SourceQuery("COSDv8HNMeasurementTcategoryIntegratedStage.xml")]
internal class COSDv8HNMeasurementTcategoryIntegratedStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? TcategoryIntegratedStage { get; set; }
}
