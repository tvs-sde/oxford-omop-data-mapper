using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Breast.Observation.CosdV9BreastFamilialCancerSyndromeSubsidiaryComment;

[DataOrigin("COSD")]
[Description("CosdV9BreastFamilialCancerSyndromeSubsidiaryComment")]
[SourceQuery("CosdV9BreastFamilialCancerSyndromeSubsidiaryComment.xml")]
internal class CosdV9BreastFamilialCancerSyndromeSubsidiaryCommentRecord
{
    public string? NhsNumber { get; set; }
    public DateOnly? Date { get; set; }
    public string? FamilialCancerSyndromeSubsidiaryComment { get; set; }
}
