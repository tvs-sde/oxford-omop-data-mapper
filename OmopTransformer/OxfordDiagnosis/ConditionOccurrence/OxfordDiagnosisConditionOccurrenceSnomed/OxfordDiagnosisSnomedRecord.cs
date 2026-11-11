using OmopTransformer.Annotations;

namespace OmopTransformer.OxfordDiagnosis.ConditionOccurrence.OxfordDiagnosisConditionOccurrenceSnomed;

[DataOrigin("Oxford Diagnosis")]
[Description("SNOMED CT diagnoses, including UK ED Subset, from databricks_diagnosis.parquet.")]
[SourceQuery("OxfordDiagnosisConditionOccurrenceSnomed.xml")]
internal class OxfordDiagnosisSnomedRecord : OxfordDiagnosisRecord
{
}
