using System;
using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CT.Measurement.COSDv8CTMeasurementMcategoryIntegratedStage;

[Serializable]
[DataOrigin("COSD")]
[Description("COSD V8 CT Measurement Mcategory Integrated Stage")]
[SourceQuery("COSDv8CTMeasurementMcategoryIntegratedStage.xml")]
internal class COSDv8CTMeasurementMcategoryIntegratedStageRecord
{
    public string? NhsNumber { get; init; }
    public string? MeasurementDate { get; init; }
    public string? McategoryIntegratedStage { get; init; }
}
