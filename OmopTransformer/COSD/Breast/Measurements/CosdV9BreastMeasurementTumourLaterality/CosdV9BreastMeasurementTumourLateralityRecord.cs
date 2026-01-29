using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Breast.Measurements.CosdV9BreastMeasurementTumourLaterality;

[DataOrigin("COSD")]
[Description("COSD V9 Breast Measurement Tumour Laterality")]
[SourceQuery("CosdV9BreastMeasurementTumourLaterality.xml")]
internal class CosdV9BreastMeasurementTumourLateralityRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? TumourLaterality { get; set; }
}
