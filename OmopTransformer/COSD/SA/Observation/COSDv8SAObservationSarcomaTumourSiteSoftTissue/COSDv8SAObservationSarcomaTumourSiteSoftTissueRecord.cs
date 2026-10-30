using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.SA.Observation.COSDv8SAObservationSarcomaTumourSiteSoftTissue;

[DataOrigin("COSD")]
[Description("COSD V8 SA Observation Sarcoma Tumour Site Soft Tissue")]
[SourceQuery("COSDv8SAObservationSarcomaTumourSiteSoftTissue.xml")]
internal class COSDv8SAObservationSarcomaTumourSiteSoftTissueRecord
{
    public string? NhsNumber { get; set; }
    public string? ClinicalDateCancerDiagnosis { get; set; }
    public string? SarcomaTumourSiteSoftTissue { get; set; }
}
