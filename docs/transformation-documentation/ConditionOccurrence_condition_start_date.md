---
layout: default
title: condition_start_date
parent: ConditionOccurrence
grand_parent: Transformation Documentation
has_toc: false
---
# condition_start_date
### SUS Outpatient Condition Occurrence
Source column  `CDSActivityDate`.
Converts text to dates.

* `CDSActivityDate` Event date [CDS ACTIVITY DATE](https://www.datadictionary.nhs.uk/data_elements/cds_activity_date.html)

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
	order by
		d.DiagnosisICD,
		op.GeneratedRecordIdentifier,
		op.NHSNumber,
		op.CDSActivityDate
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_start_date%20field%20SUS%20Outpatient%20Condition%20Occurrence%20mapping){: .btn }
### SUS Inpatient Condition Occurrence
Source column  `CDSActivityDate`.
Converts text to dates.

* `CDSActivityDate` Event date [CDS ACTIVITY DATE](https://www.datadictionary.nhs.uk/data_elements/cds_activity_date.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_start_date%20field%20SUS%20Inpatient%20Condition%20Occurrence%20mapping){: .btn }
### SUS Inpatient Condition Occurrence
Source column  `CDSActivityDate`.
Converts text to dates.

* `CDSActivityDate` Event date [CDS ACTIVITY DATE](https://www.datadictionary.nhs.uk/data_elements/cds_activity_date.html)

```sql
	select
		distinct
			d.AccidentAndEmergencyDiagnosis,
			ae.GeneratedRecordIdentifier,
			ae.NHSNumber,
			ae.CDSActivityDate
	from omop_staging.sus_AE_diagnosis d
		inner join omop_staging.sus_AE ae
			on d.MessageId = ae.MessageId
	where ae.NHSNumber is not null
	order by
		d.AccidentAndEmergencyDiagnosis,
		ae.GeneratedRecordIdentifier,
		ae.NHSNumber,
		ae.CDSActivityDate
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_start_date%20field%20SUS%20Inpatient%20Condition%20Occurrence%20mapping){: .btn }
### SACT Condition Occurrence
Source column  `Administration_Date`.
Converts text to dates.

* `Administration_Date` SYSTEMIC ANTI-CANCER THERAPY ADMINISTRATION DATE is the date of the Systemic Anti-Cancer Therapy Drug Administration or the date an oral drug was initially dispensed to the PATIENT. [SYSTEMIC ANTI-CANCER THERAPY ADMINISTRATION DATE](https://www.datadictionary.nhs.uk/data_elements/systemic_anti-cancer_therapy_administration_date.html)

```sql
	select
		Primary_Diagnosis,
		replace(NHS_Number, ' ', '') as NHS_Number,
		min(Administration_Date) as Administration_Date
	from omop_staging.sact_staging
	group by
		Primary_Diagnosis,
		NHS_Number
	order by
		NHS_Number,
		Primary_Diagnosis,
		min(Administration_Date)
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_start_date%20field%20SACT%20Condition%20Occurrence%20mapping){: .btn }
### Rtds Condition Occurrence
Source column  `event_start_date`.
Converts text to dates.

* `event_start_date` Appointment Start Time [TREATMENT START DATE (RADIOTHERAPY TREATMENT EPISODE)]()

```sql
with results as (
	select 
		distinct
			(select PatientId from omop_staging.rtds_1_demographics d where d.PatientSer = dc.PatientSer limit 1) as PatientId,
			dc.DiagnosisCode,
			dc.DateStamp as event_start_date,
			dc.DateStamp as event_end_date
	from omop_staging.RTDS_5_Diagnosis_Course dc
	where dc.DiagnosisTableName = 'ICD-10'
)
select
	PatientId,
	DiagnosisCode,
	event_start_date,
	event_end_date
from results
where
    PatientId is not null
    and regexp_matches(patientid, '\d{10}');
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_start_date%20field%20Rtds%20Condition%20Occurrence%20mapping){: .btn }
### Oxford Condition Occurrence
Source column  `EventDate`.
Converts text to dates.

* `EventDate` Event date 

```sql
select
	distinct
		d.NHSNumber,
		e.EventDate,
		e.SuppliedCode
from omop_staging.oxford_gp_event e
	inner join omop_staging.oxford_gp_demographic d
		on e.PatientIdentifier = d.PatientIdentifier
order by
	d.NHSNumber,
	e.EventDate,
	e.SuppliedCode
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_start_date%20field%20Oxford%20Condition%20Occurrence%20mapping){: .btn }
### COSD V9 Lung Condition Occurrence Recurrence
Source column  `DateOfNonPrimaryCancerDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfNonPrimaryCancerDiagnosisClinicallyAgreed` DATE OF NON PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) is the date where the Non Primary Cancer PATIENT DIAGNOSIS was confirmed or agreed. [DATE OF NON PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_non_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
select
    distinct
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
        Record ->> '$.NonPrimaryPathway.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed' as DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
        Record ->> '$.NonPrimaryPathway.Recurrence.OriginalPrimaryDiagnosisIcd.@code' as NonPrimaryRecurrenceOriginalDiagnosis
from omop_staging.cosd_staging_901
where type = 'LU'
  and NonPrimaryRecurrenceOriginalDiagnosis is not null
  and DateOfNonPrimaryCancerDiagnosisClinicallyAgreed is not null
  and NhsNumber is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_start_date%20field%20COSD%20V9%20Lung%20Condition%20Occurrence%20Recurrence%20mapping){: .btn }
### COSD V9 Lung Condition Occurrence Progression
Source column  `NonPrimaryDiagnosisDate`.
Converts text to dates.

* `NonPrimaryDiagnosisDate` DATE OF NON PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) is the date where the Non Primary Cancer PATIENT DIAGNOSIS was confirmed or agreed. [DATE OF NON PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_non_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
select distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
    Record ->> '$.NonPrimaryPathway.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed' as NonPrimaryDiagnosisDate,
    Record ->> '$.NonPrimaryPathway.Progression.ProgressionIcd.@code' as NonPrimaryProgressionOriginalDiagnosis
from omop_staging.cosd_staging_901
where type = 'LU'
  and NonPrimaryProgressionOriginalDiagnosis is not null
  and NonPrimaryDiagnosisDate is not null
  and NhsNumber is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_start_date%20field%20COSD%20V9%20Lung%20Condition%20Occurrence%20Progression%20mapping){: .btn }
### COSD V8 Lung Condition Occurrence Progression
Source column  `NonPrimaryDiagnosisDate`.
Converts text to dates.

* `NonPrimaryDiagnosisDate` DATE OF NON PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) is the date where the Non Primary Cancer PATIENT DIAGNOSIS was confirmed or agreed. [DATE OF NON PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_non_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
select distinct
    Record ->> '$.Lung.LungCore.LungCoreLinkagePatientId.NHSNumber.@extension' as NHSNumber,
    Record ->> '$.Lung.LungCore.LungCoreLinkageDiagnosticDetails.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed' as NonPrimaryDiagnosisDate,
    Record ->> '$.Lung.LungCore.LungCoreNonPrimaryCancerPathwayRoute.CancerProgressionICD.@code' as NonPrimaryProgressionOriginalDiagnosis
from omop_staging.cosd_staging_81
where type = 'LU'
  and NonPrimaryProgressionOriginalDiagnosis is not null
  and NonPrimaryDiagnosisDate is not null
  and NhsNumber is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_start_date%20field%20COSD%20V8%20Lung%20Condition%20Occurrence%20Progression%20mapping){: .btn }
### COSD V8 Lung Condition Occurrence Primary Diagnosis
Source column  `DiagnosisDate`.
Converts text to dates.

* `DiagnosisDate` DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) is the date the Primary Cancer was confirmed or the Primary Cancer diagnosis was agreed. [CLINICAL DATE CANCER DIAGNOSIS]()

```sql
with lung as (
  select 
    Record ->> '$.Lung.LungCore.LungCoreLinkagePatientId.NHSNumber.@extension' as NHSNumber,
    Record ->> '$.Lung.LungCore.LungCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as DiagnosisDate,
    Record ->> '$.Lung.LungCore.LungCoreLinkageDiagnosticDetails.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed' as NonPrimaryDiagnosisDate,
    Record ->> '$.Lung.LungCore.LungCoreDiagnosis.MorphologyICDODiagnosis.@code' as CancerHistology,
    Record ->> '$.Lung.LungCore.LungCoreDiagnosis.TopographyICDO.@code' as CancerTopography,
    Record ->> '$.Lung.LungCore.LungCoreLinkageDiagnosticDetails.PrimaryDiagnosis.@code'as CancerDiagnosis
  from omop_staging.cosd_staging_81 lu
where lu.Type = 'LU'
)

select
distinct
  NHSNumber,
  coalesce(DiagnosisDate, NonPrimaryDiagnosisDate) as DiagnosisDate,
  CancerHistology,
  CancerTopography,
  CancerDiagnosis
from lung
where NHSNumber is not null;

	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_start_date%20field%20COSD%20V8%20Lung%20Condition%20Occurrence%20Primary%20Diagnosis%20mapping){: .btn }
### COSD V8 Lung Condition Occurrence Primary Diagnosis Histology Topography
Source column  `DiagnosisDate`.
Converts text to dates.

* `DiagnosisDate` DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) is the date the Primary Cancer was confirmed or the Primary Cancer diagnosis was agreed. [CLINICAL DATE CANCER DIAGNOSIS]()

```sql
with lung as (
  select 
    Record ->> '$.Lung.LungCore.LungCoreLinkagePatientId.NHSNumber.@extension' as NHSNumber,
    Record ->> '$.Lung.LungCore.LungCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as DiagnosisDate,
    Record ->> '$.Lung.LungCore.LungCoreLinkageDiagnosticDetails.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed' as NonPrimaryDiagnosisDate,
    Record ->> '$.Lung.LungCore.LungCoreDiagnosis.MorphologyICDODiagnosis.@code' as CancerHistology,
    Record ->> '$.Lung.LungCore.LungCoreDiagnosis.TopographyICDO.@code' as CancerTopography,
    Record ->> '$.Lung.LungCore.LungCoreLinkageDiagnosticDetails.PrimaryDiagnosis.@code'as CancerDiagnosis
  from omop_staging.cosd_staging_81 lu
where lu.Type = 'LU'
)

select
distinct
  NHSNumber,
  coalesce(DiagnosisDate, NonPrimaryDiagnosisDate) as DiagnosisDate,
  CancerHistology,
  CancerTopography,
  CancerDiagnosis
from lung
where NHSNumber is not null
  and CancerHistology is not null
  and CancerTopography is not null;

	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_start_date%20field%20COSD%20V8%20Lung%20Condition%20Occurrence%20Primary%20Diagnosis%20Histology%20Topography%20mapping){: .btn }
### Haematological cancer topography from COSD v9
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) is the date the Primary Cancer was confirmed or the Primary Cancer diagnosis was agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
select distinct
    -- NHS Number: unique patient identifier, will be mapped to person_id in a later ETL step
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
    -- Date of primary cancer diagnosis: maps to condition_start_date, will be cast to date type in a later step (format CCYY-MM-DD)
    Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed' as DateOfPrimaryDiagnosisClinicallyAgreed,
    -- ICD-O topography code: maps to condition_source_value, will be mapped to a standard condition_concept_id via ICD-O-3 vocabulary in a later step
    Record ->> '$.PrimaryPathway.Diagnosis.TopographyIcd-o-3.@code' as TopographyIcdo3
from omop_staging.cosd_staging_901
where type = 'HA'
  and NhsNumber is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null
  and TopographyIcdo3 is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_start_date%20field%20Haematological%20cancer%20topography%20from%20COSD%20v9%20mapping){: .btn }
### COSD V9 Haematological Condition Occurrence Secondary Diagnosis ICD
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) is the date the Primary Cancer was confirmed or the Primary Cancer diagnosis was agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
select distinct
    -- NHS Number: unique patient identifier, will be mapped to person_id in a later ETL step
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
    -- Date of primary cancer diagnosis: maps to condition_start_date, will be cast to date type in a later step (format CCYY-MM-DD)
    Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed' as DateOfPrimaryDiagnosisClinicallyAgreed,
    -- Secondary ICD diagnosis code: maps to condition_source_value, will be mapped to a standard condition_concept_id via ICD-10 vocabulary in a later step
    Record ->> '$.PrimaryPathway.Diagnosis.DiagnosisAdditionalItems.SecondaryDiagnosisIcd.@code' as SecondaryDiagnosisIcd
from omop_staging.cosd_staging_901
where type = 'HA'
  and NhsNumber is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null
  and SecondaryDiagnosisIcd is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_start_date%20field%20COSD%20V9%20Haematological%20Condition%20Occurrence%20Secondary%20Diagnosis%20ICD%20mapping){: .btn }
### COSD V9 Haematological Condition Occurrence Progression ICD
Source column  `DateOfNonPrimaryCancerDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfNonPrimaryCancerDiagnosisClinicallyAgreed` DATE OF NON PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) is the date where the non primary cancer patient diagnosis was confirmed or agreed. [DATE OF NON PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_non_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
select distinct
    -- NHS Number: unique patient identifier, will be mapped to person_id in a later ETL step
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
    -- Date of non-primary cancer diagnosis: maps to condition_start_date for the progression event, will be cast to date type in a later step (format CCYY-MM-DD)
    Record ->> '$.NonPrimaryPathway.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed' as DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
    -- ICD code of the cancer progression: maps to condition_source_value, will be mapped to a standard condition_concept_id via ICD-10 vocabulary in a later step
    Record ->> '$.NonPrimaryPathway.Progression.ProgressionIcd.@code' as ProgressionIcd
from omop_staging.cosd_staging_901
where type = 'HA'
  and NhsNumber is not null
  and DateOfNonPrimaryCancerDiagnosisClinicallyAgreed is not null
  and ProgressionIcd is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_start_date%20field%20COSD%20V9%20Haematological%20Condition%20Occurrence%20Progression%20ICD%20mapping){: .btn }
### COSD V9 Haematological Condition Occurrence Primary Diagnosis ICD
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) is the date the Primary Cancer was confirmed or the Primary Cancer diagnosis was agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
select distinct
    -- NHS Number: unique patient identifier, will be mapped to person_id in a later ETL step
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
    -- Date of primary cancer diagnosis: maps to condition_start_date, will be cast to date type in a later step (format CCYY-MM-DD)
    Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed' as DateOfPrimaryDiagnosisClinicallyAgreed,
    -- Primary ICD diagnosis code: maps to condition_source_value, will be mapped to a standard condition_concept_id via ICD-10 vocabulary in a later step
    Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.PrimaryDiagnosisIcd.@code' as PrimaryDiagnosisIcd
from omop_staging.cosd_staging_901
where type = 'HA'
  and NhsNumber is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null
  and PrimaryDiagnosisIcd is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_start_date%20field%20COSD%20V9%20Haematological%20Condition%20Occurrence%20Primary%20Diagnosis%20ICD%20mapping){: .btn }
### COSD V9 Haematological Condition Occurrence Original Primary Diagnosis ICD
Source column  `DateOfNonPrimaryCancerDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfNonPrimaryCancerDiagnosisClinicallyAgreed` DATE OF NON PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) is the date where the non primary cancer patient diagnosis was confirmed or agreed. [DATE OF NON PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_non_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
select distinct
    -- NHS Number: unique patient identifier, will be mapped to person_id in a later ETL step
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
    -- Date of non-primary cancer diagnosis: maps to condition_start_date for the recurrence event, will be cast to date type in a later step (format CCYY-MM-DD)
    Record ->> '$.NonPrimaryPathway.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed' as DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
    -- Original primary ICD diagnosis code at recurrence: maps to condition_source_value, will be mapped to a standard condition_concept_id via ICD-10 vocabulary in a later step
    Record ->> '$.NonPrimaryPathway.Recurrence.OriginalPrimaryDiagnosisIcd.@code' as OriginalPrimaryDiagnosisIcd
from omop_staging.cosd_staging_901
where type = 'HA'
  and NhsNumber is not null
  and DateOfNonPrimaryCancerDiagnosisClinicallyAgreed is not null
  and OriginalPrimaryDiagnosisIcd is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_start_date%20field%20COSD%20V9%20Haematological%20Condition%20Occurrence%20Original%20Primary%20Diagnosis%20ICD%20mapping){: .btn }
### COSD V9 Haematological Condition Occurrence Original Morphology SNOMED
Source column  `DateOfNonPrimaryCancerDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfNonPrimaryCancerDiagnosisClinicallyAgreed` DATE OF NON PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) is the date where the non primary cancer patient diagnosis was confirmed or agreed. [DATE OF NON PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_non_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
select distinct
    -- NHS Number: unique patient identifier, will be mapped to person_id in a later ETL step
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
    -- Date of non-primary cancer diagnosis: maps to condition_start_date, will be cast to date type in a later step (format CCYY-MM-DD)
    Record ->> '$.NonPrimaryPathway.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed' as DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
    -- Original SNOMED morphology code before cancer transformation: maps to condition_source_value, will be mapped to a standard condition_concept_id via SNOMED vocabulary in a later step
    Record ->> '$.NonPrimaryPathway.Transformation.OriginalMorphologySnomed.@code' as OriginalMorphologySnomed
from omop_staging.cosd_staging_901
where type = 'HA'
  and NhsNumber is not null
  and DateOfNonPrimaryCancerDiagnosisClinicallyAgreed is not null
  and OriginalMorphologySnomed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_start_date%20field%20COSD%20V9%20Haematological%20Condition%20Occurrence%20Original%20Morphology%20SNOMED%20mapping){: .btn }
### COSD V9 Haematological Condition Occurrence Original Morphology ICD-O-3
Source column  `DateOfNonPrimaryCancerDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfNonPrimaryCancerDiagnosisClinicallyAgreed` DATE OF NON PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) is the date where the non primary cancer patient diagnosis was confirmed or agreed. [DATE OF NON PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_non_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
select distinct
    -- NHS Number: unique patient identifier, will be mapped to person_id in a later ETL step
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
    -- Date of non-primary cancer diagnosis: maps to condition_start_date, will be cast to date type in a later step (format CCYY-MM-DD)
    Record ->> '$.NonPrimaryPathway.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed' as DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
    -- Original ICD-O morphology code before cancer transformation: maps to condition_source_value, will be mapped to a standard condition_concept_id via ICD-O-3 vocabulary in a later step
    Record ->> '$.NonPrimaryPathway.Transformation.OriginalMorphologyIcd-o-3.@code' as OriginalMorphologyIcdo3
from omop_staging.cosd_staging_901
where type = 'HA'
  and NhsNumber is not null
  and DateOfNonPrimaryCancerDiagnosisClinicallyAgreed is not null
  and OriginalMorphologyIcdo3 is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_start_date%20field%20COSD%20V9%20Haematological%20Condition%20Occurrence%20Original%20Morphology%20ICD-O-3%20mapping){: .btn }
### COSD V9 Haematological Condition Occurrence Morphology SNOMED Transformation
Source column  `DateOfNonPrimaryCancerDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfNonPrimaryCancerDiagnosisClinicallyAgreed` DATE OF NON PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) is the date where the non primary cancer patient diagnosis was confirmed or agreed. [DATE OF NON PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_non_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
select distinct
    -- NHS Number: unique patient identifier, will be mapped to person_id in a later ETL step
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
    -- Date of non-primary cancer diagnosis: maps to condition_start_date, will be cast to date type in a later step (format CCYY-MM-DD)
    Record ->> '$.NonPrimaryPathway.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed' as DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
    -- SNOMED morphology code of the cancer transformation: maps to condition_source_value, will be mapped to a standard condition_concept_id via SNOMED vocabulary in a later step
    Record ->> '$.NonPrimaryPathway.Transformation.MorphologySNOMEDTransformation.MorphologySnomedTransformation.@code' as MorphologySnomedTransformation
from omop_staging.cosd_staging_901
where type = 'HA'
  and NhsNumber is not null
  and DateOfNonPrimaryCancerDiagnosisClinicallyAgreed is not null
  and MorphologySnomedTransformation is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_start_date%20field%20COSD%20V9%20Haematological%20Condition%20Occurrence%20Morphology%20SNOMED%20Transformation%20mapping){: .btn }
### COSD V9 Haematological Condition Occurrence Morphology SNOMED Diagnosis
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) is the date the Primary Cancer was confirmed or the Primary Cancer diagnosis was agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
select distinct
    -- NHS Number: unique patient identifier, will be mapped to person_id in a later ETL step
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
    -- Date of primary cancer diagnosis: maps to condition_start_date, will be cast to date type in a later step (format CCYY-MM-DD)
    Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed' as DateOfPrimaryDiagnosisClinicallyAgreed,
    -- SNOMED morphology code at diagnosis: maps to condition_source_value, will be mapped to a standard condition_concept_id via SNOMED vocabulary in a later step
    Record ->> '$.PrimaryPathway.Diagnosis.MorphologySNOMED.MorphologySnomedDiagnosis.@code' as MorphologySnomedDiagnosis
from omop_staging.cosd_staging_901
where type = 'HA'
  and NhsNumber is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null
  and MorphologySnomedDiagnosis is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_start_date%20field%20COSD%20V9%20Haematological%20Condition%20Occurrence%20Morphology%20SNOMED%20Diagnosis%20mapping){: .btn }
### COSD V9 Haematological Condition Occurrence Morphology ICD-O-3
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) is the date the Primary Cancer was confirmed or the Primary Cancer diagnosis was agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
select distinct
    -- NHS Number: unique patient identifier, will be mapped to person_id in a later ETL step
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
    -- Date of primary cancer diagnosis: maps to condition_start_date, will be cast to date type in a later step (format CCYY-MM-DD)
    Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed' as DateOfPrimaryDiagnosisClinicallyAgreed,
    -- ICD-O morphology code at diagnosis: maps to condition_source_value, will be mapped to a standard condition_concept_id via ICD-O-3 vocabulary in a later step
    Record ->> '$.PrimaryPathway.Diagnosis.MorphologyIcd-o-3.@code' as MorphologyIcdo3
from omop_staging.cosd_staging_901
where type = 'HA'
  and NhsNumber is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null
  and MorphologyIcdo3 is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_start_date%20field%20COSD%20V9%20Haematological%20Condition%20Occurrence%20Morphology%20ICD-O-3%20mapping){: .btn }
### COSD V9 Haematological Condition Occurrence Morphology ICD-O-3 Transformation
Source column  `DateOfNonPrimaryCancerDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfNonPrimaryCancerDiagnosisClinicallyAgreed` DATE OF NON PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) is the date where the non primary cancer patient diagnosis was confirmed or agreed. [DATE OF NON PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_non_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
select distinct
    -- NHS Number: unique patient identifier, will be mapped to person_id in a later ETL step
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
    -- Date of non-primary cancer diagnosis: maps to condition_start_date, will be cast to date type in a later step (format CCYY-MM-DD)
    Record ->> '$.NonPrimaryPathway.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed' as DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
    -- ICD-O morphology code of the cancer transformation: maps to condition_source_value, will be mapped to a standard condition_concept_id via ICD-O-3 vocabulary in a later step
    Record ->> '$.NonPrimaryPathway.Transformation.MorphologyIcd-o-3Transformation.@code' as MorphologyIcdo3Transformation
from omop_staging.cosd_staging_901
where type = 'HA'
  and NhsNumber is not null
  and DateOfNonPrimaryCancerDiagnosisClinicallyAgreed is not null
  and MorphologyIcdo3Transformation is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_start_date%20field%20COSD%20V9%20Haematological%20Condition%20Occurrence%20Morphology%20ICD-O-3%20Transformation%20mapping){: .btn }
### Cosd V8 Condition Occurrence Primary Diagnosis
Source column  `DiagnosisDate`.
Converts text to dates.

* `DiagnosisDate` DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) is the date the Primary Cancer was confirmed or the Primary Cancer diagnosis was agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html), [DATE OF NON PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_non_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
with co as (
  select 
    Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
    Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as DiagnosisDate,
    Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreLinkageDiagnosticDetails.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed' as NonPrimaryDiagnosisDate,
    Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreDiagnosis.MorphologyICDODiagnosis.@code' as CancerHistology,
    Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreDiagnosis.TopographyICDO.@code' as CancerTopography,
    Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreDiagnosis.BasisOfCancerDiagnosis.@code' as BasisOfDiagnosisCancer,
    Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreLinkageDiagnosticDetails.PrimaryDiagnosis.@code' as CancerDiagnosis
  from omop_staging.cosd_staging_81 co
where co.Type = 'CO'
)
select 
	distinct
		NhsNumber,
		coalesce (DiagnosisDate, NonPrimaryDiagnosisDate) as DiagnosisDate,
		BasisOfDiagnosisCancer,
		CancerDiagnosis
from CO
where NhsNumber is not null and
	(
		DiagnosisDate is not null or 
		NonPrimaryDiagnosisDate is not null
	);
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_start_date%20field%20Cosd%20V8%20Condition%20Occurrence%20Primary%20Diagnosis%20mapping){: .btn }
### Cosd V8 Condition Occurrence Primary Diagnosis Histology Topography
Source column  `DiagnosisDate`.
Converts text to dates.

* `DiagnosisDate` DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) is the date the Primary Cancer was confirmed or the Primary Cancer diagnosis was agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html), [DATE OF NON PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_non_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
with co as (
  select 
    Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
    Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as DiagnosisDate,
    Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreLinkageDiagnosticDetails.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed' as NonPrimaryDiagnosisDate,
    Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreDiagnosis.MorphologyICDODiagnosis.@code' as CancerHistology,
    Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreDiagnosis.TopographyICDO.@code' as CancerTopography,
    Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreDiagnosis.BasisOfCancerDiagnosis.@code' as BasisOfDiagnosisCancer,
    Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreLinkageDiagnosticDetails.PrimaryDiagnosis.@code' as CancerDiagnosis
  from omop_staging.cosd_staging_81 co
where co.Type = 'CO'
)
select 
	distinct
		NhsNumber,
		coalesce (DiagnosisDate, NonPrimaryDiagnosisDate) as DiagnosisDate,
		BasisOfDiagnosisCancer,
		CancerHistology,
		CancerTopography
from CO
where NhsNumber is not null and
	(
		DiagnosisDate is not null or 
		NonPrimaryDiagnosisDate is not null
	)
	and (CancerHistology is not null and CancerTopography is not null)
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_start_date%20field%20Cosd%20V8%20Condition%20Occurrence%20Primary%20Diagnosis%20Histology%20Topography%20mapping){: .btn }
### COSD V9 Condition Occurrence Recurrence
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) is the date the Primary Cancer was confirmed or the Primary Cancer diagnosis was agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
with CO as (
	select
		Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
		Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed' as DateOfPrimaryDiagnosisClinicallyAgreed,
		Record ->> '$.PrimaryPathway.Diagnosis.DiagnosisAdditionalItems.SecondaryDiagnosisIcd.@code' as SecondaryDiagnosis
	from omop_staging.cosd_staging_901
	where type = 'CO'
)
select
	NhsNumber,
	DateOfPrimaryDiagnosisClinicallyAgreed,
	max(SecondaryDiagnosis) as SecondaryDiagnosis
from CO
where DateOfPrimaryDiagnosisClinicallyAgreed is not null
  and SecondaryDiagnosis is not null
group by NhsNumber, DateOfPrimaryDiagnosisClinicallyAgreed;

	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_start_date%20field%20COSD%20V9%20Condition%20Occurrence%20Recurrence%20mapping){: .btn }
### COSD V9 Condition Occurrence Recurrence
Source column  `DateOfNonPrimaryCancerDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfNonPrimaryCancerDiagnosisClinicallyAgreed` DATE OF NON PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) is the date where the Non Primary Cancer PATIENT DIAGNOSIS was confirmed or agreed. [DATE OF NON PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_non_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
select
    distinct
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
        Record ->> '$.NonPrimaryPathway.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed' as DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
        Record ->> '$.NonPrimaryPathway.Recurrence.OriginalPrimaryDiagnosisIcd.@code' as NonPrimaryRecurrenceOriginalDiagnosis
from omop_staging.cosd_staging_901
where type = 'CO'
  and NonPrimaryRecurrenceOriginalDiagnosis is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_start_date%20field%20COSD%20V9%20Condition%20Occurrence%20Recurrence%20mapping){: .btn }
### COSD V9 Condition Occurrence Progression
Source column  `NonPrimaryDiagnosisDate`.
Converts text to dates.

* `NonPrimaryDiagnosisDate` DATE OF NON PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) is the date where the Non Primary Cancer PATIENT DIAGNOSIS was confirmed or agreed. [DATE OF NON PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_non_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
select distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
    Record ->> '$.NonPrimaryPathway.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed' as NonPrimaryDiagnosisDate,
    Record ->> '$.NonPrimaryPathway.Progression.ProgressionIcd.@code' as NonPrimaryProgressionOriginalDiagnosis
from omop_staging.cosd_staging_901
where type = 'CO'
  and NonPrimaryProgressionOriginalDiagnosis is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_start_date%20field%20COSD%20V9%20Condition%20Occurrence%20Progression%20mapping){: .btn }
### COSD V9 Condition Occurrence Primary Diagnosis
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) is the date the Primary Cancer was confirmed or the Primary Cancer diagnosis was agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
with co as (
	select
		Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
		Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed' as DateOfPrimaryDiagnosisClinicallyAgreed,
		Record ->> '$.PrimaryPathway.Diagnosis."MorphologyIcd-o-3"."@code"' as CancerHistology,
		Record ->> '$.PrimaryPathway.Diagnosis."TopographyIcd-o-3"."@code"' as CancerTopography,
		Record ->> '$.PrimaryPathway.Diagnosis.BasisOfDiagnosisCancer.@code' as BasisOfDiagnosisCancer,
		Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.PrimaryDiagnosisIcd.@code' as CancerDiagnosis
	from omop_staging.cosd_staging_901
	where type = 'CO'
)
select
	NhsNumber,
	DateOfPrimaryDiagnosisClinicallyAgreed,
	max(BasisOfDiagnosisCancer) as BasisOfDiagnosisCancer,
	CancerDiagnosis
from co
where DateOfPrimaryDiagnosisClinicallyAgreed is not null
group by NhsNumber, DateOfPrimaryDiagnosisClinicallyAgreed, CancerDiagnosis;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_start_date%20field%20COSD%20V9%20Condition%20Occurrence%20Primary%20Diagnosis%20mapping){: .btn }
### COSD V9 Condition Occurrence Primary Diagnosis Histology Topography
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) is the date the Primary Cancer was confirmed or the Primary Cancer diagnosis was agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
select distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
    Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed' as DateOfPrimaryDiagnosisClinicallyAgreed,
    Record ->> '$.PrimaryPathway.Diagnosis.BasisOfDiagnosisCancer.@code' as BasisOfDiagnosisCancer,
    Record ->> '$.PrimaryPathway.Diagnosis."MorphologyIcd-o-3"."@code"' as CancerHistology,
    Record ->> '$.PrimaryPathway.Diagnosis."TopographyIcd-o-3"."@code"' as CancerTopography
from omop_staging.cosd_staging_901
where type = 'CO'
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null
  and CancerHistology is not null
  and CancerTopography not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_start_date%20field%20COSD%20V9%20Condition%20Occurrence%20Primary%20Diagnosis%20Histology%20Topography%20mapping){: .btn }
### COSD V9 Breast Condition Occurrence Secondary Diagnosis
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) is the date the Primary Cancer was confirmed or the Primary Cancer diagnosis was agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
with BR as (
    select
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
        Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed' as DateOfPrimaryDiagnosisClinicallyAgreed,
        Record ->> '$.PrimaryPathway.Diagnosis.DiagnosisAdditionalItems.SecondaryDiagnosisIcd.@code' as SecondaryDiagnosis
    from omop_staging.cosd_staging_901
    where type = 'BR'
)
select
    NhsNumber,
    DateOfPrimaryDiagnosisClinicallyAgreed,
    max(SecondaryDiagnosis) as SecondaryDiagnosis
from BR
where DateOfPrimaryDiagnosisClinicallyAgreed is not null
  and SecondaryDiagnosis is not null
group by NhsNumber, DateOfPrimaryDiagnosisClinicallyAgreed;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_start_date%20field%20COSD%20V9%20Breast%20Condition%20Occurrence%20Secondary%20Diagnosis%20mapping){: .btn }
### COSD V9 Breast Condition Occurrence Recurrence
Source column  `DateOfNonPrimaryCancerDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfNonPrimaryCancerDiagnosisClinicallyAgreed` DATE OF NON PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) is the date where the Non Primary Cancer PATIENT DIAGNOSIS was confirmed or agreed. [DATE OF NON PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_non_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
with BR as (
    select
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
        Record ->> '$.NonPrimaryPathway.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed' as DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
        Record ->> '$.NonPrimaryPathway.Recurrence.OriginalPrimaryDiagnosisIcd.@code' as NonPrimaryRecurrenceOriginalDiagnosis
    from omop_staging.cosd_staging_901
    where type = 'BR'
)
select distinct
    NhsNumber,
    DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
    NonPrimaryRecurrenceOriginalDiagnosis
from BR
where NonPrimaryRecurrenceOriginalDiagnosis is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_start_date%20field%20COSD%20V9%20Breast%20Condition%20Occurrence%20Recurrence%20mapping){: .btn }
### COSD V9 Breast Condition Occurrence Progression
Source column  `NonPrimaryDiagnosisDate`.
Converts text to dates.

* `NonPrimaryDiagnosisDate` DATE OF NON PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) is the date where the Non Primary Cancer PATIENT DIAGNOSIS was confirmed or agreed. [DATE OF NON PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_non_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
with BR as (
    select
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
        Record ->> '$.NonPrimaryPathway.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed' as NonPrimaryDiagnosisDate,
        Record ->> '$.NonPrimaryPathway.Progression.ProgressionIcd.@code' as NonPrimaryProgressionOriginalDiagnosis
    from omop_staging.cosd_staging_901
    where type = 'BR'
)
select distinct
    NhsNumber,
    NonPrimaryDiagnosisDate,
    NonPrimaryProgressionOriginalDiagnosis
from BR
where NonPrimaryProgressionOriginalDiagnosis is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_start_date%20field%20COSD%20V9%20Breast%20Condition%20Occurrence%20Progression%20mapping){: .btn }
### COSD V9 Breast Condition Occurrence Primary Diagnosis
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) is the date the Primary Cancer was confirmed or the Primary Cancer diagnosis was agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
with br as (
    select
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
        Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed' as DateOfPrimaryDiagnosisClinicallyAgreed,
        Record ->> '$.PrimaryPathway.Diagnosis."MorphologyIcd-o-3"."@code"' as CancerHistology,
        Record ->> '$.PrimaryPathway.Diagnosis."TopographyIcd-o-3"."@code"' as CancerTopography,
        Record ->> '$.PrimaryPathway.Diagnosis.BasisOfDiagnosisCancer.@code' as BasisOfDiagnosisCancer,
        Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.PrimaryDiagnosisIcd.@code' as CancerDiagnosis
    from omop_staging.cosd_staging_901
    where type = 'BR'
)
select
    NhsNumber,
    DateOfPrimaryDiagnosisClinicallyAgreed,
    max(BasisOfDiagnosisCancer) as BasisOfDiagnosisCancer,
    CancerDiagnosis
from br
where DateOfPrimaryDiagnosisClinicallyAgreed is not null
group by NhsNumber, DateOfPrimaryDiagnosisClinicallyAgreed, CancerDiagnosis;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_start_date%20field%20COSD%20V9%20Breast%20Condition%20Occurrence%20Primary%20Diagnosis%20mapping){: .btn }
### COSD V9 Breast Condition Occurrence Primary Diagnosis Histology Topography
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) is the date the Primary Cancer was confirmed or the Primary Cancer diagnosis was agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
with BR as (
    select
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
        Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed' as DateOfPrimaryDiagnosisClinicallyAgreed,
        Record ->> '$.PrimaryPathway.Diagnosis.BasisOfDiagnosisCancer.@code' as BasisOfDiagnosisCancer,
        Record ->> '$.PrimaryPathway.Diagnosis."MorphologyIcd-o-3"."@code"' as CancerHistology,
        Record ->> '$.PrimaryPathway.Diagnosis."TopographyIcd-o-3"."@code"' as CancerTopography
    from omop_staging.cosd_staging_901
    where type = 'BR'
)
select distinct
    NhsNumber,
    DateOfPrimaryDiagnosisClinicallyAgreed,
    BasisOfDiagnosisCancer,
    CancerHistology,
    CancerTopography
from BR
where DateOfPrimaryDiagnosisClinicallyAgreed is not null
  and CancerHistology is not null
  and CancerTopography is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_start_date%20field%20COSD%20V9%20Breast%20Condition%20Occurrence%20Primary%20Diagnosis%20Histology%20Topography%20mapping){: .btn }
### COSD V8 Breast Condition Occurrence Progression
Source column  `NonPrimaryDiagnosisDate`.
Converts text to dates.

* `NonPrimaryDiagnosisDate` DATE OF NON PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) is the date where the Non Primary Cancer PATIENT DIAGNOSIS was confirmed or agreed. [DATE OF NON PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_non_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
with BR as (
    select
        Record ->> '$.Breast.BreastCore.BreastCoreLinkagePatientId.NHSNumber.@extension' as NHSNumber,
        Record ->> '$.Breast.BreastCore.BreastCoreLinkageDiagnosticDetails.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed' as NonPrimaryDiagnosisDate,
        Record ->> '$.Breast.BreastCore.BreastCoreNonPrimaryCancerPathwayRoute.CancerProgressionICD.@code' as NonPrimaryProgressionOriginalDiagnosis
    from omop_staging.cosd_staging_81
    where type = 'BR'
)
select distinct
    NHSNumber,
    NonPrimaryDiagnosisDate,
    NonPrimaryProgressionOriginalDiagnosis
from BR
where NonPrimaryProgressionOriginalDiagnosis is not null
  and NonPrimaryDiagnosisDate is not null
  and NHSNumber is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_start_date%20field%20COSD%20V8%20Breast%20Condition%20Occurrence%20Progression%20mapping){: .btn }
### Cosd V8 Breast Condition Occurrence Primary Diagnosis
Source column  `DiagnosisDate`.
Converts text to dates.

* `DiagnosisDate` DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) is the date the Primary Cancer was confirmed or the Primary Cancer diagnosis was agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html), [DATE OF NON PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_non_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
with BR as (
  select 
    Record ->> '$.Breast.BreastCore.BreastCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
    Record ->> '$.Breast.BreastCore.BreastCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as DiagnosisDate,
    Record ->> '$.Breast.BreastCore.BreastCoreLinkageDiagnosticDetails.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed' as NonPrimaryDiagnosisDate,
    Record ->> '$.Breast.BreastCore.BreastCoreDiagnosis.MorphologyICDODiagnosis.@code' as CancerHistology,
    Record ->> '$.Breast.BreastCore.BreastCoreDiagnosis.TopographyICDO.@code' as CancerTopography,
    Record ->> '$.Breast.BreastCore.BreastCoreDiagnosis.BasisOfCancerDiagnosis.@code' as BasisOfDiagnosisCancer,
    Record ->> '$.Breast.BreastCore.BreastCoreLinkageDiagnosticDetails.PrimaryDiagnosis.@code' as CancerDiagnosis
  from omop_staging.cosd_staging_81 
  where Type = 'BR'
)
select 
    distinct
        NhsNumber,
        coalesce (DiagnosisDate, NonPrimaryDiagnosisDate) as DiagnosisDate,
        BasisOfDiagnosisCancer,
        CancerDiagnosis
from BR
where NhsNumber is not null and
    (
        DiagnosisDate is not null or 
        NonPrimaryDiagnosisDate is not null
    );
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_start_date%20field%20Cosd%20V8%20Breast%20Condition%20Occurrence%20Primary%20Diagnosis%20mapping){: .btn }
### Cosd V8 Breast Condition Occurrence Primary Diagnosis Histology Topography
Source column  `DiagnosisDate`.
Converts text to dates.

* `DiagnosisDate` DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) is the date the Primary Cancer was confirmed or the Primary Cancer diagnosis was agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html), [DATE OF NON PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_non_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
with BR as (
  select 
    Record ->> '$.Breast.BreastCore.BreastCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
    Record ->> '$.Breast.BreastCore.BreastCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as DiagnosisDate,
    Record ->> '$.Breast.BreastCore.BreastCoreLinkageDiagnosticDetails.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed' as NonPrimaryDiagnosisDate,
    Record ->> '$.Breast.BreastCore.BreastCoreDiagnosis.MorphologyICDODiagnosis.@code' as CancerHistology,
    Record ->> '$.Breast.BreastCore.BreastCoreDiagnosis.TopographyICDO.@code' as CancerTopography,
    Record ->> '$.Breast.BreastCore.BreastCoreDiagnosis.BasisOfCancerDiagnosis.@code' as BasisOfDiagnosisCancer,
    Record ->> '$.Breast.BreastCore.BreastCoreLinkageDiagnosticDetails.PrimaryDiagnosis.@code' as CancerDiagnosis
  from omop_staging.cosd_staging_81
where Type = 'BR'
)
select 
    distinct
        NhsNumber,
        coalesce (DiagnosisDate, NonPrimaryDiagnosisDate) as DiagnosisDate,
        BasisOfDiagnosisCancer,
        CancerHistology,
        CancerTopography
from BR
where NhsNumber is not null and
    (
        DiagnosisDate is not null or 
        NonPrimaryDiagnosisDate is not null
    )
    and (CancerHistology is not null and CancerTopography is not null)
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_start_date%20field%20Cosd%20V8%20Breast%20Condition%20Occurrence%20Primary%20Diagnosis%20Histology%20Topography%20mapping){: .btn }
