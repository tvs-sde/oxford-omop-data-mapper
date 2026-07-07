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
### COSD V9 LV Observation Smoking Status Cancer
* Constant value set to `43054909`. Tobacco smoking status

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_concept_id%20field%20COSD%20V9%20LV%20Observation%20Smoking%20Status%20Cancer%20mapping){: .btn }
### COSD V9 LV Observation Performance Status Adult
* Constant value set to `4309681`. General physical performance status

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_concept_id%20field%20COSD%20V9%20LV%20Observation%20Performance%20Status%20Adult%20mapping){: .btn }
### COSD V9 LV Observation Familial Cancer Syndrome Indicator
* Constant value set to `4171594`. Family history of malignant neoplasm

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_concept_id%20field%20COSD%20V9%20LV%20Observation%20Familial%20Cancer%20Syndrome%20Indicator%20mapping){: .btn }
### COSD V9 LV Observation Cancer Treatment Intent
* Constant value set to `4194400`. Treatment intent

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_concept_id%20field%20COSD%20V9%20LV%20Observation%20Cancer%20Treatment%20Intent%20mapping){: .btn }
### COSD V8 LV Observation Performance Status Adult
* Constant value set to `4309681`. General physical performance status

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_concept_id%20field%20COSD%20V8%20LV%20Observation%20Performance%20Status%20Adult%20mapping){: .btn }
### COSD V8 LV Observation Cancer Treatment Intent
* Constant value set to `4194400`. Treatment intent

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_concept_id%20field%20COSD%20V8%20LV%20Observation%20Cancer%20Treatment%20Intent%20mapping){: .btn }
### CosdV9LungFamilialCancerSyndrome
* Constant value set to `2000500005`. Familial Cancer (Indicator)

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_concept_id%20field%20CosdV9LungFamilialCancerSyndrome%20mapping){: .btn }
### CosdV8LungAlcoholHistoryCancerInLastThreeMonths
* Constant value set to `2000500003`. History Of Alcohol (Current)

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_concept_id%20field%20CosdV8LungAlcoholHistoryCancerInLastThreeMonths%20mapping){: .btn }
### CosdV8LungAlcoholHistoryCancerBeforeLastThreeMonths
* Constant value set to `2000500004`. History Of Alcohol (Past)

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_concept_id%20field%20CosdV8LungAlcoholHistoryCancerBeforeLastThreeMonths%20mapping){: .btn }
### COSD V9 HN Observation Smoking Status Cancer
* Constant value set to `43054909`. Tobacco smoking status

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_concept_id%20field%20COSD%20V9%20HN%20Observation%20Smoking%20Status%20Cancer%20mapping){: .btn }
### COSD V9 HN Observation Performance Status Adult
* Constant value set to `4309681`. General physical performance status

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_concept_id%20field%20COSD%20V9%20HN%20Observation%20Performance%20Status%20Adult%20mapping){: .btn }
### COSD V9 HN Observation Familial Cancer Syndrome Indicator
* Constant value set to `4171594`. Family history of malignant neoplasm

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_concept_id%20field%20COSD%20V9%20HN%20Observation%20Familial%20Cancer%20Syndrome%20Indicator%20mapping){: .btn }
### COSD V9 HN Observation Cancer Treatment Intent
* Constant value set to `4194400`. Treatment intent

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_concept_id%20field%20COSD%20V9%20HN%20Observation%20Cancer%20Treatment%20Intent%20mapping){: .btn }
### COSD V9 HN Observation Alcohol History Cancer In Last Three Months
* Constant value set to `35609491`. Alcohol units consumed per week

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_concept_id%20field%20COSD%20V9%20HN%20Observation%20Alcohol%20History%20Cancer%20In%20Last%20Three%20Months%20mapping){: .btn }
### COSD V9 HN Observation Alcohol History Cancer Before Last Three Months
* Constant value set to `35609491`. Alcohol units consumed per week

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_concept_id%20field%20COSD%20V9%20HN%20Observation%20Alcohol%20History%20Cancer%20Before%20Last%20Three%20Months%20mapping){: .btn }
### COSD V8 HN Observation Smoking Status Cancer
* Constant value set to `43054909`. Tobacco smoking status

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_concept_id%20field%20COSD%20V8%20HN%20Observation%20Smoking%20Status%20Cancer%20mapping){: .btn }
### COSD V8 HN Observation Performance Status Adult
* Constant value set to `4309681`. General physical performance status

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_concept_id%20field%20COSD%20V8%20HN%20Observation%20Performance%20Status%20Adult%20mapping){: .btn }
### COSD V8 HN Observation Familial Cancer Syndrome Indicator
* Constant value set to `4171594`. Family history of malignant neoplasm

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_concept_id%20field%20COSD%20V8%20HN%20Observation%20Familial%20Cancer%20Syndrome%20Indicator%20mapping){: .btn }
### COSD V8 HN Observation Cancer Treatment Intent
* Constant value set to `4194400`. Treatment intent

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_concept_id%20field%20COSD%20V8%20HN%20Observation%20Cancer%20Treatment%20Intent%20mapping){: .btn }
### COSD V8 HN Observation Alcohol History Cancer In Last Three Months
* Constant value set to `35609491`. Alcohol units consumed per week

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_concept_id%20field%20COSD%20V8%20HN%20Observation%20Alcohol%20History%20Cancer%20In%20Last%20Three%20Months%20mapping){: .btn }
### COSD V8 HN Observation Alcohol History Cancer Before Last Three Months
* Constant value set to `35609491`. Alcohol units consumed per week

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_concept_id%20field%20COSD%20V8%20HN%20Observation%20Alcohol%20History%20Cancer%20Before%20Last%20Three%20Months%20mapping){: .btn }
### COSD V9 HA Observation Smoking Status Cancer
* Constant value set to `43054909`. Tobacco smoking status

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_concept_id%20field%20COSD%20V9%20HA%20Observation%20Smoking%20Status%20Cancer%20mapping){: .btn }
### COSD V9 HA Observation Performance Status Adult
* Constant value set to `4309681`. General physical performance status

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_concept_id%20field%20COSD%20V9%20HA%20Observation%20Performance%20Status%20Adult%20mapping){: .btn }
### COSD V9 HA Observation Familial Cancer Syndrome Indicator
* Constant value set to `4171594`. Family history of malignant neoplasm

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_concept_id%20field%20COSD%20V9%20HA%20Observation%20Familial%20Cancer%20Syndrome%20Indicator%20mapping){: .btn }
### COSD V9 HA Observation Cancer Treatment Intent
* Constant value set to `4194400`. Treatment intent

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_concept_id%20field%20COSD%20V9%20HA%20Observation%20Cancer%20Treatment%20Intent%20mapping){: .btn }
### COSD V9 HA Observation Alcohol History Cancer In Last Three Months
* Constant value set to `35609491`. Alcohol units consumed per week

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_concept_id%20field%20COSD%20V9%20HA%20Observation%20Alcohol%20History%20Cancer%20In%20Last%20Three%20Months%20mapping){: .btn }
### COSD V9 HA Observation Alcohol History Cancer Before Last Three Months
* Constant value set to `35609491`. Alcohol units consumed per week

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_concept_id%20field%20COSD%20V9%20HA%20Observation%20Alcohol%20History%20Cancer%20Before%20Last%20Three%20Months%20mapping){: .btn }
### COSD V8 HA Observation Smoking Status Cancer
* Constant value set to `43054909`. Tobacco smoking status

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_concept_id%20field%20COSD%20V8%20HA%20Observation%20Smoking%20Status%20Cancer%20mapping){: .btn }
### COSD V8 HA Observation Performance Status Adult
* Constant value set to `4309681`. General physical performance status

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_concept_id%20field%20COSD%20V8%20HA%20Observation%20Performance%20Status%20Adult%20mapping){: .btn }
### COSD V8 HA Observation Familial Cancer Syndrome Indicator
* Constant value set to `4171594`. Family history of malignant neoplasm

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_concept_id%20field%20COSD%20V8%20HA%20Observation%20Familial%20Cancer%20Syndrome%20Indicator%20mapping){: .btn }
### COSD V8 HA Observation Cancer Treatment Intent
* Constant value set to `4194400`. Treatment intent

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_concept_id%20field%20COSD%20V8%20HA%20Observation%20Cancer%20Treatment%20Intent%20mapping){: .btn }
### COSD V8 HA Observation Alcohol History Cancer In Last Three Months
* Constant value set to `35609491`. Alcohol units consumed per week

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_concept_id%20field%20COSD%20V8%20HA%20Observation%20Alcohol%20History%20Cancer%20In%20Last%20Three%20Months%20mapping){: .btn }
### COSD V8 HA Observation Alcohol History Cancer Before Last Three Months
* Constant value set to `35609491`. Alcohol units consumed per week

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_concept_id%20field%20COSD%20V8%20HA%20Observation%20Alcohol%20History%20Cancer%20Before%20Last%20Three%20Months%20mapping){: .btn }
### COSD V9 GY Observation Smoking Status Cancer
* Constant value set to `43054909`. Tobacco smoking status

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_concept_id%20field%20COSD%20V9%20GY%20Observation%20Smoking%20Status%20Cancer%20mapping){: .btn }
### COSD V9 GY Observation Performance Status Adult
* Constant value set to `4309681`. General physical performance status

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_concept_id%20field%20COSD%20V9%20GY%20Observation%20Performance%20Status%20Adult%20mapping){: .btn }
### COSD V9 GY Observation Familial Cancer Syndrome Indicator
* Constant value set to `4171594`. Family history of malignant neoplasm

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_concept_id%20field%20COSD%20V9%20GY%20Observation%20Familial%20Cancer%20Syndrome%20Indicator%20mapping){: .btn }
### COSD V9 GY Observation Cancer Treatment Intent
* Constant value set to `4194400`. Treatment intent

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_concept_id%20field%20COSD%20V9%20GY%20Observation%20Cancer%20Treatment%20Intent%20mapping){: .btn }
### COSD V9 GY Observation Alcohol History Cancer In Last Three Months
* Constant value set to `35609491`. Alcohol units consumed per week

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_concept_id%20field%20COSD%20V9%20GY%20Observation%20Alcohol%20History%20Cancer%20In%20Last%20Three%20Months%20mapping){: .btn }
### COSD V9 GY Observation Alcohol History Cancer Before Last Three Months
* Constant value set to `35609491`. Alcohol units consumed per week

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_concept_id%20field%20COSD%20V9%20GY%20Observation%20Alcohol%20History%20Cancer%20Before%20Last%20Three%20Months%20mapping){: .btn }
### COSD V8 GY Observation Smoking Status Cancer
* Constant value set to `43054909`. Tobacco smoking status

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_concept_id%20field%20COSD%20V8%20GY%20Observation%20Smoking%20Status%20Cancer%20mapping){: .btn }
### COSD V8 GY Observation Performance Status Adult
* Constant value set to `4309681`. General physical performance status

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_concept_id%20field%20COSD%20V8%20GY%20Observation%20Performance%20Status%20Adult%20mapping){: .btn }
### COSD V8 GY Observation Familial Cancer Syndrome Indicator
* Constant value set to `4171594`. Family history of malignant neoplasm

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_concept_id%20field%20COSD%20V8%20GY%20Observation%20Familial%20Cancer%20Syndrome%20Indicator%20mapping){: .btn }
### COSD V8 GY Observation Cancer Treatment Intent
* Constant value set to `4194400`. Treatment intent

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_concept_id%20field%20COSD%20V8%20GY%20Observation%20Cancer%20Treatment%20Intent%20mapping){: .btn }
### COSD V8 GY Observation Alcohol History Cancer In Last Three Months
* Constant value set to `35609491`. Alcohol units consumed per week

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_concept_id%20field%20COSD%20V8%20GY%20Observation%20Alcohol%20History%20Cancer%20In%20Last%20Three%20Months%20mapping){: .btn }
### COSD V8 GY Observation Alcohol History Cancer Before Last Three Months
* Constant value set to `35609491`. Alcohol units consumed per week

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_concept_id%20field%20COSD%20V8%20GY%20Observation%20Alcohol%20History%20Cancer%20Before%20Last%20Three%20Months%20mapping){: .btn }
### COSD V9 CT Observation Tobacco Smoking Cessation Treatment Indication Code
* Constant value set to `4206526`. Smoking cessation behavior

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_concept_id%20field%20COSD%20V9%20CT%20Observation%20Tobacco%20Smoking%20Cessation%20Treatment%20Indication%20Code%20mapping){: .btn }
### COSD V9 CT Observation Smoking Status Cancer
* Constant value set to `43054909`. Tobacco smoking status

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_concept_id%20field%20COSD%20V9%20CT%20Observation%20Smoking%20Status%20Cancer%20mapping){: .btn }
### COSD V9 CT Observation Performance Status Adult
* Constant value set to `4309681`. General physical performance status

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_concept_id%20field%20COSD%20V9%20CT%20Observation%20Performance%20Status%20Adult%20mapping){: .btn }
### COSD V9 CT Observation Familial Cancer Syndrome Indicator
* Constant value set to `4171594`. Family history of malignant neoplasm

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_concept_id%20field%20COSD%20V9%20CT%20Observation%20Familial%20Cancer%20Syndrome%20Indicator%20mapping){: .btn }
### COSD V9 CT Observation Cancer Treatment Intent
* Constant value set to `4194400`. Treatment intent

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_concept_id%20field%20COSD%20V9%20CT%20Observation%20Cancer%20Treatment%20Intent%20mapping){: .btn }
### COSD V9 CT Observation Alcohol History Cancer In Last Three Months
* Constant value set to `35609491`. Alcohol units consumed per week

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_concept_id%20field%20COSD%20V9%20CT%20Observation%20Alcohol%20History%20Cancer%20In%20Last%20Three%20Months%20mapping){: .btn }
### COSD V9 CT Observation Alcohol History Cancer Before Last Three Months
* Constant value set to `35609491`. Alcohol units consumed per week

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_concept_id%20field%20COSD%20V9%20CT%20Observation%20Alcohol%20History%20Cancer%20Before%20Last%20Three%20Months%20mapping){: .btn }
### COSD V8 CT Observation Smoking Status Cancer
* Constant value set to `43054909`. Tobacco smoking status

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_concept_id%20field%20COSD%20V8%20CT%20Observation%20Smoking%20Status%20Cancer%20mapping){: .btn }
### COSD V8 CT Observation Performance Status Adult
* Constant value set to `4309681`. General physical performance status

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_concept_id%20field%20COSD%20V8%20CT%20Observation%20Performance%20Status%20Adult%20mapping){: .btn }
### COSD V8 CT Observation Familial Cancer Syndrome Indicator
* Constant value set to `4171594`. Family history of malignant neoplasm

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_concept_id%20field%20COSD%20V8%20CT%20Observation%20Familial%20Cancer%20Syndrome%20Indicator%20mapping){: .btn }
### COSD V8 CT Observation Alcohol History Cancer In Last Three Months
* Constant value set to `35609491`. Alcohol units consumed per week

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_concept_id%20field%20COSD%20V8%20CT%20Observation%20Alcohol%20History%20Cancer%20In%20Last%20Three%20Months%20mapping){: .btn }
### COSD V8 CT Observation Alcohol History Cancer Before Last Three Months
* Constant value set to `35609491`. Alcohol units consumed per week

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_concept_id%20field%20COSD%20V8%20CT%20Observation%20Alcohol%20History%20Cancer%20Before%20Last%20Three%20Months%20mapping){: .btn }
### COSD V9 CR Observation Tobacco Smoking Cessation Treatment Indication Code
* Constant value set to `4206526`. Smoking cessation behavior

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_concept_id%20field%20COSD%20V9%20CR%20Observation%20Tobacco%20Smoking%20Cessation%20Treatment%20Indication%20Code%20mapping){: .btn }
### COSD V9 CR Observation Smoking Status Cancer
* Constant value set to `43054909`. Tobacco smoking status

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_concept_id%20field%20COSD%20V9%20CR%20Observation%20Smoking%20Status%20Cancer%20mapping){: .btn }
### COSD V9 CR Observation Performance Status Adult
* Constant value set to `4309681`. General physical performance status

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_concept_id%20field%20COSD%20V9%20CR%20Observation%20Performance%20Status%20Adult%20mapping){: .btn }
### COSD V9 CR Observation Familial Cancer Syndrome Indicator
* Constant value set to `4171594`. Family history of malignant neoplasm

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_concept_id%20field%20COSD%20V9%20CR%20Observation%20Familial%20Cancer%20Syndrome%20Indicator%20mapping){: .btn }
### COSD V9 CR Observation Cancer Treatment Intent
* Constant value set to `4194400`. Treatment intent

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_concept_id%20field%20COSD%20V9%20CR%20Observation%20Cancer%20Treatment%20Intent%20mapping){: .btn }
### COSD V9 CR Observation Alcohol History Cancer In Last Three Months
* Constant value set to `35609491`. Alcohol units consumed per week

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_concept_id%20field%20COSD%20V9%20CR%20Observation%20Alcohol%20History%20Cancer%20In%20Last%20Three%20Months%20mapping){: .btn }
### COSD V9 CR Observation Alcohol History Cancer Before Last Three Months
* Constant value set to `35609491`. Alcohol units consumed per week

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_concept_id%20field%20COSD%20V9%20CR%20Observation%20Alcohol%20History%20Cancer%20Before%20Last%20Three%20Months%20mapping){: .btn }
### COSD V8 CR Observation Smoking Status Cancer
* Constant value set to `43054909`. Tobacco smoking status

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_concept_id%20field%20COSD%20V8%20CR%20Observation%20Smoking%20Status%20Cancer%20mapping){: .btn }
### COSD V8 CR Observation Performance Status Adult
* Constant value set to `4309681`. General physical performance status

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_concept_id%20field%20COSD%20V8%20CR%20Observation%20Performance%20Status%20Adult%20mapping){: .btn }
### COSD V8 CR Observation Cancer Treatment Intent
* Constant value set to `4194400`. Treatment intent

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_concept_id%20field%20COSD%20V8%20CR%20Observation%20Cancer%20Treatment%20Intent%20mapping){: .btn }
### COSD V8 CR Observation Alcohol History Cancer In Last Three Months
* Constant value set to `35609491`. Alcohol units consumed per week

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_concept_id%20field%20COSD%20V8%20CR%20Observation%20Alcohol%20History%20Cancer%20In%20Last%20Three%20Months%20mapping){: .btn }
### COSD V8 CR Observation Alcohol History Cancer Before Last Three Months
* Constant value set to `35609491`. Alcohol units consumed per week

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_concept_id%20field%20COSD%20V8%20CR%20Observation%20Alcohol%20History%20Cancer%20Before%20Last%20Three%20Months%20mapping){: .btn }
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
### CosdV9BreastHistoryOfAlcoholPast
* Constant value set to `2000500004`. History Of Alcohol (Past)

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_concept_id%20field%20CosdV9BreastHistoryOfAlcoholPast%20mapping){: .btn }
### CosdV9BreastHistoryOfAlcoholCurrent
* Constant value set to `2000500003`. History Of Alcohol (Current)

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_concept_id%20field%20CosdV9BreastHistoryOfAlcoholCurrent%20mapping){: .btn }
### CosdV9BreastFamilialCancerSyndrome
* Constant value set to `2000500005`. Familial Cancer (Indicator)

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_concept_id%20field%20CosdV9BreastFamilialCancerSyndrome%20mapping){: .btn }
### CosdV9BreastFamilialCancerSyndromeSubsidiaryComment
* Constant value set to `2000500006`. Familial Cancer (Comment)

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_concept_id%20field%20CosdV9BreastFamilialCancerSyndromeSubsidiaryComment%20mapping){: .btn }
### COSD V8 Breast Familial Cancer Syndrome Indicator
* Constant value set to `2000500005`. Familial Cancer (Indicator)

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_concept_id%20field%20COSD%20V8%20Breast%20Familial%20Cancer%20Syndrome%20Indicator%20mapping){: .btn }
### COSD V9 BA Observation Performance Status Adult
* Constant value set to `4309681`. General physical performance status

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_concept_id%20field%20COSD%20V9%20BA%20Observation%20Performance%20Status%20Adult%20mapping){: .btn }
### COSD V9 BA Observation Cancer Treatment Intent
* Constant value set to `4194400`. Treatment intent

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_concept_id%20field%20COSD%20V9%20BA%20Observation%20Cancer%20Treatment%20Intent%20mapping){: .btn }
### COSD V8 BA Observation Performance Status Adult
* Constant value set to `4309681`. General physical performance status

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_concept_id%20field%20COSD%20V8%20BA%20Observation%20Performance%20Status%20Adult%20mapping){: .btn }
### COSD V8 BA Observation Cancer Treatment Intent
* Constant value set to `4194400`. Treatment intent

[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_concept_id%20field%20COSD%20V8%20BA%20Observation%20Cancer%20Treatment%20Intent%20mapping){: .btn }
