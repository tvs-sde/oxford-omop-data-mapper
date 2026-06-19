using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Lung.Measurements.CosdV8LungMeasurementPrimaryPathwayMetastasis;

[DataOrigin("COSD")]
[Description("COSD V8 Lung Measurement Primary Pathway Metastasis")]
[SourceQuery("CosdV8LungMeasurementPrimaryPathwayMetastasis.xml")]
internal class CosdV8LungMeasurementPrimaryPathwayMetastasisRecord
{
    public string? NhsNumber { get; set; }
    public string? ClinicalDateCancerDiagnosis { get; set; }
    public string? MetastaticSite { get; set; }
}
