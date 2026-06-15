using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.UR.Measurement.COSDv9URMeasurementPrimaryPathwayMetastaticSite;

[DataOrigin("COSD")]
[Description("COSD V9 UR Measurement Primary Pathway Metastatic Site")]
[SourceQuery("COSDv9URMeasurementPrimaryPathwayMetastaticSite.xml")]
internal class COSDv9URMeasurementPrimaryPathwayMetastaticSiteRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? MetastaticSite { get; set; }
}
