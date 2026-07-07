using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CR.Observation.COSDv9CRObservationCancerTreatmentIntent;

[DataOrigin("COSD")]
[Description("COSD V9 CR Observation Cancer Treatment Intent")]
[SourceQuery("COSDv9CRObservationCancerTreatmentIntent.xml")]
internal class COSDv9CRObservationCancerTreatmentIntentRecord
{
    public string? NhsNumber { get; set; }
    public string? TreatmentStartDateCancer { get; set; }
    public string? CancerTreatmentIntent { get; set; }
}
