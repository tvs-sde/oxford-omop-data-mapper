using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.HN.Observation.COSDv9HNObservationCancerTreatmentIntent;

[DataOrigin("COSD")]
[Description("COSD V9 HN Observation Cancer Treatment Intent")]
[SourceQuery("COSDv9HNObservationCancerTreatmentIntent.xml")]
internal class COSDv9HNObservationCancerTreatmentIntentRecord
{
    public string? NhsNumber { get; set; }
    public string? TreatmentStartDateCancer { get; set; }
    public string? CancerTreatmentIntent { get; set; }
}
