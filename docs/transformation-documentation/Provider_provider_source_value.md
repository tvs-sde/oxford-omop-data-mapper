---
layout: default
title: provider_source_value
parent: Provider
grand_parent: Transformation Documentation
has_toc: false
---
# provider_source_value
### SUS Outpatient Provider
* Value copied from `ConsultantCode`

* `ConsultantCode` A unique code identifying a care professional [CONSULTANT CODE](https://www.datadictionary.nhs.uk/data_elements/consultant_code.html)

```sql
with counts as (
	select 
		ConsultantCode,
		MainSpecialtyCode,
		count(*) as SpecialtyFrequency,
		row_number() over (partition by ConsultantCode order by count(*) desc, MainSpecialtyCode
) rnk
from (
	select
	ConsultantCode,
	MainSpecialtyCode
	from omop_staging.sus_OP 
	where MainSpecialtyCode is not null
	and ConsultantCode is not null
) grouped
	group by ConsultantCode, MainSpecialtyCode
)
select 
	ConsultantCode,
	MainSpecialtyCode
from counts
where rnk = 1
order by
	ConsultantCode,
	MainSpecialtyCode
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Provider%20table%20provider_source_value%20field%20SUS%20Outpatient%20Provider%20mapping){: .btn }
### SUS Inpatient Provider
* Value copied from `ConsultantCode`

* `ConsultantCode` A unique code identifying a care professional [CONSULTANT CODE](https://www.datadictionary.nhs.uk/data_elements/consultant_code.html)

```sql
with counts as (
	select 
		ConsultantCode,
		MainSpecialtyCode,
		count(*) as SpecialtyFrequency,
		row_number() over (partition by ConsultantCode order by count(*) desc, 
		MainSpecialtyCode
) 
rnk
from 
(
	select
		ConsultantCode,
		MainSpecialtyCode
	from omop_staging.sus_APC
	where MainSpecialtyCode is not null
		and ConsultantCode is not null
) grouped
	group by ConsultantCode, MainSpecialtyCode
)
select 
	ConsultantCode,
	MainSpecialtyCode
from counts
where rnk = 1
order by 
	ConsultantCode,
	MainSpecialtyCode
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Provider%20table%20provider_source_value%20field%20SUS%20Inpatient%20Provider%20mapping){: .btn }
### SACT Provider
* Value copied from `Consultant_GMC_Code`

* `Consultant_GMC_Code` A unique code identifying a care professional [CONSULTANT GMC CODE]()

```sql
	select distinct 
		Consultant_GMC_Code, 
		Consultant_Specialty_Code
	from omop_staging.sact_staging
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Provider%20table%20provider_source_value%20field%20SACT%20Provider%20mapping){: .btn }
### RTDS Provider
* Value copied from `DoctorId`

* `DoctorId` This GENERAL MEDICAL PRACTITIONER works within the General Medical Practitioner Practice with which the PATIENT is registered. [GENERAL MEDICAL PRACTITIONER (SPECIFIED)](https://www.datadictionary.nhs.uk/data_elements/general_medical_practitioner__specified_.html)

```sql
		select distinct 
			DoctorId 
		from omop_staging.RTDS_1_Demographics 
		where DoctorId is not null
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Provider%20table%20provider_source_value%20field%20RTDS%20Provider%20mapping){: .btn }
