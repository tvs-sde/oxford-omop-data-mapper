using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.HN.Measurement.COSDv8HNMeasurementNonPrimaryPathwayMetastaticSite;

[DataOrigin("COSD")]
[Description("COSD v8 HN Measurement Non Primary Pathway Metastatic Site")]
[SourceQuery("COSDv8HNMeasurementNonPrimaryPathwayMetastaticSite.xml")]
internal class COSDv8HNMeasurementNonPrimaryPathwayMetastaticSiteRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfNonPrimaryCancerDiagnosisClinicallyAgreed { get; set; }
    public string? MetastaticSite { get; set; }
}
