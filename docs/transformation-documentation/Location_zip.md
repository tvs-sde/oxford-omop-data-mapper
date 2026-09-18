---
layout: default
title: zip
parent: Location
grand_parent: Transformation Documentation
has_toc: false
---
# zip
### SUS Outpatient Location
Source column  `Postcode`.
Uppercase the postcode then insert the space in the correct location, if needed.

* `Postcode` Patient Postcode [POSTCODE](https://www.datadictionary.nhs.uk/data_elements/postcode.html)

```sql
	select
		distinct
			Postcode,
			Country,
			NHSNumber
	from omop_staging.sus_OP
	where NHSNumber is not null
		and Postcode is not null
		and AttendedorDidNotAttend in ('5','6')
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Location%20table%20zip%20field%20SUS%20Outpatient%20Location%20mapping){: .btn }
### SUS Inpatient Location
Source column  `Postcode`.
Uppercase the postcode then insert the space in the correct location, if needed.

* `Postcode` Patient Postcode [POSTCODE](https://www.datadictionary.nhs.uk/data_elements/postcode.html)

```sql
select
	distinct
		Postcode,
		NHSNumber
from omop_staging.sus_APC
where Postcode is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Location%20table%20zip%20field%20SUS%20Inpatient%20Location%20mapping){: .btn }
### SUS A&E Location
Source column  `Postcode`.
Uppercase the postcode then insert the space in the correct location, if needed.

* `Postcode` Patient Postcode [POSTCODE](https://www.datadictionary.nhs.uk/data_elements/postcode.html)

```sql
select
	distinct
		Postcode,
		NHSNumber
from omop_staging.sus_AE
where Postcode is not null
and NHSNumber is not null
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Location%20table%20zip%20field%20SUS%20A&E%20Location%20mapping){: .btn }
### SACT Location
Source column  `Patient_Postcode`.
Uppercase the postcode then insert the space in the correct location, if needed.

* `Patient_Postcode` Patient's Postcode. [POSTCODE](https://www.datadictionary.nhs.uk/data_elements/postcode.html)

```sql
select
	NHS_Number,
	max (Patient_Postcode) as Patient_Postcode,
	max (Date_Of_Birth) as Date_Of_Birth
from omop_staging.sact_staging
group by NHS_Number
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Location%20table%20zip%20field%20SACT%20Location%20mapping){: .btn }
### Rtds PAS Location
Source column  `FirstOfPOSTCODE`.
Uppercase the postcode then insert the space in the correct location, if needed.

* `FirstOfPOSTCODE` Patient's Postcode. [POSTCODE](https://www.datadictionary.nhs.uk/data_elements/postcode.html)

```sql
select
	distinct
		p.FirstOfNHSNUMBER,
		p.FirstOfPOSTCODE
from omop_staging.RTDS_PASDATA p
where p.FirstOfPOSTCODE is not null
	and p.FirstOfNHSNUMBER is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Location%20table%20zip%20field%20Rtds%20PAS%20Location%20mapping){: .btn }
### Oxford GP Location
Source column  `Postcode`.
Uppercase the postcode then insert the space in the correct location, if needed.

* `Postcode` Patient Postcode [POSTCODE](https://www.datadictionary.nhs.uk/data_elements/postcode.html)

```sql
select
	distinct
		NHSNumber,
		Postcode
from omop_staging.oxford_gp_demographic
where Postcode is not null
order by
	NHSNumber,
	Postcode
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Location%20table%20zip%20field%20Oxford%20GP%20Location%20mapping){: .btn }
### COSD Demographics
Source column  `Postcode`.
Uppercase the postcode then insert the space in the correct location, if needed.

* `Postcode` Patient Postcode [POSTCODE OF USUAL ADDRESS (AT DIAGNOSIS)](https://www.datadictionary.nhs.uk/data_elements/postcode_of_usual_address__at_diagnosis_.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Location%20table%20zip%20field%20COSD%20Demographics%20mapping){: .btn }
### COSD Demographics v8
Source column  `Postcode`.
Uppercase the postcode then insert the space in the correct location, if needed.

* `Postcode` Patient Postcode [POSTCODE OF USUAL ADDRESS (AT DIAGNOSIS)](https://www.datadictionary.nhs.uk/data_elements/postcode_of_usual_address__at_diagnosis_.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Location%20table%20zip%20field%20COSD%20Demographics%20v8%20mapping){: .btn }
