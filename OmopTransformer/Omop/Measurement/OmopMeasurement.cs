namespace OmopTransformer.Omop.Measurement;

internal abstract class OmopMeasurement<T> : IOmopRecord<T>
{
    public virtual string? nhs_number { get; set; }
    public virtual int[]? measurement_concept_id { get; set; }
    public virtual DateTime? measurement_date { get; set; }
    public virtual DateTime? measurement_datetime { get; set; }
    public virtual DateTime? measurement_time { get; set; }
    public virtual int? measurement_type_concept_id { get; set; }
    public virtual int? operator_concept_id { get; set; }
    public virtual double? value_as_number { get; set; }
    public virtual int? value_as_concept_id { get; set; }
    public virtual int? unit_concept_id { get; set; }
    public virtual double? range_low { get; set; }
    public virtual double? range_high { get; set; }
    public virtual int? provider_id { get; set; }
    public virtual string? measurement_source_value { get; set; }
    public virtual int? measurement_source_concept_id { get; set; }
    public virtual string? unit_source_value { get; set; }
    public virtual int? unit_source_concept_id { get; set; }
    public virtual string? value_source_value { get; set; }
    public virtual int? value_as_source_concept_id { get; set; }
    public virtual int? measurement_event_id { get; set; }
    public virtual int? meas_event_field_concept_id { get; set; }
    public virtual string? HospitalProviderSpellNumber { get; set; }
    public virtual string? RecordConnectionIdentifier { get; set; }
    public string OmopTargetTypeDescription => "Measurement";
    public T? Source { get; set; }

    public virtual bool IsValid =>
        measurement_concept_id != null &&
        measurement_concept_id.Any() &&
        measurement_date.HasValue &&
        nhs_number != null &&
        measurement_type_concept_id != null;
}