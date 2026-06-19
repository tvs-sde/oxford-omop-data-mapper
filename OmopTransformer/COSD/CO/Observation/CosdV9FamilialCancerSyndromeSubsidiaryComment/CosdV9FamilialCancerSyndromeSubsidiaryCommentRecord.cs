using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Colorectal.Observation.CosdV9FamilialCancerSyndromeSubsidiaryComment;

[DataOrigin("COSD")]
[Description("CosdV9FamilialCancerSyndromeSubsidiaryComment")]
[SourceQuery("CosdV9FamilialCancerSyndromeSubsidiaryComment.xml")]
internal class CosdV9FamilialCancerSyndromeSubsidiaryCommentRecord
{
    public string? NhsNumber { get; set; }
    public DateOnly? Date { get; set; }
    public string? FamilialCancerSyndromeSubsidiaryComment { get; set; }
}
