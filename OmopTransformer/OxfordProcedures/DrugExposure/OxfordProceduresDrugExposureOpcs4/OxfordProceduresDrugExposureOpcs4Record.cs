using OmopTransformer.Annotations;
using OmopTransformer.OxfordProcedures.ProcedureOccurrence;

namespace OmopTransformer.OxfordProcedures.DrugExposure.OxfordProceduresDrugExposureOpcs4;

[DataOrigin("Oxford Procedures")]
[Description("OPCS4 procedures mapped to single-day Drug Exposure from databricks_procedures.parquet.")]
[SourceQuery("OxfordProceduresDrugExposureOpcs4.xml")]
internal class OxfordProceduresDrugExposureOpcs4Record : OxfordProceduresRecord
{
}
