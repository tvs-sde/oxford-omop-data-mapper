using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CT.Measurement.COSDv8CTMeasurementNcategoryIntegratedStage;

[DataOrigin("COSD")]
[Description("COSD V8 CT Measurement Ncategory Integrated Stage")]
[SourceQuery("COSDv8CTMeasurementNcategoryIntegratedStage.xml")]
internal class COSDv8CTMeasurementNcategoryIntegratedStageRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? NcategoryIntegratedStage { get; set; }
}
