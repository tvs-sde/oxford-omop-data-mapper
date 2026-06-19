using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Lung.ProcedureOccurrence.CosdV9LungProcedureOccurrenceRelapseMethodOfDetection;

[DataOrigin("COSD")]
[Description("CosdV9LungProcedureOccurrenceRelapseMethodOfDetection")]
[SourceQuery("CosdV9LungProcedureOccurrenceRelapseMethodOfDetection.xml")]
internal class CosdV9LungProcedureOccurrenceRelapseMethodOfDetectionRecord
{
    public string? NhsNumber { get; set; }
    public DateOnly? Date { get; set; }
    public string? RelapseMethodOfDetection { get; set; }
}
