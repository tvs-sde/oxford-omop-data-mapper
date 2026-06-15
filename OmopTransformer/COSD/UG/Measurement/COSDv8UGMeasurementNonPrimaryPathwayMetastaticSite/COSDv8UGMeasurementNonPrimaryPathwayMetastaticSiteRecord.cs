using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.UG.Measurement.COSDv8UGMeasurementNonPrimaryPathwayMetastaticSite;

[DataOrigin("COSD")]
[Description("COSD V8 UG Measurement Non Primary Pathway Metastatic Site")]
[SourceQuery("COSDv8UGMeasurementNonPrimaryPathwayMetastaticSite.xml")]
internal class COSDv8UGMeasurementNonPrimaryPathwayMetastaticSiteRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfNonPrimaryCancerDiagnosisClinicallyAgreed { get; set; }
    public string? MetastaticSite { get; set; }
}
