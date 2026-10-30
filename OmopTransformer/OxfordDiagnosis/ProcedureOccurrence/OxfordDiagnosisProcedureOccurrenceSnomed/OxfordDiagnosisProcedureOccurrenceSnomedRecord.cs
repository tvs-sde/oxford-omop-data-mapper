using OmopTransformer.Annotations;
using OmopTransformer.OxfordDiagnosis.ConditionOccurrence;

namespace OmopTransformer.OxfordDiagnosis.ProcedureOccurrence.OxfordDiagnosisProcedureOccurrenceSnomed;

[DataOrigin("Oxford Diagnosis")]
[Description("SNOMED CT diagnoses, including UK ED Subset, mapped to Procedure Occurrence from databricks_diagnosis.parquet.")]
[SourceQuery("OxfordDiagnosisProcedureOccurrenceSnomed.xml")]
internal class OxfordDiagnosisProcedureOccurrenceSnomedRecord : OxfordDiagnosisRecord
{
}
