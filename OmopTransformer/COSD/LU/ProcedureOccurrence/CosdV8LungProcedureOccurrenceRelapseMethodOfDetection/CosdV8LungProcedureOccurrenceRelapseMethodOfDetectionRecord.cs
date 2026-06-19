using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Lung.ProcedureOccurrence.CosdV8LungProcedureOccurrenceRelapseMethodOfDetection;

[DataOrigin("COSD")]
[Description("CosdV8LungProcedureOccurrenceRelapseMethodOfDetection")]
[SourceQuery("CosdV8LungProcedureOccurrenceRelapseMethodOfDetection.xml")]
internal class CosdV8LungProcedureOccurrenceRelapseMethodOfDetectionRecord
{
    public string? NhsNumber { get; set; }
    public DateOnly? Date { get; set; }
    public string? RelapseMethodDetectionType { get; set; }
}
