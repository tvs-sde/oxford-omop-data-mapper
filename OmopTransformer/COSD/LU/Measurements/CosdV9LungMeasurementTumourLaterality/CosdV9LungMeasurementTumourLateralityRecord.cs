using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Lung.Measurements.CosdV9LungMeasurementTumourLaterality;

[DataOrigin("COSD")]
[Description("COSD V9 Lung Measurement Tumour Laterality")]
[SourceQuery("CosdV9LungMeasurementTumourLaterality.xml")]
internal class CosdV9LungMeasurementTumourLateralityRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? TumourLaterality { get; set; }
}
