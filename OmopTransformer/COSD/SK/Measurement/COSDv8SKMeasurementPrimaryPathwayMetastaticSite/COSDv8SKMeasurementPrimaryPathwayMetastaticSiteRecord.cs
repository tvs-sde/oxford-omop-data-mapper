using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.SK.Measurement.COSDv8SKMeasurementPrimaryPathwayMetastaticSite;

[DataOrigin("COSD")]
[Description("COSD v8 SK Measurement Primary Pathway Metastatic Site")]
[SourceQuery("COSDv8SKMeasurementPrimaryPathwayMetastaticSite.xml")]
internal class COSDv8SKMeasurementPrimaryPathwayMetastaticSiteRecord
{
    public string? NhsNumber { get; set; }
    public string? ClinicalDateCancerDiagnosis { get; set; }
    public string? MetastaticSite { get; set; }
}
