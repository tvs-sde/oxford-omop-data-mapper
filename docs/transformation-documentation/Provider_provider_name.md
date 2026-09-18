---
layout: default
title: provider_name
parent: Provider
grand_parent: Transformation Documentation
has_toc: false
---
# provider_name
### SACT Provider
* Value copied from `Consultant_GMC_Code`

* `Consultant_GMC_Code` A unique code identifying a care professional [CONSULTANT GMC CODE]()

```sql
	select distinct 
		Consultant_GMC_Code, 
		Consultant_Specialty_Code
	from omop_staging.sact_staging
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Provider%20table%20provider_name%20field%20SACT%20Provider%20mapping){: .btn }
### RTDS Provider
* Value copied from `DoctorId`

* `DoctorId` This GENERAL MEDICAL PRACTITIONER works within the General Medical Practitioner Practice with which the PATIENT is registered. [GENERAL MEDICAL PRACTITIONER (SPECIFIED)](https://www.datadictionary.nhs.uk/data_elements/general_medical_practitioner__specified_.html)

```sql
		select distinct 
			DoctorId 
		from omop_staging.RTDS_1_Demographics 
		where DoctorId is not null
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Provider%20table%20provider_name%20field%20RTDS%20Provider%20mapping){: .btn }
