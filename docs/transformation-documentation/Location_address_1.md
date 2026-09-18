---
layout: default
title: address_1
parent: Location
grand_parent: Transformation Documentation
has_toc: false
---
# address_1
### COSD Demographics
Source column  `StreetAddressLine1`.
Convert text to uppercase. Trim whitespace.

* `StreetAddressLine1` The first line of the address. [PATIENT USUAL ADDRESS (AT DIAGNOSIS)](https://www.datadictionary.nhs.uk/data_elements/patient_usual_address__at_diagnosis_.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Location%20table%20address_1%20field%20COSD%20Demographics%20mapping){: .btn }
### COSD Demographics v8
Source column  `StreetAddressLine1`.
Convert text to uppercase. Trim whitespace.

* `StreetAddressLine1` The first line of the address. [PATIENT USUAL ADDRESS (AT DIAGNOSIS)](https://www.datadictionary.nhs.uk/data_elements/patient_usual_address__at_diagnosis_.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Location%20table%20address_1%20field%20COSD%20Demographics%20v8%20mapping){: .btn }
