---
layout: default
title: death_datetime
parent: Death
grand_parent: Transformation Documentation
has_toc: false
---
# death_datetime
### SUS Inpatient Death
Source columns  `death_date`, `death_time`.
Combines a date with a time of day.

* `death_date` Discharge date of the patient's spell. [DISCHARGE DATE (HOSPITAL PROVIDER SPELL)](https://www.datadictionary.nhs.uk/data_elements/discharge_date__hospital_provider_spell_.html)

* `death_time` Discharge time of the patient's spell. [DISCHARGE TIME (HOSPITAL PROVIDER SPELL)](https://www.datadictionary.nhs.uk/data_elements/discharge_time__hospital_provider_spell_.html)

```sql
;with primarydiagnosis as (
	select *
	from omop_staging.sus_ICDDiagnosis
	where IsPrimaryDiagnosis = 1
)

select
	apc.NHSNumber as nhs_number,
	max(apc.DischargeDateFromHospitalProviderSpell) as death_date,
	max(apc.DischargeTimeHospitalProviderSpell) as death_time,
	max(d.DiagnosisICD) as DiagnosisICD
from omop_staging.sus_APC apc
	left join primarydiagnosis d
		on apc.MessageId = d.MessageId
where
	apc.NHSNumber is not null and
	apc.DischargeDateFromHospitalProviderSpell is not null and
	apc.DischargeMethodHospitalProviderSpell = '4' -- "Patient died"

group by apc.NHSNumber
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Death%20table%20death_datetime%20field%20SUS%20Inpatient%20Death%20mapping){: .btn }
### Oxford Spine Death
Source column  `DECEASED_DT_TM`.
Converts text to dates.

* `DECEASED_DT_TM` Spine datetime of death. 

```sql
select
	patient_identifier_value,
	DECEASED_DT_TM
from ##duckdb_source##
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Death%20table%20death_datetime%20field%20Oxford%20Spine%20Death%20mapping){: .btn }
### COSD v9 DeathDischargeDestination
* Value copied from `DeathDate`

* `DeathDate` The date on which a PERSON died or is officially deemed to have died. [DISCHARGE DATE (HOSPITAL PROVIDER SPELL)](https://www.datadictionary.nhs.uk/data_elements/discharge_date__hospital_provider_spell_.html), [TREATMENT START DATE (CANCER)](https://www.datadictionary.nhs.uk/data_elements/treatment_start_date__cancer_.html)

```sql
select distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
    coalesce(
        cast(Record ->> '$.Treatment.DischargeDateHospitalProviderSpell' as date),
        make_date(
            cast(extract(year from cast(Record ->> '$.Treatment.TreatmentStartDateCancer' as date)) as integer),
            12,
            31
        )
    ) as DeathDate
from omop_staging.cosd_staging_901
where (Record ->> '$.Treatment.DischargeDestinationHospitalProviderSpell.@code') = '79';-- Not applicable - PATIENT died or stillbirth
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Death%20table%20death_datetime%20field%20COSD%20v9%20DeathDischargeDestination%20mapping){: .btn }
### COSD v9 BasisOfDiagnosisCancer
* Value copied from `DeathDate`

* `DeathDate` The date on which a PERSON died or is officially deemed to have died. [MULTIDISCIPLINARY TEAM DISCUSSION DATE (CANCER)](https://www.datadictionary.nhs.uk/data_elements/multidisciplinary_team_discussion_date__cancer_.html), [TREATMENT START DATE (CANCER)](https://www.datadictionary.nhs.uk/data_elements/treatment_start_date__cancer_.html), [TNM STAGE GROUPING DATE (FINAL PRETREATMENT)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping_date__final_pretreatment_.html), [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
	    with cosddates as (
    select
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
        cast(Record ->> '$.Treatment.TreatmentStartDateCancer' as date) as TreatmentStartDateCancer,
        cast(Record ->> '$.CancerCarePlan.MultidisciplinaryTeamDiscussionDateCancer' as date) as MultidisciplinaryTeamDiscussionDateCancer,
        cast(Record ->> '$.PrimaryPathway.Staging.StageDateFinalPretreatmentStage' as date) as StageDateFinalPretreatmentStage,
        cast(Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed' as date) as DateOfPrimaryDiagnosisClinicallyAgreed
    from omop_staging.cosd_staging_901
    where type = 'CO'
      and (Record ->> '$.PrimaryPathway.Diagnosis.BasisOfDiagnosisCancer.@code') in ('0', '1')
), dates as (
    select NhsNumber, TreatmentStartDateCancer as "Date" from cosddates where TreatmentStartDateCancer is not null
    union
    select NhsNumber, MultidisciplinaryTeamDiscussionDateCancer as "Date" from cosddates where MultidisciplinaryTeamDiscussionDateCancer is not null
    union
    select NhsNumber, StageDateFinalPretreatmentStage as "Date" from cosddates where StageDateFinalPretreatmentStage is not null
    union
    select NhsNumber, DateOfPrimaryDiagnosisClinicallyAgreed as "Date" from cosddates where DateOfPrimaryDiagnosisClinicallyAgreed is not null
)
select
    NhsNumber,
    make_date(cast(extract(year from max("Date")) as integer), 12, 31) as DeathDate
from dates
group by NhsNumber;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Death%20table%20death_datetime%20field%20COSD%20v9%20BasisOfDiagnosisCancer%20mapping){: .btn }
### COSD v8 Death
Source column  `DeathDate`.
Converts text to dates.

* `DeathDate` The date on which a PERSON died or is officially deemed to have died. [PERSON DEATH DATE](https://www.datadictionary.nhs.uk/data_elements/person_death_date.html)

```sql
select 
	distinct
		Record ->> '$..NHSNumber..@extension' ->> 0 as NhsNumber,
  		Record ->> '$..PersonDeathDate' ->> 0 as DeathDate
from omop_staging.cosd_staging_81
where DeathDate is not null
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Death%20table%20death_datetime%20field%20COSD%20v8%20Death%20mapping){: .btn }
