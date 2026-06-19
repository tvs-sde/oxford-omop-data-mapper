using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Breast.Measurements.CosdV9BreastMeasurementNonPrimaryPathwayProgressionMetastasis;

[DataOrigin("COSD")]
[Description("COSD V9 Breast Measurement Non Primary Pathway Progression Metastasis")]
[SourceQuery("CosdV9BreastMeasurementNonPrimaryPathwayProgressionMetastasis.xml")]
internal class CosdV9BreastMeasurementNonPrimaryPathwayProgressionMetastasisRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfNonPrimaryCancerDiagnosisClinicallyAgreed { get; set; }
    public string? MetastaticSite { get; set; }
}
