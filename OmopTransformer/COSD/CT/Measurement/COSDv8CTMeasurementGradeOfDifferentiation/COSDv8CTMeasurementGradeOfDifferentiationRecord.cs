using System;
using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CT.Measurement.COSDv8CTMeasurementGradeOfDifferentiation;

[Serializable]
[DataOrigin("COSD")]
[Description("COSD V8 CT Measurement Grade Of Differentiation")]
[SourceQuery("COSDv8CTMeasurementGradeOfDifferentiation.xml")]
internal class COSDv8CTMeasurementGradeOfDifferentiationRecord
{
    public string? NhsNumber { get; init; }
    public string? MeasurementDate { get; init; }
    public string? GradeOfDifferentiationAtDiagnosis { get; init; }
}
