using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CT.Measurement.COSDv8CTMeasurementPrimaryPathwayMetastaticSite;

[DataOrigin("COSD")]
[Description("COSD V8 CT Measurement Primary Pathway Metastatic Site")]
[SourceQuery("COSDv8CTMeasurementPrimaryPathwayMetastaticSite.xml")]
internal class COSDv8CTMeasurementPrimaryPathwayMetastaticSiteRecord
{
    public string? NhsNumber { get; set; }
    public string? ClinicalDateCancerDiagnosis { get; set; }
    public string? MetastaticSite { get; set; }
}
