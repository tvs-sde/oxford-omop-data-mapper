using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.LV.Observation.COSDv9LVObservationCancerTreatmentIntent;

[DataOrigin("COSD")]
[Description("COSD V9 LV Observation Cancer Treatment Intent")]
[SourceQuery("COSDv9LVObservationCancerTreatmentIntent.xml")]
internal class COSDv9LVObservationCancerTreatmentIntentRecord
{
    public string? NhsNumber { get; set; }
    public string? TreatmentStartDateCancer { get; set; }
    public string? CancerTreatmentIntent { get; set; }
}
