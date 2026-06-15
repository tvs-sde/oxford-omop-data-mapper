using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.SA.Measurement.COSDv9SAMeasurementSarcomaTumourSiteSoftTissue;

[DataOrigin("COSD")]
[Description("COSD V9 SA Measurement Sarcoma Tumour Site Soft Tissue")]
[SourceQuery("COSDv9SAMeasurementSarcomaTumourSiteSoftTissue.xml")]
internal class COSDv9SAMeasurementSarcomaTumourSiteSoftTissueRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? SarcomaTumourSiteSoftTissue { get; set; }
}
