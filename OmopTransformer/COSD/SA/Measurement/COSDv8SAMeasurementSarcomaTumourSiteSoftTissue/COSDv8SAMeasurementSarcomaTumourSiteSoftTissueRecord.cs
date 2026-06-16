using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.SA.Measurement.COSDv8SAMeasurementSarcomaTumourSiteSoftTissue;

[DataOrigin("COSD")]
[Description("COSD v8 SA Measurement Sarcoma Tumour Site Soft Tissue")]
[SourceQuery("COSDv8SAMeasurementSarcomaTumourSiteSoftTissue.xml")]
internal class COSDv8SAMeasurementSarcomaTumourSiteSoftTissueRecord
{
    public string? NhsNumber { get; set; }
    public string? ClinicalDateCancerDiagnosis { get; set; }
    public string? SarcomaTumourSiteSoftTissue { get; set; }
}
