using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CT.Measurement.COSDv9CTMeasurementPrimaryPathwayMetastaticSite;

[DataOrigin("COSD")]
[Description("COSD v9 CT Measurement Primary Pathway Metastatic Site")]
[SourceQuery("COSDv9CTMeasurementPrimaryPathwayMetastaticSite.xml")]
internal class COSDv9CTMeasurementPrimaryPathwayMetastaticSiteRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? MetastaticSite { get; set; }
}
