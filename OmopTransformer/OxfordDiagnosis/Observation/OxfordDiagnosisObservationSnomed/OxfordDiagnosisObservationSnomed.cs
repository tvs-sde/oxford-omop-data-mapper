using OmopTransformer.Annotations;

namespace OmopTransformer.OxfordDiagnosis.Observation.OxfordDiagnosisObservationSnomed;

internal class OxfordDiagnosisObservationSnomed : OxfordDiagnosisObservation<OxfordDiagnosisObservationSnomedRecord>
{
    [Transform(typeof(SnomedSelector), nameof(Source.concept_code))]
    public override int? observation_source_concept_id { get; set; }
}
