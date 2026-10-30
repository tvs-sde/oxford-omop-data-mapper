using OmopTransformer.Annotations;
using OmopTransformer.Omop.Observation;
using OmopTransformer.Transformation;

namespace OmopTransformer.COSD.SA.Observation.COSDv9SAObservationSarcomaTumourSiteSoftTissue;

internal class COSDv9SAObservationSarcomaTumourSiteSoftTissue : OmopObservation<COSDv9SAObservationSarcomaTumourSiteSoftTissueRecord>
{
    [CopyValue(nameof(Source.NhsNumber))]
    public override string? nhs_number { get; set; }

    [Transform(typeof(DateOnlyConverter), nameof(Source.DateOfPrimaryDiagnosisClinicallyAgreed))]
    public override DateOnly? observation_date { get; set; }

    [Transform(typeof(DateConverter), nameof(Source.DateOfPrimaryDiagnosisClinicallyAgreed))]
    public override DateTime? observation_datetime { get; set; }

    [ConstantValue(32828, "EHR episode record")]
    public override int? observation_type_concept_id { get; set; }

    [CopyValue(nameof(Source.SarcomaTumourSiteSoftTissue))]
    public override string? observation_source_value { get; set; }

    [ConstantValue(4019104, "Soft tissue tumor AND/OR sarcoma")]
    public override int[]? observation_concept_id { get; set; }

    [Transform(typeof(Opcs4Selector), nameof(Source.SarcomaTumourSiteSoftTissue))]
    public override int? value_as_concept_id { get; set; }

    [CopyValue(nameof(Source.SarcomaTumourSiteSoftTissue))]
    public override string? value_source_value { get; set; }
}
