---
layout: default
title: observation_source_concept_id
parent: Observation
grand_parent: Transformation Documentation
has_toc: false
---
# observation_source_concept_id
### SUS Outpatient Procedure Observation
Source column  `PrimaryProcedure`.
Resolve OPCS4 codes to OMOP concepts. If code cannot be mapped, map using the parent code.

* `PrimaryProcedure` OPCS-4 Procedure code. [PROCEDURE (OPCS)](https://www.datadictionary.nhs.uk/data_elements/procedure__opcs_.html)

```sql
with results as
(
	select
		distinct
			op.GeneratedRecordIdentifier,
			op.NHSNumber,
			op.AppointmentDate,
			op.AppointmentTime,
			p.ProcedureOPCS as PrimaryProcedure
	from omop_staging.sus_OP op
		inner join omop_staging.sus_OP_OPCSProcedure p
		on op.MessageId = p.MessageId
	where NHSNumber is not null
		and AttendedorDidNotAttend in ('5','6')
)
select *
from results
order by 
	GeneratedRecordIdentifier,
	NHSNumber,
	AppointmentDate, 
	AppointmentTime,
	PrimaryProcedure
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_concept_id%20field%20SUS%20Outpatient%20Procedure%20Observation%20mapping){: .btn }
### Sus OP ICDDiagnosis table
Source column  `DiagnosisICD`.
Resolve ICD10 codes to standard or non standard OMOP concepts. If code cannot be mapped, map using the parent code.

* `DiagnosisICD` ICD10 diagnosis code [PRIMARY DIAGNOSIS (ICD)](https://www.datadictionary.nhs.uk/data_elements/primary_diagnosis__icd_.html)

```sql
select
    distinct
        d.DiagnosisICD,
        op.GeneratedRecordIdentifier,
        op.NHSNumber,
        op.CDSActivityDate
from omop_staging.sus_OP_ICDDiagnosis d
    inner join omop_staging.sus_OP op
        on d.MessageId = op.MessageId
where op.NHSNumber is not null
	and AttendedorDidNotAttend in ('5','6')
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_concept_id%20field%20Sus%20OP%20ICDDiagnosis%20table%20mapping){: .btn }
### Sus CCMDS High Cost Drugs
Source column  `ObservationSourceValue`.
Resolve OPCS4 codes to OMOP concepts. If code cannot be mapped, map using the parent code.

* `ObservationSourceValue` High cost drugs. [HIGH COST DRUGS (OPCS)](https://www.datadictionary.nhs.uk/data_elements/high_cost_drugs__opcs_.html)

```sql
		select distinct
			apc.NHSNumber,
			apc.HospitalProviderSpellNumber,
			cc.CriticalCareStartDate as ObservationDate,
			coalesce(cc.CriticalCareStartTime, '00:00:00') as ObservationDateTime,
			d.CriticalCareHighCostDrugs as ObservationSourceValue
		from omop_staging.sus_CCMDS_CriticalCareHighCostDrugs d
		inner join omop_staging.sus_CCMDS cc on d.MessageId = cc.MessageId
		inner join omop_staging.sus_APC apc on cc.GeneratedRecordID = apc.GeneratedRecordIdentifier
		where apc.NHSNumber is not null
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_concept_id%20field%20Sus%20CCMDS%20High%20Cost%20Drugs%20mapping){: .btn }
### SUS APC Procedure Occurrence
Source column  `PrimaryProcedure`.
Resolve OPCS4 codes to OMOP concepts. If code cannot be mapped, map using the parent code.

* `PrimaryProcedure` OPCS-4 Procedure code. [PROCEDURE (OPCS)](https://www.datadictionary.nhs.uk/data_elements/procedure__opcs_.html)

```sql
select
	distinct
		apc.GeneratedRecordIdentifier,
		apc.NHSNumber,
		p.ProcedureDateOPCS as PrimaryProcedureDate,
		p.ProcedureOPCS as PrimaryProcedure
from omop_staging.sus_APC apc
	inner join omop_staging.sus_OPCSProcedure p
		on apc.MessageId = p.MessageId
where NHSNumber is not null
order by
	apc.GeneratedRecordIdentifier,
	apc.NHSNumber,
	p.ProcedureDateOPCS,
	p.ProcedureOPCS
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_concept_id%20field%20SUS%20APC%20Procedure%20Occurrence%20mapping){: .btn }
### Sus APC Diagnosis Table
Source column  `DiagnosisICD`.
Resolve ICD10 codes to standard or non standard OMOP concepts. If code cannot be mapped, map using the parent code.

* `DiagnosisICD` ICD10 diagnosis code [PRIMARY DIAGNOSIS (ICD)](https://www.datadictionary.nhs.uk/data_elements/primary_diagnosis__icd_.html)

```sql
select
    distinct
        d.DiagnosisICD,
        apc.GeneratedRecordIdentifier,
        apc.NHSNumber,
        apc.CDSActivityDate
from omop_staging.sus_ICDDiagnosis d
    inner join omop_staging.sus_APC apc
        on d.MessageId = apc.MessageId
where apc.NHSNumber is not null
order by
	d.DiagnosisICD,
    apc.GeneratedRecordIdentifier,
    apc.NHSNumber,
    apc.CDSActivityDate
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_concept_id%20field%20Sus%20APC%20Diagnosis%20Table%20mapping){: .btn }
### SUS APC Anaesthetic Given Post Labour Delivery Observation
* Constant value set to `2000500002`. ANAESTHETIC GIVEN POST LABOUR OR DELIVERY CODE

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_concept_id%20field%20SUS%20APC%20Anaesthetic%20Given%20Post%20Labour%20Delivery%20Observation%20mapping){: .btn }
### SUS APC Anaesthetic During Labour Delivery Observation
* Constant value set to `2000500001`. ANAESTHETIC GIVEN DURING LABOUR OR DELIVERY CODE

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_concept_id%20field%20SUS%20APC%20Anaesthetic%20During%20Labour%20Delivery%20Observation%20mapping){: .btn }
### CosdV9LungFamilialCancerSyndrome
* Constant value set to `2000500005`. Familial Cancer (Indicator)

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_concept_id%20field%20CosdV9LungFamilialCancerSyndrome%20mapping){: .btn }
### CosdV8LungAlcoholHistoryCancerInLastThreeMonths
* Constant value set to `2000500003`. History Of Alcohol (Current)

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_concept_id%20field%20CosdV8LungAlcoholHistoryCancerInLastThreeMonths%20mapping){: .btn }
### CosdV8LungAlcoholHistoryCancerBeforeLastThreeMonths
* Constant value set to `2000500004`. History Of Alcohol (Past)

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_concept_id%20field%20CosdV8LungAlcoholHistoryCancerBeforeLastThreeMonths%20mapping){: .btn }
### CosdV9HistoryOfAlcoholPast
* Constant value set to `2000500004`. History Of Alcohol (Past)

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_concept_id%20field%20CosdV9HistoryOfAlcoholPast%20mapping){: .btn }
### CosdV9HistoryOfAlcoholCurrent
* Constant value set to `2000500003`. History Of Alcohol (Current)

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_concept_id%20field%20CosdV9HistoryOfAlcoholCurrent%20mapping){: .btn }
### CosdV9FamilialCancerSyndrome
* Constant value set to `2000500005`. Familial Cancer (Indicator)

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_concept_id%20field%20CosdV9FamilialCancerSyndrome%20mapping){: .btn }
### CosdV9FamilialCancerSyndromeSubsidiaryComment
* Constant value set to `2000500006`. Familial Cancer (Comment)

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_concept_id%20field%20CosdV9FamilialCancerSyndromeSubsidiaryComment%20mapping){: .btn }
### CosdV8FamilialCancerSyndromeIndicator
* Constant value set to `2000500005`. Familial Cancer (Indicator)

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_concept_id%20field%20CosdV8FamilialCancerSyndromeIndicator%20mapping){: .btn }
### CosdV8AlcoholHistoryCancerInLastThreeMonths
* Constant value set to `2000500003`. History Of Alcohol (Current)

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_concept_id%20field%20CosdV8AlcoholHistoryCancerInLastThreeMonths%20mapping){: .btn }
### CosdV8AlcoholHistoryCancerBeforeLastThreeMonths
* Constant value set to `2000500004`. History Of Alcohol (Past)

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_concept_id%20field%20CosdV8AlcoholHistoryCancerBeforeLastThreeMonths%20mapping){: .btn }
### CosdV9BreastFamilialCancerSyndrome
* Constant value set to `2000500005`. Familial Cancer (Indicator)

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_concept_id%20field%20CosdV9BreastFamilialCancerSyndrome%20mapping){: .btn }
### COSD V8 Breast Familial Cancer Syndrome Indicator
* Constant value set to `2000500005`. Familial Cancer (Indicator)

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_concept_id%20field%20COSD%20V8%20Breast%20Familial%20Cancer%20Syndrome%20Indicator%20mapping){: .btn }
