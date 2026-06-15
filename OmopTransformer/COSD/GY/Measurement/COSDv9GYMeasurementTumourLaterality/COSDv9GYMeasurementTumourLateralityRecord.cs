using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.GY.Measurement.COSDv9GYMeasurementTumourLaterality;

[DataOrigin("COSD")]
[Description("COSD V9 GY Measurement Tumour Laterality")]
[SourceQuery("COSDv9GYMeasurementTumourLaterality.xml")]
internal class COSDv9GYMeasurementTumourLateralityRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? TumourLaterality { get; set; }
}
