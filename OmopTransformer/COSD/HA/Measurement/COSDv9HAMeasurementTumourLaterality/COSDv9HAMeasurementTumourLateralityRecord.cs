using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.HA.Measurement.COSDv9HAMeasurementTumourLaterality;

[DataOrigin("COSD")]
[Description("COSD V9 HA Measurement Tumour Laterality")]
[SourceQuery("COSDv9HAMeasurementTumourLaterality.xml")]
internal class COSDv9HAMeasurementTumourLateralityRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? TumourLaterality { get; set; }
}
