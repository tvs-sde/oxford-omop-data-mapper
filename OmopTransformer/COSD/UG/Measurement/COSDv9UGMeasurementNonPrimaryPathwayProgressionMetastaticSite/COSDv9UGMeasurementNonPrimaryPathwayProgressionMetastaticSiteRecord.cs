using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.UG.Measurement.COSDv9UGMeasurementNonPrimaryPathwayProgressionMetastaticSite;

[DataOrigin("COSD")]
[Description("COSD V9 UG Measurement Non Primary Pathway Progression Metastatic Site")]
[SourceQuery("COSDv9UGMeasurementNonPrimaryPathwayProgressionMetastaticSite.xml")]
internal class COSDv9UGMeasurementNonPrimaryPathwayProgressionMetastaticSiteRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfNonPrimaryCancerDiagnosisClinicallyAgreed { get; set; }
    public string? MetastaticSite { get; set; }
}
