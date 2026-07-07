using OmopTransformer.Annotations;
using OmopTransformer.Omop.Observation;
using OmopTransformer.Transformation;

namespace OmopTransformer.OxfordLab.Observations.LabReportGeneralComment;

internal class OxfordLabGeneralComment : OmopObservation<OxfordLabGeneralCommentRecord>
{
    [CopyValue(nameof(Source.NHS_NUMBER))]
    public override string? nhs_number { get; set; }

    [Transform(typeof(DateOnlyConverter), nameof(Source.EVENT_START_DT_TM))]
    public override DateOnly? observation_date { get; set; }

    [Transform(typeof(DateConverter), nameof(Source.EVENT_START_DT_TM))]
    public override DateTime? observation_datetime { get; set; }

    [ConstantValue(1092006, "General Comment Narrative")]
    public override int[]? observation_concept_id { get; set; }

    [ConstantValue(32828, "EHR episode record")]
    public override int? observation_type_concept_id { get; set; }

    [CopyValue(nameof(Source.EVENT))]
    public override string? observation_source_value { get; set; }

    [CopyValue(nameof(Source.RESULT_VALUE))]
    public override string? value_as_string { get; set; }
}
