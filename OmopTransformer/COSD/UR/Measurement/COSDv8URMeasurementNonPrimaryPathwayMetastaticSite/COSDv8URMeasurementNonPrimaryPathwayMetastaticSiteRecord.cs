using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.UR.Measurement.COSDv8URMeasurementNonPrimaryPathwayMetastaticSite;

[DataOrigin("COSD")]
[Description("COSD V8 UR Measurement Non Primary Pathway Metastatic Site")]
[SourceQuery("COSDv8URMeasurementNonPrimaryPathwayMetastaticSite.xml")]
internal class COSDv8URMeasurementNonPrimaryPathwayMetastaticSiteRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfNonPrimaryCancerDiagnosisClinicallyAgreed { get; set; }
    public string? MetastaticSite { get; set; }
}
