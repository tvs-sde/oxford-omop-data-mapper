---
layout: default
title: condition_end_date
parent: ConditionOccurrence
grand_parent: Transformation Documentation
has_toc: false
---
# condition_end_date
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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_end_date%20field%20SUS%20Outpatient%20Condition%20Occurrence%20mapping){: .btn }
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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_end_date%20field%20SUS%20Inpatient%20Condition%20Occurrence%20mapping){: .btn }
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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_end_date%20field%20SUS%20Inpatient%20Condition%20Occurrence%20mapping){: .btn }
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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_end_date%20field%20SACT%20Condition%20Occurrence%20mapping){: .btn }
### Rtds Condition Occurrence
Source column  `event_end_date`.
Converts text to dates.

* `event_end_date` Appointment End Time 

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_end_date%20field%20Rtds%20Condition%20Occurrence%20mapping){: .btn }
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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_end_date%20field%20Oxford%20Condition%20Occurrence%20mapping){: .btn }
### COSD V9 UR Condition Occurrence Secondary Diagnosis ICD
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) is the date the Primary Cancer was confirmed or the Primary Cancer diagnosis was agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
with ur as (
    select distinct
        Record ->> '$.LinkagePatientId.NhsNumber.@extension'
            as NhsNumber,
        Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
            as DateOfPrimaryDiagnosisClinicallyAgreed,
        Record ->> '$.PrimaryPathway.Diagnosis.DiagnosisAdditionalItems.SecondaryDiagnosisIcd.@code'
            as SecondaryDiagnosisIcd
    from omop_staging.cosd_staging_901
    where type = 'UR'
)
select distinct
    NhsNumber,
    DateOfPrimaryDiagnosisClinicallyAgreed,
    SecondaryDiagnosisIcd
from ur
where NhsNumber is not null
  and SecondaryDiagnosisIcd is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_end_date%20field%20COSD%20V9%20UR%20Condition%20Occurrence%20Secondary%20Diagnosis%20ICD%20mapping){: .btn }
### COSD V9 UR Condition Occurrence Primary Diagnosis ICD
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) is the date the Primary Cancer was confirmed or the Primary Cancer diagnosis was agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
with ur as (
    select distinct
        Record ->> '$.LinkagePatientId.NhsNumber.@extension'
            as NhsNumber,
        Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
            as DateOfPrimaryDiagnosisClinicallyAgreed,
        Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.PrimaryDiagnosisIcd.@code'
            as PrimaryDiagnosisIcd
    from omop_staging.cosd_staging_901
    where type = 'UR'
)
select distinct
    NhsNumber,
    DateOfPrimaryDiagnosisClinicallyAgreed,
    PrimaryDiagnosisIcd
from ur
where NhsNumber is not null
  and PrimaryDiagnosisIcd is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_end_date%20field%20COSD%20V9%20UR%20Condition%20Occurrence%20Primary%20Diagnosis%20ICD%20mapping){: .btn }
### COSD V9 UR Condition Occurrence Original Primary Diagnosis ICD
Source column  `DateOfNonPrimaryCancerDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfNonPrimaryCancerDiagnosisClinicallyAgreed` The date the Non Primary Cancer PATIENT DIAGNOSIS was confirmed or agreed. [DATE OF NON PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_non_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
with ur as (
    select distinct
        Record ->> '$.LinkagePatientId.NhsNumber.@extension'
            as NhsNumber,
        Record ->> '$.NonPrimaryPathway.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed'
            as DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
        Record ->> '$.NonPrimaryPathway.Recurrence.OriginalPrimaryDiagnosisIcd.@code'
            as OriginalPrimaryDiagnosisIcd
    from omop_staging.cosd_staging_901
    where type = 'UR'
)
select distinct
    NhsNumber,
    DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
    OriginalPrimaryDiagnosisIcd
from ur
where NhsNumber is not null
  and OriginalPrimaryDiagnosisIcd is not null
  and DateOfNonPrimaryCancerDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_end_date%20field%20COSD%20V9%20UR%20Condition%20Occurrence%20Original%20Primary%20Diagnosis%20ICD%20mapping){: .btn }
### COSD V9 UR Condition Occurrence Cancer Progression ICD
Source column  `DateOfNonPrimaryCancerDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfNonPrimaryCancerDiagnosisClinicallyAgreed` The date the Non Primary Cancer PATIENT DIAGNOSIS was confirmed or agreed. [DATE OF NON PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_non_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
with ur as (
    select distinct
        Record ->> '$.LinkagePatientId.NhsNumber.@extension'
            as NhsNumber,
        Record ->> '$.NonPrimaryPathway.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed'
            as DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
        Record ->> '$.NonPrimaryPathway.Progression.ProgressionIcd.@code'
            as ProgressionIcd
    from omop_staging.cosd_staging_901
    where type = 'UR'
)
select distinct
    NhsNumber,
    DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
    ProgressionIcd
from ur
where NhsNumber is not null
  and ProgressionIcd is not null
  and DateOfNonPrimaryCancerDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_end_date%20field%20COSD%20V9%20UR%20Condition%20Occurrence%20Cancer%20Progression%20ICD%20mapping){: .btn }
### COSD V8 UR Condition Occurrence Primary Diagnosis ICD
Source column  `ClinicalDateCancerDiagnosis`.
Converts text to dates.

* `ClinicalDateCancerDiagnosis` DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) is the date the Primary Cancer was confirmed or the Primary Cancer diagnosis was agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
with ur as (
    select distinct
        Record ->> '$.Urological.UrologicalCore.UrologicalCoreLinkagePatientId.NHSNumber.@extension'
            as NhsNumber,
        Record ->> '$.Urological.UrologicalCore.UrologicalCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis'
            as ClinicalDateCancerDiagnosis,
        Record ->> '$.Urological.UrologicalCore.UrologicalCoreLinkageDiagnosticDetails.PrimaryDiagnosis.@code'
            as PrimaryDiagnosis
    from omop_staging.cosd_staging_81
    where type = 'UR'
)
select distinct
    NhsNumber,
    ClinicalDateCancerDiagnosis,
    PrimaryDiagnosis
from ur
where NhsNumber is not null
  and PrimaryDiagnosis is not null
  and ClinicalDateCancerDiagnosis is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_end_date%20field%20COSD%20V8%20UR%20Condition%20Occurrence%20Primary%20Diagnosis%20ICD%20mapping){: .btn }
### COSD V8 UR Condition Occurrence Cancer Progression ICD
Source column  `DateOfNonPrimaryCancerDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfNonPrimaryCancerDiagnosisClinicallyAgreed` The date the Non Primary Cancer PATIENT DIAGNOSIS was confirmed or agreed. [DATE OF NON PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_non_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
with ur as (
    select distinct
        Record ->> '$.Urological.UrologicalCore.UrologicalCoreLinkagePatientId.NHSNumber.@extension'
            as NhsNumber,
        Record ->> '$.Urological.UrologicalCore.UrologicalCoreLinkageDiagnosticDetails.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed'
            as DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
        Record ->> '$.Urological.UrologicalCore.UrologicalCoreNonPrimaryCancerPathwayRoute.CancerProgressionICD.@code'
            as CancerProgressionICD
    from omop_staging.cosd_staging_81
    where type = 'UR'
)
select distinct
    NhsNumber,
    DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
    CancerProgressionICD
from ur
where NhsNumber is not null
  and CancerProgressionICD is not null
  and DateOfNonPrimaryCancerDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_end_date%20field%20COSD%20V8%20UR%20Condition%20Occurrence%20Cancer%20Progression%20ICD%20mapping){: .btn }
### COSD V9 UG Condition Occurrence Secondary Diagnosis ICD
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) is the date the Primary Cancer was confirmed or the Primary Cancer diagnosis was agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
with ug as (
    select distinct
        Record ->> '$.LinkagePatientId.NhsNumber.@extension'
            as NhsNumber,
        Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
            as DateOfPrimaryDiagnosisClinicallyAgreed,
        Record ->> '$.PrimaryPathway.Diagnosis.DiagnosisAdditionalItems.SecondaryDiagnosisIcd.@code'
            as SecondaryDiagnosisIcd
    from omop_staging.cosd_staging_901
    where type = 'UG'
)
select distinct
    NhsNumber,
    DateOfPrimaryDiagnosisClinicallyAgreed,
    SecondaryDiagnosisIcd
from ug
where NhsNumber is not null
  and SecondaryDiagnosisIcd is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_end_date%20field%20COSD%20V9%20UG%20Condition%20Occurrence%20Secondary%20Diagnosis%20ICD%20mapping){: .btn }
### COSD V9 UG Condition Occurrence Primary Diagnosis ICD
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) is the date the Primary Cancer was confirmed or the Primary Cancer diagnosis was agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
with ug as (
    select distinct
        Record ->> '$.LinkagePatientId.NhsNumber.@extension'
            as NhsNumber,
        Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
            as DateOfPrimaryDiagnosisClinicallyAgreed,
        Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.PrimaryDiagnosisIcd.@code'
            as PrimaryDiagnosisIcd
    from omop_staging.cosd_staging_901
    where type = 'UG'
)
select distinct
    NhsNumber,
    DateOfPrimaryDiagnosisClinicallyAgreed,
    PrimaryDiagnosisIcd
from ug
where NhsNumber is not null
  and PrimaryDiagnosisIcd is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_end_date%20field%20COSD%20V9%20UG%20Condition%20Occurrence%20Primary%20Diagnosis%20ICD%20mapping){: .btn }
### COSD V9 UG Condition Occurrence Original Primary Diagnosis ICD
Source column  `DateOfNonPrimaryCancerDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfNonPrimaryCancerDiagnosisClinicallyAgreed` The date the Non Primary Cancer PATIENT DIAGNOSIS was confirmed or agreed. [DATE OF NON PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_non_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
with ug as (
    select distinct
        Record ->> '$.LinkagePatientId.NhsNumber.@extension'
            as NhsNumber,
        Record ->> '$.NonPrimaryPathway.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed'
            as DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
        Record ->> '$.NonPrimaryPathway.Recurrence.OriginalPrimaryDiagnosisIcd.@code'
            as OriginalPrimaryDiagnosisIcd
    from omop_staging.cosd_staging_901
    where type = 'UG'
)
select distinct
    NhsNumber,
    DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
    OriginalPrimaryDiagnosisIcd
from ug
where NhsNumber is not null
  and OriginalPrimaryDiagnosisIcd is not null
  and DateOfNonPrimaryCancerDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_end_date%20field%20COSD%20V9%20UG%20Condition%20Occurrence%20Original%20Primary%20Diagnosis%20ICD%20mapping){: .btn }
### COSD V9 UG Condition Occurrence Cancer Progression ICD
Source column  `DateOfNonPrimaryCancerDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfNonPrimaryCancerDiagnosisClinicallyAgreed` The date the Non Primary Cancer PATIENT DIAGNOSIS was confirmed or agreed. [DATE OF NON PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_non_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
with ug as (
    select distinct
        Record ->> '$.LinkagePatientId.NhsNumber.@extension'
            as NhsNumber,
        Record ->> '$.NonPrimaryPathway.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed'
            as DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
        Record ->> '$.NonPrimaryPathway.Progression.ProgressionIcd.@code'
            as ProgressionIcd
    from omop_staging.cosd_staging_901
    where type = 'UG'
)
select distinct
    NhsNumber,
    DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
    ProgressionIcd
from ug
where NhsNumber is not null
  and ProgressionIcd is not null
  and DateOfNonPrimaryCancerDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_end_date%20field%20COSD%20V9%20UG%20Condition%20Occurrence%20Cancer%20Progression%20ICD%20mapping){: .btn }
### COSD V8 UG Condition Occurrence Primary Diagnosis ICD
Source column  `ClinicalDateCancerDiagnosis`.
Converts text to dates.

* `ClinicalDateCancerDiagnosis` DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) is the date the Primary Cancer was confirmed or the Primary Cancer diagnosis was agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
with ug as (
    select distinct
        Record ->> '$.UpperGI.UpperGICore.UpperGICoreLinkagePatientId.NHSNumber.@extension'
            as NhsNumber,
        Record ->> '$.UpperGI.UpperGICore.UpperGICoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis'
            as ClinicalDateCancerDiagnosis,
        Record ->> '$.UpperGI.UpperGICore.UpperGICoreLinkageDiagnosticDetails.PrimaryDiagnosis.@code'
            as PrimaryDiagnosis
    from omop_staging.cosd_staging_81
    where type = 'UG'
)
select distinct
    NhsNumber,
    ClinicalDateCancerDiagnosis,
    PrimaryDiagnosis
from ug
where NhsNumber is not null
  and PrimaryDiagnosis is not null
  and ClinicalDateCancerDiagnosis is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_end_date%20field%20COSD%20V8%20UG%20Condition%20Occurrence%20Primary%20Diagnosis%20ICD%20mapping){: .btn }
### COSD V8 UG Condition Occurrence Cancer Progression ICD
Source column  `DateOfNonPrimaryCancerDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfNonPrimaryCancerDiagnosisClinicallyAgreed` The date the Non Primary Cancer PATIENT DIAGNOSIS was confirmed or agreed. [DATE OF NON PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_non_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
with ug as (
    select distinct
        Record ->> '$.UpperGI.UpperGICore.UpperGICoreLinkagePatientId.NHSNumber.@extension'
            as NhsNumber,
        Record ->> '$.UpperGI.UpperGICore.UpperGICoreLinkageDiagnosticDetails.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed'
            as DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
        Record ->> '$.UpperGI.UpperGICore.UpperGICoreNonPrimaryCancerPathwayRoute.CancerProgressionICD.@code'
            as CancerProgressionICD
    from omop_staging.cosd_staging_81
    where type = 'UG'
)
select distinct
    NhsNumber,
    DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
    CancerProgressionICD
from ug
where NhsNumber is not null
  and CancerProgressionICD is not null
  and DateOfNonPrimaryCancerDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_end_date%20field%20COSD%20V8%20UG%20Condition%20Occurrence%20Cancer%20Progression%20ICD%20mapping){: .btn }
### COSD V9 SK Condition Occurrence Secondary Diagnosis ICD
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) is the date the Primary Cancer was confirmed or the Primary Cancer diagnosis was agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
with sk as (
    select distinct
        Record ->> '$.LinkagePatientId.NhsNumber.@extension'
            as NhsNumber,
        Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
            as DateOfPrimaryDiagnosisClinicallyAgreed,
        Record ->> '$.PrimaryPathway.Diagnosis.DiagnosisAdditionalItems.SecondaryDiagnosisIcd.@code'
            as SecondaryDiagnosisIcd
    from omop_staging.cosd_staging_901
    where type = 'SK'
)
select distinct
    NhsNumber,
    DateOfPrimaryDiagnosisClinicallyAgreed,
    SecondaryDiagnosisIcd
from sk
where NhsNumber is not null
  and SecondaryDiagnosisIcd is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_end_date%20field%20COSD%20V9%20SK%20Condition%20Occurrence%20Secondary%20Diagnosis%20ICD%20mapping){: .btn }
### COSD V9 SK Condition Occurrence Primary Diagnosis ICD
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) is the date the Primary Cancer was confirmed or the Primary Cancer diagnosis was agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
with sk as (
    select distinct
        Record ->> '$.LinkagePatientId.NhsNumber.@extension'
            as NhsNumber,
        Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
            as DateOfPrimaryDiagnosisClinicallyAgreed,
        Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.PrimaryDiagnosisIcd.@code'
            as PrimaryDiagnosisIcd
    from omop_staging.cosd_staging_901
    where type = 'SK'
)
select distinct
    NhsNumber,
    DateOfPrimaryDiagnosisClinicallyAgreed,
    PrimaryDiagnosisIcd
from sk
where NhsNumber is not null
  and PrimaryDiagnosisIcd is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_end_date%20field%20COSD%20V9%20SK%20Condition%20Occurrence%20Primary%20Diagnosis%20ICD%20mapping){: .btn }
### COSD V9 SK Condition Occurrence Original Primary Diagnosis ICD
Source column  `DateOfNonPrimaryCancerDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfNonPrimaryCancerDiagnosisClinicallyAgreed` The date the Non Primary Cancer PATIENT DIAGNOSIS was confirmed or agreed. [DATE OF NON PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_non_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
with sk as (
    select distinct
        Record ->> '$.LinkagePatientId.NhsNumber.@extension'
            as NhsNumber,
        Record ->> '$.NonPrimaryPathway.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed'
            as DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
        Record ->> '$.NonPrimaryPathway.Recurrence.OriginalPrimaryDiagnosisIcd.@code'
            as OriginalPrimaryDiagnosisIcd
    from omop_staging.cosd_staging_901
    where type = 'SK'
)
select distinct
    NhsNumber,
    DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
    OriginalPrimaryDiagnosisIcd
from sk
where NhsNumber is not null
  and OriginalPrimaryDiagnosisIcd is not null
  and DateOfNonPrimaryCancerDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_end_date%20field%20COSD%20V9%20SK%20Condition%20Occurrence%20Original%20Primary%20Diagnosis%20ICD%20mapping){: .btn }
### COSD V9 SK Condition Occurrence Cancer Progression ICD
Source column  `DateOfNonPrimaryCancerDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfNonPrimaryCancerDiagnosisClinicallyAgreed` The date the Non Primary Cancer PATIENT DIAGNOSIS was confirmed or agreed. [DATE OF NON PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_non_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
with sk as (
    select distinct
        Record ->> '$.LinkagePatientId.NhsNumber.@extension'
            as NhsNumber,
        Record ->> '$.NonPrimaryPathway.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed'
            as DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
        Record ->> '$.NonPrimaryPathway.Progression.ProgressionIcd.@code'
            as ProgressionIcd
    from omop_staging.cosd_staging_901
    where type = 'SK'
)
select distinct
    NhsNumber,
    DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
    ProgressionIcd
from sk
where NhsNumber is not null
  and ProgressionIcd is not null
  and DateOfNonPrimaryCancerDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_end_date%20field%20COSD%20V9%20SK%20Condition%20Occurrence%20Cancer%20Progression%20ICD%20mapping){: .btn }
### COSD V8 SK Condition Occurrence Secondary Diagnosis ICD
Source column  `ClinicalDateCancerDiagnosis`.
Converts text to dates.

* `ClinicalDateCancerDiagnosis` DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) is the date the Primary Cancer was confirmed or the Primary Cancer diagnosis was agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
with sk as (
    select distinct
        Record ->> '$.Skin.SkinCore.SkinCoreLinkagePatientId.NHSNumber.@extension'
            as NhsNumber,
        Record ->> '$.Skin.SkinCore.SkinCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis'
            as ClinicalDateCancerDiagnosis,
        Record ->> '$.Skin.SkinCore.SkinCoreDiagnosis.SkinCoreDiagnosisAdditionalItems.SecondaryDiagnosisICD.@code'
            as SecondaryDiagnosisICD
    from omop_staging.cosd_staging_81
    where type = 'SK'
)
select distinct
    NhsNumber,
    ClinicalDateCancerDiagnosis,
    SecondaryDiagnosisICD
from sk
where NhsNumber is not null
  and SecondaryDiagnosisICD is not null
  and ClinicalDateCancerDiagnosis is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_end_date%20field%20COSD%20V8%20SK%20Condition%20Occurrence%20Secondary%20Diagnosis%20ICD%20mapping){: .btn }
### COSD V8 SK Condition Occurrence Primary Diagnosis ICD
Source column  `ClinicalDateCancerDiagnosis`.
Converts text to dates.

* `ClinicalDateCancerDiagnosis` DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) is the date the Primary Cancer was confirmed or the Primary Cancer diagnosis was agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
with sk as (
    select distinct
        Record ->> '$.Skin.SkinCore.SkinCoreLinkagePatientId.NHSNumber.@extension'
            as NhsNumber,
        Record ->> '$.Skin.SkinCore.SkinCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis'
            as ClinicalDateCancerDiagnosis,
        Record ->> '$.Skin.SkinCore.SkinCoreLinkageDiagnosticDetails.PrimaryDiagnosis.@code'
            as PrimaryDiagnosis
    from omop_staging.cosd_staging_81
    where type = 'SK'
)
select distinct
    NhsNumber,
    ClinicalDateCancerDiagnosis,
    PrimaryDiagnosis
from sk
where NhsNumber is not null
  and PrimaryDiagnosis is not null
  and ClinicalDateCancerDiagnosis is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_end_date%20field%20COSD%20V8%20SK%20Condition%20Occurrence%20Primary%20Diagnosis%20ICD%20mapping){: .btn }
### COSD V8 SK Condition Occurrence Cancer Progression ICD
Source column  `DateOfNonPrimaryCancerDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfNonPrimaryCancerDiagnosisClinicallyAgreed` The date the Non Primary Cancer PATIENT DIAGNOSIS was confirmed or agreed. [DATE OF NON PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_non_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
with sk as (
    select distinct
        Record ->> '$.Skin.SkinCore.SkinCoreLinkagePatientId.NHSNumber.@extension'
            as NhsNumber,
        Record ->> '$.Skin.SkinCore.SkinCoreLinkageDiagnosticDetails.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed'
            as DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
        Record ->> '$.Skin.SkinCore.SkinCoreNonPrimaryCancerPathwayRoute.CancerProgressionICD.@code'
            as CancerProgressionICD
    from omop_staging.cosd_staging_81
    where type = 'SK'
)
select distinct
    NhsNumber,
    DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
    CancerProgressionICD
from sk
where NhsNumber is not null
  and CancerProgressionICD is not null
  and DateOfNonPrimaryCancerDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_end_date%20field%20COSD%20V8%20SK%20Condition%20Occurrence%20Cancer%20Progression%20ICD%20mapping){: .btn }
### COSD V9 CR Condition Occurrence Secondary Diagnosis ICD
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) is the date the Primary Cancer was confirmed or the Primary Cancer diagnosis was agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
with cr as (
    select distinct
        Record ->> '$.LinkagePatientId.NhsNumber.@extension'
            as NhsNumber,
        Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
            as DateOfPrimaryDiagnosisClinicallyAgreed,
        Record ->> '$.PrimaryPathway.Diagnosis.DiagnosisAdditionalItems.SecondaryDiagnosisIcd.@code'
            as SecondaryDiagnosisIcd
    from omop_staging.cosd_staging_901
    where type = 'CR'
)
select distinct
    NhsNumber,
    DateOfPrimaryDiagnosisClinicallyAgreed,
    SecondaryDiagnosisIcd
from cr
where NhsNumber is not null
  and SecondaryDiagnosisIcd is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_end_date%20field%20COSD%20V9%20CR%20Condition%20Occurrence%20Secondary%20Diagnosis%20ICD%20mapping){: .btn }
### COSD V9 CR Condition Occurrence Primary Diagnosis ICD
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) is the date the Primary Cancer was confirmed or the Primary Cancer diagnosis was agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
with cr as (
    select distinct
        Record ->> '$.LinkagePatientId.NhsNumber.@extension'
            as NhsNumber,
        Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
            as DateOfPrimaryDiagnosisClinicallyAgreed,
        Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.PrimaryDiagnosisIcd.@code'
            as PrimaryDiagnosisIcd
    from omop_staging.cosd_staging_901
    where type = 'CR'
)
select distinct
    NhsNumber,
    DateOfPrimaryDiagnosisClinicallyAgreed,
    PrimaryDiagnosisIcd
from cr
where NhsNumber is not null
  and PrimaryDiagnosisIcd is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_end_date%20field%20COSD%20V9%20CR%20Condition%20Occurrence%20Primary%20Diagnosis%20ICD%20mapping){: .btn }
### COSD V9 CR Condition Occurrence Original Primary Diagnosis ICD
Source column  `DateOfNonPrimaryCancerDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfNonPrimaryCancerDiagnosisClinicallyAgreed` The date the Non Primary Cancer PATIENT DIAGNOSIS was confirmed or agreed. [DATE OF NON PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_non_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
with cr as (
    select distinct
        Record ->> '$.LinkagePatientId.NhsNumber.@extension'
            as NhsNumber,
        Record ->> '$.NonPrimaryPathway.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed'
            as DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
        Record ->> '$.NonPrimaryPathway.Recurrence.OriginalPrimaryDiagnosisIcd.@code'
            as OriginalPrimaryDiagnosisIcd
    from omop_staging.cosd_staging_901
    where type = 'CR'
)
select distinct
    NhsNumber,
    DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
    OriginalPrimaryDiagnosisIcd
from cr
where NhsNumber is not null
  and OriginalPrimaryDiagnosisIcd is not null
  and DateOfNonPrimaryCancerDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_end_date%20field%20COSD%20V9%20CR%20Condition%20Occurrence%20Original%20Primary%20Diagnosis%20ICD%20mapping){: .btn }
### COSD V9 CR Condition Occurrence Cancer Progression ICD
Source column  `DateOfNonPrimaryCancerDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfNonPrimaryCancerDiagnosisClinicallyAgreed` The date the Non Primary Cancer PATIENT DIAGNOSIS was confirmed or agreed. [DATE OF NON PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_non_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
with cr as (
    select distinct
        Record ->> '$.LinkagePatientId.NhsNumber.@extension'
            as NhsNumber,
        Record ->> '$.NonPrimaryPathway.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed'
            as DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
        Record ->> '$.NonPrimaryPathway.Progression.ProgressionIcd.@code'
            as ProgressionIcd
    from omop_staging.cosd_staging_901
    where type = 'CR'
)
select distinct
    NhsNumber,
    DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
    ProgressionIcd
from cr
where NhsNumber is not null
  and ProgressionIcd is not null
  and DateOfNonPrimaryCancerDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_end_date%20field%20COSD%20V9%20CR%20Condition%20Occurrence%20Cancer%20Progression%20ICD%20mapping){: .btn }
### COSD V8 CR Condition Occurrence Primary Diagnosis ICD
Source column  `ClinicalDateCancerDiagnosis`.
Converts text to dates.

* `ClinicalDateCancerDiagnosis` DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) is the date the Primary Cancer was confirmed or the Primary Cancer diagnosis was agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
with cr as (
    select distinct
        Record ->> '$.Core.CoreCore.CoreLinkagePatientId.NHSNumber.@extension'
            as NHSNumber,
        Record ->> '$.Core.CoreCore.CoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis'
            as ClinicalDateCancerDiagnosis,
        Record ->> '$.Core.CoreCore.CoreLinkageDiagnosticDetails.PrimaryDiagnosis.@code'
            as PrimaryDiagnosisICD
    from omop_staging.cosd_staging_81
    where type = 'CR'
)
select distinct
    NHSNumber,
    ClinicalDateCancerDiagnosis,
    PrimaryDiagnosisICD
from cr
where NHSNumber is not null
  and PrimaryDiagnosisICD is not null
  and ClinicalDateCancerDiagnosis is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_end_date%20field%20COSD%20V8%20CR%20Condition%20Occurrence%20Primary%20Diagnosis%20ICD%20mapping){: .btn }
### COSD V8 CR Condition Occurrence Cancer Progression ICD
Source column  `DateOfNonPrimaryCancerDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfNonPrimaryCancerDiagnosisClinicallyAgreed` The date the Non Primary Cancer PATIENT DIAGNOSIS was confirmed or agreed. [DATE OF NON PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_non_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
with cr as (
    select distinct
        Record ->> '$.Core.CoreCore.CoreLinkagePatientId.NHSNumber.@extension'
            as NHSNumber,
        Record ->> '$.Core.CoreCore.CoreLinkageDiagnosticDetails.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed'
            as DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
        Record ->> '$.Core.CoreCore.CoreNonPrimaryCancerPathwayRoute.CancerProgressionICD.@code'
            as CancerProgressionICD
    from omop_staging.cosd_staging_81
    where type = 'CR'
)
select distinct
    NHSNumber,
    DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
    CancerProgressionICD
from cr
where NHSNumber is not null
  and CancerProgressionICD is not null
  and DateOfNonPrimaryCancerDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_end_date%20field%20COSD%20V8%20CR%20Condition%20Occurrence%20Cancer%20Progression%20ICD%20mapping){: .btn }
### COSD V9 BA Condition Occurrence Secondary Diagnosis ICD
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) is the date the Primary Cancer was confirmed or the Primary Cancer diagnosis was agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
with ba as (
    select distinct
        Record ->> '$.LinkagePatientId.NhsNumber.@extension'
            as NhsNumber,
        Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
            as DateOfPrimaryDiagnosisClinicallyAgreed,
        Record ->> '$.PrimaryPathway.Diagnosis.DiagnosisAdditionalItems.SecondaryDiagnosisIcd.@code'
            as SecondaryDiagnosisIcd
    from omop_staging.cosd_staging_901
    where type = 'BA'
)
select distinct
    NhsNumber,
    DateOfPrimaryDiagnosisClinicallyAgreed,
    SecondaryDiagnosisIcd
from ba
where NhsNumber is not null
  and SecondaryDiagnosisIcd is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_end_date%20field%20COSD%20V9%20BA%20Condition%20Occurrence%20Secondary%20Diagnosis%20ICD%20mapping){: .btn }
### COSD V9 BA Condition Occurrence Primary Diagnosis ICD
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) is the date the Primary Cancer was confirmed or the Primary Cancer diagnosis was agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
with ba as (
    select distinct
        Record ->> '$.LinkagePatientId.NhsNumber.@extension'
            as NhsNumber,
        Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
            as DateOfPrimaryDiagnosisClinicallyAgreed,
        Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.PrimaryDiagnosisIcd.@code'
            as PrimaryDiagnosisIcd
    from omop_staging.cosd_staging_901
    where type = 'BA'
)
select distinct
    NhsNumber,
    DateOfPrimaryDiagnosisClinicallyAgreed,
    PrimaryDiagnosisIcd
from ba
where NhsNumber is not null
  and PrimaryDiagnosisIcd is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_end_date%20field%20COSD%20V9%20BA%20Condition%20Occurrence%20Primary%20Diagnosis%20ICD%20mapping){: .btn }
### COSD V9 BA Condition Occurrence Original Primary Diagnosis ICD
Source column  `DateOfNonPrimaryCancerDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfNonPrimaryCancerDiagnosisClinicallyAgreed` The date the Non Primary Cancer PATIENT DIAGNOSIS was confirmed or agreed. [DATE OF NON PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_non_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
with ba as (
    select distinct
        Record ->> '$.LinkagePatientId.NhsNumber.@extension'
            as NhsNumber,
        Record ->> '$.NonPrimaryPathway.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed'
            as DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
        Record ->> '$.NonPrimaryPathway.Recurrence.OriginalPrimaryDiagnosisIcd.@code'
            as OriginalPrimaryDiagnosisIcd
    from omop_staging.cosd_staging_901
    where type = 'BA'
)
select distinct
    NhsNumber,
    DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
    OriginalPrimaryDiagnosisIcd
from ba
where NhsNumber is not null
  and OriginalPrimaryDiagnosisIcd is not null
  and DateOfNonPrimaryCancerDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_end_date%20field%20COSD%20V9%20BA%20Condition%20Occurrence%20Original%20Primary%20Diagnosis%20ICD%20mapping){: .btn }
### COSD V9 BA Condition Occurrence Cancer Progression ICD
Source column  `DateOfNonPrimaryCancerDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfNonPrimaryCancerDiagnosisClinicallyAgreed` The date the Non Primary Cancer PATIENT DIAGNOSIS was confirmed or agreed. [DATE OF NON PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_non_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
with ba as (
    select distinct
        Record ->> '$.LinkagePatientId.NhsNumber.@extension'
            as NhsNumber,
        Record ->> '$.NonPrimaryPathway.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed'
            as DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
        Record ->> '$.NonPrimaryPathway.Progression.ProgressionIcd.@code'
            as ProgressionIcd
    from omop_staging.cosd_staging_901
    where type = 'BA'
)
select distinct
    NhsNumber,
    DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
    ProgressionIcd
from ba
where NhsNumber is not null
  and ProgressionIcd is not null
  and DateOfNonPrimaryCancerDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_end_date%20field%20COSD%20V9%20BA%20Condition%20Occurrence%20Cancer%20Progression%20ICD%20mapping){: .btn }
### COSD V8 BA Condition Occurrence Provisional Diagnosis ICD
Source column  `ClinicalDateCancerDiagnosis`.
Converts text to dates.

* `ClinicalDateCancerDiagnosis` DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) is the date the Primary Cancer was confirmed or the Primary Cancer diagnosis was agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
with ba as (
    select distinct
        Record ->> '$.CNS.CNSCore.CNSCoreLinkagePatientId.NHSNumber.@extension'
            as NHSNumber,
        Record ->> '$.CNS.CNSCore.CNSCoreCancerCarePlan.CancerMultiTeamDiscussionDate'
            as CancerMultiTeamDiscussionDate,
        Record ->> '$.CNS.CNSCore.CNSCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis'
            as ClinicalDateCancerDiagnosis,
        Record ->> '$.CNS.CNSCore.CNSCoreCancerCarePlan.CNSCancerCarePlan.ICDProvisionalDiagnosis.@code'
            as ProvisionalDiagnosisICD
    from omop_staging.cosd_staging_81
    where type = 'BA'
)
select distinct
    NHSNumber,
    CancerMultiTeamDiscussionDate,
    ClinicalDateCancerDiagnosis,
    ProvisionalDiagnosisICD
from ba
where NHSNumber is not null
  and ProvisionalDiagnosisICD is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_end_date%20field%20COSD%20V8%20BA%20Condition%20Occurrence%20Provisional%20Diagnosis%20ICD%20mapping){: .btn }
### COSD V8 BA Condition Occurrence Primary Diagnosis ICD
Source column  `ClinicalDateCancerDiagnosis`.
Converts text to dates.

* `ClinicalDateCancerDiagnosis` DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) is the date the Primary Cancer was confirmed or the Primary Cancer diagnosis was agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
with ba as (
    select distinct
        Record ->> '$.CNS.CNSCore.CNSCoreLinkagePatientId.NHSNumber.@extension'
            as NHSNumber,
        Record ->> '$.CNS.CNSCore.CNSCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis'
            as ClinicalDateCancerDiagnosis,
        Record ->> '$.CNS.CNSCore.CNSCoreLinkageDiagnosticDetails.PrimaryDiagnosis.@code'
            as PrimaryDiagnosisICD
    from omop_staging.cosd_staging_81
    where type = 'BA'
)
select distinct
    NHSNumber,
    ClinicalDateCancerDiagnosis,
    PrimaryDiagnosisICD
from ba
where NHSNumber is not null
  and PrimaryDiagnosisICD is not null
  and ClinicalDateCancerDiagnosis is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_end_date%20field%20COSD%20V8%20BA%20Condition%20Occurrence%20Primary%20Diagnosis%20ICD%20mapping){: .btn }
### COSD V8 BA Condition Occurrence Cancer Progression ICD
Source column  `DateOfNonPrimaryCancerDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfNonPrimaryCancerDiagnosisClinicallyAgreed` The date the Non Primary Cancer PATIENT DIAGNOSIS was confirmed or agreed. [DATE OF NON PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_non_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
with ba as (
    select distinct
        Record ->> '$.CNS.CNSCore.CNSCoreLinkagePatientId.NHSNumber.@extension'
            as NHSNumber,
        Record ->> '$.CNS.CNSCore.CNSCoreLinkageDiagnosticDetails.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed'
            as DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
        Record ->> '$.CNS.CNSCore.CNSCoreNonPrimaryCancerPathwayRoute.CancerProgressionICD.@code'
            as CancerProgressionICD
    from omop_staging.cosd_staging_81
    where type = 'BA'
)
select distinct
    NHSNumber,
    DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
    CancerProgressionICD
from ba
where NHSNumber is not null
  and CancerProgressionICD is not null
  and DateOfNonPrimaryCancerDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_end_date%20field%20COSD%20V8%20BA%20Condition%20Occurrence%20Cancer%20Progression%20ICD%20mapping){: .btn }
