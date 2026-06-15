using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.GY.Measurement.COSDv8GYMeasurementTcategoryIntegratedStage;

[DataOrigin("COSD")]
[Description("COSD V8 GY Measurement Tcategory Integrated Stage")]
[SourceQuery("COSDv8GYMeasurementTcategoryIntegratedStage.xml")]
internal class COSDv8GYMeasurementTcategoryIntegratedStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? TCategoryIntegratedStage { get; set; }
}
