using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.SK.Measurement.COSDv9SKMeasurementNonPrimaryPathwayRecurrenceMetastaticSite;

[DataOrigin("COSD")]
[Description("COSD V9 SK Measurement Non Primary Pathway Recurrence Metastatic Site")]
[SourceQuery("COSDv9SKMeasurementNonPrimaryPathwayRecurrenceMetastaticSite.xml")]
internal class COSDv9SKMeasurementNonPrimaryPathwayRecurrenceMetastaticSiteRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfNonPrimaryCancerDiagnosisClinicallyAgreed { get; set; }
    public string? MetastaticSite { get; set; }
}
