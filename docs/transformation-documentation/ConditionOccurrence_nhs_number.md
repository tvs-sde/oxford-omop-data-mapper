---
layout: default
title: nhs_number
parent: ConditionOccurrence
grand_parent: Transformation Documentation
has_toc: false
---
# nhs_number
### SUS Outpatient Condition Occurrence
* Value copied from `NHSNumber`

* `NHSNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20nhs_number%20field%20SUS%20Outpatient%20Condition%20Occurrence%20mapping){: .btn }
### SUS Inpatient Condition Occurrence
* Value copied from `NHSNumber`

* `NHSNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20nhs_number%20field%20SUS%20Inpatient%20Condition%20Occurrence%20mapping){: .btn }
### SUS Inpatient Condition Occurrence
* Value copied from `NHSNumber`

* `NHSNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20nhs_number%20field%20SUS%20Inpatient%20Condition%20Occurrence%20mapping){: .btn }
### SACT Condition Occurrence
* Value copied from `NHS_Number`

* `NHS_Number` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20nhs_number%20field%20SACT%20Condition%20Occurrence%20mapping){: .btn }
### Rtds Condition Occurrence
* Value copied from `PatientId`

* `PatientId` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20nhs_number%20field%20Rtds%20Condition%20Occurrence%20mapping){: .btn }
### Oxford Condition Occurrence
* Value copied from `NHSNumber`

* `NHSNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20nhs_number%20field%20Oxford%20Condition%20Occurrence%20mapping){: .btn }
### COSD V9 UR Condition Occurrence Secondary Diagnosis ICD
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number. [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20nhs_number%20field%20COSD%20V9%20UR%20Condition%20Occurrence%20Secondary%20Diagnosis%20ICD%20mapping){: .btn }
### COSD V9 UR Condition Occurrence Primary Diagnosis ICD
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number. [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20nhs_number%20field%20COSD%20V9%20UR%20Condition%20Occurrence%20Primary%20Diagnosis%20ICD%20mapping){: .btn }
### COSD V9 UR Condition Occurrence Original Primary Diagnosis ICD
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number. [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20nhs_number%20field%20COSD%20V9%20UR%20Condition%20Occurrence%20Original%20Primary%20Diagnosis%20ICD%20mapping){: .btn }
### COSD V9 UR Condition Occurrence Cancer Progression ICD
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number. [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20nhs_number%20field%20COSD%20V9%20UR%20Condition%20Occurrence%20Cancer%20Progression%20ICD%20mapping){: .btn }
### COSD V8 UR Condition Occurrence Primary Diagnosis ICD
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number. [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20nhs_number%20field%20COSD%20V8%20UR%20Condition%20Occurrence%20Primary%20Diagnosis%20ICD%20mapping){: .btn }
### COSD V8 UR Condition Occurrence Cancer Progression ICD
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number. [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20nhs_number%20field%20COSD%20V8%20UR%20Condition%20Occurrence%20Cancer%20Progression%20ICD%20mapping){: .btn }
### COSD V9 UG Condition Occurrence Secondary Diagnosis ICD
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number. [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20nhs_number%20field%20COSD%20V9%20UG%20Condition%20Occurrence%20Secondary%20Diagnosis%20ICD%20mapping){: .btn }
### COSD V9 UG Condition Occurrence Primary Diagnosis ICD
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number. [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20nhs_number%20field%20COSD%20V9%20UG%20Condition%20Occurrence%20Primary%20Diagnosis%20ICD%20mapping){: .btn }
### COSD V9 UG Condition Occurrence Original Primary Diagnosis ICD
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number. [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20nhs_number%20field%20COSD%20V9%20UG%20Condition%20Occurrence%20Original%20Primary%20Diagnosis%20ICD%20mapping){: .btn }
### COSD V9 UG Condition Occurrence Cancer Progression ICD
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number. [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20nhs_number%20field%20COSD%20V9%20UG%20Condition%20Occurrence%20Cancer%20Progression%20ICD%20mapping){: .btn }
### COSD V8 UG Condition Occurrence Primary Diagnosis ICD
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number. [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20nhs_number%20field%20COSD%20V8%20UG%20Condition%20Occurrence%20Primary%20Diagnosis%20ICD%20mapping){: .btn }
### COSD V8 UG Condition Occurrence Cancer Progression ICD
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number. [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20nhs_number%20field%20COSD%20V8%20UG%20Condition%20Occurrence%20Cancer%20Progression%20ICD%20mapping){: .btn }
### COSD V9 SK Condition Occurrence Secondary Diagnosis ICD
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number. [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20nhs_number%20field%20COSD%20V9%20SK%20Condition%20Occurrence%20Secondary%20Diagnosis%20ICD%20mapping){: .btn }
### COSD V9 SK Condition Occurrence Primary Diagnosis ICD
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number. [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20nhs_number%20field%20COSD%20V9%20SK%20Condition%20Occurrence%20Primary%20Diagnosis%20ICD%20mapping){: .btn }
### COSD V9 SK Condition Occurrence Original Primary Diagnosis ICD
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number. [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20nhs_number%20field%20COSD%20V9%20SK%20Condition%20Occurrence%20Original%20Primary%20Diagnosis%20ICD%20mapping){: .btn }
### COSD V9 SK Condition Occurrence Cancer Progression ICD
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number. [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20nhs_number%20field%20COSD%20V9%20SK%20Condition%20Occurrence%20Cancer%20Progression%20ICD%20mapping){: .btn }
### COSD V8 SK Condition Occurrence Secondary Diagnosis ICD
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number. [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20nhs_number%20field%20COSD%20V8%20SK%20Condition%20Occurrence%20Secondary%20Diagnosis%20ICD%20mapping){: .btn }
### COSD V8 SK Condition Occurrence Primary Diagnosis ICD
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number. [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20nhs_number%20field%20COSD%20V8%20SK%20Condition%20Occurrence%20Primary%20Diagnosis%20ICD%20mapping){: .btn }
### COSD V8 SK Condition Occurrence Cancer Progression ICD
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number. [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20nhs_number%20field%20COSD%20V8%20SK%20Condition%20Occurrence%20Cancer%20Progression%20ICD%20mapping){: .btn }
### COSD V9 SA Condition Occurrence Secondary Diagnosis ICD
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number. [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20nhs_number%20field%20COSD%20V9%20SA%20Condition%20Occurrence%20Secondary%20Diagnosis%20ICD%20mapping){: .btn }
### COSD V9 SA Condition Occurrence Primary Diagnosis ICD
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number. [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20nhs_number%20field%20COSD%20V9%20SA%20Condition%20Occurrence%20Primary%20Diagnosis%20ICD%20mapping){: .btn }
### COSD V9 SA Condition Occurrence Original Primary Diagnosis ICD
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number. [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20nhs_number%20field%20COSD%20V9%20SA%20Condition%20Occurrence%20Original%20Primary%20Diagnosis%20ICD%20mapping){: .btn }
### COSD V9 SA Condition Occurrence Cancer Progression ICD
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number. [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20nhs_number%20field%20COSD%20V9%20SA%20Condition%20Occurrence%20Cancer%20Progression%20ICD%20mapping){: .btn }
### COSD V8 SA Condition Occurrence Primary Diagnosis ICD
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number. [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20nhs_number%20field%20COSD%20V8%20SA%20Condition%20Occurrence%20Primary%20Diagnosis%20ICD%20mapping){: .btn }
### COSD V8 SA Condition Occurrence Cancer Progression ICD
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number. [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20nhs_number%20field%20COSD%20V8%20SA%20Condition%20Occurrence%20Cancer%20Progression%20ICD%20mapping){: .btn }
### COSD V9 LV Condition Occurrence Secondary Diagnosis ICD
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number. [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20nhs_number%20field%20COSD%20V9%20LV%20Condition%20Occurrence%20Secondary%20Diagnosis%20ICD%20mapping){: .btn }
### COSD V9 LV Condition Occurrence Primary Diagnosis ICD
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number. [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20nhs_number%20field%20COSD%20V9%20LV%20Condition%20Occurrence%20Primary%20Diagnosis%20ICD%20mapping){: .btn }
### COSD V9 LV Condition Occurrence Original Primary Diagnosis ICD
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number. [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20nhs_number%20field%20COSD%20V9%20LV%20Condition%20Occurrence%20Original%20Primary%20Diagnosis%20ICD%20mapping){: .btn }
### COSD V9 LV Condition Occurrence Cancer Progression ICD
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number. [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20nhs_number%20field%20COSD%20V9%20LV%20Condition%20Occurrence%20Cancer%20Progression%20ICD%20mapping){: .btn }
### COSD V8 LV Condition Occurrence Primary Diagnosis ICD
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number. [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20nhs_number%20field%20COSD%20V8%20LV%20Condition%20Occurrence%20Primary%20Diagnosis%20ICD%20mapping){: .btn }
### COSD V8 LV Condition Occurrence Cancer Progression ICD
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number. [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20nhs_number%20field%20COSD%20V8%20LV%20Condition%20Occurrence%20Cancer%20Progression%20ICD%20mapping){: .btn }
### COSD V9 Lung Condition Occurrence Recurrence
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20nhs_number%20field%20COSD%20V9%20Lung%20Condition%20Occurrence%20Recurrence%20mapping){: .btn }
### COSD V9 Lung Condition Occurrence Progression
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20nhs_number%20field%20COSD%20V9%20Lung%20Condition%20Occurrence%20Progression%20mapping){: .btn }
### COSD V8 Lung Condition Occurrence Progression
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20nhs_number%20field%20COSD%20V8%20Lung%20Condition%20Occurrence%20Progression%20mapping){: .btn }
### COSD V8 Lung Condition Occurrence Primary Diagnosis
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20nhs_number%20field%20COSD%20V8%20Lung%20Condition%20Occurrence%20Primary%20Diagnosis%20mapping){: .btn }
### COSD V8 Lung Condition Occurrence Primary Diagnosis Histology Topography
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20nhs_number%20field%20COSD%20V8%20Lung%20Condition%20Occurrence%20Primary%20Diagnosis%20Histology%20Topography%20mapping){: .btn }
### COSD V9 HN Condition Occurrence Secondary Diagnosis ICD
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number. [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20nhs_number%20field%20COSD%20V9%20HN%20Condition%20Occurrence%20Secondary%20Diagnosis%20ICD%20mapping){: .btn }
### COSD V9 HN Condition Occurrence Primary Diagnosis ICD
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number. [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20nhs_number%20field%20COSD%20V9%20HN%20Condition%20Occurrence%20Primary%20Diagnosis%20ICD%20mapping){: .btn }
### COSD V9 HN Condition Occurrence Original Primary Diagnosis ICD
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number. [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20nhs_number%20field%20COSD%20V9%20HN%20Condition%20Occurrence%20Original%20Primary%20Diagnosis%20ICD%20mapping){: .btn }
### COSD V9 HN Condition Occurrence Cancer Progression ICD
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number. [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20nhs_number%20field%20COSD%20V9%20HN%20Condition%20Occurrence%20Cancer%20Progression%20ICD%20mapping){: .btn }
### COSD V8 HN Condition Occurrence Primary Diagnosis ICD
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number. [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20nhs_number%20field%20COSD%20V8%20HN%20Condition%20Occurrence%20Primary%20Diagnosis%20ICD%20mapping){: .btn }
### COSD V8 HN Condition Occurrence Cancer Progression ICD
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number. [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20nhs_number%20field%20COSD%20V8%20HN%20Condition%20Occurrence%20Cancer%20Progression%20ICD%20mapping){: .btn }
### COSD V9 GY Condition Occurrence Secondary Diagnosis ICD
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number. [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20nhs_number%20field%20COSD%20V9%20GY%20Condition%20Occurrence%20Secondary%20Diagnosis%20ICD%20mapping){: .btn }
### COSD V9 GY Condition Occurrence Primary Diagnosis ICD
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number. [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20nhs_number%20field%20COSD%20V9%20GY%20Condition%20Occurrence%20Primary%20Diagnosis%20ICD%20mapping){: .btn }
### COSD V9 GY Condition Occurrence Original Primary Diagnosis ICD
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number. [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20nhs_number%20field%20COSD%20V9%20GY%20Condition%20Occurrence%20Original%20Primary%20Diagnosis%20ICD%20mapping){: .btn }
### COSD V9 GY Condition Occurrence Cancer Progression ICD
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number. [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20nhs_number%20field%20COSD%20V9%20GY%20Condition%20Occurrence%20Cancer%20Progression%20ICD%20mapping){: .btn }
### COSD V8 GY Condition Occurrence Secondary Diagnosis ICD
* Value copied from `NHSNumber`

* `NHSNumber` Patient NHS Number. [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20nhs_number%20field%20COSD%20V8%20GY%20Condition%20Occurrence%20Secondary%20Diagnosis%20ICD%20mapping){: .btn }
### COSD V8 GY Condition Occurrence Primary Diagnosis ICD
* Value copied from `NHSNumber`

* `NHSNumber` Patient NHS Number. [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20nhs_number%20field%20COSD%20V8%20GY%20Condition%20Occurrence%20Primary%20Diagnosis%20ICD%20mapping){: .btn }
### COSD V8 GY Condition Occurrence Cancer Progression ICD
* Value copied from `NHSNumber`

* `NHSNumber` Patient NHS Number. [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20nhs_number%20field%20COSD%20V8%20GY%20Condition%20Occurrence%20Cancer%20Progression%20ICD%20mapping){: .btn }
### COSD V9 CT Condition Occurrence Secondary Diagnosis ICD
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number. [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20nhs_number%20field%20COSD%20V9%20CT%20Condition%20Occurrence%20Secondary%20Diagnosis%20ICD%20mapping){: .btn }
### COSD V9 CT Condition Occurrence Primary Diagnosis ICD
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number. [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20nhs_number%20field%20COSD%20V9%20CT%20Condition%20Occurrence%20Primary%20Diagnosis%20ICD%20mapping){: .btn }
### COSD V9 CT Condition Occurrence Original Primary Diagnosis ICD
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number. [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20nhs_number%20field%20COSD%20V9%20CT%20Condition%20Occurrence%20Original%20Primary%20Diagnosis%20ICD%20mapping){: .btn }
### COSD V9 CT Condition Occurrence Cancer Progression ICD
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number. [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20nhs_number%20field%20COSD%20V9%20CT%20Condition%20Occurrence%20Cancer%20Progression%20ICD%20mapping){: .btn }
### COSD V8 CT Condition Occurrence Primary Diagnosis ICD
* Value copied from `NHSNumber`

* `NHSNumber` Patient NHS Number. [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20nhs_number%20field%20COSD%20V8%20CT%20Condition%20Occurrence%20Primary%20Diagnosis%20ICD%20mapping){: .btn }
### COSD V8 CT Condition Occurrence Cancer Progression ICD
* Value copied from `NHSNumber`

* `NHSNumber` Patient NHS Number. [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20nhs_number%20field%20COSD%20V8%20CT%20Condition%20Occurrence%20Cancer%20Progression%20ICD%20mapping){: .btn }
### COSD V9 CR Condition Occurrence Secondary Diagnosis ICD
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number. [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20nhs_number%20field%20COSD%20V9%20CR%20Condition%20Occurrence%20Secondary%20Diagnosis%20ICD%20mapping){: .btn }
### COSD V9 CR Condition Occurrence Primary Diagnosis ICD
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number. [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20nhs_number%20field%20COSD%20V9%20CR%20Condition%20Occurrence%20Primary%20Diagnosis%20ICD%20mapping){: .btn }
### COSD V9 CR Condition Occurrence Original Primary Diagnosis ICD
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number. [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20nhs_number%20field%20COSD%20V9%20CR%20Condition%20Occurrence%20Original%20Primary%20Diagnosis%20ICD%20mapping){: .btn }
### COSD V9 CR Condition Occurrence Cancer Progression ICD
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number. [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20nhs_number%20field%20COSD%20V9%20CR%20Condition%20Occurrence%20Cancer%20Progression%20ICD%20mapping){: .btn }
### COSD V8 CR Condition Occurrence Primary Diagnosis ICD
* Value copied from `NHSNumber`

* `NHSNumber` Patient NHS Number. [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20nhs_number%20field%20COSD%20V8%20CR%20Condition%20Occurrence%20Primary%20Diagnosis%20ICD%20mapping){: .btn }
### COSD V8 CR Condition Occurrence Cancer Progression ICD
* Value copied from `NHSNumber`

* `NHSNumber` Patient NHS Number. [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20nhs_number%20field%20COSD%20V8%20CR%20Condition%20Occurrence%20Cancer%20Progression%20ICD%20mapping){: .btn }
### Cosd V8 Condition Occurrence Primary Diagnosis
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20nhs_number%20field%20Cosd%20V8%20Condition%20Occurrence%20Primary%20Diagnosis%20mapping){: .btn }
### Cosd V8 Condition Occurrence Primary Diagnosis Histology Topography
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20nhs_number%20field%20Cosd%20V8%20Condition%20Occurrence%20Primary%20Diagnosis%20Histology%20Topography%20mapping){: .btn }
### COSD V9 Condition Occurrence Recurrence
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20nhs_number%20field%20COSD%20V9%20Condition%20Occurrence%20Recurrence%20mapping){: .btn }
### COSD V9 Condition Occurrence Recurrence
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20nhs_number%20field%20COSD%20V9%20Condition%20Occurrence%20Recurrence%20mapping){: .btn }
### COSD V9 Condition Occurrence Progression
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

```sql
select distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
    Record ->> '$.NonPrimaryPathway.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed' as NonPrimaryDiagnosisDate,
    Record ->> '$.NonPrimaryPathway.Progression.ProgressionIcd.@code' as NonPrimaryProgressionOriginalDiagnosis
from omop_staging.cosd_staging_901
where type = 'CO'
  and NonPrimaryProgressionOriginalDiagnosis is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20nhs_number%20field%20COSD%20V9%20Condition%20Occurrence%20Progression%20mapping){: .btn }
### COSD V9 Condition Occurrence Primary Diagnosis
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20nhs_number%20field%20COSD%20V9%20Condition%20Occurrence%20Primary%20Diagnosis%20mapping){: .btn }
### COSD V9 Condition Occurrence Primary Diagnosis Histology Topography
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20nhs_number%20field%20COSD%20V9%20Condition%20Occurrence%20Primary%20Diagnosis%20Histology%20Topography%20mapping){: .btn }
### COSD V9 Breast Condition Occurrence Secondary Diagnosis
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20nhs_number%20field%20COSD%20V9%20Breast%20Condition%20Occurrence%20Secondary%20Diagnosis%20mapping){: .btn }
### COSD V9 Breast Condition Occurrence Recurrence
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20nhs_number%20field%20COSD%20V9%20Breast%20Condition%20Occurrence%20Recurrence%20mapping){: .btn }
### COSD V9 Breast Condition Occurrence Progression
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20nhs_number%20field%20COSD%20V9%20Breast%20Condition%20Occurrence%20Progression%20mapping){: .btn }
### COSD V9 Breast Condition Occurrence Primary Diagnosis
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20nhs_number%20field%20COSD%20V9%20Breast%20Condition%20Occurrence%20Primary%20Diagnosis%20mapping){: .btn }
### COSD V9 Breast Condition Occurrence Primary Diagnosis Histology Topography
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20nhs_number%20field%20COSD%20V9%20Breast%20Condition%20Occurrence%20Primary%20Diagnosis%20Histology%20Topography%20mapping){: .btn }
### COSD V8 Breast Condition Occurrence Progression
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

```sql
with BR as (
    select
        Record ->> '$.Breast.BreastCore.BreastCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
        Record ->> '$.Breast.BreastCore.BreastCoreLinkageDiagnosticDetails.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed' as NonPrimaryDiagnosisDate,
        Record ->> '$.Breast.BreastCore.BreastCoreNonPrimaryCancerPathwayRoute.CancerProgressionICD.@code' as NonPrimaryProgressionOriginalDiagnosis
    from omop_staging.cosd_staging_81
    where type = 'BR'
)
select distinct
    NhsNumber,
    NonPrimaryDiagnosisDate,
    NonPrimaryProgressionOriginalDiagnosis
from BR
where NonPrimaryProgressionOriginalDiagnosis is not null
  and NonPrimaryDiagnosisDate is not null
  and NhsNumber is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20nhs_number%20field%20COSD%20V8%20Breast%20Condition%20Occurrence%20Progression%20mapping){: .btn }
### Cosd V8 Breast Condition Occurrence Primary Diagnosis
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20nhs_number%20field%20Cosd%20V8%20Breast%20Condition%20Occurrence%20Primary%20Diagnosis%20mapping){: .btn }
### Cosd V8 Breast Condition Occurrence Primary Diagnosis Histology Topography
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20nhs_number%20field%20Cosd%20V8%20Breast%20Condition%20Occurrence%20Primary%20Diagnosis%20Histology%20Topography%20mapping){: .btn }
### COSD V9 BA Condition Occurrence Secondary Diagnosis ICD
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number. [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20nhs_number%20field%20COSD%20V9%20BA%20Condition%20Occurrence%20Secondary%20Diagnosis%20ICD%20mapping){: .btn }
### COSD V9 BA Condition Occurrence Primary Diagnosis ICD
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number. [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20nhs_number%20field%20COSD%20V9%20BA%20Condition%20Occurrence%20Primary%20Diagnosis%20ICD%20mapping){: .btn }
### COSD V9 BA Condition Occurrence Original Primary Diagnosis ICD
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number. [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20nhs_number%20field%20COSD%20V9%20BA%20Condition%20Occurrence%20Original%20Primary%20Diagnosis%20ICD%20mapping){: .btn }
### COSD V9 BA Condition Occurrence Cancer Progression ICD
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number. [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20nhs_number%20field%20COSD%20V9%20BA%20Condition%20Occurrence%20Cancer%20Progression%20ICD%20mapping){: .btn }
### COSD V8 BA Condition Occurrence Provisional Diagnosis ICD
* Value copied from `NHSNumber`

* `NHSNumber` Patient NHS Number. [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20nhs_number%20field%20COSD%20V8%20BA%20Condition%20Occurrence%20Provisional%20Diagnosis%20ICD%20mapping){: .btn }
### COSD V8 BA Condition Occurrence Primary Diagnosis ICD
* Value copied from `NHSNumber`

* `NHSNumber` Patient NHS Number. [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20nhs_number%20field%20COSD%20V8%20BA%20Condition%20Occurrence%20Primary%20Diagnosis%20ICD%20mapping){: .btn }
### COSD V8 BA Condition Occurrence Cancer Progression ICD
* Value copied from `NHSNumber`

* `NHSNumber` Patient NHS Number. [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20nhs_number%20field%20COSD%20V8%20BA%20Condition%20Occurrence%20Cancer%20Progression%20ICD%20mapping){: .btn }
