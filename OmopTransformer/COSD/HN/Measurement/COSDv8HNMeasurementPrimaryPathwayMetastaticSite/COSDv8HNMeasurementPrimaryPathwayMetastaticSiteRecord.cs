using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.HN.Measurement.COSDv8HNMeasurementPrimaryPathwayMetastaticSite;

[DataOrigin("COSD")]
[Description("COSD v8 HN Measurement Primary Pathway Metastatic Site")]
[SourceQuery("COSDv8HNMeasurementPrimaryPathwayMetastaticSite.xml")]
internal class COSDv8HNMeasurementPrimaryPathwayMetastaticSiteRecord
{
    public string? NhsNumber { get; set; }
    public string? ClinicalDateCancerDiagnosis { get; set; }
    public string? MetastaticSite { get; set; }
}
