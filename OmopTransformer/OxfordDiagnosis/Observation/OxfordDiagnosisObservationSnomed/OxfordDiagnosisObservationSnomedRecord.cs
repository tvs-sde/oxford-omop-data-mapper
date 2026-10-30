using OmopTransformer.Annotations;
using OmopTransformer.OxfordDiagnosis.ConditionOccurrence;

namespace OmopTransformer.OxfordDiagnosis.Observation.OxfordDiagnosisObservationSnomed;

[DataOrigin("Oxford Diagnosis")]
[Description("SNOMED CT diagnoses, including UK ED Subset, mapped to Observation from databricks_diagnosis.parquet.")]
[SourceQuery("OxfordDiagnosisObservationSnomed.xml")]
internal class OxfordDiagnosisObservationSnomedRecord : OxfordDiagnosisRecord
{
}
