using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.UG.Measurement.COSDv8UGMeasurementPrimaryPathwayMetastaticSite;

[DataOrigin("COSD")]
[Description("COSD V8 UG Measurement Primary Pathway Metastatic Site")]
[SourceQuery("COSDv8UGMeasurementPrimaryPathwayMetastaticSite.xml")]
internal class COSDv8UGMeasurementPrimaryPathwayMetastaticSiteRecord
{
    public string? NhsNumber { get; set; }
    public string? ClinicalDateCancerDiagnosis { get; set; }
    public string? MetastaticSite { get; set; }
}
