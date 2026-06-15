using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.BA.Measurement.COSDv9BAMeasurementNonPrimaryPathwayRecurrenceMetastaticSite;

[DataOrigin("COSD")]
[Description("COSD V9 BA Measurement Non Primary Pathway Recurrence Metastatic Site")]
[SourceQuery("COSDv9BAMeasurementNonPrimaryPathwayRecurrenceMetastaticSite.xml")]
internal class COSDv9BAMeasurementNonPrimaryPathwayRecurrenceMetastaticSiteRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfNonPrimaryCancerDiagnosisClinicallyAgreed { get; set; }
    public string? MetastaticSite { get; set; }
}
