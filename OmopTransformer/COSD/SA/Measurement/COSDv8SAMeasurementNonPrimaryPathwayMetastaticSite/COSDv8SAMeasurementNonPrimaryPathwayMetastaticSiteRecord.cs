using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.SA.Measurement.COSDv8SAMeasurementNonPrimaryPathwayMetastaticSite;

[DataOrigin("COSD")]
[Description("COSD v8 SA Measurement Non Primary Pathway Metastatic Site")]
[SourceQuery("COSDv8SAMeasurementNonPrimaryPathwayMetastaticSite.xml")]
internal class COSDv8SAMeasurementNonPrimaryPathwayMetastaticSiteRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfNonPrimaryCancerDiagnosisClinicallyAgreed { get; set; }
    public string? MetastaticSite { get; set; }
}
