---
layout: default
title: nhs_number
parent: DrugExposure
grand_parent: Transformation Documentation
has_toc: false
---
# nhs_number
### SACT Drug Exposure
* Value copied from `NHS_Number`

* `NHS_Number` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

```sql
	select
		distinct
		replace(NHS_Number, ' ', '') as NHS_Number,
		Regimen,
		lower(Drug_Name) as Drug_Name,
		Actual_Dose_Per_Administration,
		Administration_Measurement_Per_Actual_Dose,
		Administration_Date
	from omop_staging.sact_staging
	
```


[Comment or raise an issue for this mapping.](https://github.com/tvs-sde/oxford-omop-data-mapper/issues/new?title=OMOP%20DrugExposure%20table%20nhs_number%20field%20SACT%20Drug%20Exposure%20mapping){: .btn }
### SNOMED CT procedures mapped to single-day Drug Exposure from databricks_procedures.parquet.
* Value copied from `patient_identifier_value`

* `patient_identifier_value` Patient NHS number, used to join existing OMOP Person records.

```sql
select
    patient_identifier_value,
    clinical_date,
    clinical_datetime,
    clinical_code,
    trim(clinical_code) as concept_code
from ##duckdb_source##
where upper(trim(clinical_code_system)) = 'SNOMED CT'
```


[Comment or raise an issue for this mapping.](https://github.com/tvs-sde/oxford-omop-data-mapper/issues/new?title=OMOP%20DrugExposure%20table%20nhs_number%20field%20SNOMED%20CT%20procedures%20mapped%20to%20single-day%20Drug%20Exposure%20from%20databricks_procedures.parquet.%20mapping){: .btn }
### OPCS4 procedures mapped to single-day Drug Exposure from databricks_procedures.parquet.
* Value copied from `patient_identifier_value`

* `patient_identifier_value` Patient NHS number, used to join existing OMOP Person records.

```sql
select
    patient_identifier_value,
    clinical_date,
    clinical_datetime,
    clinical_code,
    replace(upper(trim(clinical_code)), '.', '') as concept_code
from ##duckdb_source##
where upper(trim(clinical_code_system)) = 'OPCS4'
```


[Comment or raise an issue for this mapping.](https://github.com/tvs-sde/oxford-omop-data-mapper/issues/new?title=OMOP%20DrugExposure%20table%20nhs_number%20field%20OPCS4%20procedures%20mapped%20to%20single-day%20Drug%20Exposure%20from%20databricks_procedures.parquet.%20mapping){: .btn }
### Oxford Prescribing Drug Exposure
* Value copied from `patient_identifier_Value`

* `patient_identifier_Value` Patient NHS Number 

```sql
select
	patient_identifier_Value,
	beg_dt_tm,
	end_dt_tm,
	lower(replace(catalog, 'zzz', '')) as catalog,
	lower(order_mnemonic) as order_mnemonic,
	order_detail_display_line,
	lower(rxroute) as rxroute,
	strengthdoseunit,
	strengthdose,
	EVENT_ID
from ##duckdb_source##
where concept_identifier is null or
TRY_CAST(TRIM(concept_identifier) AS INTEGER) = 0
```


[Comment or raise an issue for this mapping.](https://github.com/tvs-sde/oxford-omop-data-mapper/issues/new?title=OMOP%20DrugExposure%20table%20nhs_number%20field%20Oxford%20Prescribing%20Drug%20Exposure%20mapping){: .btn }
### Oxford Prescribing Drug Exposure (with Snomed)
* Value copied from `patient_identifier_Value`

* `patient_identifier_Value` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

```sql
select
	patient_identifier_Value,
	beg_dt_tm,
	end_dt_tm,
	order_detail_display_line,
	order_mnemonic,
	lower(rxroute) as rxroute,
	strengthdoseunit,
	strengthdose,
	concept_identifier,
	EVENT_ID
from ##duckdb_source##
where concept_identifier is not null
```


[Comment or raise an issue for this mapping.](https://github.com/tvs-sde/oxford-omop-data-mapper/issues/new?title=OMOP%20DrugExposure%20table%20nhs_number%20field%20Oxford%20Prescribing%20Drug%20Exposure%20(with%20Snomed)%20mapping){: .btn }
### Oxford GP Drug Exposure
* Value copied from `NHSNumber`

* `NHSNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

```sql
select
	distinct
		d.NHSNumber,
		e.LastIssueDate,
		e.SuppliedCode,
		e.Quantity,
		e.Units
	from omop_staging.oxford_gp_medication e
		inner join omop_staging.oxford_gp_demographic d
			on e.PatientIdentifier = d.PatientIdentifier
	order by
		d.NHSNumber,
		e.LastIssueDate,
		e.SuppliedCode,
		e.Quantity,
		e.Units
	
```


[Comment or raise an issue for this mapping.](https://github.com/tvs-sde/oxford-omop-data-mapper/issues/new?title=OMOP%20DrugExposure%20table%20nhs_number%20field%20Oxford%20GP%20Drug%20Exposure%20mapping){: .btn }
