using OmopTransformer.Annotations;
using OmopTransformer.OxfordDiagnosis.ConditionOccurrence;

namespace OmopTransformer.OxfordDiagnosis.DeviceExposure.OxfordDiagnosisDeviceExposureSnomed;

[DataOrigin("Oxford Diagnosis")]
[Description("SNOMED CT diagnoses, including UK ED Subset, mapped to Device Exposure from databricks_diagnosis.parquet.")]
[SourceQuery("OxfordDiagnosisDeviceExposureSnomed.xml")]
internal class OxfordDiagnosisDeviceExposureSnomedRecord : OxfordDiagnosisRecord
{
}
