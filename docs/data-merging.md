---
layout: default
title: Data Merging
nav_order: 8
---

# Data merging logic

When OMOP records are recorded some records must be merged. An example of this would be if we detected patient is more than one data source.

In some cases we may partially record a record with the hope of detecting the missing information in later transformations. For example if we have a person data source that does not define the patient's gender. 

If all data is transformed and incomplete records still exist, use the [`finalise command`]({% link docs/user-guide/commands.md %}#finalise-command). 

## Person

| Column | Merging rule |
|--------|-------------|
| gender_concept_id | If new value is not null, set it |
| year_of_birth | If new value is not null, set it |
| month_of_birth | If new value is not null, set it |
| day_of_birth | If new value is not null, set it |
| birth_datetime | If new value is not null, set it |
| race_concept_id | If new value is not null, set it |
| ethnicity_concept_id | If new value is not null, set it |
| location_id | If new value is not null, set it |
| provider_id | If new value is not null, set it |
| care_site_id | If new value is not null, set it |
| person_source_value | If new value is not null, set it |
| gender_source_value | If new value is not null, set it |
| gender_source_concept_id | If new value is not null, set it |
| race_source_value | If new value is not null, set it |
| race_source_concept_id | If new value is not null, set it |
| ethnicity_source_value | If new value is not null, set it |
| ethnicity_source_concept_id | If new value is not null, set it |

### Remarks

* If two records are related to the same person, the fields related to that person such as gender are populated based on last record wins. For example if one record says gender is Male and the next record says gender is Female, we overwrite the gender to be Female.
* However if the second value says gender is null, we would not overwrite the gender.
* The order in which data is loaded will define what the 'final' value of fields like gender.

## Location

Merging logic is not needed as we only record unique locations. If the location already exists in the `location` table, do not record it. We never update records in this table.

## Condition Occurrence

Merging logic depends upon the data source.

|Data source|Logic|
|-----------|-----|
| SUS | Record the record if it does not already exist using the following columns as keys `person_id`, `RecordConnectionIdentifier` and `condition_concept_id`. |
| COSD | Record the record if it does not already exist using the following columns as keys `person_id`, `condition_concept_id` and `condition_start_date`. |

## Death

Merging logic is not needed. If a patient was recorded to have died then no futher records will be recorded.

## Drug Exposure

Merging logic depends upon the data source.

|Data source|Logic|
|-----------|-----|
| SUS | Record the record if it does not already exist using the following columns as keys `RecordConnectionIdentifier` and `drug_concept_id`. |

## Observation

Merging logic depends upon the data source.

|Data source|Logic|
|-----------|-----|
| SUS | Record the record if it does not already exist using the following columns as keys `RecordConnectionIdentifier`, `HospitalProviderSpellNumber`, `observation_date` and `observation_concept_id`. |

## Procedure Occurrence

Merging logic depends upon the data source.

|Data source|Logic|
|-----------|-----|
| SUS | Record the record if it does not already exist using the following columns as keys `RecordConnectionIdentifier`, `procedure_date` and `procedure_concept_id`. |
| COSD | Record the record if it does not already exist using the following columns as keys `procedure_date` and `procedure_concept_id`. |

## Visit Occurrence

Merging logic depends upon the data source.

|Data source|Logic|
|-----------|-----|
| SUS | Record the record if it does not already exist using the following columns as keys `RecordConnectionIdentifier`, `HospitalProviderSpellNumber` and `person_id`. |

### Remarks

If a record already exists for one of the following keys `RecordConnectionIdentifier`, `HospitalProviderSpellNumber` for a particular patient then use the earliest start date amd the latest end date of the record pair.

## Visit Detail

Merging logic depends upon the data source.

|Data source|Logic|
|-----------|-----|
| SUS | Record the record if it does not already exist using the following columns as keys `RecordConnectionIdentifier`, `HospitalProviderSpellNumber` and `person_id`. |

## Measurements

Merging logic depends upon the data source.

|Data source|Logic|
|-----------|-----|
| COSD | Record the record if it does not already exist using the following columns as keys `measurement_date`, `measurement_concept_id`, `measurement_source_concept_id` and `person_id`. |