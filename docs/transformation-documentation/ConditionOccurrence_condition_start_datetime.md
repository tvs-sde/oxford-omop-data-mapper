---
layout: default
title: condition_start_datetime
parent: ConditionOccurrence
grand_parent: Transformation Documentation
has_toc: false
---
# condition_start_datetime
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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_start_datetime%20field%20SUS%20Outpatient%20Condition%20Occurrence%20mapping){: .btn }
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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_start_datetime%20field%20SUS%20Inpatient%20Condition%20Occurrence%20mapping){: .btn }
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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_start_datetime%20field%20SUS%20Inpatient%20Condition%20Occurrence%20mapping){: .btn }
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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_start_datetime%20field%20SACT%20Condition%20Occurrence%20mapping){: .btn }
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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_start_datetime%20field%20Rtds%20Condition%20Occurrence%20mapping){: .btn }
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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_start_datetime%20field%20Oxford%20Condition%20Occurrence%20mapping){: .btn }
### COSD V9 SA Condition Occurrence Secondary Diagnosis ICD
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) is the date the Primary Cancer was confirmed or the Primary Cancer diagnosis was agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
with sa as (
    select distinct
        Record ->> '$.LinkagePatientId.NhsNumber.@extension'
            as NhsNumber,
        Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
            as DateOfPrimaryDiagnosisClinicallyAgreed,
        Record ->> '$.PrimaryPathway.Diagnosis.DiagnosisAdditionalItems.SecondaryDiagnosisIcd.@code'
            as SecondaryDiagnosisIcd
    from omop_staging.cosd_staging_901
    where type = 'SA'
)
select distinct
    NhsNumber,
    DateOfPrimaryDiagnosisClinicallyAgreed,
    SecondaryDiagnosisIcd
from sa
where NhsNumber is not null
  and SecondaryDiagnosisIcd is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_start_datetime%20field%20COSD%20V9%20SA%20Condition%20Occurrence%20Secondary%20Diagnosis%20ICD%20mapping){: .btn }
### COSD V9 SA Condition Occurrence Primary Diagnosis ICD
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) is the date the Primary Cancer was confirmed or the Primary Cancer diagnosis was agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
with sa as (
    select distinct
        Record ->> '$.LinkagePatientId.NhsNumber.@extension'
            as NhsNumber,
        Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
            as DateOfPrimaryDiagnosisClinicallyAgreed,
        Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.PrimaryDiagnosisIcd.@code'
            as PrimaryDiagnosisIcd
    from omop_staging.cosd_staging_901
    where type = 'SA'
)
select distinct
    NhsNumber,
    DateOfPrimaryDiagnosisClinicallyAgreed,
    PrimaryDiagnosisIcd
from sa
where NhsNumber is not null
  and PrimaryDiagnosisIcd is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_start_datetime%20field%20COSD%20V9%20SA%20Condition%20Occurrence%20Primary%20Diagnosis%20ICD%20mapping){: .btn }
### COSD V9 SA Condition Occurrence Original Primary Diagnosis ICD
Source column  `DateOfNonPrimaryCancerDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfNonPrimaryCancerDiagnosisClinicallyAgreed` The date the Non Primary Cancer PATIENT DIAGNOSIS was confirmed or agreed. [DATE OF NON PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_non_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
with sa as (
    select distinct
        Record ->> '$.LinkagePatientId.NhsNumber.@extension'
            as NhsNumber,
        Record ->> '$.NonPrimaryPathway.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed'
            as DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
        Record ->> '$.NonPrimaryPathway.Recurrence.OriginalPrimaryDiagnosisIcd.@code'
            as OriginalPrimaryDiagnosisIcd
    from omop_staging.cosd_staging_901
    where type = 'SA'
)
select distinct
    NhsNumber,
    DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
    OriginalPrimaryDiagnosisIcd
from sa
where NhsNumber is not null
  and OriginalPrimaryDiagnosisIcd is not null
  and DateOfNonPrimaryCancerDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_start_datetime%20field%20COSD%20V9%20SA%20Condition%20Occurrence%20Original%20Primary%20Diagnosis%20ICD%20mapping){: .btn }
### COSD V9 SA Condition Occurrence Cancer Progression ICD
Source column  `DateOfNonPrimaryCancerDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfNonPrimaryCancerDiagnosisClinicallyAgreed` The date the Non Primary Cancer PATIENT DIAGNOSIS was confirmed or agreed. [DATE OF NON PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_non_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
with sa as (
    select distinct
        Record ->> '$.LinkagePatientId.NhsNumber.@extension'
            as NhsNumber,
        Record ->> '$.NonPrimaryPathway.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed'
            as DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
        Record ->> '$.NonPrimaryPathway.Progression.ProgressionIcd.@code'
            as ProgressionIcd
    from omop_staging.cosd_staging_901
    where type = 'SA'
)
select distinct
    NhsNumber,
    DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
    ProgressionIcd
from sa
where NhsNumber is not null
  and ProgressionIcd is not null
  and DateOfNonPrimaryCancerDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_start_datetime%20field%20COSD%20V9%20SA%20Condition%20Occurrence%20Cancer%20Progression%20ICD%20mapping){: .btn }
### COSD V8 SA Condition Occurrence Primary Diagnosis ICD
Source column  `ClinicalDateCancerDiagnosis`.
Converts text to dates.

* `ClinicalDateCancerDiagnosis` DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) is the date the Primary Cancer was confirmed or the Primary Cancer diagnosis was agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
with sa as (
    select distinct
        Record ->> '$.Sarcoma.SarcomaCore.SarcomaCoreLinkagePatientId.NHSNumber.@extension'
            as NhsNumber,
        Record ->> '$.Sarcoma.SarcomaCore.SarcomaCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis'
            as ClinicalDateCancerDiagnosis,
        Record ->> '$.Sarcoma.SarcomaCore.SarcomaCoreLinkageDiagnosticDetails.PrimaryDiagnosis.@code'
            as PrimaryDiagnosis
    from omop_staging.cosd_staging_81
    where type = 'SA'
)
select distinct
    NhsNumber,
    ClinicalDateCancerDiagnosis,
    PrimaryDiagnosis
from sa
where NhsNumber is not null
  and PrimaryDiagnosis is not null
  and ClinicalDateCancerDiagnosis is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_start_datetime%20field%20COSD%20V8%20SA%20Condition%20Occurrence%20Primary%20Diagnosis%20ICD%20mapping){: .btn }
### COSD V8 SA Condition Occurrence Cancer Progression ICD
Source column  `DateOfNonPrimaryCancerDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfNonPrimaryCancerDiagnosisClinicallyAgreed` The date the Non Primary Cancer PATIENT DIAGNOSIS was confirmed or agreed. [DATE OF NON PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_non_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
with sa as (
    select distinct
        Record ->> '$.Sarcoma.SarcomaCore.SarcomaCoreLinkagePatientId.NHSNumber.@extension'
            as NhsNumber,
        Record ->> '$.Sarcoma.SarcomaCore.SarcomaCoreLinkageDiagnosticDetails.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed'
            as DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
        Record ->> '$.Sarcoma.SarcomaCore.SarcomaCoreNonPrimaryCancerPathwayRoute.CancerProgressionICD.@code'
            as CancerProgressionICD
    from omop_staging.cosd_staging_81
    where type = 'SA'
)
select distinct
    NhsNumber,
    DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
    CancerProgressionICD
from sa
where NhsNumber is not null
  and CancerProgressionICD is not null
  and DateOfNonPrimaryCancerDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_start_datetime%20field%20COSD%20V8%20SA%20Condition%20Occurrence%20Cancer%20Progression%20ICD%20mapping){: .btn }
### COSD V9 LV Condition Occurrence Secondary Diagnosis ICD
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) is the date the Primary Cancer was confirmed or the Primary Cancer diagnosis was agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
with lv as (
    select distinct
        Record ->> '$.LinkagePatientId.NhsNumber.@extension'
            as NhsNumber,
        Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
            as DateOfPrimaryDiagnosisClinicallyAgreed,
        Record ->> '$.PrimaryPathway.Diagnosis.DiagnosisAdditionalItems.SecondaryDiagnosisIcd.@code'
            as SecondaryDiagnosisIcd
    from omop_staging.cosd_staging_901
    where type = 'LV'
)
select distinct
    NhsNumber,
    DateOfPrimaryDiagnosisClinicallyAgreed,
    SecondaryDiagnosisIcd
from lv
where NhsNumber is not null
  and SecondaryDiagnosisIcd is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_start_datetime%20field%20COSD%20V9%20LV%20Condition%20Occurrence%20Secondary%20Diagnosis%20ICD%20mapping){: .btn }
### COSD V9 LV Condition Occurrence Primary Diagnosis ICD
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) is the date the Primary Cancer was confirmed or the Primary Cancer diagnosis was agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
with lv as (
    select distinct
        Record ->> '$.LinkagePatientId.NhsNumber.@extension'
            as NhsNumber,
        Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
            as DateOfPrimaryDiagnosisClinicallyAgreed,
        Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.PrimaryDiagnosisIcd.@code'
            as PrimaryDiagnosisIcd
    from omop_staging.cosd_staging_901
    where type = 'LV'
)
select distinct
    NhsNumber,
    DateOfPrimaryDiagnosisClinicallyAgreed,
    PrimaryDiagnosisIcd
from lv
where NhsNumber is not null
  and PrimaryDiagnosisIcd is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_start_datetime%20field%20COSD%20V9%20LV%20Condition%20Occurrence%20Primary%20Diagnosis%20ICD%20mapping){: .btn }
### COSD V9 LV Condition Occurrence Original Primary Diagnosis ICD
Source column  `DateOfNonPrimaryCancerDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfNonPrimaryCancerDiagnosisClinicallyAgreed` The date the Non Primary Cancer PATIENT DIAGNOSIS was confirmed or agreed. [DATE OF NON PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_non_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
with lv as (
    select distinct
        Record ->> '$.LinkagePatientId.NhsNumber.@extension'
            as NhsNumber,
        Record ->> '$.NonPrimaryPathway.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed'
            as DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
        Record ->> '$.NonPrimaryPathway.Recurrence.OriginalPrimaryDiagnosisIcd.@code'
            as OriginalPrimaryDiagnosisIcd
    from omop_staging.cosd_staging_901
    where type = 'LV'
)
select distinct
    NhsNumber,
    DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
    OriginalPrimaryDiagnosisIcd
from lv
where NhsNumber is not null
  and OriginalPrimaryDiagnosisIcd is not null
  and DateOfNonPrimaryCancerDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_start_datetime%20field%20COSD%20V9%20LV%20Condition%20Occurrence%20Original%20Primary%20Diagnosis%20ICD%20mapping){: .btn }
### COSD V9 LV Condition Occurrence Cancer Progression ICD
Source column  `DateOfNonPrimaryCancerDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfNonPrimaryCancerDiagnosisClinicallyAgreed` The date the Non Primary Cancer PATIENT DIAGNOSIS was confirmed or agreed. [DATE OF NON PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_non_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
with lv as (
    select distinct
        Record ->> '$.LinkagePatientId.NhsNumber.@extension'
            as NhsNumber,
        Record ->> '$.NonPrimaryPathway.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed'
            as DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
        Record ->> '$.NonPrimaryPathway.Progression.ProgressionIcd.@code'
            as ProgressionIcd
    from omop_staging.cosd_staging_901
    where type = 'LV'
)
select distinct
    NhsNumber,
    DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
    ProgressionIcd
from lv
where NhsNumber is not null
  and ProgressionIcd is not null
  and DateOfNonPrimaryCancerDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_start_datetime%20field%20COSD%20V9%20LV%20Condition%20Occurrence%20Cancer%20Progression%20ICD%20mapping){: .btn }
### COSD V8 LV Condition Occurrence Primary Diagnosis ICD
Source column  `ClinicalDateCancerDiagnosis`.
Converts text to dates.

* `ClinicalDateCancerDiagnosis` DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) is the date the Primary Cancer was confirmed or the Primary Cancer diagnosis was agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
with lv as (
    select distinct
        Record ->> '$.Liver.LiverCore.LiverCoreLinkagePatientId.NHSNumber.@extension'
            as NhsNumber,
        Record ->> '$.Liver.LiverCore.LiverCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis'
            as ClinicalDateCancerDiagnosis,
        Record ->> '$.Liver.LiverCore.LiverCoreLinkageDiagnosticDetails.PrimaryDiagnosis.@code'
            as PrimaryDiagnosis
    from omop_staging.cosd_staging_81
    where type = 'LV'
)
select distinct
    NhsNumber,
    ClinicalDateCancerDiagnosis,
    PrimaryDiagnosis
from lv
where NhsNumber is not null
  and PrimaryDiagnosis is not null
  and ClinicalDateCancerDiagnosis is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_start_datetime%20field%20COSD%20V8%20LV%20Condition%20Occurrence%20Primary%20Diagnosis%20ICD%20mapping){: .btn }
### COSD V8 LV Condition Occurrence Cancer Progression ICD
Source column  `DateOfNonPrimaryCancerDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfNonPrimaryCancerDiagnosisClinicallyAgreed` The date the Non Primary Cancer PATIENT DIAGNOSIS was confirmed or agreed. [DATE OF NON PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_non_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
with lv as (
    select distinct
        Record ->> '$.Liver.LiverCore.LiverCoreLinkagePatientId.NHSNumber.@extension'
            as NhsNumber,
        Record ->> '$.Liver.LiverCore.LiverCoreLinkageDiagnosticDetails.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed'
            as DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
        Record ->> '$.Liver.LiverCore.LiverCoreNonPrimaryCancerPathwayRoute.CancerProgressionICD.@code'
            as CancerProgressionICD
    from omop_staging.cosd_staging_81
    where type = 'LV'
)
select distinct
    NhsNumber,
    DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
    CancerProgressionICD
from lv
where NhsNumber is not null
  and CancerProgressionICD is not null
  and DateOfNonPrimaryCancerDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_start_datetime%20field%20COSD%20V8%20LV%20Condition%20Occurrence%20Cancer%20Progression%20ICD%20mapping){: .btn }
### COSD V9 HN Condition Occurrence Secondary Diagnosis ICD
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) is the date the Primary Cancer was confirmed or the Primary Cancer diagnosis was agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
with hn as (
    select distinct
        Record ->> '$.LinkagePatientId.NhsNumber.@extension'
            as NhsNumber,
        Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
            as DateOfPrimaryDiagnosisClinicallyAgreed,
        Record ->> '$.PrimaryPathway.Diagnosis.DiagnosisAdditionalItems.SecondaryDiagnosisIcd.@code'
            as SecondaryDiagnosisIcd
    from omop_staging.cosd_staging_901
    where type = 'HN'
)
select distinct
    NhsNumber,
    DateOfPrimaryDiagnosisClinicallyAgreed,
    SecondaryDiagnosisIcd
from hn
where NhsNumber is not null
  and SecondaryDiagnosisIcd is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_start_datetime%20field%20COSD%20V9%20HN%20Condition%20Occurrence%20Secondary%20Diagnosis%20ICD%20mapping){: .btn }
### COSD V9 HN Condition Occurrence Primary Diagnosis ICD
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) is the date the Primary Cancer was confirmed or the Primary Cancer diagnosis was agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
with hn as (
    select distinct
        Record ->> '$.LinkagePatientId.NhsNumber.@extension'
            as NhsNumber,
        Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
            as DateOfPrimaryDiagnosisClinicallyAgreed,
        Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.PrimaryDiagnosisIcd.@code'
            as PrimaryDiagnosisIcd
    from omop_staging.cosd_staging_901
    where type = 'HN'
)
select distinct
    NhsNumber,
    DateOfPrimaryDiagnosisClinicallyAgreed,
    PrimaryDiagnosisIcd
from hn
where NhsNumber is not null
  and PrimaryDiagnosisIcd is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_start_datetime%20field%20COSD%20V9%20HN%20Condition%20Occurrence%20Primary%20Diagnosis%20ICD%20mapping){: .btn }
### COSD V9 HN Condition Occurrence Original Primary Diagnosis ICD
Source column  `DateOfNonPrimaryCancerDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfNonPrimaryCancerDiagnosisClinicallyAgreed` The date the Non Primary Cancer PATIENT DIAGNOSIS was confirmed or agreed. [DATE OF NON PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_non_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
with hn as (
    select distinct
        Record ->> '$.LinkagePatientId.NhsNumber.@extension'
            as NhsNumber,
        Record ->> '$.NonPrimaryPathway.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed'
            as DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
        Record ->> '$.NonPrimaryPathway.Recurrence.OriginalPrimaryDiagnosisIcd.@code'
            as OriginalPrimaryDiagnosisIcd
    from omop_staging.cosd_staging_901
    where type = 'HN'
)
select distinct
    NhsNumber,
    DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
    OriginalPrimaryDiagnosisIcd
from hn
where NhsNumber is not null
  and OriginalPrimaryDiagnosisIcd is not null
  and DateOfNonPrimaryCancerDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_start_datetime%20field%20COSD%20V9%20HN%20Condition%20Occurrence%20Original%20Primary%20Diagnosis%20ICD%20mapping){: .btn }
### COSD V9 HN Condition Occurrence Cancer Progression ICD
Source column  `DateOfNonPrimaryCancerDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfNonPrimaryCancerDiagnosisClinicallyAgreed` The date the Non Primary Cancer PATIENT DIAGNOSIS was confirmed or agreed. [DATE OF NON PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_non_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
with hn as (
    select distinct
        Record ->> '$.LinkagePatientId.NhsNumber.@extension'
            as NhsNumber,
        Record ->> '$.NonPrimaryPathway.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed'
            as DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
        Record ->> '$.NonPrimaryPathway.Progression.ProgressionIcd.@code'
            as ProgressionIcd
    from omop_staging.cosd_staging_901
    where type = 'HN'
)
select distinct
    NhsNumber,
    DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
    ProgressionIcd
from hn
where NhsNumber is not null
  and ProgressionIcd is not null
  and DateOfNonPrimaryCancerDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_start_datetime%20field%20COSD%20V9%20HN%20Condition%20Occurrence%20Cancer%20Progression%20ICD%20mapping){: .btn }
### COSD V8 HN Condition Occurrence Primary Diagnosis ICD
Source column  `ClinicalDateCancerDiagnosis`.
Converts text to dates.

* `ClinicalDateCancerDiagnosis` DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) is the date the Primary Cancer was confirmed or the Primary Cancer diagnosis was agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
with hn as (
    select distinct
        Record ->> '$.HeadNeck.HeadNeckCore.HeadNeckCoreLinkagePatientId.NHSNumber.@extension'
            as NhsNumber,
        Record ->> '$.HeadNeck.HeadNeckCore.HeadNeckCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis'
            as ClinicalDateCancerDiagnosis,
        Record ->> '$.HeadNeck.HeadNeckCore.HeadNeckCoreLinkageDiagnosticDetails.PrimaryDiagnosis.@code'
            as PrimaryDiagnosis
    from omop_staging.cosd_staging_81
    where type = 'HN'
)
select distinct
    NhsNumber,
    ClinicalDateCancerDiagnosis,
    PrimaryDiagnosis
from hn
where NhsNumber is not null
  and PrimaryDiagnosis is not null
  and ClinicalDateCancerDiagnosis is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_start_datetime%20field%20COSD%20V8%20HN%20Condition%20Occurrence%20Primary%20Diagnosis%20ICD%20mapping){: .btn }
### COSD V8 HN Condition Occurrence Cancer Progression ICD
Source column  `DateOfNonPrimaryCancerDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfNonPrimaryCancerDiagnosisClinicallyAgreed` The date the Non Primary Cancer PATIENT DIAGNOSIS was confirmed or agreed. [DATE OF NON PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_non_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
with hn as (
    select distinct
        Record ->> '$.HeadNeck.HeadNeckCore.HeadNeckCoreLinkagePatientId.NHSNumber.@extension'
            as NhsNumber,
        Record ->> '$.HeadNeck.HeadNeckCore.HeadNeckCoreLinkageDiagnosticDetails.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed'
            as DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
        Record ->> '$.HeadNeck.HeadNeckCore.HeadNeckCoreNonPrimaryCancerPathwayRoute.CancerProgressionICD.@code'
            as CancerProgressionICD
    from omop_staging.cosd_staging_81
    where type = 'HN'
)
select distinct
    NhsNumber,
    DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
    CancerProgressionICD
from hn
where NhsNumber is not null
  and CancerProgressionICD is not null
  and DateOfNonPrimaryCancerDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_start_datetime%20field%20COSD%20V8%20HN%20Condition%20Occurrence%20Cancer%20Progression%20ICD%20mapping){: .btn }
### COSD V9 GY Condition Occurrence Secondary Diagnosis ICD
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) is the date the Primary Cancer was confirmed or the Primary Cancer diagnosis was agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
with gy as (
    select distinct
        Record ->> '$.LinkagePatientId.NhsNumber.@extension'
            as NhsNumber,
        Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
            as DateOfPrimaryDiagnosisClinicallyAgreed,
        Record ->> '$.PrimaryPathway.Diagnosis.DiagnosisAdditionalItems.SecondaryDiagnosisIcd.@code'
            as SecondaryDiagnosisIcd
    from omop_staging.cosd_staging_901
    where type = 'GY'
)
select distinct
    NhsNumber,
    DateOfPrimaryDiagnosisClinicallyAgreed,
    SecondaryDiagnosisIcd
from gy
where NhsNumber is not null
  and SecondaryDiagnosisIcd is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_start_datetime%20field%20COSD%20V9%20GY%20Condition%20Occurrence%20Secondary%20Diagnosis%20ICD%20mapping){: .btn }
### COSD V9 GY Condition Occurrence Primary Diagnosis ICD
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) is the date the Primary Cancer was confirmed or the Primary Cancer diagnosis was agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
with gy as (
    select distinct
        Record ->> '$.LinkagePatientId.NhsNumber.@extension'
            as NhsNumber,
        Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
            as DateOfPrimaryDiagnosisClinicallyAgreed,
        Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.PrimaryDiagnosisIcd.@code'
            as PrimaryDiagnosisIcd
    from omop_staging.cosd_staging_901
    where type = 'GY'
)
select distinct
    NhsNumber,
    DateOfPrimaryDiagnosisClinicallyAgreed,
    PrimaryDiagnosisIcd
from gy
where NhsNumber is not null
  and PrimaryDiagnosisIcd is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_start_datetime%20field%20COSD%20V9%20GY%20Condition%20Occurrence%20Primary%20Diagnosis%20ICD%20mapping){: .btn }
### COSD V9 GY Condition Occurrence Original Primary Diagnosis ICD
Source column  `DateOfNonPrimaryCancerDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfNonPrimaryCancerDiagnosisClinicallyAgreed` The date the Non Primary Cancer PATIENT DIAGNOSIS was confirmed or agreed. [DATE OF NON PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_non_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
with gy as (
    select distinct
        Record ->> '$.LinkagePatientId.NhsNumber.@extension'
            as NhsNumber,
        Record ->> '$.NonPrimaryPathway.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed'
            as DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
        Record ->> '$.NonPrimaryPathway.Recurrence.OriginalPrimaryDiagnosisIcd.@code'
            as OriginalPrimaryDiagnosisIcd
    from omop_staging.cosd_staging_901
    where type = 'GY'
)
select distinct
    NhsNumber,
    DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
    OriginalPrimaryDiagnosisIcd
from gy
where NhsNumber is not null
  and OriginalPrimaryDiagnosisIcd is not null
  and DateOfNonPrimaryCancerDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_start_datetime%20field%20COSD%20V9%20GY%20Condition%20Occurrence%20Original%20Primary%20Diagnosis%20ICD%20mapping){: .btn }
### COSD V9 GY Condition Occurrence Cancer Progression ICD
Source column  `DateOfNonPrimaryCancerDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfNonPrimaryCancerDiagnosisClinicallyAgreed` The date the Non Primary Cancer PATIENT DIAGNOSIS was confirmed or agreed. [DATE OF NON PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_non_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
with gy as (
    select distinct
        Record ->> '$.LinkagePatientId.NhsNumber.@extension'
            as NhsNumber,
        Record ->> '$.NonPrimaryPathway.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed'
            as DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
        Record ->> '$.NonPrimaryPathway.Progression.ProgressionIcd.@code'
            as ProgressionIcd
    from omop_staging.cosd_staging_901
    where type = 'GY'
)
select distinct
    NhsNumber,
    DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
    ProgressionIcd
from gy
where NhsNumber is not null
  and ProgressionIcd is not null
  and DateOfNonPrimaryCancerDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_start_datetime%20field%20COSD%20V9%20GY%20Condition%20Occurrence%20Cancer%20Progression%20ICD%20mapping){: .btn }
### COSD V8 GY Condition Occurrence Secondary Diagnosis ICD
Source column  `ClinicalDateCancerDiagnosis`.
Converts text to dates.

* `ClinicalDateCancerDiagnosis` DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) is the date the Primary Cancer was confirmed or the Primary Cancer diagnosis was agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
with gy as (
    select distinct
        Record ->> '$.Gynaecological.GynaecologicalCore.GynaecologicalCoreLinkagePatientId.NHSNumber.@extension'
            as NHSNumber,
        Record ->> '$.Gynaecological.GynaecologicalCore.GynaecologicalCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis'
            as ClinicalDateCancerDiagnosis,
        Record ->> '$.Gynaecological.GynaecologicalCore.GynaecologicalCoreDiagnosis.GynaecologicalCoreDiagnosisAdditionalItems.SecondaryDiagnosisICD.@code'
            as SecondaryDiagnosisICD
    from omop_staging.cosd_staging_81
    where type = 'GY'
)
select distinct
    NHSNumber,
    ClinicalDateCancerDiagnosis,
    SecondaryDiagnosisICD
from gy
where NHSNumber is not null
  and SecondaryDiagnosisICD is not null
  and ClinicalDateCancerDiagnosis is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_start_datetime%20field%20COSD%20V8%20GY%20Condition%20Occurrence%20Secondary%20Diagnosis%20ICD%20mapping){: .btn }
### COSD V8 GY Condition Occurrence Primary Diagnosis ICD
Source column  `ClinicalDateCancerDiagnosis`.
Converts text to dates.

* `ClinicalDateCancerDiagnosis` DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) is the date the Primary Cancer was confirmed or the Primary Cancer diagnosis was agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
with gy as (
    select distinct
        Record ->> '$.Gynaecological.GynaecologicalCore.GynaecologicalCoreLinkagePatientId.NHSNumber.@extension'
            as NHSNumber,
        Record ->> '$.Gynaecological.GynaecologicalCore.GynaecologicalCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis'
            as ClinicalDateCancerDiagnosis,
        Record ->> '$.Gynaecological.GynaecologicalCore.GynaecologicalCoreLinkageDiagnosticDetails.PrimaryDiagnosis.@code'
            as PrimaryDiagnosisICD
    from omop_staging.cosd_staging_81
    where type = 'GY'
)
select distinct
    NHSNumber,
    ClinicalDateCancerDiagnosis,
    PrimaryDiagnosisICD
from gy
where NHSNumber is not null
  and PrimaryDiagnosisICD is not null
  and ClinicalDateCancerDiagnosis is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_start_datetime%20field%20COSD%20V8%20GY%20Condition%20Occurrence%20Primary%20Diagnosis%20ICD%20mapping){: .btn }
### COSD V8 GY Condition Occurrence Cancer Progression ICD
Source column  `DateOfNonPrimaryCancerDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfNonPrimaryCancerDiagnosisClinicallyAgreed` The date the Non Primary Cancer PATIENT DIAGNOSIS was confirmed or agreed. [DATE OF NON PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_non_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
with gy as (
    select distinct
        Record ->> '$.Gynaecological.GynaecologicalCore.GynaecologicalCoreLinkagePatientId.NHSNumber.@extension'
            as NHSNumber,
        Record ->> '$.Gynaecological.GynaecologicalCore.GynaecologicalCoreLinkageDiagnosticDetails.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed'
            as DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
        Record ->> '$.Gynaecological.GynaecologicalCore.GynaecologicalCoreNonPrimaryCancerPathwayRoute.CancerProgressionICD.@code'
            as CancerProgressionICD
    from omop_staging.cosd_staging_81
    where type = 'GY'
)
select distinct
    NHSNumber,
    DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
    CancerProgressionICD
from gy
where NHSNumber is not null
  and CancerProgressionICD is not null
  and DateOfNonPrimaryCancerDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_start_datetime%20field%20COSD%20V8%20GY%20Condition%20Occurrence%20Cancer%20Progression%20ICD%20mapping){: .btn }
### COSD V9 CT Condition Occurrence Secondary Diagnosis ICD
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) is the date the Primary Cancer was confirmed or the Primary Cancer diagnosis was agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
with ct as (
    select distinct
        Record ->> '$.LinkagePatientId.NhsNumber.@extension'
            as NhsNumber,
        Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
            as DateOfPrimaryDiagnosisClinicallyAgreed,
        Record ->> '$.PrimaryPathway.Diagnosis.DiagnosisAdditionalItems.SecondaryDiagnosisIcd.@code'
            as SecondaryDiagnosisIcd
    from omop_staging.cosd_staging_901
    where type = 'CT'
)
select distinct
    NhsNumber,
    DateOfPrimaryDiagnosisClinicallyAgreed,
    SecondaryDiagnosisIcd
from ct
where NhsNumber is not null
  and SecondaryDiagnosisIcd is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_start_datetime%20field%20COSD%20V9%20CT%20Condition%20Occurrence%20Secondary%20Diagnosis%20ICD%20mapping){: .btn }
### COSD V9 CT Condition Occurrence Primary Diagnosis ICD
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) is the date the Primary Cancer was confirmed or the Primary Cancer diagnosis was agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
with ct as (
    select distinct
        Record ->> '$.LinkagePatientId.NhsNumber.@extension'
            as NhsNumber,
        Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
            as DateOfPrimaryDiagnosisClinicallyAgreed,
        Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.PrimaryDiagnosisIcd.@code'
            as PrimaryDiagnosisIcd
    from omop_staging.cosd_staging_901
    where type = 'CT'
)
select distinct
    NhsNumber,
    DateOfPrimaryDiagnosisClinicallyAgreed,
    PrimaryDiagnosisIcd
from ct
where NhsNumber is not null
  and PrimaryDiagnosisIcd is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_start_datetime%20field%20COSD%20V9%20CT%20Condition%20Occurrence%20Primary%20Diagnosis%20ICD%20mapping){: .btn }
### COSD V9 CT Condition Occurrence Original Primary Diagnosis ICD
Source column  `DateOfNonPrimaryCancerDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfNonPrimaryCancerDiagnosisClinicallyAgreed` The date the Non Primary Cancer PATIENT DIAGNOSIS was confirmed or agreed. [DATE OF NON PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_non_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
with ct as (
    select distinct
        Record ->> '$.LinkagePatientId.NhsNumber.@extension'
            as NhsNumber,
        Record ->> '$.NonPrimaryPathway.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed'
            as DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
        Record ->> '$.NonPrimaryPathway.Recurrence.OriginalPrimaryDiagnosisIcd.@code'
            as OriginalPrimaryDiagnosisIcd
    from omop_staging.cosd_staging_901
    where type = 'CT'
)
select distinct
    NhsNumber,
    DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
    OriginalPrimaryDiagnosisIcd
from ct
where NhsNumber is not null
  and OriginalPrimaryDiagnosisIcd is not null
  and DateOfNonPrimaryCancerDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_start_datetime%20field%20COSD%20V9%20CT%20Condition%20Occurrence%20Original%20Primary%20Diagnosis%20ICD%20mapping){: .btn }
### COSD V9 CT Condition Occurrence Cancer Progression ICD
Source column  `DateOfNonPrimaryCancerDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfNonPrimaryCancerDiagnosisClinicallyAgreed` The date the Non Primary Cancer PATIENT DIAGNOSIS was confirmed or agreed. [DATE OF NON PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_non_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
with ct as (
    select distinct
        Record ->> '$.LinkagePatientId.NhsNumber.@extension'
            as NhsNumber,
        Record ->> '$.NonPrimaryPathway.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed'
            as DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
        Record ->> '$.NonPrimaryPathway.Progression.ProgressionIcd.@code'
            as ProgressionIcd
    from omop_staging.cosd_staging_901
    where type = 'CT'
)
select distinct
    NhsNumber,
    DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
    ProgressionIcd
from ct
where NhsNumber is not null
  and ProgressionIcd is not null
  and DateOfNonPrimaryCancerDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_start_datetime%20field%20COSD%20V9%20CT%20Condition%20Occurrence%20Cancer%20Progression%20ICD%20mapping){: .btn }
### COSD V8 CT Condition Occurrence Primary Diagnosis ICD
Source column  `ClinicalDateCancerDiagnosis`.
Converts text to dates.

* `ClinicalDateCancerDiagnosis` DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) is the date the Primary Cancer was confirmed or the Primary Cancer diagnosis was agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
with ct as (
    select distinct
        Record ->> '$.CTYA.CTYACore.CTYACoreLinkagePatientId.NHSNumber.@extension'
            as NHSNumber,
        Record ->> '$.CTYA.CTYACore.CTYACoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis'
            as ClinicalDateCancerDiagnosis,
        Record ->> '$.CTYA.CTYACore.CTYACoreLinkageDiagnosticDetails.PrimaryDiagnosis.@code'
            as PrimaryDiagnosisICD
    from omop_staging.cosd_staging_81
    where type = 'CT'
)
select distinct
    NHSNumber,
    ClinicalDateCancerDiagnosis,
    PrimaryDiagnosisICD
from ct
where NHSNumber is not null
  and PrimaryDiagnosisICD is not null
  and ClinicalDateCancerDiagnosis is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_start_datetime%20field%20COSD%20V8%20CT%20Condition%20Occurrence%20Primary%20Diagnosis%20ICD%20mapping){: .btn }
### COSD V8 CT Condition Occurrence Cancer Progression ICD
Source column  `DateOfNonPrimaryCancerDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfNonPrimaryCancerDiagnosisClinicallyAgreed` The date the Non Primary Cancer PATIENT DIAGNOSIS was confirmed or agreed. [DATE OF NON PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_non_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
with ct as (
    select distinct
        Record ->> '$.CTYA.CTYACore.CTYACoreLinkagePatientId.NHSNumber.@extension'
            as NHSNumber,
        Record ->> '$.CTYA.CTYACore.CTYACoreLinkageDiagnosticDetails.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed'
            as DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
        Record ->> '$.CTYA.CTYACore.CTYACoreNonPrimaryCancerPathwayRoute.CancerProgressionICD.@code'
            as CancerProgressionICD
    from omop_staging.cosd_staging_81
    where type = 'CT'
)
select distinct
    NHSNumber,
    DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
    CancerProgressionICD
from ct
where NHSNumber is not null
  and CancerProgressionICD is not null
  and DateOfNonPrimaryCancerDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_start_datetime%20field%20COSD%20V8%20CT%20Condition%20Occurrence%20Cancer%20Progression%20ICD%20mapping){: .btn }
