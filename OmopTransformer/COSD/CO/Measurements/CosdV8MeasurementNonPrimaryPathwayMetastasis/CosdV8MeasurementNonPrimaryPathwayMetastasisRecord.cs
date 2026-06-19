using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Colorectal.Measurements.CosdV8MeasurementNonPrimaryPathwayMetastasis;

[DataOrigin("COSD")]
[Description("COSD V8 Measurement Non Primary Pathway Metastasis")]
[SourceQuery("CosdV8MeasurementNonPrimaryPathwayMetastasis.xml")]
internal class CosdV8MeasurementNonPrimaryPathwayMetastasisRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfNonPrimaryCancerDiagnosisClinicallyAgreed { get; set; }
    public string? MetastaticSite { get; set; }
}