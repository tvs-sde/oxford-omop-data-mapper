using OmopTransformer.Annotations;
using OmopTransformer.Omop.ProcedureOccurrence;
using OmopTransformer.Transformation;

namespace OmopTransformer.COSD.Lung.ProcedureOccurrence.CosdV9LungProcedureOccurrenceRelapseMethodOfDetection;

internal class CosdV9LungProcedureOccurrenceRelapseMethodOfDetection : OmopProcedureOccurrence<CosdV9LungProcedureOccurrenceRelapseMethodOfDetectionRecord>
{
    [CopyValue(nameof(Source.NhsNumber))]
    public override string? nhs_number { get; set; }

    [Transform(typeof(RelapseMethodOfDetectionLungLookup), nameof(Source.RelapseMethodOfDetection))]
    public override int[]? procedure_concept_id { get; set; }

    [CopyValue(nameof(Source.Date))]
    public override DateTime? procedure_date { get; set; }

    [CopyValue(nameof(Source.Date))]
    public override DateTime? procedure_datetime { get; set; }

    [ConstantValue(32828, "`EHR episode record`")]
    public override int? procedure_type_concept_id { get; set; }

    [CopyValue(nameof(Source.RelapseMethodOfDetection))]
    public override string? procedure_source_value { get; set; }
}
