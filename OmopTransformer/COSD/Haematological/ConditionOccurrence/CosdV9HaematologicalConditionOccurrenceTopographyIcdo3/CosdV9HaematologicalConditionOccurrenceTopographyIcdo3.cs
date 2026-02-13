using OmopTransformer.Annotations;
using OmopTransformer.Omop.ConditionOccurrence;
using OmopTransformer.Transformation;

namespace OmopTransformer.COSD.Haematological.ConditionOccurrence.CosdV9HaematologicalConditionOccurrenceTopographyIcdo3;

/// <summary>
/// Transforms COSD v9 haematological cancer topography data (ICD-O-3) into OMOP ConditionOccurrence records.
/// Maps topographical site of the tumor using ICD-O-3 topography codes to OMOP condition concepts.
/// </summary>
[Description("COSD v9 Haematological cancer topography (ICD-O-3) to OMOP ConditionOccurrence")]
internal class CosdV9HaematologicalConditionOccurrenceTopographyIcdo3 : OmopConditionOccurrence<CosdV9HaematologicalConditionOccurrenceTopographyIcdo3Record>
{
    [CopyValue(nameof(Source.NhsNumber))]
    public override string? nhs_number { get; set; }

    [Transform(typeof(DateConverter), nameof(Source.DateOfPrimaryDiagnosisClinicallyAgreed))]
    public override DateTime? condition_start_date { get; set; }

    [ConstantValue(32828, "`EHR episode record`")]
    public override int? condition_type_concept_id { get; set; }

    [Transform(typeof(Icdo3TopographyOnlySelector), nameof(Source.TopographyIcdo3))]
    public override int? condition_source_concept_id { get; set; }

    [Transform(typeof(StandardConditionConceptSelector), useOmopTypeAsSource: true, nameof(condition_source_concept_id))]
    public override int[]? condition_concept_id { get; set; }

    [CopyValue(nameof(Source.TopographyIcdo3))]
    public override string? condition_source_value { get; set; }
}
