using OmopTransformer.Annotations;

namespace OmopTransformer.OxfordDiagnosis.Measurement.OxfordDiagnosisMeasurementSnomed;

internal class OxfordDiagnosisMeasurementSnomed : OxfordDiagnosisMeasurement<OxfordDiagnosisMeasurementSnomedRecord>
{
    [Transform(typeof(SnomedSelector), nameof(Source.concept_code))]
    public override int? measurement_source_concept_id { get; set; }
}
