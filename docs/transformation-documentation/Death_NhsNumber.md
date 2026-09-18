---
layout: default
title: NhsNumber
parent: Death
grand_parent: Transformation Documentation
has_toc: false
---
# NhsNumber
### SUS Outpatient Death
* Value copied from `nhs_number`

* `nhs_number` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

```sql
	select
		NHSNumber as nhs_number,
		coalesce(max(ReferralToTreatmentPeriodEndDate), max(CDSActivityDate)) as death_date
	from omop_staging.sus_OP
	where ReferralToTreatmentPeriodStatus = 36
		and (CDSActivityDate is not null or ReferralToTreatmentPeriodEndDate is not null)
		and NHSNumber is not null
	group by NHSNumber
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Death%20table%20NhsNumber%20field%20SUS%20Outpatient%20Death%20mapping){: .btn }
### SUS Inpatient Death
* Value copied from `nhs_number`

* `nhs_number` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Death%20table%20NhsNumber%20field%20SUS%20Inpatient%20Death%20mapping){: .btn }
### SUS A&E Death
* Value copied from `nhs_number`

* `nhs_number` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

```sql
select
	NHSNumber as nhs_number,
	coalesce(max(ReferralToTreatmentPeriodEndDate), max(CDSActivityDate)) as death_date
from omop_staging.sus_AE
where ((ReferralToTreatmentPeriodStatus = 36) --PATIENT died before treatment
	or (AEPatientGroup = 70) -- PATIENT brought in dead
	or (AEAttendanceDisposal = 10))  --PATIENT died in AE
	and (CDSActivityDate is not null or ReferralToTreatmentPeriodEndDate is not null)
	and NHSNumber is not null
group by NHSNumber
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Death%20table%20NhsNumber%20field%20SUS%20A&E%20Death%20mapping){: .btn }
### Oxford Spine Death
* Value copied from `patient_identifier_Value`

* `patient_identifier_Value` Patient NHS Number 

```sql
select
	patient_identifier_value,
	DECEASED_DT_TM
from ##duckdb_source##
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Death%20table%20NhsNumber%20field%20Oxford%20Spine%20Death%20mapping){: .btn }
### Oxford GP Death
* Value copied from `NHSNumber`

* `NHSNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

```sql
select
	distinct
		NHSNumber,
		DateofDeath
from omop_staging.oxford_gp_demographic
where DateofDeath is not null
order by
	NHSNumber,
	DateofDeath
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Death%20table%20NhsNumber%20field%20Oxford%20GP%20Death%20mapping){: .btn }
### COSD v9 DeathDischargeDestination
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Death%20table%20NhsNumber%20field%20COSD%20v9%20DeathDischargeDestination%20mapping){: .btn }
### COSD v9 BasisOfDiagnosisCancer
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Death%20table%20NhsNumber%20field%20COSD%20v9%20BasisOfDiagnosisCancer%20mapping){: .btn }
### COSD v8 Death
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

```sql
select 
	distinct
		Record ->> '$..NHSNumber..@extension' ->> 0 as NhsNumber,
  		Record ->> '$..PersonDeathDate' ->> 0 as DeathDate
from omop_staging.cosd_staging_81
where DeathDate is not null
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Death%20table%20NhsNumber%20field%20COSD%20v8%20Death%20mapping){: .btn }
