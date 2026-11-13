using OmopTransformer.Annotations;
using OmopTransformer.Omop.DrugExposure;
using OmopTransformer.OxfordProcedures.ProcedureOccurrence;
using OmopTransformer.Transformation;

namespace OmopTransformer.OxfordProcedures.DrugExposure;

internal abstract class OxfordProceduresDrugExposure<T> : OmopDrugExposure<T>
    where T : OxfordProceduresRecord
{
    [CopyValue(nameof(Source.patient_identifier_value))]
    public override string? nhs_number { get; set; }

    [Transform(typeof(DateConverter), nameof(Source.clinical_date))]
    public override DateTime? drug_exposure_start_date { get; set; }

    [Transform(typeof(DateConverter), nameof(Source.clinical_datetime))]
    public override DateTime? drug_exposure_start_datetime { get; set; }

    [Description("Single-day exposure: the clinical date supplies the required end date; no duration is available.")]
    [Transform(typeof(DateConverter), nameof(Source.clinical_date))]
    public override DateTime? drug_exposure_end_date { get; set; }

    [ConstantValue(32817, "EHR")]
    public override int? drug_type_concept_id { get; set; }

    [Transform(typeof(StandardDrugConceptSelector), useOmopTypeAsSource: true, nameof(drug_source_concept_id))]
    public override int[]? drug_concept_id { get; set; }

    [CopyValue(nameof(Source.clinical_code))]
    public override string? drug_source_value { get; set; }
}
