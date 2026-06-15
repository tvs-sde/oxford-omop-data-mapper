---
layout: default
title: procedure_source_value
parent: ProcedureOccurrence
grand_parent: Transformation Documentation
has_toc: false
---
# procedure_source_value
### SUS Outpatient Procedure Occurrence
* Value copied from `PrimaryProcedure`

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_value%20field%20SUS%20Outpatient%20Procedure%20Occurrence%20mapping){: .btn }
### SUS CCMDS Procedure Occurrence
* Value copied from `ProcedureSourceValue`

* `ProcedureSourceValue` Used to look up the Procedure code. [CRITICAL CARE ACTIVITY CODE](https://www.datadictionary.nhs.uk/data_elements/critical_care_activity_code.html)

```sql
with results as
(
	select 
		distinct
			apc.NHSNumber,
			apc.GeneratedRecordIdentifier,
			cc.CriticalCareStartDate as ProcedureOccurrenceStartDate,
			coalesce(cc.CriticalCareStartTime, '00:00:00') as ProcedureOccurrenceStartTime,
			coalesce(cc.CriticalCarePeriodDischargeDate, cc.EventDate) as ProcedureOccurrenceEndDate,
			coalesce(cc.CriticalCarePeriodDischargeTime, '00:00:00') as ProcedureOccurrenceEndTime,
			d.CriticalCareActivityCode as ProcedureSourceValue
	from omop_staging.sus_CCMDS_CriticalCareActivityCode d
		inner join omop_staging.sus_CCMDS cc 
			on d.MessageId = cc.MessageId
		inner join omop_staging.sus_APC apc 
			on cc.GeneratedRecordID = apc.GeneratedRecordIdentifier
	where apc.NHSNumber is not null
		and d.CriticalCareActivityCode != '99'  -- No Defined Critical Care Activity
)
select *
from results
order by 
	NHSNumber,
	GeneratedRecordIdentifier,
	ProcedureOccurrenceStartDate, 
	ProcedureOccurrenceStartTime,
	ProcedureOccurrenceEndDate,
	ProcedureOccurrenceEndTime,
	ProcedureSourceValue

	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_value%20field%20SUS%20CCMDS%20Procedure%20Occurrence%20mapping){: .btn }
### SUS APC Procedure Occurrence
* Value copied from `PrimaryProcedure`

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_value%20field%20SUS%20APC%20Procedure%20Occurrence%20mapping){: .btn }
### SUS AE Procedure Occurrence
* Value copied from `PrimaryProcedure`

* `PrimaryProcedure` 
			ACCIDENT AND EMERGENCY TREATMENT is a six character code, comprising:
				Condition	n2 (see Treatment Table below)
				Sub-Analysis	n1 (see Sub-analysis Table below)
				Local use	up to an3
			 [ACCIDENT and EMERGENCY CLINICAL CODES]()

```sql
		select
			distinct
				ae.GeneratedRecordIdentifier,
				ae.NHSNumber,
				ae.CDSActivityDate as PrimaryProcedureDate,
				p.AccidentAndEmergencyTreatment as PrimaryProcedure
		from omop_staging.sus_AE ae
			inner join omop_staging.sus_AE_treatment p
				on AE.MessageId = p.MessageId
		where NHSNumber is not null
		order by
			ae.GeneratedRecordIdentifier,
			ae.NHSNumber,
			ae.CDSActivityDate,
			p.AccidentAndEmergencyTreatment
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_value%20field%20SUS%20AE%20Procedure%20Occurrence%20mapping){: .btn }
### Rtds Procedure Occurrence
* Value copied from `ProcedureCode`

* `ProcedureCode` OPCS Procedure Code []()

```sql
with records as (
	select
		PatientSer,
		ProcedureCode,
		ActualStartDateTime_s as Start_date,
		ActualEndDateTime_s as End_date
	from omop_staging.rtds_2a_attendances

	union

	select 
		PatientSer,
		ProcedureCode,
		Start_date,
		End_date
	from omop_staging.rtds_2b_plan
), records_with_patient as (
	select
		(select PatientId from omop_staging.rtds_1_demographics d where d.PatientSer = r.PatientSer limit 1) as PatientId,
		r.*
	from records r
)
select distinct
	PatientId,
	ProcedureCode,
	Start_date as event_start_date,
	End_date as event_end_date
from records_with_patient
where PatientId is not null
	and regexp_matches(patientid, '\d{10}');
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_value%20field%20Rtds%20Procedure%20Occurrence%20mapping){: .btn }
### Oxford Procedure Occurrence
* Value copied from `SuppliedCode`

* `SuppliedCode`  

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_value%20field%20Oxford%20Procedure%20Occurrence%20mapping){: .btn }
### COSD V9 UR Procedure Occurrence Procedure Opcs
* Value copied from `ProcedureOpcs`

* `ProcedureOpcs` Patient procedure other than the primary procedure (OPCS). Recommended to record multiple patient procedures where applicable. [PROCEDURE (OPCS)](https://www.datadictionary.nhs.uk/data_elements/procedure__opcs_.html)

```sql
<<<<<<< HEAD
-- Extracts secondary/other procedure OPCS codes from treatment surgery for the Urological cancer area (COSD v9).
-- Treatment is a repeating group and ProcedureOpcs can also repeat within a treatment, so unnest is required.
-- ProcedureOpcs identifies patient procedures other than the primary procedure (OPCS-4 code).
-- ProcedureDate is the date of the procedure in CCYY-MM-DD string format, to be cast to date downstream.
-- The OPCS code will be mapped to a standard OMOP procedure_concept_id in a later ETL step.
=======
>>>>>>> main
with ur as (
    select distinct
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
        unnest ([[Record ->> '$.Treatment.Surgery.ProcedureDate'], Record ->> '$.Treatment[*].Surgery.ProcedureDate'], recursive := true) as ProcedureDate,
<<<<<<< HEAD
        unnest ([[Record ->> '$.Treatment.Surgery.ProcedureOpcs.@code'], Record ->> '$.Treatment[*].Surgery.ProcedureOpcs.@code'], recursive := true) as ProcedureOpcs
=======
        unnest ([[Record ->> '$.Treatment.Surgery.ProcedureOpcs.@code'], Record ->> '$.Treatment.Surgery.ProcedureOpcs[*].@code', Record ->> '$.Treatment[*].Surgery.ProcedureOpcs[*].@code', Record ->> '$.Treatment[*].Surgery.ProcedureOpcs.@code'], recursive := true) as ProcedureOpcs
>>>>>>> main
    from omop_staging.cosd_staging_901
    where type = 'UR'
)
select distinct
    NhsNumber,
    ProcedureDate,
    ProcedureOpcs
from ur
where NhsNumber is not null
  and ProcedureOpcs is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_value%20field%20COSD%20V9%20UR%20Procedure%20Occurrence%20Procedure%20Opcs%20mapping){: .btn }
### COSD V9 UR Procedure Occurrence Primary Procedure Opcs
* Value copied from `PrimaryProcedureOpcs`

* `PrimaryProcedureOpcs` OPCS Classification of Interventions and Procedures code used to identify the primary patient procedure carried out. [PRIMARY PROCEDURE (OPCS)](https://www.datadictionary.nhs.uk/data_elements/primary_procedure__opcs_.html)

```sql
<<<<<<< HEAD
-- Extracts primary procedure OPCS codes from treatment surgery for the Urological cancer area (COSD v9).
-- Treatment is a repeating group, so unnest is required to normalise each treatment entry.
-- PrimaryProcedureOpcs identifies the primary patient procedure carried out (OPCS-4 code).
-- ProcedureDate is the date of the procedure in CCYY-MM-DD string format, to be cast to date downstream.
-- The OPCS code will be mapped to a standard OMOP procedure_concept_id in a later ETL step.
=======
>>>>>>> main
with ur as (
    select distinct
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
        unnest ([[Record ->> '$.Treatment.Surgery.ProcedureDate'], Record ->> '$.Treatment[*].Surgery.ProcedureDate'], recursive := true) as ProcedureDate,
        unnest ([[Record ->> '$.Treatment.Surgery.PrimaryProcedureOpcs.@code'], Record ->> '$.Treatment[*].Surgery.PrimaryProcedureOpcs.@code'], recursive := true) as PrimaryProcedureOpcs
    from omop_staging.cosd_staging_901
    where type = 'UR'
)
select distinct
    NhsNumber,
    ProcedureDate,
    PrimaryProcedureOpcs
from ur
where NhsNumber is not null
  and PrimaryProcedureOpcs is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_value%20field%20COSD%20V9%20UR%20Procedure%20Occurrence%20Primary%20Procedure%20Opcs%20mapping){: .btn }
### COSD V9 UR Procedure Occurrence Diagnostic Procedure Snomed Ct
* Value copied from `DiagnosticProcedureSnomedCt`

* `DiagnosticProcedureSnomedCt` The SNOMED CT concept ID used to identify the diagnostic procedure. [DIAGNOSTIC PROCEDURE (SNOMED CT)](https://www.datadictionary.nhs.uk/data_elements/diagnostic_procedure__snomed_ct_.html)

```sql
<<<<<<< HEAD
-- Extracts diagnostic procedure SNOMED CT codes for the Urological cancer area (COSD v9).
-- These represent diagnostic procedures carried out, identified by SNOMED CT concept ID.
-- The SNOMED CT code will be mapped to a standard OMOP procedure_concept_id in a later ETL step.
-- DiagnosticProcedureDate is a string in CCYY-MM-DD format and will be cast to a date type downstream.
=======
>>>>>>> main
select distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
    Record ->> '$.DiagnosticProcedures.DiagnosticProcedureDate' as DiagnosticProcedureDate,
    Record ->> '$.DiagnosticProcedures.DiagnosticProcedureSnomedCt.@code' as DiagnosticProcedureSnomedCt
from omop_staging.cosd_staging_901
where type = 'UR'
  and NhsNumber is not null
  and DiagnosticProcedureSnomedCt is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_value%20field%20COSD%20V9%20UR%20Procedure%20Occurrence%20Diagnostic%20Procedure%20Snomed%20Ct%20mapping){: .btn }
### COSD V9 UR Procedure Occurrence Diagnostic Procedure Opcs
* Value copied from `DiagnosticProcedureOpcs`

* `DiagnosticProcedureOpcs` The OPCS Classification of Interventions and Procedures code used to identify the diagnostic procedure carried out. [DIAGNOSTIC PROCEDURE (OPCS)](https://www.datadictionary.nhs.uk/data_elements/diagnostic_procedure__opcs_.html)

```sql
<<<<<<< HEAD
-- Extracts diagnostic procedure OPCS codes for the Urological cancer area (COSD v9).
-- These represent diagnostic procedures carried out, identified by OPCS code.
-- The OPCS code will be mapped to a standard OMOP procedure_concept_id in a later ETL step.
-- DiagnosticProcedureDate is a string in CCYY-MM-DD format and will be cast to a date type downstream.
=======
>>>>>>> main
select distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
    Record ->> '$.DiagnosticProcedures.DiagnosticProcedureDate' as DiagnosticProcedureDate,
    Record ->> '$.DiagnosticProcedures.DiagnosticProcedureOpcs.@code' as DiagnosticProcedureOpcs
from omop_staging.cosd_staging_901
where type = 'UR'
  and NhsNumber is not null
  and DiagnosticProcedureOpcs is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_value%20field%20COSD%20V9%20UR%20Procedure%20Occurrence%20Diagnostic%20Procedure%20Opcs%20mapping){: .btn }
### COSD V8 UR Procedure Occurrence Procedure OPCS
<<<<<<< HEAD
* Value copied from `ProcedureOPCS`

* `ProcedureOPCS` Patient procedure other than the primary procedure (OPCS). Recommended to record multiple patient procedures where applicable. [PROCEDURE (OPCS)](https://www.datadictionary.nhs.uk/data_elements/procedure__opcs_.html)

```sql
-- Extracts secondary/other procedure OPCS codes from treatment surgery for the Urological cancer area (COSD v8).
-- UrologicalCoreTreatment is a repeating group and ProcedureOPCS can also repeat within a treatment, so unnest is required.
-- ProcedureOPCS identifies patient procedures other than the primary procedure (OPCS-4 code).
-- ProcedureDate is the date of the procedure in CCYY-MM-DD string format, to be cast to date downstream.
-- The OPCS code will be mapped to a standard OMOP procedure_concept_id in a later ETL step.
with ur as (
    select distinct
        Record ->> '$.Urological.UrologicalCore.UrologicalCoreLinkagePatientId.NHSNumber.@extension' as NHSNumber,
        unnest ([[Record ->> '$.Urological.UrologicalCore.UrologicalCoreTreatment.UrologicalCoreSurgeryAndOtherProcedures.ProcedureDate'], Record ->> '$.Urological.UrologicalCore.UrologicalCoreTreatment[*].UrologicalCoreSurgeryAndOtherProcedures.ProcedureDate'], recursive := true) as ProcedureDate,
        unnest ([[Record ->> '$.Urological.UrologicalCore.UrologicalCoreTreatment.UrologicalCoreSurgeryAndOtherProcedures.ProcedureOPCS.@code'], Record ->> '$.Urological.UrologicalCore.UrologicalCoreTreatment[*].UrologicalCoreSurgeryAndOtherProcedures.ProcedureOPCS.@code'], recursive := true) as ProcedureOPCS
=======
* Value copied from `ProcedureOpcs`

* `ProcedureOpcs` Patient procedure other than the primary procedure (OPCS). Recommended to record multiple patient procedures where applicable. [PROCEDURE (OPCS)](https://www.datadictionary.nhs.uk/data_elements/procedure__opcs_.html)

```sql
with ur as (
    select distinct
        Record ->> '$.Urological.UrologicalCore.UrologicalCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
        unnest ([[Record ->> '$.Urological.UrologicalCore.UrologicalCoreTreatment.UrologicalCoreSurgeryAndOtherProcedures.ProcedureDate'], Record ->> '$.Urological.UrologicalCore.UrologicalCoreTreatment[*].UrologicalCoreSurgeryAndOtherProcedures.ProcedureDate'], recursive := true) as ProcedureDate,
        unnest ([[Record ->> '$.Urological.UrologicalCore.UrologicalCoreTreatment.UrologicalCoreSurgeryAndOtherProcedures.ProcedureOPCS.@code'], Record ->> '$.Urological.UrologicalCore.UrologicalCoreTreatment.UrologicalCoreSurgeryAndOtherProcedures.ProcedureOPCS[*].@code', Record ->> '$.Urological.UrologicalCore.UrologicalCoreTreatment[*].UrologicalCoreSurgeryAndOtherProcedures.ProcedureOPCS[*].@code', Record ->> '$.Urological.UrologicalCore.UrologicalCoreTreatment[*].UrologicalCoreSurgeryAndOtherProcedures.ProcedureOPCS.@code'], recursive := true) as ProcedureOPCS
>>>>>>> main
    from omop_staging.cosd_staging_81
    where type = 'UR'
)
select distinct
<<<<<<< HEAD
    NHSNumber,
    ProcedureDate,
    ProcedureOPCS
from ur
where NHSNumber is not null
=======
    NhsNumber,
    ProcedureDate,
    ProcedureOPCS
from ur
where NhsNumber is not null
>>>>>>> main
  and ProcedureOPCS is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_value%20field%20COSD%20V8%20UR%20Procedure%20Occurrence%20Procedure%20OPCS%20mapping){: .btn }
### COSD V8 UR Procedure Occurrence Primary Procedure OPCS
<<<<<<< HEAD
* Value copied from `PrimaryProcedureOPCS`

* `PrimaryProcedureOPCS` OPCS Classification of Interventions and Procedures code used to identify the primary patient procedure carried out. [PRIMARY PROCEDURE (OPCS)](https://www.datadictionary.nhs.uk/data_elements/primary_procedure__opcs_.html)

```sql
-- Extracts primary procedure OPCS codes from treatment surgery for the Urological cancer area (COSD v8).
-- UrologicalCoreTreatment is a repeating group, so unnest is required to normalise each treatment entry.
-- PrimaryProcedureOPCS identifies the primary patient procedure carried out (OPCS-4 code).
-- ProcedureDate is the date of the procedure in CCYY-MM-DD string format, to be cast to date downstream.
-- The OPCS code will be mapped to a standard OMOP procedure_concept_id in a later ETL step.
with ur as (
    select distinct
        Record ->> '$.Urological.UrologicalCore.UrologicalCoreLinkagePatientId.NHSNumber.@extension' as NHSNumber,
=======
* Value copied from `PrimaryProcedureOpcs`

* `PrimaryProcedureOpcs` OPCS Classification of Interventions and Procedures code used to identify the primary patient procedure carried out. [PRIMARY PROCEDURE (OPCS)](https://www.datadictionary.nhs.uk/data_elements/primary_procedure__opcs_.html)

```sql
with ur as (
    select distinct
        Record ->> '$.Urological.UrologicalCore.UrologicalCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
>>>>>>> main
        unnest ([[Record ->> '$.Urological.UrologicalCore.UrologicalCoreTreatment.UrologicalCoreSurgeryAndOtherProcedures.ProcedureDate'], Record ->> '$.Urological.UrologicalCore.UrologicalCoreTreatment[*].UrologicalCoreSurgeryAndOtherProcedures.ProcedureDate'], recursive := true) as ProcedureDate,
        unnest ([[Record ->> '$.Urological.UrologicalCore.UrologicalCoreTreatment.UrologicalCoreSurgeryAndOtherProcedures.PrimaryProcedureOPCS.@code'], Record ->> '$.Urological.UrologicalCore.UrologicalCoreTreatment[*].UrologicalCoreSurgeryAndOtherProcedures.PrimaryProcedureOPCS.@code'], recursive := true) as PrimaryProcedureOPCS
    from omop_staging.cosd_staging_81
    where type = 'UR'
)
select distinct
<<<<<<< HEAD
    NHSNumber,
    ProcedureDate,
    PrimaryProcedureOPCS
from ur
where NHSNumber is not null
=======
    NhsNumber,
    ProcedureDate,
    PrimaryProcedureOPCS
from ur
where NhsNumber is not null
>>>>>>> main
  and PrimaryProcedureOPCS is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_value%20field%20COSD%20V8%20UR%20Procedure%20Occurrence%20Primary%20Procedure%20OPCS%20mapping){: .btn }
<<<<<<< HEAD
=======
### COSD V9 UG Procedure Occurrence Procedure Opcs
* Value copied from `ProcedureOpcs`

* `ProcedureOpcs` Patient procedure other than the primary procedure (OPCS). Recommended to record multiple patient procedures where applicable. [PROCEDURE (OPCS)](https://www.datadictionary.nhs.uk/data_elements/procedure__opcs_.html)

```sql
with ug as (
    select distinct
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,

        unnest ([[Record ->> '$.Treatment.Surgery.ProcedureOpcs.@code'], Record ->> '$.Treatment[*].Surgery.ProcedureOpcs[*].@code'], recursive := true) as ProcedureOpcs,

        unnest ([[Record ->> '$.Treatment.Surgery.ProcedureDate'], Record ->> '$.Treatment[*].Surgery.ProcedureDate'], recursive := true) as ProcedureDate
    from omop_staging.cosd_staging_901
    where type = 'UG'
)
select distinct
    NhsNumber,
    ProcedureOpcs,
    ProcedureDate
from ug
where NhsNumber is not null
  and ProcedureOpcs is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_value%20field%20COSD%20V9%20UG%20Procedure%20Occurrence%20Procedure%20Opcs%20mapping){: .btn }
### COSD V9 UG Procedure Occurrence Primary Procedure Opcs
* Value copied from `PrimaryProcedureOpcs`

* `PrimaryProcedureOpcs` OPCS Classification of Interventions and Procedures code used to identify the primary patient procedure carried out. [PRIMARY PROCEDURE (OPCS)](https://www.datadictionary.nhs.uk/data_elements/primary_procedure__opcs_.html)

```sql
with ug as (
    select distinct
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,

        unnest ([[Record ->> '$.Treatment.Surgery.PrimaryProcedureOpcs.@code'], Record ->> '$.Treatment[*].Surgery.PrimaryProcedureOpcs.@code'], recursive := true) as PrimaryProcedureOpcs,

        unnest ([[Record ->> '$.Treatment.Surgery.ProcedureDate'], Record ->> '$.Treatment[*].Surgery.ProcedureDate'], recursive := true) as ProcedureDate
    from omop_staging.cosd_staging_901
    where type = 'UG'
)
select distinct
    NhsNumber,
    PrimaryProcedureOpcs,
    ProcedureDate
from ug
where NhsNumber is not null
  and PrimaryProcedureOpcs is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_value%20field%20COSD%20V9%20UG%20Procedure%20Occurrence%20Primary%20Procedure%20Opcs%20mapping){: .btn }
### COSD V9 UG Procedure Occurrence Diagnostic Procedure Snomed Ct
* Value copied from `DiagnosticProcedureSnomedCt`

* `DiagnosticProcedureSnomedCt` The SNOMED CT concept ID used to identify the diagnostic procedure. [DIAGNOSTIC PROCEDURE (SNOMED CT)](https://www.datadictionary.nhs.uk/data_elements/diagnostic_procedure__snomed_ct_.html)

```sql
select distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,

    Record ->> '$.DiagnosticProcedures.DiagnosticProcedureSnomedCt.@code' as DiagnosticProcedureSnomedCt,

    Record ->> '$.DiagnosticProcedures.DiagnosticProcedureDate' as DiagnosticProcedureDate
from omop_staging.cosd_staging_901
where type = 'UG'
  and NhsNumber is not null
  and DiagnosticProcedureSnomedCt is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_value%20field%20COSD%20V9%20UG%20Procedure%20Occurrence%20Diagnostic%20Procedure%20Snomed%20Ct%20mapping){: .btn }
### COSD V9 UG Procedure Occurrence Diagnostic Procedure Opcs
* Value copied from `DiagnosticProcedureOpcs`

* `DiagnosticProcedureOpcs` The OPCS Classification of Interventions and Procedures code used to identify the diagnostic procedure carried out. [DIAGNOSTIC PROCEDURE (OPCS)](https://www.datadictionary.nhs.uk/data_elements/diagnostic_procedure__opcs_.html)

```sql
select distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,

    Record ->> '$.DiagnosticProcedures.DiagnosticProcedureOpcs.@code' as DiagnosticProcedureOpcs,

    Record ->> '$.DiagnosticProcedures.DiagnosticProcedureDate' as DiagnosticProcedureDate
from omop_staging.cosd_staging_901
where type = 'UG'
  and NhsNumber is not null
  and DiagnosticProcedureOpcs is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_value%20field%20COSD%20V9%20UG%20Procedure%20Occurrence%20Diagnostic%20Procedure%20Opcs%20mapping){: .btn }
### COSD V8 UG Procedure Occurrence Procedure OPCS
* Value copied from `ProcedureOpcs`

* `ProcedureOpcs` Patient procedure other than the primary procedure (OPCS). Recommended to record multiple patient procedures where applicable. [PROCEDURE (OPCS)](https://www.datadictionary.nhs.uk/data_elements/procedure__opcs_.html)

```sql
with ug as (
    select distinct
        Record ->> '$.UpperGI.UpperGICore.UpperGICoreLinkagePatientId.NHSNumber.@extension' as NHSNumber,

        unnest ([[Record ->> '$.UpperGI.UpperGICore.UpperGICoreTreatment.UpperGICoreSurgeryAndOtherProcedures.ProcedureOPCS.@code'], Record ->> '$.UpperGI.UpperGICore.UpperGICoreTreatment.UpperGICoreSurgeryAndOtherProcedures.ProcedureOPCS[*].@code'], recursive := true) as ProcedureOPCS,

        unnest ([[Record ->> '$.UpperGI.UpperGICore.UpperGICoreTreatment.UpperGICoreSurgeryAndOtherProcedures.ProcedureDate'], Record ->> '$.UpperGI.UpperGICore.UpperGICoreTreatment[*].UpperGICoreSurgeryAndOtherProcedures.ProcedureDate'], recursive := true) as ProcedureDate
    from omop_staging.cosd_staging_81
    where type = 'UG'
)
select distinct
    NHSNumber,
    ProcedureOPCS,
    ProcedureDate
from ug
where NHSNumber is not null
  and ProcedureOPCS is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_value%20field%20COSD%20V8%20UG%20Procedure%20Occurrence%20Procedure%20OPCS%20mapping){: .btn }
### COSD V8 UG Procedure Occurrence Primary Procedure OPCS
* Value copied from `PrimaryProcedureOpcs`

* `PrimaryProcedureOpcs` OPCS Classification of Interventions and Procedures code used to identify the primary patient procedure carried out. [PRIMARY PROCEDURE (OPCS)](https://www.datadictionary.nhs.uk/data_elements/primary_procedure__opcs_.html)

```sql
with ug as (
    select distinct
        Record ->> '$.UpperGI.UpperGICore.UpperGICoreLinkagePatientId.NHSNumber.@extension' as NHSNumber,

        unnest ([[Record ->> '$.UpperGI.UpperGICore.UpperGICoreTreatment.UpperGICoreSurgeryAndOtherProcedures.PrimaryProcedureOPCS.@code'], Record ->> '$.UpperGI.UpperGICore.UpperGICoreTreatment[*].UpperGICoreSurgeryAndOtherProcedures.PrimaryProcedureOPCS.@code'], recursive := true) as PrimaryProcedureOPCS,

        unnest ([[Record ->> '$.UpperGI.UpperGICore.UpperGICoreTreatment.UpperGICoreSurgeryAndOtherProcedures.ProcedureDate'], Record ->> '$.UpperGI.UpperGICore.UpperGICoreTreatment[*].UpperGICoreSurgeryAndOtherProcedures.ProcedureDate'], recursive := true) as ProcedureDate
    from omop_staging.cosd_staging_81
    where type = 'UG'
)
select distinct
    NHSNumber,
    PrimaryProcedureOPCS,
    ProcedureDate
from ug
where NHSNumber is not null
  and PrimaryProcedureOPCS is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_value%20field%20COSD%20V8%20UG%20Procedure%20Occurrence%20Primary%20Procedure%20OPCS%20mapping){: .btn }
### COSD V9 SK Procedure Occurrence Procedure Opcs
* Value copied from `ProcedureOpcs`

* `ProcedureOpcs` Patient procedure other than the primary procedure (OPCS). Recommended to record multiple patient procedures where applicable. Will be mapped to procedure_source_value and used to derive procedure_concept_id via OPCS4-to-OMOP concept mapping in a later ETL step. [PROCEDURE (OPCS)](https://www.datadictionary.nhs.uk/data_elements/procedure__opcs_.html)

```sql
with COSD as (
    select distinct
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
        unnest ([[Record ->> '$.Treatment.Surgery.ProcedureDate'], Record ->> '$.Treatment[*].Surgery.ProcedureDate'], recursive := true) as ProcedureDate,
        unnest ([[Record ->> '$.Treatment.Surgery.ProcedureOpcs.@code'], Record ->> '$.Treatment[*].Surgery.ProcedureOpcs[*].@code'], recursive := true) as ProcedureOpcs
    from omop_staging.cosd_staging_901
    where type = 'SK'
)
select distinct
    NhsNumber,
    ProcedureDate,
    ProcedureOpcs
from COSD
where NhsNumber is not null
  and ProcedureOpcs is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_value%20field%20COSD%20V9%20SK%20Procedure%20Occurrence%20Procedure%20Opcs%20mapping){: .btn }
### COSD V9 SK Procedure Occurrence Primary Procedure Opcs
* Value copied from `PrimaryProcedureOpcs`

* `PrimaryProcedureOpcs` OPCS Classification of Interventions and Procedures code used to identify the primary patient procedure carried out. Will be mapped to procedure_source_value and used to derive procedure_concept_id via OPCS4-to-OMOP concept mapping in a later ETL step. [PRIMARY PROCEDURE (OPCS)](https://www.datadictionary.nhs.uk/data_elements/primary_procedure__opcs_.html)

```sql
with COSD as (
    select distinct
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
        unnest ([[Record ->> '$.Treatment.Surgery.ProcedureDate'], Record ->> '$.Treatment[*].Surgery.ProcedureDate'], recursive := true) as ProcedureDate,
        unnest ([[Record ->> '$.Treatment.Surgery.PrimaryProcedureOpcs.@code'], Record ->> '$.Treatment[*].Surgery.PrimaryProcedureOpcs.@code'], recursive := true) as PrimaryProcedureOpcs
    from omop_staging.cosd_staging_901
    where type = 'SK'
)
select distinct
    NhsNumber,
    ProcedureDate,
    PrimaryProcedureOpcs
from COSD
where NhsNumber is not null
  and PrimaryProcedureOpcs is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_value%20field%20COSD%20V9%20SK%20Procedure%20Occurrence%20Primary%20Procedure%20Opcs%20mapping){: .btn }
### COSD V9 SK Procedure Occurrence Diagnostic Procedure Snomed Ct
* Value copied from `DiagnosticProcedureSnomedCt`

* `DiagnosticProcedureSnomedCt` The SNOMED CT concept ID used to identify the diagnostic procedure. Will be mapped to procedure_source_value and used to derive procedure_concept_id via SNOMED-to-OMOP concept mapping in a later ETL step. [DIAGNOSTIC PROCEDURE (SNOMED CT)](https://www.datadictionary.nhs.uk/data_elements/diagnostic_procedure__snomed_ct_.html)

```sql
with COSD as (
    select distinct
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
        unnest ([[Record ->> '$.DiagnosticProcedures.DiagnosticProcedureDate'], Record ->> '$.DiagnosticProcedures[*].DiagnosticProcedureDate'], recursive := true) as DiagnosticProcedureDate,
        unnest ([[Record ->> '$.DiagnosticProcedures.DiagnosticProcedureSnomedCt.@code'], Record ->> '$.DiagnosticProcedures[*].DiagnosticProcedureSnomedCt.@code'], recursive := true) as DiagnosticProcedureSnomedCt
    from omop_staging.cosd_staging_901
    where type = 'SK'
)
select distinct
    NhsNumber,
    DiagnosticProcedureDate,
    DiagnosticProcedureSnomedCt
from COSD
where NhsNumber is not null
  and DiagnosticProcedureSnomedCt is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_value%20field%20COSD%20V9%20SK%20Procedure%20Occurrence%20Diagnostic%20Procedure%20Snomed%20Ct%20mapping){: .btn }
### COSD V9 SK Procedure Occurrence Diagnostic Procedure Opcs
* Value copied from `DiagnosticProcedureOpcs`

* `DiagnosticProcedureOpcs` The OPCS Classification of Interventions and Procedures code used to identify the diagnostic procedure carried out. Will be mapped to procedure_source_value and used to derive procedure_concept_id via OPCS4-to-OMOP concept mapping in a later ETL step. [DIAGNOSTIC PROCEDURE (OPCS)](https://www.datadictionary.nhs.uk/data_elements/diagnostic_procedure__opcs_.html)

```sql
with COSD as (
    select distinct
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
        unnest ([[Record ->> '$.DiagnosticProcedures.DiagnosticProcedureDate'], Record ->> '$.DiagnosticProcedures[*].DiagnosticProcedureDate'], recursive := true) as DiagnosticProcedureDate,
        unnest ([[Record ->> '$.DiagnosticProcedures.DiagnosticProcedureOpcs.@code'], Record ->> '$.DiagnosticProcedures[*].DiagnosticProcedureOpcs.@code'], recursive := true) as DiagnosticProcedureOpcs
    from omop_staging.cosd_staging_901
    where type = 'SK'
)
select distinct
    NhsNumber,
    DiagnosticProcedureDate,
    DiagnosticProcedureOpcs
from COSD
where NhsNumber is not null
  and DiagnosticProcedureOpcs is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_value%20field%20COSD%20V9%20SK%20Procedure%20Occurrence%20Diagnostic%20Procedure%20Opcs%20mapping){: .btn }
### COSD V8 SK Procedure Occurrence Procedure OPCS
* Value copied from `ProcedureOpcs`

* `ProcedureOpcs` Patient procedure other than the primary procedure (OPCS). Recommended to record multiple patient procedures where applicable. Will be mapped to procedure_source_value and used to derive procedure_concept_id via OPCS4-to-OMOP concept mapping in a later ETL step. [PROCEDURE (OPCS)](https://www.datadictionary.nhs.uk/data_elements/procedure__opcs_.html)

```sql
with COSD as (
    select distinct
        Record ->> '$.Skin.SkinCore.SkinCoreLinkagePatientId.NHSNumber.@extension' as NHSNumber,
        unnest ([[Record ->> '$.Skin.SkinCore.SkinCoreTreatment.SkinCoreSurgeryAndOtherProcedures.ProcedureDate'], Record ->> '$.Skin.SkinCore.SkinCoreTreatment[*].SkinCoreSurgeryAndOtherProcedures.ProcedureDate'], recursive := true) as ProcedureDate,
        unnest ([[Record ->> '$.Skin.SkinCore.SkinCoreTreatment.SkinCoreSurgeryAndOtherProcedures.ProcedureOPCS.@code'], Record ->> '$.Skin.SkinCore.SkinCoreTreatment[*].SkinCoreSurgeryAndOtherProcedures.ProcedureOPCS[*].@code'], recursive := true) as ProcedureOPCS
    from omop_staging.cosd_staging_81
    where type = 'SK'
)
select distinct
    NHSNumber,
    ProcedureDate,
    ProcedureOPCS
from COSD
where NHSNumber is not null
  and ProcedureOPCS is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_value%20field%20COSD%20V8%20SK%20Procedure%20Occurrence%20Procedure%20OPCS%20mapping){: .btn }
### COSD V8 SK Procedure Occurrence Primary Procedure OPCS
* Value copied from `PrimaryProcedureOpcs`

* `PrimaryProcedureOpcs` OPCS Classification of Interventions and Procedures code used to identify the primary patient procedure carried out. Will be mapped to procedure_source_value and used to derive procedure_concept_id via OPCS4-to-OMOP concept mapping in a later ETL step. [PRIMARY PROCEDURE (OPCS)](https://www.datadictionary.nhs.uk/data_elements/primary_procedure__opcs_.html)

```sql
with COSD as (
    select distinct
        Record ->> '$.Skin.SkinCore.SkinCoreLinkagePatientId.NHSNumber.@extension' as NHSNumber,
        unnest ([[Record ->> '$.Skin.SkinCore.SkinCoreTreatment.SkinCoreSurgeryAndOtherProcedures.ProcedureDate'], Record ->> '$.Skin.SkinCore.SkinCoreTreatment[*].SkinCoreSurgeryAndOtherProcedures.ProcedureDate'], recursive := true) as ProcedureDate,
        unnest ([[Record ->> '$.Skin.SkinCore.SkinCoreTreatment.SkinCoreSurgeryAndOtherProcedures.PrimaryProcedureOPCS.@code'], Record ->> '$.Skin.SkinCore.SkinCoreTreatment[*].SkinCoreSurgeryAndOtherProcedures.PrimaryProcedureOPCS.@code'], recursive := true) as PrimaryProcedureOPCS
    from omop_staging.cosd_staging_81
    where type = 'SK'
)
select distinct
    NHSNumber,
    ProcedureDate,
    PrimaryProcedureOPCS
from COSD
where NHSNumber is not null
  and PrimaryProcedureOPCS is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_value%20field%20COSD%20V8%20SK%20Procedure%20Occurrence%20Primary%20Procedure%20OPCS%20mapping){: .btn }
### COSD V9 SA Procedure Occurrence Procedure Opcs Procedure Date
* Value copied from `ProcedureOpcs`

* `ProcedureOpcs` Patient procedure other than the primary procedure (OPCS). Recommended to record multiple patient procedures where applicable. Will be mapped to procedure_source_value in the OMOP procedure_occurrence table. The OPCS-4 code will be mapped to a standard OMOP concept_id (procedure_concept_id) in a later ETL step using the OMOP vocabulary. [PROCEDURE (OPCS)](https://www.datadictionary.nhs.uk/data_elements/procedure__opcs_.html)

```sql
with sa as (
    select distinct
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
        unnest ([[Record ->> '$.Treatment.Surgery.ProcedureDate'], Record ->> '$.Treatment[*].Surgery.ProcedureDate'], recursive := true) as ProcedureDate,
        unnest ([[Record ->> '$.Treatment.Surgery.ProcedureOpcs.@code'], Record ->> '$.Treatment[*].Surgery.ProcedureOpcs[*].@code'], recursive := true) as ProcedureOpcs
    from omop_staging.cosd_staging_901
    where type = 'SA'
)
select distinct
    NhsNumber,
    ProcedureDate,
    ProcedureOpcs
from sa
where NhsNumber is not null
  and ProcedureOpcs is not null
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_value%20field%20COSD%20V9%20SA%20Procedure%20Occurrence%20Procedure%20Opcs%20Procedure%20Date%20mapping){: .btn }
### COSD V9 SA Procedure Occurrence Primary Procedure Opcs Procedure Date
* Value copied from `PrimaryProcedureOpcs`

* `PrimaryProcedureOpcs` OPCS Classification of Interventions and Procedures code used to identify the primary patient procedure carried out. Will be mapped to procedure_source_value in the OMOP procedure_occurrence table. The OPCS-4 code will be mapped to a standard OMOP concept_id (procedure_concept_id) in a later ETL step using the OMOP vocabulary. [PRIMARY PROCEDURE (OPCS)](https://www.datadictionary.nhs.uk/data_elements/primary_procedure__opcs_.html)

```sql
with sa as (
    select distinct
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
        unnest ([[Record ->> '$.Treatment.Surgery.ProcedureDate'], Record ->> '$.Treatment[*].Surgery.ProcedureDate'], recursive := true) as ProcedureDate,
        unnest ([[Record ->> '$.Treatment.Surgery.PrimaryProcedureOpcs.@code'], Record ->> '$.Treatment[*].Surgery.PrimaryProcedureOpcs.@code'], recursive := true) as PrimaryProcedureOpcs
    from omop_staging.cosd_staging_901
    where type = 'SA'
)
select distinct
    NhsNumber,
    ProcedureDate,
    PrimaryProcedureOpcs
from sa
where NhsNumber is not null
  and PrimaryProcedureOpcs is not null
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_value%20field%20COSD%20V9%20SA%20Procedure%20Occurrence%20Primary%20Procedure%20Opcs%20Procedure%20Date%20mapping){: .btn }
### COSD V8 SA Procedure Occurrence Procedure OPCS Procedure Date
* Value copied from `ProcedureOpcs`

* `ProcedureOpcs` Patient procedure other than the primary procedure (OPCS). Recommended to record multiple patient procedures where applicable. Will be mapped to procedure_source_value in the OMOP procedure_occurrence table. The OPCS-4 code will be mapped to a standard OMOP concept_id (procedure_concept_id) in a later ETL step using the OMOP vocabulary. [PROCEDURE (OPCS)](https://www.datadictionary.nhs.uk/data_elements/procedure__opcs_.html)

```sql
with sa as (
    select distinct
        Record ->> '$.Sarcoma.SarcomaCore.SarcomaCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
        unnest ([[Record ->> '$.Sarcoma.SarcomaCore.SarcomaCoreTreatment.SarcomaCoreSurgeryAndOtherProcedures.ProcedureDate'], Record ->> '$.Sarcoma.SarcomaCore.SarcomaCoreTreatment[*].SarcomaCoreSurgeryAndOtherProcedures.ProcedureDate'], recursive := true) as ProcedureDate,
        unnest ([[Record ->> '$.Sarcoma.SarcomaCore.SarcomaCoreTreatment.SarcomaCoreSurgeryAndOtherProcedures.ProcedureOPCS.@code'], Record ->> '$.Sarcoma.SarcomaCore.SarcomaCoreTreatment[*].SarcomaCoreSurgeryAndOtherProcedures.ProcedureOPCS[*].@code'], recursive := true) as ProcedureOPCS
    from omop_staging.cosd_staging_81
    where type = 'SA'
)
select distinct
    NhsNumber,
    ProcedureDate,
    ProcedureOPCS
from sa
where NhsNumber is not null
  and ProcedureOPCS is not null
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_value%20field%20COSD%20V8%20SA%20Procedure%20Occurrence%20Procedure%20OPCS%20Procedure%20Date%20mapping){: .btn }
### COSD V8 SA Procedure Occurrence Primary Procedure OPCS Procedure Date
* Value copied from `PrimaryProcedureOpcs`

* `PrimaryProcedureOpcs` OPCS Classification of Interventions and Procedures code used to identify the primary patient procedure carried out. Will be mapped to procedure_source_value in the OMOP procedure_occurrence table. The OPCS-4 code will be mapped to a standard OMOP concept_id (procedure_concept_id) in a later ETL step using the OMOP vocabulary. [PRIMARY PROCEDURE (OPCS)](https://www.datadictionary.nhs.uk/data_elements/primary_procedure__opcs_.html)

```sql
with sa as (
    select distinct
        Record ->> '$.Sarcoma.SarcomaCore.SarcomaCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
        unnest ([[Record ->> '$.Sarcoma.SarcomaCore.SarcomaCoreTreatment.SarcomaCoreSurgeryAndOtherProcedures.ProcedureDate'], Record ->> '$.Sarcoma.SarcomaCore.SarcomaCoreTreatment[*].SarcomaCoreSurgeryAndOtherProcedures.ProcedureDate'], recursive := true) as ProcedureDate,
        unnest ([[Record ->> '$.Sarcoma.SarcomaCore.SarcomaCoreTreatment.SarcomaCoreSurgeryAndOtherProcedures.PrimaryProcedureOPCS.@code'], Record ->> '$.Sarcoma.SarcomaCore.SarcomaCoreTreatment[*].SarcomaCoreSurgeryAndOtherProcedures.PrimaryProcedureOPCS.@code'], recursive := true) as PrimaryProcedureOPCS
    from omop_staging.cosd_staging_81
    where type = 'SA'
)
select distinct
    NhsNumber,
    ProcedureDate,
    PrimaryProcedureOPCS
from sa
where NhsNumber is not null
  and PrimaryProcedureOPCS is not null
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_value%20field%20COSD%20V8%20SA%20Procedure%20Occurrence%20Primary%20Procedure%20OPCS%20Procedure%20Date%20mapping){: .btn }
### COSD V9 LV Procedure Occurrence Procedure Opcs
* Value copied from `ProcedureOpcs`

* `ProcedureOpcs` Patient procedure other than the primary procedure (OPCS). Recommended to record multiple patient procedures where applicable. [PROCEDURE (OPCS)](https://www.datadictionary.nhs.uk/data_elements/procedure__opcs_.html)

```sql
with lv as (
    select distinct
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
        Record ->> '$.Treatment.Surgery.ProcedureDate' as ProcedureDate,
        unnest(
            [
                [Record ->> '$.Treatment.Surgery.ProcedureOpcs.@code'],
                Record ->> '$.Treatment.Surgery.ProcedureOpcs[*].@code'
            ],
            recursive := true
        ) as ProcedureOpcs
    from omop_staging.cosd_staging_901
    where type = 'LV'
)
select distinct
    NhsNumber,
    ProcedureOpcs,
    ProcedureDate
from lv
where NhsNumber is not null
  and ProcedureOpcs is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_value%20field%20COSD%20V9%20LV%20Procedure%20Occurrence%20Procedure%20Opcs%20mapping){: .btn }
### COSD V9 LV Procedure Occurrence Primary Procedure Opcs
* Value copied from `PrimaryProcedureOpcs`

* `PrimaryProcedureOpcs` OPCS Classification of Interventions and Procedures code used to identify the primary patient procedure carried out. [PRIMARY PROCEDURE (OPCS)](https://www.datadictionary.nhs.uk/data_elements/primary_procedure__opcs_.html)

```sql
select distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
    -- OPCS code identifying the primary procedure carried out
    Record ->> '$.Treatment.Surgery.PrimaryProcedureOpcs.@code' as PrimaryProcedureOpcs,
    -- Date the procedure was performed, currently a string in CCYY-MM-DD format; will be cast to date in a later ETL step
    Record ->> '$.Treatment.Surgery.ProcedureDate' as ProcedureDate
from omop_staging.cosd_staging_901
where type = 'LV'
  and NhsNumber is not null
  and PrimaryProcedureOpcs is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_value%20field%20COSD%20V9%20LV%20Procedure%20Occurrence%20Primary%20Procedure%20Opcs%20mapping){: .btn }
### COSD V8 LV Procedure Occurrence Procedure OPCS
* Value copied from `ProcedureOpcs`

* `ProcedureOpcs` Patient procedure other than the primary procedure (OPCS). Recommended to record multiple patient procedures where applicable. [PROCEDURE (OPCS)](https://www.datadictionary.nhs.uk/data_elements/procedure__opcs_.html)

```sql
select distinct
    Record ->> '$.Liver.LiverCore.LiverCoreLinkagePatientId.NHSNumber.@extension' as NHSNumber,
    Record ->> '$.Liver.LiverCore.LiverCoreTreatment.LiverCoreSurgeryAndOtherProcedures.ProcedureOPCS.@code' as ProcedureOPCS,
    Record ->> '$.Liver.LiverCore.LiverCoreTreatment.LiverCoreSurgeryAndOtherProcedures.ProcedureDate' as ProcedureDate
from omop_staging.cosd_staging_81
where type = 'LV'
  and NHSNumber is not null
  and ProcedureOPCS is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_value%20field%20COSD%20V8%20LV%20Procedure%20Occurrence%20Procedure%20OPCS%20mapping){: .btn }
### COSD V8 LV Procedure Occurrence Primary Procedure OPCS
* Value copied from `PrimaryProcedureOpcs`

* `PrimaryProcedureOpcs` OPCS Classification of Interventions and Procedures code used to identify the primary patient procedure carried out. [PRIMARY PROCEDURE (OPCS)](https://www.datadictionary.nhs.uk/data_elements/primary_procedure__opcs_.html)

```sql
select distinct
    Record ->> '$.Liver.LiverCore.LiverCoreLinkagePatientId.NHSNumber.@extension' as NHSNumber,
    Record ->> '$.Liver.LiverCore.LiverCoreTreatment.LiverCoreSurgeryAndOtherProcedures.PrimaryProcedureOPCS.@code' as PrimaryProcedureOPCS,
    Record ->> '$.Liver.LiverCore.LiverCoreTreatment.LiverCoreSurgeryAndOtherProcedures.ProcedureDate' as ProcedureDate
from omop_staging.cosd_staging_81
where type = 'LV'
  and NHSNumber is not null
  and PrimaryProcedureOPCS is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_value%20field%20COSD%20V8%20LV%20Procedure%20Occurrence%20Primary%20Procedure%20OPCS%20mapping){: .btn }
>>>>>>> main
### CosdV9LungProcedureOccurrenceRelapseMethodOfDetection
* Value copied from `RelapseMethodOfDetection`

* `RelapseMethodOfDetection` A code representing the method used to detect a relapse or recurrence. [RELAPSE - METHOD OF DETECTION]()

```sql
with LU as (
    select
        Record ->> '$.PrimaryPathway.ReferralAndFirstStageOfPatientPathway.DateFirstSeen' as DateFirstSeen,
        Record ->> '$.PrimaryPathway.ReferralAndFirstStageOfPatientPathway.DateFirstSeenCancerSpecialist' as DateFirstSeenCancerSpecialist,
        Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed' as DateOfPrimaryDiagnosisClinicallyAgreed,
        Record ->> '$.PrimaryPathway.Staging.StageDateFinalPretreatmentStage' as StageDateFinalPretreatmentStage,
        Record ->> '$.PrimaryPathway.Staging.StageDateIntegratedStage' as StageDateIntegratedStage,
        Record ->> '$.Treatment.TreatmentStartDateCancer' as TreatmentStartDateCancer,
        Record ->> '$.Treatment.Surgery.ProcedureDate' as ProcedureDate,
        unnest ([[Record ->> '$.NonPrimaryPathway.Recurrence.Relapse-MethodOfDetection.@code'], Record ->> '$.NonPrimaryPathway.Recurrence.Relapse-MethodOfDetection[*].@code'], recursive := true) as RelapseMethodOfDetection,
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber
    from omop_staging.cosd_staging_901
    where type = 'LU'
)
select
    distinct
        RelapseMethodOfDetection,
        NhsNumber,
        least(
            cast(DateFirstSeen as date),
            cast(DateFirstSeenCancerSpecialist as date),
            cast(DateOfPrimaryDiagnosisClinicallyAgreed as date),
            cast(StageDateFinalPretreatmentStage as date),
            cast(StageDateIntegratedStage as date),
            cast(TreatmentStartDateCancer as date),
            cast(ProcedureDate as date)
        ) as Date
from LU o
where o.RelapseMethodOfDetection is not null
  and not (
        DateFirstSeen is null and
        DateFirstSeenCancerSpecialist is null and
        DateOfPrimaryDiagnosisClinicallyAgreed is null and
        StageDateFinalPretreatmentStage is null and
        StageDateIntegratedStage is null and
        TreatmentStartDateCancer is null and
        ProcedureDate is null
    )
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_value%20field%20CosdV9LungProcedureOccurrenceRelapseMethodOfDetection%20mapping){: .btn }
### Cosd V9 Lung Procedure Occurrence Procedure Opcs
* Value copied from `ProcedureOpcsCode`

* `ProcedureOpcsCode` PROCEDURE (OPCS) is a Patient Procedure other than the PRIMARY PROCEDURE (OPCS). [PROCEDURE (OPCS)](https://www.datadictionary.nhs.uk/data_elements/procedure__opcs_.html)

```sql
with lung as (
    select distinct
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
        Record ->> '$.Treatment.Surgery.ProcedureDate' as ProcedureDate,
        unnest ([[Record ->> '$.Treatment.Surgery.ProcedureOpcs.@code'], Record ->> '$.Treatment.Surgery.ProcedureOpcs[*].@code'], recursive := true) as ProcedureOpcsCode
    from omop_staging.cosd_staging_901
    where type = 'LU'
)
select distinct
    NhsNumber,
    ProcedureDate,
    ProcedureOpcsCode
from lung
where ProcedureOpcsCode is not null
and NhsNumber is not null
and ProcedureDate is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_value%20field%20Cosd%20V9%20Lung%20Procedure%20Occurrence%20Procedure%20Opcs%20mapping){: .btn }
### Cosd V9 Lung Procedure Occurrence Primary Procedure Opcs
* Value copied from `PrimaryProcedureOpcs`

* `PrimaryProcedureOpcs` PRIMARY PROCEDURE (OPCS) is the main PROCEDURE (OPCS) undertaken by a PATIENT. [PRIMARY PROCEDURE (OPCS)](https://www.datadictionary.nhs.uk/data_elements/primary_procedure__opcs_.html)

```sql
select 
  distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
    Record ->> '$.Treatment.Surgery.ProcedureDate' as ProcedureDate,
    Record ->> '$.Treatment.Surgery.PrimaryProcedureOpcs.@code' as PrimaryProcedureOpcs
from omop_staging.cosd_staging_901
where type = 'LU'
  and NhsNumber is not null
  and ProcedureDate is not null
  and PrimaryProcedureOpcs is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_value%20field%20Cosd%20V9%20Lung%20Procedure%20Occurrence%20Primary%20Procedure%20Opcs%20mapping){: .btn }
### CosdV8LungProcedureOccurrenceRelapseMethodOfDetection
* Value copied from `RelapseMethodDetectionType`

* `RelapseMethodDetectionType` A code representing the method used to detect a relapse or recurrence. [RELAPSE - METHOD OF DETECTION]()

```sql
with LU as (
    select 
        Record ->> '$.Lung.LungCore.LungCoreReferralAndFirstStageOfPatientPathway.DateFirstSeen' as DateFirstSeen,
        Record ->> '$.Lung.LungCore.LungCoreReferralAndFirstStageOfPatientPathway.SpecialistDateFirstSeen' as SpecialistDateFirstSeen,
        Record ->> '$.Lung.LungCore.LungCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
        Record ->> '$.Lung.LungCore.LungCoreStaging.IntegratedStageTNMStageGroupingDate' as IntegratedStageTNMStageGroupingDate,
        Record ->> '$.Lung.LungCore.LungCoreStaging.FinalPreTreatmentTNMStageGroupingDate' as FinalPreTreatmentTNMStageGroupingDate,
        unnest ([[Record ->> '$.Lung.LungCore.LungCoreTreatment.CancerTreatmentStartDate'], Record ->> '$.Lung.LungCore.LungCoreTreatment[*].CancerTreatmentStartDate'], recursive := true) as CancerTreatmentStartDate,
        Record ->> '$.Lung.LungCore.LungCoreTreatment.LungCoreSurgeryAndOtherProcedures.ProcedureDate' as ProcedureDate,
        Record ->> '$.Lung.LungCore.LungCoreNonPrimaryCancerPathwayALLAMLAndMPAL.RelapseMethodDetectionType.@code' as RelapseMethodDetectionType,
        Record ->> '$.Lung.LungCore.LungCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber
    from omop_staging.cosd_staging_81
    where Type = 'LU'
)
select
      distinct
          RelapseMethodDetectionType,
          NhsNumber,
          least(
                cast (DateFirstSeen as date),
                cast (SpecialistDateFirstSeen as date),
                cast (ClinicalDateCancerDiagnosis as date),
                cast (IntegratedStageTNMStageGroupingDate as date),
                cast (FinalPreTreatmentTNMStageGroupingDate as date),
                cast (CancerTreatmentStartDate as date),
                cast (ProcedureDate as date)
              ) as Date
from LU o
where o.RelapseMethodDetectionType is not null
  and not (
    DateFirstSeen is null and
    SpecialistDateFirstSeen is null and
    ClinicalDateCancerDiagnosis is null and
    IntegratedStageTNMStageGroupingDate is null and
    FinalPreTreatmentTNMStageGroupingDate is null and
    CancerTreatmentStartDate is null and
    ProcedureDate is null
    )
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_value%20field%20CosdV8LungProcedureOccurrenceRelapseMethodOfDetection%20mapping){: .btn }
### Cosd V8 Lung Procedure Occurrence Procedure Opcs
* Value copied from `ProcedureOpcsCode`

* `ProcedureOpcsCode` PROCEDURE (OPCS) is a Patient Procedure other than the PRIMARY PROCEDURE (OPCS). [PROCEDURE (OPCS)](https://www.datadictionary.nhs.uk/data_elements/procedure__opcs_.html)

```sql
with lung as (
  select 
    Record ->> '$.Lung.LungCore.LungCoreLinkagePatientId.NHSNumber.@extension' as NHSNumber,
    Record ->> '$.Lung.LungCore.LungCoreTreatment.LungCoreSurgeryAndOtherProcedures.ProcedureDate' as ProcedureDate,
    unnest ([[Record ->> '$.Lung.LungCore.LungCoreTreatment.LungCoreSurgeryAndOtherProcedures.ProcedureOPCS.@code'], Record ->> '$.Lung.LungCore.LungCoreTreatment.LungCoreSurgeryAndOtherProcedures.ProcedureOPCS[*].@code'], recursive := true) as ProcedureOpcsCode
    from omop_staging.cosd_staging_81
    where Type = 'LU'
)
select
  distinct
		NhsNumber,
		ProcedureDate,
		ProcedureOpcsCode
from lung
where ProcedureOpcsCode is not null
and NhsNumber is not null
and ProcedureDate is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_value%20field%20Cosd%20V8%20Lung%20Procedure%20Occurrence%20Procedure%20Opcs%20mapping){: .btn }
### COSD V8 Lung Procedure Occurrence Primary Procedure Opcs
* Value copied from `PrimaryProcedureOpcs`

* `PrimaryProcedureOpcs` PRIMARY PROCEDURE (OPCS) is the OPCS Classification of Interventions and Procedures code which is used to identify the primary Patient Procedure carried out. [PRIMARY PROCEDURE (OPCS)](https://www.datadictionary.nhs.uk/data_elements/primary_procedure__opcs_.html)

```sql
with Lung as (
  select 
    Record ->> '$.Lung.LungCore.LungCoreTreatment.LungCoreSurgeryAndOtherProcedures.ProcedureDate' as ProcedureDate,
    Record ->> '$.Lung.LungCore.LungCoreLinkagePatientId.NHSNumber.@extension' as NHSNumber,
    Record ->> '$.Lung.LungCore.LungCoreTreatment.LungCoreSurgeryAndOtherProcedures.PrimaryProcedureOPCS.@code' as PrimaryProcedureOPCS
  from omop_staging.cosd_staging_81
  where Type = 'LU'
)
select
      distinct
          ProcedureDate,
          NhsNumber,
          PrimaryProcedureOPCS
from Lung l
where l.ProcedureDate is not null
and l.PrimaryProcedureOPCS is not null
and l.NhsNumber is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_value%20field%20COSD%20V8%20Lung%20Procedure%20Occurrence%20Primary%20Procedure%20Opcs%20mapping){: .btn }
### COSD V9 HA Procedure Occurrence Procedure Opcs
* Value copied from `ProcedureOpcs`

* `ProcedureOpcs` Patient procedure other than the primary procedure (OPCS). Recommended to record multiple patient procedures where applicable. [PROCEDURE (OPCS)](https://www.datadictionary.nhs.uk/data_elements/procedure__opcs_.html)

```sql
select distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
    Record ->> '$.Treatment.Surgery.ProcedureDate' as ProcedureDate,
    Record ->> '$.Treatment.Surgery.ProcedureOpcs.@code' as ProcedureOpcs
from omop_staging.cosd_staging_901
where type = 'HA'
  and NhsNumber is not null
  and ProcedureOpcs is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_value%20field%20COSD%20V9%20HA%20Procedure%20Occurrence%20Procedure%20Opcs%20mapping){: .btn }
### COSD V9 HA Procedure Occurrence Primary Procedure Opcs
* Value copied from `PrimaryProcedureOpcs`

* `PrimaryProcedureOpcs` OPCS Classification of Interventions and Procedures code used to identify the primary patient procedure carried out. [PRIMARY PROCEDURE (OPCS)](https://www.datadictionary.nhs.uk/data_elements/primary_procedure__opcs_.html)

```sql
select distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
    Record ->> '$.Treatment.Surgery.ProcedureDate' as ProcedureDate,
    Record ->> '$.Treatment.Surgery.PrimaryProcedureOpcs.@code' as PrimaryProcedureOpcs
from omop_staging.cosd_staging_901
where type = 'HA'
  and NhsNumber is not null
  and PrimaryProcedureOpcs is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_value%20field%20COSD%20V9%20HA%20Procedure%20Occurrence%20Primary%20Procedure%20Opcs%20mapping){: .btn }
### COSD V9 HA Procedure Occurrence Diagnostic Procedure Snomed Ct
* Value copied from `DiagnosticProcedureSnomedCt`

* `DiagnosticProcedureSnomedCt` The SNOMED CT concept ID used to identify the diagnostic procedure. [DIAGNOSTIC PROCEDURE (SNOMED CT)](https://www.datadictionary.nhs.uk/data_elements/diagnostic_procedure__snomed_ct_.html)

```sql
select distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
    Record ->> '$.DiagnosticProcedures.DiagnosticProcedureDate' as DiagnosticProcedureDate,
    Record ->> '$.DiagnosticProcedures.DiagnosticProcedureSnomedCt.@code' as DiagnosticProcedureSnomedCt
from omop_staging.cosd_staging_901
where type = 'HA'
  and NhsNumber is not null
  and DiagnosticProcedureSnomedCt is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_value%20field%20COSD%20V9%20HA%20Procedure%20Occurrence%20Diagnostic%20Procedure%20Snomed%20Ct%20mapping){: .btn }
### COSD V9 HA Procedure Occurrence Diagnostic Procedure Opcs
* Value copied from `DiagnosticProcedureOpcs`

* `DiagnosticProcedureOpcs` The OPCS Classification of Interventions and Procedures code used to identify the diagnostic procedure carried out. [DIAGNOSTIC PROCEDURE (OPCS)](https://www.datadictionary.nhs.uk/data_elements/diagnostic_procedure__opcs_.html)

```sql
select distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
    Record ->> '$.DiagnosticProcedures.DiagnosticProcedureDate' as DiagnosticProcedureDate,
    Record ->> '$.DiagnosticProcedures.DiagnosticProcedureOpcs.@code' as DiagnosticProcedureOpcs
from omop_staging.cosd_staging_901
where type = 'HA'
  and NhsNumber is not null
  and DiagnosticProcedureOpcs is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_value%20field%20COSD%20V9%20HA%20Procedure%20Occurrence%20Diagnostic%20Procedure%20Opcs%20mapping){: .btn }
### COSD V901 CT Procedure Occurrence Procedure Opcs
* Value copied from `ProcedureOpcs`

* `ProcedureOpcs` Patient procedure other than the primary procedure (OPCS). Recommended to record multiple patient procedures where applicable. [PROCEDURE (OPCS)](https://www.datadictionary.nhs.uk/data_elements/procedure__opcs_.html)

```sql
with ct as (
    select distinct
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,

        unnest ([[Record ->> '$.Treatment.Surgery.ProcedureDate'], Record ->> '$.Treatment[*].Surgery.ProcedureDate'], recursive := true) as ProcedureDate,

        unnest ([[Record ->> '$.Treatment.Surgery.ProcedureOpcs.@code'], Record ->> '$.Treatment[*].Surgery.ProcedureOpcs[*].@code'], recursive := true) as ProcedureOpcs
    from omop_staging.cosd_staging_901
    where type = 'CT'
)
select distinct
    NhsNumber,
    ProcedureDate,
    ProcedureOpcs
from ct
where NhsNumber is not null
  and ProcedureOpcs is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_value%20field%20COSD%20V901%20CT%20Procedure%20Occurrence%20Procedure%20Opcs%20mapping){: .btn }
### COSD V901 CT Procedure Occurrence Primary Procedure Opcs
* Value copied from `PrimaryProcedureOpcs`

* `PrimaryProcedureOpcs` OPCS Classification of Interventions and Procedures code used to identify the primary patient procedure carried out. [PRIMARY PROCEDURE (OPCS)](https://www.datadictionary.nhs.uk/data_elements/primary_procedure__opcs_.html)

```sql
with ct as (
    select distinct
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,

        unnest ([[Record ->> '$.Treatment.Surgery.ProcedureDate'], Record ->> '$.Treatment[*].Surgery.ProcedureDate'], recursive := true) as ProcedureDate,

        unnest ([[Record ->> '$.Treatment.Surgery.PrimaryProcedureOpcs.@code'], Record ->> '$.Treatment[*].Surgery.PrimaryProcedureOpcs.@code'], recursive := true) as PrimaryProcedureOpcs
    from omop_staging.cosd_staging_901
    where type = 'CT'
)
select distinct
    NhsNumber,
    ProcedureDate,
    PrimaryProcedureOpcs
from ct
where NhsNumber is not null
  and PrimaryProcedureOpcs is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_value%20field%20COSD%20V901%20CT%20Procedure%20Occurrence%20Primary%20Procedure%20Opcs%20mapping){: .btn }
### COSD V8 CT Procedure Occurrence Primary Procedure OPCS
* Value copied from `PrimaryProcedureOpcs`

* `PrimaryProcedureOpcs` OPCS Classification of Interventions and Procedures code used to identify the primary patient procedure carried out. [PRIMARY PROCEDURE (OPCS)](https://www.datadictionary.nhs.uk/data_elements/primary_procedure__opcs_.html)

```sql
with ct as (
    select distinct
        Record ->> '$.CTYA.CTYACore.CTYACoreLinkagePatientId.NHSNumber.@extension' as NHSNumber,

        unnest ([[Record ->> '$.CTYA.CTYACore.CTYACoreTreatment.CTYACoreSurgeryAndOtherProcedures.ProcedureDate'], Record ->> '$.CTYA.CTYACore.CTYACoreTreatment[*].CTYACoreSurgeryAndOtherProcedures.ProcedureDate'], recursive := true) as ProcedureDate,

        unnest ([[Record ->> '$.CTYA.CTYACore.CTYACoreTreatment.CTYACoreSurgeryAndOtherProcedures.PrimaryProcedureOPCS.@code'], Record ->> '$.CTYA.CTYACore.CTYACoreTreatment[*].CTYACoreSurgeryAndOtherProcedures.PrimaryProcedureOPCS.@code'], recursive := true) as PrimaryProcedureOPCS
    from omop_staging.cosd_staging_81
    where type = 'CT'
)
select distinct
    NHSNumber,
    ProcedureDate,
    PrimaryProcedureOPCS
from ct
where NHSNumber is not null
  and PrimaryProcedureOPCS is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_value%20field%20COSD%20V8%20CT%20Procedure%20Occurrence%20Primary%20Procedure%20OPCS%20mapping){: .btn }
### COSD V9 CO Procedure Occurrence Procedure Opcs
* Value copied from `ProcedureOpcs`

* `ProcedureOpcs` Patient procedure other than the primary procedure (OPCS). Recommended to record multiple patient procedures where applicable. Will be mapped to procedure_concept_id and stored as procedure_source_value in the procedure_occurrence table. The OPCS-4 code will be used to look up the corresponding standard OMOP concept in the Procedure domain. [PROCEDURE (OPCS)](https://www.datadictionary.nhs.uk/data_elements/procedure__opcs_.html)

```sql
with co as (
    select distinct
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
        unnest ([[Record ->> '$.Treatment.Surgery.ProcedureOpcs.@code'], Record ->> '$.Treatment[*].Surgery.ProcedureOpcs[*].@code'], recursive := true) as ProcedureOpcs,
        unnest ([[Record ->> '$.Treatment.Surgery.ProcedureDate'], Record ->> '$.Treatment[*].Surgery.ProcedureDate'], recursive := true) as ProcedureDate
    from omop_staging.cosd_staging_901
    where type = 'CO'
)
select distinct
    NhsNumber,
    ProcedureOpcs,
    ProcedureDate
from co
where NhsNumber is not null
  and ProcedureOpcs is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_value%20field%20COSD%20V9%20CO%20Procedure%20Occurrence%20Procedure%20Opcs%20mapping){: .btn }
### COSD V9 CO Procedure Occurrence Primary Procedure Opcs
* Value copied from `PrimaryProcedureOpcs`

* `PrimaryProcedureOpcs` OPCS Classification of Interventions and Procedures code used to identify the primary patient procedure carried out. Will be mapped to procedure_concept_id and stored as procedure_source_value in the procedure_occurrence table. The OPCS-4 code will be used to look up the corresponding standard OMOP concept in the Procedure domain. [PRIMARY PROCEDURE (OPCS)](https://www.datadictionary.nhs.uk/data_elements/primary_procedure__opcs_.html)

```sql
with co as (
    select distinct
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
        unnest ([[Record ->> '$.Treatment.Surgery.PrimaryProcedureOpcs.@code'], Record ->> '$.Treatment[*].Surgery.PrimaryProcedureOpcs.@code'], recursive := true) as PrimaryProcedureOpcs,
        unnest ([[Record ->> '$.Treatment.Surgery.ProcedureDate'], Record ->> '$.Treatment[*].Surgery.ProcedureDate'], recursive := true) as ProcedureDate
    from omop_staging.cosd_staging_901
    where type = 'CO'
)
select distinct
    NhsNumber,
    PrimaryProcedureOpcs,
    ProcedureDate
from co
where NhsNumber is not null
  and PrimaryProcedureOpcs is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_value%20field%20COSD%20V9%20CO%20Procedure%20Occurrence%20Primary%20Procedure%20Opcs%20mapping){: .btn }
### COSD V8 CO Procedure Occurrence Procedure OPCS
* Value copied from `ProcedureOpcs`

* `ProcedureOpcs` Patient procedure other than the primary procedure (OPCS). Recommended to record multiple patient procedures where applicable. Will be mapped to procedure_concept_id and stored as procedure_source_value in the procedure_occurrence table. The OPCS-4 code will be used to look up the corresponding standard OMOP concept in the Procedure domain. [PROCEDURE (OPCS)](https://www.datadictionary.nhs.uk/data_elements/procedure__opcs_.html)

```sql
with co as (
    select distinct
        Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
        unnest ([[Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreTreatment.ColorectalCoreSurgeryAndOtherProcedures.ProcedureOPCS.@code'], Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreTreatment[*].ColorectalCoreSurgeryAndOtherProcedures.ProcedureOPCS[*].@code'], recursive := true) as ProcedureOPCS,
        unnest ([[Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreTreatment.ColorectalCoreSurgeryAndOtherProcedures.ProcedureDate'], Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreTreatment[*].ColorectalCoreSurgeryAndOtherProcedures.ProcedureDate'], recursive := true) as ProcedureDate
    from omop_staging.cosd_staging_81
    where type = 'CO'
)
select distinct
    NhsNumber,
    ProcedureOPCS,
    ProcedureDate
from co
where NhsNumber is not null
  and ProcedureOPCS is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_value%20field%20COSD%20V8%20CO%20Procedure%20Occurrence%20Procedure%20OPCS%20mapping){: .btn }
### COSD V8 CO Procedure Occurrence Primary Procedure OPCS
* Value copied from `PrimaryProcedureOpcs`

* `PrimaryProcedureOpcs` OPCS Classification of Interventions and Procedures code used to identify the primary patient procedure carried out. Will be mapped to procedure_concept_id and stored as procedure_source_value in the procedure_occurrence table. The OPCS-4 code will be used to look up the corresponding standard OMOP concept in the Procedure domain. [PRIMARY PROCEDURE (OPCS)](https://www.datadictionary.nhs.uk/data_elements/primary_procedure__opcs_.html)

```sql
with co as (
    select distinct
        Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
        unnest ([[Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreTreatment.ColorectalCoreSurgeryAndOtherProcedures.PrimaryProcedureOPCS.@code'], Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreTreatment[*].ColorectalCoreSurgeryAndOtherProcedures.PrimaryProcedureOPCS.@code'], recursive := true) as PrimaryProcedureOPCS,
        unnest ([[Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreTreatment.ColorectalCoreSurgeryAndOtherProcedures.ProcedureDate'], Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreTreatment[*].ColorectalCoreSurgeryAndOtherProcedures.ProcedureDate'], recursive := true) as ProcedureDate
    from omop_staging.cosd_staging_81
    where type = 'CO'
)
select distinct
    NhsNumber,
    PrimaryProcedureOPCS,
    ProcedureDate
from co
where NhsNumber is not null
  and PrimaryProcedureOPCS is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_value%20field%20COSD%20V8%20CO%20Procedure%20Occurrence%20Primary%20Procedure%20OPCS%20mapping){: .btn }
### Cosd V9 Procedure Occurrence Procedure Opcs
* Value copied from `ProcedureOpcsCode`

* `ProcedureOpcsCode` PROCEDURE (OPCS) is a Patient Procedure other than the PRIMARY PROCEDURE (OPCS). [PROCEDURE (OPCS)](https://www.datadictionary.nhs.uk/data_elements/procedure__opcs_.html)

```sql
with CO as (
    select distinct
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
        coalesce(Record ->> '$.Treatment[0].Surgery.ProcedureDate', Record ->> '$.Treatment.Surgery.ProcedureDate') as ProcedureDate,
        unnest(
            [
                [ Record ->> '$.Treatment.Surgery.ProcedureOpcs.@code' ],
                Record ->> '$.Treatment.Surgery.ProcedureOpcs[*].@code'
            ],
            recursive := true
        ) as ProcedureOpcsCode
    from omop_staging.cosd_staging_901
    where type = 'CO'
)
select distinct
    NhsNumber,
    ProcedureDate,
    ProcedureOpcsCode
from CO
where ProcedureOpcsCode is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_value%20field%20Cosd%20V9%20Procedure%20Occurrence%20Procedure%20Opcs%20mapping){: .btn }
### Cosd V9 Procedure Occurrence Primary Procedure Opcs
* Value copied from `PrimaryProcedureOpcs`

* `PrimaryProcedureOpcs` PRIMARY PROCEDURE (OPCS) is the OPCS Classification of Interventions and Procedures code which is used to identify the primary Patient Procedure carried out. [PRIMARY PROCEDURE (OPCS)](https://www.datadictionary.nhs.uk/data_elements/primary_procedure__opcs_.html)

```sql
select 
  distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
    coalesce(Record ->> '$.Treatment[0].Surgery.ProcedureDate', Record ->> '$.Treatment.Surgery.ProcedureDate') as ProcedureDate,
    coalesce(Record ->> '$.Treatment[0].Surgery.PrimaryProcedureOpcs.@code', Record ->> '$.Treatment.Surgery.PrimaryProcedureOpcs.@code') as PrimaryProcedureOpcs
from omop_staging.cosd_staging_901
where type = 'CO'
  and ProcedureDate is not null
  and PrimaryProcedureOpcs is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_value%20field%20Cosd%20V9%20Procedure%20Occurrence%20Primary%20Procedure%20Opcs%20mapping){: .btn }
### Cosd V8 Procedure Occurrence Procedure Opcs
* Value copied from `ProcedureOpcsCode`

* `ProcedureOpcsCode` PROCEDURE (OPCS) is a Patient Procedure other than the PRIMARY PROCEDURE (OPCS). [PROCEDURE (OPCS)](https://www.datadictionary.nhs.uk/data_elements/procedure__opcs_.html)

```sql
with co as (
  select 
    Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
    Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreTreatment.ColorectalCoreSurgeryAndOtherProcedures.ProcedureDate' as ProcedureDate,
    unnest(
      [
        [
          Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreTreatment.ColorectalCoreSurgeryAndOtherProcedures.ProcedureOPCS.@code'
        ], 
        Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreTreatment.ColorectalCoreSurgeryAndOtherProcedures.ProcedureOPCS[*].@code',
      ], recursive := true
    ) as ProcedureOpcsCode
    from omop_staging.cosd_staging_81
    where Type = 'CO'
)
select
  distinct
		NhsNumber,
		ProcedureDate,
		ProcedureOpcsCode
from co
where co.ProcedureOpcsCode is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_value%20field%20Cosd%20V8%20Procedure%20Occurrence%20Procedure%20Opcs%20mapping){: .btn }
### Cosd V8 Procedure Occurrence Primary Procedure Opcs
* Value copied from `PrimaryProcedureOpcs`

* `PrimaryProcedureOpcs` PRIMARY PROCEDURE (OPCS) is the OPCS Classification of Interventions and Procedures code which is used to identify the primary Patient Procedure carried out. [PRIMARY PROCEDURE (OPCS)](https://www.datadictionary.nhs.uk/data_elements/primary_procedure__opcs_.html)

```sql
with CO as (
  select 
    Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreTreatment.ColorectalCoreSurgeryAndOtherProcedures.ProcedureDate' as ProcedureDate,
    Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
    Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreTreatment.ColorectalCoreSurgeryAndOtherProcedures.PrimaryProcedureOPCS.@code' as PrimaryProcedureOpcs
  from omop_staging.cosd_staging_81
  where Type = 'CO'
)
select
      distinct
          ProcedureDate,
          NhsNumber,
          PrimaryProcedureOpcs
from CO o
where o.ProcedureDate is not null and o.PrimaryProcedureOpcs is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_value%20field%20Cosd%20V8%20Procedure%20Occurrence%20Primary%20Procedure%20Opcs%20mapping){: .btn }
### COSD V9 Breast Procedure Occurrence Procedure Opcs
* Value copied from `ProcedureOpcsCode`

* `ProcedureOpcsCode` PROCEDURE (OPCS) is a Patient Procedure other than the PRIMARY PROCEDURE (OPCS). [PROCEDURE (OPCS)](https://www.datadictionary.nhs.uk/data_elements/procedure__opcs_.html)

```sql
with BR as (
    select distinct
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
        coalesce(Record ->> '$.Treatment[0].Surgery.ProcedureDate', Record ->> '$.Treatment.Surgery.ProcedureDate') as ProcedureDate,
        unnest(
            [
                [ Record ->> '$.Treatment.Surgery.ProcedureOpcs.@code' ],
                Record ->> '$.Treatment.Surgery.ProcedureOpcs[*].@code'
            ],
            recursive := true
        ) as ProcedureOpcsCode
    from omop_staging.cosd_staging_901
    where type = 'BR'
)
select distinct
    NhsNumber,
    ProcedureDate,
    ProcedureOpcsCode
from BR
where ProcedureOpcsCode is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_value%20field%20COSD%20V9%20Breast%20Procedure%20Occurrence%20Procedure%20Opcs%20mapping){: .btn }
### COSD V9 Breast Procedure Occurrence Primary Procedure Opcs
* Value copied from `PrimaryProcedureOpcs`

* `PrimaryProcedureOpcs` The main or first Procedure in a series of Procedures. [PRIMARY PROCEDURE (OPCS)](https://www.datadictionary.nhs.uk/data_elements/primary_procedure__opcs_.html)

```sql
with BR as (
    select distinct
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
        coalesce(Record ->> '$.Treatment[0].Surgery.ProcedureDate', Record ->> '$.Treatment.Surgery.ProcedureDate') as ProcedureDate,
        coalesce(Record ->> '$.Treatment[0].Surgery.PrimaryProcedureOpcs.@code', Record ->> '$.Treatment.Surgery.PrimaryProcedureOpcs.@code') as PrimaryProcedureOpcs
    from omop_staging.cosd_staging_901
    where type = 'BR'
)
select
    NhsNumber,
    ProcedureDate,
    PrimaryProcedureOpcs
from BR
where ProcedureDate is not null
  and PrimaryProcedureOpcs is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_value%20field%20COSD%20V9%20Breast%20Procedure%20Occurrence%20Primary%20Procedure%20Opcs%20mapping){: .btn }
### COSD V8 Breast Procedure Occurrence Procedure Opcs
* Value copied from `ProcedureOpcsCode`

* `ProcedureOpcsCode` PROCEDURE (OPCS) is a Patient Procedure other than the PRIMARY PROCEDURE (OPCS). [PROCEDURE (OPCS)](https://www.datadictionary.nhs.uk/data_elements/procedure__opcs_.html)

```sql
with br as (
  select 
    Record ->> '$.Breast.BreastCore.BreastCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
    Record ->> '$.Breast.BreastCore.BreastCoreTreatment.BreastCoreSurgeryAndOtherProcedures.ProcedureDate' as ProcedureDate,
    unnest(
      [
        [
          Record ->> '$.Breast.BreastCore.BreastCoreTreatment.BreastCoreSurgeryAndOtherProcedures.ProcedureOPCS.@code'
        ], 
        Record ->> '$.Breast.BreastCore.BreastCoreTreatment.BreastCoreSurgeryAndOtherProcedures.ProcedureOPCS[*].@code'
      ], recursive := true
    ) as ProcedureOpcsCode
    from omop_staging.cosd_staging_81
    where Type = 'BR'
)
select
  distinct
        NhsNumber,
        ProcedureDate,
        ProcedureOpcsCode
from br
where br.ProcedureOpcsCode is not null;
--no rows in ci
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_value%20field%20COSD%20V8%20Breast%20Procedure%20Occurrence%20Procedure%20Opcs%20mapping){: .btn }
### COSD V8 Breast Procedure Occurrence Primary Procedure Opcs
* Value copied from `PrimaryProcedureOpcs`

* `PrimaryProcedureOpcs` The main or first Procedure in a series of Procedures. [PRIMARY PROCEDURE (OPCS)](https://www.datadictionary.nhs.uk/data_elements/primary_procedure__opcs_.html)

```sql
with BR as (
  select
    Record ->> '$.Breast.BreastCore.BreastCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
    Record ->> '$.Breast.BreastCore.BreastCoreTreatment.BreastCoreSurgeryAndOtherProcedures.ProcedureDate' as ProcedureDate,
    Record ->> '$.Breast.BreastCore.BreastCoreTreatment.BreastCoreSurgeryAndOtherProcedures.PrimaryProcedureOPCS.@code' as PrimaryProcedureOpcs
  from omop_staging.cosd_staging_81
  where Type = 'BR'
)
select
      distinct
          NhsNumber,
          ProcedureDate,
          PrimaryProcedureOpcs
from BR
where ProcedureDate is not null and PrimaryProcedureOpcs is not null;
--no rows in ci
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_value%20field%20COSD%20V8%20Breast%20Procedure%20Occurrence%20Primary%20Procedure%20Opcs%20mapping){: .btn }
### COSD V9 BA Procedure Occurrence Procedure Opcs Procedure Date
* Value copied from `ProcedureOpcs`

* `ProcedureOpcs` Patient procedure other than the primary procedure (OPCS). Recommended to record multiple patient procedures where applicable. Will be mapped to a standard OMOP concept to populate procedure_concept_id and stored as procedure_source_value. [PROCEDURE (OPCS)](https://www.datadictionary.nhs.uk/data_elements/procedure__opcs_.html)

```sql
with ba as (
    select distinct
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
        unnest (
            [
                [Record ->> '$.Treatment.Surgery.ProcedureDate'],
                Record ->> '$.Treatment[*].Surgery.ProcedureDate'
            ],
            recursive := true
        ) as ProcedureDate,
        unnest (
            [
                [Record ->> '$.Treatment.Surgery.ProcedureOpcs.@code'],
                Record ->> '$.Treatment[*].Surgery.ProcedureOpcs[*].@code'
            ],
            recursive := true
        ) as ProcedureOpcs
    from omop_staging.cosd_staging_901
    where type = 'BA'
)
select distinct
    NhsNumber,
    ProcedureDate,
    ProcedureOpcs
from ba
where NhsNumber is not null
  and ProcedureOpcs is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_value%20field%20COSD%20V9%20BA%20Procedure%20Occurrence%20Procedure%20Opcs%20Procedure%20Date%20mapping){: .btn }
### COSD V9 BA Procedure Occurrence Primary Procedure Opcs Procedure Date
* Value copied from `PrimaryProcedureOpcs`

* `PrimaryProcedureOpcs` OPCS Classification of Interventions and Procedures code used to identify the primary patient procedure carried out. Will be mapped to a standard OMOP concept to populate procedure_concept_id and stored as procedure_source_value. [PRIMARY PROCEDURE (OPCS)](https://www.datadictionary.nhs.uk/data_elements/primary_procedure__opcs_.html)

```sql
with ba as (
    select distinct
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
        unnest (
            [
                [Record ->> '$.Treatment.Surgery.ProcedureDate'],
                Record ->> '$.Treatment[*].Surgery.ProcedureDate'
            ],
            recursive := true
        ) as ProcedureDate,
        unnest (
            [
                [Record ->> '$.Treatment.Surgery.PrimaryProcedureOpcs.@code'],
                Record ->> '$.Treatment[*].Surgery.PrimaryProcedureOpcs.@code'
            ],
            recursive := true
        ) as PrimaryProcedureOpcs
    from omop_staging.cosd_staging_901
    where type = 'BA'
)
select distinct
    NhsNumber,
    ProcedureDate,
    PrimaryProcedureOpcs
from ba
where NhsNumber is not null
  and PrimaryProcedureOpcs is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_value%20field%20COSD%20V9%20BA%20Procedure%20Occurrence%20Primary%20Procedure%20Opcs%20Procedure%20Date%20mapping){: .btn }
### COSD V9 BA Procedure Occurrence Biopsy Type Procedure Date
* Value copied from `BiopsyType`

* `BiopsyType` The type of biopsy carried out on Central Nervous System (CNS) tumours during a Central Nervous System Cancer Care Spell. Coded values include Frame-based stereotactic biopsy (1), Frameless stereotactic biopsy (2), Open biopsy (3), Percutaneous biopsy (4), Endoscopic biopsy (5), Other biopsy (6). Will be stored as procedure_source_value and mapped to a standard concept in a later ETL step. [BIOPSY TYPE (CENTRAL NERVOUS SYSTEM TUMOURS)](https://www.datadictionary.nhs.uk/data_elements/biopsy_type__central_nervous_system_tumours_.html)

```sql
select distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
    Record ->> '$.Treatment.Surgery.ProcedureDate' as ProcedureDate,
    Record ->> '$.Treatment.Surgery.SurgeryCNS.BiopsyType.@code' as BiopsyType
from omop_staging.cosd_staging_901
where type = 'BA'
  and NhsNumber is not null
  and BiopsyType is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_value%20field%20COSD%20V9%20BA%20Procedure%20Occurrence%20Biopsy%20Type%20Procedure%20Date%20mapping){: .btn }
### COSD V8 BA Procedure Occurrence Primary Procedure OPCS Procedure Date
* Value copied from `PrimaryProcedureOpcs`

* `PrimaryProcedureOpcs` OPCS Classification of Interventions and Procedures code used to identify the primary patient procedure carried out. Will be mapped to a standard OMOP concept to populate procedure_concept_id and stored as procedure_source_value. [PRIMARY PROCEDURE (OPCS)](https://www.datadictionary.nhs.uk/data_elements/primary_procedure__opcs_.html)

```sql
with ba as (
    select distinct
        Record ->> '$.CNS.CNSCore.CNSCoreLinkagePatientId.NHSNumber.@extension' as NHSNumber,
        unnest (
            [
                [Record ->> '$.CNS.CNSCore.CNSCoreTreatment.CNSCoreSurgeryAndOtherProcedures.ProcedureDate'],
                Record ->> '$.CNS.CNSCore.CNSCoreTreatment[*].CNSCoreSurgeryAndOtherProcedures.ProcedureDate'
            ],
            recursive := true
        ) as ProcedureDate,
        unnest (
            [
                [Record ->> '$.CNS.CNSCore.CNSCoreTreatment.CNSCoreSurgeryAndOtherProcedures.PrimaryProcedureOPCS.@code'],
                Record ->> '$.CNS.CNSCore.CNSCoreTreatment[*].CNSCoreSurgeryAndOtherProcedures.PrimaryProcedureOPCS.@code'
            ],
            recursive := true
        ) as PrimaryProcedureOPCS
    from omop_staging.cosd_staging_81
    where type = 'BA'
)
select distinct
    NHSNumber,
    ProcedureDate,
    PrimaryProcedureOPCS
from ba
where NHSNumber is not null
  and PrimaryProcedureOPCS is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_source_value%20field%20COSD%20V8%20BA%20Procedure%20Occurrence%20Primary%20Procedure%20OPCS%20Procedure%20Date%20mapping){: .btn }
