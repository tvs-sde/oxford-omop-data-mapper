using OmopTransformer.Annotations;

namespace OmopTransformer.OxfordDiagnosis.ConditionOccurrence.OxfordDiagnosisConditionOccurrenceIcd10;

[DataOrigin("Oxford Diagnosis")]
[Description("ICD-10 and ICD10 diagnoses from databricks_diagnosis.parquet.")]
[SourceQuery("OxfordDiagnosisIcd10.xml")]
internal class OxfordDiagnosisIcd10Record : OxfordDiagnosisRecord
{
}
