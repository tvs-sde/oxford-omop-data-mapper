using OmopTransformer.Annotations;
using OmopTransformer.Omop.Observation;
using OmopTransformer.Transformation;

namespace OmopTransformer.COSD.Lung.Observation.CosdV9LungHistoryOfAlcoholCurrent;

[Notes("Notes", DocumentationNotes.ApproximatedDatesWarning)]
internal class CosdV9LungHistoryOfAlcoholCurrent : OmopObservation<CosdV9LungHistoryOfAlcoholCurrentRecord>
{
    [CopyValue(nameof(Source.NhsNumber))]
    public override string? nhs_number { get; set; }

    [ConstantValue(44782821, "Finding of alcohol consumption")]
    public override int[]? observation_concept_id { get; set; }

    [CopyValue(nameof(Source.Date))]
    public override DateOnly? observation_date { get; set; }

    [CopyValue(nameof(Source.Date))]
    public override DateTime? observation_datetime { get; set; }

    [ConstantValue(32828, "`EHR episode record`")]
    public override int? observation_type_concept_id { get; set; }

    [CopyValue(nameof(Source.HistoryOfAlcoholCurrent))]
    public override string? value_as_string { get; set; }
}
