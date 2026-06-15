using System;
using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CR.Measurement.COSDv8CRMeasurementPrimaryPathwayMetastasis;

[Serializable]
[DataOrigin("COSD")]
[Description("COSD V8 CR Measurement Primary Pathway Metastasis")]
[SourceQuery("COSDv8CRMeasurementPrimaryPathwayMetastasis.xml")]
internal class COSDv8CRMeasurementPrimaryPathwayMetastasisRecord
{
    public string? NhsNumber { get; init; }
    public string? ClinicalDateCancerDiagnosis { get; init; }
    public string? MetastaticSite { get; init; }
}
