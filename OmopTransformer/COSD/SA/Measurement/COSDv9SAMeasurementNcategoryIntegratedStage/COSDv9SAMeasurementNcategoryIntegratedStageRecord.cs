using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.SA.Measurement.COSDv9SAMeasurementNcategoryIntegratedStage;

[DataOrigin("COSD")]
[Description("COSD V9 SA Measurement Ncategory Integrated Stage")]
[SourceQuery("COSDv9SAMeasurementNcategoryIntegratedStage.xml")]
internal class COSDv9SAMeasurementNcategoryIntegratedStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? NCategoryIntegratedStage { get; set; }
}
