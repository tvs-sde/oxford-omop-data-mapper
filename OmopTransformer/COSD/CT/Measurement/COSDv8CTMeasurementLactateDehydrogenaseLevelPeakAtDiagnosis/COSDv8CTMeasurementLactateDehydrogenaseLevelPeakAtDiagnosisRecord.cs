using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CT.Measurement.COSDv8CTMeasurementLactateDehydrogenaseLevelPeakAtDiagnosis;

[Serializable]
[DataOrigin("COSD")]
[Description("COSD V8 CT Measurement Lactate Dehydrogenase Level Peak At Diagnosis")]
[SourceQuery("COSDv8CTMeasurementLactateDehydrogenaseLevelPeakAtDiagnosis.xml")]
internal class COSDv8CTMeasurementLactateDehydrogenaseLevelPeakAtDiagnosisRecord
{
    public string? NhsNumber { get; init; }
    public string? MeasurementDate { get; init; }
    public string? LactateDehydrogenaseLevelPeakAtDiagnosis { get; init; }
}
