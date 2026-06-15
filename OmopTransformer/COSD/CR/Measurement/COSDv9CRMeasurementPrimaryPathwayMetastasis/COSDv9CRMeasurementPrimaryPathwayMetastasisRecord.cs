using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CR.Measurement.COSDv9CRMeasurementPrimaryPathwayMetastasis;

[DataOrigin("COSD")]
[Description("COSD v9 CR Measurement Primary Pathway Metastasis")]
[SourceQuery("COSDv9CRMeasurementPrimaryPathwayMetastasis.xml")]
internal class COSDv9CRMeasurementPrimaryPathwayMetastasisRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? MetastaticSite { get; set; }
}
