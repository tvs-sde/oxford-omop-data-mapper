using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.SA.Measurement.COSDv9SAMeasurementMcategoryIntegratedStage;

[DataOrigin("COSD")]
[Description("COSD V9 SA Measurement Mcategory Integrated Stage")]
[SourceQuery("COSDv9SAMeasurementMcategoryIntegratedStage.xml")]
internal class COSDv9SAMeasurementMcategoryIntegratedStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? MCategoryIntegratedStage { get; set; }
}
