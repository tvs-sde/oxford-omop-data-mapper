using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Breast.Measurements.CosdV8BreastMeasurementNonPrimaryPathwayMetastasis;

[DataOrigin("COSD")]
[Description("COSD V8 Breast Measurement Non Primary Pathway Metastasis")]
[SourceQuery("CosdV8BreastMeasurementNonPrimaryPathwayMetastasis.xml")]
internal class CosdV8BreastMeasurementNonPrimaryPathwayMetastasisRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfNonPrimaryCancerDiagnosisClinicallyAgreed { get; set; }
    public string? MetastaticSite { get; set; }
}
