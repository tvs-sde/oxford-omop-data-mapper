using OmopTransformer.Annotations;
using OmopTransformer.OxfordProcedures.ProcedureOccurrence;

namespace OmopTransformer.OxfordProcedures.ConditionOccurrence.OxfordProceduresConditionOccurrenceSnomed;

[DataOrigin("Oxford Procedures")]
[Description("SNOMED CT procedures mapped to Condition Occurrence from databricks_procedures.parquet.")]
[SourceQuery("OxfordProceduresConditionOccurrenceSnomed.xml")]
internal class OxfordProceduresConditionOccurrenceSnomedRecord : OxfordProceduresRecord
{
}
