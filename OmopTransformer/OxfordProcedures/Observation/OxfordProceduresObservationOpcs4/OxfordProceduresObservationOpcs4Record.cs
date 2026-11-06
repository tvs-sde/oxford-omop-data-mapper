using OmopTransformer.Annotations;
using OmopTransformer.OxfordProcedures.ProcedureOccurrence;

namespace OmopTransformer.OxfordProcedures.Observation.OxfordProceduresObservationOpcs4;

[DataOrigin("Oxford Procedures")]
[Description("OPCS4 procedures mapped to Observation from databricks_procedures.parquet.")]
[SourceQuery("OxfordProceduresObservationOpcs4.xml")]
internal class OxfordProceduresObservationOpcs4Record : OxfordProceduresRecord
{
}
