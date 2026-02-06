using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CTYA.ProcedureOccurrence.CosdV8CTYAProcedureOccurrencePrimaryProcedureOpcs;

[DataOrigin("COSD")]
[Description("Cosd V8 CTYA Procedure Occurrence Primary Procedure Opcs")]
[SourceQuery("CosdV8CTYAProcedureOccurrencePrimaryProcedureOpcs.xml")]
internal class CosdV8CTYAProcedureOccurrencePrimaryProcedureOpcsRecord
{
    public string? NhsNumber { get; set; }
    public string? ProcedureDate { get; set; }
    public string? PrimaryProcedureOpcs { get; set; }
}
