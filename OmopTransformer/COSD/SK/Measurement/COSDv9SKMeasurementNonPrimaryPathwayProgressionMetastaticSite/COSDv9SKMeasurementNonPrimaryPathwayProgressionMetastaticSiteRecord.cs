using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.SK.Measurement.COSDv9SKMeasurementNonPrimaryPathwayProgressionMetastaticSite;

[DataOrigin("COSD")]
[Description("COSD V9 SK Measurement Non Primary Pathway Progression Metastatic Site")]
[SourceQuery("COSDv9SKMeasurementNonPrimaryPathwayProgressionMetastaticSite.xml")]
internal class COSDv9SKMeasurementNonPrimaryPathwayProgressionMetastaticSiteRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfNonPrimaryCancerDiagnosisClinicallyAgreed { get; set; }
    public string? MetastaticSite { get; set; }
}
