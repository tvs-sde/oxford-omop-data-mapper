using OmopTransformer.Annotations;

namespace OmopTransformer.OxfordProcedures.ProcedureOccurrence.OxfordProceduresProcedureOccurrenceIcd10;

[DataOrigin("Oxford Procedures")]
[Description("ICD-10 and ICD10 procedures from databricks_procedures.parquet.")]
[SourceQuery("OxfordProceduresProcedureOccurrenceIcd10.xml")]
internal class OxfordProceduresProcedureOccurrenceIcd10Record : OxfordProceduresRecord
{
}
