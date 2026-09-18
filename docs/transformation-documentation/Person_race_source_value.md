---
layout: default
title: race_source_value
parent: Person
grand_parent: Transformation Documentation
has_toc: false
---
# race_source_value
### SUS Outpatient Person
* Value copied from `EthnicCategory`

* `EthnicCategory` Patient EthnicCategory [ETHNIC CATEGORY](https://www.datadictionary.nhs.uk/data_elements/ethnic_category.html)

```sql
	select
		NHSNumber,
		max(DateofBirth) as DateOfBirth,
		max(EthnicCategory) as EthnicCategory,
		max(Sex) as PersonCurrentGenderCode
	from omop_staging.sus_OP
	where NHSNumber is not null
	group by NHSNumber
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Person%20table%20race_source_value%20field%20SUS%20Outpatient%20Person%20mapping){: .btn }
### SUS Inpatient Person
* Value copied from `EthnicCategory`

* `EthnicCategory` Patient EthnicCategory [ETHNIC CATEGORY](https://www.datadictionary.nhs.uk/data_elements/ethnic_category.html)

```sql
	select
		NHSNumber,
		max(DateofBirth) as DateOfBirth,
		max(EthnicGroup) as EthnicCategory,
		max(Sex) as PersonCurrentGenderCode
	from omop_staging.sus_APC
	where NHSNumber is not null
	group by NHSNumber
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Person%20table%20race_source_value%20field%20SUS%20Inpatient%20Person%20mapping){: .btn }
### SUS A&E Person
* Value copied from `EthnicCategory`

* `EthnicCategory` Patient EthnicCategory [ETHNIC CATEGORY](https://www.datadictionary.nhs.uk/data_elements/ethnic_category.html)

```sql
	select
		NHSNumber,
		max(DateofBirth) as DateOfBirth,
		max(EthnicCategory) as EthnicCategory,
		max(Sex) as PersonCurrentGenderCode
	from omop_staging.sus_AE
	where NHSNumber is not null
	group by NHSNumber
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Person%20table%20race_source_value%20field%20SUS%20A&E%20Person%20mapping){: .btn }
### COSD Demographics
* Value copied from `EthnicCategory`

* `EthnicCategory` Patient EthnicCategory [ETHNIC CATEGORY](https://www.datadictionary.nhs.uk/data_elements/ethnic_category.html)

```sql
with demographics as (
select 
  Record ->> '$..NhsNumber..@extension' ->> 0 as NhsNumber,
  Record ->> '$..PersonBirthDate' ->> 0 as DateOfBirth,
  Record ->> '$..StreetAddressLine[0].#cdata-section' ->> 0 as StreetAddressLine1,
  Record ->> '$..StreetAddressLine[1].#cdata-section' ->> 0 as StreetAddressLine2,
  Record ->> '$..StreetAddressLine[2].#cdata-section' ->> 0 as StreetAddressLine3,
  Record ->> '$..StreetAddressLine[3].#cdata-section' ->> 0 as StreetAddressLine4,
  Record ->> '$..PostcodeOfUsualAddressAtDiagnosis' ->> 0 as Postcode,
  Record ->> '$..EthnicCategory.@code' ->> 0 as EthnicCategory
from omop_staging.cosd_staging_901
)
select
	NhsNumber,
	max (DateOfBirth) as DateOfBirth,
	max (StreetAddressLine1) as StreetAddressLine1,
	max (StreetAddressLine2) as StreetAddressLine2,
	max (StreetAddressLine3) as StreetAddressLine3,
	max (StreetAddressLine4) as StreetAddressLine4,
	max (Postcode) as Postcode
from demographics 
where NhsNumber is not null
group by NhsNumber
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Person%20table%20race_source_value%20field%20COSD%20Demographics%20mapping){: .btn }
