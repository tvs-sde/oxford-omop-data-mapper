using OmopTransformer.Annotations;
using OmopTransformer.OxfordDiagnosis.ConditionOccurrence;

namespace OmopTransformer.OxfordDiagnosis.Measurement.OxfordDiagnosisMeasurementSnomed;

[DataOrigin("Oxford Diagnosis")]
[Description("SNOMED CT diagnoses, including UK ED Subset, mapped to Measurement from databricks_diagnosis.parquet. No result or unit is inferred.")]
[SourceQuery("OxfordDiagnosisMeasurementSnomed.xml")]
internal class OxfordDiagnosisMeasurementSnomedRecord : OxfordDiagnosisRecord
{
}
