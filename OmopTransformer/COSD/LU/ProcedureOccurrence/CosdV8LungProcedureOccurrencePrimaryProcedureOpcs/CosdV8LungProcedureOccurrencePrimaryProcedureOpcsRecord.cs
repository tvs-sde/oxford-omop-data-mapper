using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Lung.ProcedureOccurrence.CosdV8LungProcedureOccurrencePrimaryProcedureOpcs;

[DataOrigin("COSD")]
[Description("COSD V8 Lung Procedure Occurrence Primary Procedure Opcs")]
[SourceQuery("CosdV8LungProcedureOccurrencePrimaryProcedureOpcs.xml")]
internal class CosdV8LungProcedureOccurrencePrimaryProcedureOpcsRecord
{
    public string? ProcedureDate { get; set; }
    public string? NhsNumber { get; set; }
    public string? PrimaryProcedureOpcs { get; set; }
}