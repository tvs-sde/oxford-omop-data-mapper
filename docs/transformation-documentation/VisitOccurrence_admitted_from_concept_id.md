---
layout: default
title: admitted_from_concept_id
parent: VisitOccurrence
grand_parent: Transformation Documentation
has_toc: false
---
# admitted_from_concept_id
### SUS APC VisitOccurrenceWithSpell
Source column  `SourceofAdmissionCode`.
Lookup admission source concept.


|SourceofAdmissionCode|admitted_from_concept_id|notes|
|------|-----|-----|
|1|38004353|Ambulance|
|2||No mapping possible|
|19|581476|Home Visit|
|29|8602|Temporary Lodging|
|37|38003619|Prison / Correctional Facility|
|40|38003619|Prison / Correctional Facility|
|42|38003619|Prison / Correctional Facility|
|49|38004284|Psychiatric Hospital|
|51|8717|Inpatient Hospital|
|52|8650|Birthing Center|
|53|8976|Psychiatric Residential Treatment Center|
|55|8863|Skilled Nursing Facility|
|56|38004306|Custodial Care Facility|
|66|38004205|Foster Care Agency|
|79|8650|Birthing Center|
|87|8717|Inpatient Hospital|
|88|8546|Hospice|
|98||No mapping possible|
|99||No mapping possible|

Notes
* [Admission Source](https://www.datadictionary.nhs.uk/data_elements/admission_source__hospital_provider_spell_.html)
* [Admission Source A&E](https://archive.datadictionary.nhs.uk/DD%20Release%20September%202020/attributes/accident_and_emergency_arrival_mode.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20VisitOccurrence%20table%20admitted_from_concept_id%20field%20SUS%20APC%20VisitOccurrenceWithSpell%20mapping){: .btn }
### SUS AE VisitOccurrenceWithSpell
Source column  `SourceofAdmissionCode`.
Lookup admission source concept.


|SourceofAdmissionCode|admitted_from_concept_id|notes|
|------|-----|-----|
|1|38004353|Ambulance|
|2||No mapping possible|
|19|581476|Home Visit|
|29|8602|Temporary Lodging|
|37|38003619|Prison / Correctional Facility|
|40|38003619|Prison / Correctional Facility|
|42|38003619|Prison / Correctional Facility|
|49|38004284|Psychiatric Hospital|
|51|8717|Inpatient Hospital|
|52|8650|Birthing Center|
|53|8976|Psychiatric Residential Treatment Center|
|55|8863|Skilled Nursing Facility|
|56|38004306|Custodial Care Facility|
|66|38004205|Foster Care Agency|
|79|8650|Birthing Center|
|87|8717|Inpatient Hospital|
|88|8546|Hospice|
|98||No mapping possible|
|99||No mapping possible|

Notes
* [Admission Source](https://www.datadictionary.nhs.uk/data_elements/admission_source__hospital_provider_spell_.html)
* [Admission Source A&E](https://archive.datadictionary.nhs.uk/DD%20Release%20September%202020/attributes/accident_and_emergency_arrival_mode.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20VisitOccurrence%20table%20admitted_from_concept_id%20field%20SUS%20AE%20VisitOccurrenceWithSpell%20mapping){: .btn }
