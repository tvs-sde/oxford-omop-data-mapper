using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.SA.Observation.COSDv9SAObservationSarcomaTumourSiteSoftTissue;

[DataOrigin("COSD")]
[Description("COSD V9 SA Observation Sarcoma Tumour Site Soft Tissue")]
[SourceQuery("COSDv9SAObservationSarcomaTumourSiteSoftTissue.xml")]
internal class COSDv9SAObservationSarcomaTumourSiteSoftTissueRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? SarcomaTumourSiteSoftTissue { get; set; }
}
