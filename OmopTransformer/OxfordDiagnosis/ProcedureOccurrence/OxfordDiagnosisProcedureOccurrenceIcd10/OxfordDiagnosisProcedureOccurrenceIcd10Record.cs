using OmopTransformer.Annotations;
using OmopTransformer.OxfordDiagnosis.ConditionOccurrence;

namespace OmopTransformer.OxfordDiagnosis.ProcedureOccurrence.OxfordDiagnosisProcedureOccurrenceIcd10;

[DataOrigin("Oxford Diagnosis")]
[Description("ICD-10 and ICD10 diagnoses mapped to Procedure Occurrence from databricks_diagnosis.parquet.")]
[SourceQuery("OxfordDiagnosisProcedureOccurrenceIcd10.xml")]
internal class OxfordDiagnosisProcedureOccurrenceIcd10Record : OxfordDiagnosisRecord
{
}
