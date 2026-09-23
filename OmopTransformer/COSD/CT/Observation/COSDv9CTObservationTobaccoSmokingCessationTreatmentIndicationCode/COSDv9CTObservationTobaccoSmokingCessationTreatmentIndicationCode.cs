using OmopTransformer.Annotations;
using OmopTransformer.Omop.Observation;
using OmopTransformer.Transformation;

namespace OmopTransformer.COSD.CT.Observation.COSDv9CTObservationTobaccoSmokingCessationTreatmentIndicationCode;

internal class COSDv9CTObservationTobaccoSmokingCessationTreatmentIndicationCode : OmopObservation<COSDv9CTObservationTobaccoSmokingCessationTreatmentIndicationCodeRecord>
{
    [CopyValue(nameof(Source.NhsNumber))]
    public override string? nhs_number { get; set; }

    [Transform(typeof(DateOnlyConverter), nameof(Source.DateOfPrimaryDiagnosisClinicallyAgreed))]
    public override DateOnly? observation_date { get; set; }

    [Transform(typeof(DateConverter), nameof(Source.DateOfPrimaryDiagnosisClinicallyAgreed))]
    public override DateTime? observation_datetime { get; set; }

    [ConstantValue(32828, "EHR episode record")]
    public override int? observation_type_concept_id { get; set; }

    [ConstantValue(44802474, "Smoking cessation advice declined")]
    public override int[]? observation_concept_id { get; set; }

    [CopyValue(nameof(Source.TobaccoSmokingCessationTreatmentIndicationCode))]
    public override string? observation_source_value { get; set; }
}
