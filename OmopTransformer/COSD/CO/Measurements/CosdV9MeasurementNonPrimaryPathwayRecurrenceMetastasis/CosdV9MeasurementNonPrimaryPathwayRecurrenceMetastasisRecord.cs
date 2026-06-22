using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Colorectal.Measurements.CosdV9MeasurementNonPrimaryPathwayRecurrenceMetastasis;

[DataOrigin("COSD")]
[Description("COSD V9 Measurement Non Primary Pathway Recurrence Metastasis")]
[SourceQuery("CosdV9MeasurementNonPrimaryPathwayRecurrenceMetastasis.xml")]
internal class CosdV9MeasurementNonPrimaryPathwayRecurrenceMetastasisRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfNonPrimaryCancerDiagnosisClinicallyAgreed { get; set; }
    public string? MetastaticSite { get; set; }
}