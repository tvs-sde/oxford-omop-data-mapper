using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.SA.Measurement.COSDv9SAMeasurementSarcomaTumourSiteBone;

[DataOrigin("COSD")]
[Description("COSD V9 SA Measurement Sarcoma Tumour Site Bone")]
[SourceQuery("COSDv9SAMeasurementSarcomaTumourSiteBone.xml")]
internal class COSDv9SAMeasurementSarcomaTumourSiteBoneRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? SarcomaTumourSiteBone { get; set; }
}
