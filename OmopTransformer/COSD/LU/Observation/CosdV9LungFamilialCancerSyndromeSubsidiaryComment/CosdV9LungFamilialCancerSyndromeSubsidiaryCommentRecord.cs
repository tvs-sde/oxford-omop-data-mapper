using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Lung.Observation.CosdV9LungFamilialCancerSyndromeSubsidiaryComment;

[DataOrigin("COSD")]
[Description("CosdV9LungFamilialCancerSyndromeSubsidiaryComment")]
[SourceQuery("CosdV9LungFamilialCancerSyndromeSubsidiaryComment.xml")]
internal class CosdV9LungFamilialCancerSyndromeSubsidiaryCommentRecord
{
    public string? NhsNumber { get; set; }
    public DateOnly? Date { get; set; }
    public string? FamilialCancerSyndromeSubsidiaryComment { get; set; }
}
