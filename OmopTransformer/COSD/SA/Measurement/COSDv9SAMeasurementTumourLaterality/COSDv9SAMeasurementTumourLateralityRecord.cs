using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.SA.Measurement.COSDv9SAMeasurementTumourLaterality;

[DataOrigin("COSD")]
[Description("COSD V9 SA Measurement Tumour Laterality")]
[SourceQuery("COSDv9SAMeasurementTumourLaterality.xml")]
internal class COSDv9SAMeasurementTumourLateralityRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? TumourLaterality { get; set; }
}
