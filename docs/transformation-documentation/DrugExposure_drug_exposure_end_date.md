---
layout: default
title: drug_exposure_end_date
parent: DrugExposure
grand_parent: Transformation Documentation
has_toc: false
---
# drug_exposure_end_date
### SACT Drug Exposure
Source column  `Administration_Date`.
Converts text to dates.

* `Administration_Date` SYSTEMIC ANTI-CANCER THERAPY ADMINISTRATION DATE is the date of the Systemic Anti-Cancer Therapy Drug Administration or the date an oral drug was initially dispensed to the PATIENT. [SYSTEMIC ANTI-CANCER THERAPY ADMINISTRATION DATE](https://www.datadictionary.nhs.uk/data_elements/systemic_anti-cancer_therapy_administration_date.html)

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


[Comment or raise an issue for this mapping.](https://github.com/tvs-sde/oxford-omop-data-mapper/issues/new?title=OMOP%20DrugExposure%20table%20drug_exposure_end_date%20field%20SACT%20Drug%20Exposure%20mapping){: .btn }
### SNOMED CT procedures mapped to single-day Drug Exposure from databricks_procedures.parquet.
Source column  `clinical_date`.
Converts text to dates.
* Single-day exposure: the clinical date supplies the required end date; no duration is available.

* `clinical_date` Clinical drug exposure date. Used for both start and required end date as a single-day exposure. 

```sql
select
    patient_identifier_value,
    clinical_date,
    clinical_datetime,
    clinical_code,
    trim(clinical_code) as concept_code
from ##duckdb_source##
where upper(trim(clinical_code_system)) = 'SNOMED CT'
order by all
```


[Comment or raise an issue for this mapping.](https://github.com/tvs-sde/oxford-omop-data-mapper/issues/new?title=OMOP%20DrugExposure%20table%20drug_exposure_end_date%20field%20SNOMED%20CT%20procedures%20mapped%20to%20single-day%20Drug%20Exposure%20from%20databricks_procedures.parquet.%20mapping){: .btn }
### OPCS4 procedures mapped to single-day Drug Exposure from databricks_procedures.parquet.
Source column  `clinical_date`.
Converts text to dates.
* Single-day exposure: the clinical date supplies the required end date; no duration is available.

* `clinical_date` Clinical drug exposure date. Used for both start and required end date as a single-day exposure. 

```sql
select
    patient_identifier_value,
    clinical_date,
    clinical_datetime,
    clinical_code,
    replace(upper(trim(clinical_code)), '.', '') as concept_code
from ##duckdb_source##
where upper(trim(clinical_code_system)) = 'OPCS4'
order by all
```


[Comment or raise an issue for this mapping.](https://github.com/tvs-sde/oxford-omop-data-mapper/issues/new?title=OMOP%20DrugExposure%20table%20drug_exposure_end_date%20field%20OPCS4%20procedures%20mapped%20to%20single-day%20Drug%20Exposure%20from%20databricks_procedures.parquet.%20mapping){: .btn }
### Oxford Prescribing Drug Exposure
Source column  `end_dt_tm`.
Converts text to dates.

* `end_dt_tm` The end date of the Drug that was initially dispensed to the PATIENT. 

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
order by all
```


[Comment or raise an issue for this mapping.](https://github.com/tvs-sde/oxford-omop-data-mapper/issues/new?title=OMOP%20DrugExposure%20table%20drug_exposure_end_date%20field%20Oxford%20Prescribing%20Drug%20Exposure%20mapping){: .btn }
### Oxford Prescribing Drug Exposure (with Snomed)
Source column  `end_dt_tm`.
Converts text to dates.

* `end_dt_tm` The end date of the Drug that was initially dispensed to the PATIENT. 

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
order by all
```


[Comment or raise an issue for this mapping.](https://github.com/tvs-sde/oxford-omop-data-mapper/issues/new?title=OMOP%20DrugExposure%20table%20drug_exposure_end_date%20field%20Oxford%20Prescribing%20Drug%20Exposure%20(with%20Snomed)%20mapping){: .btn }
### Oxford GP Drug Exposure
Source column  `LastIssueDate`.
Converts text to dates.

* `LastIssueDate` Last Issue Date 

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


[Comment or raise an issue for this mapping.](https://github.com/tvs-sde/oxford-omop-data-mapper/issues/new?title=OMOP%20DrugExposure%20table%20drug_exposure_end_date%20field%20Oxford%20GP%20Drug%20Exposure%20mapping){: .btn }
