using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.HN.Measurement.COSDv9HNMeasurementNonPrimaryPathwayProgressionMetastaticSite;

[DataOrigin("COSD")]
[Description("COSD V9 HN Measurement Non Primary Pathway Progression Metastatic Site")]
[SourceQuery("COSDv9HNMeasurementNonPrimaryPathwayProgressionMetastaticSite.xml")]
internal class COSDv9HNMeasurementNonPrimaryPathwayProgressionMetastaticSiteRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfNonPrimaryCancerDiagnosisClinicallyAgreed { get; set; }
    public string? MetastaticSite { get; set; }
}
