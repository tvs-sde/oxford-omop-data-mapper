using OmopTransformer.Annotations;

namespace OmopTransformer.OxfordProcedures.Observation.OxfordProceduresObservationOpcs4;

internal class OxfordProceduresObservationOpcs4 : OxfordProceduresObservation<OxfordProceduresObservationOpcs4Record>
{
    [Transform(typeof(Opcs4Selector), nameof(Source.concept_code))]
    public override int? observation_source_concept_id { get; set; }
}
