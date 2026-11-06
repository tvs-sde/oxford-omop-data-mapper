using OmopTransformer.Annotations;

namespace OmopTransformer.OxfordProcedures.Observation.OxfordProceduresObservationSnomed;

internal class OxfordProceduresObservationSnomed : OxfordProceduresObservation<OxfordProceduresObservationSnomedRecord>
{
    [Transform(typeof(SnomedSelector), nameof(Source.concept_code))]
    public override int? observation_source_concept_id { get; set; }
}
