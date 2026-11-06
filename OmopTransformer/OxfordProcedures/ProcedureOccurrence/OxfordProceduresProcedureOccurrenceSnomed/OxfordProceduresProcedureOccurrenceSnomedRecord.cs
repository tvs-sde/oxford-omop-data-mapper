using OmopTransformer.Annotations;

namespace OmopTransformer.OxfordProcedures.ProcedureOccurrence.OxfordProceduresProcedureOccurrenceSnomed;

[DataOrigin("Oxford Procedures")]
[Description("SNOMED CT procedures from databricks_procedures.parquet.")]
[SourceQuery("OxfordProceduresProcedureOccurrenceSnomed.xml")]
internal class OxfordProceduresProcedureOccurrenceSnomedRecord : OxfordProceduresRecord
{
}
