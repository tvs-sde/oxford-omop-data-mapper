---
layout: default
title: cause_concept_id
parent: Death
grand_parent: Transformation Documentation
has_toc: false
---
# cause_concept_id
### SUS Inpatient Death
Source column  `DiagnosisICD`.
Resolve ICD10 codes to standard OMOP concepts. If code cannot be mapped, map using the parent code.

* `DiagnosisICD` Primary Diagnosis [PRIMARY DIAGNOSIS]()

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Death%20table%20cause_concept_id%20field%20SUS%20Inpatient%20Death%20mapping){: .btn }
