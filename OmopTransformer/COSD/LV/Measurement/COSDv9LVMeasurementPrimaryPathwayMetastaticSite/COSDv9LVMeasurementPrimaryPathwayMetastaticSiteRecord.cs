using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.LV.Measurement.COSDv9LVMeasurementPrimaryPathwayMetastaticSite;

[DataOrigin("COSD")]
[Description("COSD V9 LV Measurement Primary Pathway Metastatic Site")]
[SourceQuery("COSDv9LVMeasurementPrimaryPathwayMetastaticSite.xml")]
internal class COSDv9LVMeasurementPrimaryPathwayMetastaticSiteRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? MetastaticSite { get; set; }
}
