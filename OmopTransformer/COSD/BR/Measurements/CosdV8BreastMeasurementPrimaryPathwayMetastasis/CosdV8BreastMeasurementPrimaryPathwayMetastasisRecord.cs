using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Breast.Measurements.CosdV8BreastMeasurementPrimaryPathwayMetastasis;

[DataOrigin("COSD")]
[Description("COSD V8 Breast Measurement Primary Pathway Metastasis")]
[SourceQuery("CosdV8BreastMeasurementPrimaryPathwayMetastasis.xml")]
internal class CosdV8BreastMeasurementPrimaryPathwayMetastasisRecord
{
    public string? NhsNumber { get; set; }
    public string? ClinicalDateCancerDiagnosis { get; set; }
    public string? MetastaticSite { get; set; }
}
