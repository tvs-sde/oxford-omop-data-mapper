using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.BA.Measurement.COSDv9BAMeasurementTumourLaterality;

[DataOrigin("COSD")]
[Description("COSD V9 BA Measurement Tumour Laterality")]
[SourceQuery("COSDv9BAMeasurementTumourLaterality.xml")]
internal class COSDv9BAMeasurementTumourLateralityRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? TumourLaterality { get; set; }
}
