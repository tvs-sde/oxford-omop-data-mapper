using System;
using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.BA.Measurement.COSDv8BAMeasurementGradeOfDifferentiation;

[Serializable]
[DataOrigin("COSD")]
[Description("COSD V8 BA Measurement Grade Of Differentiation")]
[SourceQuery("COSDv8BAMeasurementGradeOfDifferentiation.xml")]
internal class COSDv8BAMeasurementGradeOfDifferentiationRecord
{
    public string? NhsNumber { get; init; }
    public string? MeasurementDate { get; init; }
    public string? GradeOfDifferentiationAtDiagnosis { get; init; }
}
