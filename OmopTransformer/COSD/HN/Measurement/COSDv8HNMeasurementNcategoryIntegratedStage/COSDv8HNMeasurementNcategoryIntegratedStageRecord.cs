using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.HN.Measurement.COSDv8HNMeasurementNcategoryIntegratedStage;

[DataOrigin("COSD")]
[Description("COSD v8 HN Measurement Ncategory Integrated Stage")]
[SourceQuery("COSDv8HNMeasurementNcategoryIntegratedStage.xml")]
internal class COSDv8HNMeasurementNcategoryIntegratedStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? NcategoryIntegratedStage { get; set; }
}
