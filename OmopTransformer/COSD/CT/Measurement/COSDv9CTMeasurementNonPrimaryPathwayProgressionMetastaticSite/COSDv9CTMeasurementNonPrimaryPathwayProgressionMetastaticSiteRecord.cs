using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CT.Measurement.COSDv9CTMeasurementNonPrimaryPathwayProgressionMetastaticSite;

[DataOrigin("COSD")]
[Description("COSD v9 CT Measurement Non Primary Pathway Progression Metastatic Site")]
[SourceQuery("COSDv9CTMeasurementNonPrimaryPathwayProgressionMetastaticSite.xml")]
internal class COSDv9CTMeasurementNonPrimaryPathwayProgressionMetastaticSiteRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfNonPrimaryCancerDiagnosisClinicallyAgreed { get; set; }
    public string? MetastaticSite { get; set; }
}
