using OmopTransformer.Annotations;
using OmopTransformer.Omop.Observation;
using OmopTransformer.Transformation;

namespace OmopTransformer.COSD.SA.Observation.COSDv8SAObservationSarcomaTumourSiteSoftTissue;

internal class COSDv8SAObservationSarcomaTumourSiteSoftTissue : OmopObservation<COSDv8SAObservationSarcomaTumourSiteSoftTissueRecord>
{
    [CopyValue(nameof(Source.NhsNumber))]
    public override string? nhs_number { get; set; }

    [Transform(typeof(DateOnlyConverter), nameof(Source.ClinicalDateCancerDiagnosis))]
    public override DateOnly? observation_date { get; set; }

    [Transform(typeof(DateConverter), nameof(Source.ClinicalDateCancerDiagnosis))]
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
