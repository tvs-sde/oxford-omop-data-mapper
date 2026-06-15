using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.SA.Measurement.COSDv8SAMeasurementGradeOfDifferentiation;

[DataOrigin("COSD")]
[Description("COSD v8 SA Measurement Grade Of Differentiation")]
[SourceQuery("COSDv8SAMeasurementGradeOfDifferentiation.xml")]
internal class COSDv8SAMeasurementGradeOfDifferentiationRecord
{
    public string? NhsNumber { get; set; }
    public string? MeasurementDate { get; set; }
    public string? GradeOfDifferentiationAtDiagnosis { get; set; }
}
