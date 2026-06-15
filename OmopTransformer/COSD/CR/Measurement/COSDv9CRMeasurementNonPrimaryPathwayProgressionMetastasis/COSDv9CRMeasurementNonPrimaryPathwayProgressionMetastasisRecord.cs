using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.CR.Measurement.COSDv9CRMeasurementNonPrimaryPathwayProgressionMetastasis;

[DataOrigin("COSD")]
[Description("COSD v9 CR Measurement Non Primary Pathway Progression Metastasis")]
[SourceQuery("COSDv9CRMeasurementNonPrimaryPathwayProgressionMetastasis.xml")]
internal class COSDv9CRMeasurementNonPrimaryPathwayProgressionMetastasisRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfNonPrimaryCancerDiagnosisClinicallyAgreed { get; set; }
    public string? MetastaticSite { get; set; }
}
