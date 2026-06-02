using OmopTransformer.Annotations;
using OmopTransformer.Omop.Measurement;
using OmopTransformer.Transformation;

namespace OmopTransformer.COSD.UG.Measurement.COSDv9UGMeasurementNonPrimaryPathwayRecurrenceMetastaticSite;

internal class COSDv9UGMeasurementNonPrimaryPathwayRecurrenceMetastaticSite : OmopMeasurement<COSDv9UGMeasurementNonPrimaryPathwayRecurrenceMetastaticSiteRecord>
{
    [CopyValue(nameof(Source.NhsNumber))]
    public override string? nhs_number { get; set; }

    [Transform(typeof(DateConverter), nameof(Source.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed))]
    public override DateTime? measurement_date { get; set; }

    [Transform(typeof(DateConverter), nameof(Source.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed))]
    public override DateTime? measurement_datetime { get; set; }

    [ConstantValue(32828, "EHR episode record")]
    public override int? measurement_type_concept_id { get; set; }

    [CopyValue(nameof(Source.MetastaticSite))]
    public override string? measurement_source_value { get; set; }

    [Transform(typeof(MetastasisSiteLookup), nameof(Source.MetastaticSite))]
    public override int[]? measurement_concept_id { get; set; }

    [ConstantValue(2000500008, "NonPrimaryPathwayRecurrenceMetastasis")]
    public override int? measurement_source_concept_id { get; set; }
}
