---
layout: default
title: place_of_service_source_value
parent: CareSite
grand_parent: Transformation Documentation
has_toc: false
---
# place_of_service_source_value
### SUS Outpatient Care Site
* Value copied from `MainSpecialtyCode`

* `MainSpecialtyCode` A unique code identifying each MAIN SPECIALTY designated by Royal Colleges. [MAIN SPECIALTY CODE](https://www.datadictionary.nhs.uk/data_elements/main_specialty_code.html)

```sql
with counts as ( 
	select 
		SiteCodeofTreatment, 
		MainSpecialtyCode, 
		count(*) as cnt 
	from omop_staging.sus_OP 
	where SiteCodeofTreatment is not null 
		and MainSpecialtyCode is not null 
	group by 
		SiteCodeofTreatment, 
		MainSpecialtyCode 
),  ranked as ( 
	select 
		SiteCodeofTreatment, 
		MainSpecialtyCode, 
		cnt, 
		row_number() over (partition by SiteCodeofTreatment order by cnt desc, MainSpecialtyCode 
	) as rnk 
	from counts 
)
select 
	SiteCodeofTreatment, 
	MainSpecialtyCode 
from ranked 
where rnk = 1
order by 
	SiteCodeofTreatment, 
	MainSpecialtyCode 
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20CareSite%20table%20place_of_service_source_value%20field%20SUS%20Outpatient%20Care%20Site%20mapping){: .btn }
### SUS Inpatient Care Site
* Value copied from `MainSpecialtyCode`

* `MainSpecialtyCode` A unique code identifying each MAIN SPECIALTY designated by Royal Colleges. [MAIN SPECIALTY CODE](https://www.datadictionary.nhs.uk/data_elements/main_specialty_code.html)

```sql
with counts as 
( 
	select 
		SiteCodeOfTreatmentAtEpisodeStartDate, 
		MainSpecialtyCode, 
		count(*) as cnt 
	from omop_staging.sus_APC 
	where SiteCodeOfTreatmentAtEpisodeStartDate is not null 
		and MainSpecialtyCode is not null 
	group by 
		SiteCodeOfTreatmentAtEpisodeStartDate, 
		MainSpecialtyCode 
), ranked as ( 
	select 
		SiteCodeOfTreatmentAtEpisodeStartDate, 
		MainSpecialtyCode, 
		cnt, 
		row_number() over (partition by SiteCodeOfTreatmentAtEpisodeStartDate order by cnt desc, MainSpecialtyCode 
	) as rnk 
	from counts 
)
select 
	SiteCodeOfTreatmentAtEpisodeStartDate, 
	MainSpecialtyCode 
from ranked 
where rnk = 1
order by 
	SiteCodeOfTreatmentAtEpisodeStartDate, 
	MainSpecialtyCode 
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20CareSite%20table%20place_of_service_source_value%20field%20SUS%20Inpatient%20Care%20Site%20mapping){: .btn }
