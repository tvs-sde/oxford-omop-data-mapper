using OmopTransformer.Annotations;
using OmopTransformer.Omop.Measurement;
using OmopTransformer.Transformation;

namespace OmopTransformer.COSD.SA.Measurement.COSDv9SAMeasurementSarcomaTumourSiteSoftTissue;

internal class COSDv9SAMeasurementSarcomaTumourSiteSoftTissue : OmopMeasurement<COSDv9SAMeasurementSarcomaTumourSiteSoftTissueRecord>
{
    [CopyValue(nameof(Source.NhsNumber))]
    public override string? nhs_number { get; set; }

    [Transform(typeof(DateConverter), nameof(Source.DateOfPrimaryDiagnosisClinicallyAgreed))]
    public override DateTime? measurement_date { get; set; }

    [Transform(typeof(DateConverter), nameof(Source.DateOfPrimaryDiagnosisClinicallyAgreed))]
    public override DateTime? measurement_datetime { get; set; }

    [ConstantValue(32828, "EHR episode record")]
    public override int? measurement_type_concept_id { get; set; }

    [CopyValue(nameof(Source.SarcomaTumourSiteSoftTissue))]
    public override string? measurement_source_value { get; set; }

    [Transform(typeof(Opcs4Selector), nameof(Source.SarcomaTumourSiteSoftTissue))]
    public override int[]? measurement_concept_id { get; set; }
}
