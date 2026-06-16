using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.HA.Measurement.COSDv9HAMeasurementRecurrenceMetastaticSite;

[DataOrigin("COSD")]
[Description("COSD V9 HA Measurement Recurrence Metastatic Site")]
[SourceQuery("COSDv9HAMeasurementRecurrenceMetastaticSite.xml")]
internal class COSDv9HAMeasurementRecurrenceMetastaticSiteRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfNonPrimaryCancerDiagnosisClinicallyAgreed { get; set; }
    public string? MetastaticSite { get; set; }
}
