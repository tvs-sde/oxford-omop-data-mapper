using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.LV.Measurement.COSDv9LVMeasurementNonPrimaryPathwayProgressionMetastaticSite;

[DataOrigin("COSD")]
[Description("COSD V9 LV Measurement Non Primary Pathway Progression Metastatic Site")]
[SourceQuery("COSDv9LVMeasurementNonPrimaryPathwayProgressionMetastaticSite.xml")]
internal class COSDv9LVMeasurementNonPrimaryPathwayProgressionMetastaticSiteRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfNonPrimaryCancerDiagnosisClinicallyAgreed { get; set; }
    public string? MetastaticSite { get; set; }
}
