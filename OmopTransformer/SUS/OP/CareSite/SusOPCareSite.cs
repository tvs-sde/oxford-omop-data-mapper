using OmopTransformer.Annotations;
using OmopTransformer.Omop.CareSite;

namespace OmopTransformer.SUS.OP.CareSite;

internal class SusOPCareSite : OmopCareSite<SusOPCareSiteRecord>
{
    [CopyValue(nameof(Source.SiteCodeofTreatment))]
    public override string? care_site_name { get; set; }

    [CopyValue(nameof(Source.MainSpecialtyCode))]
    public override string? place_of_service_source_value { get; set; }

    [ConstantValue(38004515, "`Inpatient Hospital`")]
    public override int? place_of_service_concept_id { get; set; }
}