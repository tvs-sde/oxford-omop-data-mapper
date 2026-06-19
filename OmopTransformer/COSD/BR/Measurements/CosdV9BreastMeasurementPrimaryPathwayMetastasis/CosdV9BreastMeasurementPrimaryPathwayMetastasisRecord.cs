using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Breast.Measurements.CosdV9BreastMeasurementPrimaryPathwayMetastasis;

[DataOrigin("COSD")]
[Description("COSD V9 Breast Measurement Primary Pathway Metastasis")]
[SourceQuery("CosdV9BreastMeasurementPrimaryPathwayMetastasis.xml")]
internal class CosdV9BreastMeasurementPrimaryPathwayMetastasisRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? MetastaticSite { get; set; }
}
