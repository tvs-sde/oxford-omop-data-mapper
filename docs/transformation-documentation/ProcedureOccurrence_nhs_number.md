---
layout: default
title: nhs_number
parent: ProcedureOccurrence
grand_parent: Transformation Documentation
has_toc: false
---
# nhs_number
### SUS Outpatient Procedure Occurrence
* Value copied from `NHSNumber`

* `NHSNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20nhs_number%20field%20SUS%20Outpatient%20Procedure%20Occurrence%20mapping){: .btn }
### SUS CCMDS Procedure Occurrence
* Value copied from `NHSNumber`

* `NHSNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20nhs_number%20field%20SUS%20CCMDS%20Procedure%20Occurrence%20mapping){: .btn }
### SUS APC Procedure Occurrence
* Value copied from `NHSNumber`

* `NHSNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20nhs_number%20field%20SUS%20APC%20Procedure%20Occurrence%20mapping){: .btn }
### SUS AE Procedure Occurrence
* Value copied from `NHSNumber`

* `NHSNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20nhs_number%20field%20SUS%20AE%20Procedure%20Occurrence%20mapping){: .btn }
### Rtds Procedure Occurrence
* Value copied from `PatientId`

* `PatientId` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20nhs_number%20field%20Rtds%20Procedure%20Occurrence%20mapping){: .btn }
### Oxford Procedure Occurrence
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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20nhs_number%20field%20Oxford%20Procedure%20Occurrence%20mapping){: .btn }
### COSD V9 UR Procedure Occurrence Procedure Opcs
* Value copied from `NhsNumber`

* `NhsNumber` The unique NHS NUMBER allocated to every patient registered with the NHS. [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

```sql
-- Extracts secondary/other procedure OPCS codes from treatment surgery for the Urological cancer area (COSD v9).
-- Treatment is a repeating group and ProcedureOpcs can also repeat within a treatment, so unnest is required.
-- ProcedureOpcs identifies patient procedures other than the primary procedure (OPCS-4 code).
-- ProcedureDate is the date of the procedure in CCYY-MM-DD string format, to be cast to date downstream.
-- The OPCS code will be mapped to a standard OMOP procedure_concept_id in a later ETL step.
with ur as (
    select distinct
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
        unnest ([[Record ->> '$.Treatment.Surgery.ProcedureDate'], Record ->> '$.Treatment[*].Surgery.ProcedureDate'], recursive := true) as ProcedureDate,
        unnest ([[Record ->> '$.Treatment.Surgery.ProcedureOpcs.@code'], Record ->> '$.Treatment[*].Surgery.ProcedureOpcs.@code'], recursive := true) as ProcedureOpcs
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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20nhs_number%20field%20COSD%20V9%20UR%20Procedure%20Occurrence%20Procedure%20Opcs%20mapping){: .btn }
### COSD V9 UR Procedure Occurrence Primary Procedure Opcs
* Value copied from `NhsNumber`

* `NhsNumber` The unique NHS NUMBER allocated to every patient registered with the NHS. [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

```sql
-- Extracts primary procedure OPCS codes from treatment surgery for the Urological cancer area (COSD v9).
-- Treatment is a repeating group, so unnest is required to normalise each treatment entry.
-- PrimaryProcedureOpcs identifies the primary patient procedure carried out (OPCS-4 code).
-- ProcedureDate is the date of the procedure in CCYY-MM-DD string format, to be cast to date downstream.
-- The OPCS code will be mapped to a standard OMOP procedure_concept_id in a later ETL step.
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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20nhs_number%20field%20COSD%20V9%20UR%20Procedure%20Occurrence%20Primary%20Procedure%20Opcs%20mapping){: .btn }
### COSD V9 UR Procedure Occurrence Diagnostic Procedure Snomed Ct
* Value copied from `NhsNumber`

* `NhsNumber` The unique NHS NUMBER allocated to every patient registered with the NHS. [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

```sql
-- Extracts diagnostic procedure SNOMED CT codes for the Urological cancer area (COSD v9).
-- These represent diagnostic procedures carried out, identified by SNOMED CT concept ID.
-- The SNOMED CT code will be mapped to a standard OMOP procedure_concept_id in a later ETL step.
-- DiagnosticProcedureDate is a string in CCYY-MM-DD format and will be cast to a date type downstream.
select distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
    Record ->> '$.DiagnosticProcedures.DiagnosticProcedureDate' as DiagnosticProcedureDate,
    Record ->> '$.DiagnosticProcedures.DiagnosticProcedureSnomedCt.@code' as DiagnosticProcedureSnomedCt
from omop_staging.cosd_staging_901
where type = 'UR'
  and NhsNumber is not null
  and DiagnosticProcedureSnomedCt is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20nhs_number%20field%20COSD%20V9%20UR%20Procedure%20Occurrence%20Diagnostic%20Procedure%20Snomed%20Ct%20mapping){: .btn }
### COSD V9 UR Procedure Occurrence Diagnostic Procedure Opcs
* Value copied from `NhsNumber`

* `NhsNumber` The unique NHS NUMBER allocated to every patient registered with the NHS. [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

```sql
-- Extracts diagnostic procedure OPCS codes for the Urological cancer area (COSD v9).
-- These represent diagnostic procedures carried out, identified by OPCS code.
-- The OPCS code will be mapped to a standard OMOP procedure_concept_id in a later ETL step.
-- DiagnosticProcedureDate is a string in CCYY-MM-DD format and will be cast to a date type downstream.
select distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
    Record ->> '$.DiagnosticProcedures.DiagnosticProcedureDate' as DiagnosticProcedureDate,
    Record ->> '$.DiagnosticProcedures.DiagnosticProcedureOpcs.@code' as DiagnosticProcedureOpcs
from omop_staging.cosd_staging_901
where type = 'UR'
  and NhsNumber is not null
  and DiagnosticProcedureOpcs is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20nhs_number%20field%20COSD%20V9%20UR%20Procedure%20Occurrence%20Diagnostic%20Procedure%20Opcs%20mapping){: .btn }
### COSD V8 UR Procedure Occurrence Procedure OPCS
* Value copied from `NHSNumber`

* `NHSNumber` The unique NHS NUMBER allocated to every patient registered with the NHS. [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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
    from omop_staging.cosd_staging_81
    where type = 'UR'
)
select distinct
    NHSNumber,
    ProcedureDate,
    ProcedureOPCS
from ur
where NHSNumber is not null
  and ProcedureOPCS is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20nhs_number%20field%20COSD%20V8%20UR%20Procedure%20Occurrence%20Procedure%20OPCS%20mapping){: .btn }
### COSD V8 UR Procedure Occurrence Primary Procedure OPCS
* Value copied from `NHSNumber`

* `NHSNumber` The unique NHS NUMBER allocated to every patient registered with the NHS. [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

```sql
-- Extracts primary procedure OPCS codes from treatment surgery for the Urological cancer area (COSD v8).
-- UrologicalCoreTreatment is a repeating group, so unnest is required to normalise each treatment entry.
-- PrimaryProcedureOPCS identifies the primary patient procedure carried out (OPCS-4 code).
-- ProcedureDate is the date of the procedure in CCYY-MM-DD string format, to be cast to date downstream.
-- The OPCS code will be mapped to a standard OMOP procedure_concept_id in a later ETL step.
with ur as (
    select distinct
        Record ->> '$.Urological.UrologicalCore.UrologicalCoreLinkagePatientId.NHSNumber.@extension' as NHSNumber,
        unnest ([[Record ->> '$.Urological.UrologicalCore.UrologicalCoreTreatment.UrologicalCoreSurgeryAndOtherProcedures.ProcedureDate'], Record ->> '$.Urological.UrologicalCore.UrologicalCoreTreatment[*].UrologicalCoreSurgeryAndOtherProcedures.ProcedureDate'], recursive := true) as ProcedureDate,
        unnest ([[Record ->> '$.Urological.UrologicalCore.UrologicalCoreTreatment.UrologicalCoreSurgeryAndOtherProcedures.PrimaryProcedureOPCS.@code'], Record ->> '$.Urological.UrologicalCore.UrologicalCoreTreatment[*].UrologicalCoreSurgeryAndOtherProcedures.PrimaryProcedureOPCS.@code'], recursive := true) as PrimaryProcedureOPCS
    from omop_staging.cosd_staging_81
    where type = 'UR'
)
select distinct
    NHSNumber,
    ProcedureDate,
    PrimaryProcedureOPCS
from ur
where NHSNumber is not null
  and PrimaryProcedureOPCS is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20nhs_number%20field%20COSD%20V8%20UR%20Procedure%20Occurrence%20Primary%20Procedure%20OPCS%20mapping){: .btn }
### CosdV9LungProcedureOccurrenceRelapseMethodOfDetection
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20nhs_number%20field%20CosdV9LungProcedureOccurrenceRelapseMethodOfDetection%20mapping){: .btn }
### Cosd V9 Lung Procedure Occurrence Procedure Opcs
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20nhs_number%20field%20Cosd%20V9%20Lung%20Procedure%20Occurrence%20Procedure%20Opcs%20mapping){: .btn }
### Cosd V9 Lung Procedure Occurrence Primary Procedure Opcs
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20nhs_number%20field%20Cosd%20V9%20Lung%20Procedure%20Occurrence%20Primary%20Procedure%20Opcs%20mapping){: .btn }
### CosdV8LungProcedureOccurrenceRelapseMethodOfDetection
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20nhs_number%20field%20CosdV8LungProcedureOccurrenceRelapseMethodOfDetection%20mapping){: .btn }
### Cosd V8 Lung Procedure Occurrence Procedure Opcs
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20nhs_number%20field%20Cosd%20V8%20Lung%20Procedure%20Occurrence%20Procedure%20Opcs%20mapping){: .btn }
### COSD V8 Lung Procedure Occurrence Primary Procedure Opcs
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20nhs_number%20field%20COSD%20V8%20Lung%20Procedure%20Occurrence%20Primary%20Procedure%20Opcs%20mapping){: .btn }
### Cosd V9 Procedure Occurrence Procedure Opcs
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20nhs_number%20field%20Cosd%20V9%20Procedure%20Occurrence%20Procedure%20Opcs%20mapping){: .btn }
### Cosd V9 Procedure Occurrence Primary Procedure Opcs
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20nhs_number%20field%20Cosd%20V9%20Procedure%20Occurrence%20Primary%20Procedure%20Opcs%20mapping){: .btn }
### Cosd V8 Procedure Occurrence Procedure Opcs
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20nhs_number%20field%20Cosd%20V8%20Procedure%20Occurrence%20Procedure%20Opcs%20mapping){: .btn }
### Cosd V8 Procedure Occurrence Primary Procedure Opcs
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20nhs_number%20field%20Cosd%20V8%20Procedure%20Occurrence%20Primary%20Procedure%20Opcs%20mapping){: .btn }
### COSD V9 Breast Procedure Occurrence Procedure Opcs
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20nhs_number%20field%20COSD%20V9%20Breast%20Procedure%20Occurrence%20Procedure%20Opcs%20mapping){: .btn }
### COSD V9 Breast Procedure Occurrence Primary Procedure Opcs
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20nhs_number%20field%20COSD%20V9%20Breast%20Procedure%20Occurrence%20Primary%20Procedure%20Opcs%20mapping){: .btn }
### COSD V8 Breast Procedure Occurrence Procedure Opcs
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20nhs_number%20field%20COSD%20V8%20Breast%20Procedure%20Occurrence%20Procedure%20Opcs%20mapping){: .btn }
### COSD V8 Breast Procedure Occurrence Primary Procedure Opcs
* Value copied from `NhsNumber`

* `NhsNumber` Patient NHS Number [NHS NUMBER](https://www.datadictionary.nhs.uk/data_elements/nhs_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ProcedureOccurrence%20table%20nhs_number%20field%20COSD%20V8%20Breast%20Procedure%20Occurrence%20Primary%20Procedure%20Opcs%20mapping){: .btn }
