using OmopTransformer.Annotations;
    
namespace OmopTransformer.COSD.Colorectal.Measurements.CosdV9MeasurementNonPrimaryPathwayProgressionMetastasis;

[DataOrigin("COSD")]
[Description("COSD V9 Measurement Non Primary Pathway Progression Metastasis")]
[SourceQuery("CosdV9MeasurementNonPrimaryPathwayProgressionMetastasis.xml")]
internal class CosdV9MeasurementNonPrimaryPathwayProgressionMetastasisRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfNonPrimaryCancerDiagnosisClinicallyAgreed { get; set; }
    public string? MetastaticSite { get; set; }
}