using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.GY.Observation.COSDv8GYObservationCancerTreatmentIntent;

[DataOrigin("COSD")]
[Description("COSD V8 GY Observation Cancer Treatment Intent")]
[SourceQuery("COSDv8GYObservationCancerTreatmentIntent.xml")]
internal class COSDv8GYObservationCancerTreatmentIntentRecord
{
    public string? NhsNumber { get; set; }
    public string? TreatmentStartDateCancer { get; set; }
    public string? CancerTreatmentIntent { get; set; }
}
