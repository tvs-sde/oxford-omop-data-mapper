using OmopTransformer.Annotations;
using OmopTransformer.Omop.Measurement;
using OmopTransformer.Transformation;

namespace OmopTransformer.COSD.Breast.Measurements.CosdV9BreastMeasurementTNMcategoryIntegratedStage;

internal class CosdV9BreastMeasurementTNMcategoryIntegratedStage : OmopMeasurement<CosdV9BreastMeasurementTNMcategoryIntegratedStageRecord>
{
    [CopyValue(nameof(Source.NhsNumber))]
    public override string? nhs_number { get; set; }

    [Transform(typeof(DateConverter), nameof(Source.MeasurementDate))]
    public override DateTime? measurement_date { get; set; }

    [Transform(typeof(DateConverter), nameof(Source.MeasurementDate))]
    public override DateTime? measurement_datetime { get; set; }

    [ConstantValue(32828, "EHR episode record")]
    public override int? measurement_type_concept_id { get; set; }

    [CopyValue(nameof(Source.TnmStageGroupingIntegrated))]
    public override string? measurement_source_value { get; set; }

    [Transform(typeof(TNMCategoryLookup), nameof(Source.TnmStageGroupingIntegrated))]
    public override int[]? measurement_concept_id { get; set; }

    [ConstantValue(2000500013, "TNMCategoryIntegratedStage")]
    public override int? measurement_source_concept_id { get; set; }
}
