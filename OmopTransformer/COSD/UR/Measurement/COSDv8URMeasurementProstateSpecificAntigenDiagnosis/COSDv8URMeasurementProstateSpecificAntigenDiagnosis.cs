using OmopTransformer.Annotations;
using OmopTransformer.Omop.Measurement;
using OmopTransformer.Transformation;

namespace OmopTransformer.COSD.UR.Measurement.COSDv8URMeasurementProstateSpecificAntigenDiagnosis;

// Warning: No confirmed standard OMOP concept ID for Prostate Specific Antigen (Diagnosis) available locally. Placeholder used for measurement_concept_id.
internal class COSDv8URMeasurementProstateSpecificAntigenDiagnosis : OmopMeasurement<COSDv8URMeasurementProstateSpecificAntigenDiagnosisRecord>
{
    [CopyValue(nameof(Source.NhsNumber))]
    public override string? nhs_number { get; set; }

    [Transform(typeof(DateConverter), nameof(Source.MeasurementDate))]
    public override DateTime? measurement_date { get; set; }

    [Transform(typeof(DateConverter), nameof(Source.MeasurementDate))]
    public override DateTime? measurement_datetime { get; set; }

    [ConstantValue(32828, "EHR episode record")]
    public override int? measurement_type_concept_id { get; set; }

    [CopyValue(nameof(Source.ProstateSpecificAntigenDiagnosis))]
    public override string? measurement_source_value { get; set; }

    [ConstantValue(4272032, "Prostate specific antigen measurement")]
    public override int[]? measurement_concept_id { get; set; }

    [Transform(typeof(DoubleParser), nameof(Source.ProstateSpecificAntigenDiagnosis))]
    public override double? value_as_number { get; set; }

    [ConstantValue(4272032, "Prostate specific antigen measurement")]
    public override int? measurement_source_concept_id { get; set; }

    [ConstantValue(8842, "nanogram per millilitre")]
    public override int? unit_concept_id { get; set; }
}
