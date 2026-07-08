using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CT.Observation.COSDv9CTObservationCancerTreatmentIntent;

[DataOrigin("COSD")]
[Description("COSD V9 CT Observation Cancer Treatment Intent")]
[SourceQuery("COSDv9CTObservationCancerTreatmentIntent.xml")]
internal class COSDv9CTObservationCancerTreatmentIntentRecord
{
    public string? NhsNumber { get; set; }
    public string? TreatmentStartDateCancer { get; set; }
    public string? CancerTreatmentIntent { get; set; }
}
