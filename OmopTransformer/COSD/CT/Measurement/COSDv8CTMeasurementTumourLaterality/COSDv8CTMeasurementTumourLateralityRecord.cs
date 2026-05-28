using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CT.Measurement.COSDv8CTMeasurementTumourLaterality;

[DataOrigin("COSD")]
[Description("COSD V8 CT Measurement Tumour Laterality")]
[SourceQuery("COSDv8CTMeasurementTumourLaterality.xml")]
internal class COSDv8CTMeasurementTumourLateralityRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? TumourLaterality { get; set; }
}
