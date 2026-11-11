using OmopTransformer.Annotations;
using OmopTransformer.OxfordDiagnosis.ConditionOccurrence;

namespace OmopTransformer.OxfordDiagnosis.ProcedureOccurrence.OxfordDiagnosisProcedureOccurrenceOpcs4;

[DataOrigin("Oxford Diagnosis")]
[Description("OPCS4-coded diagnoses mapped to Procedure Occurrence from databricks_diagnosis.parquet.")]
[SourceQuery("OxfordDiagnosisProcedureOccurrenceOpcs4.xml")]
internal class OxfordDiagnosisProcedureOccurrenceOpcs4Record : OxfordDiagnosisRecord
{
}
