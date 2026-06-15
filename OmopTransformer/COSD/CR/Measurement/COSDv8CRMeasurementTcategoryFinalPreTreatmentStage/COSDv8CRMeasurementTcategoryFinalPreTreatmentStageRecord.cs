using System;
using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CR.Measurement.COSDv8CRMeasurementTcategoryFinalPreTreatmentStage;

[Serializable]
[DataOrigin("COSD")]
[Description("COSD V8 CR Measurement Tcategory Final Pre Treatment Stage")]
[SourceQuery("COSDv8CRMeasurementTcategoryFinalPreTreatmentStage.xml")]
internal class COSDv8CRMeasurementTcategoryFinalPreTreatmentStageRecord
{
    public string? NhsNumber { get; init; }
    public string? MeasurementDate { get; init; }
    public string? TcategoryFinalPreTreatment { get; init; }
}
