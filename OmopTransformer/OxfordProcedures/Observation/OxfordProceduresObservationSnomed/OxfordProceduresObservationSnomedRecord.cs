using OmopTransformer.Annotations;
using OmopTransformer.OxfordProcedures.ProcedureOccurrence;

namespace OmopTransformer.OxfordProcedures.Observation.OxfordProceduresObservationSnomed;

[DataOrigin("Oxford Procedures")]
[Description("SNOMED CT procedures mapped to Observation from databricks_procedures.parquet.")]
[SourceQuery("OxfordProceduresObservationSnomed.xml")]
internal class OxfordProceduresObservationSnomedRecord : OxfordProceduresRecord
{
}
