---
layout: default
title: HospitalProviderSpellNumber
parent: VisitOccurrence
grand_parent: Transformation Documentation
has_toc: false
---
# HospitalProviderSpellNumber
### SUS OP VisitOccurrenceWithSpell
* Value copied from `SUSgeneratedspellID`

* `SUSgeneratedspellID` CDS specific hospital spell number that binds many episodes together. [HOSPITAL PROVIDER SPELL NUMBER](https://www.datadictionary.nhs.uk/data_elements/hospital_provider_spell_number.html)

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
	where op.UpdateType = 9
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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20VisitOccurrence%20table%20HospitalProviderSpellNumber%20field%20SUS%20OP%20VisitOccurrenceWithSpell%20mapping){: .btn }
### SUS APC VisitOccurrenceWithSpell
* Value copied from `HospitalProviderSpellNumber`

* `HospitalProviderSpellNumber` CDS specific hospital spell number that binds many episodes together. [HOSPITAL PROVIDER SPELL NUMBER](https://www.datadictionary.nhs.uk/data_elements/hospital_provider_spell_number.html)

```sql
	with records as (
		select
			max(apc.NHSNumber) as NHSNumber,
			apc.HospitalProviderSpellNumber,
	
			coalesce(min(apc.StartDateConsultantEpisode), min(apc.StartDateHospitalProviderSpell), min(apc.CDSActivityDate)) as VisitStartDate,
			coalesce(min(apc.StartTimeEpisode), min(apc.StartTimeHospitalProviderSpell), '000000') as VisitStartTime,
			coalesce(max(apc.EndDateConsultantEpisode), max(apc.DischargeDateFromHospitalProviderSpell), max(apc.CDSActivityDate)) as VisitEndDate,
			coalesce(max(apc.EndTimeEpisode), max(apc.DischargeTimeHospitalProviderSpell), '000000') as VisitEndTime,
	
			max(apc.SourceOfAdmissionHospitalProviderSpell) as SourceofAdmissionCode,
			max(apc.DischargeDestinationHospitalProviderSpell) as DischargeDestinationCode
	
		from omop_staging.sus_APC apc
		where apc.NHSNumber is not null
		group by HospitalProviderSpellNumber
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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20VisitOccurrence%20table%20HospitalProviderSpellNumber%20field%20SUS%20APC%20VisitOccurrenceWithSpell%20mapping){: .btn }
### SUS AE VisitOccurrenceWithSpell
* Value copied from `AEAttendanceNumber`

* `AEAttendanceNumber` ATTENDANCE IDENTIFIER is a sequential number or time of day used to enable an attendance to be uniquely identified. [ATTENDANCE IDENTIFIER](https://www.datadictionary.nhs.uk/data_elements/attendance_identifier.html)

```sql
		with records as (
			select  
				distinct
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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20VisitOccurrence%20table%20HospitalProviderSpellNumber%20field%20SUS%20AE%20VisitOccurrenceWithSpell%20mapping){: .btn }
