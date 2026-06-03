using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.BA.Measurement.COSDv9BAMeasurementPrimaryPathwayMetastaticSite;

[DataOrigin("COSD")]
[Description("COSD V9 BA Measurement Primary Pathway Metastatic Site")]
[SourceQuery("COSDv9BAMeasurementPrimaryPathwayMetastaticSite.xml")]
internal class COSDv9BAMeasurementPrimaryPathwayMetastaticSiteRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? MetastaticSite { get; set; }
}
