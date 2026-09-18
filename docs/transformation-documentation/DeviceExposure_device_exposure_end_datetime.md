---
layout: default
title: device_exposure_end_datetime
parent: DeviceExposure
grand_parent: Transformation Documentation
has_toc: false
---
# device_exposure_end_datetime
### SUS OP Device Exposure
Source columns  `AppointmentDate`, `AppointmentTime`.
Combines a date with a time of day.

* `AppointmentDate` Appointment Date. [APPOINTMENT DATE](https://www.datadictionary.nhs.uk/data_elements/appointment_date.html)

* `AppointmentTime` Appointment Time. [APPOINTMENT TIME](https://www.datadictionary.nhs.uk/data_elements/appointment_time.html)

```sql
	select
		distinct
		op.SUSgeneratedspellID,
		op.NHSNumber,
		op.AppointmentDate,
		op.AppointmentTime,
		p.ProcedureOPCS as PrimaryProcedure
	from omop_staging.sus_OP op
		inner join omop_staging.sus_OP_OPCSProcedure p
		on op.MessageId = p.MessageId
	where NHSNumber is not null
		and AttendedorDidNotAttend in ('5','6')
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20DeviceExposure%20table%20device_exposure_end_datetime%20field%20SUS%20OP%20Device%20Exposure%20mapping){: .btn }
### SUS CCMDS Device Exposure
Source columns  `DeviceExposureEndDate`, `DeviceExposureEndTime`.
Combines a date with a time of day.

* `DeviceExposureEndDate` End date of the Device, if exists, else the event date [CRITICAL CARE PERIOD DISCHARGE DATE](), [EVENT DATE]()

* `DeviceExposureEndTime` End time of the Procedure, if exists, else midnight. [CRITICAL CARE PERIOD DISCHARGE TIME]()

```sql
		select distinct
				apc.NHSNumber,
				apc.HospitalProviderSpellNumber,
				cc.CriticalCareStartDate as DeviceExposureStartDate,
				coalesce(cc.CriticalCareStartTime, '00:00:00') as DeviceExposureStartTime,
				coalesce(cc.CriticalCarePeriodDischargeDate, cc.EventDate) as DeviceExposureEndDate,
				coalesce(cc.CriticalCarePeriodDischargeTime, '00:00:00') as DeviceExposureEndTime,
				d.CriticalCareActivityCode as CriticalCareActivityCode
		from omop_staging.sus_CCMDS_CriticalCareActivityCode d
		inner join omop_staging.sus_CCMDS cc on d.MessageId = cc.MessageId
		inner join omop_staging.sus_APC apc on cc.GeneratedRecordID = apc.GeneratedRecordIdentifier
		where apc.NHSNumber is not null
		and d.CriticalCareActivityCode not in('3','4','6','8','10','12','15','21','22','23','24','25','27','28','29','50','57','58','64','65','66','67','68','69','70','71','72','74','82','83','87','99')

	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20DeviceExposure%20table%20device_exposure_end_datetime%20field%20SUS%20CCMDS%20Device%20Exposure%20mapping){: .btn }
### SUS APC Procedure Occurrence
Source column  `PrimaryProcedureDate`.
Converts text to dates.

* `PrimaryProcedureDate` Procedure Date. [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

```sql
select
	distinct
		apc.HospitalProviderSpellNumber,
		apc.NHSNumber,
		p.ProcedureDateOPCS as PrimaryProcedureDate,
		p.ProcedureOPCS as PrimaryProcedure
from omop_staging.sus_APC apc
	inner join omop_staging.sus_OPCSProcedure p
		on apc.MessageId = p.MessageId
where NHSNumber is not null
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20DeviceExposure%20table%20device_exposure_end_datetime%20field%20SUS%20APC%20Procedure%20Occurrence%20mapping){: .btn }
### SUS AE Procedure Device Exposure
Source column  `PrimaryProcedureDate`.
Converts text to dates.

* `PrimaryProcedureDate` Procedure Date. [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

```sql
	select
		distinct
			ae.AEAttendanceNumber,
			ae.NHSNumber,
			ae.CDSActivityDate as PrimaryProcedureDate,
			p.AccidentAndEmergencyTreatment as PrimaryProcedure
	from omop_staging.sus_AE ae
		inner join omop_staging.sus_AE_treatment p
			on AE.MessageId = p.MessageId
	where NHSNumber is not null
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20DeviceExposure%20table%20device_exposure_end_datetime%20field%20SUS%20AE%20Procedure%20Device%20Exposure%20mapping){: .btn }
### SUS AE Investigation Device Exposure
Source columns  `EndDate`, `EndTime`.
Combines a date with a time of day.

* `EndDate` The latest episode end date for the spell, or the latest activity date if none are specified. [CDS ACTIVITY DATE](https://www.datadictionary.nhs.uk/data_elements/cds_activity_date.html), [END DATE (EPISODE)](https://www.datadictionary.nhs.uk/data_elements/end_date__episode_.html)

* `EndTime` The latest episode end time for the spell, or midnight if none are specified. [END TIME (EPISODE)](https://www.datadictionary.nhs.uk/data_elements/end_time__episode_.html)

```sql
	select
		distinct
		ae.AEAttendanceNumber,
		ae.NHSNumber,
		coalesce(ae.ArrivalDate, ae.CDSActivityDate) as StartDate,
		coalesce(ae.ArrivalTime, '000000') as StartTime,
		coalesce(ae.AEDepartureDate, ae.AEAttendanceConclusionDate) as EndDate,
		coalesce(ae.AEDepartureTime, ae.AEAttendanceConclusionTime, '000000') as EndTime,
		i.AccidentAndEmergencyInvestigation
	from omop_staging.sus_AE_investigation i
		inner join omop_staging.sus_AE ae
			on i.MessageId = ae.MessageId
	where ae.NHSNumber is not null
	and i.AccidentAndEmergencyInvestigation in ('01', '02', '08', '09', '10', '11', '12', '19')
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20DeviceExposure%20table%20device_exposure_end_datetime%20field%20SUS%20AE%20Investigation%20Device%20Exposure%20mapping){: .btn }
### Oxford Device Exposure
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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20DeviceExposure%20table%20device_exposure_end_datetime%20field%20Oxford%20Device%20Exposure%20mapping){: .btn }
