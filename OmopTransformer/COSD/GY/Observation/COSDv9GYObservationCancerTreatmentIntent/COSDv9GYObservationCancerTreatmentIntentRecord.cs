using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.GY.Observation.COSDv9GYObservationCancerTreatmentIntent;

[DataOrigin("COSD")]
[Description("COSD V9 GY Observation Cancer Treatment Intent")]
[SourceQuery("COSDv9GYObservationCancerTreatmentIntent.xml")]
internal class COSDv9GYObservationCancerTreatmentIntentRecord
{
    public string? NhsNumber { get; set; }
    public string? TreatmentStartDateCancer { get; set; }
    public string? CancerTreatmentIntent { get; set; }
}
