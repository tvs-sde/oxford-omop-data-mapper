using OmopTransformer.Annotations;
using OmopTransformer.Omop.Measurement;
using OmopTransformer.Transformation;

namespace OmopTransformer.COSD.SA.Measurement.COSDv8SAMeasurementSarcomaTumourSiteSoftTissue;

internal class COSDv8SAMeasurementSarcomaTumourSiteSoftTissue : OmopMeasurement<COSDv8SAMeasurementSarcomaTumourSiteSoftTissueRecord>
{
    [CopyValue(nameof(Source.NhsNumber))]
    public override string? nhs_number { get; set; }

    [Transform(typeof(DateConverter), nameof(Source.ClinicalDateCancerDiagnosis))]
    public override DateTime? measurement_date { get; set; }

    [Transform(typeof(DateConverter), nameof(Source.ClinicalDateCancerDiagnosis))]
    public override DateTime? measurement_datetime { get; set; }

    [ConstantValue(32828, "EHR episode record")]
    public override int? measurement_type_concept_id { get; set; }

    [Transform(typeof(Opcs4Selector), nameof(Source.SarcomaTumourSiteSoftTissue))]
    public override int? measurement_source_concept_id { get; set; }

    [CopyValue(nameof(Source.SarcomaTumourSiteSoftTissue))]
    public override string? measurement_source_value { get; set; }

    [Transform(typeof(StandardMeasurementConceptSelector), useOmopTypeAsSource: true, nameof(measurement_source_concept_id))]
    public override int[]? measurement_concept_id { get; set; }
}
