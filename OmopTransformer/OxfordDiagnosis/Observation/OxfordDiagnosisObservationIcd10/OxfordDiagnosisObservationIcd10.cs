using OmopTransformer.Annotations;

namespace OmopTransformer.OxfordDiagnosis.Observation.OxfordDiagnosisObservationIcd10;

internal class OxfordDiagnosisObservationIcd10 : OxfordDiagnosisObservation<OxfordDiagnosisObservationIcd10Record>
{
    [Transform(typeof(Icd10StandardNonStandardSelector), nameof(Source.concept_code))]
    public override int? observation_source_concept_id { get; set; }
}
