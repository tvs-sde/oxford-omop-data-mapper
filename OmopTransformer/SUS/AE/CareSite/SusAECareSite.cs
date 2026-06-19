using OmopTransformer.Annotations;
using OmopTransformer.Omop.CareSite;

namespace OmopTransformer.SUS.AE.CareSite;

internal class SusAECareSite : OmopCareSite<SusAECareSiteRecord>
{
    [CopyValue(nameof(Source.SiteCodeOfTreatment))]
    public override string? care_site_name { get; set; }

    [ConstantValue(8870, "`Emergency Room - Hospital`")]
    public override int? place_of_service_concept_id { get; set; }
}

