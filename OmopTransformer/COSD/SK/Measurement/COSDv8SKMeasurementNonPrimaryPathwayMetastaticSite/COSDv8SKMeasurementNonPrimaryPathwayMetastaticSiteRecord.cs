using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.SK.Measurement.COSDv8SKMeasurementNonPrimaryPathwayMetastaticSite;

[DataOrigin("COSD")]
[Description("COSD v8 SK Measurement Non Primary Pathway Metastatic Site")]
[SourceQuery("COSDv8SKMeasurementNonPrimaryPathwayMetastaticSite.xml")]
internal class COSDv8SKMeasurementNonPrimaryPathwayMetastaticSiteRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfNonPrimaryCancerDiagnosisClinicallyAgreed { get; set; }
    public string? MetastaticSite { get; set; }
}
