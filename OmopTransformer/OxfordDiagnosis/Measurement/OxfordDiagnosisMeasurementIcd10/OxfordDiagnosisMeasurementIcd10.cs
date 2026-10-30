using OmopTransformer.Annotations;

namespace OmopTransformer.OxfordDiagnosis.Measurement.OxfordDiagnosisMeasurementIcd10;

internal class OxfordDiagnosisMeasurementIcd10 : OxfordDiagnosisMeasurement<OxfordDiagnosisMeasurementIcd10Record>
{
    [Transform(typeof(Icd10StandardNonStandardSelector), nameof(Source.concept_code))]
    public override int? measurement_source_concept_id { get; set; }
}
