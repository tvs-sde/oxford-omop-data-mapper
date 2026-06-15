using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.LV.Measurement.COSDv9LVMeasurementTumourLaterality;

[DataOrigin("COSD")]
[Description("COSD V9 LV Measurement Tumour Laterality")]
[SourceQuery("COSDv9LVMeasurementTumourLaterality.xml")]
internal class COSDv9LVMeasurementTumourLateralityRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? TumourLaterality { get; set; }
}
