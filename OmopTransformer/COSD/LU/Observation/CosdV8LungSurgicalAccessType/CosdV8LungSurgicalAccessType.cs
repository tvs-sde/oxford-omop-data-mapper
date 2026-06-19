using OmopTransformer.Annotations;
using OmopTransformer.Omop.Observation;
using OmopTransformer.Transformation;

namespace OmopTransformer.COSD.Lung.Observation.CosdV8LungSurgicalAccessType;

[Notes("Notes", DocumentationNotes.ApproximatedDatesWarning)]
internal class CosdV8LungSurgicalAccessType : OmopObservation<CosdV8LungSurgicalAccessTypeRecord>
{
    [CopyValue(nameof(Source.NhsNumber))]
    public override string? nhs_number { get; set; }

    [ConstantValue(4301351, "Surgical access")]
    public override int[]? observation_concept_id { get; set; }

    [CopyValue(nameof(Source.Date))]
    public override DateOnly? observation_date { get; set; }

    [CopyValue(nameof(Source.Date))]
    public override DateTime? observation_datetime { get; set; }

    [ConstantValue(32828, "`EHR episode record`")]
    public override int? observation_type_concept_id { get; set; }

    [Transform(typeof(SurgicalAccessTypeLungLookup), nameof(Source.SurgicalAccessType))]
    public override int? qualifier_concept_id { get; set; }

    [CopyValue(nameof(Source.SurgicalAccessType))]
    public override string? qualifier_source_value { get; set; }
}
