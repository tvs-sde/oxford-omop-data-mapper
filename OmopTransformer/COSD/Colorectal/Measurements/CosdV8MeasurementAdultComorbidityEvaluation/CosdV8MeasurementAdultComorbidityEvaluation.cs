using OmopTransformer.Annotations;
using OmopTransformer.COSD.Breast.Observation;
using OmopTransformer.Omop.Measurement;
using OmopTransformer.Transformation;

namespace OmopTransformer.COSD.Colorectal.Measurements.CosdV8MeasurementAdultComorbidityEvaluation;

[Notes("Notes", DocumentationNotes.ApproximatedDatesWarning)]
internal class CosdV8MeasurementAdultComorbidityEvaluation : OmopMeasurement<CosdV8MeasurementAdultComorbidityEvaluationRecord>
{
    [CopyValue(nameof(Source.NhsNumber))]
    public override string? nhs_number { get; set; }

    [Transform(typeof(DateConverter), nameof(Source.MeasurementDate))]
    public override DateTime? measurement_date { get; set; }

    [Transform(typeof(DateConverter), nameof(Source.MeasurementDate))]
    public override DateTime? measurement_datetime { get; set; }

    [ConstantValue(32828, "EHR episode record")]
    public override int? measurement_type_concept_id { get; set; }

    [CopyValue(nameof(Source.AdultComorbidityEvaluation))]
    public override string? measurement_source_value { get; set; }

    [ConstantValue(40488785, "Adult comorbidity evaluation-27")]
    public override int[]? measurement_concept_id { get; set; }

    [Transform(typeof(DoubleParser), nameof(Source.AdultComorbidityEvaluation))]
    public override double? value_as_number { get; set; }

}
