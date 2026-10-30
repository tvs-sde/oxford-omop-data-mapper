using OmopTransformer.Annotations;

namespace OmopTransformer.OxfordDiagnosis.ConditionOccurrence.OxfordDiagnosisConditionOccurrenceOpcs4;

[DataOrigin("Oxford Diagnosis")]
[Description("OPCS4-coded diagnoses from databricks_diagnosis.parquet. Only mappings to the Condition domain are retained.")]
[SourceQuery("OxfordDiagnosisOpcs4.xml")]
internal class OxfordDiagnosisOpcs4Record : OxfordDiagnosisRecord
{
}
