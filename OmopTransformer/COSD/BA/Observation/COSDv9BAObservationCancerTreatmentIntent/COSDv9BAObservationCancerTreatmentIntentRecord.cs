using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.BA.Observation.COSDv9BAObservationCancerTreatmentIntent;

[DataOrigin("COSD")]
[Description("COSD V9 BA Observation Cancer Treatment Intent")]
[SourceQuery("COSDv9BAObservationCancerTreatmentIntent.xml")]
internal class COSDv9BAObservationCancerTreatmentIntentRecord
{
    public string? NhsNumber { get; set; }
    public string? TreatmentStartDateCancer { get; set; }
    public string? CancerTreatmentIntent { get; set; }
}
