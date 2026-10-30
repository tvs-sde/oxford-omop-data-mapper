using OmopTransformer.Annotations;
using OmopTransformer.Omop.Measurement;
using OmopTransformer.Transformation;

namespace OmopTransformer.COSD.LU.Measurement.COSDv8LungMeasurementSurgicalAccessType;

internal class COSDv8LungMeasurementSurgicalAccessType : OmopMeasurement<COSDv8LungMeasurementSurgicalAccessTypeRecord>
{
    [CopyValue(nameof(Source.NhsNumber))]
    public override string? nhs_number { get; set; }

    [CopyValue(nameof(Source.Date))]
    public override DateTime? measurement_date { get; set; }

    [CopyValue(nameof(Source.Date))]
    public override DateTime? measurement_datetime { get; set; }

    [ConstantValue(32828, "EHR episode record")]
    public override int? measurement_type_concept_id { get; set; }

    [CopyValue(nameof(Source.SurgicalAccessType))]
    public override string? measurement_source_value { get; set; }

    [ConstantValue(40762622, "Surgical approach at facility.YYY 2010 Cancer")]
    public override int[]? measurement_concept_id { get; set; }

    [Transform(typeof(SurgicalAccessTypeLungLookup), nameof(Source.SurgicalAccessType))]
    public override int? value_as_concept_id { get; set; }

    [CopyValue(nameof(Source.SurgicalAccessType))]
    public override string? value_source_value { get; set; }
}
