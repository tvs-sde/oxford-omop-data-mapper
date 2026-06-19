using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Breast.Measurements.CosdV9BreastMeasurementNonPrimaryPathwayRecurrenceMetastasis;

[DataOrigin("COSD")]
[Description("COSD V9 Breast Measurement Non Primary Pathway Recurrence Metastasis")]
[SourceQuery("CosdV9BreastMeasurementNonPrimaryPathwayRecurrenceMetastasis.xml")]
internal class CosdV9BreastMeasurementNonPrimaryPathwayRecurrenceMetastasisRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfNonPrimaryCancerDiagnosisClinicallyAgreed { get; set; }
    public string? MetastaticSite { get; set; }
}
