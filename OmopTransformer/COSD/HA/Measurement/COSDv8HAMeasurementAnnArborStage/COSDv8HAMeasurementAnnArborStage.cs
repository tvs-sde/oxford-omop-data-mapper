using OmopTransformer.Annotations;
using OmopTransformer.Omop.Measurement;
using OmopTransformer.Transformation;

namespace OmopTransformer.COSD.HA.Measurement.COSDv8HAMeasurementAnnArborStage;

internal class COSDv8HAMeasurementAnnArborStage : OmopMeasurement<COSDv8HAMeasurementAnnArborStageRecord>
{
    [CopyValue(nameof(Source.NhsNumber))]
    public override string? nhs_number { get; set; }

    [Transform(typeof(DateConverter), nameof(Source.ClinicalDateCancerDiagnosis))]
    public override DateTime? measurement_date { get; set; }

    [Transform(typeof(DateConverter), nameof(Source.ClinicalDateCancerDiagnosis))]
    public override DateTime? measurement_datetime { get; set; }

    [ConstantValue(32828, "EHR episode record")]
    public override int? measurement_type_concept_id { get; set; }

    [CopyValue(nameof(Source.AnnArborStage))]
    public override string? measurement_source_value { get; set; }

    [Transform(typeof(AnnArborStageLookup), nameof(Source.AnnArborStage))]
    public override int[]? measurement_concept_id { get; set; }
}
