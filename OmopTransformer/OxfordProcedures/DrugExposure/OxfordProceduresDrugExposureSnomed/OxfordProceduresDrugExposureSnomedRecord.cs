using OmopTransformer.Annotations;
using OmopTransformer.OxfordProcedures.ProcedureOccurrence;

namespace OmopTransformer.OxfordProcedures.DrugExposure.OxfordProceduresDrugExposureSnomed;

[DataOrigin("Oxford Procedures")]
[Description("SNOMED CT procedures mapped to single-day Drug Exposure from databricks_procedures.parquet.")]
[SourceQuery("OxfordProceduresDrugExposureSnomed.xml")]
internal class OxfordProceduresDrugExposureSnomedRecord : OxfordProceduresRecord
{
}
