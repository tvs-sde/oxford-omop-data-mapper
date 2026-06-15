using OmopTransformer.Annotations;
using OmopTransformer.Omop.Measurement;
using OmopTransformer.Transformation;

namespace OmopTransformer.COSD.CT.Measurement.COSDv8CTMeasurementLactateDehydrogenaseLevelPeakAtDiagnosis;

internal class COSDv8CTMeasurementLactateDehydrogenaseLevelPeakAtDiagnosis : OmopMeasurement<COSDv8CTMeasurementLactateDehydrogenaseLevelPeakAtDiagnosisRecord>
{
    [CopyValue(nameof(Source.NhsNumber))]
    public override string? nhs_number { get; set; }

    [Transform(typeof(DateConverter), nameof(Source.MeasurementDate))]
    public override DateTime? measurement_date { get; set; }

    [Transform(typeof(DateConverter), nameof(Source.MeasurementDate))]
    public override DateTime? measurement_datetime { get; set; }

    [ConstantValue(32828, "EHR episode record")]
    public override int? measurement_type_concept_id { get; set; }

    [CopyValue(nameof(Source.LactateDehydrogenaseLevelPeakAtDiagnosis))]
    public override string? measurement_source_value { get; set; }

    [ConstantValue(4012918, "Lactate dehydrogenase measurement")]
    public override int[]? measurement_concept_id { get; set; }

    [Transform(typeof(DoubleParser), nameof(Source.LactateDehydrogenaseLevelPeakAtDiagnosis))]
    public override double? value_as_number { get; set; }

    [ConstantValue("U/L", "Units per litre")]
    public override string? unit_source_value { get; set; }
    
    [ConstantValue(4012918, "Lactate dehydrogenase measurement")]   
    public override int? measurement_source_concept_id { get; set; }
}
