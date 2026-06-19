using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.LU.Measurements.CosdV9LungMeasurementNonPrimaryPathwayProgressionMetastasis;

[DataOrigin("COSD")]
[Description("COSD V9 Lung Measurement Non Primary Pathway Progression Metastasis")]
[SourceQuery("CosdV9LungMeasurementNonPrimaryPathwayProgressionMetastasis.xml")]
internal class CosdV9LungMeasurementNonPrimaryPathwayProgressionMetastasisRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfNonPrimaryCancerDiagnosisClinicallyAgreed { get; set; }
    public string? MetastaticSite { get; set; }
}
