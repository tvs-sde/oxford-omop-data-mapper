---
layout: default
title: race_concept_id
parent: Person
grand_parent: Transformation Documentation
has_toc: false
---
# race_concept_id
### SUS Outpatient Person
Source column  `EthnicCategory`.
Lookup race concept.


|EthnicCategory|race_concept_id|notes|
|------|-----|-----|
|A|8527|White - British|
|B|8527|White - Irish|
|C|8527|White - Any other White background|
|D|8527|Mixed - White and Black Caribbean [Athena mapping](https://athena.ohdsi.org/search-terms/terms/700388)|
|E|8527|Mixed - White and Black African [Athena mapping](https://athena.ohdsi.org/search-terms/terms/700389)|
|F|8527|Mixed - White and Asian [Athena mapping](https://athena.ohdsi.org/search-terms/terms/700390)|
|G|8527|Mixed - Any other mixed background [Athena mapping](https://athena.ohdsi.org/search-terms/terms/700391)|
|H|38003574|Asian or Asian British - Indian|
|J|38003589|Asian or Asian British - Pakistani|
|K|38003575|Asian or Asian British - Bangladeshi|
|L|8515|Asian or Asian British - Any other Asian background|
|M|38003598|Black or Black British - Caribbean|
|N|38003600|Black or Black British - African|
|P|38003598|Black or Black British - Any other Black background|
|R|38003579|Other Ethnic Groups - Chinese|
|S|0|Other Ethnic Groups - Any other ethnic group|
|Z|0|Not stated|
|99|0|Not known|
||0|No data|

Notes
* [NHS Race (i.e.Ethnicity)](https://www.datadictionary.nhs.uk/data_elements/ethnic_category.html)
* [OMOP Race](https://athena.ohdsi.org/search-terms/terms?conceptClass=Race&invalidReason=Valid&vocabulary=Race&page=1&pageSize=50&query=)
* [D, E, F, G Race mapping](https://forums.ohdsi.org/t/mapping-nhs-ethnic-category-to-omop-race/20883/2)

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


[Comment or raise an issue for this mapping.](https://github.com/tvs-sde/oxford-omop-data-mapper/issues/new?title=OMOP%20Person%20table%20race_concept_id%20field%20SUS%20Outpatient%20Person%20mapping){: .btn }
### SUS Inpatient Person
Source column  `EthnicCategory`.
Lookup race concept.


|EthnicCategory|race_concept_id|notes|
|------|-----|-----|
|A|8527|White - British|
|B|8527|White - Irish|
|C|8527|White - Any other White background|
|D|8527|Mixed - White and Black Caribbean [Athena mapping](https://athena.ohdsi.org/search-terms/terms/700388)|
|E|8527|Mixed - White and Black African [Athena mapping](https://athena.ohdsi.org/search-terms/terms/700389)|
|F|8527|Mixed - White and Asian [Athena mapping](https://athena.ohdsi.org/search-terms/terms/700390)|
|G|8527|Mixed - Any other mixed background [Athena mapping](https://athena.ohdsi.org/search-terms/terms/700391)|
|H|38003574|Asian or Asian British - Indian|
|J|38003589|Asian or Asian British - Pakistani|
|K|38003575|Asian or Asian British - Bangladeshi|
|L|8515|Asian or Asian British - Any other Asian background|
|M|38003598|Black or Black British - Caribbean|
|N|38003600|Black or Black British - African|
|P|38003598|Black or Black British - Any other Black background|
|R|38003579|Other Ethnic Groups - Chinese|
|S|0|Other Ethnic Groups - Any other ethnic group|
|Z|0|Not stated|
|99|0|Not known|
||0|No data|

Notes
* [NHS Race (i.e.Ethnicity)](https://www.datadictionary.nhs.uk/data_elements/ethnic_category.html)
* [OMOP Race](https://athena.ohdsi.org/search-terms/terms?conceptClass=Race&invalidReason=Valid&vocabulary=Race&page=1&pageSize=50&query=)
* [D, E, F, G Race mapping](https://forums.ohdsi.org/t/mapping-nhs-ethnic-category-to-omop-race/20883/2)

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


[Comment or raise an issue for this mapping.](https://github.com/tvs-sde/oxford-omop-data-mapper/issues/new?title=OMOP%20Person%20table%20race_concept_id%20field%20SUS%20Inpatient%20Person%20mapping){: .btn }
### SUS A&E Person
Source column  `EthnicCategory`.
Lookup race concept.


|EthnicCategory|race_concept_id|notes|
|------|-----|-----|
|A|8527|White - British|
|B|8527|White - Irish|
|C|8527|White - Any other White background|
|D|8527|Mixed - White and Black Caribbean [Athena mapping](https://athena.ohdsi.org/search-terms/terms/700388)|
|E|8527|Mixed - White and Black African [Athena mapping](https://athena.ohdsi.org/search-terms/terms/700389)|
|F|8527|Mixed - White and Asian [Athena mapping](https://athena.ohdsi.org/search-terms/terms/700390)|
|G|8527|Mixed - Any other mixed background [Athena mapping](https://athena.ohdsi.org/search-terms/terms/700391)|
|H|38003574|Asian or Asian British - Indian|
|J|38003589|Asian or Asian British - Pakistani|
|K|38003575|Asian or Asian British - Bangladeshi|
|L|8515|Asian or Asian British - Any other Asian background|
|M|38003598|Black or Black British - Caribbean|
|N|38003600|Black or Black British - African|
|P|38003598|Black or Black British - Any other Black background|
|R|38003579|Other Ethnic Groups - Chinese|
|S|0|Other Ethnic Groups - Any other ethnic group|
|Z|0|Not stated|
|99|0|Not known|
||0|No data|

Notes
* [NHS Race (i.e.Ethnicity)](https://www.datadictionary.nhs.uk/data_elements/ethnic_category.html)
* [OMOP Race](https://athena.ohdsi.org/search-terms/terms?conceptClass=Race&invalidReason=Valid&vocabulary=Race&page=1&pageSize=50&query=)
* [D, E, F, G Race mapping](https://forums.ohdsi.org/t/mapping-nhs-ethnic-category-to-omop-race/20883/2)

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


[Comment or raise an issue for this mapping.](https://github.com/tvs-sde/oxford-omop-data-mapper/issues/new?title=OMOP%20Person%20table%20race_concept_id%20field%20SUS%20A&E%20Person%20mapping){: .btn }
### SACT Person
* Constant value set to `0`. Unknown concept

[Comment or raise an issue for this mapping.](https://github.com/tvs-sde/oxford-omop-data-mapper/issues/new?title=OMOP%20Person%20table%20race_concept_id%20field%20SACT%20Person%20mapping){: .btn }
### Rtds Person
* Constant value set to `0`. Unknown concept

[Comment or raise an issue for this mapping.](https://github.com/tvs-sde/oxford-omop-data-mapper/issues/new?title=OMOP%20Person%20table%20race_concept_id%20field%20Rtds%20Person%20mapping){: .btn }
### Oxford demographics from databricks_demographics.parquet
Source column  `ethnic_group`.
Lookup Databricks ethnic group as an OMOP race concept.


|ethnic_group|race_concept_id|notes|
|------|-----|-----|
|Asian - Any Other Asian Background|8515|Asian or Asian British - Any other Asian background|
|Asian or Asian British - Bangladeshi|38003575|Asian or Asian British - Bangladeshi|
|Asian or Asian British - Indian|38003574|Asian or Asian British - Indian|
|Asian or Asian British - Pakistani|38003589|Asian or Asian British - Pakistani|
|Black - Any Other Black Background|38003598|Black or Black British - Any other Black background|
|Black or Black British - African|38003600|Black or Black British - African|
|Black or Black British - Caribbean|38003598|Black or Black British - Caribbean|
|Mixed - Any Other Mixed Background|8527|Mixed - Any other mixed background [Athena mapping](https://athena.ohdsi.org/search-terms/terms/700391)|
|Mixed - White and Asian|8527|Mixed - White and Asian [Athena mapping](https://athena.ohdsi.org/search-terms/terms/700390)|
|Mixed - White and Black African|8527|Mixed - White and Black African [Athena mapping](https://athena.ohdsi.org/search-terms/terms/700389)|
|Mixed - White and Black Caribbean|8527|Mixed - White and Black Caribbean [Athena mapping](https://athena.ohdsi.org/search-terms/terms/700388)|
|Other - Any Other Ethnic Group|0|Other Ethnic Groups - Any other ethnic group|
|Other - Chinese|38003579|Other Ethnic Groups - Chinese|
|Other - Not Known|0|Not known|
|Other - Not Stated|0|Not stated|
|White - Any Other White Background|8527|White - Any other White background|
|White - British|8527|White - British|
|White - Irish|8527|White - Irish|
||0|No data|

Notes
* [NHS Race (i.e.Ethnicity)](https://www.datadictionary.nhs.uk/data_elements/ethnic_category.html)
* [OMOP Race](https://athena.ohdsi.org/search-terms/terms?conceptClass=Race&invalidReason=Valid&vocabulary=Race&page=1&pageSize=50&query=)
* [Mixed race mapping](https://forums.ohdsi.org/t/mapping-nhs-ethnic-category-to-omop-race/20883/2)

* `ethnic_group` Databricks ethnic group, mapped to an OMOP race concept. 

```sql
select
    cast(date_of_birth as varchar) as date_of_birth,
    ethnic_group,
    sex,
    cast(nhs_number as varchar) as nhs_number
from ##duckdb_source##
order by all
```


[Comment or raise an issue for this mapping.](https://github.com/tvs-sde/oxford-omop-data-mapper/issues/new?title=OMOP%20Person%20table%20race_concept_id%20field%20Oxford%20demographics%20from%20databricks_demographics.parquet%20mapping){: .btn }
### COSD Demographics
Source column  `EthnicCategory`.
Lookup race concept.


|EthnicCategory|race_concept_id|notes|
|------|-----|-----|
|A|8527|White - British|
|B|8527|White - Irish|
|C|8527|White - Any other White background|
|D|8527|Mixed - White and Black Caribbean [Athena mapping](https://athena.ohdsi.org/search-terms/terms/700388)|
|E|8527|Mixed - White and Black African [Athena mapping](https://athena.ohdsi.org/search-terms/terms/700389)|
|F|8527|Mixed - White and Asian [Athena mapping](https://athena.ohdsi.org/search-terms/terms/700390)|
|G|8527|Mixed - Any other mixed background [Athena mapping](https://athena.ohdsi.org/search-terms/terms/700391)|
|H|38003574|Asian or Asian British - Indian|
|J|38003589|Asian or Asian British - Pakistani|
|K|38003575|Asian or Asian British - Bangladeshi|
|L|8515|Asian or Asian British - Any other Asian background|
|M|38003598|Black or Black British - Caribbean|
|N|38003600|Black or Black British - African|
|P|38003598|Black or Black British - Any other Black background|
|R|38003579|Other Ethnic Groups - Chinese|
|S|0|Other Ethnic Groups - Any other ethnic group|
|Z|0|Not stated|
|99|0|Not known|
||0|No data|

Notes
* [NHS Race (i.e.Ethnicity)](https://www.datadictionary.nhs.uk/data_elements/ethnic_category.html)
* [OMOP Race](https://athena.ohdsi.org/search-terms/terms?conceptClass=Race&invalidReason=Valid&vocabulary=Race&page=1&pageSize=50&query=)
* [D, E, F, G Race mapping](https://forums.ohdsi.org/t/mapping-nhs-ethnic-category-to-omop-race/20883/2)

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


[Comment or raise an issue for this mapping.](https://github.com/tvs-sde/oxford-omop-data-mapper/issues/new?title=OMOP%20Person%20table%20race_concept_id%20field%20COSD%20Demographics%20mapping){: .btn }
