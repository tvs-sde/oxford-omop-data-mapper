using OmopTransformer.Annotations;
using OmopTransformer.Omop.Observation;
using OmopTransformer.Transformation;

namespace OmopTransformer.COSD.LU.Observation.CosdV9LungTobaccoSmokingCessation;

[Notes("Notes", DocumentationNotes.ApproximatedDatesWarning)]
internal class CosdV9LungTobaccoSmokingCessation : OmopObservation<CosdV9LungTobaccoSmokingCessationRecord>
{
    [CopyValue(nameof(Source.NhsNumber))]
    public override string? nhs_number { get; set; }

    [ConstantValue(44802474, "Smoking cessation advice declined")]
    public override int[]? observation_concept_id { get; set; }

    [CopyValue(nameof(Source.Date))]
    public override DateOnly? observation_date { get; set; }

    [CopyValue(nameof(Source.Date))]
    public override DateTime? observation_datetime { get; set; }

    [ConstantValue(32828, "`EHR episode record`")]
    public override int? observation_type_concept_id { get; set; }

    [CopyValue(nameof(Source.TobaccoSmokingCessation))]
    public override string? observation_source_value { get; set; }

}
