using OmopTransformer.Annotations;
using OmopTransformer.Omop.ConditionOccurrence;
using OmopTransformer.Transformation;

namespace OmopTransformer.COSD.Haematological.ConditionOccurrence.CosdV9HaematologicalConditionOccurrenceOriginalMorphologyIcdo3;

[Notes(
    "Assumptions",
    "* Any changes in a Diagnosis that may occur in later submissions, for the same Diagnosis date, is taken to be an additional diagnosis as opposed to a change (hence removal of the original)")]
internal class CosdV9HaematologicalConditionOccurrenceOriginalMorphologyIcdo3 : OmopConditionOccurrence<CosdV9HaematologicalConditionOccurrenceOriginalMorphologyIcdo3Record>
{
    [CopyValue(nameof(Source.NhsNumber))]
    public override string? nhs_number { get; set; }

    [Transform(typeof(DateConverter), nameof(Source.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed))]
    public override DateTime? condition_start_date { get; set; }

    [ConstantValue(32828, "`EHR episode record`")]
    public override int? condition_type_concept_id { get; set; }

    [Transform(typeof(Icdo3MorphologySelector), nameof(Source.OriginalMorphologyIcdo3))]
    public override int? condition_source_concept_id { get; set; }

    [Transform(typeof(StandardConditionConceptSelector), useOmopTypeAsSource: true, nameof(condition_source_concept_id))]
    public override int[]? condition_concept_id { get; set; }

    [CopyValue(nameof(Source.OriginalMorphologyIcdo3))]
    public override string? condition_source_value { get; set; }
}
