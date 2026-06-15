using System;
using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CR.Measurement.COSDv8CRMeasurementNonPrimaryPathwayMetastasis;

[Serializable]
[DataOrigin("COSD")]
[Description("COSD V8 CR Measurement Non Primary Pathway Metastasis")]
[SourceQuery("COSDv8CRMeasurementNonPrimaryPathwayMetastasis.xml")]
internal class COSDv8CRMeasurementNonPrimaryPathwayMetastasisRecord
{
    public string? NhsNumber { get; init; }
    public string? DateOfNonPrimaryCancerDiagnosisClinicallyAgreed { get; init; }
    public string? MetastaticSite { get; init; }
}
