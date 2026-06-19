using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Lung.ProcedureOccurrence.CosdV9LungProcedureOccurrencePrimaryProcedureOpcs;

[DataOrigin("COSD")]
[Description("Cosd V9 Lung Procedure Occurrence Primary Procedure Opcs")]
[SourceQuery("CosdV9LungProcedureOccurrencePrimaryProcedureOpcs.xml")]
internal class CosdV9LungProcedureOccurrencePrimaryProcedureOpcsRecord
{
    public string? NhsNumber { get; set; }
    public string? ProcedureDate { get; set; }
    public string? PrimaryProcedureOpcs { get; set; }
}