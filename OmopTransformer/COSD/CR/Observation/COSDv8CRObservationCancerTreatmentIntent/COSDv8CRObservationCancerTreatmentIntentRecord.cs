using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CR.Observation.COSDv8CRObservationCancerTreatmentIntent;

[DataOrigin("COSD")]
[Description("COSD V8 CR Observation Cancer Treatment Intent")]
[SourceQuery("COSDv8CRObservationCancerTreatmentIntent.xml")]
internal class COSDv8CRObservationCancerTreatmentIntentRecord
{
    public string? NhsNumber { get; set; }
    public string? TreatmentStartDateCancer { get; set; }
    public string? CancerTreatmentIntent { get; set; }
}
