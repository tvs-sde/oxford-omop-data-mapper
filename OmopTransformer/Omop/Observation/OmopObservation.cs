namespace OmopTransformer.Omop.Observation;

internal abstract class OmopObservation<T> : IOmopRecord<T>
{
    public virtual string? nhs_number { get; set; }
    public virtual string? RecordConnectionIdentifier { get; set; }
    public virtual string? HospitalProviderSpellNumber { get; set; }
    public virtual int[]? observation_concept_id { get; set; }
    public virtual DateOnly? observation_date { get; set; }
    public virtual DateTime? observation_datetime { get; set; }
    public virtual int? observation_type_concept_id { get; set; }
    public virtual double? value_as_number { get; set; }
    public virtual string? value_as_string { get; set; }
    public virtual int? value_as_concept_id { get; set; }
    public virtual DateOnly? value_as_date { get; set; }
    public virtual int? qualifier_concept_id { get; set; }
    public virtual int? unit_concept_id { get; set; }
    public virtual int? provider_id { get; set; }
    public virtual string? observation_source_value { get; set; }
    public virtual int? observation_source_concept_id { get; set; }
    public virtual string? unit_source_value { get; set; }
    public virtual int? unit_source_concept_id { get; set; }
    public virtual string? qualifier_source_value { get; set; }
    public virtual string? value_source_value { get; set; }
    public virtual int? value_as_source_concept_id { get; set; }
    public virtual int? observation_event_id { get; set; }
    public virtual int? obs_event_field_concept_id { get; set; }
    public string OmopTargetTypeDescription => "Observation";
    public T? Source { get; set; }

    public virtual bool IsValid =>
        observation_concept_id != null &&
        observation_concept_id.Any() &&
        observation_date.HasValue &&
        nhs_number != null &&
        observation_type_concept_id != null;
}