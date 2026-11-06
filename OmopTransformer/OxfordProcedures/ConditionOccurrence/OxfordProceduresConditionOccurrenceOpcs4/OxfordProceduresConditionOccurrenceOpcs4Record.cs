using OmopTransformer.Annotations;
using OmopTransformer.OxfordProcedures.ProcedureOccurrence;

namespace OmopTransformer.OxfordProcedures.ConditionOccurrence.OxfordProceduresConditionOccurrenceOpcs4;

[DataOrigin("Oxford Procedures")]
[Description("OPCS4 procedures mapped to Condition Occurrence from databricks_procedures.parquet.")]
[SourceQuery("OxfordProceduresConditionOccurrenceOpcs4.xml")]
internal class OxfordProceduresConditionOccurrenceOpcs4Record : OxfordProceduresRecord
{
}
