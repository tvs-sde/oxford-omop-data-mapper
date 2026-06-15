using System;
using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CT.Measurement.COSDv8CTMeasurementLactateDehydrogenaseLevelNormalUpperLimit;

[Serializable]
[DataOrigin("COSD")]
[Description("COSD V8 CT Measurement Lactate Dehydrogenase Level Normal Upper Limit")]
[SourceQuery("COSDv8CTMeasurementLactateDehydrogenaseLevelNormalUpperLimit.xml")]
internal class COSDv8CTMeasurementLactateDehydrogenaseLevelNormalUpperLimitRecord
{
    public string? NhsNumber { get; init; }
    public string? MeasurementDate { get; init; }
    public string? LactateDehydrogenaseLevelNormalUpperLimit { get; init; }
}
