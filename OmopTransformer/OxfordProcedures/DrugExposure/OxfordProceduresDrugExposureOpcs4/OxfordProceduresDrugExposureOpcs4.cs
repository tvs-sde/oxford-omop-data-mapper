using OmopTransformer.Annotations;

namespace OmopTransformer.OxfordProcedures.DrugExposure.OxfordProceduresDrugExposureOpcs4;

internal class OxfordProceduresDrugExposureOpcs4 : OxfordProceduresDrugExposure<OxfordProceduresDrugExposureOpcs4Record>
{
    [Transform(typeof(Opcs4Selector), nameof(Source.concept_code))]
    public override int? drug_source_concept_id { get; set; }
}
