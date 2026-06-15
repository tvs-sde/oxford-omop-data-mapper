using System;
using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CR.Measurement.COSDv8CRMeasurementTumourLaterality;

[Serializable]
[DataOrigin("COSD")]
[Description("COSD V8 CR Measurement Tumour Laterality")]
[SourceQuery("COSDv8CRMeasurementTumourLaterality.xml")]
internal class COSDv8CRMeasurementTumourLateralityRecord
{
    public string? NhsNumber { get; init; }
    public string? MeasurementDate { get; init; }
    public string? TumourLaterality { get; init; }
}
