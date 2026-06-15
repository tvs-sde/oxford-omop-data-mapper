using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.SA.Measurement.COSDv8SAMeasurementPrimaryPathwayMetastaticSite;

[DataOrigin("COSD")]
[Description("COSD v8 SA Measurement Primary Pathway Metastatic Site")]
[SourceQuery("COSDv8SAMeasurementPrimaryPathwayMetastaticSite.xml")]
internal class COSDv8SAMeasurementPrimaryPathwayMetastaticSiteRecord
{
    public string? NhsNumber { get; set; }
    public string? ClinicalDateCancerDiagnosis { get; set; }
    public string? MetastaticSite { get; set; }
}
