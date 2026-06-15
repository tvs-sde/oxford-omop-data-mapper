using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.SA.Measurement.COSDv9SAMeasurementNonPrimaryPathwayRecurrenceMetastaticSite;

[DataOrigin("COSD")]
[Description("COSD V9 SA Measurement Non Primary Pathway Recurrence Metastatic Site")]
[SourceQuery("COSDv9SAMeasurementNonPrimaryPathwayRecurrenceMetastaticSite.xml")]
internal class COSDv9SAMeasurementNonPrimaryPathwayRecurrenceMetastaticSiteRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfNonPrimaryCancerDiagnosisClinicallyAgreed { get; set; }
    public string? MetastaticSite { get; set; }
}
