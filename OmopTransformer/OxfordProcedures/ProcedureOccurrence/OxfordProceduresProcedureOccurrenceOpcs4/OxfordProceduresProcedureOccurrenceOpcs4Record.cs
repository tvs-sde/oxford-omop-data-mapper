using OmopTransformer.Annotations;

namespace OmopTransformer.OxfordProcedures.ProcedureOccurrence.OxfordProceduresProcedureOccurrenceOpcs4;

[DataOrigin("Oxford Procedures")]
[Description("OPCS4 procedures from databricks_procedures.parquet.")]
[SourceQuery("OxfordProceduresProcedureOccurrenceOpcs4.xml")]
internal class OxfordProceduresProcedureOccurrenceOpcs4Record : OxfordProceduresRecord
{
}
