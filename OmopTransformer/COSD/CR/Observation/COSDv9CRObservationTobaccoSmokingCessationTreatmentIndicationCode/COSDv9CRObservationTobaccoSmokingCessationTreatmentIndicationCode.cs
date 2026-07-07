using OmopTransformer.Annotations;
using OmopTransformer.Omop.Observation;
using OmopTransformer.Transformation;

namespace OmopTransformer.COSD.CR.Observation.COSDv9CRObservationTobaccoSmokingCessationTreatmentIndicationCode;

internal class COSDv9CRObservationTobaccoSmokingCessationTreatmentIndicationCode : OmopObservation<COSDv9CRObservationTobaccoSmokingCessationTreatmentIndicationCodeRecord>
{
    [CopyValue(nameof(Source.NhsNumber))]
    public override string? nhs_number { get; set; }

    [Transform(typeof(DateOnlyConverter), nameof(Source.DateOfPrimaryDiagnosisClinicallyAgreed))]
    public override DateOnly? observation_date { get; set; }

    [Transform(typeof(DateConverter), nameof(Source.DateOfPrimaryDiagnosisClinicallyAgreed))]
    public override DateTime? observation_datetime { get; set; }

    [ConstantValue(32828, "EHR episode record")]
    public override int? observation_type_concept_id { get; set; }

    [ConstantValue(4206526, "Smoking cessation behavior")]
    public override int? observation_source_concept_id { get; set; }

    [Transform(typeof(StandardObservationConceptSelector), useOmopTypeAsSource: true, nameof(observation_source_concept_id))]
    public override int[]? observation_concept_id { get; set; }

    [CopyValue(nameof(Source.TobaccoSmokingCessationTreatmentIndicationCode))]
    public override string? observation_source_value { get; set; }

    [CopyValue(nameof(Source.TobaccoSmokingCessationTreatmentIndicationCode))]
    public override string? value_source_value { get; set; }
}
