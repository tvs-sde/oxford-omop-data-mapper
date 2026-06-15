using System;
using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CR.Measurement.COSDv8CRMeasurementTcategoryIntegratedStage;

[Serializable]
[DataOrigin("COSD")]
[Description("COSD V8 CR Measurement Tcategory Integrated Stage")]
[SourceQuery("COSDv8CRMeasurementTcategoryIntegratedStage.xml")]
internal class COSDv8CRMeasurementTcategoryIntegratedStageRecord
{
    public string? NhsNumber { get; init; }
    public string? MeasurementDate { get; init; }
    public string? TCategoryIntegratedStage { get; init; }
}
