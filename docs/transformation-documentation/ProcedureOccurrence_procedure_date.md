---
layout: default
title: procedure_date
parent: ProcedureOccurrence
grand_parent: Transformation Documentation
has_toc: false
---
# procedure_date
### SUS Outpatient Procedure Occurrence
Source column  `AppointmentDate`.
Converts text to dates.

* `AppointmentDate` Appointment Date. [APPOINTMENT DATE](https://www.datadictionary.nhs.uk/data_elements/appointment_date.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_date%20field%20SUS%20Outpatient%20Procedure%20Occurrence%20mapping){: .btn }
### SUS CCMDS Procedure Occurrence
Source column  `ProcedureOccurrenceStartDate`.
Converts text to dates.

* `ProcedureOccurrenceStartDate` Start date of the Procedure [CRITICAL CARE START DATE](https://www.datadictionary.nhs.uk/data_elements/critical_care_start_date.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_date%20field%20SUS%20CCMDS%20Procedure%20Occurrence%20mapping){: .btn }
### SUS APC Procedure Occurrence
Source column  `PrimaryProcedureDate`.
Converts text to dates.

* `PrimaryProcedureDate` Procedure Date. [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_date%20field%20SUS%20APC%20Procedure%20Occurrence%20mapping){: .btn }
### SUS AE Procedure Occurrence
Source column  `PrimaryProcedureDate`.
Converts text to dates.

* `PrimaryProcedureDate` Procedure Date. [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_date%20field%20SUS%20AE%20Procedure%20Occurrence%20mapping){: .btn }
### Rtds Procedure Occurrence
Source column  `event_start_date`.
Converts text to dates.

* `event_start_date` Appointment Start Time [TREATMENT START DATE (RADIOTHERAPY TREATMENT EPISODE)]()

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_date%20field%20Rtds%20Procedure%20Occurrence%20mapping){: .btn }
### Oxford Procedure Occurrence
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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_date%20field%20Oxford%20Procedure%20Occurrence%20mapping){: .btn }
### COSD V9 UR Procedure Occurrence Procedure Opcs
Source column  `ProcedureDate`.
Converts text to dates.

* `ProcedureDate` Date relevant to the activity for the procedure date. Same as the ACTIVITY DATE attribute for "Procedure Date". [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

```sql
with ur as (
    select distinct
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
        unnest ([[Record ->> '$.Treatment.Surgery.ProcedureDate'], Record ->> '$.Treatment[*].Surgery.ProcedureDate'], recursive := true) as ProcedureDate,
        unnest ([[Record ->> '$.Treatment.Surgery.ProcedureOpcs.@code'], Record ->> '$.Treatment.Surgery.ProcedureOpcs[*].@code', Record ->> '$.Treatment[*].Surgery.ProcedureOpcs[*].@code', Record ->> '$.Treatment[*].Surgery.ProcedureOpcs.@code'], recursive := true) as ProcedureOpcs
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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_date%20field%20COSD%20V9%20UR%20Procedure%20Occurrence%20Procedure%20Opcs%20mapping){: .btn }
### COSD V9 UR Procedure Occurrence Primary Procedure Opcs
Source column  `ProcedureDate`.
Converts text to dates.

* `ProcedureDate` Date relevant to the activity for the procedure date. Same as the ACTIVITY DATE attribute for "Procedure Date". [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

```sql
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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_date%20field%20COSD%20V9%20UR%20Procedure%20Occurrence%20Primary%20Procedure%20Opcs%20mapping){: .btn }
### COSD V9 UR Procedure Occurrence Diagnostic Procedure Snomed Ct
Source column  `DiagnosticProcedureDate`.
Converts text to dates.

* `DiagnosticProcedureDate` Procedure date of the diagnostic procedure. Same as the ACTIVITY DATE attribute for this diagnostic procedure. [PROCEDURE DATE (DIAGNOSTIC PROCEDURE)](https://www.datadictionary.nhs.uk/data_elements/procedure_date__diagnostic_procedure_.html)

```sql
select distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
    Record ->> '$.DiagnosticProcedures.DiagnosticProcedureDate' as DiagnosticProcedureDate,
    Record ->> '$.DiagnosticProcedures.DiagnosticProcedureSnomedCt.@code' as DiagnosticProcedureSnomedCt
from omop_staging.cosd_staging_901
where type = 'UR'
  and NhsNumber is not null
  and DiagnosticProcedureSnomedCt is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_date%20field%20COSD%20V9%20UR%20Procedure%20Occurrence%20Diagnostic%20Procedure%20Snomed%20Ct%20mapping){: .btn }
### COSD V9 UR Procedure Occurrence Diagnostic Procedure Opcs
Source column  `DiagnosticProcedureDate`.
Converts text to dates.

* `DiagnosticProcedureDate` Procedure date of the diagnostic procedure. Same as the ACTIVITY DATE attribute for this diagnostic procedure. [PROCEDURE DATE (DIAGNOSTIC PROCEDURE)](https://www.datadictionary.nhs.uk/data_elements/procedure_date__diagnostic_procedure_.html)

```sql
select distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
    Record ->> '$.DiagnosticProcedures.DiagnosticProcedureDate' as DiagnosticProcedureDate,
    Record ->> '$.DiagnosticProcedures.DiagnosticProcedureOpcs.@code' as DiagnosticProcedureOpcs
from omop_staging.cosd_staging_901
where type = 'UR'
  and NhsNumber is not null
  and DiagnosticProcedureOpcs is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_date%20field%20COSD%20V9%20UR%20Procedure%20Occurrence%20Diagnostic%20Procedure%20Opcs%20mapping){: .btn }
### COSD V8 UR Procedure Occurrence Procedure OPCS
Source column  `ProcedureDate`.
Converts text to dates.

* `ProcedureDate` Date relevant to the activity for the procedure date. Same as the ACTIVITY DATE attribute for "Procedure Date". [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

```sql
with ur as (
    select distinct
        Record ->> '$.Urological.UrologicalCore.UrologicalCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
        unnest ([[Record ->> '$.Urological.UrologicalCore.UrologicalCoreTreatment.UrologicalCoreSurgeryAndOtherProcedures.ProcedureDate'], Record ->> '$.Urological.UrologicalCore.UrologicalCoreTreatment[*].UrologicalCoreSurgeryAndOtherProcedures.ProcedureDate'], recursive := true) as ProcedureDate,
        unnest ([[Record ->> '$.Urological.UrologicalCore.UrologicalCoreTreatment.UrologicalCoreSurgeryAndOtherProcedures.ProcedureOPCS.@code'], Record ->> '$.Urological.UrologicalCore.UrologicalCoreTreatment.UrologicalCoreSurgeryAndOtherProcedures.ProcedureOPCS[*].@code', Record ->> '$.Urological.UrologicalCore.UrologicalCoreTreatment[*].UrologicalCoreSurgeryAndOtherProcedures.ProcedureOPCS[*].@code', Record ->> '$.Urological.UrologicalCore.UrologicalCoreTreatment[*].UrologicalCoreSurgeryAndOtherProcedures.ProcedureOPCS.@code'], recursive := true) as ProcedureOPCS
    from omop_staging.cosd_staging_81
    where type = 'UR'
)
select distinct
    NhsNumber,
    ProcedureDate,
    ProcedureOPCS
from ur
where NhsNumber is not null
  and ProcedureOPCS is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_date%20field%20COSD%20V8%20UR%20Procedure%20Occurrence%20Procedure%20OPCS%20mapping){: .btn }
### COSD V8 UR Procedure Occurrence Primary Procedure OPCS
Source column  `ProcedureDate`.
Converts text to dates.

* `ProcedureDate` Date relevant to the activity for the procedure date. Same as the ACTIVITY DATE attribute for "Procedure Date". [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

```sql
with ur as (
    select distinct
        Record ->> '$.Urological.UrologicalCore.UrologicalCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
        unnest ([[Record ->> '$.Urological.UrologicalCore.UrologicalCoreTreatment.UrologicalCoreSurgeryAndOtherProcedures.ProcedureDate'], Record ->> '$.Urological.UrologicalCore.UrologicalCoreTreatment[*].UrologicalCoreSurgeryAndOtherProcedures.ProcedureDate'], recursive := true) as ProcedureDate,
        unnest ([[Record ->> '$.Urological.UrologicalCore.UrologicalCoreTreatment.UrologicalCoreSurgeryAndOtherProcedures.PrimaryProcedureOPCS.@code'], Record ->> '$.Urological.UrologicalCore.UrologicalCoreTreatment[*].UrologicalCoreSurgeryAndOtherProcedures.PrimaryProcedureOPCS.@code'], recursive := true) as PrimaryProcedureOPCS
    from omop_staging.cosd_staging_81
    where type = 'UR'
)
select distinct
    NhsNumber,
    ProcedureDate,
    PrimaryProcedureOPCS
from ur
where NhsNumber is not null
  and PrimaryProcedureOPCS is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_date%20field%20COSD%20V8%20UR%20Procedure%20Occurrence%20Primary%20Procedure%20OPCS%20mapping){: .btn }
### COSD V9 UG Procedure Occurrence Procedure Opcs
Source column  `ProcedureDate`.
Converts text to dates.

* `ProcedureDate` Date relevant to the activity for the procedure date. [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_date%20field%20COSD%20V9%20UG%20Procedure%20Occurrence%20Procedure%20Opcs%20mapping){: .btn }
### COSD V9 UG Procedure Occurrence Primary Procedure Opcs
Source column  `ProcedureDate`.
Converts text to dates.

* `ProcedureDate` Date relevant to the activity for the procedure date. [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_date%20field%20COSD%20V9%20UG%20Procedure%20Occurrence%20Primary%20Procedure%20Opcs%20mapping){: .btn }
### COSD V9 UG Procedure Occurrence Diagnostic Procedure Snomed Ct
Source column  `DiagnosticProcedureDate`.
Converts text to dates.

* `DiagnosticProcedureDate` Procedure date of the diagnostic procedure. [PROCEDURE DATE (DIAGNOSTIC PROCEDURE)](https://www.datadictionary.nhs.uk/data_elements/procedure_date__diagnostic_procedure_.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_date%20field%20COSD%20V9%20UG%20Procedure%20Occurrence%20Diagnostic%20Procedure%20Snomed%20Ct%20mapping){: .btn }
### COSD V9 UG Procedure Occurrence Diagnostic Procedure Opcs
Source column  `DiagnosticProcedureDate`.
Converts text to dates.

* `DiagnosticProcedureDate` Procedure date of the diagnostic procedure. [PROCEDURE DATE (DIAGNOSTIC PROCEDURE)](https://www.datadictionary.nhs.uk/data_elements/procedure_date__diagnostic_procedure_.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_date%20field%20COSD%20V9%20UG%20Procedure%20Occurrence%20Diagnostic%20Procedure%20Opcs%20mapping){: .btn }
### COSD V8 UG Procedure Occurrence Procedure OPCS
Source column  `ProcedureDate`.
Converts text to dates.

* `ProcedureDate` Date relevant to the activity for the procedure date. [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_date%20field%20COSD%20V8%20UG%20Procedure%20Occurrence%20Procedure%20OPCS%20mapping){: .btn }
### COSD V8 UG Procedure Occurrence Primary Procedure OPCS
Source column  `ProcedureDate`.
Converts text to dates.

* `ProcedureDate` Date relevant to the activity for the procedure date. [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_date%20field%20COSD%20V8%20UG%20Procedure%20Occurrence%20Primary%20Procedure%20OPCS%20mapping){: .btn }
### COSD V9 SK Procedure Occurrence Procedure Opcs
Source column  `ProcedureDate`.
Converts text to dates.

* `ProcedureDate` Date relevant to the activity for the procedure date. Will be mapped to procedure_date in OMOP. Currently in string format (CCYY-MM-DD) and will be cast to a date type in a later ETL step. [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_date%20field%20COSD%20V9%20SK%20Procedure%20Occurrence%20Procedure%20Opcs%20mapping){: .btn }
### COSD V9 SK Procedure Occurrence Primary Procedure Opcs
Source column  `ProcedureDate`.
Converts text to dates.

* `ProcedureDate` Date relevant to the activity for the procedure date. Will be mapped to procedure_date in OMOP. Currently in string format (CCYY-MM-DD) and will be cast to a date type in a later ETL step. [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_date%20field%20COSD%20V9%20SK%20Procedure%20Occurrence%20Primary%20Procedure%20Opcs%20mapping){: .btn }
### COSD V9 SK Procedure Occurrence Diagnostic Procedure Snomed Ct
Source column  `DiagnosticProcedureDate`.
Converts text to dates.

* `DiagnosticProcedureDate` Procedure date of the diagnostic procedure. Will be mapped to procedure_date in OMOP. Currently in string format (CCYY-MM-DD) and will be cast to a date type in a later ETL step. [PROCEDURE DATE (DIAGNOSTIC PROCEDURE)](https://www.datadictionary.nhs.uk/data_elements/procedure_date__diagnostic_procedure_.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_date%20field%20COSD%20V9%20SK%20Procedure%20Occurrence%20Diagnostic%20Procedure%20Snomed%20Ct%20mapping){: .btn }
### COSD V9 SK Procedure Occurrence Diagnostic Procedure Opcs
Source column  `DiagnosticProcedureDate`.
Converts text to dates.

* `DiagnosticProcedureDate` Procedure date of the diagnostic procedure. Will be mapped to procedure_date in OMOP. Currently in string format (CCYY-MM-DD) and will be cast to a date type in a later ETL step. [PROCEDURE DATE (DIAGNOSTIC PROCEDURE)](https://www.datadictionary.nhs.uk/data_elements/procedure_date__diagnostic_procedure_.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_date%20field%20COSD%20V9%20SK%20Procedure%20Occurrence%20Diagnostic%20Procedure%20Opcs%20mapping){: .btn }
### COSD V8 SK Procedure Occurrence Procedure OPCS
Source column  `ProcedureDate`.
Converts text to dates.

* `ProcedureDate` Date relevant to the activity for the procedure date. Will be mapped to procedure_date in OMOP. Currently in string format (CCYY-MM-DD) and will be cast to a date type in a later ETL step. [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_date%20field%20COSD%20V8%20SK%20Procedure%20Occurrence%20Procedure%20OPCS%20mapping){: .btn }
### COSD V8 SK Procedure Occurrence Primary Procedure OPCS
Source column  `ProcedureDate`.
Converts text to dates.

* `ProcedureDate` Date relevant to the activity for the procedure date. Will be mapped to procedure_date in OMOP. Currently in string format (CCYY-MM-DD) and will be cast to a date type in a later ETL step. [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_date%20field%20COSD%20V8%20SK%20Procedure%20Occurrence%20Primary%20Procedure%20OPCS%20mapping){: .btn }
### COSD V9 SA Procedure Occurrence Procedure Opcs Procedure Date
Source column  `ProcedureDate`.
Converts text to dates.

* `ProcedureDate` Date relevant to the activity for the procedure date. Same as the ACTIVITY DATE attribute for "Procedure Date". Will be mapped to procedure_date in the OMOP procedure_occurrence table. Format is CCYY-MM-DD and will need date parsing in a later ETL step. [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_date%20field%20COSD%20V9%20SA%20Procedure%20Occurrence%20Procedure%20Opcs%20Procedure%20Date%20mapping){: .btn }
### COSD V9 SA Procedure Occurrence Primary Procedure Opcs Procedure Date
Source column  `ProcedureDate`.
Converts text to dates.

* `ProcedureDate` Date relevant to the activity for the procedure date. Same as the ACTIVITY DATE attribute for "Procedure Date". Will be mapped to procedure_date in the OMOP procedure_occurrence table. Format is CCYY-MM-DD and will need date parsing in a later ETL step. [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_date%20field%20COSD%20V9%20SA%20Procedure%20Occurrence%20Primary%20Procedure%20Opcs%20Procedure%20Date%20mapping){: .btn }
### COSD V8 SA Procedure Occurrence Procedure OPCS Procedure Date
Source column  `ProcedureDate`.
Converts text to dates.

* `ProcedureDate` Date relevant to the activity for the procedure date. Same as the ACTIVITY DATE attribute for "Procedure Date". Will be mapped to procedure_date in the OMOP procedure_occurrence table. Format is CCYY-MM-DD and will need date parsing in a later ETL step. [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_date%20field%20COSD%20V8%20SA%20Procedure%20Occurrence%20Procedure%20OPCS%20Procedure%20Date%20mapping){: .btn }
### COSD V8 SA Procedure Occurrence Primary Procedure OPCS Procedure Date
Source column  `ProcedureDate`.
Converts text to dates.

* `ProcedureDate` Date relevant to the activity for the procedure date. Same as the ACTIVITY DATE attribute for "Procedure Date". Will be mapped to procedure_date in the OMOP procedure_occurrence table. Format is CCYY-MM-DD and will need date parsing in a later ETL step. [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_date%20field%20COSD%20V8%20SA%20Procedure%20Occurrence%20Primary%20Procedure%20OPCS%20Procedure%20Date%20mapping){: .btn }
### COSD V9 LV Procedure Occurrence Procedure Opcs
Source column  `ProcedureDate`.
Converts text to dates.

* `ProcedureDate` Date relevant to the activity for the procedure date. Same as the ACTIVITY DATE attribute for "Procedure Date". [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_date%20field%20COSD%20V9%20LV%20Procedure%20Occurrence%20Procedure%20Opcs%20mapping){: .btn }
### COSD V9 LV Procedure Occurrence Primary Procedure Opcs
Source column  `ProcedureDate`.
Converts text to dates.

* `ProcedureDate` Date relevant to the activity for the procedure date. Same as the ACTIVITY DATE attribute for "Procedure Date". [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_date%20field%20COSD%20V9%20LV%20Procedure%20Occurrence%20Primary%20Procedure%20Opcs%20mapping){: .btn }
### COSD V8 LV Procedure Occurrence Procedure OPCS
Source column  `ProcedureDate`.
Converts text to dates.

* `ProcedureDate` Date relevant to the activity for the procedure date. Same as the ACTIVITY DATE attribute for "Procedure Date". [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_date%20field%20COSD%20V8%20LV%20Procedure%20Occurrence%20Procedure%20OPCS%20mapping){: .btn }
### COSD V8 LV Procedure Occurrence Primary Procedure OPCS
Source column  `ProcedureDate`.
Converts text to dates.

* `ProcedureDate` Date relevant to the activity for the procedure date. Same as the ACTIVITY DATE attribute for "Procedure Date". [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_date%20field%20COSD%20V8%20LV%20Procedure%20Occurrence%20Primary%20Procedure%20OPCS%20mapping){: .btn }
### CosdV9LungProcedureOccurrenceRelapseMethodOfDetection
* Value copied from `Date`

* `Date` Procedure date [CANCER RECURRENCE OR PROGRESSION - DATE DETECTED]()

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_date%20field%20CosdV9LungProcedureOccurrenceRelapseMethodOfDetection%20mapping){: .btn }
### Cosd V9 Lung Procedure Occurrence Procedure Opcs
Source column  `ProcedureDate`.
Converts text to dates.

* `ProcedureDate` The date, month, year and century, or any combination of these elements, that is of relevance to an ACTIVITY. [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_date%20field%20Cosd%20V9%20Lung%20Procedure%20Occurrence%20Procedure%20Opcs%20mapping){: .btn }
### Cosd V9 Lung Procedure Occurrence Primary Procedure Opcs
Source column  `ProcedureDate`.
Converts text to dates.

* `ProcedureDate` The date, month, year and century, or any combination of these elements, that is of relevance to an ACTIVITY. [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_date%20field%20Cosd%20V9%20Lung%20Procedure%20Occurrence%20Primary%20Procedure%20Opcs%20mapping){: .btn }
### CosdV8LungProcedureOccurrenceRelapseMethodOfDetection
* Value copied from `Date`

* `Date` Procedure date [DATE FIRST SEEN](https://www.datadictionary.nhs.uk/data_elements/date_first_seen.html), [DATE FIRST SEEN (CANCER SPECIALIST)](https://www.datadictionary.nhs.uk/data_elements/date_first_seen__cancer_specialist_.html), [DIAGNOSIS DATE](https://www.datadictionary.nhs.uk/data_elements/diagnosis_date.html), [TNM STAGE GROUPING DATE (INTEGRATED)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping_date__integrated_.html), [TNM STAGE GROUPING DATE (FINAL PRETREATMENT)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping_date__final_pretreatment_.html), [TREATMENT START DATE (CANCER)](https://www.datadictionary.nhs.uk/data_elements/treatment_start_date__cancer_.html), [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_date%20field%20CosdV8LungProcedureOccurrenceRelapseMethodOfDetection%20mapping){: .btn }
### Cosd V8 Lung Procedure Occurrence Procedure Opcs
Source column  `ProcedureDate`.
Converts text to dates.

* `ProcedureDate` The date, month, year and century, or any combination of these elements, that is of relevance to an ACTIVITY. [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_date%20field%20Cosd%20V8%20Lung%20Procedure%20Occurrence%20Procedure%20Opcs%20mapping){: .btn }
### COSD V8 Lung Procedure Occurrence Primary Procedure Opcs
Source column  `ProcedureDate`.
Converts text to dates.

* `ProcedureDate` The date on which the procedure was performed [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_date%20field%20COSD%20V8%20Lung%20Procedure%20Occurrence%20Primary%20Procedure%20Opcs%20mapping){: .btn }
### COSD V9 HN Procedure Occurrence Procedure OPCS
Source column  `ProcedureDate`.
Converts text to dates.

* `ProcedureDate` Date relevant to the activity for the procedure date. [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

```sql
-- Selects the non-primary PROCEDURE (OPCS) codes for Head and Neck (HN)
-- cancer records from COSD v9.01. Each Surgery occurrence can carry zero,
-- one or many additional OPCS-coded procedures. To preserve the
-- one-Surgery-to-many-ProcedureOpcs relationship (and so that each
-- non-primary procedure inherits the PROCEDURE DATE of the surgery it
-- belongs to), the JSON is unnested in two stages: first to one Surgery
-- object per row, then to one ProcedureOpcs code per row within that
-- Surgery. The Surgery's ProcedureDate is carried alongside each code.
--
-- Downstream ETL responsibilities:
--   * Cast ProcedureDate (currently varchar) to DATE / DATETIME and
--     assign it to procedure_date / procedure_datetime. procedure_date is
--     mandatory in OMOP procedure_occurrence.
--   * Map ProcedureOpcs to the standard procedure_concept_id and retain
--     the verbatim code in procedure_source_value.
--   * Resolve NhsNumber against cdm.person to obtain person_id.
--   * Set procedure_type_concept_id to a cancer registry / EHR
--     provenance concept.
with hn_surgery as (
    select
        -- NHS NUMBER - patient identifier, mandatory; used to join to cdm.person.
        Record ->> '$.LinkagePatientId.NhsNumber.@extension'
            as NhsNumber,
        -- Flatten Surgery to one object per row, whether Treatment is a
        -- single object or an array.
        unnest(
            [
                [Record -> '$.Treatment.Surgery'],
                Record -> '$.Treatment[*].Surgery'
            ],
            recursive := true
        ) as Surgery
    from omop_staging.cosd_staging_901
    where type = 'HN'
),
hn_proc as (
    select
        NhsNumber,
        -- PROCEDURE DATE - the date relevant to the surgery; inherited by
        -- every ProcedureOpcs code emitted from this Surgery. Becomes
        -- procedure_date / procedure_datetime downstream.
        Surgery ->> '$.ProcedureDate' as ProcedureDate,
        -- PROCEDURE (OPCS) - additional OPCS-4 coded procedures recorded
        -- against the surgery. Flattens single object and array shapes
        -- into one row per code.
        unnest(
            [
                [Surgery ->> '$.ProcedureOpcs.@code'],
                Surgery ->> '$.ProcedureOpcs[*].@code'
            ],
            recursive := true
        ) as ProcedureOpcs
    from hn_surgery
    where Surgery is not null
)
select distinct
    NhsNumber,
    ProcedureOpcs,
    ProcedureDate
from hn_proc
where NhsNumber is not null
  and ProcedureOpcs is not null
  and ProcedureDate is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_date%20field%20COSD%20V9%20HN%20Procedure%20Occurrence%20Procedure%20OPCS%20mapping){: .btn }
### COSD V9 HN Procedure Occurrence Primary Procedure OPCS
Source column  `ProcedureDate`.
Converts text to dates.

* `ProcedureDate` Date relevant to the activity for the procedure date. [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

```sql
-- Selects the PRIMARY PROCEDURE (OPCS) for Head and Neck (HN) cancer
-- records from COSD v9.01. Each Surgery occurrence contributes one row
-- per (patient, primary OPCS code, procedure date) triple. The Surgery
-- structure can appear either as a single object or as an array under
-- Treatment, so the JSON paths are unnested recursively to flatten both
-- shapes into individual rows.
--
-- Downstream ETL responsibilities:
--   * Cast ProcedureDate (currently varchar) to a DATE / DATETIME and
--     assign it to procedure_date / procedure_datetime.
--   * Map PrimaryProcedureOpcs (an OPCS-4 code) to the standard
--     procedure_concept_id and retain the verbatim code in
--     procedure_source_value.
--   * Resolve NhsNumber against cdm.person to obtain person_id.
--   * Set procedure_type_concept_id to a cancer registry / EHR provenance
--     concept (e.g. "EHR Cancer Registry record").
with hn as (
    select
        -- NHS NUMBER - patient identifier, mandatory; used to join to cdm.person.
        Record ->> '$.LinkagePatientId.NhsNumber.@extension'
            as NhsNumber,
        -- PRIMARY PROCEDURE (OPCS) - the OPCS-4 code of the primary
        -- patient procedure performed during the surgery; will be mapped
        -- to procedure_concept_id and retained as procedure_source_value.
        unnest([
            [Record ->> '$.Treatment.Surgery.PrimaryProcedureOpcs.@code'],
            Record ->> '$.Treatment[*].Surgery.PrimaryProcedureOpcs.@code'
        ], recursive := true) as PrimaryProcedureOpcs,
        -- PROCEDURE DATE - the date relevant to the surgery; paired
        -- one-to-one with PrimaryProcedureOpcs via lockstep unnest so
        -- each procedure code keeps its own date.
        unnest([
            [Record ->> '$.Treatment.Surgery.ProcedureDate'],
            Record ->> '$.Treatment[*].Surgery.ProcedureDate'
        ], recursive := true) as ProcedureDate
    from omop_staging.cosd_staging_901
    where type = 'HN'
)
select distinct
    NhsNumber,
    PrimaryProcedureOpcs,
    ProcedureDate
from hn
where NhsNumber is not null
  and PrimaryProcedureOpcs is not null
  and ProcedureDate is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_date%20field%20COSD%20V9%20HN%20Procedure%20Occurrence%20Primary%20Procedure%20OPCS%20mapping){: .btn }
### COSD V9 HN Procedure Occurrence Diagnostic Procedure SNOMEDCT
Source column  `DiagnosticProcedureDate`.
Converts text to dates.

* `DiagnosticProcedureDate` Procedure date of the diagnostic procedure. [PROCEDURE DATE (DIAGNOSTIC PROCEDURE)](https://www.datadictionary.nhs.uk/data_elements/procedure_date__diagnostic_procedure_.html)

```sql
-- Selects the DIAGNOSTIC PROCEDURE (SNOMED CT) for Head and Neck (HN)
-- cancer records from COSD v9.01. Each diagnostic procedure contributes
-- one row per (patient, SNOMED CT code, procedure date) triple.
-- DiagnosticProcedures is captured as a singular structure in the source,
-- so no unnest is required.
--
-- Downstream ETL responsibilities:
--   * Cast DiagnosticProcedureDate (currently varchar) to a DATE /
--     DATETIME and assign it to procedure_date / procedure_datetime.
--   * Map DiagnosticProcedureSnomedCt (a SNOMED CT concept id) to the
--     standard procedure_concept_id and retain the verbatim code in
--     procedure_source_value.
--   * Resolve NhsNumber against cdm.person to obtain person_id.
--   * Set procedure_type_concept_id to a cancer registry / EHR provenance
--     concept.
select distinct
    -- NHS NUMBER - patient identifier, mandatory; used to join to cdm.person.
    Record ->> '$.LinkagePatientId.NhsNumber.@extension'
        as NhsNumber,
    -- PROCEDURE DATE (DIAGNOSTIC PROCEDURE) - the date relevant to the
    -- diagnostic procedure; becomes procedure_date / procedure_datetime.
    Record ->> '$.DiagnosticProcedures.DiagnosticProcedureDate'
        as DiagnosticProcedureDate,
    -- DIAGNOSTIC PROCEDURE (SNOMED CT) - the SNOMED CT concept id
    -- identifying the diagnostic procedure carried out; will be mapped to
    -- procedure_concept_id and retained as procedure_source_value.
    Record ->> '$.DiagnosticProcedures.DiagnosticProcedureSnomedCt.@code'
        as DiagnosticProcedureSnomedCt
from omop_staging.cosd_staging_901
where type = 'HN'
  and NhsNumber is not null
  and DiagnosticProcedureSnomedCt is not null
  and DiagnosticProcedureDate is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_date%20field%20COSD%20V9%20HN%20Procedure%20Occurrence%20Diagnostic%20Procedure%20SNOMEDCT%20mapping){: .btn }
### COSD V9 HN Procedure Occurrence Diagnostic Procedure OPCS
Source column  `DiagnosticProcedureDate`.
Converts text to dates.

* `DiagnosticProcedureDate` Procedure date of the diagnostic procedure. [PROCEDURE DATE (DIAGNOSTIC PROCEDURE)](https://www.datadictionary.nhs.uk/data_elements/procedure_date__diagnostic_procedure_.html)

```sql
-- Selects the DIAGNOSTIC PROCEDURE (OPCS) for Head and Neck (HN) cancer
-- records from COSD v9.01. Each diagnostic procedure contributes one row
-- per (patient, OPCS code, procedure date) triple. DiagnosticProcedures
-- is captured as a singular structure in the source, so no unnest is
-- required.
--
-- Downstream ETL responsibilities:
--   * Cast DiagnosticProcedureDate (currently varchar) to a DATE /
--     DATETIME and assign it to procedure_date / procedure_datetime.
--   * Map DiagnosticProcedureOpcs (an OPCS-4 code) to the standard
--     procedure_concept_id and retain the verbatim code in
--     procedure_source_value.
--   * Resolve NhsNumber against cdm.person to obtain person_id.
--   * Set procedure_type_concept_id to a cancer registry / EHR provenance
--     concept.
select distinct
    -- NHS NUMBER - patient identifier, mandatory; used to join to cdm.person.
    Record ->> '$.LinkagePatientId.NhsNumber.@extension'
        as NhsNumber,
    -- PROCEDURE DATE (DIAGNOSTIC PROCEDURE) - the date relevant to the
    -- diagnostic procedure; becomes procedure_date / procedure_datetime.
    Record ->> '$.DiagnosticProcedures.DiagnosticProcedureDate'
        as DiagnosticProcedureDate,
    -- DIAGNOSTIC PROCEDURE (OPCS) - the OPCS-4 code identifying the
    -- diagnostic procedure carried out; will be mapped to
    -- procedure_concept_id and retained as procedure_source_value.
    Record ->> '$.DiagnosticProcedures.DiagnosticProcedureOpcs.@code'
        as DiagnosticProcedureOpcs
from omop_staging.cosd_staging_901
where type = 'HN'
  and NhsNumber is not null
  and DiagnosticProcedureOpcs is not null
  and DiagnosticProcedureDate is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_date%20field%20COSD%20V9%20HN%20Procedure%20Occurrence%20Diagnostic%20Procedure%20OPCS%20mapping){: .btn }
### COSD V8 HN Procedure Occurrence Procedure OPCS
Source column  `ProcedureDate`.
Converts text to dates.

* `ProcedureDate` Date relevant to the activity for the procedure date. [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

```sql
-- Selects the non-primary PROCEDURE (OPCS) codes for Head and Neck (HN)
-- cancer records from COSD v8.1. Each Surgery occurrence can carry zero,
-- one or many additional OPCS-coded procedures. To preserve the
-- one-Surgery-to-many-ProcedureOPCS relationship (and so that each
-- non-primary procedure inherits the PROCEDURE DATE of the surgery it
-- belongs to), the JSON is unnested in two stages: first to one Surgery
-- object per row, then to one ProcedureOPCS code per row within that
-- Surgery. The Surgery's ProcedureDate is carried alongside each code.
--
-- Downstream ETL responsibilities:
--   * Cast ProcedureDate (currently varchar) to DATE / DATETIME and
--     assign it to procedure_date / procedure_datetime. procedure_date is
--     mandatory in OMOP procedure_occurrence.
--   * Map ProcedureOPCS to the standard procedure_concept_id and retain
--     the verbatim code in procedure_source_value.
--   * Resolve NHSNumber against cdm.person to obtain person_id.
--   * Set procedure_type_concept_id to a cancer registry / EHR
--     provenance concept.
with hn_surgery as (
    select
        -- NHS NUMBER - patient identifier, mandatory; used to join to cdm.person.
        Record ->> '$.HeadNeck.HeadNeckCore.HeadNeckCoreLinkagePatientId.NHSNumber.@extension'
            as NHSNumber,
        -- Flatten the Surgery container
        -- (HeadNeckCoreSurgeryAndOtherProcedures) to one object per row,
        -- whether HeadNeckCoreTreatment is a single object or an array.
        unnest(
            [
                [Record -> '$.HeadNeck.HeadNeckCore.HeadNeckCoreTreatment.HeadNeckCoreSurgeryAndOtherProcedures'],
                Record -> '$.HeadNeck.HeadNeckCore.HeadNeckCoreTreatment[*].HeadNeckCoreSurgeryAndOtherProcedures'
            ],
            recursive := true
        ) as Surgery
    from omop_staging.cosd_staging_81
    where type = 'HN'
),
hn_proc as (
    select
        NHSNumber,
        -- PROCEDURE DATE - the date relevant to the surgery; inherited by
        -- every ProcedureOPCS code emitted from this Surgery. Becomes
        -- procedure_date / procedure_datetime downstream.
        Surgery ->> '$.ProcedureDate' as ProcedureDate,
        -- PROCEDURE (OPCS) - additional OPCS-4 coded procedures recorded
        -- against the surgery. Flattens single object and array shapes
        -- into one row per code.
        unnest(
            [
                [Surgery ->> '$.ProcedureOPCS.@code'],
                Surgery ->> '$.ProcedureOPCS[*].@code'
            ],
            recursive := true
        ) as ProcedureOPCS
    from hn_surgery
    where Surgery is not null
)
select distinct
    NHSNumber,
    ProcedureOPCS,
    ProcedureDate
from hn_proc
where NHSNumber is not null
  and ProcedureOPCS is not null
  and ProcedureDate is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_date%20field%20COSD%20V8%20HN%20Procedure%20Occurrence%20Procedure%20OPCS%20mapping){: .btn }
### COSD V8 HN Procedure Occurrence Primary Procedure OPCS
Source column  `ProcedureDate`.
Converts text to dates.

* `ProcedureDate` Date relevant to the activity for the procedure date. [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

```sql
-- Selects the PRIMARY PROCEDURE (OPCS) for Head and Neck (HN) cancer
-- records from COSD v8.1. Each Surgery occurrence contributes one row per
-- (patient, primary OPCS code, procedure date) triple. The Surgery
-- structure can appear either as a single object or as an array under
-- HeadNeckCoreTreatment, so the JSON paths are unnested recursively to
-- flatten both shapes into individual rows.
--
-- Downstream ETL responsibilities:
--   * Cast ProcedureDate (currently varchar) to a DATE / DATETIME and
--     assign it to procedure_date / procedure_datetime.
--   * Map PrimaryProcedureOPCS (an OPCS-4 code) to the standard
--     procedure_concept_id and retain the verbatim code in
--     procedure_source_value.
--   * Resolve NHSNumber against cdm.person to obtain person_id.
--   * Set procedure_type_concept_id to a cancer registry / EHR provenance
--     concept (e.g. "EHR Cancer Registry record").
with hn as (
    select
        -- NHS NUMBER - patient identifier, mandatory; used to join to cdm.person.
        Record ->> '$.HeadNeck.HeadNeckCore.HeadNeckCoreLinkagePatientId.NHSNumber.@extension'
            as NHSNumber,
        -- PRIMARY PROCEDURE (OPCS) - the OPCS-4 code of the primary
        -- patient procedure performed during the surgery; will be mapped
        -- to procedure_concept_id and retained as procedure_source_value.
        unnest([
            [Record ->> '$.HeadNeck.HeadNeckCore.HeadNeckCoreTreatment.HeadNeckCoreSurgeryAndOtherProcedures.PrimaryProcedureOPCS.@code'],
            Record ->> '$.HeadNeck.HeadNeckCore.HeadNeckCoreTreatment[*].HeadNeckCoreSurgeryAndOtherProcedures.PrimaryProcedureOPCS.@code'
        ], recursive := true) as PrimaryProcedureOPCS,
        -- PROCEDURE DATE - the date relevant to the surgery; paired
        -- one-to-one with PrimaryProcedureOPCS via lockstep unnest so
        -- each procedure code keeps its own date.
        unnest([
            [Record ->> '$.HeadNeck.HeadNeckCore.HeadNeckCoreTreatment.HeadNeckCoreSurgeryAndOtherProcedures.ProcedureDate'],
            Record ->> '$.HeadNeck.HeadNeckCore.HeadNeckCoreTreatment[*].HeadNeckCoreSurgeryAndOtherProcedures.ProcedureDate'
        ], recursive := true) as ProcedureDate
    from omop_staging.cosd_staging_81
    where type = 'HN'
)
select distinct
    NHSNumber,
    PrimaryProcedureOPCS,
    ProcedureDate
from hn
where NHSNumber is not null
  and PrimaryProcedureOPCS is not null
  and ProcedureDate is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_date%20field%20COSD%20V8%20HN%20Procedure%20Occurrence%20Primary%20Procedure%20OPCS%20mapping){: .btn }
### COSD V9 HA Procedure Occurrence Procedure Opcs
Source column  `ProcedureDate`.
Converts text to dates.

* `ProcedureDate` Date relevant to the activity for the procedure date. Same as the ACTIVITY DATE attribute for "Procedure Date". [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_date%20field%20COSD%20V9%20HA%20Procedure%20Occurrence%20Procedure%20Opcs%20mapping){: .btn }
### COSD V9 HA Procedure Occurrence Primary Procedure Opcs
Source column  `ProcedureDate`.
Converts text to dates.

* `ProcedureDate` Date relevant to the activity for the procedure date. Same as the ACTIVITY DATE attribute for "Procedure Date". [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_date%20field%20COSD%20V9%20HA%20Procedure%20Occurrence%20Primary%20Procedure%20Opcs%20mapping){: .btn }
### COSD V9 HA Procedure Occurrence Diagnostic Procedure Snomed Ct
Source column  `DiagnosticProcedureDate`.
Converts text to dates.

* `DiagnosticProcedureDate` Procedure date of the diagnostic procedure. Same as the ACTIVITY DATE attribute for this diagnostic procedure. [PROCEDURE DATE (DIAGNOSTIC PROCEDURE)](https://www.datadictionary.nhs.uk/data_elements/procedure_date__diagnostic_procedure_.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_date%20field%20COSD%20V9%20HA%20Procedure%20Occurrence%20Diagnostic%20Procedure%20Snomed%20Ct%20mapping){: .btn }
### COSD V9 HA Procedure Occurrence Diagnostic Procedure Opcs
Source column  `DiagnosticProcedureDate`.
Converts text to dates.

* `DiagnosticProcedureDate` Procedure date of the diagnostic procedure. Same as the ACTIVITY DATE attribute for this diagnostic procedure. [PROCEDURE DATE (DIAGNOSTIC PROCEDURE)](https://www.datadictionary.nhs.uk/data_elements/procedure_date__diagnostic_procedure_.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_date%20field%20COSD%20V9%20HA%20Procedure%20Occurrence%20Diagnostic%20Procedure%20Opcs%20mapping){: .btn }
### COSD V9 GY Procedure Occurrence Procedure OPCS
Source column  `ProcedureDate`.
Converts text to dates.

* `ProcedureDate` Date relevant to the activity for the procedure date. [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

```sql
-- Selects the non-primary PROCEDURE (OPCS) codes for Gynaecological (GY)
-- cancer records from COSD v9.01. Each Surgery occurrence can carry zero,
-- one or many additional OPCS-coded procedures. To preserve the
-- one-Surgery-to-many-ProcedureOpcs relationship (and so that each
-- non-primary procedure inherits the PROCEDURE DATE of the surgery it
-- belongs to), the JSON is unnested in two stages: first to one Surgery
-- object per row, then to one ProcedureOpcs code per row within that
-- Surgery. The Surgery's ProcedureDate is carried alongside each code.
--
-- Downstream ETL responsibilities:
--   * Cast ProcedureDate (currently varchar) to DATE / DATETIME and
--     assign it to procedure_date / procedure_datetime. procedure_date is
--     mandatory in OMOP procedure_occurrence.
--   * Map ProcedureOpcs to the standard procedure_concept_id and retain
--     the verbatim code in procedure_source_value.
--   * Resolve NhsNumber against cdm.person to obtain person_id.
--   * Set procedure_type_concept_id to a cancer registry / EHR
--     provenance concept.
with gy_surgery as (
    select
        -- NHS NUMBER - patient identifier, mandatory; used to join to cdm.person.
        Record ->> '$.LinkagePatientId.NhsNumber.@extension'
            as NhsNumber,
        -- Flatten Surgery to one object per row, whether Treatment is a
        -- single object or an array.
        unnest(
            [
                [Record -> '$.Treatment.Surgery'],
                Record -> '$.Treatment[*].Surgery'
            ],
            recursive := true
        ) as Surgery
    from omop_staging.cosd_staging_901
    where type = 'GY'
),
gy_proc as (
    select
        NhsNumber,
        -- PROCEDURE DATE - the date relevant to the surgery; inherited by
        -- every ProcedureOpcs code emitted from this Surgery. Becomes
        -- procedure_date / procedure_datetime downstream.
        Surgery ->> '$.ProcedureDate' as ProcedureDate,
        -- PROCEDURE (OPCS) - additional OPCS-4 coded procedures recorded
        -- against the surgery. Flattens single object and array shapes
        -- into one row per code.
        unnest(
            [
                [Surgery ->> '$.ProcedureOpcs.@code'],
                Surgery ->> '$.ProcedureOpcs[*].@code'
            ],
            recursive := true
        ) as ProcedureOpcs
    from gy_surgery
    where Surgery is not null
)
select distinct
    NhsNumber,
    ProcedureOpcs,
    ProcedureDate
from gy_proc
where NhsNumber is not null
  and ProcedureOpcs is not null
  and ProcedureDate is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_date%20field%20COSD%20V9%20GY%20Procedure%20Occurrence%20Procedure%20OPCS%20mapping){: .btn }
### COSD V9 GY Procedure Occurrence Primary Procedure OPCS
Source column  `ProcedureDate`.
Converts text to dates.

* `ProcedureDate` Date relevant to the activity for the procedure date. [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

```sql
-- Selects the PRIMARY PROCEDURE (OPCS) for Gynaecological (GY) cancer
-- records from COSD v9.01. Each Surgery occurrence contributes one row per
-- (patient, primary OPCS code, procedure date) triple. The Surgery
-- structure can appear either as a single object or as an array under
-- Treatment, so the JSON paths are unnested recursively to flatten both
-- shapes into individual rows.
--
-- Downstream ETL responsibilities:
--   * Cast ProcedureDate (currently varchar) to a DATE / DATETIME and
--     assign it to procedure_date / procedure_datetime.
--   * Map PrimaryProcedureOpcs (an OPCS-4 code) to the standard
--     procedure_concept_id and retain the verbatim code in
--     procedure_source_value.
--   * Resolve NhsNumber against cdm.person to obtain person_id.
--   * Set procedure_type_concept_id to a cancer registry / EHR provenance
--     concept (e.g. "EHR Cancer Registry record").
with gy as (
    select
        -- NHS NUMBER - patient identifier, mandatory; used to join to cdm.person.
        Record ->> '$.LinkagePatientId.NhsNumber.@extension'
            as NhsNumber,
        -- PRIMARY PROCEDURE (OPCS) - the OPCS-4 code of the primary
        -- patient procedure performed during the surgery; will be mapped
        -- to procedure_concept_id and retained as procedure_source_value.
        unnest([
            [Record ->> '$.Treatment.Surgery.PrimaryProcedureOpcs.@code'],
            Record ->> '$.Treatment[*].Surgery.PrimaryProcedureOpcs.@code'
        ], recursive := true) as PrimaryProcedureOpcs,
        -- PROCEDURE DATE - the date relevant to the surgery; paired
        -- one-to-one with PrimaryProcedureOpcs via lockstep unnest so
        -- each procedure code keeps its own date.
        unnest([
            [Record ->> '$.Treatment.Surgery.ProcedureDate'],
            Record ->> '$.Treatment[*].Surgery.ProcedureDate'
        ], recursive := true) as ProcedureDate
    from omop_staging.cosd_staging_901
    where type = 'GY'
)
select distinct
    NhsNumber,
    PrimaryProcedureOpcs,
    ProcedureDate
from gy
where NhsNumber is not null
  and PrimaryProcedureOpcs is not null
  and ProcedureDate is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_date%20field%20COSD%20V9%20GY%20Procedure%20Occurrence%20Primary%20Procedure%20OPCS%20mapping){: .btn }
### COSD V9 GY Procedure Occurrence Diagnostic Procedure SNOMEDCT
Source column  `DiagnosticProcedureDate`.
Converts text to dates.

* `DiagnosticProcedureDate` Procedure date of the diagnostic procedure. [PROCEDURE DATE (DIAGNOSTIC PROCEDURE)](https://www.datadictionary.nhs.uk/data_elements/procedure_date__diagnostic_procedure_.html)

```sql
-- Selects the DIAGNOSTIC PROCEDURE (SNOMED CT) for Gynaecological (GY)
-- cancer records from COSD v9.01. Each diagnostic procedure contributes
-- one row per (patient, SNOMED CT code, procedure date) triple.
-- DiagnosticProcedures is captured as a singular structure in the source,
-- so no unnest is required.
--
-- Downstream ETL responsibilities:
--   * Cast DiagnosticProcedureDate (currently varchar) to a DATE /
--     DATETIME and assign it to procedure_date / procedure_datetime.
--   * Map DiagnosticProcedureSnomedCt (a SNOMED CT concept id) to the
--     standard procedure_concept_id and retain the verbatim code in
--     procedure_source_value.
--   * Resolve NhsNumber against cdm.person to obtain person_id.
--   * Set procedure_type_concept_id to a cancer registry / EHR provenance
--     concept.
select distinct
    -- NHS NUMBER - patient identifier, mandatory; used to join to cdm.person.
    Record ->> '$.LinkagePatientId.NhsNumber.@extension'
        as NhsNumber,
    -- PROCEDURE DATE (DIAGNOSTIC PROCEDURE) - the date relevant to the
    -- diagnostic procedure; becomes procedure_date / procedure_datetime.
    Record ->> '$.DiagnosticProcedures.DiagnosticProcedureDate'
        as DiagnosticProcedureDate,
    -- DIAGNOSTIC PROCEDURE (SNOMED CT) - the SNOMED CT concept id
    -- identifying the diagnostic procedure carried out; will be mapped to
    -- procedure_concept_id and retained as procedure_source_value.
    Record ->> '$.DiagnosticProcedures.DiagnosticProcedureSnomedCt.@code'
        as DiagnosticProcedureSnomedCt
from omop_staging.cosd_staging_901
where type = 'GY'
  and NhsNumber is not null
  and DiagnosticProcedureSnomedCt is not null
  and DiagnosticProcedureDate is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_date%20field%20COSD%20V9%20GY%20Procedure%20Occurrence%20Diagnostic%20Procedure%20SNOMEDCT%20mapping){: .btn }
### COSD V9 GY Procedure Occurrence Diagnostic Procedure OPCS
Source column  `DiagnosticProcedureDate`.
Converts text to dates.

* `DiagnosticProcedureDate` Procedure date of the diagnostic procedure. [PROCEDURE DATE (DIAGNOSTIC PROCEDURE)](https://www.datadictionary.nhs.uk/data_elements/procedure_date__diagnostic_procedure_.html)

```sql
-- Selects the DIAGNOSTIC PROCEDURE (OPCS) for Gynaecological (GY) cancer
-- records from COSD v9.01. Each diagnostic procedure contributes one row
-- per (patient, OPCS code, procedure date) triple. DiagnosticProcedures
-- is captured as a singular structure in the source, so no unnest is
-- required.
--
-- Downstream ETL responsibilities:
--   * Cast DiagnosticProcedureDate (currently varchar) to a DATE /
--     DATETIME and assign it to procedure_date / procedure_datetime.
--   * Map DiagnosticProcedureOpcs (an OPCS-4 code) to the standard
--     procedure_concept_id and retain the verbatim code in
--     procedure_source_value.
--   * Resolve NhsNumber against cdm.person to obtain person_id.
--   * Set procedure_type_concept_id to a cancer registry / EHR provenance
--     concept.
select distinct
    -- NHS NUMBER - patient identifier, mandatory; used to join to cdm.person.
    Record ->> '$.LinkagePatientId.NhsNumber.@extension'
        as NhsNumber,
    -- PROCEDURE DATE (DIAGNOSTIC PROCEDURE) - the date relevant to the
    -- diagnostic procedure; becomes procedure_date / procedure_datetime.
    Record ->> '$.DiagnosticProcedures.DiagnosticProcedureDate'
        as DiagnosticProcedureDate,
    -- DIAGNOSTIC PROCEDURE (OPCS) - the OPCS-4 code identifying the
    -- diagnostic procedure carried out; will be mapped to
    -- procedure_concept_id and retained as procedure_source_value.
    Record ->> '$.DiagnosticProcedures.DiagnosticProcedureOpcs.@code'
        as DiagnosticProcedureOpcs
from omop_staging.cosd_staging_901
where type = 'GY'
  and NhsNumber is not null
  and DiagnosticProcedureOpcs is not null
  and DiagnosticProcedureDate is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_date%20field%20COSD%20V9%20GY%20Procedure%20Occurrence%20Diagnostic%20Procedure%20OPCS%20mapping){: .btn }
### COSD V8 GY Procedure Occurrence Procedure OPCS
Source column  `ProcedureDate`.
Converts text to dates.

* `ProcedureDate` Date relevant to the activity for the procedure date. [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

```sql
-- Selects the non-primary PROCEDURE (OPCS) codes for Gynaecological (GY)
-- cancer records from COSD v8.1. Each Surgery occurrence can carry zero,
-- one or many additional OPCS-coded procedures. To preserve the
-- one-Surgery-to-many-ProcedureOPCS relationship (and so that each
-- non-primary procedure inherits the PROCEDURE DATE of the surgery it
-- belongs to), the JSON is unnested in two stages: first to one Surgery
-- object per row, then to one ProcedureOPCS code per row within that
-- Surgery. The Surgery's ProcedureDate is carried alongside each code.
--
-- Downstream ETL responsibilities:
--   * Cast ProcedureDate (currently varchar) to DATE / DATETIME and
--     assign it to procedure_date / procedure_datetime. procedure_date is
--     mandatory in OMOP procedure_occurrence.
--   * Map ProcedureOPCS to the standard procedure_concept_id and retain
--     the verbatim code in procedure_source_value.
--   * Resolve NHSNumber against cdm.person to obtain person_id.
--   * Set procedure_type_concept_id to a cancer registry / EHR
--     provenance concept.
with gy_surgery as (
    select
        -- NHS NUMBER - patient identifier, mandatory; used to join to cdm.person.
        Record ->> '$.Gynaecological.GynaecologicalCore.GynaecologicalCoreLinkagePatientId.NHSNumber.@extension'
            as NHSNumber,
        -- Flatten the Surgery container
        -- (GynaecologicalCoreSurgeryAndOtherProcedures) to one object per
        -- row, whether GynaecologicalCoreTreatment is a single object or
        -- an array.
        unnest(
            [
                [Record -> '$.Gynaecological.GynaecologicalCore.GynaecologicalCoreTreatment.GynaecologicalCoreSurgeryAndOtherProcedures'],
                Record -> '$.Gynaecological.GynaecologicalCore.GynaecologicalCoreTreatment[*].GynaecologicalCoreSurgeryAndOtherProcedures'
            ],
            recursive := true
        ) as Surgery
    from omop_staging.cosd_staging_81
    where type = 'GY'
),
gy_proc as (
    select
        NHSNumber,
        -- PROCEDURE DATE - the date relevant to the surgery; inherited by
        -- every ProcedureOPCS code emitted from this Surgery. Becomes
        -- procedure_date / procedure_datetime downstream.
        Surgery ->> '$.ProcedureDate' as ProcedureDate,
        -- PROCEDURE (OPCS) - additional OPCS-4 coded procedures recorded
        -- against the surgery. Flattens single object and array shapes
        -- into one row per code.
        unnest(
            [
                [Surgery ->> '$.ProcedureOPCS.@code'],
                Surgery ->> '$.ProcedureOPCS[*].@code'
            ],
            recursive := true
        ) as ProcedureOPCS
    from gy_surgery
    where Surgery is not null
)
select distinct
    NHSNumber,
    ProcedureOPCS,
    ProcedureDate
from gy_proc
where NHSNumber is not null
  and ProcedureOPCS is not null
  and ProcedureDate is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_date%20field%20COSD%20V8%20GY%20Procedure%20Occurrence%20Procedure%20OPCS%20mapping){: .btn }
### COSD V8 GY Procedure Occurrence Primary Procedure OPCS
Source column  `ProcedureDate`.
Converts text to dates.

* `ProcedureDate` Date relevant to the activity for the procedure date. [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

```sql
-- Selects the PRIMARY PROCEDURE (OPCS) for Gynaecological (GY) cancer
-- records from COSD v8.1. Each Surgery occurrence contributes one row per
-- (patient, primary OPCS code, procedure date) triple. The Surgery
-- structure can appear either as a single object or as an array under
-- GynaecologicalCoreTreatment, so the JSON paths are unnested recursively
-- to flatten both shapes into individual rows.
--
-- Downstream ETL responsibilities:
--   * Cast ProcedureDate (currently varchar) to a DATE / DATETIME and
--     assign it to procedure_date / procedure_datetime.
--   * Map PrimaryProcedureOPCS (an OPCS-4 code) to the standard
--     procedure_concept_id and retain the verbatim code in
--     procedure_source_value.
--   * Resolve NHSNumber against cdm.person to obtain person_id.
--   * Set procedure_type_concept_id to a cancer registry / EHR provenance
--     concept (e.g. "EHR Cancer Registry record").
with gy as (
    select
        -- NHS NUMBER - patient identifier, mandatory; used to join to cdm.person.
        Record ->> '$.Gynaecological.GynaecologicalCore.GynaecologicalCoreLinkagePatientId.NHSNumber.@extension'
            as NHSNumber,
        -- PRIMARY PROCEDURE (OPCS) - the OPCS-4 code of the primary
        -- patient procedure performed during the surgery; will be mapped
        -- to procedure_concept_id and retained as procedure_source_value.
        unnest([
            [Record ->> '$.Gynaecological.GynaecologicalCore.GynaecologicalCoreTreatment.GynaecologicalCoreSurgeryAndOtherProcedures.PrimaryProcedureOPCS.@code'],
            Record ->> '$.Gynaecological.GynaecologicalCore.GynaecologicalCoreTreatment[*].GynaecologicalCoreSurgeryAndOtherProcedures.PrimaryProcedureOPCS.@code'
        ], recursive := true) as PrimaryProcedureOPCS,
        -- PROCEDURE DATE - the date relevant to the surgery; paired
        -- one-to-one with PrimaryProcedureOPCS via lockstep unnest so
        -- each procedure code keeps its own date.
        unnest([
            [Record ->> '$.Gynaecological.GynaecologicalCore.GynaecologicalCoreTreatment.GynaecologicalCoreSurgeryAndOtherProcedures.ProcedureDate'],
            Record ->> '$.Gynaecological.GynaecologicalCore.GynaecologicalCoreTreatment[*].GynaecologicalCoreSurgeryAndOtherProcedures.ProcedureDate'
        ], recursive := true) as ProcedureDate
    from omop_staging.cosd_staging_81
    where type = 'GY'
)
select distinct
    NHSNumber,
    PrimaryProcedureOPCS,
    ProcedureDate
from gy
where NHSNumber is not null
  and PrimaryProcedureOPCS is not null
  and ProcedureDate is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_date%20field%20COSD%20V8%20GY%20Procedure%20Occurrence%20Primary%20Procedure%20OPCS%20mapping){: .btn }
### COSD V901 CT Procedure Occurrence Procedure Opcs
Source column  `ProcedureDate`.
Converts text to dates.

* `ProcedureDate` Date relevant to the activity for the procedure date. Same as the ACTIVITY DATE attribute for "Procedure Date". [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_date%20field%20COSD%20V901%20CT%20Procedure%20Occurrence%20Procedure%20Opcs%20mapping){: .btn }
### COSD V901 CT Procedure Occurrence Primary Procedure Opcs
Source column  `ProcedureDate`.
Converts text to dates.

* `ProcedureDate` Date relevant to the activity for the procedure date. Same as the ACTIVITY DATE attribute for "Procedure Date". [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_date%20field%20COSD%20V901%20CT%20Procedure%20Occurrence%20Primary%20Procedure%20Opcs%20mapping){: .btn }
### COSD V8 CT Procedure Occurrence Primary Procedure OPCS
Source column  `ProcedureDate`.
Converts text to dates.

* `ProcedureDate` Date relevant to the activity for the procedure date. Same as the ACTIVITY DATE attribute for "Procedure Date". [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_date%20field%20COSD%20V8%20CT%20Procedure%20Occurrence%20Primary%20Procedure%20OPCS%20mapping){: .btn }
### COSD V9 CR Procedure Occurrence Procedure OPCS
Source column  `ProcedureDate`.
Converts text to dates.

* `ProcedureDate` Date relevant to the activity for the procedure date. [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

```sql
-- Selects the non-primary PROCEDURE (OPCS) codes for Colorectal (CR)
-- cancer records from COSD v9.01. Each Surgery occurrence can carry zero,
-- one or many additional OPCS-coded procedures. To preserve the
-- one-Surgery-to-many-ProcedureOpcs relationship (and so that each
-- non-primary procedure inherits the PROCEDURE DATE of the surgery it
-- belongs to), the JSON is unnested in two stages: first to one Surgery
-- object per row, then to one ProcedureOpcs code per row within that
-- Surgery. The Surgery's ProcedureDate is carried alongside each code.
--
-- Downstream ETL responsibilities:
--   * Cast ProcedureDate (currently varchar) to DATE / DATETIME and
--     assign it to procedure_date / procedure_datetime. procedure_date is
--     mandatory in OMOP procedure_occurrence.
--   * Map ProcedureOpcs to the standard procedure_concept_id and retain
--     the verbatim code in procedure_source_value.
--   * Resolve NhsNumber against cdm.person to obtain person_id.
--   * Set procedure_type_concept_id to a cancer registry / EHR
--     provenance concept.
with cr_surgery as (
    select
        -- NHS NUMBER - patient identifier, mandatory; used to join to cdm.person.
        Record ->> '$.LinkagePatientId.NhsNumber.@extension'
            as NhsNumber,
        -- Flatten Surgery to one object per row, whether Treatment is a
        -- single object or an array. The recursive unnest handles the
        -- list-of-one (single Surgery) and list (array Surgery) cases.
        unnest(
            [
                [Record -> '$.Treatment.Surgery'],
                Record -> '$.Treatment[*].Surgery'
            ],
            recursive := true
        ) as Surgery
    from omop_staging.cosd_staging_901
    where type = 'CR'
),
cr_proc as (
    select
        NhsNumber,
        -- PROCEDURE DATE - the date relevant to the surgery; inherited by
        -- every ProcedureOpcs code emitted from this Surgery. Becomes
        -- procedure_date / procedure_datetime downstream.
        Surgery ->> '$.ProcedureDate' as ProcedureDate,
        -- PROCEDURE (OPCS) - additional OPCS-4 coded procedures recorded
        -- against the surgery. Flattens single object and array shapes
        -- into one row per code.
        unnest(
            [
                [Surgery ->> '$.ProcedureOpcs.@code'],
                Surgery ->> '$.ProcedureOpcs[*].@code'
            ],
            recursive := true
        ) as ProcedureOpcs
    from cr_surgery
    where Surgery is not null
)
select distinct
    NhsNumber,
    ProcedureOpcs,
    ProcedureDate
from cr_proc
where NhsNumber is not null
  and ProcedureOpcs is not null
  and ProcedureDate is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_date%20field%20COSD%20V9%20CR%20Procedure%20Occurrence%20Procedure%20OPCS%20mapping){: .btn }
### COSD V9 CR Procedure Occurrence Primary Procedure OPCS
Source column  `ProcedureDate`.
Converts text to dates.

* `ProcedureDate` Date relevant to the activity for the procedure date. [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

```sql
-- Selects the PRIMARY PROCEDURE (OPCS) for Colorectal (CR) cancer records
-- from COSD v9.01. Each Surgery occurrence contributes one row per
-- (patient, primary OPCS code, procedure date) triple. The Surgery
-- structure can appear either as a single object or as an array under
-- Treatment, so the JSON paths are unnested recursively to flatten both
-- shapes into individual rows.
--
-- Downstream ETL responsibilities:
--   * Cast ProcedureDate (currently varchar) to a DATE / DATETIME and
--     assign it to procedure_date / procedure_datetime.
--   * Map PrimaryProcedureOpcs (an OPCS-4 code) to the standard
--     procedure_concept_id and retain the verbatim code in
--     procedure_source_value.
--   * Resolve NhsNumber against cdm.person to obtain person_id.
--   * Set procedure_type_concept_id to a cancer registry / EHR provenance
--     concept (e.g. "EHR Cancer Registry record").
with cr as (
    select
        -- NHS NUMBER - patient identifier, mandatory; used to join to cdm.person.
        Record ->> '$.LinkagePatientId.NhsNumber.@extension'
            as NhsNumber,
        -- PRIMARY PROCEDURE (OPCS) - the OPCS-4 code of the primary
        -- patient procedure performed during the surgery; will be mapped
        -- to procedure_concept_id and retained as procedure_source_value.
        unnest([
            [Record ->> '$.Treatment.Surgery.PrimaryProcedureOpcs.@code'],
            Record ->> '$.Treatment[*].Surgery.PrimaryProcedureOpcs.@code'
        ], recursive := true) as PrimaryProcedureOpcs,
        -- PROCEDURE DATE - the date relevant to the surgery; paired
        -- one-to-one with PrimaryProcedureOpcs via lockstep unnest so
        -- each procedure code keeps its own date.
        unnest([
            [Record ->> '$.Treatment.Surgery.ProcedureDate'],
            Record ->> '$.Treatment[*].Surgery.ProcedureDate'
        ], recursive := true) as ProcedureDate
    from omop_staging.cosd_staging_901
    where type = 'CR'
)
select distinct
    NhsNumber,
    PrimaryProcedureOpcs,
    ProcedureDate
from cr
where NhsNumber is not null
  and PrimaryProcedureOpcs is not null
  and ProcedureDate is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_date%20field%20COSD%20V9%20CR%20Procedure%20Occurrence%20Primary%20Procedure%20OPCS%20mapping){: .btn }
### COSD V8 CR Procedure Occurrence Procedure OPCS
Source column  `ProcedureDate`.
Converts text to dates.

* `ProcedureDate` Date relevant to the activity for the procedure date. [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

```sql
-- Selects the non-primary PROCEDURE (OPCS) codes for Colorectal (CR)
-- cancer records from COSD v8.1. Each Surgery occurrence can carry zero,
-- one or many additional OPCS-coded procedures. To preserve the
-- one-Surgery-to-many-ProcedureOPCS relationship (and so that each
-- non-primary procedure inherits the PROCEDURE DATE of the surgery it
-- belongs to), the JSON is unnested in two stages: first to one Surgery
-- object per row, then to one ProcedureOPCS code per row within that
-- Surgery. The Surgery's ProcedureDate is carried alongside each code.
--
-- Downstream ETL responsibilities:
--   * Cast ProcedureDate (currently varchar) to DATE / DATETIME and
--     assign it to procedure_date / procedure_datetime. procedure_date is
--     mandatory in OMOP procedure_occurrence.
--   * Map ProcedureOPCS to the standard procedure_concept_id and retain
--     the verbatim code in procedure_source_value.
--   * Resolve NHSNumber against cdm.person to obtain person_id.
--   * Set procedure_type_concept_id to a cancer registry / EHR
--     provenance concept.
with cr_surgery as (
    select
        -- NHS NUMBER - patient identifier, mandatory; used to join to cdm.person.
        Record ->> '$.Core.CoreCore.CoreLinkagePatientId.NHSNumber.@extension'
            as NHSNumber,
        -- Flatten the Surgery container (CoreSurgeryAndOtherProcedures)
        -- to one object per row, whether CoreTreatment is a single object
        -- or an array.
        unnest(
            [
                [Record -> '$.Core.CoreCore.CoreTreatment.CoreSurgeryAndOtherProcedures'],
                Record -> '$.Core.CoreCore.CoreTreatment[*].CoreSurgeryAndOtherProcedures'
            ],
            recursive := true
        ) as Surgery
    from omop_staging.cosd_staging_81
    where type = 'CR'
),
cr_proc as (
    select
        NHSNumber,
        -- PROCEDURE DATE - the date relevant to the surgery; inherited by
        -- every ProcedureOPCS code emitted from this Surgery. Becomes
        -- procedure_date / procedure_datetime downstream.
        Surgery ->> '$.ProcedureDate' as ProcedureDate,
        -- PROCEDURE (OPCS) - additional OPCS-4 coded procedures recorded
        -- against the surgery. Flattens single object and array shapes
        -- into one row per code.
        unnest(
            [
                [Surgery ->> '$.ProcedureOPCS.@code'],
                Surgery ->> '$.ProcedureOPCS[*].@code'
            ],
            recursive := true
        ) as ProcedureOPCS
    from cr_surgery
    where Surgery is not null
)
select distinct
    NHSNumber,
    ProcedureOPCS,
    ProcedureDate
from cr_proc
where NHSNumber is not null
  and ProcedureOPCS is not null
  and ProcedureDate is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_date%20field%20COSD%20V8%20CR%20Procedure%20Occurrence%20Procedure%20OPCS%20mapping){: .btn }
### COSD V8 CR Procedure Occurrence Primary Procedure OPCS
Source column  `ProcedureDate`.
Converts text to dates.

* `ProcedureDate` Date relevant to the activity for the procedure date. [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

```sql
-- Selects the PRIMARY PROCEDURE (OPCS) for Colorectal (CR) cancer records
-- from COSD v8.1. Each Surgery occurrence contributes one row per
-- (patient, primary OPCS code, procedure date) triple. The Surgery
-- structure can appear either as a single object or as an array under
-- CoreTreatment, so the JSON paths are unnested recursively to flatten
-- both shapes into individual rows.
--
-- The OPCS code is the primary patient procedure carried out (one per
-- surgery); the ProcedureDate is the date relevant to that surgery and
-- is paired one-to-one with the primary OPCS code via lockstep unnest.
--
-- Downstream ETL responsibilities:
--   * Cast ProcedureDate (currently varchar) to a DATE / DATETIME and
--     assign it to procedure_date / procedure_datetime.
--   * Map PrimaryProcedureOPCS (an OPCS-4 code) to the standard
--     procedure_concept_id and retain the verbatim code in
--     procedure_source_value.
--   * Resolve NHSNumber against cdm.person to obtain person_id.
--   * Set procedure_type_concept_id to a cancer registry / EHR provenance
--     concept (e.g. "EHR Cancer Registry record").
with cr as (
    select
        -- NHS NUMBER - patient identifier, mandatory; used to join to cdm.person.
        Record ->> '$.Core.CoreCore.CoreLinkagePatientId.NHSNumber.@extension'
            as NHSNumber,
        -- PRIMARY PROCEDURE (OPCS) - the OPCS-4 code of the primary
        -- patient procedure performed during the surgery; will be mapped
        -- to procedure_concept_id and retained as procedure_source_value.
        -- The recursive unnest flattens the Surgery array (or single
        -- object) under CoreTreatment.
        unnest([
            [Record ->> '$.Core.CoreCore.CoreTreatment.CoreSurgeryAndOtherProcedures.PrimaryProcedureOPCS.@code'],
            Record ->> '$.Core.CoreCore.CoreTreatment[*].CoreSurgeryAndOtherProcedures.PrimaryProcedureOPCS.@code'
        ], recursive := true) as PrimaryProcedureOPCS,
        -- PROCEDURE DATE - the date relevant to the surgery; paired
        -- one-to-one with PrimaryProcedureOPCS via lockstep unnest so
        -- each procedure code keeps its own date. Will become
        -- procedure_date / procedure_datetime.
        unnest([
            [Record ->> '$.Core.CoreCore.CoreTreatment.CoreSurgeryAndOtherProcedures.ProcedureDate'],
            Record ->> '$.Core.CoreCore.CoreTreatment[*].CoreSurgeryAndOtherProcedures.ProcedureDate'
        ], recursive := true) as ProcedureDate
    from omop_staging.cosd_staging_81
    where type = 'CR'
)
select distinct
    NHSNumber,
    PrimaryProcedureOPCS,
    ProcedureDate
from cr
where NHSNumber is not null
  and PrimaryProcedureOPCS is not null
  and ProcedureDate is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_date%20field%20COSD%20V8%20CR%20Procedure%20Occurrence%20Primary%20Procedure%20OPCS%20mapping){: .btn }
### COSD V9 CO Procedure Occurrence Procedure Opcs
Source column  `ProcedureDate`.
Converts text to dates.

* `ProcedureDate` Date relevant to the activity for the procedure date, in CCYY-MM-DD format. Will be transformed to a date type and mapped to procedure_date in the procedure_occurrence table. Null values indicate the procedure date was not recorded. [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_date%20field%20COSD%20V9%20CO%20Procedure%20Occurrence%20Procedure%20Opcs%20mapping){: .btn }
### COSD V9 CO Procedure Occurrence Primary Procedure Opcs
Source column  `ProcedureDate`.
Converts text to dates.

* `ProcedureDate` Date relevant to the activity for the procedure date, in CCYY-MM-DD format. Will be transformed to a date type and mapped to procedure_date in the procedure_occurrence table. Null values indicate the procedure date was not recorded. [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_date%20field%20COSD%20V9%20CO%20Procedure%20Occurrence%20Primary%20Procedure%20Opcs%20mapping){: .btn }
### COSD V8 CO Procedure Occurrence Procedure OPCS
Source column  `ProcedureDate`.
Converts text to dates.

* `ProcedureDate` Date relevant to the activity for the procedure date, in CCYY-MM-DD format. Will be transformed to a date type and mapped to procedure_date in the procedure_occurrence table. Null values indicate the procedure date was not recorded. [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_date%20field%20COSD%20V8%20CO%20Procedure%20Occurrence%20Procedure%20OPCS%20mapping){: .btn }
### COSD V8 CO Procedure Occurrence Primary Procedure OPCS
Source column  `ProcedureDate`.
Converts text to dates.

* `ProcedureDate` Date relevant to the activity for the procedure date, in CCYY-MM-DD format. Will be transformed to a date type and mapped to procedure_date in the procedure_occurrence table. Null values indicate the procedure date was not recorded. [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_date%20field%20COSD%20V8%20CO%20Procedure%20Occurrence%20Primary%20Procedure%20OPCS%20mapping){: .btn }
### Cosd V9 Procedure Occurrence Procedure Opcs
Source column  `ProcedureDate`.
Converts text to dates.

* `ProcedureDate` The date, month, year and century, or any combination of these elements, that is of relevance to an ACTIVITY. [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_date%20field%20Cosd%20V9%20Procedure%20Occurrence%20Procedure%20Opcs%20mapping){: .btn }
### Cosd V9 Procedure Occurrence Primary Procedure Opcs
Source column  `ProcedureDate`.
Converts text to dates.

* `ProcedureDate` The date, month, year and century, or any combination of these elements, that is of relevance to an ACTIVITY. [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_date%20field%20Cosd%20V9%20Procedure%20Occurrence%20Primary%20Procedure%20Opcs%20mapping){: .btn }
### Cosd V8 Procedure Occurrence Procedure Opcs
Source column  `ProcedureDate`.
Converts text to dates.

* `ProcedureDate` The date, month, year and century, or any combination of these elements, that is of relevance to an ACTIVITY. [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_date%20field%20Cosd%20V8%20Procedure%20Occurrence%20Procedure%20Opcs%20mapping){: .btn }
### Cosd V8 Procedure Occurrence Primary Procedure Opcs
Source column  `ProcedureDate`.
Converts text to dates.

* `ProcedureDate` The date, month, year and century, or any combination of these elements, that is of relevance to an ACTIVITY. [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_date%20field%20Cosd%20V8%20Procedure%20Occurrence%20Primary%20Procedure%20Opcs%20mapping){: .btn }
### COSD V9 Breast Procedure Occurrence Procedure Opcs
Source column  `ProcedureDate`.
Converts text to dates.

* `ProcedureDate` The date, month, year and century, or any combination of these elements, that is of relevance to an ACTIVITY. [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_date%20field%20COSD%20V9%20Breast%20Procedure%20Occurrence%20Procedure%20Opcs%20mapping){: .btn }
### COSD V9 Breast Procedure Occurrence Primary Procedure Opcs
Source column  `ProcedureDate`.
Converts text to dates.

* `ProcedureDate` The date, month, year and century, or any combination of these elements, that is of relevance to an ACTIVITY. [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_date%20field%20COSD%20V9%20Breast%20Procedure%20Occurrence%20Primary%20Procedure%20Opcs%20mapping){: .btn }
### COSD V8 Breast Procedure Occurrence Procedure Opcs
Source column  `ProcedureDate`.
Converts text to dates.

* `ProcedureDate` The date, month, year and century, or any combination of these elements, that is of relevance to an ACTIVITY. [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_date%20field%20COSD%20V8%20Breast%20Procedure%20Occurrence%20Procedure%20Opcs%20mapping){: .btn }
### COSD V8 Breast Procedure Occurrence Primary Procedure Opcs
Source column  `ProcedureDate`.
Converts text to dates.

* `ProcedureDate` The date, month, year and century, or any combination of these elements, that is of relevance to an ACTIVITY. [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_date%20field%20COSD%20V8%20Breast%20Procedure%20Occurrence%20Primary%20Procedure%20Opcs%20mapping){: .btn }
### COSD V9 BA Procedure Occurrence Procedure Opcs Procedure Date
Source column  `ProcedureDate`.
Converts text to dates.

* `ProcedureDate` Date relevant to the activity for the procedure date. Extracted as a string in CCYY-MM-DD format and will be cast to a date type in a later ETL step to populate procedure_date. [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_date%20field%20COSD%20V9%20BA%20Procedure%20Occurrence%20Procedure%20Opcs%20Procedure%20Date%20mapping){: .btn }
### COSD V9 BA Procedure Occurrence Primary Procedure Opcs Procedure Date
Source column  `ProcedureDate`.
Converts text to dates.

* `ProcedureDate` Date relevant to the activity for the procedure date. Extracted as a string in CCYY-MM-DD format and will be cast to a date type in a later ETL step to populate procedure_date. [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_date%20field%20COSD%20V9%20BA%20Procedure%20Occurrence%20Primary%20Procedure%20Opcs%20Procedure%20Date%20mapping){: .btn }
### COSD V9 BA Procedure Occurrence Biopsy Type Procedure Date
Source column  `ProcedureDate`.
Converts text to dates.

* `ProcedureDate` Date relevant to the activity for the procedure date. Extracted as a string in CCYY-MM-DD format and will be cast to a date type in a later ETL step to populate procedure_date. Uses scalar path aligned with BiopsyType cardinality. [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_date%20field%20COSD%20V9%20BA%20Procedure%20Occurrence%20Biopsy%20Type%20Procedure%20Date%20mapping){: .btn }
### COSD V8 BA Procedure Occurrence Primary Procedure OPCS Procedure Date
Source column  `ProcedureDate`.
Converts text to dates.

* `ProcedureDate` Date relevant to the activity for the procedure date. Extracted as a string in CCYY-MM-DD format and will be cast to a date type in a later ETL step to populate procedure_date. [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20procedure_date%20field%20COSD%20V8%20BA%20Procedure%20Occurrence%20Primary%20Procedure%20OPCS%20Procedure%20Date%20mapping){: .btn }
