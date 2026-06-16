using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.HA.Measurement.COSDv9HAMeasurementProgressionMetastaticSite;

[DataOrigin("COSD")]
[Description("COSD V9 HA Measurement Progression Metastatic Site")]
[SourceQuery("COSDv9HAMeasurementProgressionMetastaticSite.xml")]
internal class COSDv9HAMeasurementProgressionMetastaticSiteRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfNonPrimaryCancerDiagnosisClinicallyAgreed { get; set; }
    public string? MetastaticSite { get; set; }
}
