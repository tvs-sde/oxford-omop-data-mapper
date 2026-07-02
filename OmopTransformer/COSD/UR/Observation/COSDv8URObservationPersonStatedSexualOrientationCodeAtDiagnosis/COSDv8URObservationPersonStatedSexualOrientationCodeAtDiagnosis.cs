using OmopTransformer.Annotations;
using OmopTransformer.Omop.Observation;
using OmopTransformer.Transformation;

namespace OmopTransformer.COSD.UR.Observation.COSDv8URObservationPersonStatedSexualOrientationCodeAtDiagnosis;

internal class COSDv8URObservationPersonStatedSexualOrientationCodeAtDiagnosis : OmopObservation<COSDv8URObservationPersonStatedSexualOrientationCodeAtDiagnosisRecord>
{
    [CopyValue(nameof(Source.NhsNumber))]
    public override string? nhs_number { get; set; }

    [Transform(typeof(DateOnlyConverter), nameof(Source.DateOfPrimaryDiagnosisClinicallyAgreed))]
    public override DateOnly? observation_date { get; set; }

    [Transform(typeof(DateConverter), nameof(Source.DateOfPrimaryDiagnosisClinicallyAgreed))]
    public override DateTime? observation_datetime { get; set; }

    [ConstantValue(32828, "EHR episode record")]
    public override int? observation_type_concept_id { get; set; }

    [CopyValue(nameof(Source.PersonStatedSexualOrientationCodeAtDiagnosis))]
    public override string? observation_source_value { get; set; }

    [ConstantValue(4036080, "Orientation of sexual relationship")]
    public override int[]? observation_concept_id { get; set; }

    [Transform(typeof(PersonStatedSexualOrientationCodeAtDiagnosisLookup), nameof(Source.PersonStatedSexualOrientationCodeAtDiagnosis))]
    public override int? value_as_concept_id { get; set; }

    [CopyValue(nameof(Source.PersonStatedSexualOrientationCodeAtDiagnosis))]
    public override string? value_source_value { get; set; }
}
