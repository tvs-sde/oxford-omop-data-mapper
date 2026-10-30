using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.BR.ConditionOccurrence.CosdV9BreastConditionOccurrenceMenopausalStatus;

[DataOrigin("COSD")]
[Description("COSD V9 Breast Condition Occurrence Menopausal Status")]
[SourceQuery("CosdV9BreastConditionOccurrenceMenopausalStatus.xml")]
internal class CosdV9BreastConditionOccurrenceMenopausalStatusRecord
{
    public string? NhsNumber { get; set; }
    public DateOnly? Date { get; set; }
    public string? MenopausalStatus { get; set; }
}
