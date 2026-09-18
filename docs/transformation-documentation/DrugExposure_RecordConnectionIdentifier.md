---
layout: default
title: RecordConnectionIdentifier
parent: DrugExposure
grand_parent: Transformation Documentation
has_toc: false
---
# RecordConnectionIdentifier
### Oxford Prescribing Drug Exposure
* Value copied from `EVENT_ID`

* `EVENT_ID` Unique identifier 

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20DrugExposure%20table%20RecordConnectionIdentifier%20field%20Oxford%20Prescribing%20Drug%20Exposure%20mapping){: .btn }
### Oxford Prescribing Drug Exposure (with Snomed)
* Value copied from `EVENT_ID`

* `EVENT_ID` The unique ID of the Event 

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20DrugExposure%20table%20RecordConnectionIdentifier%20field%20Oxford%20Prescribing%20Drug%20Exposure%20(with%20Snomed)%20mapping){: .btn }
