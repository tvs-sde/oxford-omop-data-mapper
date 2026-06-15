using System;
using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CR.Measurement.COSDv8CRMeasurementNcategoryFinalPreTreatmentStage;

[Serializable]
[DataOrigin("COSD")]
[Description("COSD V8 CR Measurement Ncategory Final Pre Treatment Stage")]
[SourceQuery("COSDv8CRMeasurementNcategoryFinalPreTreatmentStage.xml")]
internal class COSDv8CRMeasurementNcategoryFinalPreTreatmentStageRecord
{
    public string? NhsNumber { get; init; }
    public string? MeasurementDate { get; init; }
    public string? NcategoryFinalPreTreatment { get; init; }
}
