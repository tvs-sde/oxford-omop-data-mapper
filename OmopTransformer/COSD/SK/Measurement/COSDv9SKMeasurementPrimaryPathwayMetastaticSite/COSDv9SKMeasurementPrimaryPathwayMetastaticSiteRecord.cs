using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.SK.Measurement.COSDv9SKMeasurementPrimaryPathwayMetastaticSite;

[DataOrigin("COSD")]
[Description("COSD V9 SK Measurement Primary Pathway Metastatic Site")]
[SourceQuery("COSDv9SKMeasurementPrimaryPathwayMetastaticSite.xml")]
internal class COSDv9SKMeasurementPrimaryPathwayMetastaticSiteRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? MetastaticSite { get; set; }
}
