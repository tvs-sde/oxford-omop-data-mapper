using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.BA.Measurement.COSDv8BAMeasurementTumourLaterality;

[Serializable]
[DataOrigin("COSD")]
[Description("COSD V8 BA Measurement Tumour Laterality")]
[SourceQuery("COSDv8BAMeasurementTumourLaterality.xml")]
internal class COSDv8BAMeasurementTumourLateralityRecord
{
    public string? NhsNumber { get; init; }
    public string? MeasurementDate { get; init; }
    public string? TumourLaterality { get; init; }
}
