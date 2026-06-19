using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Lung.Measurements.CosdV8LungMeasurementNonPrimaryPathwayMetastasis;

[DataOrigin("COSD")]
[Description("COSD V8 Lung Measurement Non Primary Pathway Metastasis")]
[SourceQuery("CosdV8LungMeasurementNonPrimaryPathwayMetastasis.xml")]
internal class CosdV8LungMeasurementNonPrimaryPathwayMetastasisRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfNonPrimaryCancerDiagnosisClinicallyAgreed { get; set; }
    public string? MetastaticSite { get; set; }
}
