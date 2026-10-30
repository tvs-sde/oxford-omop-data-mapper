using OmopTransformer.Annotations;
using OmopTransformer.Omop.Observation;
using OmopTransformer.Transformation;

namespace OmopTransformer.COSD.BR.Observation.CosdV9BreastAsaScore;

[Notes("Notes", DocumentationNotes.ApproximatedDatesWarning)]
internal class CosdV9BreastAsaScore : OmopObservation<CosdV9BreastAsaScoreRecord>
{
    [CopyValue(nameof(Source.NhsNumber))]
    public override string? nhs_number { get; set; }

    [ConstantValue(647671, "Physical status classification ASA")]
    public override int[]? observation_concept_id { get; set; }

    [CopyValue(nameof(Source.Date))]
    public override DateOnly? observation_date { get; set; }

    [CopyValue(nameof(Source.Date))]
    public override DateTime? observation_datetime { get; set; }

    [ConstantValue(32828, "`EHR episode record`")]
    public override int? observation_type_concept_id { get; set; }

    [CopyValue(nameof(Source.AsaScoreDescription))]
    public override string? value_source_value { get; set; }

    [CopyValue(nameof(Source.AsaScoreDescription))]
    public override string? observation_source_value { get; set; }

    [Transform(typeof(AsaScoreLookup), nameof(Source.AsaScore))]
    public override int? value_as_concept_id { get; set; }
}
