using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.HN.Observation.COSDv8HNObservationCancerTreatmentIntent;

[DataOrigin("COSD")]
[Description("COSD V8 HN Observation Cancer Treatment Intent")]
[SourceQuery("COSDv8HNObservationCancerTreatmentIntent.xml")]
internal class COSDv8HNObservationCancerTreatmentIntentRecord
{
    public string? NhsNumber { get; set; }
    public string? TreatmentStartDateCancer { get; set; }
    public string? CancerTreatmentIntent { get; set; }
}
