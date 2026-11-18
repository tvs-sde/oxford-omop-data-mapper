using OmopTransformer.Annotations;
using OmopTransformer.OxfordProcedures.ProcedureOccurrence;

namespace OmopTransformer.OxfordProcedures.DeviceExposure.OxfordProceduresDeviceExposureSnomed;

[DataOrigin("Oxford Procedures")]
[Description("SNOMED CT procedures mapped to Device Exposure from databricks_procedures.parquet.")]
[SourceQuery("OxfordProceduresDeviceExposureSnomed.xml")]
internal class OxfordProceduresDeviceExposureSnomedRecord : OxfordProceduresRecord
{
}
