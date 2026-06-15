using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.LV.Measurement.COSDv9LVMeasurementNonPrimaryPathwayRecurrenceMetastaticSite;

[DataOrigin("COSD")]
[Description("COSD V9 LV Measurement Non Primary Pathway Recurrence Metastatic Site")]
[SourceQuery("COSDv9LVMeasurementNonPrimaryPathwayRecurrenceMetastaticSite.xml")]
internal class COSDv9LVMeasurementNonPrimaryPathwayRecurrenceMetastaticSiteRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfNonPrimaryCancerDiagnosisClinicallyAgreed { get; set; }
    public string? MetastaticSite { get; set; }
}
