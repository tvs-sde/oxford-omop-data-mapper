---
layout: default
title: value_source_value
parent: Measurement
grand_parent: Transformation Documentation
has_toc: false
---
# value_source_value
### Sus OP  Measurement
Source column  `DiagnosisICD`.
Resolve Measurement domain ICD10 codes to `Maps To Value` concepts.

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20value_source_value%20field%20Sus%20OP%20%20Measurement%20mapping){: .btn }
### Sus CCMDS Measurement - Person Weight
* Value copied from `ValueAsNumber`

* `ValueAsNumber` Value of the Person weight [PERSON WEIGHT](https://www.datadictionary.nhs.uk/data_elements/person_weight.html)

```sql
		select distinct
				apc.NHSNumber,
				apc.GeneratedRecordIdentifier,
				cc.CriticalCareStartDate as MeasurementDate,
				coalesce(cc.CriticalCareStartTime, '00:00:00') as MeasurementDateTime,
				cc.PersonWeight as ValueAsNumber
		from omop_staging.sus_CCMDS cc 
		inner join omop_staging.sus_APC apc on cc.GeneratedRecordID = apc.GeneratedRecordIdentifier
		where apc.NHSNumber is not null
		and cc.PersonWeight is not null
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20value_source_value%20field%20Sus%20CCMDS%20Measurement%20-%20Person%20Weight%20mapping){: .btn }
### Sus APC Measurement
Source column  `DiagnosisICD`.
Resolve Measurement domain ICD10 codes to `Maps To Value` concepts.

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20value_source_value%20field%20Sus%20APC%20Measurement%20mapping){: .btn }
### SACT Measurement Weight at Start of Regimen
* Value copied from `Weight_At_Start_Of_Regimen`

* `Weight_At_Start_Of_Regimen` Weight when the Regimen started [WEIGHT AT START OF REGIMEN]()

```sql
		select distinct 
			NHS_Number,
			Weight_At_Start_Of_Regimen,
			Start_Date_Of_Regimen
		from omop_staging.sact_staging
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20value_source_value%20field%20SACT%20Measurement%20Weight%20at%20Start%20of%20Regimen%20mapping){: .btn }
### SACT Measurement Weight at Start of Cycle
* Value copied from `Weight_At_Start_Of_Cycle`

* `Weight_At_Start_Of_Cycle` Weight when the cycle started [WEIGHT AT START OF CYCLE]()

```sql
		select distinct 
			NHS_Number,
			Weight_At_Start_Of_Cycle,
			Start_Date_Of_Cycle
		from omop_staging.sact_staging
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20value_source_value%20field%20SACT%20Measurement%20Weight%20at%20Start%20of%20Cycle%20mapping){: .btn }
### SACT  Measurement Height
* Value copied from `Height_At_Start_Of_Regimen`

* `Height_At_Start_Of_Regimen` Height when the treatment started [HEIGHT AT START OF TREATMENT]()

```sql
		select distinct 
			NHS_Number,
			Height_At_Start_Of_Regimen,
			Start_Date_Of_Regimen
		from omop_staging.sact_staging
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20value_source_value%20field%20SACT%20%20Measurement%20Height%20mapping){: .btn }
