using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.GY.Measurement.COSDv8GYMeasurementPrimaryPathwayMetastaticSite;

[DataOrigin("COSD")]
[Description("COSD V8 GY Measurement Primary Pathway Metastatic Site")]
[SourceQuery("COSDv8GYMeasurementPrimaryPathwayMetastaticSite.xml")]
internal class COSDv8GYMeasurementPrimaryPathwayMetastaticSiteRecord
{
    public string? NhsNumber { get; set; }
    public string? ClinicalDateCancerDiagnosis { get; set; }
    public string? MetastaticSite { get; set; }
}
