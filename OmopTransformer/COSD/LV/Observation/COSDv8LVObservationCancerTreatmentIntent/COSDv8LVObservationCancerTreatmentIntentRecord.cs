using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.LV.Observation.COSDv8LVObservationCancerTreatmentIntent;

[DataOrigin("COSD")]
[Description("COSD V8 LV Observation Cancer Treatment Intent")]
[SourceQuery("COSDv8LVObservationCancerTreatmentIntent.xml")]
internal class COSDv8LVObservationCancerTreatmentIntentRecord
{
    public string? NhsNumber { get; set; }
    public string? TreatmentStartDateCancer { get; set; }
    public string? CancerTreatmentIntent { get; set; }
}
