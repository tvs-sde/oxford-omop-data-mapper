using OmopTransformer.Annotations;

namespace OmopTransformer.OxfordLab.Observations.LabReportGeneralComment;

[DataOrigin("OxfordLab")]
[Description("Oxford Lab General Comment Observation")]
[SourceQuery("OxfordLabGeneralComment.xml")]
internal class OxfordLabGeneralCommentRecord
{
    public string? NHS_NUMBER { get; set; }
    public string? EVENT { get; set; }
    public string? EVENT_START_DT_TM { get; set; }
    public string? RESULT_VALUE { get; set; }
}
