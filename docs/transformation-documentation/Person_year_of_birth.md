---
layout: default
title: year_of_birth
parent: Person
grand_parent: Transformation Documentation
has_toc: false
---
# year_of_birth
### SUS Outpatient Person
Source column  `DateOfBirth`.
Selects the year from a date or null of the date is null.

* `DateOfBirth` Patient's date of birth. [PERSON BIRTH DATE](https://www.datadictionary.nhs.uk/data_elements/person_birth_date.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Person%20table%20year_of_birth%20field%20SUS%20Outpatient%20Person%20mapping){: .btn }
### SUS Inpatient Person
Source column  `DateOfBirth`.
Selects the year from a date or null of the date is null.

* `DateOfBirth` Patient's date of birth. [PERSON BIRTH DATE](https://www.datadictionary.nhs.uk/data_elements/person_birth_date.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Person%20table%20year_of_birth%20field%20SUS%20Inpatient%20Person%20mapping){: .btn }
### SUS A&E Person
Source column  `DateOfBirth`.
Selects the year from a date or null of the date is null.

* `DateOfBirth` Patient's date of birth. [PERSON BIRTH DATE](https://www.datadictionary.nhs.uk/data_elements/person_birth_date.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Person%20table%20year_of_birth%20field%20SUS%20A&E%20Person%20mapping){: .btn }
### SACT Person
Source column  `Date_Of_Birth`.
Selects the year from a date or null of the date is null.

* `Date_Of_Birth` Patient's date of birth. [PERSON BIRTH DATE](https://www.datadictionary.nhs.uk/data_elements/person_birth_date.html)

```sql
	select
		NHS_Number,
		max (Date_Of_Birth) as Date_Of_Birth,
		max (Person_Stated_Gender_Code) as Person_Stated_Gender_Code
	from omop_staging.sact_staging
	group by NHS_Number
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Person%20table%20year_of_birth%20field%20SACT%20Person%20mapping){: .btn }
### Rtds Person
Source column  `DateOfBirth`.
Selects the year from a date or null of the date is null.

* `DateOfBirth` Patient's date of birth. [PERSON BIRTH DATE](https://www.datadictionary.nhs.uk/data_elements/person_birth_date.html)

```sql
select
	PatientId,
	max (DateOfBirth) as DateOfBirth,
	max (Sex) as Sex
from omop_staging.RTDS_1_Demographics d
where PatientId is not null
group by PatientId
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Person%20table%20year_of_birth%20field%20Rtds%20Person%20mapping){: .btn }
### Oxford GP Person
Source column  `DOB`.
Selects the year from a date or null of the date is null.

* `DOB` Patient's date of birth. [PERSON BIRTH DATE](https://www.datadictionary.nhs.uk/data_elements/person_birth_date.html)

```sql
select
	distinct
		NHSNumber,
		DOB
from omop_staging.oxford_gp_demographic
order by
	NHSNumber,
	DOB
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Person%20table%20year_of_birth%20field%20Oxford%20GP%20Person%20mapping){: .btn }
### COSD Demographics
Source column  `DateOfBirth`.
Selects the year from a date or null of the date is null.

* `DateOfBirth` Patient's date of birth. [PERSON BIRTH DATE](https://www.datadictionary.nhs.uk/data_elements/person_birth_date.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Person%20table%20year_of_birth%20field%20COSD%20Demographics%20mapping){: .btn }
### COSD Demographics v8
Source column  `DateOfBirth`.
Selects the year from a date or null of the date is null.

* `DateOfBirth` Patient's date of birth. [PERSON BIRTH DATE](https://www.datadictionary.nhs.uk/data_elements/person_birth_date.html)

```sql
with demographics as (
select 
  Record ->> '$..NHSNumber..@extension' ->> 0 as NhsNumber,
  Record ->> '$..Birthdate' ->> 0 as DateOfBirth,
  Record ->> '$..streetAddressLine[0].#cdata-section' ->> 0 as StreetAddressLine1,
  Record ->> '$..streetAddressLine[1].#cdata-section' ->> 0 as StreetAddressLine2,
  Record ->> '$..streetAddressLine[2].#cdata-section' ->> 0 as StreetAddressLine3,
  Record ->> '$..streetAddressLine[3].#cdata-section' ->> 0 as StreetAddressLine4,
  Record ->> '$..Postcode.postalCode' -> 0 as Postcode,
from omop_staging.cosd_staging_81
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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Person%20table%20year_of_birth%20field%20COSD%20Demographics%20v8%20mapping){: .btn }
