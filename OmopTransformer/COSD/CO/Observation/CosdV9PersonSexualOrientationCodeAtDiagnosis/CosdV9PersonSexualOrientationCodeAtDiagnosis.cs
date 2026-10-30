using OmopTransformer.Annotations;
using OmopTransformer.Omop.Observation;
using OmopTransformer.Transformation;

namespace OmopTransformer.COSD.Colorectal.Observation.CosdV9PersonSexualOrientationCodeAtDiagnosis;

[Notes("Notes", DocumentationNotes.ApproximatedDatesWarning)]
internal class CosdV9PersonSexualOrientationCodeAtDiagnosis : OmopObservation<CosdV9PersonSexualOrientationCodeAtDiagnosisRecord>
{
    [CopyValue(nameof(Source.NhsNumber))]
    public override string? nhs_number { get; set; }

    [ConstantValue(46235214, "Sexual orientation")]
    public override int[]? observation_concept_id { get; set; }

    [CopyValue(nameof(Source.Date))]
    public override DateOnly? observation_date { get; set; }

    [CopyValue(nameof(Source.Date))]
    public override DateTime? observation_datetime { get; set; }

    [ConstantValue(32828, "`EHR episode record`")]
    public override int? observation_type_concept_id { get; set; }

    [CopyValue(nameof(Source.PersonSexualOrientationCodeAtDiagnosis))]
    public override string? value_as_string { get; set; }

    [CopyValue(nameof(Source.PersonSexualOrientationCodeAtDiagnosis))]
    public override string? value_source_value { get; set; }

    [CopyValue(nameof(Source.PersonSexualOrientationCodeAtDiagnosis))]
    public override string? observation_source_value { get; set; }

    [Transform(typeof(SexualOrientationLookup), nameof(Source.PersonSexualOrientationCodeAtDiagnosis))]
    public override int? value_as_concept_id { get; set; }

}
