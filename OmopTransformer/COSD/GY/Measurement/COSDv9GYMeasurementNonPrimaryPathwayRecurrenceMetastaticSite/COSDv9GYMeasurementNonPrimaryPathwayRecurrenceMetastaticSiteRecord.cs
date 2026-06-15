using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.GY.Measurement.COSDv9GYMeasurementNonPrimaryPathwayRecurrenceMetastaticSite;

[DataOrigin("COSD")]
[Description("COSD V9 GY Measurement Non Primary Pathway Recurrence Metastatic Site")]
[SourceQuery("COSDv9GYMeasurementNonPrimaryPathwayRecurrenceMetastaticSite.xml")]
internal class COSDv9GYMeasurementNonPrimaryPathwayRecurrenceMetastaticSiteRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfNonPrimaryCancerDiagnosisClinicallyAgreed { get; set; }
    public string? MetastaticSite { get; set; }
}
