using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.GY.Measurement.COSDv9GYMeasurementNonPrimaryPathwayProgressionMetastaticSite;

[DataOrigin("COSD")]
[Description("COSD V9 GY Measurement Non Primary Pathway Progression Metastatic Site")]
[SourceQuery("COSDv9GYMeasurementNonPrimaryPathwayProgressionMetastaticSite.xml")]
internal class COSDv9GYMeasurementNonPrimaryPathwayProgressionMetastaticSiteRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfNonPrimaryCancerDiagnosisClinicallyAgreed { get; set; }
    public string? MetastaticSite { get; set; }
}
