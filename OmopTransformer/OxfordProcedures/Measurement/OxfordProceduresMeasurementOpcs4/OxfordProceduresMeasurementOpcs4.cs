using OmopTransformer.Annotations;

namespace OmopTransformer.OxfordProcedures.Measurement.OxfordProceduresMeasurementOpcs4;

internal class OxfordProceduresMeasurementOpcs4 : OxfordProceduresMeasurement<OxfordProceduresMeasurementOpcs4Record>
{
    [Transform(typeof(Opcs4Selector), nameof(Source.concept_code))]
    public override int? measurement_source_concept_id { get; set; }
}
