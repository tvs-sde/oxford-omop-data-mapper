---
layout: default
title: dose_unit_source_value
parent: DrugExposure
grand_parent: Transformation Documentation
has_toc: false
---
# dose_unit_source_value
### SACT Drug Exposure
Source column  `Administration_Measurement_Per_Actual_Dose`.
The UNIT OF MEASUREMENT used for each Systemic Anti-Cancer Therapy Drug Administration in a Systemic Anti-Cancer Therapy Drug Cycle.


|Administration_Measurement_Per_Actual_Dose|dose_unit_source_value|notes|
|------|-----|-----|
|1|Milligrams (mg)||
|2|Micrograms (Mcg)||
|01|Milligrams (mg)||
|02|Micrograms (Mcg)||
|03|Grams (g)||
|04|Units||
|05|Cells||
|06|Plaque Forming Units (PFU) (one million) (x10^6)||
|07|Plaque Forming Units (PFU) (one hundred million) (x10^8)||
|98|Other (not listed)||


* `Administration_Measurement_Per_Actual_Dose` The UNIT OF MEASUREMENT used for each Systemic Anti-Cancer Therapy Drug Administration in a Systemic Anti-Cancer Therapy Drug Cycle. [UNIT OF MEASUREMENT (SYSTEMIC ANTI-CANCER THERAPY)](https://www.datadictionary.nhs.uk/data_elements/unit_of_measurement__systemic_anti-cancer_therapy_.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20DrugExposure%20table%20dose_unit_source_value%20field%20SACT%20Drug%20Exposure%20mapping){: .btn }
### Oxford Prescribing Drug Exposure
* Value copied from `strengthdoseunit`

* `strengthdoseunit` The unit of the drug dose 

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20DrugExposure%20table%20dose_unit_source_value%20field%20Oxford%20Prescribing%20Drug%20Exposure%20mapping){: .btn }
### Oxford Prescribing Drug Exposure (with Snomed)
* Value copied from `strengthdoseunit`

* `strengthdoseunit` The unit of the drug dose 

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20DrugExposure%20table%20dose_unit_source_value%20field%20Oxford%20Prescribing%20Drug%20Exposure%20(with%20Snomed)%20mapping){: .btn }
### Oxford GP Drug Exposure
* Value copied from `Units`

* `Units` Units of the medication supplied 

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20DrugExposure%20table%20dose_unit_source_value%20field%20Oxford%20GP%20Drug%20Exposure%20mapping){: .btn }
