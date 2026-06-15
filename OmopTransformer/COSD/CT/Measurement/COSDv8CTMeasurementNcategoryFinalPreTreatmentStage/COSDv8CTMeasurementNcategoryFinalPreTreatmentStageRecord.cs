using System;
using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CT.Measurement.COSDv8CTMeasurementNcategoryFinalPreTreatmentStage;

[Serializable]
[DataOrigin("COSD")]
[Description("COSD V8 CT Measurement Ncategory Final Pre Treatment Stage")]
[SourceQuery("COSDv8CTMeasurementNcategoryFinalPreTreatmentStage.xml")]
internal class COSDv8CTMeasurementNcategoryFinalPreTreatmentStageRecord
{
    public string? NhsNumber { get; init; }
    public string? MeasurementDate { get; init; }
    public string? NcategoryFinalPreTreatment { get; init; }
}
