---
layout: default
title: visit_detail_start_datetime
parent: VisitDetail
grand_parent: Transformation Documentation
has_toc: false
---
# visit_detail_start_datetime
### Sus Outpatient VisitDetails
Source columns  `VisitStartDate`, `VisitStartTime`.
Combines a date with a time of day.

* `VisitStartDate` Start date of the episode, if exists, else the start date of the spell. [CDS ACTIVITY DATE](https://www.datadictionary.nhs.uk/data_elements/cds_activity_date.html), [START DATE (HOSPITAL PROVIDER SPELL)](https://www.datadictionary.nhs.uk/data_elements/start_date__hospital_provider_spell_.html), [START DATE (EPISODE)](https://www.datadictionary.nhs.uk/data_elements/start_date__episode_.html)

* `VisitStartTime` Start time of the episode, if exists, else midnight. [START TIME (HOSPITAL PROVIDER SPELL)](https://www.datadictionary.nhs.uk/data_elements/start_time__hospital_provider_spell_.html), [START TIME (EPISODE)](https://www.datadictionary.nhs.uk/data_elements/start_time__episode_.html)

```sql
with results as
(
	select  
		distinct
			op.NHSNumber,
			op.SUSgeneratedspellID,
			coalesce(op.AppointmentDate, op.CDSActivityDate) as VisitStartDate,  -- visit_start_date
			coalesce(op.AppointmentTime, '000000') as VisitStartTime,  -- visit_start_time
			coalesce(op.AppointmentDate, op.CDSActivityDate) as VisitEndDate,
			null as VisitEndTime
	from omop_staging.sus_OP op
	where op.UpdateType = 9   -- New/Modification     (1 = Delete)
		and op.NHSNumber is not null
		and AttendedorDidNotAttend in ('5','6')
)
select *
from results
order by 
	NHSNumber,
	SUSgeneratedspellID,
	VisitStartDate, 
	VisitStartTime,
	VisitEndDate,
	VisitEndTime
		
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20VisitDetail%20table%20visit_detail_start_datetime%20field%20Sus%20Outpatient%20VisitDetails%20mapping){: .btn }
### Sus Critical Care VisitDetails
Source columns  `VisitStartDate`, `VisitStartTime`.
Combines a date with a time of day.

* `VisitStartDate` Start date of the visit [CRITICAL CARE START DATE](https://www.datadictionary.nhs.uk/data_elements/critical_care_start_date.html)

* `VisitStartTime` Start time of the visit, if exists, else midnight. [CRITICAL CARE START TIME](https://www.datadictionary.nhs.uk/data_elements/critical_care_start_time.html)

```sql
with results as (
	select
		distinct
			apc.NHSNumber,
			apc.HospitalProviderSpellNumber,
			cc.CriticalCareStartDate as VisitStartDate,
			coalesce(cc.CriticalCareStartTime, '00:00:00') as VisitStartTime,
			coalesce(cc.CriticalCarePeriodDischargeDate, cc.EventDate) as VisitEndDate,
			coalesce(cc.CriticalCarePeriodDischargeTime, '00:00:00') as VisitEndTime
	from omop_staging.sus_CCMDS cc
	inner join omop_staging.sus_APC apc on cc.GeneratedRecordID = apc.GeneratedRecordIdentifier
	where apc.NHSNumber is not null
)
select *
from results
order by
	NHSNumber,
	HospitalProviderSpellNumber,
	VisitStartDate,
	VisitStartTime,
	VisitEndDate,
	VisitEndTime

	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20VisitDetail%20table%20visit_detail_start_datetime%20field%20Sus%20Critical%20Care%20VisitDetails%20mapping){: .btn }
### Sus Inptatient VisitDetails
Source columns  `VisitStartDate`, `VisitStartTime`.
Combines a date with a time of day.

* `VisitStartDate` Start date of the episode, if exists, else the start date of the spell. [CDS ACTIVITY DATE](https://www.datadictionary.nhs.uk/data_elements/cds_activity_date.html), [START DATE (HOSPITAL PROVIDER SPELL)](https://www.datadictionary.nhs.uk/data_elements/start_date__hospital_provider_spell_.html), [START DATE (EPISODE)](https://www.datadictionary.nhs.uk/data_elements/start_date__episode_.html)

* `VisitStartTime` Start time of the episode, if exists, else midnight. [START TIME (HOSPITAL PROVIDER SPELL)](https://www.datadictionary.nhs.uk/data_elements/start_time__hospital_provider_spell_.html), [START TIME (EPISODE)](https://www.datadictionary.nhs.uk/data_elements/start_time__episode_.html)

```sql
		with records as (
			select
				apc.NHSNumber,
				apc.HospitalProviderSpellNumber,
		
				coalesce(apc.StartDateConsultantEpisode, apc.StartDateHospitalProviderSpell, apc.CDSActivityDate) as VisitStartDate,
				coalesce(apc.StartTimeEpisode, apc.StartTimeHospitalProviderSpell, '000000') as VisitStartTime,
				coalesce(apc.EndDateConsultantEpisode, apc.DischargeDateFromHospitalProviderSpell, apc.CDSActivityDate) as VisitEndDate,
				coalesce(apc.EndTimeEpisode, apc.DischargeTimeHospitalProviderSpell, '000000') as VisitEndTime,
		
				apc.SourceOfAdmissionHospitalProviderSpell as SourceofAdmissionCode,
				apc.DischargeDestinationHospitalProviderSpell as DischargeDestinationCode
		
			from omop_staging.sus_APC apc
			where apc.NHSNumber is not null
		)
		select *
		from records
		order by 
			NHSNumber, 
			HospitalProviderSpellNumber, 
			VisitStartDate, 
			VisitStartTime, 
			VisitEndDate, 
			VisitEndTime, 
			SourceofAdmissionCode, 
			DischargeDestinationCode

	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20VisitDetail%20table%20visit_detail_start_datetime%20field%20Sus%20Inptatient%20VisitDetails%20mapping){: .btn }
### Sus Inptatient VisitDetails
Source columns  `VisitStartDate`, `VisitStartTime`.
Combines a date with a time of day.

* `VisitStartDate` Start date of the episode, if exists, else the start date of the spell. [CDS ACTIVITY DATE](https://www.datadictionary.nhs.uk/data_elements/cds_activity_date.html), [START DATE (HOSPITAL PROVIDER SPELL)](https://www.datadictionary.nhs.uk/data_elements/start_date__hospital_provider_spell_.html), [START DATE (EPISODE)](https://www.datadictionary.nhs.uk/data_elements/start_date__episode_.html)

* `VisitStartTime` Start time of the episode, if exists, else midnight. [START TIME (HOSPITAL PROVIDER SPELL)](https://www.datadictionary.nhs.uk/data_elements/start_time__hospital_provider_spell_.html), [START TIME (EPISODE)](https://www.datadictionary.nhs.uk/data_elements/start_time__episode_.html)

```sql
		with records as (
			select  
				ae.NHSNumber,
				ae.AEAttendanceNumber,
				coalesce(ae.ArrivalDate, ae.CDSActivityDate) as VisitStartDate,
				coalesce(ae.ArrivalTime, '000000') as VisitStartTime,
				coalesce(ae.AEDepartureDate, ae.AEAttendanceConclusionDate, ae.ArrivalDate, ae.CDSActivityDate) as VisitEndDate,
				coalesce(ae.AEDepartureTime, ae.AEAttendanceConclusionTime, '000000') as VisitEndTime,
				ae.AEArrivalMode as SourceofAdmissionCode,
				ae.AEAttendanceDisposal as DischargeDestinationCode
			from omop_staging.sus_AE ae
			where ae.NHSNumber is not null
		)
		select *
		from records
		order by 
			NHSNumber, 
			AEAttendanceNumber, 
			VisitStartDate, 
			VisitStartTime, 
			VisitEndDate, 
			VisitEndTime, 
			SourceofAdmissionCode, 
			DischargeDestinationCode

	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20VisitDetail%20table%20visit_detail_start_datetime%20field%20Sus%20Inptatient%20VisitDetails%20mapping){: .btn }
### Oxford Visit Details
Source column  `EventDate`.
Converts text to dates.

* `EventDate` Event date 

```sql
select
	GPEventsPrimaryKey,
	d.NHSNumber,
	e.EventDate
from omop_staging.oxford_gp_event e
	inner join omop_staging.oxford_gp_demographic d
		on e.PatientIdentifier = d.PatientIdentifier
order by
	d.NHSNumber,
	e.EventDate
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20VisitDetail%20table%20visit_detail_start_datetime%20field%20Oxford%20Visit%20Details%20mapping){: .btn }
