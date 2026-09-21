---
layout: default
title: HospitalProviderSpellNumber
parent: VisitDetail
grand_parent: Transformation Documentation
has_toc: false
---
# HospitalProviderSpellNumber
### Sus Outpatient VisitDetails
* Value copied from `SUSgeneratedspellID`

* `SUSgeneratedspellID` System generated value spell id, this id is consistent across all records belonging to the same spell. []()

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20VisitDetail%20table%20HospitalProviderSpellNumber%20field%20Sus%20Outpatient%20VisitDetails%20mapping){: .btn }
### Sus Critical Care VisitDetails
* Value copied from `HospitalProviderSpellNumber`

* `HospitalProviderSpellNumber` CDS specific hospital spell number that binds many episodes together. [HOSPITAL PROVIDER SPELL NUMBER](https://www.datadictionary.nhs.uk/data_elements/hospital_provider_spell_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20VisitDetail%20table%20HospitalProviderSpellNumber%20field%20Sus%20Critical%20Care%20VisitDetails%20mapping){: .btn }
### Sus Inptatient VisitDetails
* Value copied from `HospitalProviderSpellNumber`

* `HospitalProviderSpellNumber` CDS specific hospital spell number that binds many episodes together. [HOSPITAL PROVIDER SPELL NUMBER](https://www.datadictionary.nhs.uk/data_elements/hospital_provider_spell_number.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20VisitDetail%20table%20HospitalProviderSpellNumber%20field%20Sus%20Inptatient%20VisitDetails%20mapping){: .btn }
### Sus Inptatient VisitDetails
* Value copied from `AEAttendanceNumber`

* `AEAttendanceNumber`  [A and E ATTENDANCE NUMBER (Retired)]()

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20VisitDetail%20table%20HospitalProviderSpellNumber%20field%20Sus%20Inptatient%20VisitDetails%20mapping){: .btn }
