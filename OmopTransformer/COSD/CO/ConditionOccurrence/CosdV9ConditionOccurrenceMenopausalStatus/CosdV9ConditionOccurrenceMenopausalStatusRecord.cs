using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Colorectal.ConditionOccurrence.CosdV9ConditionOccurrenceMenopausalStatus;

[DataOrigin("COSD")]
[Description("COSD V9 Condition Occurrence Menopausal Status")]
[SourceQuery("CosdV9ConditionOccurrenceMenopausalStatus.xml")]
internal class CosdV9ConditionOccurrenceMenopausalStatusRecord
{
    public string? NhsNumber { get; set; }
    public DateOnly? Date { get; set; }
    public string? MenopausalStatus { get; set; }
}
