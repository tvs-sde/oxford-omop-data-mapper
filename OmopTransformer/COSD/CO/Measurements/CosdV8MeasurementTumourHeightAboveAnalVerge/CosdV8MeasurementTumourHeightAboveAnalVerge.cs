using OmopTransformer.Annotations;
using OmopTransformer.Omop.Measurement;
using OmopTransformer.Transformation;

namespace OmopTransformer.COSD.Colorectal.Measurements.CosdV8MeasurementTumourHeightAboveAnalVerge;

internal class CosdV8MeasurementTumourHeightAboveAnalVerge : OmopMeasurement<CosdV8MeasurementTumourHeightAboveAnalVergeRecord>
{
    [CopyValue(nameof(Source.NhsNumber))]
    public override string? nhs_number { get; set; }

    [Transform(typeof(DateConverter), nameof(Source.ClinicalDateCancerDiagnosis))]
    public override DateTime? measurement_date { get; set; }

    [Transform(typeof(DateConverter), nameof(Source.ClinicalDateCancerDiagnosis))]
    public override DateTime? measurement_datetime { get; set; }

    [ConstantValue(32828, "EHR episode record")]
    public override int? measurement_type_concept_id { get; set; }

    [CopyValue(nameof(Source.TumourHeightAboveAnalVerge))]
    public override string? measurement_source_value { get; set; }

    [ConstantValue(3029142, "`Distance from anal verge`")]
    public override int[]? measurement_concept_id { get; set; }

    [ConstantValue(4172703, "`-`")]
    public override int? operator_concept_id { get; set; }

    [Transform(typeof(DoubleParser), nameof(Source.TumourHeightAboveAnalVerge))]
    public override double? value_as_number { get; set; }

    [ConstantValue("cm", "`centimetres`")]
    public override string? unit_source_value { get; set; }
}