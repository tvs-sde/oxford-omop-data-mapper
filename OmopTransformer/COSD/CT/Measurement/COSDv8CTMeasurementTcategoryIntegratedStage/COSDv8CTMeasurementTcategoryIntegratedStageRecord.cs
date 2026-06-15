using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CT.Measurement.COSDv8CTMeasurementTcategoryIntegratedStage;

[DataOrigin("COSD")]
[Description("COSD V8 CT Measurement Tcategory Integrated Stage")]
[SourceQuery("COSDv8CTMeasurementTcategoryIntegratedStage.xml")]
internal class COSDv8CTMeasurementTcategoryIntegratedStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? TcategoryIntegratedStage { get; set; }
}
