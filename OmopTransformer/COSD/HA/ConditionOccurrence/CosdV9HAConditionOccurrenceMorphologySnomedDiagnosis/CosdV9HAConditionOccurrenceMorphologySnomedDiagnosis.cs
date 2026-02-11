using OmopTransformer.Annotations;
using OmopTransformer.Omop.ConditionOccurrence;
using OmopTransformer.Transformation;

namespace OmopTransformer.COSD.HA.ConditionOccurrence.CosdV9HAConditionOccurrenceMorphologySnomedDiagnosis;

[Notes(
    "Assumptions",
    "* Any changes in a Diagnosis that may occur in later submissions, for the same Diagnosis date, is taken to be an additional diagnosis as opposed to a change (hence removal of the original)",
    "* If the same Diagnosis occurs but we have 2 separate \"basis of diagnosis\" values, then the first one will be taken only")]
internal class CosdV9HAConditionOccurrenceMorphologySnomedDiagnosis : OmopConditionOccurrence<CosdV9HAConditionOccurrenceMorphologySnomedDiagnosisRecord>
{
    [CopyValue(nameof(Source.NhsNumber))]
    public override string? nhs_number { get; set; }

    [Transform(typeof(DateConverter), nameof(Source.DateOfPrimaryDiagnosisClinicallyAgreed))]
    public override DateTime? condition_start_date { get; set; }

    [ConstantValue(32828, "`EHR episode record`")]
    public override int? condition_type_concept_id { get; set; }

    [Transform(typeof(SnomedSelector), nameof(Source.MorphologySnomedDiagnosis))]
    public override int? condition_source_concept_id { get; set; }

    [Transform(typeof(StandardConditionConceptSelector), useOmopTypeAsSource: true, nameof(condition_source_concept_id))]
    public override int[]? condition_concept_id { get; set; }

    [CopyValue(nameof(Source.MorphologySnomedDiagnosis))]
    public override string? condition_source_value { get; set; }
}
