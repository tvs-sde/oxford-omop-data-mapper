using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.Colorectal.Measurements.CosdV8MeasurementPrimaryPathwayMetastasis;

[DataOrigin("COSD")]
[Description("COSD V8 Measurement Primary Pathway Metastasis")]
[SourceQuery("CosdV8MeasurementPrimaryPathwayMetastasis.xml")]
internal class CosdV8MeasurementPrimaryPathwayMetastasisRecord
{
    public string? NhsNumber { get; set; }
    public string? ClinicalDateCancerDiagnosis { get; set; }
    public string? MetastaticSite { get; set; }
}