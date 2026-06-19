using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Lung.Measurements.CosdV9LungMeasurementPrimaryPathwayMetastasis;

[DataOrigin("COSD")]
[Description("COSD V9 Lung Measurement Primary Pathway Metastasis")]
[SourceQuery("CosdV9LungMeasurementPrimaryPathwayMetastasis.xml")]
internal class CosdV9LungMeasurementPrimaryPathwayMetastasisRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? MetastaticSite { get; set; }
}
