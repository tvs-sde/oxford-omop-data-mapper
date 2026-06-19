using OmopTransformer.Annotations;
using OmopTransformer.Omop.Observation;
using OmopTransformer.Transformation;

namespace OmopTransformer.COSD.Lung.Observation.CosdV8LungPersonStatedSexualOrientationCodeAtDiagnosis;

[Notes("Notes", DocumentationNotes.ApproximatedDatesWarning)]
internal class CosdV8LungPersonStatedSexualOrientationCodeAtDiagnosis : OmopObservation<CosdV8LungPersonStatedSexualOrientationCodeAtDiagnosisRecord>
{
    [CopyValue(nameof(Source.NhsNumber))]
    public override string? nhs_number { get; set; }

    [ConstantValue(4036080, "Orientation of sexual relationship")]
    public override int[]? observation_concept_id { get; set; }

    [CopyValue(nameof(Source.Date))]
    public override DateOnly? observation_date { get; set; }

    [CopyValue(nameof(Source.Date))]
    public override DateTime? observation_datetime { get; set; }

    [ConstantValue(32828, "`EHR episode record`")]
    public override int? observation_type_concept_id { get; set; }

    [CopyValue(nameof(Source.PersonStatedSexualOrientationCodeAtDiagnosis))]
    public override string? value_as_string { get; set; }

}
