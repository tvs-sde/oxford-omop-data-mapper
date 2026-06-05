using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.SA.Measurement.COSDv9SAMeasurementNonPrimaryPathwayProgressionMetastaticSite;

[DataOrigin("COSD")]
[Description("COSD V9 SA Measurement Non Primary Pathway Progression Metastatic Site")]
[SourceQuery("COSDv9SAMeasurementNonPrimaryPathwayProgressionMetastaticSite.xml")]
internal class COSDv9SAMeasurementNonPrimaryPathwayProgressionMetastaticSiteRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfNonPrimaryCancerDiagnosisClinicallyAgreed { get; set; }
    public string? MetastaticSite { get; set; }
}
