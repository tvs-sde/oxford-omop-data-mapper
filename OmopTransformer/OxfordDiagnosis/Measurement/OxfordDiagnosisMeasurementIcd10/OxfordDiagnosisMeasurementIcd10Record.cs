using OmopTransformer.Annotations;
using OmopTransformer.OxfordDiagnosis.ConditionOccurrence;

namespace OmopTransformer.OxfordDiagnosis.Measurement.OxfordDiagnosisMeasurementIcd10;

[DataOrigin("Oxford Diagnosis")]
[Description("ICD-10 and ICD10 diagnoses mapped to Measurement from databricks_diagnosis.parquet. No result or unit is inferred.")]
[SourceQuery("OxfordDiagnosisMeasurementIcd10.xml")]
internal class OxfordDiagnosisMeasurementIcd10Record : OxfordDiagnosisRecord
{
}
