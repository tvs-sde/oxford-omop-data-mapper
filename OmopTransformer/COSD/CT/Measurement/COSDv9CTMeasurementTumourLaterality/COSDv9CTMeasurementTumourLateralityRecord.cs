using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CT.Measurement.COSDv9CTMeasurementTumourLaterality;

[DataOrigin("COSD")]
[Description("COSD V9 CT Measurement Tumour Laterality")]
[SourceQuery("COSDv9CTMeasurementTumourLaterality.xml")]
internal class COSDv9CTMeasurementTumourLateralityRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? TumourLaterality { get; set; }
}
