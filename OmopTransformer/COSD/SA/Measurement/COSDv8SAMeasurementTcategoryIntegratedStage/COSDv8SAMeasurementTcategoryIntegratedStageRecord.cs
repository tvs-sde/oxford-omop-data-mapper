using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.SA.Measurement.COSDv8SAMeasurementTcategoryIntegratedStage;

[DataOrigin("COSD")]
[Description("COSD v8 SA Measurement Tcategory Integrated Stage")]
[SourceQuery("COSDv8SAMeasurementTcategoryIntegratedStage.xml")]
internal class COSDv8SAMeasurementTcategoryIntegratedStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? TcategoryIntegratedStage { get; set; }
}
