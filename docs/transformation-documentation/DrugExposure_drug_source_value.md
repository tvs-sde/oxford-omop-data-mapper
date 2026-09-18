---
layout: default
title: drug_source_value
parent: DrugExposure
grand_parent: Transformation Documentation
has_toc: false
---
# drug_source_value
### SACT Drug Exposure
* Value copied from `Drug_Name`

* `Drug_Name` The name of the Systemic Anti-Cancer Therapy drug given to a PATIENT during an Systemic Anti-Cancer Therapy Drug Regimen. [SYSTEMIC ANTI-CANCER THERAPY DRUG NAME](https://www.datadictionary.nhs.uk/data_elements/systemic_anti-cancer_therapy_drug_name.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20DrugExposure%20table%20drug_source_value%20field%20SACT%20Drug%20Exposure%20mapping){: .btn }
### Oxford Prescribing Drug Exposure
* Value copied from `order_mnemonic`

* `order_mnemonic` The mnemonic of the prescribed drug item as showing in the order screen as selected by the clinician 

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20DrugExposure%20table%20drug_source_value%20field%20Oxford%20Prescribing%20Drug%20Exposure%20mapping){: .btn }
### Oxford Prescribing Drug Exposure (with Snomed)
* Value copied from `order_mnemonic`

* `order_mnemonic` All the prescribed drug item details as shown in the order screen as selected by the clinician 

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20DrugExposure%20table%20drug_source_value%20field%20Oxford%20Prescribing%20Drug%20Exposure%20(with%20Snomed)%20mapping){: .btn }
### Oxford GP Drug Exposure
* Value copied from `SuppliedCode`

* `SuppliedCode` Supplied SNOMED Code 

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20DrugExposure%20table%20drug_source_value%20field%20Oxford%20GP%20Drug%20Exposure%20mapping){: .btn }
