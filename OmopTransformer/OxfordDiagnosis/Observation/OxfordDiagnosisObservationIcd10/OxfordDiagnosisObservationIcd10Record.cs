using OmopTransformer.Annotations;
using OmopTransformer.OxfordDiagnosis.ConditionOccurrence;

namespace OmopTransformer.OxfordDiagnosis.Observation.OxfordDiagnosisObservationIcd10;

[DataOrigin("Oxford Diagnosis")]
[Description("ICD-10 and ICD10 diagnoses mapped to Observation from databricks_diagnosis.parquet.")]
[SourceQuery("OxfordDiagnosisObservationIcd10.xml")]
internal class OxfordDiagnosisObservationIcd10Record : OxfordDiagnosisRecord
{
}
