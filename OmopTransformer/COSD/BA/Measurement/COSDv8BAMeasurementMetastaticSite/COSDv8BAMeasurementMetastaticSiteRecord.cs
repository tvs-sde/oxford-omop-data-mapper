using System;
using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.BA.Measurement.COSDv8BAMeasurementMetastaticSite;

[Serializable]
[DataOrigin("COSD")]
[Description("COSD V8 BA Measurement Metastatic Site")]
[SourceQuery("COSDv8BAMeasurementMetastaticSite.xml")]
internal class COSDv8BAMeasurementMetastaticSiteRecord
{
    public string? NhsNumber { get; init; }
    public string? ClinicalDateCancerDiagnosis { get; init; }
    public string? MetastaticSite { get; init; }
}
