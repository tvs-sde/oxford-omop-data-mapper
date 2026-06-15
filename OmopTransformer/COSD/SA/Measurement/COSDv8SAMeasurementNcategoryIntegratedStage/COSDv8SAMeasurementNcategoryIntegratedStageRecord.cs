using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.SA.Measurement.COSDv8SAMeasurementNcategoryIntegratedStage;

[DataOrigin("COSD")]
[Description("COSD v8 SA Measurement Ncategory Integrated Stage")]
[SourceQuery("COSDv8SAMeasurementNcategoryIntegratedStage.xml")]
internal class COSDv8SAMeasurementNcategoryIntegratedStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? NcategoryIntegratedStage { get; set; }
}
