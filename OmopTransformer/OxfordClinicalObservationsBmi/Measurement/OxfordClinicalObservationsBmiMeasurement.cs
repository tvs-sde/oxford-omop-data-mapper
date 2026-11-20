using OmopTransformer.Annotations;
using OmopTransformer.Omop.Measurement;
using OmopTransformer.Transformation;

namespace OmopTransformer.OxfordClinicalObservationsBmi.Measurement;

internal class OxfordClinicalObservationsBmiMeasurement : OmopMeasurement<OxfordClinicalObservationsBmiMeasurementRecord>
{
    [CopyValue(nameof(Source.nhs_number))]
    public override string? nhs_number { get; set; }

    [Transform(typeof(DateConverter), nameof(Source.EVENT_END_DT_TM))]
    public override DateTime? measurement_date { get; set; }

    [Transform(typeof(DateConverter), nameof(Source.EVENT_END_DT_TM))]
    public override DateTime? measurement_datetime { get; set; }

    [Transform(typeof(OxfordClinicalObservationsBmiEventLookup), nameof(Source.EVENT))]
    public override int[]? measurement_concept_id { get; set; }

    [ConstantValue(32817, "EHR")]
    public override int? measurement_type_concept_id { get; set; }

    [CopyValue(nameof(Source.EVENT))]
    public override string? measurement_source_value { get; set; }

    [Transform(typeof(DoubleParser), nameof(Source.RESULT_VALUE))]
    public override double? value_as_number { get; set; }

    [CopyValue(nameof(Source.RESULT_VALUE))]
    public override string? value_source_value { get; set; }

    [Transform(typeof(OxfordClinicalObservationsBmiUnitLookup), nameof(Source.RESULT_UNITS))]
    public override int? unit_concept_id { get; set; }

    [CopyValue(nameof(Source.RESULT_UNITS))]
    public override string? unit_source_value { get; set; }

    [Transform(typeof(DoubleParser), nameof(Source.NORMAL_LOW))]
    public override double? range_low { get; set; }

    [Transform(typeof(DoubleParser), nameof(Source.NORMAL_HIGH))]
    public override double? range_high { get; set; }
}
