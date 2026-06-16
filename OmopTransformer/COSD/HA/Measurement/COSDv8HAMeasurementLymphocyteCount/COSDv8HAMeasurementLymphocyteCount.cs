using OmopTransformer.Annotations;
using OmopTransformer.Omop.Measurement;
using OmopTransformer.Transformation;

namespace OmopTransformer.COSD.HA.Measurement.COSDv8HAMeasurementLymphocyteCount;

internal class COSDv8HAMeasurementLymphocyteCount : OmopMeasurement<COSDv8HAMeasurementLymphocyteCountRecord>
{
    [CopyValue(nameof(Source.NhsNumber))]
    public override string? nhs_number { get; set; }

    [Transform(typeof(DateConverter), nameof(Source.ClinicalDateCancerDiagnosis))]
    public override DateTime? measurement_date { get; set; }

    [Transform(typeof(DateConverter), nameof(Source.ClinicalDateCancerDiagnosis))]
    public override DateTime? measurement_datetime { get; set; }

    [ConstantValue(32828, "EHR episode record")]
    public override int? measurement_type_concept_id { get; set; }

    [CopyValue(nameof(Source.LymphocyteCount))]
    public override string? measurement_source_value { get; set; }

    [ConstantValue("45613489", "Lymphocyte Count")]
    public override int[]? measurement_concept_id { get; set; }

    [Transform(typeof(DoubleParser), nameof(Source.LymphocyteCount))]
    public override double? value_as_number { get; set; }

    [ConstantValue("45613489", "Lymphocyte Count")]
    public override int? measurement_source_concept_id { get; set; }
}
