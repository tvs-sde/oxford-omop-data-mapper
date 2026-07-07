using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.BA.Observation.COSDv8BAObservationCancerTreatmentIntent;

[DataOrigin("COSD")]
[Description("COSD V8 BA Observation Cancer Treatment Intent")]
[SourceQuery("COSDv8BAObservationCancerTreatmentIntent.xml")]
internal class COSDv8BAObservationCancerTreatmentIntentRecord
{
    public string? NhsNumber { get; set; }
    public string? TreatmentStartDateCancer { get; set; }
    public string? CancerTreatmentIntent { get; set; }
}
