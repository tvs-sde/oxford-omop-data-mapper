using OmopTransformer.Annotations;
using OmopTransformer.Omop.ProcedureOccurrence;
using OmopTransformer.Transformation;

namespace OmopTransformer.COSD.Lung.ProcedureOccurrence.CosdV8LungProcedureOccurrenceRelapseMethodOfDetection;

internal class CosdV8LungProcedureOccurrenceRelapseMethodOfDetection : OmopProcedureOccurrence<CosdV8LungProcedureOccurrenceRelapseMethodOfDetectionRecord>
{
    [CopyValue(nameof(Source.NhsNumber))]
    public override string? nhs_number { get; set; }

    [Transform(typeof(RelapseMethodOfDetectionLungLookup), nameof(Source.RelapseMethodDetectionType))]
    public override int[]? procedure_concept_id { get; set; }

    [CopyValue(nameof(Source.Date))]
    public override DateTime? procedure_date { get; set; }

    [CopyValue(nameof(Source.Date))]
    public override DateTime? procedure_datetime { get; set; }

    [ConstantValue(32828, "`EHR episode record`")]
    public override int? procedure_type_concept_id { get; set; }

    [CopyValue(nameof(Source.RelapseMethodDetectionType))]
    public override string? procedure_source_value { get; set; }
}
