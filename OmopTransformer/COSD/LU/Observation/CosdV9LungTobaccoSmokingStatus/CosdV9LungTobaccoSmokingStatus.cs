using OmopTransformer.Annotations;
using OmopTransformer.Omop.Observation;
using OmopTransformer.Transformation;

namespace OmopTransformer.COSD.LU.Observation.CosdV9LungTobaccoSmokingStatus;

[Notes("Notes", DocumentationNotes.ApproximatedDatesWarning)]
internal class CosdV9LungTobaccoSmokingStatus : OmopObservation<CosdV9LungTobaccoSmokingStatusRecord>
{
    [CopyValue(nameof(Source.NhsNumber))]
    public override string? nhs_number { get; set; }

    [ConstantValue(648645, "Smoking status")]
    public override int[]? observation_concept_id { get; set; }

    [CopyValue(nameof(Source.Date))]
    public override DateOnly? observation_date { get; set; }

    [CopyValue(nameof(Source.Date))]
    public override DateTime? observation_datetime { get; set; }

    [ConstantValue(32828, "`EHR episode record`")]
    public override int? observation_type_concept_id { get; set; }

    [CopyValue(nameof(Source.TobaccoSmokingStatus))]
    public override string? value_source_value { get; set; }

    [Transform(typeof(SmokingStatusLookup), nameof(Source.TobaccoSmokingStatus))]
    public override int? value_as_concept_id { get; set; }

}
