using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.LV.Measurement.COSDv8LVMeasurementPrimaryPathwayMetastaticSite;

[DataOrigin("COSD")]
[Description("COSD v8 LV Measurement Primary Pathway Metastatic Site")]
[SourceQuery("COSDv8LVMeasurementPrimaryPathwayMetastaticSite.xml")]
internal class COSDv8LVMeasurementPrimaryPathwayMetastaticSiteRecord
{
    public string? NhsNumber { get; set; }
    public string? ClinicalDateCancerDiagnosis { get; set; }
    public string? MetastaticSite { get; set; }
}
