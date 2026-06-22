using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Colorectal.Measurements.CosdV9MeasurementPrimaryPathwayMetastasis;

[DataOrigin("COSD")]
[Description("COSD V9 Measurement Primary Pathway Metastasis")]
[SourceQuery("CosdV9MeasurementPrimaryPathwayMetastasis.xml")]
internal class CosdV9MeasurementPrimaryPathwayMetastasisRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? MetastaticSite { get; set; }
}