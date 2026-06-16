using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.SA.Measurement.COSDv8SAMeasurementSarcomaTumourSiteBone;

[DataOrigin("COSD")]
[Description("COSD v8 SA Measurement Sarcoma Tumour Site Bone")]
[SourceQuery("COSDv8SAMeasurementSarcomaTumourSiteBone.xml")]
internal class COSDv8SAMeasurementSarcomaTumourSiteBoneRecord
{
    public string? NhsNumber { get; set; }
    public string? ClinicalDateCancerDiagnosis { get; set; }
    public string? SarcomaTumourSiteBone { get; set; }
}
