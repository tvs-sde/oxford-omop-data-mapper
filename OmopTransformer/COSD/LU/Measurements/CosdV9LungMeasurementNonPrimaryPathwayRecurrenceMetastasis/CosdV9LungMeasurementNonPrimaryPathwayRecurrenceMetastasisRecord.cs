using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Lung.Measurements.CosdV9LungMeasurementNonPrimaryPathwayRecurrenceMetastasis;

[DataOrigin("COSD")]
[Description("COSD V9 Lung Measurement Non Primary Pathway Recurrence Metastasis")]
[SourceQuery("CosdV9LungMeasurementNonPrimaryPathwayRecurrenceMetastasis.xml")]
internal class CosdV9LungMeasurementNonPrimaryPathwayRecurrenceMetastasisRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfNonPrimaryCancerDiagnosisClinicallyAgreed { get; set; }
    public string? MetastaticSite { get; set; }
}
