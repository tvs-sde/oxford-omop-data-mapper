---
layout: default
title: admitted_from_source_value
parent: VisitDetail
grand_parent: Transformation Documentation
has_toc: false
---
# admitted_from_source_value
### Sus Inptatient VisitDetails
* Value copied from `SourceofAdmissionCode`

* `SourceofAdmissionCode` Admission Source. [ADMISSION SOURCE (HOSPITAL PROVIDER SPELL)](https://www.datadictionary.nhs.uk/data_elements/admission_source__hospital_provider_spell_.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20VisitDetail%20table%20admitted_from_source_value%20field%20Sus%20Inptatient%20VisitDetails%20mapping){: .btn }
### Sus Inptatient VisitDetails
* Value copied from `SourceofAdmissionCode`

* `SourceofAdmissionCode` Admission Source. [ADMISSION SOURCE (HOSPITAL PROVIDER SPELL)](https://www.datadictionary.nhs.uk/data_elements/admission_source__hospital_provider_spell_.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20VisitDetail%20table%20admitted_from_source_value%20field%20Sus%20Inptatient%20VisitDetails%20mapping){: .btn }
