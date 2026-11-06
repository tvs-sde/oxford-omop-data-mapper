using OmopTransformer.Annotations;

namespace OmopTransformer.OxfordProcedures.Measurement.OxfordProceduresMeasurementSnomed;

internal class OxfordProceduresMeasurementSnomed : OxfordProceduresMeasurement<OxfordProceduresMeasurementSnomedRecord>
{
    [Transform(typeof(SnomedSelector), nameof(Source.concept_code))]
    public override int? measurement_source_concept_id { get; set; }
}
