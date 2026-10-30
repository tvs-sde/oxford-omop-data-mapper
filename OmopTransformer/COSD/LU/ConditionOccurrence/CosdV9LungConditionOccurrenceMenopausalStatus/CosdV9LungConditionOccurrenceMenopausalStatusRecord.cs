using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.LU.ConditionOccurrence.CosdV9LungConditionOccurrenceMenopausalStatus;

[DataOrigin("COSD")]
[Description("COSD V9 Lung Condition Occurrence Menopausal Status")]
[SourceQuery("CosdV9LungConditionOccurrenceMenopausalStatus.xml")]
internal class CosdV9LungConditionOccurrenceMenopausalStatusRecord
{
    public string? NhsNumber { get; set; }
    public DateOnly? Date { get; set; }
    public string? MenopausalStatus { get; set; }
}
