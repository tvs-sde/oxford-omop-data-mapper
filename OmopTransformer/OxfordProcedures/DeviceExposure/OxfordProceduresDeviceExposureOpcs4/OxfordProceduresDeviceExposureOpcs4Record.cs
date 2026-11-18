using OmopTransformer.Annotations;
using OmopTransformer.OxfordProcedures.ProcedureOccurrence;

namespace OmopTransformer.OxfordProcedures.DeviceExposure.OxfordProceduresDeviceExposureOpcs4;

[DataOrigin("Oxford Procedures")]
[Description("OPCS4 procedures mapped to Device Exposure from databricks_procedures.parquet.")]
[SourceQuery("OxfordProceduresDeviceExposureOpcs4.xml")]
internal class OxfordProceduresDeviceExposureOpcs4Record : OxfordProceduresRecord
{
}
