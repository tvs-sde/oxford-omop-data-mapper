using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CT.Measurement.COSDv9CTMeasurementNonPrimaryPathwayRecurrenceMetastaticSite;

[DataOrigin("COSD")]
[Description("COSD v9 CT Measurement Non Primary Pathway Recurrence Metastatic Site")]
[SourceQuery("COSDv9CTMeasurementNonPrimaryPathwayRecurrenceMetastaticSite.xml")]
internal class COSDv9CTMeasurementNonPrimaryPathwayRecurrenceMetastaticSiteRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfNonPrimaryCancerDiagnosisClinicallyAgreed { get; set; }
    public string? MetastaticSite { get; set; }
}
