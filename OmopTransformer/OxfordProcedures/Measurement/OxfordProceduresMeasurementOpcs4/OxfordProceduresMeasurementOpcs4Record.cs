using OmopTransformer.Annotations;
using OmopTransformer.OxfordProcedures.ProcedureOccurrence;

namespace OmopTransformer.OxfordProcedures.Measurement.OxfordProceduresMeasurementOpcs4;

[DataOrigin("Oxford Procedures")]
[Description("OPCS4 procedures mapped to Measurement from databricks_procedures.parquet. No result or unit is inferred.")]
[SourceQuery("OxfordProceduresMeasurementOpcs4.xml")]
internal class OxfordProceduresMeasurementOpcs4Record : OxfordProceduresRecord
{
}
