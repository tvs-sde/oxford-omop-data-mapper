using OmopTransformer.Annotations;

namespace OmopTransformer.COSD.HA.Measurement.COSDv9HAMeasurementAnnArborBulkDiseaseIndicationCode;

[DataOrigin("COSD")]
[Description("COSD V9 HA Measurement Ann Arbor Bulk Disease Indication Code")]
[SourceQuery("COSDv9HAMeasurementAnnArborBulkDiseaseIndicationCode.xml")]
internal class COSDv9HAMeasurementAnnArborBulkDiseaseIndicationCodeRecord
{
    public string? NhsNumber { get; set; }
    public string? DateOfPrimaryDiagnosisClinicallyAgreed { get; set; }
    public string? AnnArborBulk { get; set; }
}
