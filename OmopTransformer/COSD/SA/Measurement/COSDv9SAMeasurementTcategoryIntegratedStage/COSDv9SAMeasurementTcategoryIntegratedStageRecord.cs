using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.SA.Measurement.COSDv9SAMeasurementTcategoryIntegratedStage;

[DataOrigin("COSD")]
[Description("COSD V9 SA Measurement Tcategory Integrated Stage")]
[SourceQuery("COSDv9SAMeasurementTcategoryIntegratedStage.xml")]
internal class COSDv9SAMeasurementTcategoryIntegratedStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? TCategoryIntegratedStage { get; set; }
}
