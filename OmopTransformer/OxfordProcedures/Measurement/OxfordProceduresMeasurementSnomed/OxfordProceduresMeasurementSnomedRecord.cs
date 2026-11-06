using OmopTransformer.Annotations;
using OmopTransformer.OxfordProcedures.ProcedureOccurrence;

namespace OmopTransformer.OxfordProcedures.Measurement.OxfordProceduresMeasurementSnomed;

[DataOrigin("Oxford Procedures")]
[Description("SNOMED CT procedures mapped to Measurement from databricks_procedures.parquet. No result or unit is inferred.")]
[SourceQuery("OxfordProceduresMeasurementSnomed.xml")]
internal class OxfordProceduresMeasurementSnomedRecord : OxfordProceduresRecord
{
}
