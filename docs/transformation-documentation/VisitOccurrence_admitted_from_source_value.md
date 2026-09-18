---
layout: default
title: admitted_from_source_value
parent: VisitOccurrence
grand_parent: Transformation Documentation
has_toc: false
---
# admitted_from_source_value
### SUS APC VisitOccurrenceWithSpell
* Value copied from `SourceofAdmissionCode`

* `SourceofAdmissionCode` Admission Source. [ADMISSION SOURCE (HOSPITAL PROVIDER SPELL)](https://www.datadictionary.nhs.uk/data_elements/admission_source__hospital_provider_spell_.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20VisitOccurrence%20table%20admitted_from_source_value%20field%20SUS%20APC%20VisitOccurrenceWithSpell%20mapping){: .btn }
### SUS AE VisitOccurrenceWithSpell
* Value copied from `SourceofAdmissionCode`

* `SourceofAdmissionCode` Admission Source. [ADMISSION SOURCE (HOSPITAL PROVIDER SPELL)](https://www.datadictionary.nhs.uk/data_elements/admission_source__hospital_provider_spell_.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20VisitOccurrence%20table%20admitted_from_source_value%20field%20SUS%20AE%20VisitOccurrenceWithSpell%20mapping){: .btn }
