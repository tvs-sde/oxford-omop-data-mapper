using System;
using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CR.Measurement.COSDv8CRMeasurementGradeOfDifferentiation;

[Serializable]
[DataOrigin("COSD")]
[Description("COSD V8 CR Measurement Grade Of Differentiation")]
[SourceQuery("COSDv8CRMeasurementGradeOfDifferentiation.xml")]
internal class COSDv8CRMeasurementGradeOfDifferentiationRecord
{
    public string? NhsNumber { get; init; }
    public string? MeasurementDate { get; init; }
    public string? GradeOfDifferentiationAtDiagnosis { get; init; }
}
