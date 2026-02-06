using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CTYA.ProcedureOccurrence.CosdV8CTYAProcedureOccurrenceProcedureOpcs;

[DataOrigin("COSD")]
[Description("Cosd V8 CTYA Procedure Occurrence Procedure Opcs")]
[SourceQuery("CosdV8CTYAProcedureOccurrenceProcedureOpcs.xml")]
internal class CosdV8CTYAProcedureOccurrenceProcedureOpcsRecord
{
    public string? NhsNumber { get; set; }
    public string? ProcedureDate { get; set; }
    public string? ProcedureOpcsCode { get; set; }
}   
