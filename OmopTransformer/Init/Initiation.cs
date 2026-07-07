using System.Data;
using Dapper;
using DuckDB.NET.Data;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace OmopTransformer.Init;

internal class Initiation : IInitiation
{
    private readonly Configuration _configuration;
    private readonly ILogger<Initiation> _logger;

    public Initiation(IOptions<Configuration> configuration, ILogger<Initiation> logger)
    {
        _logger = logger;
        _configuration = configuration.Value;
    }


    public async Task Initiate(CancellationToken cancellationToken)
    {
        var connection = new DuckDBConnection(_configuration.ConnectionString!);
        await connection.OpenAsync(cancellationToken);

        using IDbTransaction transaction = connection.BeginTransaction();
        try
        {
            _logger.LogInformation("Adding OMOP tables.");

            await connection.ExecuteAsync(@"
create sequence sequence_care_site_id start 1;
create sequence sequence_condition_occurrence_id start 1;
create sequence sequence_device_exposure_id start 1;
create sequence sequence_drug_exposure_id start 1;
create sequence sequence_episode_id start 1;
create sequence sequence_location_id start 1;
create sequence sequence_measurement_id start 1;
create sequence sequence_observation_id start 1;
create sequence sequence_person_id start 1;
create sequence sequence_procedure_occurrence_id start 1;
create sequence sequence_provider_id start 1;
create sequence sequence_visit_detail_id start 1;
create sequence sequence_visit_occurrence_id start 1;

create schema dbo;
create schema cdm;
create schema omop_staging;

CREATE TABLE cdm.care_site (
	care_site_id integer NOT NULL default nextval('sequence_care_site_id'),
	care_site_name varchar(255) NULL,
	place_of_service_concept_id integer NULL,
	location_id integer NULL,
	care_site_source_value varchar(50) NULL,
	place_of_service_source_value varchar(50) NULL,
	data_source varchar(100) NOT NULL
);

CREATE TABLE cdm.cdm_source(
	cdm_source_name varchar(255) NOT NULL,
	cdm_source_abbreviation varchar(25) NOT NULL,
	cdm_holder varchar(255) NOT NULL,
	source_description varchar(1000) NULL,
	source_documentation_reference varchar(255) NULL,
	cdm_etl_reference varchar(255) NULL,
	source_release_date date NOT NULL,
	cdm_release_date date NOT NULL,
	cdm_version varchar(10) NULL,
	cdm_version_concept_id integer NOT NULL,
	vocabulary_version varchar(20) NOT NULL
); 

CREATE TABLE cdm.cohort(
	cohort_definition_id integer NOT NULL,
	subject_id integer NOT NULL,
	cohort_start_date date NOT NULL,
	cohort_end_date date NOT NULL
);

CREATE TABLE cdm.cohort_definition(
	cohort_definition_id integer NOT NULL,
	cohort_definition_name varchar(255) NOT NULL,
	cohort_definition_description varchar(1000) NULL,
	definition_type_concept_id integer NOT NULL,
	cohort_definition_syntax varchar(1000) NULL,
	subject_concept_id integer NOT NULL,
	cohort_initiation_date date NULL
); 

CREATE TABLE cdm.concept(
	concept_id integer NOT NULL,
	concept_name nvarchar(1000) NOT NULL,
	domain_id varchar(20) NOT NULL,
	vocabulary_id varchar(20) NOT NULL,
	concept_class_id varchar(20) NOT NULL,
	standard_concept varchar(1) NULL,
	concept_code varchar(50) NOT NULL,
	valid_start_date date NOT NULL,
	valid_end_date date NOT NULL,
	invalid_reason varchar(1) NULL
);

CREATE TABLE cdm.concept_ancestor(
	ancestor_concept_id integer NOT NULL,
	descendant_concept_id integer NOT NULL,
	min_levels_of_separation integer NOT NULL,
	max_levels_of_separation integer NOT NULL
);

CREATE TABLE cdm.concept_class(
	concept_class_id varchar(20) NOT NULL,
	concept_class_name varchar(255) NOT NULL,
	concept_class_concept_id integer NOT NULL
);

CREATE TABLE cdm.concept_relationship(
	concept_id_1 integer NOT NULL,
	concept_id_2 integer NOT NULL,
	relationship_id varchar(20) NOT NULL,
	valid_start_date date NOT NULL,
	valid_end_date date NOT NULL,
	invalid_reason varchar(1) NULL
);

CREATE TABLE cdm.concept_synonym(
	concept_id integer NOT NULL,
	concept_synonym_name nvarchar(1000) NOT NULL,
	language_concept_id integer NOT NULL
);

CREATE TABLE cdm.condition_era(
	condition_era_id integer NOT NULL,
	person_id integer NOT NULL,
	condition_concept_id integer NOT NULL,
	condition_era_start_date date NOT NULL,
	condition_era_end_date date NOT NULL,
	condition_occurrence_count integer NULL
);

CREATE TABLE cdm.condition_occurrence(
	condition_occurrence_id integer NOT NULL default nextval('sequence_condition_occurrence_id'),
	person_id integer NOT NULL,
	condition_concept_id integer NOT NULL,
	condition_start_date date NOT NULL,
	condition_start_datetime datetime NULL,
	condition_end_date date NULL,
	condition_end_datetime datetime NULL,
	condition_type_concept_id integer NOT NULL,
	condition_status_concept_id integer NULL,
	stop_reason varchar(20) NULL,
	provider_id integer NULL,
	visit_occurrence_id integer NULL,
	visit_detail_id integer NULL,
	condition_source_value varchar(50) NULL,
	condition_source_concept_id integer NULL,
	condition_status_source_value varchar(50) NULL,
	RecordConnectionIdentifier varchar(50) NULL,
	data_source varchar(100) NOT NULL
);

CREATE TABLE cdm.cost(
	cost_id integer NOT NULL,
	cost_event_id integer NOT NULL,
	cost_domain_id varchar(20) NOT NULL,
	cost_type_concept_id integer NOT NULL,
	currency_concept_id integer NULL,
	total_charge float NULL,
	total_cost float NULL,
	total_paid float NULL,
	paid_by_payer float NULL,
	paid_by_patient float NULL,
	paid_patient_copay float NULL,
	paid_patient_coinsurance float NULL,
	paid_patient_deductible float NULL,
	paid_by_primary float NULL,
	paid_ingredient_cost float NULL,
	paid_dispensing_fee float NULL,
	payer_plan_period_id integer NULL,
	amount_allowed float NULL,
	revenue_code_concept_id integer NULL,
	revenue_code_source_value varchar(50) NULL,
	drg_concept_id integer NULL,
	drg_source_value varchar(3) NULL
);

CREATE TABLE cdm.death(
	person_id integer NOT NULL,
	death_date date NOT NULL,
	death_datetime datetime NULL,
	death_type_concept_id integer NULL,
	cause_concept_id integer NULL,
	cause_source_value varchar(50) NULL,
	cause_source_concept_id integer NULL,
	data_source varchar(100) NOT NULL
);

CREATE TABLE cdm.device_exposure(
	device_exposure_id integer NOT NULL default nextval('sequence_device_exposure_id'),
	person_id integer NOT NULL,
	device_concept_id integer NOT NULL,
	device_exposure_start_date date NOT NULL,
	device_exposure_start_datetime datetime NULL,
	device_exposure_end_date date NULL,
	device_exposure_end_datetime datetime NULL,
	device_type_concept_id integer NOT NULL,
	unique_device_id varchar(255) NULL,
	production_id varchar(255) NULL,
	quantity integer NULL,
	provider_id integer NULL,
	visit_occurrence_id integer NULL,
	visit_detail_id integer NULL,
	device_source_value varchar(50) NULL,
	device_source_concept_id integer NULL,
	unit_concept_id integer NULL,
	unit_source_value varchar(50) NULL,
	unit_source_concept_id integer NULL,
	RecordConnectionIdentifier varchar(50) NULL,
	HospitalProviderSpellNumber varchar(100) NULL,
	data_source varchar(100) NOT NULL
);

CREATE TABLE cdm.domain(
	domain_id varchar(20) NOT NULL,
	domain_name varchar(255) NOT NULL,
	domain_concept_id integer NOT NULL
);

CREATE TABLE cdm.dose_era(
	dose_era_id integer NOT NULL,
	person_id integer NOT NULL,
	drug_concept_id integer NOT NULL,
	unit_concept_id integer NOT NULL,
	dose_value float NOT NULL,
	dose_era_start_date date NOT NULL,
	dose_era_end_date date NOT NULL
);

CREATE TABLE cdm.drug_era(
	drug_era_id integer NOT NULL,
	person_id integer NOT NULL,
	drug_concept_id integer NOT NULL,
	drug_era_start_date date NOT NULL,
	drug_era_end_date date NOT NULL,
	drug_exposure_count integer NULL,
	gap_days integer NULL
);

CREATE TABLE cdm.drug_exposure(
	drug_exposure_id integer NOT NULL default nextval('sequence_drug_exposure_id'),
	person_id integer NOT NULL,
	drug_concept_id integer NOT NULL,
	drug_exposure_start_date date NOT NULL,
	drug_exposure_start_datetime datetime NULL,
	drug_exposure_end_date date NOT NULL,
	drug_exposure_end_datetime datetime NULL,
	verbatim_end_date date NULL,
	drug_type_concept_id integer NOT NULL,
	stop_reason varchar(20) NULL,
	refills integer NULL,
	quantity float NULL,
	days_supply integer NULL,
	sig varchar(1000) NULL,
	route_concept_id integer NULL,
	lot_number varchar(50) NULL,
	provider_id integer NULL,
	visit_occurrence_id integer NULL,
	visit_detail_id integer NULL,
	drug_source_value varchar(500) NULL,
	drug_source_concept_id integer NULL,
	route_source_value varchar(50) NULL,
	dose_unit_source_value varchar(50) NULL,
	RecordConnectionIdentifier varchar(50) NULL,
	data_source varchar(100) NOT NULL
);

CREATE TABLE cdm.drug_strength(
	drug_concept_id integer NOT NULL,
	ingredient_concept_id integer NOT NULL,
	amount_value float NULL,
	amount_unit_concept_id integer NULL,
	numerator_value float NULL,
	numerator_unit_concept_id integer NULL,
	denominator_value float NULL,
	denominator_unit_concept_id integer NULL,
	box_size integer NULL,
	valid_start_date date NOT NULL,
	valid_end_date date NOT NULL,
	invalid_reason varchar(1) NULL
);

CREATE TABLE cdm.episode(
	episode_id integer NOT NULL default nextval('sequence_episode_id'),
	person_id integer NOT NULL,
	episode_concept_id integer NOT NULL,
	episode_start_date date NOT NULL,
	episode_start_datetime datetime NULL,
	episode_end_date date NULL,
	episode_end_datetime datetime NULL,
	episode_parent_id integer NULL,
	episode_number integer NULL,
	episode_object_concept_id integer NOT NULL,
	episode_type_concept_id integer NOT NULL,
	episode_source_value varchar(50) NULL,
	episode_source_concept_id integer NULL
);

CREATE TABLE cdm.episode_event(
	episode_id integer NOT NULL,
	event_id integer NOT NULL,
	episode_event_field_concept_id integer NOT NULL
);

CREATE TABLE cdm.fact_relationship(
	domain_concept_id_1 integer NOT NULL,
	fact_id_1 integer NOT NULL,
	domain_concept_id_2 integer NOT NULL,
	fact_id_2 integer NOT NULL,
	relationship_concept_id integer NOT NULL
);

CREATE TABLE cdm.location(
	location_id integer NOT NULL default nextval('sequence_location_id'),
	address_1 varchar(255) NULL,
	address_2 varchar(255) NULL,
	city varchar(255) NULL,
	state varchar(2) NULL,
	zip varchar(9) NULL,
	county varchar(255) NULL,
	location_source_value varchar(255) NULL,
	country_concept_id integer NULL,
	country_source_value varchar(80) NULL,
	latitude float NULL,
	longitude float NULL,
	data_source varchar(100) NOT NULL
);

CREATE TABLE cdm.measurement(
	measurement_id integer NOT NULL default nextval('sequence_measurement_id'),
	person_id integer NOT NULL,
	measurement_concept_id integer NOT NULL,
	measurement_date date NOT NULL,
	measurement_datetime datetime NULL,
	measurement_time varchar(10) NULL,
	measurement_type_concept_id integer NOT NULL,
	operator_concept_id integer NULL,
	value_as_number float NULL,
	value_as_concept_id integer NULL,
	unit_concept_id integer NULL,
	range_low float NULL,
	range_high float NULL,
	provider_id integer NULL,
	visit_occurrence_id integer NULL,
	visit_detail_id integer NULL,
	measurement_source_value varchar(50) NULL,
	measurement_source_concept_id integer NULL,
	unit_source_value varchar(50) NULL,
	unit_source_concept_id integer NULL,
	value_source_value varchar(50) NULL,
	measurement_event_id integer NULL,
	meas_event_field_concept_id integer NULL,
	RecordConnectionIdentifier varchar(50) NULL,
	HospitalProviderSpellNumber varchar(100) NULL,
	data_source varchar(100) NOT NULL
);

CREATE TABLE cdm.metadata(
	metadata_id integer NOT NULL,
	metadata_concept_id integer NOT NULL,
	metadata_type_concept_id integer NOT NULL,
	name varchar(250) NOT NULL,
	value_as_string varchar(250) NULL,
	value_as_concept_id integer NULL,
	value_as_number float NULL,
	metadata_date date NULL,
	metadata_datetime datetime NULL
);

CREATE TABLE cdm.note(
	note_id integer NOT NULL,
	person_id integer NOT NULL,
	note_date date NOT NULL,
	note_datetime datetime NULL,
	note_type_concept_id integer NOT NULL,
	note_class_concept_id integer NOT NULL,
	note_title varchar(250) NULL,
	note_text varchar(1000) NOT NULL,
	encoding_concept_id integer NOT NULL,
	language_concept_id integer NOT NULL,
	provider_id integer NULL,
	visit_occurrence_id integer NULL,
	visit_detail_id integer NULL,
	note_source_value varchar(50) NULL,
	note_event_id integer NULL,
	note_event_field_concept_id integer NULL
); 

CREATE TABLE cdm.note_nlp(
	note_nlp_id integer NOT NULL,
	note_id integer NOT NULL,
	section_concept_id integer NULL,
	snippet varchar(250) NULL,
	""offset"" varchar(50) NULL,
	lexical_variant varchar(250) NOT NULL,
	note_nlp_concept_id integer NULL,
	note_nlp_source_concept_id integer NULL,
	nlp_system varchar(250) NULL,
	nlp_date date NOT NULL,
	nlp_datetime datetime NULL,
	term_exists varchar(1) NULL,
	term_temporal varchar(50) NULL,
	term_modifiers varchar(2000) NULL
);

CREATE TABLE cdm.observation(
	observation_id integer NOT NULL default nextval('sequence_observation_id'),
	person_id integer NOT NULL,
	observation_concept_id integer NOT NULL,
	observation_date date NOT NULL,
	observation_datetime datetime NULL,
	observation_type_concept_id integer NOT NULL,
	value_as_number float NULL,
	value_as_string varchar(60) NULL,
	value_as_concept_id integer NULL,
	qualifier_concept_id integer NULL,
	unit_concept_id integer NULL,
	provider_id integer NULL,
	visit_occurrence_id integer NULL,
	visit_detail_id integer NULL,
	observation_source_value varchar(50) NULL,
	observation_source_concept_id integer NULL,
	unit_source_value varchar(50) NULL,
	qualifier_source_value varchar(50) NULL,
	value_source_value varchar(50) NULL,
	observation_event_id integer NULL,
	obs_event_field_concept_id integer NULL,
	RecordConnectionIdentifier varchar(50) NULL,
	HospitalProviderSpellNumber varchar(100) NULL,
	data_source varchar(100) NOT NULL
);

CREATE TABLE cdm.observation_period(
	observation_period_id integer NULL,
	person_id integer NOT NULL,
	observation_period_start_date date NULL,
	observation_period_end_date date NULL,
	period_type_concept_id integer NOT NULL
);

CREATE TABLE cdm.payer_plan_period(
	payer_plan_period_id integer NOT NULL,
	person_id integer NOT NULL,
	payer_plan_period_start_date date NOT NULL,
	payer_plan_period_end_date date NOT NULL,
	payer_concept_id integer NULL,
	payer_source_value varchar(50) NULL,
	payer_source_concept_id integer NULL,
	plan_concept_id integer NULL,
	plan_source_value varchar(50) NULL,
	plan_source_concept_id integer NULL,
	sponsor_concept_id integer NULL,
	sponsor_source_value varchar(50) NULL,
	sponsor_source_concept_id integer NULL,
	family_source_value varchar(50) NULL,
	stop_reason_concept_id integer NULL,
	stop_reason_source_value varchar(50) NULL,
	stop_reason_source_concept_id integer NULL
);

CREATE TABLE cdm.person(
	person_id integer NOT NULL default nextval('sequence_person_id'),
	gender_concept_id integer NULL,
	year_of_birth integer NULL,
	month_of_birth integer NULL,
	day_of_birth integer NULL,
	birth_datetime datetime NULL,
	race_concept_id integer NULL,
	ethnicity_concept_id integer NULL,
	location_id integer NULL,
	provider_id integer NULL,
	care_site_id integer NULL,
	person_source_value varchar(50) NOT NULL,
	gender_source_value varchar(50) NULL,
	gender_source_concept_id integer NULL,
	race_source_value varchar(50) NULL,
	race_source_concept_id integer NULL,
	ethnicity_source_value varchar(50) NULL,
	ethnicity_source_concept_id integer NULL,
	data_source varchar(100) NOT NULL
);

CREATE TABLE cdm.procedure_occurrence(
	procedure_occurrence_id integer NOT NULL default nextval('sequence_procedure_occurrence_id'),
	person_id integer NOT NULL,
	procedure_concept_id integer NOT NULL,
	procedure_date date NOT NULL,
	procedure_datetime datetime NULL,
	procedure_end_date date NULL,
	procedure_end_datetime datetime NULL,
	procedure_type_concept_id integer NOT NULL,
	modifier_concept_id integer NULL,
	quantity integer NULL,
	provider_id integer NULL,
	visit_occurrence_id integer NULL,
	visit_detail_id integer NULL,
	procedure_source_value varchar(50) NULL,
	procedure_source_concept_id integer NULL,
	modifier_source_value varchar(50) NULL,
	RecordConnectionIdentifier varchar(50) NULL,
	data_source varchar(100) NOT NULL
);

CREATE TABLE cdm.provider(
	provider_id integer NOT NULL default nextval('sequence_provider_id'),
	provider_name varchar(255) NULL,
	npi varchar(20) NULL,
	dea varchar(20) NULL,
	specialty_concept_id integer NULL,
	care_site_id integer NULL,
	year_of_birth integer NULL,
	gender_concept_id integer NULL,
	provider_source_value varchar(50) NULL,
	specialty_source_value varchar(50) NULL,
	specialty_source_concept_id integer NULL,
	gender_source_value varchar(50) NULL,
	gender_source_concept_id integer NULL,
	data_source varchar(100) NOT NULL
);

CREATE TABLE cdm.relationship(
	relationship_id varchar(20) NOT NULL,
	relationship_name varchar(255) NOT NULL,
	is_hierarchical varchar(1) NOT NULL,
	defines_ancestry varchar(1) NOT NULL,
	reverse_relationship_id varchar(20) NOT NULL,
	relationship_concept_id integer NOT NULL
);

CREATE TABLE cdm.source_to_concept_map(
	source_code varchar(50) NOT NULL,
	source_concept_id integer NOT NULL,
	source_vocabulary_id varchar(20) NOT NULL,
	source_code_description varchar(255) NULL,
	target_concept_id integer NOT NULL,
	target_vocabulary_id varchar(20) NOT NULL,
	valid_start_date date NOT NULL,
	valid_end_date date NOT NULL,
	invalid_reason varchar(1) NULL
);

CREATE TABLE cdm.specimen(
	specimen_id integer NOT NULL,
	person_id integer NOT NULL,
	specimen_concept_id integer NOT NULL,
	specimen_type_concept_id integer NOT NULL,
	specimen_date date NOT NULL,
	specimen_datetime datetime NULL,
	quantity float NULL,
	unit_concept_id integer NULL,
	anatomic_site_concept_id integer NULL,
	disease_status_concept_id integer NULL,
	specimen_source_id varchar(50) NULL,
	specimen_source_value varchar(50) NULL,
	unit_source_value varchar(50) NULL,
	anatomic_site_source_value varchar(50) NULL,
	disease_status_source_value varchar(50) NULL
);

CREATE TABLE cdm.visit_detail(
	visit_detail_id integer NOT NULL default nextval('sequence_visit_detail_id'),
	person_id integer NOT NULL,
	visit_detail_concept_id integer NOT NULL,
	visit_detail_start_date date NOT NULL,
	visit_detail_start_datetime datetime NULL,
	visit_detail_end_date date NOT NULL,
	visit_detail_end_datetime datetime NULL,
	visit_detail_type_concept_id integer NOT NULL,
	provider_id integer NULL,
	care_site_id integer NULL,
	visit_detail_source_value varchar(50) NULL,
	visit_detail_source_concept_id integer NULL,
	admitted_from_concept_id integer NULL,
	admitted_from_source_value varchar(50) NULL,
	discharged_to_source_value varchar(50) NULL,
	discharged_to_concept_id integer NULL,
	preceding_visit_detail_id integer NULL,
	parent_visit_detail_id integer NULL,
	visit_occurrence_id integer NOT NULL,
	RecordConnectionIdentifier varchar(50) NULL,
	HospitalProviderSpellNumber varchar(100) NULL,
	data_source varchar(100) NOT NULL
);

CREATE TABLE cdm.visit_occurrence(
	visit_occurrence_id integer NOT NULL default nextval('sequence_visit_occurrence_id'),
	person_id integer NOT NULL,
	visit_concept_id integer NOT NULL,
	visit_start_date date NOT NULL,
	visit_start_datetime datetime NULL,
	visit_end_date date NOT NULL,
	visit_end_datetime datetime NULL,
	visit_type_concept_id integer NOT NULL,
	provider_id integer NULL,
	care_site_id integer NULL,
	visit_source_value varchar(50) NULL,
	visit_source_concept_id integer NULL,
	admitted_from_concept_id integer NULL,
	admitted_from_source_value varchar(50) NULL,
	discharged_to_concept_id integer NULL,
	discharged_to_source_value varchar(50) NULL,
	preceding_visit_occurrence_id integer NULL,
	RecordConnectionIdentifier varchar(50) NULL,
	HospitalProviderSpellNumber varchar(100) NULL,
	data_source varchar(100) NOT NULL
);

CREATE TABLE cdm.vocabulary(
	vocabulary_id varchar(20) NOT NULL,
	vocabulary_name varchar(255) NOT NULL,
	vocabulary_reference varchar(255) NULL,
	vocabulary_version varchar(255) NULL,
	vocabulary_concept_id integer NOT NULL
);


CREATE TABLE dbo.run_analysis(
	run_id uuid NOT NULL,
	datetime_utc datetime NOT NULL,
	table_type varchar(100) NOT NULL,
	origin varchar(100) NOT NULL,
	valid_count integer NOT NULL,
	invalid_count integer NOT NULL
);

CREATE TABLE omop_staging.concept_code_map(
	source_concept_code varchar(50) NOT NULL,
	source_concept_id integer NOT NULL,
	target_concept_id integer NULL,
    source_domain_id varchar(50) NOT NULL,
	target_domain_id varchar(50) NULL,
	mapped_from_standard tinyint NOT NULL
);


CREATE TABLE omop_staging.cosd_staging_81(
	SubmissionName varchar(200) NOT NULL,
	FileName varchar(200) NOT NULL,
    Type varchar(5) not null,
	Record json NOT NULL
);

CREATE TABLE omop_staging.cosd_staging_901(
	SubmissionName varchar(200) NOT NULL,
	FileName varchar(200) NOT NULL,
    Type varchar(5) not null,
	Record json NOT NULL
);

CREATE TABLE omop_staging.oxford_gp_appointment(
	GPAppointmentsPrimaryKey varchar(1000) NULL,
	PatientIdentifier varchar(20) NOT NULL,
	AppointmentDate varchar(1000) NULL,
	AppointmentStatus varchar(1000) NULL,
	AppointmentBookedDate varchar(1000) NULL,
	ClinicianCode varchar(1000) NULL,
	AppointmentCancelledDate varchar(1000) NULL,
	OrganisationName varchar(1000) NULL,
	SourceName varchar(1000) NULL,
	StatusDescription varchar(1000) NULL,
	DNAFlag varchar(1000) NULL,
	OrganisationNationalCode varchar(1000) NULL,
	ClinicianType varchar(1000) NULL,
	OrganisationIdentifier varchar(1000) NULL,
	Location varchar(1000) NULL,
	LocationType varchar(1000) NULL,
	Specialty varchar(1000) NULL,
	ClinicName varchar(1000) NULL,
	BookingSource varchar(1000) NULL,
	BookingMethod varchar(1000) NULL,
	PatientArrivedDateTime varchar(1000) NULL,
	PatientSeenDateTime varchar(1000) NULL,
	DeliveryMethodText varchar(1000) NULL,
	PlannedMinutesDuration varchar(1000) NULL,
	ActualMinutesDuration varchar(1000) NULL,
	NationalSlotDesc varchar(1000) NULL,
	NationalSlotName varchar(1000) NULL,
	NationalContext varchar(1000) NULL,
	NationalService varchar(1000) NULL,
	UrgentFlag varchar(1000) NULL,
	FollowUp varchar(1000) NULL,
	ExternalPatient varchar(1000) NULL,
	ExternalPatientOrganisationIdentifierSystem varchar(1000) NULL,
	ExternalPatientOrganisationIdentifierValue varchar(1000) NULL,
	ExternalPatientOrganisationDisplay varchar(1000) NULL,
	CancellationReasonText varchar(1000) NULL,
	SessionIdentifierValue varchar(1000) NULL,
	ClinicianIdentifierValue varchar(1000) NULL,
	SlotEndDateTime varchar(1000) NULL
); 


CREATE TABLE omop_staging.oxford_gp_demographic(
	PatientIdentifier varchar(20) NOT NULL,
	NHSNumber varchar(1000) NULL,
	Forename varchar(1000) NULL,
	Surname varchar(1000) NULL,
	DOB varchar(1000) NULL,
	Postcode varchar(1000) NULL,
	DateofDeath varchar(1000) NULL
); 

CREATE TABLE omop_staging.oxford_gp_event(
	GPEventsPrimaryKey varchar(1000) NULL,
	PatientIdentifier varchar(20) NOT NULL,
	GeneralPractitionerCode varchar(1000) NULL,
	RegisteredGP varchar(1000) NULL,
	GPPracticeCode varchar(1000) NULL,
	EventDate varchar(1000) NULL,
	SuppliedCode varchar(1000) NULL,
	CodeSet varchar(1000) NULL,
	EventDescription varchar(1000) NULL,
	Episodicity varchar(1000) NULL,
	Units varchar(1000) NULL,
	Value varchar(1000) NULL,
	SensitivityDormant varchar(1000) NULL,
	EventNo varchar(1000) NULL,
	AlternateReadEMISCode varchar(1000) NULL,
	JournalUpdateFlag varchar(1000) NULL,
	UpdateKey varchar(1000) NULL,
	UniqueKey varchar(1000) NULL
); 

CREATE TABLE omop_staging.oxford_gp_medication(
	GPMedicationsPrimaryKey varchar(1000) NULL,
	PatientIdentifier varchar(20) NOT NULL,
	GeneralPracticeCode varchar(1000) NULL,
	RegisteredGP varchar(1000) NULL,
	GPPracticeCode varchar(1000) NULL,
	SuppliedCode varchar(1000) NULL,
	CodeSet varchar(1000) NULL,
	MedicationDescription varchar(1000) NULL,
	Quantity varchar(1000) NULL,
	Dosage varchar(1000) NULL,
	LastIssueDate varchar(1000) NULL,
	MixtureID varchar(1000) NULL,
	Constituent varchar(1000) NULL,
	Units varchar(1000) NULL,
	RepeatMedicationFlag varchar(1000) NULL,
	MedicationNo varchar(1000) NULL,
	MaxIssues varchar(1000) NULL,
	UpdateKey varchar(1000) NULL,
	UniqueKey varchar(1000) NULL,
	AuthorisingUserDisplay varchar(1000) NULL,
	CourseLengthPerIssue varchar(1000) NULL
); 

CREATE TABLE omop_staging.oxford_prescribing(
	patient_identifier_value varchar(1000) NULL,
	WAREHOUSE_IDENTIFIER varchar(1000) NULL,
	ORDER_ID varchar(1000) NULL,
	BEG_DT_TM varchar(1000) NULL,
	END_DT_TM varchar(1000) NULL,
	SCHEDULED_DT_TM varchar(1000) NULL,
	VERIFICATION_DT_TM varchar(1000) NULL,
	UPDT_DT_TM varchar(1000) NULL,
	CURRENT_START_DT_TM varchar(1000) NULL,
	PROJECTED_STOP_DT_TM varchar(1000) NULL,
	MED_ADMIN_EVENT_ID varchar(1000) NULL,
	EVENT_TYPE_DISPLAY varchar(1000) NULL,
	REFERENCESTARTDTTM varchar(1000) NULL,
	STRENGTHDOSE varchar(1000) NULL,
	DIFFINMIN varchar(1000) NULL,
	CONSTANTIND varchar(1000) NULL,
	RXPRIORITY varchar(1000) NULL,
	PHARMORDERTYPE varchar(1000) NULL,
	ADHOCFREQINSTANCE varchar(1000) NULL,
	FREQSCHEDID varchar(1000) NULL,
	WEIGHT varchar(1000) NULL,
	DRUGFORM varchar(1000) NULL,
	REQSTARTDTTM varchar(1000) NULL,
	STRENGTHDOSEUNIT varchar(1000) NULL,
	RXROUTE varchar(1000) NULL,
	CATALOG_CD varchar(1000) NULL,
	CATALOG varchar(1000) NULL,
	ORDER_MNEMONIC varchar(1000) NULL,
	ORDER_DETAIL_DISPLAY_LINE nvarchar(1000) NULL,
	DEPT_MISC_LINE varchar(1000) NULL,
	concept_identifier varchar(1000) NULL,
	concept_name varchar(1000) NULL,
	CONCEPT_CKI varchar(1000) NULL,
	cki varchar(1000) NULL,
	EVENT_ID varchar(1000) NULL
); 

CREATE TABLE omop_staging.RTDS_1_Demographics(
	SourceFileName varchar(100) NOT NULL,
	PatientSer varchar(255) NULL,
	PatientId varchar(255) NULL,
	PatientId2 varchar(255) NULL,
	UniversalPatientId varchar(255) NULL,
	SSN varchar(255) NULL,
	FirstName varchar(255) NULL,
	LastName varchar(255) NULL,
	DateOfBirth varchar(255) NULL,
	Sex varchar(255) NULL,
	DoctorId varchar(255) NULL,
	CourseSer varchar(255) NULL,
	Expression1 varchar(255) NULL,
	StartDateTime varchar(255) NULL,
	CompletedDateTime varchar(255) NULL,
	End_date varchar(255) NULL,
	Start_date varchar(255) NULL
);

CREATE TABLE omop_staging.RTDS_2a_Attendances(
	SourceFileName varchar(100) NOT NULL,
	ScheduledActivitySer varchar(255) NULL,
	ScheduledStartTime varchar(255) NULL,
	AttributeValue varchar(255) NULL,
	CourseSer varchar(255) NULL,
	ProcedureCode varchar(255) NULL,
	PatientSer varchar(255) NULL,
	ScheduledActivityCode varchar(255) NULL,
	Description varchar(255) NULL,
	ActualStartDateTime_s varchar(255) NULL,
	ActualEndDateTime_s varchar(255) NULL,
	Start_date varchar(255) NULL,
	End_date varchar(255) NULL
);

CREATE TABLE omop_staging.RTDS_2b_Plan(
	SourceFileName varchar(100) NOT NULL,
	ProcedureCode varchar(255) NULL,
	AttributeValue varchar(255) NULL,
	PatientSer varchar(255) NULL,
	DueDateTime varchar(255) NULL,
	NonScheduledActivityCode varchar(255) NULL,
	CourseSer varchar(255) NULL,
	NonScheduledActivitySer varchar(255) NULL,
	ActivityName varchar(255) NULL,
	Description varchar(255) NULL,
	Start_date varchar(255) NULL,
	End_date varchar(255) NULL,
	ProcedureCodeSer varchar(255) NULL
);

CREATE TABLE omop_staging.RTDS_3_Prescription(
	SourceFileName varchar(100) NOT NULL,
	PatientSer varchar(255) NULL,
	CourseSer varchar(255) NULL,
	TreatmentType varchar(255) NULL,
	NoFields varchar(255) NULL,
	PreDescribedDose varchar(255) NULL,
	PlanSetupSer varchar(255) NULL,
	StartDateTime varchar(255) NULL,
	TotDeliveredActualDose varchar(255) NULL,
	NoFracs varchar(255) NULL,
	PlanNameUpper varchar(255) NULL,
	Start_date varchar(255) NULL,
	End_date varchar(255) NULL,
	Expression1 varchar(255) NULL
);

CREATE TABLE omop_staging.RTDS_4_Exposures(
	SourceFileName varchar(100) NOT NULL,
	PatientSer varchar(255) NULL,
	CourseSer varchar(255) NULL,
	RadiationSer varchar(255) NULL,
	NominalEnergy varchar(255) NULL,
	RadiationType varchar(255) NULL,
	PlanSetupSer varchar(255) NULL,
	EventNumber varchar(255) NULL,
	MachineId varchar(255) NULL,
	PlanName varchar(255) NULL,
	Start_date varchar(255) NULL,
	End_date varchar(255) NULL,
	TreatmentDateTime varchar(255) NULL,
	storedprocedure_version varchar(255) NULL
);

CREATE TABLE omop_staging.RTDS_5_Diagnosis_Course(
	SourceFileName varchar(100) NOT NULL,
	PatientSer varchar(255) NULL,
	CourseSer varchar(255) NULL,
	DateStamp varchar(255) NULL,
	DiagnosisCode varchar(255) NULL,
	DiagnosisTableName varchar(255) NULL,
	DiagnosisType varchar(255) NULL,
	End_date varchar(255) NULL,
	Start_date varchar(255) NULL
);

CREATE TABLE omop_staging.RTDS_PASDATA(
	SourceFileName varchar(100) NOT NULL,
	Expr1 varchar(255) NULL,
	Expr2 varchar(255) NULL,
	Expr3 varchar(255) NULL,
	Expr4 varchar(255) NULL,
	Expr5 varchar(255) NULL,
	Expr6 varchar(255) NULL,
	PatientID2 varchar(255) NULL,
	FirstOfNHSNUMBER varchar(255) NULL,
	NHSNUMBERTRACESTATUS varchar(255) NULL,
	Expr7 varchar(255) NULL,
	Expr8 varchar(255) NULL,
	FirstOfPOSTCODE varchar(255) NULL,
	Expr9 varchar(255) NULL,
	BIRTHDATE varchar(255) NULL,
	GENDER varchar(255) NULL,
	Expr10 varchar(255) NULL,
	Expr11 varchar(255) NULL,
	Expr12 varchar(255) NULL,
	Expr13 varchar(255) NULL,
	Expr14 varchar(255) NULL,
	FirstOfGPNATIONALCODE varchar(255) NULL,
	FirstOfPRACTICECODE varchar(255) NULL
);

CREATE TABLE omop_staging.sact_staging(
	NHS_Number nvarchar(255) NULL,
	Local_Patient_Identifier nvarchar(255) NULL,
	NHS_Number_Status_Indicator_Code nvarchar(255) NULL,
	Person_Family_Name nvarchar(255) NULL,
	Person_Given_Name nvarchar(255) NULL,
	Date_Of_Birth nvarchar(255) NULL,
	Person_Stated_Gender_Code nvarchar(255) NULL,
	Patient_Postcode nvarchar(255) NULL,
	Consultant_GMC_Code nvarchar(255) NULL,
	Consultant_Specialty_Code nvarchar(255) NULL,
	Organisation_Identifier_Code_Of_Provider nvarchar(255) NULL,
	Primary_Diagnosis nvarchar(255) NULL,
	Morphology_ICD_O nvarchar(255) NULL,
	Diagnosis_Code_SNOMED_CT nvarchar(255) NULL,
	Adjunctive_Therapy nvarchar(255) NULL,
	Intent_Of_Treatment nvarchar(255) NULL,
	Regimen nvarchar(255) NULL,
	Height_At_Start_Of_Regimen nvarchar(255) NULL,
	Weight_At_Start_Of_Regimen nvarchar(255) NULL,
	Performance_Status_At_Start_Of_Regimen_Adult nvarchar(255) NULL,
	Comorbidity_Adjustment nvarchar(255) NULL,
	Date_Decision_To_Treat nvarchar(255) NULL,
	Start_Date_Of_Regimen nvarchar(255) NULL,
	Clinical_Trial nvarchar(255) NULL,
	Cycle_Number nvarchar(255) NULL,
	Start_Date_Of_Cycle nvarchar(255) NULL,
	Weight_At_Start_Of_Cycle nvarchar(255) NULL,
	Performance_Status_At_Start_Of_Cycle_Adult nvarchar(255) NULL,
	Drug_Name nvarchar(255) NULL,
	DM_D nvarchar(255) NULL,
	Actual_Dose_Per_Administration nvarchar(255) NULL,
	Administration_Measurement_Per_Actual_Dose nvarchar(255) NULL,
	Other_Administration_Measurement_Per_Actual_Dose nvarchar(255) NULL,
	Unit_Of_Measurement_SNOMED_CT_DM_D nvarchar(255) NULL,
	SACT_Administration_Route nvarchar(255) NULL,
	Route_Of_Administration_SNOMED_CT_DM_D nvarchar(255) NULL,
	Administration_Date nvarchar(255) NULL,
	Organisation_Identifier_Of_SACT_Administration nvarchar(255) NULL,
	Regimen_Modification_Dose_Reduction nvarchar(255) NULL,
	Regimen_Outcome_Summary_Curative_Completed_As_Planned nvarchar(255) NULL,
	Regimen_Outcome_Summary_Curative_Not_Completed_As_Planned_Reason nvarchar(255) NULL,
	Other_Regimen_Outcome_Summary_Curative_Not_Completed_As_Planned_Reason nvarchar(255) NULL,
	Regimen_Outcome_Summary_Non_Curative nvarchar(255) NULL,
	Regimen_Outcome_Summary_Toxicity nvarchar(255) NULL
);

CREATE TABLE omop_staging.sus_AE(
	MessageId uuid NOT NULL,
	GeneratedRecordIdentifier varchar(1000) NULL,
	ReasonForAccess varchar(1000) NULL,
	CDStype varchar(1000) NULL,
	ProtocolIdentifier varchar(1000) NULL,
	UniqueCDSidentifier varchar(1000) NULL,
	UpdateType varchar(1000) NULL,
	BulkreplacementCDSgroup varchar(1000) NULL,
	TestIndicator varchar(1000) NULL,
	ApplicableDatetime varchar(1000) NULL,
	CensusDate varchar(1000) NULL,
	ExtractDatetime varchar(1000) NULL,
	ReportPeriodStartDate varchar(1000) NULL,
	ReportPeriodEndDate varchar(1000) NULL,
	OrganisationCodeSenderOfTransaction varchar(1000) NULL,
	OrganisationCodeTypeofSender varchar(1000) NULL,
	CDSInterchangeID varchar(1000) NULL,
	LocalPatientIdentifier varchar(1000) NULL,
	OrganisationCodeLocalPatientIdentifier varchar(1000) NULL,
	OrganisationCodeTypeLocalPatientIdentifier varchar(1000) NULL,
	NHSNumber varchar(1000) NULL,
	DateOfBirth varchar(1000) NULL,
	CarerSupportIndicator varchar(1000) NULL,
	NHSNumberTraceStatus varchar(1000) NULL,
	WithheldIdentityReason varchar(1000) NULL,
	Sex varchar(1000) NULL,
	NameFormatCode varchar(1000) NULL,
	PatientName varchar(1000) NULL,
	PersonTitle varchar(1000) NULL,
	PersonGivenName varchar(1000) NULL,
	PersonFamilyName varchar(1000) NULL,
	PersonNameSuffix varchar(1000) NULL,
	PersonInitials varchar(1000) NULL,
	AddressFormatCode varchar(1000) NULL,
	PatientUsualAddress varchar(1000) NULL,
	Postcode varchar(1000) NULL,
	OrganisationCodeResidenceResponsibility varchar(1000) NULL,
	PCTofResidence varchar(1000) NULL,
	OrganisationCodeTypePCTofResidence varchar(1000) NULL,
	EthnicCategory varchar(1000) NULL,
	OSVClassificationatCDSActivityDate varchar(1000) NULL,
	GeneralMedicalPractitionerCodeofRegisteredGMP varchar(1000) NULL,
	PracticeCodeofRegisteredGP varchar(1000) NULL,
	OrganisationCodeTypeofRegisteredGP varchar(1000) NULL,
	AEAttendanceNumber varchar(1000) NULL,
	AEArrivalMode varchar(1000) NULL,
	AEAttendanceCategory varchar(1000) NULL,
	AEAttendanceDisposal varchar(1000) NULL,
	AEIncidentLocationType varchar(1000) NULL,
	AEPatientGroup varchar(1000) NULL,
	SourceofReferralForAE varchar(1000) NULL,
	ArrivalDate varchar(1000) NULL,
	ArrivalTime varchar(1000) NULL,
	AEAttendanceConclusionTime varchar(1000) NULL,
	AEAttendanceConclusionDate varchar(1000) NULL,
	AEDepartureTime varchar(1000) NULL,
	AEDepartureDate varchar(1000) NULL,
	AEInitialAssessmentTimefirstandunplannedfollowupattendancesonly varchar(1000) NULL,
	AEInitialAssessmentDate varchar(1000) NULL,
	AETimeSeenForTreatment varchar(1000) NULL,
	SiteCodeOfTreatment varchar(1000) NULL,
	WaitingTimeMeasurementType varchar(1000) NULL,
	AmbulanceIncidentNumber varchar(1000) NULL,
	OrganisationCodeConveyingAmbulanceTrust varchar(1000) NULL,
	CommissioningSerialNumber varchar(1000) NULL,
	NHSServiceAgreementLineNumber varchar(1000) NULL,
	ProviderReferenceNumber varchar(1000) NULL,
	CommissionerReferenceNumber varchar(1000) NULL,
	OrganisationCodeCodeOfProvider varchar(1000) NULL,
	OrganisationCodeTypeOfProvider varchar(1000) NULL,
	OrganisationCodeCodeOfCommissioner varchar(1000) NULL,
	OrganisationCodeTypeOfCommissioner varchar(1000) NULL,
	AEStaffMemberCode varchar(1000) NULL,
	DiagnosisSchemeInUse varchar(1000) NULL,
	InvestigationSchemeInUse varchar(1000) NULL,
	TreatmentSchemeInUse varchar(1000) NULL,
	HRGCode varchar(1000) NULL,
	HRGVersionNumber varchar(1000) NULL,
	ProcedureSchemeInUse varchar(1000) NULL,
	DominantGroupingVariableProcedure varchar(1000) NULL,
	FCEHRG varchar(1000) NULL,
	SpellCOREHRGVersionNo varchar(1000) NULL,
	PBRGeneratedCoreHRGforInformation varchar(1000) NULL,
	PBRGeneratedCoreHRGVersionforInformation varchar(1000) NULL,
	UniqueBookingReferenceNumberConverted varchar(1000) NULL,
	PatientPathwayIdentifier varchar(1000) NULL,
	OrganisationCodePatientPathwayIdentifierIssuer varchar(1000) NULL,
	ReferralToTreatmentPeriodStatus varchar(1000) NULL,
	ReferralToTreatmentPeriodStartDate varchar(1000) NULL,
	ReferralToTreatmentPeriodEndDate varchar(1000) NULL,
	LeadCareActivityIndicator varchar(1000) NULL,
	AgeatCDSActivityDate varchar(1000) NULL,
	NHSServiceAgreementChangeDate varchar(1000) NULL,
	CDSActivityDate varchar(1000) NULL,
	AEDepartmentType varchar(1000) NULL,
	XMLVersion varchar(1000) NULL,
	ConfidentialityCategoryDerived varchar(1000) NULL,
	ReferralToTreatmentLengthDerived varchar(1000) NULL,
	AEAssessmentWaitTime varchar(1000) NULL,
	AEConclusionWaitTime varchar(1000) NULL,
	AEDuration varchar(1000) NULL,
	AETreatmentWait varchar(1000) NULL,
	AgerangepatientderivedfromDOB varchar(1000) NULL,
	AreaCodeDerivedFromPostcode varchar(1000) NULL,
	CDSGroup varchar(1000) NULL,
	FinishedIndicator varchar(1000) NULL,
	PCTDerivedfromGP varchar(1000) NULL,
	PCTTypeDerivedfromGP varchar(1000) NULL,
	GPPracticeDerived varchar(1000) NULL,
	PCTDerivedfromderivedGPPractice varchar(1000) NULL,
	SHAfromGPPractice varchar(1000) NULL,
	SHATypefromGPPractice varchar(1000) NULL,
	MonthOfBirth varchar(1000) NULL,
	ElectoralWardFromPostcode varchar(1000) NULL,
	PCTfrompostcode varchar(1000) NULL,
	PCTTypefromPostcode varchar(1000) NULL,
	SHAfromPostcode varchar(1000) NULL,
	SHATypefromPostcode varchar(1000) NULL,
	AreaCodeFromProviderPostcode varchar(1000) NULL,
	AgeAtEndOfEpisode varchar(1000) NULL,
	AgeAtStartOfEpisode varchar(1000) NULL,
	YearOfBirth varchar(1000) NULL,
	CensusArea varchar(1000) NULL,
	Country varchar(1000) NULL,
	CountyCode varchar(1000) NULL,
	CensusED varchar(1000) NULL,
	EDDistrictCode varchar(1000) NULL,
	ElectoralWardCode varchar(1000) NULL,
	GORCode varchar(1000) NULL,
	LocalUnitaryAuthority varchar(1000) NULL,
	OldSHACode varchar(1000) NULL,
	ElectoralArea varchar(1000) NULL,
	PrimeRecipient varchar(1000) NULL,
	CopyRecipients varchar(1000) NULL
); 

CREATE TABLE omop_staging.sus_AE_diagnosis(
	MessageId uuid NOT NULL,
	AccidentAndEmergencyDiagnosis varchar(1000) NOT NULL
); 

CREATE TABLE omop_staging.sus_AE_investigation(
	MessageId uuid NOT NULL,
	AccidentAndEmergencyInvestigation varchar(1000) NOT NULL
); 

CREATE TABLE omop_staging.sus_AE_treatment(
	MessageId uuid NOT NULL,
	AccidentAndEmergencyTreatment varchar(1000) NOT NULL
); 

CREATE TABLE omop_staging.sus_APC(
	MessageId uuid NOT NULL,
	GeneratedRecordIdentifier varchar(500) NULL,
	PBRSpellID varchar(500) NULL,
	ReasonForAccess varchar(500) NULL,
	CDSType varchar(500) NULL,
	ProtocolIdentifier varchar(500) NULL,
	UniqueCDSIdentifier varchar(500) NULL,
	UpdateType varchar(500) NULL,
	BulkReplacementCDSGroup varchar(500) NULL,
	TestIndicator varchar(500) NULL,
	ApplicableDatetime varchar(500) NULL,
	CensusDate varchar(500) NULL,
	ExtractDatetime varchar(500) NULL,
	ReportPeriodStartDate varchar(500) NULL,
	ReportPeriodEndDate varchar(500) NULL,
	OrganisationCodeSenderOfTransaction varchar(500) NULL,
	OrganisationCodeTypeofSender varchar(500) NULL,
	SubmissionDate varchar(500) NULL,
	CDSInterchangeID varchar(500) NULL,
	LocalPatientIdentifier varchar(500) NULL,
	OrganisationCodeLocalPatientIdentifier varchar(500) NULL,
	OrganisationCodeTypeLocalPatientIdentifier varchar(500) NULL,
	NHSNumber varchar(500) NULL,
	DateofBirth varchar(500) NULL,
	BirthWeight varchar(500) NULL,
	LiveOrStillBirth varchar(500) NULL,
	CarerSupportIndicator varchar(500) NULL,
	LegalStatusClassificationOnAdmissionPsychiatricCensusOnly varchar(500) NULL,
	EthnicGroup varchar(500) NULL,
	MaritalStatusPsychiatricCensusOnly varchar(500) NULL,
	NHSNumberTraceStatus varchar(500) NULL,
	WithheldIdentityReason varchar(500) NULL,
	Sex varchar(500) NULL,
	PregnancyTotalPreviousPregnancies varchar(500) NULL,
	NameFormatCode varchar(500) NULL,
	PatientName varchar(500) NULL,
	PersonTitle varchar(500) NULL,
	PersonGivenName varchar(500) NULL,
	PersonFamilyName varchar(500) NULL,
	PersonNameSuffix varchar(500) NULL,
	PersonInitials varchar(500) NULL,
	AddressFormatCode varchar(500) NULL,
	PatientUsualAddress varchar(500) NULL,
	Postcode varchar(500) NULL,
	OrganisationCodeResidenceResponsibility varchar(500) NULL,
	PCTofResidence varchar(500) NULL,
	OrganisationCodeTypePCTofResidence varchar(500) NULL,
	OSVClassificationatCDSActivityDate varchar(500) NULL,
	HospitalProviderSpellNumber varchar(500) NULL,
	AdministrativeCategory varchar(500) NULL,
	PatientClassification varchar(500) NULL,
	AdmissionMethodHospitalProviderSpell varchar(500) NULL,
	DischargeDestinationHospitalProviderSpell varchar(500) NULL,
	DischargeMethodHospitalProviderSpell varchar(500) NULL,
	SourceOfAdmissionHospitalProviderSpell varchar(500) NULL,
	StartDateHospitalProviderSpell varchar(500) NULL,
	StartTimeHospitalProviderSpell varchar(500) NULL,
	DischargeDateFromHospitalProviderSpell varchar(500) NULL,
	DischargeTimeHospitalProviderSpell varchar(500) NULL,
	DischargeToHospitalAtHomeServiceIndicator varchar(500) NULL,
	EpisodeNumber varchar(500) NULL,
	FirstRegularDayNightAdmission varchar(500) NULL,
	LastEpisodeInSpellIndicator varchar(500) NULL,
	NeonatalLevelOfCare varchar(500) NULL,
	OperationStatus varchar(500) NULL,
	PsychiatricPatientStatus varchar(500) NULL,
	StartDateConsultantEpisode varchar(500) NULL,
	StartTimeEpisode varchar(500) NULL,
	EndDateConsultantEpisode varchar(500) NULL,
	EndTimeEpisode varchar(500) NULL,
	LengthOfStayAdjustmentRehabilitation varchar(500) NULL,
	LengthOfStayAdjustmentSpecialistPalliativeCare varchar(500) NULL,
	CommissioningSerialNumber varchar(500) NULL,
	NHSServiceAgreementLineNumber varchar(500) NULL,
	ProviderReferenceNumber varchar(500) NULL,
	CommissionerReferenceNumber varchar(500) NULL,
	OrganisationCodeCodeOfProvider varchar(500) NULL,
	OrganisationCodeTypeOfProvider varchar(500) NULL,
	OrganisationCodeCodeOfCommissioner varchar(500) NULL,
	OrganisationCodeTypeofCommissioner varchar(500) NULL,
	ConsultantCode varchar(500) NULL,
	MainSpecialtyCode varchar(500) NULL,
	TreatmentFunctionCode varchar(500) NULL,
	LocalSubSpecialtyCode varchar(500) NULL,
	MultiProfessionalOrMultidisciplinaryIndCode varchar(500) NULL,
	RehabilitationAssessmentTeamType varchar(500) NULL,
	DiagnosisSchemeInUseICD varchar(500) NULL,
	DiagnosisSchemeInUseRead varchar(500) NULL,
	ProcedureSchemeInUseOPCS varchar(500) NULL,
	ProcedureSchemeInUseREAD varchar(500) NULL,
	WardCodeAtEpisodeStartDate varchar(500) NULL,
	WardSecurityLevelAtEpisodeStartDate varchar(500) NULL,
	LocationClassAtEpisodeStartDate varchar(500) NULL,
	SiteCodeOfTreatmentAtEpisodeStartDate varchar(500) NULL,
	OrganisationCodeTypeSiteCodeOfTreatmentAtStartOfEpisode varchar(500) NULL,
	IntendedClinicalCareIntensityAtStartOfEpisode varchar(500) NULL,
	AgeGroupIntendedAtStartOfEpisode varchar(500) NULL,
	SexOfPatientsAtStartOfEpisode varchar(500) NULL,
	WardDayPeriodAvailability varchar(500) NULL,
	WardNightPeriodAvailability varchar(500) NULL,
	WardCodeAtEpisodeEndDate varchar(500) NULL,
	WardSecurityLevelAtEpisodeEndDate varchar(500) NULL,
	LocationClassAtEpisodeEndDate varchar(500) NULL,
	SiteCodeOfTreatmentAtEpisodeEndDate varchar(500) NULL,
	OrganisationCodeTypeSiteCodeOfTreatmentAtEpisodeEndDate varchar(500) NULL,
	IntendedClinicalCareIntensityAtEpisodeEndDate varchar(500) NULL,
	AgeGroupIntendedAtEpisodeEndDate varchar(500) NULL,
	SexOfPatientsAtEpisodeEndDate varchar(500) NULL,
	WardDayPeriodAvailabilityAtEpisodeEndDate varchar(500) NULL,
	WardNightPeriodAvailabilityAtEpisodeEndDate varchar(500) NULL,
	GeneralMedicalPractitionerCodeofRegisteredGMP varchar(500) NULL,
	PracticeCodeofRegisteredGP varchar(500) NULL,
	OrganisationCodeTypeofRegisteredGP varchar(500) NULL,
	ReferrerCode varchar(500) NULL,
	ReferringOrganisationCode varchar(500) NULL,
	OrganisationCodeTypeofReferrer varchar(500) NULL,
	DirectAccessReferralIndicator varchar(500) NULL,
	AmbulanceIncidentNumber varchar(500) NULL,
	OrganisationCodeConveyingAmbulanceTrust varchar(500) NULL,
	DurationofElectiveWait varchar(500) NULL,
	IntendedManagement varchar(500) NULL,
	DecidedToAdmitDateForThisProvider varchar(500) NULL,
	WaitingTimeMeasurementType varchar(500) NULL,
	LocationTypeCodeAtStartOfEpisode varchar(500) NULL,
	HRGCode varchar(500) NULL,
	HRGVersionNumber varchar(500) NULL,
	ProcedureSchemeInUse varchar(500) NULL,
	DominantGroupingVariableProcedure varchar(500) NULL,
	FCEHRG varchar(500) NULL,
	EpisodeHRGVersionNumber varchar(500) NULL,
	SpellCoreHRG varchar(500) NULL,
	SpellHRGVersionNumber varchar(500) NULL,
	NumberOfBabies varchar(500) NULL,
	FirstAntenatalAssessmentDate varchar(500) NULL,
	GMPCodeofGMPResponsibleforAntenatalCare varchar(500) NULL,
	CodeofGPPracticeRegisteredGMPAntenatalCare varchar(500) NULL,
	OrganisationCodeTypeGPPracticeRegisteredGMPAntenatalCare varchar(500) NULL,
	LocationClassOfDeliveryPlaceIntended varchar(500) NULL,
	LocationTypeofDeliveryPlaceIntended varchar(500) NULL,
	DeliveryPlaceChangeReason varchar(500) NULL,
	DeliveryPlaceTypeIntended varchar(500) NULL,
	AnaestheticGivenDuringLabourDelivery varchar(500) NULL,
	AnaestheticGivenPostDelivery varchar(500) NULL,
	GestationLengthLabourOnset varchar(500) NULL,
	LabourDeliveryOnsetMethod varchar(500) NULL,
	DeliveryDate varchar(500) NULL,
	GestationLengthAssessmentBaby varchar(500) NULL,
	LocalPatientIdentifierMother varchar(500) NULL,
	OrganisationCodeLocalPatientIdentifierMother varchar(500) NULL,
	OrganisationCodeTypeMother varchar(500) NULL,
	NHSNumberMother varchar(500) NULL,
	NHSNumberStatusIndicatorMother varchar(500) NULL,
	BirthDateMother varchar(500) NULL,
	AddressFormatCodeMother varchar(500) NULL,
	PatientUsualAddressMother varchar(500) NULL,
	PostcodeOfUsualAddressMother varchar(500) NULL,
	OrganisationCodePCTofResidenceMother varchar(500) NULL,
	OrganisationCodeTypePCTofResidenceMother varchar(500) NULL,
	UniqueBookingReferenceNumberConverted varchar(500) NULL,
	PatientPathwayIdentifier varchar(500) NULL,
	OrganisationCodePatientPathwayIdentifierIssuer varchar(500) NULL,
	ReferralToTreatmentPeriodStatus varchar(500) NULL,
	ReferralToTreatmentPeriodStartDate varchar(500) NULL,
	ReferralToTreatmentPeriodEndDate varchar(500) NULL,
	LeadCareActivityIndicator varchar(500) NULL,
	AgeatCDSActivityDate varchar(500) NULL,
	NHSServiceAgreementChangeDate varchar(500) NULL,
	CDSActivityDate varchar(500) NULL,
	AgeAsOnAdmission varchar(500) NULL,
	AdminCategoryAtStart varchar(500) NULL,
	HospitalProviderSpellDischargeReadyDate varchar(500) NULL,
	LocationType varchar(500) NULL,
	XMLVersion varchar(500) NULL,
	ConfidentialityCategoryDerived varchar(500) NULL,
	ReferralToTreatmentLengthDerived varchar(500) NULL,
	AgeRangePatientdDerivedFromDOB varchar(500) NULL,
	AgeRangeMotherDerivedFromDOB varchar(500) NULL,
	AreaCodeDerivedFromPostcode varchar(500) NULL,
	CDSGroup varchar(500) NULL,
	FinishedIndicator varchar(500) NULL,
	PCTDerivedfromGP varchar(500) NULL,
	PCTTypeDerivedfromGP varchar(500) NULL,
	GPPracticeDerived varchar(500) NULL,
	GPPracticeMotherDerived varchar(500) NULL,
	PCTDerivedfromderivedGPPractice varchar(500) NULL,
	PCTMotherDerivedfromderivedGPPractice varchar(500) NULL,
	SHAfromGPPractice varchar(500) NULL,
	SHATypefromGPPractice varchar(500) NULL,
	HospitalSpellDuration varchar(500) NULL,
	MonthOfBirth varchar(500) NULL,
	HomeBirthOrDelivery varchar(500) NULL,
	ElectoralWardFromPostcode varchar(500) NULL,
	PCTFromPostcode varchar(500) NULL,
	PCTTypefromPostcode varchar(500) NULL,
	SHAfromPostcode varchar(500) NULL,
	SHATypefromPostcode varchar(500) NULL,
	AreacodeFromProviderPostcode varchar(500) NULL,
	AgeAtEndOfEpisode varchar(500) NULL,
	AgeAtStartOfEpisode varchar(500) NULL,
	YearOfBirth varchar(500) NULL,
	YearOfBirthMother varchar(500) NULL,
	MonthOfBirthMother varchar(500) NULL,
	CensusArea varchar(500) NULL,
	Country varchar(500) NULL,
	CountyCode varchar(500) NULL,
	CensusED varchar(500) NULL,
	EDDistrictCode varchar(500) NULL,
	ElectoralWardCode varchar(500) NULL,
	GORCode varchar(500) NULL,
	LocalUnitaryAuthority varchar(500) NULL,
	OldSHACode varchar(500) NULL,
	ElectoralArea varchar(500) NULL,
	PrimeRecipient varchar(500) NULL,
	CopyRecipients varchar(500) NULL
);

CREATE TABLE omop_staging.sus_Birth(
	MessageId uuid NOT NULL,
	BirthOrderBaby varchar(500) NULL,
	DeliveryMethodBaby varchar(500) NULL,
	GestationLengthAssessmentBaby varchar(500) NULL,
	ResuscitationMethodBaby varchar(500) NULL,
	StatusOfPersonConductingDeliveryBaby varchar(500) NULL,
	LocalPatientIdentifierBaby varchar(500) NULL,
	OrganisationCodeLocalPatientIDBaby varchar(500) NULL,
	OrganisationCodeTypeLocalPatientIDBaby varchar(500) NULL,
	NHSNumberBaby varchar(500) NULL,
	NHSNumberStatusIndicatorBaby varchar(500) NULL,
	BirthDateBabyBaby varchar(500) NULL,
	BirthWeightBaby varchar(500) NULL,
	LiveOrStillBirthBaby varchar(500) NULL,
	SexBaby varchar(500) NULL,
	BirthLocationType varchar(500) NULL,
	LocationClassDeliveryPlaceActual varchar(500) NULL,
	DeliveryPlaceTypeActual varchar(500) NULL
);

CREATE TABLE omop_staging.sus_CareLocation(
	MessageId uuid NOT NULL,
	WardCode varchar(500) NULL,
	WardSecurityLevel varchar(500) NULL,
	LocationClass varchar(500) NULL,
	SiteCodeOfTreatment varchar(500) NULL,
	OrganisationCodeTypeSiteCodeOfTreatment varchar(500) NULL,
	IntendedClinicalCareIntensity varchar(500) NULL,
	AgeGroupIntended varchar(500) NULL,
	SexOfPatients varchar(500) NULL,
	WardDayPeriodAvailability varchar(500) NULL,
	WardNightPeriodAvailability varchar(500) NULL,
	StartDate varchar(500) NULL,
	StartTimeWardStay varchar(500) NULL,
	EndDate varchar(500) NULL,
	EndTimeWardStay varchar(500) NULL
);

CREATE TABLE omop_staging.sus_CCMDS(
	MessageId uuid NOT NULL,
	GeneratedRecordID varchar(70) NULL,
	LoadStagingDate varchar(1000) NULL,
	CriticalCarePeriodSequenceNumber varchar(1000) NULL,
	CDSVersionontheepisodes varchar(1000) NULL,
	HESEPITYPEoftheepisode varchar(1000) NULL,
	CDSInterchangeID varchar(1000) NULL,
	HESEPISTAToftheepisode varchar(1000) NULL,
	EventDate varchar(1000) NULL,
	ActivityDateCriticalCare varchar(1000) NULL,
	CriticalCarePeriodType varchar(1000) NULL,
	CriticalCareEpisodeRelationship varchar(1000) NULL,
	CriticalCareUnitFunction varchar(1000) NULL,
	CriticalCareStartDate varchar(1000) NULL,
	CriticalCareStartTime varchar(1000) NULL,
	CriticalCarePeriodDischargeDate varchar(1000) NULL,
	CriticalCarePeriodDischargeTime varchar(1000) NULL,
	CriticalCarePeriodLocalIdentifier varchar(1000) NULL,
	GestationLengthAtDelivery varchar(1000) NULL,
	CriticalCareSequenceNumberDerived varchar(1000) NULL,
	TotalnumberofCriticalCareActivitiesDerived varchar(1000) NULL,
	LastRecordforthisCriticalCarePeriodIndicatorDerived varchar(1000) NULL,
	CriticalCareActivitytoEpisodeRelationshipDerived varchar(1000) NULL,
	PersonWeight varchar(1000) NULL
); 

CREATE TABLE omop_staging.sus_CCMDS_CriticalCareActivityCode(
	MessageId uuid NOT NULL,
	CriticalCareActivityCode varchar(1000) NOT NULL
); 

CREATE TABLE omop_staging.sus_CCMDS_CriticalCareHighCostDrugs(
	MessageId uuid NOT NULL,
	CriticalCareHighCostDrugs varchar(1000) NOT NULL
); 

CREATE TABLE omop_staging.sus_CriticalCare(
	MessageId uuid NOT NULL,
	CriticalCareLocalIdentifier varchar(500) NULL,
	CriticalCareStartDate varchar(500) NULL,
	CriticalCareUnitFunction varchar(500) NULL,
	AdvancedRespiratorySupportDays varchar(500) NULL,
	BasicRespiratorySupportDays varchar(500) NULL,
	AdvancedCardiovascularSupportDays varchar(500) NULL,
	BasicCardiovascularSupportDays varchar(500) NULL,
	RenalSupportDays varchar(500) NULL,
	NeurologicalSupportDays varchar(500) NULL,
	DermatologicalSupportDays varchar(500) NULL,
	LiverSupportDays varchar(500) NULL,
	CriticalCareLevel2Days varchar(500) NULL,
	CriticalCareLevel3Days varchar(500) NULL,
	CriticalCareDischargeDate varchar(500) NULL,
	CriticalCareUnitBedConfiguration varchar(500) NULL,
	CriticalCareAdmissionSource varchar(500) NULL,
	CriticalCareSourceLocation varchar(500) NULL,
	CriticalCareAdmissionType varchar(500) NULL,
	GastroIntestinalSupportDays varchar(500) NULL,
	OrganSupportMaximum varchar(500) NULL,
	CriticalCareDischargeReadyDate varchar(500) NULL,
	CriticalCareDischargeReadyTime varchar(500) NULL,
	CriticalCareDischargeStatus varchar(500) NULL,
	CriticalCareDischargeDestination varchar(500) NULL,
	CriticalCareDischargeLocation varchar(500) NULL,
	CriticalCareDischargeTime varchar(500) NULL,
	CriticalCareActivityToEpisodeRelationshipDerived varchar(500) NULL,
	CriticalCarePeriodSequenceNumber varchar(500) NULL,
	CriticalCareStartTime varchar(500) NULL,
	CriticalCarePeriodType varchar(500) NULL
);

CREATE TABLE omop_staging.sus_ICDDiagnosis(
	MessageId uuid NOT NULL,
	DiagnosisICD varchar(500) NULL,
	PresentOnAdmissionIndicatorDiagnosis varchar(500) NULL,
	IsPrimaryDiagnosis integer NOT NULL
);

CREATE TABLE omop_staging.sus_OP(
	MessageId uuid NOT NULL,
	GeneratedRecordIdentifier varchar(500) NULL,
	ReasonforAccess varchar(500) NULL,
	CDStype varchar(500) NULL,
	Protocolidentifier varchar(500) NULL,
	UniqueCDSidentifier varchar(500) NULL,
	SUSgeneratedspellID varchar(500) NULL,
	Updatetype varchar(500) NULL,
	BulkreplacementCDSgroup varchar(500) NULL,
	Testindicator varchar(500) NULL,
	Applicabledatetime varchar(500) NULL,
	Censusdate varchar(500) NULL,
	Extractdatetime varchar(500) NULL,
	ReportperiodStartDate varchar(500) NULL,
	ReportperiodEndDate varchar(500) NULL,
	OrganisationcodeSenderoftransaction varchar(500) NULL,
	OrganisationCodeTypeofSender varchar(500) NULL,
	SubmissionDate varchar(500) NULL,
	CDSInterchangeID varchar(500) NULL,
	LocalPatientIdentifier varchar(500) NULL,
	OrganisationCodeLocalPatientIdentifier varchar(500) NULL,
	OrganisationCodeTypeLocalPatientIdentifier varchar(500) NULL,
	NHSNumber varchar(500) NULL,
	DateofBirth varchar(500) NULL,
	CarerSupportIndicator varchar(500) NULL,
	NHSNumberTraceStatus varchar(500) NULL,
	WithheldIdentityReason varchar(500) NULL,
	Sex varchar(500) NULL,
	NameFormatCode varchar(500) NULL,
	PatientName varchar(500) NULL,
	PersonTitle varchar(500) NULL,
	PersonGivenName varchar(500) NULL,
	PersonFamilyName varchar(500) NULL,
	PersonNameSuffix varchar(500) NULL,
	PersonInitials varchar(500) NULL,
	AddressFormatCode varchar(500) NULL,
	PatientUsualAddress varchar(500) NULL,
	Postcode varchar(500) NULL,
	OrganisationCodeResidenceResponsibility varchar(500) NULL,
	PCTofResidence varchar(500) NULL,
	OrganisationCodeTypePCTofResidence varchar(500) NULL,
	EthnicCategory varchar(500) NULL,
	OSVClassificationatCDSActivityDate varchar(500) NULL,
	ConsultantCode varchar(500) NULL,
	MainSpecialtyCode varchar(500) NULL,
	TreatmentFunctionCode varchar(500) NULL,
	LocalSubSpecialtyCode varchar(500) NULL,
	MultiProfessionalOrMultidisciplinaryIndCode varchar(500) NULL,
	RehabilitationAssessmentTeamType varchar(500) NULL,
	DiagnosisSchemeInUseICD varchar(500) NULL,
	DiagnosisSchemeInUseRead varchar(500) NULL,
	AttendanceIdentifier varchar(500) NULL,
	AdministrativeCategory varchar(500) NULL,
	AttendedorDidNotAttend varchar(500) NULL,
	FirstAttendance varchar(500) NULL,
	MedicalStaffTypeSeeingPatient varchar(500) NULL,
	OperationStatusPerAttendance varchar(500) NULL,
	OutcomeofAttendance varchar(500) NULL,
	AppointmentDate varchar(500) NULL,
	AppointmentTime varchar(500) NULL,
	ExpectedDurationOfAppointment varchar(500) NULL,
	ConsultationMediumUsed varchar(500) NULL,
	WaitingTimeMeasurementType varchar(500) NULL,
	ActivityLocationTypeCode varchar(500) NULL,
	EarliestClinicallyAppropriateDate varchar(500) NULL,
	ClinicCode varchar(500) NULL,
	CommissioningSerialNumber varchar(500) NULL,
	NHSServiceAgreementLineNumber varchar(500) NULL,
	ProviderReferenceNumber varchar(500) NULL,
	CommissionerReferenceNumber varchar(500) NULL,
	OrganisationCodeCodeofProvider varchar(500) NULL,
	OrganisationCodeTypeCodeofProvider varchar(500) NULL,
	OrganisationCodeCodeofCommissioner varchar(500) NULL,
	OrganisationCodeTypeCodeofCommissioner varchar(500) NULL,
	ProcedureSchemeInUseOPCS varchar(500) NULL,
	ProcedureSchemeInUseRead varchar(500) NULL,
	LocationClassatAttendance varchar(500) NULL,
	SiteCodeofTreatment varchar(500) NULL,
	OrganisationCodeTypeSiteCodeofTreatmentAtAttendance varchar(500) NULL,
	GeneralMedicalPractitionerCodeofRegisteredGMP varchar(500) NULL,
	PracticeCodeofRegisteredGP varchar(500) NULL,
	OrganisationCodeTypeofRegisteredGP varchar(500) NULL,
	PriorityType varchar(500) NULL,
	ServiceTypeRequested varchar(500) NULL,
	SourceofReferralForOutpatients varchar(500) NULL,
	ReferralRequestReceivedDate varchar(500) NULL,
	DirectAccessReferralIndicator varchar(500) NULL,
	ReferrerCode varchar(500) NULL,
	ReferringOrganisationCode varchar(500) NULL,
	OrganisationCodeTypeofReferrer varchar(500) NULL,
	LastDNAOrPatientCancelledDate varchar(500) NULL,
	HRGCode varchar(500) NULL,
	HRGVersionNumber varchar(500) NULL,
	ProcedureSchemeInUse varchar(500) NULL,
	DominantGroupingVariableProcedure varchar(500) NULL,
	CoreHRG varchar(500) NULL,
	HRGVersionCalculated varchar(500) NULL,
	SUSHRG varchar(500) NULL,
	UniqueBookingReferenceNumberConverted varchar(500) NULL,
	PatientPathwayIdentifier varchar(500) NULL,
	OrganisationCodePatientPathwayIdentifierIssuer varchar(500) NULL,
	ReferralToTreatmentPeriodStatus varchar(500) NULL,
	ReferralToTreatmentPeriodStartDate varchar(500) NULL,
	ReferralToTreatmentPeriodEndDate varchar(500) NULL,
	LeadCareActivityIndicator varchar(500) NULL,
	AgeatCDSActivityDate varchar(500) NULL,
	NHSServiceAgreementChangeDate varchar(500) NULL,
	CDSActivityDate varchar(500) NULL,
	EarliestReasonableOfferedDate varchar(500) NULL,
	LocationType varchar(500) NULL,
	XMLVersion varchar(500) NULL,
	ConfidentialityCategoryDerived varchar(500) NULL,
	ReferralToTreatmentLengthDerived varchar(500) NULL,
	AgerangepatientderivedfromDOB varchar(500) NULL,
	Areacodederivedfrompostcode varchar(500) NULL,
	AttenderTypeDerived varchar(500) NULL,
	CDSGroup varchar(500) NULL,
	FinishedIndicator varchar(500) NULL,
	PCTDerivedfromGP varchar(500) NULL,
	PCTTypeDerivedfromGP varchar(500) NULL,
	GPPracticeDerived varchar(500) NULL,
	PCTDerivedfromderivedGPPractice varchar(500) NULL,
	SHAfromGPPractice varchar(500) NULL,
	SHATypefromGPPractice varchar(500) NULL,
	MonthofBirth varchar(500) NULL,
	ElectoralWardfrompostcode varchar(500) NULL,
	PCTfrompostcode varchar(500) NULL,
	PCTTypefromPostcode varchar(500) NULL,
	SHAfromPostcode varchar(500) NULL,
	SHATypefromPostcode varchar(500) NULL,
	AreacodefromProviderPostcode varchar(500) NULL,
	AgeatEndofEpisode varchar(500) NULL,
	AgeatStartofEpisode varchar(500) NULL,
	YearofBirth varchar(500) NULL,
	CensusArea varchar(500) NULL,
	Country varchar(500) NULL,
	CountyCode varchar(500) NULL,
	CensusED varchar(500) NULL,
	EDDistrictCode varchar(500) NULL,
	ElectoralWardCode varchar(500) NULL,
	GORCode varchar(500) NULL,
	LocalUnitaryAuthority varchar(500) NULL,
	OldSHACode varchar(500) NULL,
	ElectoralArea varchar(500) NULL,
	PrimeRecipient varchar(500) NULL,
	CopyRecipients varchar(500) NULL,
	IsValidUBRN varchar(500) NULL,
	UBRNOccurrenceCount varchar(500) NULL
);

CREATE TABLE omop_staging.sus_OP_ICDDiagnosis(
	MessageId uuid NOT NULL,
	DiagnosisICD varchar(500) NULL,
	PresentOnAdmissionIndicatorDiagnosis varchar(500) NULL,
	IsPrimaryDiagnosis integer NOT NULL
);

CREATE TABLE omop_staging.sus_OP_OPCSProcedure(
	MessageId uuid NOT NULL,
	ProcedureOPCS varchar(500) NULL,
	MainOperatingHealthcareProfessionalCodeOpcs varchar(500) NULL,
	ProfessionalRegistrationIssuerCodeOpcs varchar(500) NULL,
	ResponsibleAnaesthetistCodeOpcs varchar(500) NULL,
	ResponsibleAnaesthetistRegBodyOpcs varchar(500) NULL,
	IsPrimaryProcedure integer NOT NULL
);

CREATE TABLE omop_staging.sus_OP_ReadDiagnosis(
	MessageId uuid NOT NULL,
	DiagnosisRead varchar(500) NOT NULL,
	IsPrimaryDiagnosis integer NOT NULL
);

CREATE TABLE omop_staging.sus_OP_ReadProcedure(
	MessageId uuid NOT NULL,
	ProcedureRead varchar(500) NULL,
	IsPrimaryProcedure integer NOT NULL
);

CREATE TABLE omop_staging.sus_OPCSProcedure(
	MessageId uuid NOT NULL,
	ProcedureOPCS varchar(500) NULL,
	ProcedureDateOPCS varchar(500) NULL,
	MainOperatingHealthcareProfessionalCodeOpcs varchar(500) NULL,
	ProfessionalRegistrationIssuerCodeOpcs varchar(500) NULL,
	ResponsibleAnaesthetistCodeOpcs varchar(500) NULL,
	ResponsibleAnaesthetistRegBodyOpcs varchar(500) NULL,
	IsPrimaryProcedure integer NOT NULL
);

CREATE TABLE omop_staging.sus_OverseasVisitor(
	MessageId uuid NOT NULL,
	OverseasVisitorStatusClassification varchar(500) NULL,
	OverseasVisitorStatusStartDate varchar(500) NULL
);

CREATE TABLE omop_staging.sus_ReadDiagnosis(
	MessageId uuid NOT NULL,
	DiagnosisRead varchar(500) NOT NULL,
	IsPrimaryDiagnosis integer NOT NULL
);

CREATE TABLE omop_staging.sus_ReadProcedure(
	MessageId uuid NOT NULL,
	ProcedureRead varchar(500) NULL,
	ProcedureDateRead varchar(500) NULL,
	IsPrimaryProcedure integer NOT NULL
);

CREATE table omop_staging.care_site_row (
	care_site_name varchar(50) NULL,
	place_of_service_concept_id integer NULL,
	location_id integer NULL,
	care_site_source_value varchar(50) NULL,
	place_of_service_source_value varchar(50) NULL,
	data_source varchar(100) NOT NULL
);

CREATE table omop_staging.condition_occurrence_row (
	nhs_number varchar(10) NOT NULL,
	RecordConnectionIdentifier varchar(50) NULL,
	condition_concept_id integer NOT NULL,
	condition_start_date date NOT NULL,
	condition_start_datetime datetime NULL,
	condition_end_date date NULL,
	condition_end_datetime datetime NULL,
	condition_type_concept_id integer NOT NULL,
	condition_status_concept_id integer NULL,
	stop_reason varchar(20) NULL,
	provider_id integer NULL,
	visit_occurrence_id integer NULL,
	visit_detail_id integer NULL,
	condition_source_value varchar(50) NULL,
	condition_source_concept_id integer NULL,
	condition_status_source_value varchar(50) NULL,
	data_source varchar(100) NOT NULL
);

CREATE table omop_staging.death_row (
	nhs_number varchar(10) NOT NULL,
	death_date date NOT NULL,
	death_datetime datetime NULL,
	death_type_concept_id integer NULL,
	cause_concept_id integer NULL,
	cause_source_value varchar(50) NULL,
	cause_source_concept_id integer NULL,
	data_source varchar(100) NOT NULL
);

CREATE table omop_staging.device_exposure_row (
	nhs_number varchar(10) NOT NULL,
	device_concept_id integer NOT NULL,
	device_exposure_start_date date NOT NULL,
	device_exposure_start_datetime datetime NULL,
	device_exposure_end_date date NULL,
	device_exposure_end_datetime datetime NULL,
	device_type_concept_id integer NOT NULL,
	unique_device_id varchar(50) NULL,
	production_id varchar(50) NULL,
	quantity float NULL,
	provider_id integer NULL,
	visit_occurrence_id integer NULL,
	visit_detail_id integer NULL,
	device_source_value varchar(50) NULL,
	device_source_concept_id integer NULL,
	unit_concept_id integer NULL,
	unit_source_value varchar(50) NULL,
	unit_source_concept_id integer NULL,
	RecordConnectionIdentifier varchar(50) NULL,
	HospitalProviderSpellNumber varchar(100) NULL,
	data_source varchar(100) NOT NULL
);

CREATE table omop_staging.drug_exposure_row (
	nhs_number varchar(10) NOT NULL,
	drug_concept_id integer NOT NULL,
	drug_exposure_start_date date NOT NULL,
	drug_exposure_start_datetime datetime NULL,
	drug_exposure_end_date date NOT NULL,
	drug_exposure_end_datetime datetime NULL,
	verbatim_end_date date NULL,
	drug_type_concept_id integer NOT NULL,
	stop_reason varchar(20) NULL,
	refills integer NULL,
	quantity float NULL,
	days_supply integer NULL,
	sig varchar(1000) NULL,
	route_concept_id integer NULL,
	lot_number varchar(50) NULL,
	provider_id integer NULL,
	drug_source_value varchar(500) NULL,
	drug_source_concept_id integer NULL,
	route_source_value varchar(50) NULL,
	dose_unit_source_value varchar(50) NULL,
	RecordConnectionIdentifier varchar(50) NULL,
	data_source varchar(100) NOT NULL
);

CREATE table omop_staging.Location_row (
	address_1 varchar(255) NULL,
	address_2 varchar(255) NULL,
	city varchar(255) NULL,
	state varchar(2) NULL,
	zip varchar(9) NULL,
	county varchar(255) NULL,
	location_source_value varchar(255) NULL,
	country_concept_id integer NULL,
	country_source_value varchar(80) NULL,
	latitude float NULL,
	longitude float NULL,
	NhsNumber varchar(500) NULL,
	data_source varchar(100) NOT NULL
);

CREATE table omop_staging.measurement_row (
	nhs_number varchar(10) NOT NULL,
	measurement_concept_id integer NOT NULL,
	measurement_date date NOT NULL,
	measurement_datetime datetime NULL,
	measurement_time varchar(10) NULL,
	measurement_type_concept_id integer NOT NULL,
	operator_concept_id integer NULL,
	value_as_number float NULL,
	value_as_concept_id integer NULL,
	unit_concept_id integer NULL,
	range_low float NULL,
	range_high float NULL,
	provider_id integer NULL,
	measurement_source_value varchar(50) NULL,
	measurement_source_concept_id integer NULL,
	unit_source_value varchar(50) NULL,
	unit_source_concept_id integer NULL,
	value_source_value varchar(50) NULL,
	measurement_event_id integer NULL,
	meas_event_field_concept_id integer NULL,
	RecordConnectionIdentifier varchar(50) NULL,
	HospitalProviderSpellNumber varchar(100) NULL,
	data_source varchar(100) NOT NULL
);

CREATE table omop_staging.observation_row (
	nhs_number varchar(10) NOT NULL,
	RecordConnectionIdentifier varchar(50) NULL,
	HospitalProviderSpellNumber varchar(100) NULL,
	observation_concept_id integer NOT NULL,
	observation_date date NOT NULL,
	observation_datetime datetime NULL,
	observation_type_concept_id integer NOT NULL,
	value_as_number float NULL,
	value_as_string varchar(60) NULL,
	value_as_concept_id integer NULL,
	qualifier_concept_id integer NULL,
	unit_concept_id integer NULL,
	provider_id integer NULL,
	observation_source_value varchar(50) NULL,
	observation_source_concept_id integer NULL,
	unit_source_value varchar(50) NULL,
	qualifier_source_value varchar(50) NULL,
	value_source_value varchar(50) NULL,
	observation_event_id integer NULL,
	obs_event_field_concept_id integer NULL,
	data_source varchar(100) NOT NULL
);

CREATE table omop_staging.person_row (
	gender_concept_id integer NULL,
	year_of_birth integer NULL,
	month_of_birth integer NULL,
	day_of_birth integer NULL,
	birth_datetime datetime NULL,
	race_concept_id integer NULL,
	ethnicity_concept_id integer NULL,
	provider_id integer NULL,
	care_site_id integer NULL,
	person_source_value varchar(1000) NOT NULL,
	gender_source_value varchar(1000) NULL,
	gender_source_concept_id integer NULL,
	race_source_value varchar(1000) NULL,
	race_source_concept_id integer NULL,
	ethnicity_source_value varchar(1000) NULL,
	ethnicity_source_concept_id integer NULL,
	data_source varchar(100) NOT NULL
);

CREATE table omop_staging.procedure_occurrence_row (
	nhs_number varchar(10) NOT NULL,
	procedure_concept_id integer NOT NULL,
	procedure_date date NOT NULL,
	procedure_datetime datetime NULL,
	procedure_end_date date NULL,
	procedure_end_datetime datetime NULL,
	procedure_type_concept_id integer NOT NULL,
	modifier_concept_id integer NULL,
	quantity integer NULL,
	provider_id integer NULL,
	visit_occurrence_id integer NULL,
	visit_detail_id integer NULL,
	procedure_source_value varchar(50) NULL,
	procedure_source_concept_id integer NULL,
	modifier_source_value varchar(50) NULL,
	RecordConnectionIdentifier varchar(50) NULL,
	data_source varchar(100) NOT NULL
);

CREATE table omop_staging.provider_row (
	provider_name varchar(50) NULL,
	npi varchar(50) NULL,
	dea varchar(50) NULL,
	specialty_concept_id integer NULL,
	care_site_id integer NULL,
	year_of_birth integer NULL,
	gender_concept_id integer NULL,
	provider_source_value varchar(50) NULL,
	specialty_source_value varchar(50) NULL,
	specialty_source_concept_id integer NULL,
	gender_source_value varchar(50) NULL,
	gender_source_concept_id integer NULL,
	data_source varchar(100) NOT NULL
);

CREATE table omop_staging.visit_detail_row (
	nhs_number varchar(10) NOT NULL,
	HospitalProviderSpellNumber varchar(100) NULL,
	RecordConnectionIdentifier varchar(50) NULL,
	visit_detail_concept_id integer NOT NULL,
	visit_detail_start_date date NOT NULL,
	visit_detail_start_datetime datetime NULL,
	visit_detail_end_date date NOT NULL,
	visit_detail_end_datetime datetime NULL,
	visit_detail_type_concept_id integer NOT NULL,
	provider_id integer NULL,
	care_site_id integer NULL,
	visit_detail_source_value varchar(50) NULL,
	visit_detail_source_concept_id integer NULL,
	admitted_from_concept_id integer NULL,
	admitted_from_source_value varchar(50) NULL,
	discharged_to_source_value varchar(50) NULL,
	discharged_to_concept_id integer NULL,
	data_source varchar(100) NOT NULL
);

CREATE table omop_staging.visit_occurrence_row (
	nhs_number varchar(10) NOT NULL,
	HospitalProviderSpellNumber varchar(100) NULL,
	RecordConnectionIdentifier varchar(50) NULL,
	visit_concept_id integer NOT NULL,
	visit_start_date date NOT NULL,
	visit_start_datetime datetime NULL,
	visit_end_date date NOT NULL,
	visit_end_datetime datetime NULL,
	visit_type_concept_id integer NOT NULL,
	provider_id integer NULL,
	care_site_id integer NULL,
	visit_source_value varchar(50) NULL,
	visit_source_concept_id integer NULL,
	admitted_from_concept_id integer NULL,
	admitted_from_source_value varchar(50) NULL,
	discharged_to_concept_id integer NULL,
	discharged_to_source_value varchar(50) NULL,
	data_source varchar(100) NOT NULL
);", cancellationToken);

			
            _logger.LogInformation($"Importing Vocabulary from {_configuration.VocabularyDirectory!}");

            await connection.ExecuteAsync($@"

copy cdm.CONCEPT from '{Path.Combine(_configuration.VocabularyDirectory!, "CONCEPT.csv")}' (HEADER, DATEFORMAT '%Y%m%d');
copy cdm.CONCEPT_ANCESTOR from '{Path.Combine(_configuration.VocabularyDirectory!, "CONCEPT_ANCESTOR.csv")}'  (HEADER, DATEFORMAT '%Y%m%d');
copy cdm.CONCEPT_CLASS from '{Path.Combine(_configuration.VocabularyDirectory!, "CONCEPT_CLASS.csv")}'  (HEADER, DATEFORMAT '%Y%m%d');
copy cdm.CONCEPT_RELATIONSHIP from '{Path.Combine(_configuration.VocabularyDirectory!, "CONCEPT_RELATIONSHIP.csv")}'  (HEADER, DATEFORMAT '%Y%m%d');
copy cdm.CONCEPT_SYNONYM from '{Path.Combine(_configuration.VocabularyDirectory!, "CONCEPT_SYNONYM.csv")}'  (HEADER, DATEFORMAT '%Y%m%d');
copy cdm.DOMAIN from '{Path.Combine(_configuration.VocabularyDirectory!, "DOMAIN.csv")}'  (HEADER, DATEFORMAT '%Y%m%d');
copy cdm.DRUG_STRENGTH from '{Path.Combine(_configuration.VocabularyDirectory!, "DRUG_STRENGTH.csv")}'  (HEADER, DATEFORMAT '%Y%m%d');
copy cdm.RELATIONSHIP from '{Path.Combine(_configuration.VocabularyDirectory!, "RELATIONSHIP.csv")}'  (HEADER, DATEFORMAT '%Y%m%d');
copy cdm.VOCABULARY from '{Path.Combine(_configuration.VocabularyDirectory!, "VOCABULARY.csv")}'  (HEADER, DATEFORMAT '%Y%m%d');",
                cancellationToken);

            _logger.LogInformation("Adding custom concepts.");

            await connection.ExecuteAsync(@"
insert into cdm.cdm_source 
(
	cdm_source_name, 
	cdm_source_abbreviation, 
	cdm_holder, 
	source_description, 
	source_documentation_reference, 
	cdm_etl_reference, 
	source_release_date, 
	cdm_release_date, 
	cdm_version, 
	cdm_version_concept_id, 
	vocabulary_version
) 
values 
(
	'Oxford', 
	'Oxford', 
	'', 
	'', 
	'', 
	'', 
	current_date, 
	current_date, 
	'5.4', 
	0, 
	''
);

insert into cdm.concept
(
	concept_id,
	concept_name,
	domain_id,
	vocabulary_id,
	concept_class_id,
	standard_concept,
	concept_code,
	valid_start_date,
	valid_end_date,
	invalid_reason
)
values
(
	2000500000, --concept_id
	'OMOP Oxford',--concept_name
	'Metadata', --domain_id
	'Vocabulary', --vocabulary_id
	'Vocabulary', --concept_class_id
	null, --standard_concept
	'OMOP generated', --concept_code
	'1970-01-01', --valid_start_date
	'2099-12-31', --valid_end_date
	null --invalid_reason
);

insert into cdm.vocabulary
(
	vocabulary_id,
	vocabulary_name,
	vocabulary_reference,
	vocabulary_version,
	vocabulary_concept_id
)
values
(
	'OXFORD', --vocabulary_id
	'OXFORD', --vocabulary_name
	'', --vocabulary_reference
	null, --vocabulary_version
	2000500000--vocabulary_concept_id
);


insert into cdm.concept
(
	concept_id,
	concept_name,
	domain_id,
	vocabulary_id,
	concept_class_id,
	standard_concept,
	concept_code,
	valid_start_date,
	valid_end_date,
	invalid_reason
)
values
(
	2000500001,-- concept_id
	'ANAESTHETIC GIVEN DURING LABOUR OR DELIVERY CODE',-- concept_name
	'Observation', -- domain_id
	'OXFORD', -- vocabulary_id
	'Observation',-- concept_class_id
	null, -- standard_concept
	'ANAESTHETIC GIVEN DURING LABOUR OR DELIVERY CODE',-- concept_code
	'1970-01-01', -- valid_start_date
	'2099-12-31', -- valid_end_date
	null -- invalid_reason
);

insert into cdm.concept
(
	concept_id,
	concept_name,
	domain_id,
	vocabulary_id,
	concept_class_id,
	standard_concept,
	concept_code,
	valid_start_date,
	valid_end_date,
	invalid_reason
)
values
(
	2000500002,-- concept_id
	'ANAESTHETIC GIVEN POST LABOUR OR DELIVERY CODE',-- concept_name
	'Observation', -- domain_id
	'OXFORD', -- vocabulary_id
	'Observation',-- concept_class_id
	null, -- standard_concept
	'ANAESTHETIC GIVEN POST LABOUR OR DELIVERY CODE',-- concept_code
	'1970-01-01', -- valid_start_date
	'2099-12-31', -- valid_end_date
	null -- invalid_reason
);

insert into cdm.concept
(
	concept_id,
	concept_name,
	domain_id,
	vocabulary_id,
	concept_class_id,
	standard_concept,
	concept_code,
	valid_start_date,
	valid_end_date,
	invalid_reason
)
values
(
	2000500003,-- concept_id
	'History Of Alcohol (Current)',-- concept_name
	'Observation', -- domain_id
	'OXFORD', -- vocabulary_id
	'Observation',-- concept_class_id
	null, -- standard_concept
	'History Of Alcohol (Current)',-- concept_code
	'1970-01-01', -- valid_start_date
	'2099-12-31', -- valid_end_date
	null -- invalid_reason
);

insert into cdm.concept
(
	concept_id,
	concept_name,
	domain_id,
	vocabulary_id,
	concept_class_id,
	standard_concept,
	concept_code,
	valid_start_date,
	valid_end_date,
	invalid_reason
)
values
(
	2000500004,-- concept_id
	'History Of Alcohol (Past)',-- concept_name
	'Observation', -- domain_id
	'OXFORD', -- vocabulary_id
	'Observation',-- concept_class_id
	null, -- standard_concept
	'History Of Alcohol (Past)',-- concept_code
	'1970-01-01', -- valid_start_date
	'2099-12-31', -- valid_end_date
	null -- invalid_reason
);

insert into cdm.concept
(
	concept_id,
	concept_name,
	domain_id,
	vocabulary_id,
	concept_class_id,
	standard_concept,
	concept_code,
	valid_start_date,
	valid_end_date,
	invalid_reason
)
values
(
	2000500005,-- concept_id
	'Familial Cancer (Indicator)',-- concept_name
	'Observation', -- domain_id
	'OXFORD', -- vocabulary_id
	'Observation',-- concept_class_id
	null, -- standard_concept
	'Familial Cancer (Indicator)',-- concept_code
	'1970-01-01', -- valid_start_date
	'2099-12-31', -- valid_end_date
	null -- invalid_reason
);

insert into cdm.concept
(
	concept_id,
	concept_name,
	domain_id,
	vocabulary_id,
	concept_class_id,
	standard_concept,
	concept_code,
	valid_start_date,
	valid_end_date,
	invalid_reason
)
values
(
	2000500006,-- concept_id
	'Familial Cancer (Comment)',-- concept_name
	'Observation', -- domain_id
	'OXFORD', -- vocabulary_id
	'Observation',-- concept_class_id
	null, -- standard_concept
	'Familial Cancer (Comment)',-- concept_code
	'1970-01-01', -- valid_start_date
	'2099-12-31', -- valid_end_date
	null -- invalid_reason
);

insert into cdm.concept
(
	concept_id,
	concept_name,
	domain_id,
	vocabulary_id,
	concept_class_id,
	standard_concept,
	concept_code,
	valid_start_date,
	valid_end_date,
	invalid_reason
)
values
(
	2000500007,-- concept_id
	'PrimaryPathwayMetastasis',
    'Measurement',
    'OXFORD',
    'Measurement',
    null,
    'PrimaryPathwayMetastasis',
    '1970-01-01',
    '2099-12-31',
    null
);

insert into cdm.concept
(
	concept_id,
	concept_name,
	domain_id,
	vocabulary_id,
	concept_class_id,
	standard_concept,
	concept_code,
	valid_start_date,
	valid_end_date,
	invalid_reason
)
values
(
	2000500008,-- concept_id
	'NonPrimaryPathwayRecurrenceMetastasis',
    'Measurement',
    'OXFORD',
    'Measurement',
    null,
    'NonPrimaryPathwayRecurrenceMetastasis',
    '1970-01-01',
    '2099-12-31',
    null
);

insert into cdm.concept
(
	concept_id,
	concept_name,
	domain_id,
	vocabulary_id,
	concept_class_id,
	standard_concept,
	concept_code,
	valid_start_date,
	valid_end_date,
	invalid_reason
)
values
(
	2000500009,-- concept_id
	'NonPrimaryPathwayProgressionMetastasis',
    'Measurement',
    'OXFORD',
    'Measurement',
    null,
    'NonPrimaryPathwayProgressionMetastasis',
    '1970-01-01',
    '2099-12-31',
    null
);

insert into cdm.concept
(
	concept_id,
	concept_name,
	domain_id,
	vocabulary_id,
	concept_class_id,
	standard_concept,
	concept_code,
	valid_start_date,
	valid_end_date,
	invalid_reason
)
values
(
	2000500010,-- concept_id
	'MCategoryIntegratedStage',
    'Measurement',
    'OXFORD',
    'Measurement',
    null,
    'MCategoryIntegratedStage',
    '1970-01-01',
    '2099-12-31',
    null
);

insert into cdm.concept
(
	concept_id,
	concept_name,
	domain_id,
	vocabulary_id,
	concept_class_id,
	standard_concept,
	concept_code,
	valid_start_date,
	valid_end_date,
	invalid_reason
)
values
(
	2000500011,-- concept_id
	'NCategoryIntegratedStage',
    'Measurement',
    'OXFORD',
    'Measurement',
    null,
    'NCategoryIntegratedStage',
    '1970-01-01',
    '2099-12-31',
    null
);

insert into cdm.concept
(
	concept_id,
	concept_name,
	domain_id,
	vocabulary_id,
	concept_class_id,
	standard_concept,
	concept_code,
	valid_start_date,
	valid_end_date,
	invalid_reason
)
values
(
	2000500012,-- concept_id
	'TCategoryIntegratedStage',
    'Measurement',
    'OXFORD',
    'Measurement',
    null,
    'TCategoryIntegratedStage',
    '1970-01-01',
    '2099-12-31',
    null
);

insert into cdm.concept
(
	concept_id,
	concept_name,
	domain_id,
	vocabulary_id,
	concept_class_id,
	standard_concept,
	concept_code,
	valid_start_date,
	valid_end_date,
	invalid_reason
)
values
(
	2000500013,-- concept_id
	'TNMCategoryIntegratedStage',
    'Measurement',
    'OXFORD',
    'Measurement',
    null,
    'TNMCategoryIntegratedStage',
    '1970-01-01',
    '2099-12-31',
    null
);

insert into cdm.concept
(
	concept_id,
	concept_name,
	domain_id,
	vocabulary_id,
	concept_class_id,
	standard_concept,
	concept_code,
	valid_start_date,
	valid_end_date,
	invalid_reason
)
values
(
	2000500014,-- concept_id
	'MCategoryFinalPreTreatmentStage',
    'Measurement',
    'OXFORD',
    'Measurement',
    null,
    'MCategoryFinalPreTreatmentStage',
    '1970-01-01',
    '2099-12-31',
    null
);

insert into cdm.concept
(
	concept_id,
	concept_name,
	domain_id,
	vocabulary_id,
	concept_class_id,
	standard_concept,
	concept_code,
	valid_start_date,
	valid_end_date,
	invalid_reason
)
values
(
	2000500015,-- concept_id
	'NCategoryFinalPreTreatmentStage',
    'Measurement',
    'OXFORD',
    'Measurement',
    null,
    'NCategoryFinalPreTreatmentStage',
    '1970-01-01',
    '2099-12-31',
    null
);

insert into cdm.concept
(
	concept_id,
	concept_name,
	domain_id,
	vocabulary_id,
	concept_class_id,
	standard_concept,
	concept_code,
	valid_start_date,
	valid_end_date,
	invalid_reason
)
values
(
	2000500016,-- concept_id
	'TCategoryFinalPreTreatmentStage',
    'Measurement',
    'OXFORD',
    'Measurement',
    null,
    'TCategoryFinalPreTreatmentStage',
    '1970-01-01',
    '2099-12-31',
    null
);

insert into cdm.concept
(
	concept_id,
	concept_name,
	domain_id,
	vocabulary_id,
	concept_class_id,
	standard_concept,
	concept_code,
	valid_start_date,
	valid_end_date,
	invalid_reason
)
values
(
	2000500017,-- concept_id
	'TNMCategoryFinalPreTreatmentStage',
    'Measurement',
    'OXFORD',
    'Measurement',
    null,
    'TNMCategoryFinalPreTreatmentStage',
    '1970-01-01',
    '2099-12-31',
    null
);

insert into cdm.concept
(
	concept_id,
	concept_name,
	domain_id,
	vocabulary_id,
	concept_class_id,
	standard_concept,
	concept_code,
	valid_start_date,
	valid_end_date,
	invalid_reason
)
values
(
	2000500018,-- concept_id
	'IntegratedStage',
    'Measurement',
    'OXFORD',
    'Measurement',
    null,
    'IntegratedStage',
    '1970-01-01',
    '2099-12-31',
    null
);

insert into cdm.concept
(
	concept_id,
	concept_name,
	domain_id,
	vocabulary_id,
	concept_class_id,
	standard_concept,
	concept_code,
	valid_start_date,
	valid_end_date,
	invalid_reason
)
values
(
	2000500019,-- concept_id
	'FinalPreTreatmentStage',
    'Measurement',
    'OXFORD',
    'Measurement',
    null,
    'FinalPreTreatmentStage',
    '1970-01-01',
    '2099-12-31',
    null
);",
                cancellationToken);

			_logger.LogInformation("Computing concept maps.");

            await connection.ExecuteAsync(@"
insert into omop_staging.concept_code_map
 (
 	source_concept_code,
	source_concept_id,
 	target_concept_id,
 	source_domain_id,
  target_domain_id,
 	mapped_from_standard
 )
 with InvalidConceptMap as (
 	select
 		c1.concept_code as source_concept_code,
		c1.concept_id as source_concept_id,
		c2.concept_id as target_concept_id,
    c1.domain_id as source_domain_id,
		c2.domain_id as target_domain_id
 	from cdm.concept c1
		inner join cdm.concept_relationship cr
			on c1.concept_id = cr.concept_id_1
 		inner join cdm.concept c2
			on cr.concept_id_2 = c2.concept_id		
 	where not
 		(
 			c1.standard_concept is not null
 			and c1.standard_concept = 'S'
			and current_date between c1.valid_start_date and c1.valid_end_date
 		)
		and cr.relationship_id in ('Maps to', 'Source - RxNorm eq')
 		and c2.standard_concept is not null
 		and c2.standard_concept = 'S'
    	and current_date between c2.valid_start_date and c2.valid_end_date

 ), Mapped as (
 	select -- Valid standard codes that we map to self
 		c.concept_code as source_concept_code,
		c.concept_id as source_concept_id,
 		c.concept_id as target_concept_id,
        c.domain_id as source_domain_id,
        c.domain_id as target_domain_id,
 		1 as mapped_from_standard
 	from cdm.concept c
 	where c.standard_concept is not null
 		and c.standard_concept = 'S'
		and current_date between c.valid_start_date and c.valid_end_date

 	union 

 	select -- Invalid codes that we can map to a standard code
 		icm.source_concept_code,
		icm.source_concept_id,
 		icm.target_concept_id as concept_id,
 		icm.source_domain_id,
		icm.target_domain_id, 
 		0 as mapped_from_standard
 	from InvalidConceptMap icm
 		inner join cdm.concept c
 			on icm.target_concept_id = c.concept_id
 	where icm.target_concept_id is not null
 )

 select
	distinct
		source_concept_code,
		source_concept_id,
 		target_concept_id,
 		source_domain_id,
    target_domain_id,
 		mapped_from_standard
from Mapped;

insert into omop_staging.concept_code_map
(
	source_concept_code,
	source_concept_id,
	target_concept_id,
	source_domain_id,
  target_domain_id,
	mapped_from_standard
)
select
	c.concept_code as source_concept_code,
	c.concept_id as source_concept_id,
	rxnormConcept.concept_id as target_concept_id,
	'Drug' as source_domain_id, 
  'Drug' as target_domain_id,
	1 as mapped_from_standard
from cdm.concept c
	inner join cdm.concept dmdConcept 
		on c.concept_code = dmdConcept.concept_code
	inner join cdm.concept_relationship cr
		on dmdConcept.concept_id = cr.concept_id_1
	inner join cdm.concept rxnormConcept
		on cr.concept_id_2 = rxnormConcept.concept_id
where c.vocabulary_id = 'SNOMED'
	and c.domain_id = 'Drug'
	and not exists (
		select *
		from omop_staging.concept_code_map ccm
		where ccm.source_concept_id = c.concept_id
	)
	and dmdConcept.domain_id = 'Drug'
	and dmdConcept.vocabulary_id = 'dm+d'
	and dmdConcept.concept_class_id = 'VTM'
	and cr.relationship_id = 'Source - RxNorm eq'
	and rxnormConcept.standard_concept = 'S'
	and rxnormConcept.domain_id = 'Drug'
	and rxnormConcept.vocabulary_id in ('RxNorm', 'RxNorm Extension');

insert into omop_staging.concept_code_map
(
  source_concept_code,
  source_concept_id,
  target_concept_id,
  source_domain_id,
  target_domain_id,
  mapped_from_standard
)
select
    c.concept_code,
    c.concept_id,
    null,
    c.domain_id,
    null,
    0
from cdm.concept c
where c.standard_concept is null
  and not exists (
    select *
    from omop_staging.concept_code_map ccm
    where ccm.source_concept_id = c.concept_id
  )
");


            transaction.Commit();
        }
        catch
        {
            transaction.Rollback();

            throw;
        }
    }
}