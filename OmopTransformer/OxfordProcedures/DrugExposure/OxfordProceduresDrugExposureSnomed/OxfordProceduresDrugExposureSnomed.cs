using OmopTransformer.Annotations;

namespace OmopTransformer.OxfordProcedures.DrugExposure.OxfordProceduresDrugExposureSnomed;

internal class OxfordProceduresDrugExposureSnomed : OxfordProceduresDrugExposure<OxfordProceduresDrugExposureSnomedRecord>
{
    [Transform(typeof(SnomedSelector), nameof(Source.concept_code))]
    public override int? drug_source_concept_id { get; set; }
}
