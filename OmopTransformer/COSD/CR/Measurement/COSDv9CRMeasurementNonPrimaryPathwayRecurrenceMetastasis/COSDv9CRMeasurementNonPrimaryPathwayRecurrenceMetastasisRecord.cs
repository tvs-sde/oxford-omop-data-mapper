using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CR.Measurement.COSDv9CRMeasurementNonPrimaryPathwayRecurrenceMetastasis;

[DataOrigin("COSD")]
[Description("COSD v9 CR Measurement Non Primary Pathway Recurrence Metastasis")]
[SourceQuery("COSDv9CRMeasurementNonPrimaryPathwayRecurrenceMetastasis.xml")]
internal class COSDv9CRMeasurementNonPrimaryPathwayRecurrenceMetastasisRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfNonPrimaryCancerDiagnosisClinicallyAgreed { get; set; }
    public string? MetastaticSite { get; set; }
}
