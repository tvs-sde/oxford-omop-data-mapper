using OmopTransformer.Annotations;
using OmopTransformer.Omop.Measurement;
using OmopTransformer.Transformation;

namespace OmopTransformer.COSD.Lung.Measurements.CosdV9LungMeasurementMcategoryFinalPreTreatmentStage;

internal class CosdV9LungMeasurementMcategoryFinalPreTreatmentStage : OmopMeasurement<CosdV9LungMeasurementMcategoryFinalPreTreatmentStageRecord>
{
    [CopyValue(nameof(Source.NhsNumber))]
    public override string? nhs_number { get; set; }

    [Transform(typeof(DateConverter), nameof(Source.MeasurementDate))]
    public override DateTime? measurement_date { get; set; }

    [Transform(typeof(DateConverter), nameof(Source.MeasurementDate))]
    public override DateTime? measurement_datetime { get; set; }

    [ConstantValue(32828, "EHR episode record")]
    public override int? measurement_type_concept_id { get; set; }

    [CopyValue(nameof(Source.McategoryFinalPreTreatment))]
    public override string? measurement_source_value { get; set; }

    [Transform(typeof(MCategoryLookup), nameof(Source.McategoryFinalPreTreatment))]
    public override int[]? measurement_concept_id { get; set; }

    [ConstantValue(2000500014, "MCategoryFinalPreTreatmentStage")]
    public override int? measurement_source_concept_id { get; set; }
}
