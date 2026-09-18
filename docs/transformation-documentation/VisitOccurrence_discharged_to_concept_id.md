---
layout: default
title: discharged_to_concept_id
parent: VisitOccurrence
grand_parent: Transformation Documentation
has_toc: false
---
# discharged_to_concept_id
### SUS APC VisitOccurrenceWithSpell
Source column  `DischargeDestinationCode`.
Lookup discharge destination concept.


|DischargeDestinationCode|discharged_to_concept_id|notes|
|------|-----|-----|
|19|32759|Home Isolation|
|29|8602|Temporary Lodging|
|30|38004284|Psychiatric Hospital|
|37|38003619|Prison / Correctional Facility|
|38|38003619|Prison / Correctional Facility|
|48|38004284|Psychiatric Hospital|
|49|38004284|Psychiatric Hospital|
|50|8971|Inpatient Psychiatric Facility|
|51|8717|Inpatient Hospital|
|52|8650|Birthing Center|
|53|8976|Psychiatric Residential Treatment Center|
|54|8676|Nursing Facility|
|65|8676|Nursing Facility|
|66|38004205|Foster Care Agency|
|79|8650|Birthing Center|
|84|8971|Inpatient Psychiatric Facility|
|85|8676|Nursing Facility|
|87|8717|Inpatient Hospital|
|88|8546|Hospice|
|98||No mapping possible|
|99||No mapping possible|

Notes
* [Discharge Destination](https://www.datadictionary.nhs.uk/data_elements/discharge_destination_code__hospital_provider_spell_.html)
* [Discharge Destination](https://archive.datadictionary.nhs.uk/DD%20Release%20July%202024/attributes/discharge_destination.html)

* `DischargeDestinationCode` Discharge Destination Code [DISCHARGE DESTINATION CODE (HOSPITAL PROVIDER SPELL)](https://www.datadictionary.nhs.uk/data_elements/discharge_destination_code__hospital_provider_spell_.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20VisitOccurrence%20table%20discharged_to_concept_id%20field%20SUS%20APC%20VisitOccurrenceWithSpell%20mapping){: .btn }
### SUS AE VisitOccurrenceWithSpell
Source column  `DischargeDestinationCode`.
Lookup discharge destination concept for A&E.


|DischargeDestinationCode|discharged_to_concept_id|notes|
|------|-----|-----|
|01|8717|In Patient Hospital|
|02|38004453|Family Practice|
|03|32759|Home Isolation|
|04|8870|Emergency Room - Hospital|
|05|8870|Emergency Room - Hospital|
|06|8756|Out Patient Hospital|
|07||No mapping possible|
|10||No mapping possible|
|11||No mapping possible|
|12||No mapping possible|
|13||No mapping possible|
|14||No mapping possible|

Notes
* [Discharge Destination](https://www.datadictionary.nhs.uk/data_elements/discharge_destination_code__hospital_provider_spell_.html)
* [Discharge Destination A&E](https://archive.datadictionary.nhs.uk/DD%20Release%20September%202020/data_elements/accident_and_emergency_attendance_disposal_code.html)

* `DischargeDestinationCode` Discharge Destination Code [DISCHARGE DESTINATION CODE (HOSPITAL PROVIDER SPELL)](https://www.datadictionary.nhs.uk/data_elements/discharge_destination_code__hospital_provider_spell_.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20VisitOccurrence%20table%20discharged_to_concept_id%20field%20SUS%20AE%20VisitOccurrenceWithSpell%20mapping){: .btn }
