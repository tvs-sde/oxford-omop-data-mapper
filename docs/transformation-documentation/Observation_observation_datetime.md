---
layout: default
title: observation_datetime
parent: Observation
grand_parent: Transformation Documentation
has_toc: false
---
# observation_datetime
### SUS OP Source Of Referral For Outpatients
Source columns  `AppointmentDate`, `AppointmentTime`.
Combines a date with a time of day.

* `AppointmentDate` Event date [APPOINTMENT DATE](https://www.datadictionary.nhs.uk/data_elements/appointment_date.html)

* `AppointmentTime` The time, advised to a PATIENT for when they can expect to see a relevant CARE PROFESSIONAL at an Out-Patient Clinic. [APPOINTMENT TIME](https://www.datadictionary.nhs.uk/data_elements/appointment_time.html)

```sql
select
	NHSNumber,
	GeneratedRecordIdentifier,
	AppointmentDate,
	AppointmentTime,
	ReferrerCode   -- Referrer code is the code of the person making the referral request
from omop_staging.sus_OP
	where ReferrerCode is not null
	and NHSNumber is not null
	and AttendedorDidNotAttend in ('5','6')
order by NHSNumber,
	GeneratedRecordIdentifier,
	AppointmentDate,
	AppointmentTime,
	ReferrerCode
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20SUS%20OP%20Source%20Of%20Referral%20For%20Outpatients%20mapping){: .btn }
### SUS OP Referral Received Date For Outpatients
Source columns  `AppointmentDate`, `AppointmentTime`.
Combines a date with a time of day.

* `AppointmentDate` Event date [APPOINTMENT DATE](https://www.datadictionary.nhs.uk/data_elements/appointment_date.html)

* `AppointmentTime` The time, advised to a PATIENT for when they can expect to see a relevant CARE PROFESSIONAL at an Out-Patient Clinic. [APPOINTMENT TIME](https://www.datadictionary.nhs.uk/data_elements/appointment_time.html)

```sql
	select
		op.NHSNumber, 
		op.AppointmentDate,
		op.AppointmentTime,
		op.ReferralRequestReceivedDate,
		op.GeneratedRecordIdentifier
	from omop_staging.sus_OP op
	where ReferralRequestReceivedDate is not null
		and op.NHSNumber is not null
		and AttendedorDidNotAttend in ('5','6')
	order by op.NHSNumber, 
		op.AppointmentDate,
		op.AppointmentTime,
		op.ReferralRequestReceivedDate,
		op.GeneratedRecordIdentifier
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20SUS%20OP%20Referral%20Received%20Date%20For%20Outpatients%20mapping){: .btn }
### SUS Outpatient Procedure Observation
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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20SUS%20Outpatient%20Procedure%20Observation%20mapping){: .btn }
### Sus OP ICDDiagnosis table
Source column  `CDSActivityDate`.
Converts text to dates.

* `CDSActivityDate` Start date of the episode, if exists, else the start date of the spell. [CDS ACTIVITY DATE](https://www.datadictionary.nhs.uk/data_elements/cds_activity_date.html)

```sql
select
    distinct
        d.DiagnosisICD,
        op.GeneratedRecordIdentifier,
        op.NHSNumber,
        op.CDSActivityDate
from omop_staging.sus_OP_ICDDiagnosis d
    inner join omop_staging.sus_OP op
        on d.MessageId = op.MessageId
where op.NHSNumber is not null
	and AttendedorDidNotAttend in ('5','6')
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20Sus%20OP%20ICDDiagnosis%20table%20mapping){: .btn }
### SUS Outpatient Carer Support Indicator Observation
Source column  `CDSActivityDate`.
Converts text to dates.

* `CDSActivityDate` Event date [CDS ACTIVITY DATE](https://www.datadictionary.nhs.uk/data_elements/cds_activity_date.html)

```sql
select 
	op.NHSNumber, 
	max(op.CDSActivityDate) as CDSActivityDate, 
	op.CarerSupportIndicator,
	op.GeneratedRecordIdentifier
from omop_staging.sus_OP op
where op.CarerSupportIndicator is not null
	and op.NHSNumber is not null
	and AttendedorDidNotAttend in ('5','6')
group by
	op.NHSNumber, 
	op.CarerSupportIndicator,
	op.GeneratedRecordIdentifier;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20SUS%20Outpatient%20Carer%20Support%20Indicator%20Observation%20mapping){: .btn }
### Sus CCMDS High Cost Drugs
Source columns  `ObservationDate`, `ObservationDateTime`.
Combines a date with a time of day.

* `ObservationDate` Start date of the visit [CRITICAL CARE START DATE](https://www.datadictionary.nhs.uk/data_elements/critical_care_start_date.html)

* `ObservationDateTime` Start time of the visit, if exists, else midnight. [CRITICAL CARE START TIME](https://www.datadictionary.nhs.uk/data_elements/critical_care_start_time.html)

```sql
		select distinct
			apc.NHSNumber,
			apc.HospitalProviderSpellNumber,
			cc.CriticalCareStartDate as ObservationDate,
			coalesce(cc.CriticalCareStartTime, '00:00:00') as ObservationDateTime,
			d.CriticalCareHighCostDrugs as ObservationSourceValue
		from omop_staging.sus_CCMDS_CriticalCareHighCostDrugs d
		inner join omop_staging.sus_CCMDS cc on d.MessageId = cc.MessageId
		inner join omop_staging.sus_APC apc on cc.GeneratedRecordID = apc.GeneratedRecordIdentifier
		where apc.NHSNumber is not null
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20Sus%20CCMDS%20High%20Cost%20Drugs%20mapping){: .btn }
### SUS Inpatient Total Previous Pregnancies Observation
Source column  `observation_date`.
Converts text to dates.

* `observation_date` Event date [CDS ACTIVITY DATE](https://www.datadictionary.nhs.uk/data_elements/cds_activity_date.html)

```sql
select 
	apc.NHSNumber, 
	apc.GeneratedRecordIdentifier,
	apc.HospitalProviderSpellNumber,
	max(apc.CDSActivityDate) as observation_date,
	apc.PregnancyTotalPreviousPregnancies
from omop_staging.sus_APC apc
where apc.NHSNumber is not null
	and apc.PregnancyTotalPreviousPregnancies is not null
	and apc.CDSActivityDate is not null
	and apc.CdsType in ('140', '120')
group by 
	apc.NHSNumber, 
	apc.GeneratedRecordIdentifier, 
    apc.HospitalProviderSpellNumber,
	apc.PregnancyTotalPreviousPregnancies;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20SUS%20Inpatient%20Total%20Previous%20Pregnancies%20Observation%20mapping){: .btn }
### SUS APC Source Of Referral For Inpatients
Source columns  `StartDateHospitalProviderSpell`, `StartTimeHospitalProviderSpell`.
Combines a date with a time of day.

* `StartDateHospitalProviderSpell` Event date [START DATE (HOSPITAL PROVIDER SPELL)](https://www.datadictionary.nhs.uk/data_elements/start_date__hospital_provider_spell_.html)

* `StartTimeHospitalProviderSpell` Records whether anaesthetic was given during Labour/ Delivery, and the type used. [START TIME (HOSPITAL PROVIDER SPELL)](https://www.datadictionary.nhs.uk/data_elements/start_time__hospital_provider_spell_.html)

```sql
select	
	NHSNumber,
	GeneratedRecordIdentifier,
	StartDateHospitalProviderSpell,
	StartTimeHospitalProviderSpell,
	ReferrerCode   -- Referrer code is the code of the person making the referral request
FROM omop_staging.sus_APC
where NHSNumber is not null
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20SUS%20APC%20Source%20Of%20Referral%20For%20Inpatients%20mapping){: .btn }
### SUS APC Referral Received Date For Inpatients
Source columns  `StartDateHospitalProviderSpell`, `StartTimeHospitalProviderSpell`.
Combines a date with a time of day.

* `StartDateHospitalProviderSpell` START DATE (HOSPITAL PROVIDER SPELL) is the Start Date of the Hospital Provider Spell. [START DATE (HOSPITAL PROVIDER SPELL)](https://www.datadictionary.nhs.uk/data_elements/start_date__hospital_provider_spell_.html)

* `StartTimeHospitalProviderSpell` START TIME (HOSPITAL PROVIDER SPELL)  is the Start Time  of the Hospital Provider Spell . [START TIME (HOSPITAL PROVIDER SPELL)](https://www.datadictionary.nhs.uk/data_elements/start_time__hospital_provider_spell_.html)

```sql
	select
		apc.NHSNumber, 
		apc.StartDateHospitalProviderSpell,
		apc.StartTimeHospitalProviderSpell,
		apc.ReferralToTreatmentPeriodStartDate,
		apc.GeneratedRecordIdentifier
	from omop_staging.sus_APC apc
	where ReferralToTreatmentPeriodStartDate is not null
		and apc.NHSNumber is not null
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20SUS%20APC%20Referral%20Received%20Date%20For%20Inpatients%20mapping){: .btn }
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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20SUS%20APC%20Procedure%20Occurrence%20mapping){: .btn }
### SUS Inpatient NumberofBabies Observation
Source column  `observation_date`.
Converts text to dates.

* `observation_date` Event date [CDS ACTIVITY DATE](https://www.datadictionary.nhs.uk/data_elements/cds_activity_date.html), [DELIVERY DATE](https://www.datadictionary.nhs.uk/data_elements/delivery_date.html)

```sql
select
	apc.NHSNumber,
	apc.GeneratedRecordIdentifier,
	apc.HospitalProviderSpellNumber,
	coalesce(max(apc.DeliveryDate), max(apc.CDSActivityDate)) as observation_date,
	apc.NumberofBabies
from omop_staging.sus_APC apc													
where apc.NHSNumber is not null
	and apc.NumberofBabies is not null
	and apc.CDSType in ('120','140')
group by
	apc.NHSNumber,
	apc.GeneratedRecordIdentifier, 
    apc.HospitalProviderSpellNumber,
	apc.DeliveryDate,
	apc.NumberofBabies;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20SUS%20Inpatient%20NumberofBabies%20Observation%20mapping){: .btn }
### Sus APC Diagnosis Table
Source column  `CDSActivityDate`.
Converts text to dates.

* `CDSActivityDate` Start date of the episode, if exists, else the start date of the spell. [CDS ACTIVITY DATE](https://www.datadictionary.nhs.uk/data_elements/cds_activity_date.html)

```sql
select
    distinct
        d.DiagnosisICD,
        apc.GeneratedRecordIdentifier,
        apc.NHSNumber,
        apc.CDSActivityDate
from omop_staging.sus_ICDDiagnosis d
    inner join omop_staging.sus_APC apc
        on d.MessageId = apc.MessageId
where apc.NHSNumber is not null
order by
	d.DiagnosisICD,
    apc.GeneratedRecordIdentifier,
    apc.NHSNumber,
    apc.CDSActivityDate
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20Sus%20APC%20Diagnosis%20Table%20mapping){: .btn }
### SUS Inpatient Gestation Length Labour Onset Observation
Source column  `observation_date`.
Converts text to dates.

* `observation_date` Event date [CDS ACTIVITY DATE](https://www.datadictionary.nhs.uk/data_elements/cds_activity_date.html), [DELIVERY DATE](https://www.datadictionary.nhs.uk/data_elements/delivery_date.html)

```sql
select 
	apc.NHSNumber, 
	apc.GeneratedRecordIdentifier,
	apc.HospitalProviderSpellNumber,
	coalesce(max(apc.DeliveryDate), max(apc.CDSActivityDate)) as observation_date, 
	apc.GestationLengthLabourOnset
from omop_staging.sus_APC as apc																			
where apc.NHSNumber is not null
  and apc.GestationLengthLabourOnset is not null
  and apc.CDSType in ('120', '140')
group by 
	apc.NHSNumber, 
	apc.GeneratedRecordIdentifier, 
    apc.HospitalProviderSpellNumber,
	apc.DeliveryDate, 
	apc.GestationLengthLabourOnset;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20SUS%20Inpatient%20Gestation%20Length%20Labour%20Onset%20Observation%20mapping){: .btn }
### SUS Inpatient Carer Support Indicator Observation
Source column  `CDSActivityDate`.
Converts text to dates.

* `CDSActivityDate` Event date [CDS ACTIVITY DATE](https://www.datadictionary.nhs.uk/data_elements/cds_activity_date.html)

```sql
select 
	apc.NHSNumber, 
	max(apc.CDSActivityDate) as CDSActivityDate, 
	apc.CarerSupportIndicator,
	apc.HospitalProviderSpellNumber,
	apc.GeneratedRecordIdentifier
from omop_staging.sus_APC apc
where apc.CarerSupportIndicator is not null
	and apc.NHSNumber is not null
group by
	apc.NHSNumber, 
	apc.CarerSupportIndicator,
	apc.HospitalProviderSpellNumber,
	apc.GeneratedRecordIdentifier;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20SUS%20Inpatient%20Carer%20Support%20Indicator%20Observation%20mapping){: .btn }
### Sus APC Birth Weight Observation
Source column  `observation_date`.
Converts text to dates.

* `observation_date` Event date [CDS ACTIVITY DATE](https://www.datadictionary.nhs.uk/data_elements/cds_activity_date.html), [DELIVERY DATE](https://www.datadictionary.nhs.uk/data_elements/delivery_date.html)

```sql
select 
	apc.NHSNumber, 
	apc.GeneratedRecordIdentifier,
	apc.HospitalProviderSpellNumber,
	coalesce(max(apc.DeliveryDate), max(apc.CDSActivityDate)) as observation_date, 
	b.BirthWeightBaby as BirthWeight
from omop_staging.sus_APC apc
	inner join omop_staging.sus_Birth as b
		on apc.MessageId = b.MessageId
where b.BirthWeightBaby is not null
  and apc.NHSNumber is not null
  and apc.CdsType in ('140', '120')
group by 
	apc.NHSNumber,
	apc.GeneratedRecordIdentifier,
    apc.HospitalProviderSpellNumber,
	apc.DeliveryDate,
	b.BirthWeightBaby;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20Sus%20APC%20Birth%20Weight%20Observation%20mapping){: .btn }
### SUS APC Anaesthetic Given Post Labour Delivery Observation
Source column  `observation_date`.
Converts text to dates.

* `observation_date` Event date [CDS ACTIVITY DATE](https://www.datadictionary.nhs.uk/data_elements/cds_activity_date.html)

```sql
select
    apc.NHSNumber, 
    apc.GeneratedRecordIdentifier, 
	apc.HospitalProviderSpellNumber,
    coalesce(max(apc.DeliveryDate), max(apc.CDSActivityDate)) as observation_date, 
    apc.AnaestheticGivenPostDelivery
from omop_staging.sus_APC as apc
where apc.AnaestheticGivenPostDelivery is not null
  and apc.NHSNumber is not null
  and apc.CdsType in ('140', '120')
group by 
    apc.NHSNumber, 
    apc.GeneratedRecordIdentifier,
	apc.HospitalProviderSpellNumber,
    apc.DeliveryDate,
    apc.AnaestheticGivenPostDelivery;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20SUS%20APC%20Anaesthetic%20Given%20Post%20Labour%20Delivery%20Observation%20mapping){: .btn }
### SUS APC Anaesthetic During Labour Delivery Observation
Source column  `observation_date`.
Converts text to dates.

* `observation_date` Event date [CDS ACTIVITY DATE](https://www.datadictionary.nhs.uk/data_elements/cds_activity_date.html), [DELIVERY DATE](https://www.datadictionary.nhs.uk/data_elements/delivery_date.html)

```sql
select
    apc.NHSNumber, 
    apc.GeneratedRecordIdentifier, 
    coalesce(max(apc.DeliveryDate), max(apc.CDSActivityDate)) as observation_date,
	apc.HospitalProviderSpellNumber,
    apc.AnaestheticGivenDuringLabourDelivery
from omop_staging.sus_APC as apc
where apc.AnaestheticGivenDuringLabourDelivery is not null
  and apc.NHSNumber is not null
  and apc.CdsType in ('140', '120')
group by 
    apc.NHSNumber, 
    apc.GeneratedRecordIdentifier,
	apc.HospitalProviderSpellNumber,
    apc.DeliveryDate, 
    apc.AnaestheticGivenDuringLabourDelivery;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20SUS%20APC%20Anaesthetic%20During%20Labour%20Delivery%20Observation%20mapping){: .btn }
### SUS AE Source Of Referral For AE
Source columns  `ArrivalDate`, `ArrivalTime`.
Combines a date with a time of day.

* `ArrivalDate` Event date [ARRIVAL DATE](https://www.datadictionary.nhs.uk/data_elements/arrival_date.html)

* `ArrivalTime` The time (using a 24 hour clock) that is of relevance to an ACTIVITY. [ARRIVAL TIME AT ACCIDENT AND EMERGENCY DEPARTMENT](https://www.datadictionary.nhs.uk/data_elements/arrival_time_at_accident_and_emergency_department.html)

```sql
select
	NHSNumber,
	GeneratedRecordIdentifier,
    ArrivalDate,
    ArrivalTime,
	SourceofReferralForAE   -- Referrer code is the code of the person making the referral request
from omop_staging.sus_AE
where SourceofReferralForAE is not null
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20SUS%20AE%20Source%20Of%20Referral%20For%20AE%20mapping){: .btn }
### SUS AE Diabetic Patient
Source columns  `ArrivalDate`, `ArrivalTime`.
Combines a date with a time of day.

* `ArrivalDate` Event date [ARRIVAL DATE](https://www.datadictionary.nhs.uk/data_elements/arrival_date.html)

* `ArrivalTime` The time (using a 24 hour clock) that is of relevance to an ACTIVITY. [ARRIVAL TIME AT ACCIDENT AND EMERGENCY DEPARTMENT](https://www.datadictionary.nhs.uk/data_elements/arrival_time_at_accident_and_emergency_department.html)

```sql
select
	distinct
		d.AccidentAndEmergencyDiagnosis,
		ae.GeneratedRecordIdentifier,
		ae.NHSNumber,
		ae.ArrivalDate,
		ae.ArrivalTime
from omop_staging.sus_AE_diagnosis d
	inner join omop_staging.sus_AE ae
		on d.MessageId = ae.MessageId
where ae.NHSNumber is not null
and d.AccidentAndEmergencyDiagnosis in ('30','301')
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20SUS%20AE%20Diabetic%20Patient%20mapping){: .btn }
### SUS AE Diabetic Patient
Source columns  `ArrivalDate`, `ArrivalTime`.
Combines a date with a time of day.

* `ArrivalDate` Event date [ARRIVAL DATE](https://www.datadictionary.nhs.uk/data_elements/arrival_date.html)

* `ArrivalTime` The time (using a 24 hour clock) that is of relevance to an ACTIVITY. [ARRIVAL TIME AT ACCIDENT AND EMERGENCY DEPARTMENT](https://www.datadictionary.nhs.uk/data_elements/arrival_time_at_accident_and_emergency_department.html)

```sql
select
	distinct
		d.AccidentAndEmergencyDiagnosis,
		ae.GeneratedRecordIdentifier,
		ae.NHSNumber,
		ae.ArrivalDate,
		ae.ArrivalTime
from omop_staging.sus_AE_diagnosis d
	inner join omop_staging.sus_AE ae
		on d.MessageId = ae.MessageId
where ae.NHSNumber is not null
and d.AccidentAndEmergencyDiagnosis in ('20','201')
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20SUS%20AE%20Diabetic%20Patient%20mapping){: .btn }
### SACT Adjunctive Therapy Type
Source columns  `Administration_Date`, `Administration_Date`.
Combines a date with a time of day.

* `Administration_Date` SYSTEMIC ANTI-CANCER THERAPY ADMINISTRATION DATE is the date of the Systemic Anti-Cancer Therapy Drug Administration or the date an oral drug was initially dispensed to the PATIENT. [SYSTEMIC ANTI-CANCER THERAPY ADMINISTRATION DATE](https://www.datadictionary.nhs.uk/data_elements/systemic_anti-cancer_therapy_administration_date.html)

* `Administration_Date` SYSTEMIC ANTI-CANCER THERAPY ADMINISTRATION DATE is the date of the Systemic Anti-Cancer Therapy Drug Administration or the date an oral drug was initially dispensed to the PATIENT. [SYSTEMIC ANTI-CANCER THERAPY ADMINISTRATION DATE](https://www.datadictionary.nhs.uk/data_elements/systemic_anti-cancer_therapy_administration_date.html)

```sql
		select distinct
  			replace(NHS_Number, ' ', '') as NHSNumber,
			Adjunctive_Therapy,
			Case 
				When Adjunctive_Therapy = 1 then concat(Adjunctive_Therapy, ' - Adjuvant Therapy')
				When Adjunctive_Therapy = 2 then concat(Adjunctive_Therapy, ' - Neoadjuvant Therapy')
				When Adjunctive_Therapy = 3 then concat(Adjunctive_Therapy, ' - Not Applicable (Primary Treatment)')
				When Adjunctive_Therapy = 9 then concat(Adjunctive_Therapy, ' - Not Known (Not Recorded)')
			else '' end as Source_value,
		  	Administration_Date
		from omop_staging.sact_staging
  		where Adjunctive_Therapy != ''
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20SACT%20Adjunctive%20Therapy%20Type%20mapping){: .btn }
### SACT Administration Route
Source columns  `Administration_Date`, `Administration_Date`.
Combines a date with a time of day.

* `Administration_Date` SYSTEMIC ANTI-CANCER THERAPY ADMINISTRATION DATE is the date of the Systemic Anti-Cancer Therapy Drug Administration or the date an oral drug was initially dispensed to the PATIENT. [SYSTEMIC ANTI-CANCER THERAPY ADMINISTRATION DATE](https://www.datadictionary.nhs.uk/data_elements/systemic_anti-cancer_therapy_administration_date.html)

* `Administration_Date` SYSTEMIC ANTI-CANCER THERAPY ADMINISTRATION DATE is the date of the Systemic Anti-Cancer Therapy Drug Administration or the date an oral drug was initially dispensed to the PATIENT. [SYSTEMIC ANTI-CANCER THERAPY ADMINISTRATION DATE](https://www.datadictionary.nhs.uk/data_elements/systemic_anti-cancer_therapy_administration_date.html)

```sql
		select
		distinct
  			replace(NHS_Number, ' ', '') as NHSNumber,
      		SACT_Administration_Route as Administration_Route,
		  	Administration_Date
	from omop_staging.sact_staging
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20SACT%20Administration%20Route%20mapping){: .btn }
### SACT Clinical Trial
Source columns  `Administration_Date`, `Administration_Date`.
Combines a date with a time of day.

* `Administration_Date` SYSTEMIC ANTI-CANCER THERAPY ADMINISTRATION DATE is the date of the Systemic Anti-Cancer Therapy Drug Administration or the date an oral drug was initially dispensed to the PATIENT. [SYSTEMIC ANTI-CANCER THERAPY ADMINISTRATION DATE](https://www.datadictionary.nhs.uk/data_elements/systemic_anti-cancer_therapy_administration_date.html)

* `Administration_Date` SYSTEMIC ANTI-CANCER THERAPY ADMINISTRATION DATE is the date of the Systemic Anti-Cancer Therapy Drug Administration or the date an oral drug was initially dispensed to the PATIENT. [SYSTEMIC ANTI-CANCER THERAPY ADMINISTRATION DATE](https://www.datadictionary.nhs.uk/data_elements/systemic_anti-cancer_therapy_administration_date.html)

```sql
		select
			distinct
  			replace(NHS_Number, ' ', '') as NHSNumber,
      		Clinical_Trial,
			Case 
				When Clinical_Trial = 1 then concat(Clinical_Trial, ' - PATIENT is taking part in a CLINICAL TRIAL')
			else '' end as Source_Value,
		  	Administration_Date
		from omop_staging.sact_staging
  		where Clinical_Trial = '1'
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20SACT%20Clinical%20Trial%20mapping){: .btn }
### SACT Treatment Intent
Source columns  `Administration_Date`, `Administration_Date`.
Combines a date with a time of day.

* `Administration_Date` SYSTEMIC ANTI-CANCER THERAPY ADMINISTRATION DATE is the date of the Systemic Anti-Cancer Therapy Drug Administration or the date an oral drug was initially dispensed to the PATIENT. [SYSTEMIC ANTI-CANCER THERAPY ADMINISTRATION DATE](https://www.datadictionary.nhs.uk/data_elements/systemic_anti-cancer_therapy_administration_date.html)

* `Administration_Date` SYSTEMIC ANTI-CANCER THERAPY ADMINISTRATION DATE is the date of the Systemic Anti-Cancer Therapy Drug Administration or the date an oral drug was initially dispensed to the PATIENT. [SYSTEMIC ANTI-CANCER THERAPY ADMINISTRATION DATE](https://www.datadictionary.nhs.uk/data_elements/systemic_anti-cancer_therapy_administration_date.html)

```sql
		select distinct
  			replace(NHS_Number, ' ', '') as NHSNumber,
			Intent_Of_Treatment,
			Case 
				When Intent_Of_Treatment = 1 then concat(Intent_Of_Treatment, ' - Curative(aiming to permanently eradicate disease)')
				When Intent_Of_Treatment = 2 then concat(Intent_Of_Treatment, ' - Palliative(aiming to extend life expectancy)')
				When Intent_Of_Treatment = 3 then concat(Intent_Of_Treatment, ' - Palliative(aiming to relieve and/or control malignancy related symptoms)')
				When Intent_Of_Treatment = 4 then concat(Intent_Of_Treatment, ' - Palliative(aiming to achieve remission)')
				When Intent_Of_Treatment = 5 then concat(Intent_Of_Treatment, ' - Palliative(aiming to permanently eradicate disease)')
			else '' end as Source_value,
		  	Administration_Date
		from omop_staging.sact_staging
        where Intent_Of_Treatment != ''
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20SACT%20Treatment%20Intent%20mapping){: .btn }
### RTDS Decision To Perform Date
Source columns  `DateStamp`, `DateStamp`.
Combines a date with a time of day.

* `DateStamp` Decision date of treatment 

* `DateStamp` Decision date of treatment 

```sql
		select distinct
			(select PatientId from omop_staging.rtds_1_demographics d where d.PatientSer = dc.PatientSer limit 1) as NhsNumber,
			DateStamp
		from omop_staging.RTDS_5_Diagnosis_Course dc
		where dc.DiagnosisCode like 'Decision%'
		and NhsNumber is not null
		and regexp_matches(NhsNumber, '\d{10}');
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20RTDS%20Decision%20To%20Perform%20Date%20mapping){: .btn }
### RTDS External Beam Radiation Therapy Energy
Source columns  `Treatmentdatetime`, `Treatmentdatetime`.
Combines a date with a time of day.

* `Treatmentdatetime` Start date of treatment 

* `Treatmentdatetime` Start date of treatment 

```sql
		select distinct
			(select PatientId from omop_staging.rtds_1_demographics d where d.PatientSer = dc.PatientSer limit 1) as NhsNumber,
			Treatmentdatetime,
			Cast(NominalEnergy as double) / 1000 as CalculatedNominalEnergy,
			NominalEnergy as NominalEnergy
		from omop_staging.RTDS_4_Exposures dc
		where NhsNumber is not null
		and regexp_matches(NhsNumber, '\d{10}')
		and NominalEnergy is not null 
		and NominalEnergy != '';
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20RTDS%20External%20Beam%20Radiation%20Therapy%20Energy%20mapping){: .btn }
### RTDS Number Of Fractions
Source columns  `StartDateTime`, `StartDateTime`.
Combines a date with a time of day.

* `StartDateTime` Start date of treatment 

* `StartDateTime` Start date of treatment 

```sql
		select distinct
			(select PatientId from omop_staging.rtds_1_demographics d where d.PatientSer = dc.PatientSer limit 1) as NhsNumber,
			StartDateTime,
			NoFracs 
		from omop_staging.RTDS_3_Prescription dc
		where NhsNumber is not null
		and regexp_matches(NhsNumber, '\d{10}')
		and NoFracs is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20RTDS%20Number%20Of%20Fractions%20mapping){: .btn }
### RTDS Date of Referral
Source columns  `DateStamp`, `DateStamp`.
Combines a date with a time of day.

* `DateStamp` Decision date of treatment 

* `DateStamp` Decision date of treatment 

```sql
		select distinct
			(select PatientId from omop_staging.rtds_1_demographics d where d.PatientSer = dc.PatientSer limit 1) as NhsNumber,
			dc.DiagnosisCode,
					dc.DateStamp,
		from omop_staging.RTDS_5_Diagnosis_Course dc
		where dc.DiagnosisCode like 'Referral%'
		and NhsNumber is not null
		and regexp_matches(NhsNumber, '\d{10}');
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20RTDS%20Date%20of%20Referral%20mapping){: .btn }
### RTDS Treatment Anatomical Site
Source columns  `DueDateTime`, `DueDateTime`.
Combines a date with a time of day.

* `DueDateTime` DATE WHEN RADIOTHERAPY OCCURRED 

* `DueDateTime` DATE WHEN RADIOTHERAPY OCCURRED 

```sql
		select distinct
			(select PatientId from omop_staging.rtds_1_demographics d where d.PatientSer = dc.PatientSer limit 1) as NhsNumber,
			AttributeValue,
			(select concept_id from cdm.concept where domain_id = 'Spec Anatomic Site'
				and concept_code = CASE WHEN length(code) > 3 THEN substr(code, 1, 3) || '.' || substr(code, 4) ELSE code END) as AnatomicalSiteConceptId,
			DueDateTime
		from omop_staging.RTDS_2b_Plan dc,
		LATERAL (SELECT regexp_extract(AttributeValue, '^([A-Z][0-9A-Z]+)', 1) AS code) AS t
		where Description = 'Anatomical Site' 
		and AttributeValue is not null 
		and AttributeValue != 'None'
		and NhsNumber is not null
		and regexp_matches(NhsNumber, '\d{10}');
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20RTDS%20Treatment%20Anatomical%20Site%20mapping){: .btn }
### Oxford Lab General Comment Observation
Source column  `EVENT_START_DT_TM`.
Converts text to dates.

* `EVENT_START_DT_TM` Lab test event start datetime [EVENT START DT TM]()

```sql
select
    NHS_NUMBER,
    EVENT,
    EVENT_START_DT_TM,
    RESULT_VALUE
from ##duckdb_source##
where lower(EVENT) like '%comment%'
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20Oxford%20Lab%20General%20Comment%20Observation%20mapping){: .btn }
### COSD V9 UR Observation Smoking Status Cancer
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` The date the Primary Cancer was confirmed or the Primary Cancer diagnosis was clinically agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
-- Selects SMOKING STATUS (CANCER) for Urological (UR) records in COSD
-- v9.01, sourced from TobaccoSmokingStatus. Date of primary diagnosis is
-- used as observation_date.
select distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
    Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed' as DateOfPrimaryDiagnosisClinicallyAgreed,
    Record ->> '$.ClinicalNurseSpecialistAndRiskFactorAssessments.TobaccoSmokingStatus.@code' as SmokingStatusCancer
from omop_staging.cosd_staging_901
where type = 'UR'
  and NhsNumber is not null
  and SmokingStatusCancer is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20COSD%20V9%20UR%20Observation%20Smoking%20Status%20Cancer%20mapping){: .btn }
### COSD V9 UR Observation Alcohol History Cancer In Last Three Months
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` The date the Primary Cancer was confirmed or the Primary Cancer diagnosis was clinically agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
-- Selects ALCOHOL HISTORY (CANCER IN LAST THREE MONTHS) for Urological
-- (UR) records in COSD v9.01, sourced from HistoryOfAlcoholCurrent. Date
-- of primary diagnosis is used as observation_date.
select distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
    Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed' as DateOfPrimaryDiagnosisClinicallyAgreed,
    Record ->> '$.ClinicalNurseSpecialistAndRiskFactorAssessments.HistoryOfAlcoholCurrent.@code' as AlcoholHistoryCancerInLastThreeMonths
from omop_staging.cosd_staging_901
where type = 'UR'
  and NhsNumber is not null
  and AlcoholHistoryCancerInLastThreeMonths is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20COSD%20V9%20UR%20Observation%20Alcohol%20History%20Cancer%20In%20Last%20Three%20Months%20mapping){: .btn }
### COSD V9 UR Observation Alcohol History Cancer Before Last Three Months
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` The date the Primary Cancer was confirmed or the Primary Cancer diagnosis was clinically agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
-- Selects ALCOHOL HISTORY (CANCER BEFORE LAST THREE MONTHS) for Urological
-- (UR) records in COSD v9.01, sourced from HistoryOfAlcoholPast. Date of
-- primary diagnosis is used as observation_date.
select distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
    Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed' as DateOfPrimaryDiagnosisClinicallyAgreed,
    Record ->> '$.ClinicalNurseSpecialistAndRiskFactorAssessments.HistoryOfAlcoholPast.@code' as AlcoholHistoryCancerBeforeLastThreeMonths
from omop_staging.cosd_staging_901
where type = 'UR'
  and NhsNumber is not null
  and AlcoholHistoryCancerBeforeLastThreeMonths is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20COSD%20V9%20UR%20Observation%20Alcohol%20History%20Cancer%20Before%20Last%20Three%20Months%20mapping){: .btn }
### COSD V8 UR Observation Smoking Status Cancer
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` The date the Primary Cancer was confirmed or the Primary Cancer diagnosis was clinically agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
-- Selects SMOKING STATUS (CANCER) for Urological (UR) records in COSD
-- v8.1, sourced from SmokingStatusCode. Date of primary diagnosis is used
-- as observation_date.
select distinct
    Record ->> '$.Urological.UrologicalCore.UrologicalCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
    Record ->> '$.Urological.UrologicalCore.UrologicalCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as DateOfPrimaryDiagnosisClinicallyAgreed,
    Record ->> '$.Urological.UrologicalCore.UrologicalCoreClinicalNurseSpecialistAndRiskFactorAssessments.SmokingStatusCode.@code' as SmokingStatusCancer
from omop_staging.cosd_staging_81
where type = 'UR'
  and NhsNumber is not null
  and SmokingStatusCancer is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20COSD%20V8%20UR%20Observation%20Smoking%20Status%20Cancer%20mapping){: .btn }
### COSD V8 UR Observation Person Stated Sexual Orientation Code At Diagnosis
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` The date the Primary Cancer was confirmed or the Primary Cancer diagnosis was clinically agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
-- Selects PERSON STATED SEXUAL ORIENTATION CODE (AT DIAGNOSIS) for
-- Urological (UR) records in COSD v8.1. Date of primary diagnosis is used
-- as observation_date.
select distinct
    Record ->> '$.Urological.UrologicalCore.UrologicalCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
    Record ->> '$.Urological.UrologicalCore.UrologicalCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as DateOfPrimaryDiagnosisClinicallyAgreed,
    Record ->> '$.Urological.UrologicalCore.UrologicalCoreDemographics.PersonStatedSexualOrientationCodeAtDiagnosis.@code' as PersonStatedSexualOrientationCodeAtDiagnosis
from omop_staging.cosd_staging_81
where type = 'UR'
  and NhsNumber is not null
  and PersonStatedSexualOrientationCodeAtDiagnosis is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20COSD%20V8%20UR%20Observation%20Person%20Stated%20Sexual%20Orientation%20Code%20At%20Diagnosis%20mapping){: .btn }
### COSD V8 UR Observation Asa Physical Status Classification System Code
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` The date the Primary Cancer was confirmed or the Primary Cancer diagnosis was clinically agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
-- Selects ASA PHYSICAL STATUS CLASSIFICATION SYSTEM CODE for Urological
-- (UR) records in COSD v8.1. The Treatment array is unnested so each
-- surgery's ASA grade can be emitted, paired with the primary diagnosis
-- date as observation_date (no dedicated assessment date is recorded
-- alongside the ASA code in this dataset).
with ur as (
    select
        Record ->> '$.Urological.UrologicalCore.UrologicalCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
        Record ->> '$.Urological.UrologicalCore.UrologicalCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as DateOfPrimaryDiagnosisClinicallyAgreed,
        unnest([
            [Record ->> '$.Urological.UrologicalCore.UrologicalCoreTreatment.UrologicalCoreSurgeryAndOtherProcedures.ASAPhysicalStatusClassificationSystemCode.@code'],
            Record ->> '$.Urological.UrologicalCore.UrologicalCoreTreatment[*].UrologicalCoreSurgeryAndOtherProcedures.ASAPhysicalStatusClassificationSystemCode.@code'
        ], recursive := true) as AsaPhysicalStatusClassificationSystemCode
    from omop_staging.cosd_staging_81
    where type = 'UR'
)
select distinct
    NhsNumber,
    DateOfPrimaryDiagnosisClinicallyAgreed,
    AsaPhysicalStatusClassificationSystemCode
from ur
where NhsNumber is not null
  and AsaPhysicalStatusClassificationSystemCode is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20COSD%20V8%20UR%20Observation%20Asa%20Physical%20Status%20Classification%20System%20Code%20mapping){: .btn }
### COSD V8 UR Observation Alcohol History Cancer In Last Three Months
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` The date the Primary Cancer was confirmed or the Primary Cancer diagnosis was clinically agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
-- Selects ALCOHOL HISTORY (CANCER IN LAST THREE MONTHS) for Urological
-- (UR) records in COSD v8.1. Date of primary diagnosis is used as
-- observation_date.
select distinct
    Record ->> '$.Urological.UrologicalCore.UrologicalCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
    Record ->> '$.Urological.UrologicalCore.UrologicalCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as DateOfPrimaryDiagnosisClinicallyAgreed,
    Record ->> '$.Urological.UrologicalCore.UrologicalCoreClinicalNurseSpecialistAndRiskFactorAssessments.AlcoholHistoryCancerInLastThreeMonths.@code' as AlcoholHistoryCancerInLastThreeMonths
from omop_staging.cosd_staging_81
where type = 'UR'
  and NhsNumber is not null
  and AlcoholHistoryCancerInLastThreeMonths is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20COSD%20V8%20UR%20Observation%20Alcohol%20History%20Cancer%20In%20Last%20Three%20Months%20mapping){: .btn }
### COSD V8 UR Observation Alcohol History Cancer Before Last Three Months
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` The date the Primary Cancer was confirmed or the Primary Cancer diagnosis was clinically agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
-- Selects ALCOHOL HISTORY (CANCER BEFORE LAST THREE MONTHS) for Urological
-- (UR) records in COSD v8.1. Date of primary diagnosis is used as
-- observation_date.
select distinct
    Record ->> '$.Urological.UrologicalCore.UrologicalCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
    Record ->> '$.Urological.UrologicalCore.UrologicalCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as DateOfPrimaryDiagnosisClinicallyAgreed,
    Record ->> '$.Urological.UrologicalCore.UrologicalCoreClinicalNurseSpecialistAndRiskFactorAssessments.AlcoholHistoryCancerBeforeLastThreeMonths.@code' as AlcoholHistoryCancerBeforeLastThreeMonths
from omop_staging.cosd_staging_81
where type = 'UR'
  and NhsNumber is not null
  and AlcoholHistoryCancerBeforeLastThreeMonths is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20COSD%20V8%20UR%20Observation%20Alcohol%20History%20Cancer%20Before%20Last%20Three%20Months%20mapping){: .btn }
### COSD V9 UG Observation Smoking Status Cancer
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` The date the Primary Cancer was confirmed or the Primary Cancer diagnosis was clinically agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
-- Selects SMOKING STATUS (CANCER) for Upper GI (UG) records in COSD v9.01,
-- sourced from TobaccoSmokingStatus. Date of primary diagnosis is used as
-- observation_date.
select distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
    Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed' as DateOfPrimaryDiagnosisClinicallyAgreed,
    Record ->> '$.ClinicalNurseSpecialistAndRiskFactorAssessments.TobaccoSmokingStatus.@code' as SmokingStatusCancer
from omop_staging.cosd_staging_901
where type = 'UG'
  and NhsNumber is not null
  and SmokingStatusCancer is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20COSD%20V9%20UG%20Observation%20Smoking%20Status%20Cancer%20mapping){: .btn }
### COSD V9 UG Observation Alcohol History Cancer In Last Three Months
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` The date the Primary Cancer was confirmed or the Primary Cancer diagnosis was clinically agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
-- Selects ALCOHOL HISTORY (CANCER IN LAST THREE MONTHS) for Upper GI (UG)
-- records in COSD v9.01, sourced from HistoryOfAlcoholCurrent. Date of
-- primary diagnosis is used as observation_date.
select distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
    Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed' as DateOfPrimaryDiagnosisClinicallyAgreed,
    Record ->> '$.ClinicalNurseSpecialistAndRiskFactorAssessments.HistoryOfAlcoholCurrent.@code' as AlcoholHistoryCancerInLastThreeMonths
from omop_staging.cosd_staging_901
where type = 'UG'
  and NhsNumber is not null
  and AlcoholHistoryCancerInLastThreeMonths is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20COSD%20V9%20UG%20Observation%20Alcohol%20History%20Cancer%20In%20Last%20Three%20Months%20mapping){: .btn }
### COSD V9 UG Observation Alcohol History Cancer Before Last Three Months
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` The date the Primary Cancer was confirmed or the Primary Cancer diagnosis was clinically agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
-- Selects ALCOHOL HISTORY (CANCER BEFORE LAST THREE MONTHS) for Upper GI
-- (area UG) records in COSD v9.01, sourced from HistoryOfAlcoholPast.
--
-- The DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) is used as the
-- observation_date.
--
-- Downstream ETL: resolve NhsNumber to person_id; cast date; map National
-- Code value to observation_concept_id.
select distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
    Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed' as DateOfPrimaryDiagnosisClinicallyAgreed,
    Record ->> '$.ClinicalNurseSpecialistAndRiskFactorAssessments.HistoryOfAlcoholPast.@code' as AlcoholHistoryCancerBeforeLastThreeMonths
from omop_staging.cosd_staging_901
where type = 'UG'
  and NhsNumber is not null
  and AlcoholHistoryCancerBeforeLastThreeMonths is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20COSD%20V9%20UG%20Observation%20Alcohol%20History%20Cancer%20Before%20Last%20Three%20Months%20mapping){: .btn }
### COSD V8 UG Observation Smoking Status Cancer
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` The date the Primary Cancer was confirmed or the Primary Cancer diagnosis was clinically agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
-- Selects SMOKING STATUS (CANCER) for Upper GI (area UG) records in COSD
-- v8.1, routed to the OMOP observation table as a lifestyle / risk-factor
-- attribute.
--
-- The DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) is used as the
-- observation_date.
--
-- Downstream ETL responsibilities:
--   * Resolve NhsNumber against cdm.person to obtain person_id.
--   * Map SmokingStatusCancer (NHS National Code) to the standard
--     observation_concept_id and retain the verbatim code in
--     observation_source_value / value_source_value.
--   * Cast DateOfPrimaryDiagnosisClinicallyAgreed (varchar) to a DATE and
--     assign to observation_date / observation_datetime.
select distinct
    Record ->> '$.UpperGI.UpperGICore.UpperGICoreLinkagePatientId.NHSNumber.@extension'
        as NhsNumber,
    Record ->> '$.UpperGI.UpperGICore.UpperGICoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    Record ->> '$.UpperGI.UpperGICore.UpperGICoreClinicalNurseSpecialistAndRiskFactorAssessments.SmokingStatusCode.@code'
        as SmokingStatusCancer
from omop_staging.cosd_staging_81
where type = 'UG'
  and NhsNumber is not null
  and SmokingStatusCancer is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20COSD%20V8%20UG%20Observation%20Smoking%20Status%20Cancer%20mapping){: .btn }
### COSD V8 UG Observation Asa Physical Status Classification System Code
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` The date the Primary Cancer was confirmed or the Primary Cancer diagnosis was clinically agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
-- Selects ASA PHYSICAL STATUS CLASSIFICATION SYSTEM CODE for Upper GI
-- (area UG) records in COSD v8.1, routed to the OMOP observation table.
-- The ASA grade is a perioperative clinical assessment of the patient's
-- fitness for surgery.
--
-- The DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) is used as the
-- observation_date because no specific assessment date is provided
-- alongside the ASA code in this dataset.
--
-- Downstream ETL responsibilities:
--   * Resolve NhsNumber against cdm.person to obtain person_id.
--   * Map AsaPhysicalStatusClassificationSystemCode (NHS National Code) to
--     the standard observation_concept_id and retain the verbatim code in
--     observation_source_value / value_source_value.
--   * Cast DateOfPrimaryDiagnosisClinicallyAgreed (varchar) to a DATE and
--     assign to observation_date / observation_datetime.
select distinct
    Record ->> '$.UpperGI.UpperGICore.UpperGICoreLinkagePatientId.NHSNumber.@extension'
        as NhsNumber,
    Record ->> '$.UpperGI.UpperGICore.UpperGICoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    Record ->> '$.UpperGI.UpperGICore.UpperGICoreTreatment.UpperGICoreSurgeryAndOtherProcedures.ASAPhysicalStatusClassificationSystemCode.@code'
        as AsaPhysicalStatusClassificationSystemCode
from omop_staging.cosd_staging_81
where type = 'UG'
  and NhsNumber is not null
  and AsaPhysicalStatusClassificationSystemCode is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20COSD%20V8%20UG%20Observation%20Asa%20Physical%20Status%20Classification%20System%20Code%20mapping){: .btn }
### COSD V8 UG Observation Alcohol History Cancer In Last Three Months
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` The date the Primary Cancer was confirmed or the Primary Cancer diagnosis was clinically agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
-- Selects ALCOHOL HISTORY (CANCER IN LAST THREE MONTHS) for Upper GI (area
-- UG) records in COSD v8.1, routed to the OMOP observation table as a
-- lifestyle / risk-factor attribute describing recent alcohol consumption.
--
-- The DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) is used as the
-- observation_date.
--
-- Downstream ETL responsibilities:
--   * Resolve NhsNumber against cdm.person to obtain person_id.
--   * Map AlcoholHistoryCancerInLastThreeMonths (NHS National Code) to the
--     standard observation_concept_id and retain the verbatim code in
--     observation_source_value / value_source_value.
--   * Cast DateOfPrimaryDiagnosisClinicallyAgreed (varchar) to a DATE and
--     assign to observation_date / observation_datetime.
select distinct
    Record ->> '$.UpperGI.UpperGICore.UpperGICoreLinkagePatientId.NHSNumber.@extension'
        as NhsNumber,
    Record ->> '$.UpperGI.UpperGICore.UpperGICoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    Record ->> '$.UpperGI.UpperGICore.UpperGICoreClinicalNurseSpecialistAndRiskFactorAssessments.AlcoholHistoryCancerInLastThreeMonths.@code'
        as AlcoholHistoryCancerInLastThreeMonths
from omop_staging.cosd_staging_81
where type = 'UG'
  and NhsNumber is not null
  and AlcoholHistoryCancerInLastThreeMonths is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20COSD%20V8%20UG%20Observation%20Alcohol%20History%20Cancer%20In%20Last%20Three%20Months%20mapping){: .btn }
### COSD V8 UG Observation Alcohol History Cancer Before Last Three Months
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` The date the Primary Cancer was confirmed or the Primary Cancer diagnosis was clinically agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
-- Selects ALCOHOL HISTORY (CANCER BEFORE LAST THREE MONTHS) for Upper GI
-- (area UG) records in COSD v8.1, routed to the OMOP observation table as
-- a lifestyle / risk-factor attribute describing past alcohol consumption.
--
-- The DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) is used as the
-- observation_date.
--
-- Downstream ETL responsibilities:
--   * Resolve NhsNumber against cdm.person to obtain person_id.
--   * Map AlcoholHistoryCancerBeforeLastThreeMonths (NHS National Code) to
--     the standard observation_concept_id and retain the verbatim code in
--     observation_source_value / value_source_value.
--   * Cast DateOfPrimaryDiagnosisClinicallyAgreed (varchar) to a DATE and
--     assign to observation_date / observation_datetime.
select distinct
    -- NHS NUMBER - patient identifier, mandatory.
    Record ->> '$.UpperGI.UpperGICore.UpperGICoreLinkagePatientId.NHSNumber.@extension'
        as NhsNumber,
    -- DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) - becomes
    -- observation_date / observation_datetime.
    Record ->> '$.UpperGI.UpperGICore.UpperGICoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    -- ALCOHOL HISTORY (CANCER BEFORE LAST THREE MONTHS) - the observation
    -- value; mapped downstream to observation_concept_id and retained as
    -- observation_source_value.
    Record ->> '$.UpperGI.UpperGICore.UpperGICoreClinicalNurseSpecialistAndRiskFactorAssessments.AlcoholHistoryCancerBeforeLastThreeMonths.@code'
        as AlcoholHistoryCancerBeforeLastThreeMonths
from omop_staging.cosd_staging_81
where type = 'UG'
  and NhsNumber is not null
  and AlcoholHistoryCancerBeforeLastThreeMonths is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20COSD%20V8%20UG%20Observation%20Alcohol%20History%20Cancer%20Before%20Last%20Three%20Months%20mapping){: .btn }
### COSD V9 SK Observation Smoking Status Cancer
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` The date the Primary Cancer was confirmed or the Primary Cancer diagnosis was clinically agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
-- Selects SMOKING STATUS (CANCER) for Skin (area SK) records in COSD v9.01,
-- routed to the OMOP observation table as a lifestyle / risk-factor
-- attribute. In v9 this is sourced from TobaccoSmokingStatus.
--
-- The DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) is used as the
-- observation_date.
--
-- Downstream ETL responsibilities:
--   * Resolve NhsNumber against cdm.person to obtain person_id.
--   * Map SmokingStatusCancer (NHS National Code) to the standard
--     observation_concept_id and retain the verbatim code in
--     observation_source_value / value_source_value.
--   * Cast DateOfPrimaryDiagnosisClinicallyAgreed (varchar) to a DATE and
--     assign to observation_date / observation_datetime.
select distinct
    -- NHS NUMBER - patient identifier, mandatory; used to join to cdm.person.
    Record ->> '$.LinkagePatientId.NhsNumber.@extension'
        as NhsNumber,
    -- DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) - becomes
    -- observation_date / observation_datetime.
    Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    -- SMOKING STATUS (CANCER) - the observation value; mapped downstream to
    -- observation_concept_id and retained as observation_source_value.
    Record ->> '$.ClinicalNurseSpecialistAndRiskFactorAssessments.TobaccoSmokingStatus.@code'
        as SmokingStatusCancer
from omop_staging.cosd_staging_901
where type = 'SK'
  and NhsNumber is not null
  and SmokingStatusCancer is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20COSD%20V9%20SK%20Observation%20Smoking%20Status%20Cancer%20mapping){: .btn }
### COSD V9 SK Observation Alcohol History Cancer In Last Three Months
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` The date the Primary Cancer was confirmed or the Primary Cancer diagnosis was clinically agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
-- Selects ALCOHOL HISTORY (CANCER IN LAST THREE MONTHS) for Skin (area SK)
-- records in COSD v9.01, routed to the OMOP observation table as a
-- lifestyle / risk-factor attribute describing recent alcohol consumption
-- history. In v9 this is sourced from HistoryOfAlcoholCurrent.
--
-- The DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) is used as the
-- observation_date.
--
-- Downstream ETL responsibilities:
--   * Resolve NhsNumber against cdm.person to obtain person_id.
--   * Map AlcoholHistoryCancerInLastThreeMonths (NHS National Code) to the
--     standard observation_concept_id and retain the verbatim code in
--     observation_source_value / value_source_value.
--   * Cast DateOfPrimaryDiagnosisClinicallyAgreed (varchar) to a DATE and
--     assign to observation_date / observation_datetime.
select distinct
    -- NHS NUMBER - patient identifier, mandatory; used to join to cdm.person.
    Record ->> '$.LinkagePatientId.NhsNumber.@extension'
        as NhsNumber,
    -- DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) - becomes
    -- observation_date / observation_datetime.
    Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    -- ALCOHOL HISTORY (CANCER IN LAST THREE MONTHS) - the observation
    -- value; mapped downstream to observation_concept_id and retained as
    -- observation_source_value.
    Record ->> '$.ClinicalNurseSpecialistAndRiskFactorAssessments.HistoryOfAlcoholCurrent.@code'
        as AlcoholHistoryCancerInLastThreeMonths
from omop_staging.cosd_staging_901
where type = 'SK'
  and NhsNumber is not null
  and AlcoholHistoryCancerInLastThreeMonths is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20COSD%20V9%20SK%20Observation%20Alcohol%20History%20Cancer%20In%20Last%20Three%20Months%20mapping){: .btn }
### COSD V9 SK Observation Alcohol History Cancer Before Last Three Months
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` The date the Primary Cancer was confirmed or the Primary Cancer diagnosis was clinically agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
-- Selects ALCOHOL HISTORY (CANCER BEFORE LAST THREE MONTHS) for Skin
-- (area SK) records in COSD v9.01, routed to the OMOP observation table as
-- a lifestyle / risk-factor attribute describing past alcohol consumption
-- history. In v9 this is sourced from HistoryOfAlcoholPast.
--
-- The DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) is used as the
-- observation_date.
--
-- Downstream ETL responsibilities:
--   * Resolve NhsNumber against cdm.person to obtain person_id.
--   * Map AlcoholHistoryCancerBeforeLastThreeMonths (NHS National Code) to
--     the standard observation_concept_id and retain the verbatim code in
--     observation_source_value / value_source_value.
--   * Cast DateOfPrimaryDiagnosisClinicallyAgreed (varchar) to a DATE and
--     assign to observation_date / observation_datetime.
select distinct
    -- NHS NUMBER - patient identifier, mandatory; used to join to cdm.person.
    Record ->> '$.LinkagePatientId.NhsNumber.@extension'
        as NhsNumber,
    -- DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) - becomes
    -- observation_date / observation_datetime.
    Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    -- ALCOHOL HISTORY (CANCER BEFORE LAST THREE MONTHS) - the observation
    -- value; mapped downstream to observation_concept_id and retained as
    -- observation_source_value.
    Record ->> '$.ClinicalNurseSpecialistAndRiskFactorAssessments.HistoryOfAlcoholPast.@code'
        as AlcoholHistoryCancerBeforeLastThreeMonths
from omop_staging.cosd_staging_901
where type = 'SK'
  and NhsNumber is not null
  and AlcoholHistoryCancerBeforeLastThreeMonths is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20COSD%20V9%20SK%20Observation%20Alcohol%20History%20Cancer%20Before%20Last%20Three%20Months%20mapping){: .btn }
### COSD V8 SK Observation Smoking Status Cancer
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` The date the Primary Cancer was confirmed or the Primary Cancer diagnosis was clinically agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
-- Selects SMOKING STATUS (CANCER) for Skin (area SK) records in COSD v8.1
-- (Skin core structure), routed to the OMOP observation table as a
-- lifestyle / risk-factor attribute. The source path SmokingStatusCode
-- carries the patient's tobacco smoking status.
--
-- The DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) - held in the
-- Skin core as ClinicalDateCancerDiagnosis - is used as the
-- observation_date.
--
-- Downstream ETL responsibilities:
--   * Resolve NhsNumber against cdm.person to obtain person_id.
--   * Map SmokingStatusCancer (NHS National Code) to the standard
--     observation_concept_id and retain the verbatim code in
--     observation_source_value / value_source_value.
--   * Cast DateOfPrimaryDiagnosisClinicallyAgreed (varchar) to a DATE and
--     assign to observation_date / observation_datetime.
select distinct
    -- NHS NUMBER - patient identifier, mandatory; used to join to cdm.person.
    Record ->> '$.Skin.SkinCore.SkinCoreLinkagePatientId.NHSNumber.@extension'
        as NhsNumber,
    -- DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) - becomes
    -- observation_date / observation_datetime.
    Record ->> '$.Skin.SkinCore.SkinCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    -- SMOKING STATUS (CANCER) - the observation value; mapped downstream to
    -- observation_concept_id and retained as observation_source_value.
    Record ->> '$.Skin.SkinCore.SkinCoreClinicalNurseSpecialistAndRiskFactorAssessments.SmokingStatusCode.@code'
        as SmokingStatusCancer
from omop_staging.cosd_staging_81
where type = 'SK'
  and NhsNumber is not null
  and SmokingStatusCancer is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20COSD%20V8%20SK%20Observation%20Smoking%20Status%20Cancer%20mapping){: .btn }
### COSD V8 SK Observation Alcohol History Cancer In Last Three Months
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` The date the Primary Cancer was confirmed or the Primary Cancer diagnosis was clinically agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
-- Selects ALCOHOL HISTORY (CANCER IN LAST THREE MONTHS) for Skin (area SK)
-- records in COSD v8.1 (Skin core structure), routed to the OMOP observation
-- table as a lifestyle / risk-factor attribute describing recent alcohol
-- consumption history.
--
-- The DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) - held in the
-- Skin core as ClinicalDateCancerDiagnosis - is used as the
-- observation_date.
--
-- Downstream ETL responsibilities:
--   * Resolve NhsNumber against cdm.person to obtain person_id.
--   * Map AlcoholHistoryCancerInLastThreeMonths (NHS National Code) to the
--     standard observation_concept_id and retain the verbatim code in
--     observation_source_value / value_source_value.
--   * Cast DateOfPrimaryDiagnosisClinicallyAgreed (varchar) to a DATE and
--     assign to observation_date / observation_datetime.
select distinct
    -- NHS NUMBER - patient identifier, mandatory; used to join to cdm.person.
    Record ->> '$.Skin.SkinCore.SkinCoreLinkagePatientId.NHSNumber.@extension'
        as NhsNumber,
    -- DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) - becomes
    -- observation_date / observation_datetime.
    Record ->> '$.Skin.SkinCore.SkinCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    -- ALCOHOL HISTORY (CANCER IN LAST THREE MONTHS) - the observation
    -- value; mapped downstream to observation_concept_id and retained as
    -- observation_source_value.
    Record ->> '$.Skin.SkinCore.SkinCoreClinicalNurseSpecialistAndRiskFactorAssessments.AlcoholHistoryCancerInLastThreeMonths.@code'
        as AlcoholHistoryCancerInLastThreeMonths
from omop_staging.cosd_staging_81
where type = 'SK'
  and NhsNumber is not null
  and AlcoholHistoryCancerInLastThreeMonths is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20COSD%20V8%20SK%20Observation%20Alcohol%20History%20Cancer%20In%20Last%20Three%20Months%20mapping){: .btn }
### COSD V8 SK Observation Alcohol History Cancer Before Last Three Months
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` The date the Primary Cancer was confirmed or the Primary Cancer diagnosis was clinically agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
-- Selects ALCOHOL HISTORY (CANCER BEFORE LAST THREE MONTHS) for Skin
-- (area SK) records in COSD v8.1 (Skin core structure), routed to the OMOP
-- observation table as a lifestyle / risk-factor attribute describing past
-- alcohol consumption history.
--
-- The DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) - held in the
-- Skin core as ClinicalDateCancerDiagnosis - is used as the
-- observation_date.
--
-- Downstream ETL responsibilities:
--   * Resolve NhsNumber against cdm.person to obtain person_id.
--   * Map AlcoholHistoryCancerBeforeLastThreeMonths (NHS National Code) to
--     the standard observation_concept_id and retain the verbatim code in
--     observation_source_value / value_source_value.
--   * Cast DateOfPrimaryDiagnosisClinicallyAgreed (varchar) to a DATE and
--     assign to observation_date / observation_datetime.
select distinct
    -- NHS NUMBER - patient identifier, mandatory; used to join to cdm.person.
    Record ->> '$.Skin.SkinCore.SkinCoreLinkagePatientId.NHSNumber.@extension'
        as NhsNumber,
    -- DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) - becomes
    -- observation_date / observation_datetime.
    Record ->> '$.Skin.SkinCore.SkinCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    -- ALCOHOL HISTORY (CANCER BEFORE LAST THREE MONTHS) - the observation
    -- value; mapped downstream to observation_concept_id and retained as
    -- observation_source_value.
    Record ->> '$.Skin.SkinCore.SkinCoreClinicalNurseSpecialistAndRiskFactorAssessments.AlcoholHistoryCancerBeforeLastThreeMonths.@code'
        as AlcoholHistoryCancerBeforeLastThreeMonths
from omop_staging.cosd_staging_81
where type = 'SK'
  and NhsNumber is not null
  and AlcoholHistoryCancerBeforeLastThreeMonths is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20COSD%20V8%20SK%20Observation%20Alcohol%20History%20Cancer%20Before%20Last%20Three%20Months%20mapping){: .btn }
### COSD V9 SA Observation Smoking Status Cancer
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` The date the Primary Cancer was confirmed or the Primary Cancer diagnosis was clinically agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
-- Selects SMOKING STATUS (CANCER) for Sarcoma (area SA) records in COSD
-- v9.01, routed to the OMOP observation table as a lifestyle / risk-factor
-- attribute. The source path TobaccoSmokingStatus carries the patient's
-- tobacco smoking status.
--
-- The DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) is used as the
-- observation_date.
--
-- Downstream ETL responsibilities:
--   * Resolve NhsNumber against cdm.person to obtain person_id.
--   * Map SmokingStatusCancer (NHS National Code) to the standard
--     observation_concept_id and retain the verbatim code in
--     observation_source_value / value_source_value.
--   * Cast DateOfPrimaryDiagnosisClinicallyAgreed (varchar) to a DATE and
--     assign to observation_date / observation_datetime.
select distinct
    -- NHS NUMBER - patient identifier, mandatory; used to join to cdm.person.
    Record ->> '$.LinkagePatientId.NhsNumber.@extension'
        as NhsNumber,
    -- DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) - becomes
    -- observation_date / observation_datetime.
    Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    -- SMOKING STATUS (CANCER) - the observation value; mapped downstream to
    -- observation_concept_id and retained as observation_source_value.
    Record ->> '$.ClinicalNurseSpecialistAndRiskFactorAssessments.TobaccoSmokingStatus.@code'
        as SmokingStatusCancer
from omop_staging.cosd_staging_901
where type = 'SA'
  and NhsNumber is not null
  and SmokingStatusCancer is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20COSD%20V9%20SA%20Observation%20Smoking%20Status%20Cancer%20mapping){: .btn }
### COSD V9 SA Observation Alcohol History Cancer In Last Three Months
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` The date the Primary Cancer was confirmed or the Primary Cancer diagnosis was clinically agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
-- Selects ALCOHOL HISTORY (CANCER IN LAST THREE MONTHS) for Sarcoma (area
-- SA) records in COSD v9.01, routed to the OMOP observation table as a
-- lifestyle / risk-factor attribute describing current alcohol consumption
-- history (source path HistoryOfAlcoholCurrent).
--
-- The DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) is used as the
-- observation_date.
--
-- Downstream ETL responsibilities:
--   * Resolve NhsNumber against cdm.person to obtain person_id.
--   * Map AlcoholHistoryCancerInLastThreeMonths (NHS National Code) to the
--     standard observation_concept_id and retain the verbatim code in
--     observation_source_value / value_source_value.
--   * Cast DateOfPrimaryDiagnosisClinicallyAgreed (varchar) to a DATE and
--     assign to observation_date / observation_datetime.
select distinct
    -- NHS NUMBER - patient identifier, mandatory; used to join to cdm.person.
    Record ->> '$.LinkagePatientId.NhsNumber.@extension'
        as NhsNumber,
    -- DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) - becomes
    -- observation_date / observation_datetime.
    Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    -- ALCOHOL HISTORY (CANCER IN LAST THREE MONTHS) - the observation value;
    -- mapped downstream to observation_concept_id and retained as
    -- observation_source_value.
    Record ->> '$.ClinicalNurseSpecialistAndRiskFactorAssessments.HistoryOfAlcoholCurrent.@code'
        as AlcoholHistoryCancerInLastThreeMonths
from omop_staging.cosd_staging_901
where type = 'SA'
  and NhsNumber is not null
  and AlcoholHistoryCancerInLastThreeMonths is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20COSD%20V9%20SA%20Observation%20Alcohol%20History%20Cancer%20In%20Last%20Three%20Months%20mapping){: .btn }
### COSD V9 SA Observation Alcohol History Cancer Before Last Three Months
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` The date the Primary Cancer was confirmed or the Primary Cancer diagnosis was clinically agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
-- Selects ALCOHOL HISTORY (CANCER BEFORE LAST THREE MONTHS) for Sarcoma
-- (area SA) records in COSD v9.01, routed to the OMOP observation table as a
-- lifestyle / risk-factor attribute describing past alcohol consumption
-- history (source path HistoryOfAlcoholPast).
--
-- The DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) is used as the
-- observation_date.
--
-- Downstream ETL responsibilities:
--   * Resolve NhsNumber against cdm.person to obtain person_id.
--   * Map AlcoholHistoryCancerBeforeLastThreeMonths (NHS National Code) to
--     the standard observation_concept_id and retain the verbatim code in
--     observation_source_value / value_source_value.
--   * Cast DateOfPrimaryDiagnosisClinicallyAgreed (varchar) to a DATE and
--     assign to observation_date / observation_datetime.
select distinct
    -- NHS NUMBER - patient identifier, mandatory; used to join to cdm.person.
    Record ->> '$.LinkagePatientId.NhsNumber.@extension'
        as NhsNumber,
    -- DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) - becomes
    -- observation_date / observation_datetime.
    Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    -- ALCOHOL HISTORY (CANCER BEFORE LAST THREE MONTHS) - the observation
    -- value; mapped downstream to observation_concept_id and retained as
    -- observation_source_value.
    Record ->> '$.ClinicalNurseSpecialistAndRiskFactorAssessments.HistoryOfAlcoholPast.@code'
        as AlcoholHistoryCancerBeforeLastThreeMonths
from omop_staging.cosd_staging_901
where type = 'SA'
  and NhsNumber is not null
  and AlcoholHistoryCancerBeforeLastThreeMonths is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20COSD%20V9%20SA%20Observation%20Alcohol%20History%20Cancer%20Before%20Last%20Three%20Months%20mapping){: .btn }
### COSD V8 SA Observation Smoking Status Cancer
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` The date the Primary Cancer was confirmed or the Primary Cancer diagnosis was clinically agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
-- Selects SMOKING STATUS (CANCER) for Sarcoma (area SA) records in COSD v8.1
-- (Sarcoma core structure), routed to the OMOP observation table as a
-- lifestyle / risk-factor attribute. The source path SmokingStatusCode
-- carries the patient's tobacco smoking status.
--
-- The DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) - held in the
-- Sarcoma core as ClinicalDateCancerDiagnosis - is used as the
-- observation_date.
--
-- Downstream ETL responsibilities:
--   * Resolve NhsNumber against cdm.person to obtain person_id.
--   * Map SmokingStatusCancer (NHS National Code) to the standard
--     observation_concept_id and retain the verbatim code in
--     observation_source_value / value_source_value.
--   * Cast DateOfPrimaryDiagnosisClinicallyAgreed (varchar) to a DATE and
--     assign to observation_date / observation_datetime.
select distinct
    -- NHS NUMBER - patient identifier, mandatory; used to join to cdm.person.
    Record ->> '$.Sarcoma.SarcomaCore.SarcomaCoreLinkagePatientId.NHSNumber.@extension'
        as NhsNumber,
    -- DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) - becomes
    -- observation_date / observation_datetime.
    Record ->> '$.Sarcoma.SarcomaCore.SarcomaCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    -- SMOKING STATUS (CANCER) - the observation value; mapped downstream to
    -- observation_concept_id and retained as observation_source_value.
    Record ->> '$.Sarcoma.SarcomaCore.SarcomaCoreClinicalNurseSpecialistAndRiskFactorAssessments.SmokingStatusCode.@code'
        as SmokingStatusCancer
from omop_staging.cosd_staging_81
where type = 'SA'
  and NhsNumber is not null
  and SmokingStatusCancer is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20COSD%20V8%20SA%20Observation%20Smoking%20Status%20Cancer%20mapping){: .btn }
### COSD V8 SA Observation Alcohol History Cancer In Last Three Months
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` The date the Primary Cancer was confirmed or the Primary Cancer diagnosis was clinically agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
-- Selects ALCOHOL HISTORY (CANCER IN LAST THREE MONTHS) for Sarcoma (area
-- SA) records in COSD v8.1 (Sarcoma core structure), routed to the OMOP
-- observation table as a lifestyle / risk-factor attribute describing
-- current alcohol consumption history.
--
-- The DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) - held in the
-- Sarcoma core as ClinicalDateCancerDiagnosis - is used as the
-- observation_date.
--
-- Downstream ETL responsibilities:
--   * Resolve NhsNumber against cdm.person to obtain person_id.
--   * Map AlcoholHistoryCancerInLastThreeMonths (NHS National Code) to the
--     standard observation_concept_id and retain the verbatim code in
--     observation_source_value / value_source_value.
--   * Cast DateOfPrimaryDiagnosisClinicallyAgreed (varchar) to a DATE and
--     assign to observation_date / observation_datetime.
select distinct
    -- NHS NUMBER - patient identifier, mandatory; used to join to cdm.person.
    Record ->> '$.Sarcoma.SarcomaCore.SarcomaCoreLinkagePatientId.NHSNumber.@extension'
        as NhsNumber,
    -- DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) - becomes
    -- observation_date / observation_datetime.
    Record ->> '$.Sarcoma.SarcomaCore.SarcomaCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    -- ALCOHOL HISTORY (CANCER IN LAST THREE MONTHS) - the observation value;
    -- mapped downstream to observation_concept_id and retained as
    -- observation_source_value.
    Record ->> '$.Sarcoma.SarcomaCore.SarcomaCoreClinicalNurseSpecialistAndRiskFactorAssessments.AlcoholHistoryCancerInLastThreeMonths.@code'
        as AlcoholHistoryCancerInLastThreeMonths
from omop_staging.cosd_staging_81
where type = 'SA'
  and NhsNumber is not null
  and AlcoholHistoryCancerInLastThreeMonths is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20COSD%20V8%20SA%20Observation%20Alcohol%20History%20Cancer%20In%20Last%20Three%20Months%20mapping){: .btn }
### COSD V8 SA Observation Alcohol History Cancer Before Last Three Months
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` The date the Primary Cancer was confirmed or the Primary Cancer diagnosis was clinically agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
-- Selects ALCOHOL HISTORY (CANCER BEFORE LAST THREE MONTHS) for Sarcoma
-- (area SA) records in COSD v8.1 (Sarcoma core structure), routed to the
-- OMOP observation table as a lifestyle / risk-factor attribute describing
-- past alcohol consumption history.
--
-- The DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) - held in the
-- Sarcoma core as ClinicalDateCancerDiagnosis - is used as the
-- observation_date.
--
-- Downstream ETL responsibilities:
--   * Resolve NhsNumber against cdm.person to obtain person_id.
--   * Map AlcoholHistoryCancerBeforeLastThreeMonths (NHS National Code) to
--     the standard observation_concept_id and retain the verbatim code in
--     observation_source_value / value_source_value.
--   * Cast DateOfPrimaryDiagnosisClinicallyAgreed (varchar) to a DATE and
--     assign to observation_date / observation_datetime.
select distinct
    -- NHS NUMBER - patient identifier, mandatory; used to join to cdm.person.
    Record ->> '$.Sarcoma.SarcomaCore.SarcomaCoreLinkagePatientId.NHSNumber.@extension'
        as NhsNumber,
    -- DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) - becomes
    -- observation_date / observation_datetime.
    Record ->> '$.Sarcoma.SarcomaCore.SarcomaCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    -- ALCOHOL HISTORY (CANCER BEFORE LAST THREE MONTHS) - the observation
    -- value; mapped downstream to observation_concept_id and retained as
    -- observation_source_value.
    Record ->> '$.Sarcoma.SarcomaCore.SarcomaCoreClinicalNurseSpecialistAndRiskFactorAssessments.AlcoholHistoryCancerBeforeLastThreeMonths.@code'
        as AlcoholHistoryCancerBeforeLastThreeMonths
from omop_staging.cosd_staging_81
where type = 'SA'
  and NhsNumber is not null
  and AlcoholHistoryCancerBeforeLastThreeMonths is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20COSD%20V8%20SA%20Observation%20Alcohol%20History%20Cancer%20Before%20Last%20Three%20Months%20mapping){: .btn }
### COSD V9 LV Observation Smoking Status Cancer
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` The date the Primary Cancer was confirmed or the Primary Cancer diagnosis was clinically agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
-- Selects SMOKING STATUS (CANCER) for Liver (area LV) records in COSD v9.01,
-- routed to the OMOP observation table as a lifestyle / risk-factor
-- attribute. The source path TobaccoSmokingStatus carries the patient's
-- tobacco smoking status.
--
-- The DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) is used as the
-- observation_date.
--
-- Downstream ETL responsibilities:
--   * Resolve NhsNumber against cdm.person to obtain person_id.
--   * Map SmokingStatusCancer (NHS National Code) to the standard
--     observation_concept_id and retain the verbatim code in
--     observation_source_value / value_source_value.
--   * Cast DateOfPrimaryDiagnosisClinicallyAgreed (varchar) to a DATE and
--     assign to observation_date / observation_datetime.
select distinct
    -- NHS NUMBER - patient identifier, mandatory; used to join to cdm.person.
    Record ->> '$.LinkagePatientId.NhsNumber.@extension'
        as NhsNumber,
    -- DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) - becomes
    -- observation_date / observation_datetime.
    Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    -- SMOKING STATUS (CANCER) - the observation value; mapped downstream to
    -- observation_concept_id and retained as observation_source_value.
    Record ->> '$.ClinicalNurseSpecialistAndRiskFactorAssessments.TobaccoSmokingStatus.@code'
        as SmokingStatusCancer
from omop_staging.cosd_staging_901
where type = 'LV'
  and NhsNumber is not null
  and SmokingStatusCancer is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20COSD%20V9%20LV%20Observation%20Smoking%20Status%20Cancer%20mapping){: .btn }
### COSD V9 LV Observation Performance Status Adult
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` The date the Primary Cancer was confirmed or the Primary Cancer diagnosis was clinically agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
-- Selects PERFORMANCE STATUS (ADULT) for Liver (area LV) records in COSD
-- v9.01, routed to the OMOP observation table. This WHO performance status
-- is a clinical assessment of the patient's functional status.
--
-- The DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) is used as the
-- observation_date.
--
-- Downstream ETL responsibilities:
--   * Resolve NhsNumber against cdm.person to obtain person_id.
--   * Map PerformanceStatusAdult (NHS National Code) to the standard
--     observation_concept_id and retain the verbatim code in
--     observation_source_value / value_source_value.
--   * Cast DateOfPrimaryDiagnosisClinicallyAgreed (varchar) to a DATE and
--     assign to observation_date / observation_datetime.
select distinct
    -- NHS NUMBER - patient identifier, mandatory; used to join to cdm.person.
    Record ->> '$.LinkagePatientId.NhsNumber.@extension'
        as NhsNumber,
    -- DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) - becomes
    -- observation_date / observation_datetime.
    Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    -- PERFORMANCE STATUS (ADULT) - the observation value; mapped downstream
    -- to observation_concept_id and retained as observation_source_value.
    Record ->> '$.PrimaryPathway.Diagnosis.PerformanceStatusAdult.@code'
        as PerformanceStatusAdult
from omop_staging.cosd_staging_901
where type = 'LV'
  and NhsNumber is not null
  and PerformanceStatusAdult is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20COSD%20V9%20LV%20Observation%20Performance%20Status%20Adult%20mapping){: .btn }
### COSD V9 LV Observation Familial Cancer Syndrome Indicator
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` The date the Primary Cancer was confirmed or the Primary Cancer diagnosis was clinically agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
-- Selects FAMILIAL CANCER SYNDROME INDICATOR for Liver (area LV) records in
-- COSD v9.01, routed to the OMOP observation table as a family-history /
-- risk attribute (source path FamilialCancerSyndrome).
--
-- The DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) is used as the
-- observation_date.
--
-- Downstream ETL responsibilities:
--   * Resolve NhsNumber against cdm.person to obtain person_id.
--   * Map FamilialCancerSyndromeIndicator (NHS National Code) to the
--     standard observation_concept_id and retain the verbatim code in
--     observation_source_value / value_source_value.
--   * Cast DateOfPrimaryDiagnosisClinicallyAgreed (varchar) to a DATE and
--     assign to observation_date / observation_datetime.
select distinct
    -- NHS NUMBER - patient identifier, mandatory; used to join to cdm.person.
    Record ->> '$.LinkagePatientId.NhsNumber.@extension'
        as NhsNumber,
    -- DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) - becomes
    -- observation_date / observation_datetime.
    Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    -- FAMILIAL CANCER SYNDROME INDICATOR - the observation value; mapped
    -- downstream to observation_concept_id and retained as
    -- observation_source_value.
    Record ->> '$.PrimaryPathway.Diagnosis.DiagnosisAdditionalItems.FamilialCancerSyndrome.@code'
        as FamilialCancerSyndromeIndicator
from omop_staging.cosd_staging_901
where type = 'LV'
  and NhsNumber is not null
  and FamilialCancerSyndromeIndicator is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20COSD%20V9%20LV%20Observation%20Familial%20Cancer%20Syndrome%20Indicator%20mapping){: .btn }
### COSD V9 LV Observation Cancer Treatment Intent
Source column  `TreatmentStartDateCancer`.
Converts text to dates.

* `TreatmentStartDateCancer` The start date of a cancer treatment during a Cancer Care Spell. [TREATMENT START DATE (CANCER)](https://www.datadictionary.nhs.uk/data_elements/treatment_start_date__cancer_.html)

```sql
-- Selects CANCER TREATMENT INTENT for Liver (area LV) records in COSD v9.01,
-- routed to the OMOP observation table. Each record's Treatment array
-- carries one (intent, start date) pair per entry, so the JSON paths are
-- unnested in lockstep so each treatment intent keeps its own start date.
-- The first element of each array list covers the singular-object encoding
-- and the second the JSON-array encoding.
--
-- The TREATMENT START DATE (CANCER) is used as the observation_date.
--
-- Downstream ETL responsibilities:
--   * Resolve NhsNumber against cdm.person to obtain person_id.
--   * Map CancerTreatmentIntent (NHS National Code) to the standard
--     observation_concept_id and retain the verbatim code in
--     observation_source_value / value_source_value.
--   * Cast TreatmentStartDateCancer (varchar) to a DATE and assign to
--     observation_date / observation_datetime.
with lv as (
    select
        -- NHS NUMBER - patient identifier, mandatory; joins to cdm.person.
        Record ->> '$.LinkagePatientId.NhsNumber.@extension'
            as NhsNumber,
        -- CANCER TREATMENT INTENT - the observation value; unnested in
        -- lockstep with the treatment start date.
        unnest([
            [Record ->> '$.Treatment.CancerTreatmentIntent.@code'],
            Record ->> '$.Treatment[*].CancerTreatmentIntent.@code'
        ], recursive := true) as CancerTreatmentIntent,
        -- TREATMENT START DATE (CANCER) - becomes observation_date /
        -- observation_datetime. Paired one-to-one with CancerTreatmentIntent.
        unnest([
            [Record ->> '$.Treatment.TreatmentStartDateCancer'],
            Record ->> '$.Treatment[*].TreatmentStartDateCancer'
        ], recursive := true) as TreatmentStartDateCancer
    from omop_staging.cosd_staging_901
    where type = 'LV'
)
select distinct
    NhsNumber,
    TreatmentStartDateCancer,
    CancerTreatmentIntent
from lv
where NhsNumber is not null
  and CancerTreatmentIntent is not null
  and TreatmentStartDateCancer is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20COSD%20V9%20LV%20Observation%20Cancer%20Treatment%20Intent%20mapping){: .btn }
### COSD V8 LV Observation Performance Status Adult
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` The date the Primary Cancer was confirmed or the Primary Cancer diagnosis was clinically agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
-- Selects PERFORMANCE STATUS (ADULT) for Liver (area LV) records in COSD
-- v8.1 (Liver core structure), routed to the OMOP observation table. This
-- WHO performance status is a clinical assessment of the patient's
-- functional status.
--
-- The DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) - held in the
-- Liver core as ClinicalDateCancerDiagnosis - is used as the
-- observation_date.
--
-- Downstream ETL responsibilities:
--   * Resolve NhsNumber against cdm.person to obtain person_id.
--   * Map PerformanceStatusAdult (NHS National Code) to the standard
--     observation_concept_id and retain the verbatim code in
--     observation_source_value / value_source_value.
--   * Cast DateOfPrimaryDiagnosisClinicallyAgreed (varchar) to a DATE and
--     assign to observation_date / observation_datetime.
select distinct
    -- NHS NUMBER - patient identifier, mandatory; used to join to cdm.person.
    Record ->> '$.Liver.LiverCore.LiverCoreLinkagePatientId.NHSNumber.@extension'
        as NhsNumber,
    -- DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) - becomes
    -- observation_date / observation_datetime.
    Record ->> '$.Liver.LiverCore.LiverCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    -- PERFORMANCE STATUS (ADULT) - the observation value; mapped downstream
    -- to observation_concept_id and retained as observation_source_value.
    Record ->> '$.Liver.LiverCore.LiverCoreDiagnosis.AdultPerformanceStatus.@code'
        as PerformanceStatusAdult
from omop_staging.cosd_staging_81
where type = 'LV'
  and NhsNumber is not null
  and PerformanceStatusAdult is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20COSD%20V8%20LV%20Observation%20Performance%20Status%20Adult%20mapping){: .btn }
### COSD V8 LV Observation Cancer Treatment Intent
Source column  `TreatmentStartDateCancer`.
Converts text to dates.

* `TreatmentStartDateCancer` The start date of a cancer treatment during a Cancer Care Spell. [TREATMENT START DATE (CANCER)](https://www.datadictionary.nhs.uk/data_elements/treatment_start_date__cancer_.html)

```sql
-- Selects CANCER TREATMENT INTENT for Liver (area LV) records in COSD v8.1
-- (Liver core structure), routed to the OMOP observation table. The Liver
-- core Treatment section is a repeating array, so the intent and its
-- associated TREATMENT START DATE (CANCER) are unnested in lockstep: the
-- first element of each array list covers the singular-object encoding and
-- the second the JSON-array encoding, keeping each intent paired with its
-- own start date.
--
-- The TREATMENT START DATE (CANCER) is used as the observation_date because
-- the treatment intent is recorded against an individual treatment event.
--
-- Downstream ETL responsibilities:
--   * Resolve NhsNumber against cdm.person to obtain person_id.
--   * Map CancerTreatmentIntent (NHS National Code) to the standard
--     observation_concept_id and retain the verbatim code in
--     observation_source_value / value_source_value.
--   * Cast TreatmentStartDateCancer (varchar) to a DATE and assign to
--     observation_date / observation_datetime.
with lv as (
    select
        -- NHS NUMBER - patient identifier, mandatory; joins to cdm.person.
        Record ->> '$.Liver.LiverCore.LiverCoreLinkagePatientId.NHSNumber.@extension'
            as NhsNumber,
        -- CANCER TREATMENT INTENT - unnested in lockstep with the start date;
        -- the observation value mapped downstream to observation_concept_id.
        unnest(
            [
                [ Record ->> '$.Liver.LiverCore.LiverCoreTreatment.CancerTreatmentIntent.@code' ],
                Record ->> '$.Liver.LiverCore.LiverCoreTreatment[*].CancerTreatmentIntent.@code'
            ],
            recursive := true
        ) as CancerTreatmentIntent,
        -- TREATMENT START DATE (CANCER) - unnested in lockstep with the
        -- intent; becomes observation_date / observation_datetime.
        unnest(
            [
                [ Record ->> '$.Liver.LiverCore.LiverCoreTreatment.CancerTreatmentStartDate' ],
                Record ->> '$.Liver.LiverCore.LiverCoreTreatment[*].CancerTreatmentStartDate'
            ],
            recursive := true
        ) as TreatmentStartDateCancer
    from omop_staging.cosd_staging_81
    where type = 'LV'
)
select distinct
    NhsNumber,
    TreatmentStartDateCancer,
    CancerTreatmentIntent
from lv
where NhsNumber is not null
  and CancerTreatmentIntent is not null
  and TreatmentStartDateCancer is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20COSD%20V8%20LV%20Observation%20Cancer%20Treatment%20Intent%20mapping){: .btn }
### CosdV9LungTobaccoSmokingStatus
* Value copied from `Date`

* `Date` Observation date [DATE FIRST SEEN](https://www.datadictionary.nhs.uk/data_elements/date_first_seen.html), [DATE FIRST SEEN (CANCER SPECIALIST)](https://www.datadictionary.nhs.uk/data_elements/date_first_seen__cancer_specialist_.html), [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html), [TNM STAGE GROUPING DATE (FINAL PRETREATMENT)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping_date__final_pretreatment_.html), [TNM STAGE GROUPING DATE (INTEGRATED)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping_date__integrated_.html), [TREATMENT START DATE (CANCER)](https://www.datadictionary.nhs.uk/data_elements/treatment_start_date__cancer_.html), [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

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
        Record ->> '$.ClinicalNurseSpecialistAndRiskFactorAssessments.TobaccoSmokingStatus.@code' as TobaccoSmokingStatus,
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber
    from omop_staging.cosd_staging_901
    where type = 'LU'
)
select
    distinct
        TobaccoSmokingStatus,
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
where o.TobaccoSmokingStatus is not null
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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20CosdV9LungTobaccoSmokingStatus%20mapping){: .btn }
### CosdV9LungTobaccoSmokingCessation
* Value copied from `Date`

* `Date` Observation date [DATE FIRST SEEN](https://www.datadictionary.nhs.uk/data_elements/date_first_seen.html), [DATE FIRST SEEN (CANCER SPECIALIST)](https://www.datadictionary.nhs.uk/data_elements/date_first_seen__cancer_specialist_.html), [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html), [TNM STAGE GROUPING DATE (FINAL PRETREATMENT)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping_date__final_pretreatment_.html), [TNM STAGE GROUPING DATE (INTEGRATED)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping_date__integrated_.html), [TREATMENT START DATE (CANCER)](https://www.datadictionary.nhs.uk/data_elements/treatment_start_date__cancer_.html), [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

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
        Record ->> '$.ClinicalNurseSpecialistAndRiskFactorAssessments.TobaccoSmokingCessation.@code' as TobaccoSmokingCessation,
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber
    from omop_staging.cosd_staging_901
    where type = 'LU'
)
select
    distinct
        TobaccoSmokingCessation,
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
where o.TobaccoSmokingCessation is not null
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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20CosdV9LungTobaccoSmokingCessation%20mapping){: .btn }
### CosdV9LungSurgicalAccessType
* Value copied from `Date`

* `Date` Observation date [DATE FIRST SEEN](https://www.datadictionary.nhs.uk/data_elements/date_first_seen.html), [DATE FIRST SEEN (CANCER SPECIALIST)](https://www.datadictionary.nhs.uk/data_elements/date_first_seen__cancer_specialist_.html), [DIAGNOSIS DATE (CLINICALLY AGREED)](), [STAGE DATE (FINAL PRETREATMENT STAGE)](), [STAGE DATE (INTEGRATED STAGE)](), [TREATMENT START DATE (CANCER)](https://www.datadictionary.nhs.uk/data_elements/treatment_start_date__cancer_.html), [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

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
        Record ->> '$.Treatment.Surgery.SurgicalAccessType.@code' as SurgicalAccessType,
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber
    from omop_staging.cosd_staging_901
    where type = 'LU'
)
select
    distinct
        SurgicalAccessType,
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
where o.SurgicalAccessType is not null
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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20CosdV9LungSurgicalAccessType%20mapping){: .btn }
### CosdV9LungSourceOfReferralForOutpatients
* Value copied from `Date`

* `Date` Observation date [DATE FIRST SEEN](https://www.datadictionary.nhs.uk/data_elements/date_first_seen.html), [DATE FIRST SEEN (CANCER SPECIALIST)](https://www.datadictionary.nhs.uk/data_elements/date_first_seen__cancer_specialist_.html), [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html), [TNM STAGE GROUPING DATE (FINAL PRETREATMENT)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping_date__final_pretreatment_.html), [TNM STAGE GROUPING DATE (INTEGRATED)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping_date__integrated_.html), [TREATMENT START DATE (CANCER)](https://www.datadictionary.nhs.uk/data_elements/treatment_start_date__cancer_.html), [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

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
        Record ->> '$.PrimaryPathway.ReferralAndFirstStageOfPatientPathway.SourceOfReferralForOut-patients.@code' as SourceOfReferralForOutpatients,
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber
    from omop_staging.cosd_staging_901
    where type = 'LU'
)
select
    distinct
        SourceOfReferralForOutpatients,
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
where o.SourceOfReferralForOutpatients is not null
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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20CosdV9LungSourceOfReferralForOutpatients%20mapping){: .btn }
### CosdV9LungSourceOfReferralForNonPrimaryCancerPathway
* Value copied from `Date`

* `Date` Observation date [DATE FIRST SEEN](https://www.datadictionary.nhs.uk/data_elements/date_first_seen.html), [DATE FIRST SEEN (CANCER SPECIALIST)](https://www.datadictionary.nhs.uk/data_elements/date_first_seen__cancer_specialist_.html), [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html), [TNM STAGE GROUPING DATE (FINAL PRETREATMENT)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping_date__final_pretreatment_.html), [TNM STAGE GROUPING DATE (INTEGRATED)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping_date__integrated_.html), [TREATMENT START DATE (CANCER)](https://www.datadictionary.nhs.uk/data_elements/treatment_start_date__cancer_.html), [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

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
        Record ->> '$.NonPrimaryPathway.NonPrimaryCancerPathwayReferral.SourceOfReferralForNonPrimaryCancerPathway.@code' as SourceOfReferralForNonPrimaryCancerPathway,
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber
    from omop_staging.cosd_staging_901
    where type = 'LU'
)
select
    distinct
        SourceOfReferralForNonPrimaryCancerPathway,
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
where o.SourceOfReferralForNonPrimaryCancerPathway is not null
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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20CosdV9LungSourceOfReferralForNonPrimaryCancerPathway%20mapping){: .btn }
### CosdV9LungPerformanceStatusAdult
* Value copied from `Date`

* `Date` Observation date [DATE FIRST SEEN](https://www.datadictionary.nhs.uk/data_elements/date_first_seen.html), [DATE FIRST SEEN (CANCER SPECIALIST)](https://www.datadictionary.nhs.uk/data_elements/date_first_seen__cancer_specialist_.html), [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html), [TNM STAGE GROUPING DATE (FINAL PRETREATMENT)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping_date__final_pretreatment_.html), [TNM STAGE GROUPING DATE (INTEGRATED)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping_date__integrated_.html), [TREATMENT START DATE (CANCER)](https://www.datadictionary.nhs.uk/data_elements/treatment_start_date__cancer_.html), [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

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
        Record ->> '$.PrimaryPathway.Diagnosis.PerformanceStatusAdult.@code' as PerformanceStatusAdult,
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber
    from omop_staging.cosd_staging_901
    where type = 'LU'
)
select
    distinct
        PerformanceStatusAdult,
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
where o.PerformanceStatusAdult is not null
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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20CosdV9LungPerformanceStatusAdult%20mapping){: .btn }
### CosdV9LungMenopausalStatus
* Value copied from `Date`

* `Date` Observation date [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html), [TREATMENT START DATE (CANCER)](https://www.datadictionary.nhs.uk/data_elements/treatment_start_date__cancer_.html), [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

```sql
with LU as (
    select
        Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed' as DateOfPrimaryDiagnosisClinicallyAgreed,
        Record ->> '$.Treatment.TreatmentStartDateCancer' as TreatmentStartDateCancer,
        Record ->> '$.Treatment.Surgery.ProcedureDate' as ProcedureDate,
        Record ->> '$.ClinicalNurseSpecialistAndRiskFactorAssessments.MenopausalStatus.@code' as MenopausalStatus,
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber
    from omop_staging.cosd_staging_901
    where type = 'LU'
)
select
    distinct
        MenopausalStatus,
        NhsNumber,
        least(
            cast(DateOfPrimaryDiagnosisClinicallyAgreed as date),
            cast(TreatmentStartDateCancer as date),
            cast(ProcedureDate as date)
        ) as Date
from LU o
where o.MenopausalStatus is not null
  and not (
        DateOfPrimaryDiagnosisClinicallyAgreed is null and
        TreatmentStartDateCancer is null and
        ProcedureDate is null
    )
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20CosdV9LungMenopausalStatus%20mapping){: .btn }
### CosdV9LungHistoryOfAlcoholPast
* Value copied from `Date`

* `Date` Observation date [DATE FIRST SEEN](https://www.datadictionary.nhs.uk/data_elements/date_first_seen.html), [DATE FIRST SEEN (CANCER SPECIALIST)](https://www.datadictionary.nhs.uk/data_elements/date_first_seen__cancer_specialist_.html), [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html), [TNM STAGE GROUPING DATE (FINAL PRETREATMENT)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping_date__final_pretreatment_.html), [TNM STAGE GROUPING DATE (INTEGRATED)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping_date__integrated_.html), [TREATMENT START DATE (CANCER)](https://www.datadictionary.nhs.uk/data_elements/treatment_start_date__cancer_.html), [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

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
        Record ->> '$.ClinicalNurseSpecialistAndRiskFactorAssessments.HistoryOfAlcoholPast.@code' as HistoryOfAlcoholPast,
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber
    from omop_staging.cosd_staging_901
    where type = 'LU'
)
select
    distinct
        HistoryOfAlcoholPast,
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
where o.HistoryOfAlcoholPast is not null
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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20CosdV9LungHistoryOfAlcoholPast%20mapping){: .btn }
### CosdV9LungHistoryOfAlcoholCurrent
* Value copied from `Date`

* `Date` Observation date [DATE FIRST SEEN](https://www.datadictionary.nhs.uk/data_elements/date_first_seen.html), [DATE FIRST SEEN (CANCER SPECIALIST)](https://www.datadictionary.nhs.uk/data_elements/date_first_seen__cancer_specialist_.html), [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html), [TNM STAGE GROUPING DATE (FINAL PRETREATMENT)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping_date__final_pretreatment_.html), [TNM STAGE GROUPING DATE (INTEGRATED)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping_date__integrated_.html), [TREATMENT START DATE (CANCER)](https://www.datadictionary.nhs.uk/data_elements/treatment_start_date__cancer_.html), [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

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
        Record ->> '$.ClinicalNurseSpecialistAndRiskFactorAssessments.HistoryOfAlcoholCurrent.@code' as HistoryOfAlcoholCurrent,
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber
    from omop_staging.cosd_staging_901
    where type = 'LU'
)
select
    distinct
        HistoryOfAlcoholCurrent,
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
where o.HistoryOfAlcoholCurrent is not null
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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20CosdV9LungHistoryOfAlcoholCurrent%20mapping){: .btn }
### CosdV9LungFamilialCancerSyndrome
* Value copied from `Date`

* `Date` Observation date [DATE FIRST SEEN](https://www.datadictionary.nhs.uk/data_elements/date_first_seen.html), [DATE FIRST SEEN (CANCER SPECIALIST)](https://www.datadictionary.nhs.uk/data_elements/date_first_seen__cancer_specialist_.html), [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html), [TNM STAGE GROUPING DATE (FINAL PRETREATMENT)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping_date__final_pretreatment_.html), [TNM STAGE GROUPING DATE (INTEGRATED)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping_date__integrated_.html), [TREATMENT START DATE (CANCER)](https://www.datadictionary.nhs.uk/data_elements/treatment_start_date__cancer_.html), [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

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
        Record ->> '$.PrimaryPathway.Diagnosis.DiagnosisAdditionalItems.FamilialCancerSyndrome.@code' as FamilialCancerSyndrome,
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber
    from omop_staging.cosd_staging_901
    where type = 'LU'
)
select
    distinct
        FamilialCancerSyndrome,
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
where o.FamilialCancerSyndrome is not null
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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20CosdV9LungFamilialCancerSyndrome%20mapping){: .btn }
### CosdV9LungFamilialCancerSyndromeSubsidiaryComment
* Value copied from `Date`

* `Date` Observation date [DATE FIRST SEEN](https://www.datadictionary.nhs.uk/data_elements/date_first_seen.html), [DATE FIRST SEEN (CANCER SPECIALIST)](https://www.datadictionary.nhs.uk/data_elements/date_first_seen__cancer_specialist_.html), [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html), [TNM STAGE GROUPING DATE (FINAL PRETREATMENT)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping_date__final_pretreatment_.html), [TNM STAGE GROUPING DATE (INTEGRATED)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping_date__integrated_.html), [TREATMENT START DATE (CANCER)](https://www.datadictionary.nhs.uk/data_elements/treatment_start_date__cancer_.html), [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

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
        Record ->> '$.PrimaryPathway.Diagnosis.DiagnosisAdditionalItems.FamilialCancerSyndromeSubsidiaryComment.#cdata-section' as FamilialCancerSyndromeSubsidiaryComment,
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber
    from omop_staging.cosd_staging_901
    where type = 'LU'
)
select
    distinct
        FamilialCancerSyndromeSubsidiaryComment,
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
where o.FamilialCancerSyndromeSubsidiaryComment is not null
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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20CosdV9LungFamilialCancerSyndromeSubsidiaryComment%20mapping){: .btn }
### CosdV9LungAsaScore
* Value copied from `Date`

* `Date` Observation date [DATE FIRST SEEN](https://www.datadictionary.nhs.uk/data_elements/date_first_seen.html), [DATE FIRST SEEN (CANCER SPECIALIST)](https://www.datadictionary.nhs.uk/data_elements/date_first_seen__cancer_specialist_.html), [DIAGNOSIS DATE](https://www.datadictionary.nhs.uk/data_elements/diagnosis_date.html), [TNM STAGE GROUPING DATE (INTEGRATED)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping_date__integrated_.html), [TNM STAGE GROUPING DATE (FINAL PRETREATMENT)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping_date__final_pretreatment_.html), [TREATMENT START DATE (CANCER)](https://www.datadictionary.nhs.uk/data_elements/treatment_start_date__cancer_.html), [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

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
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber
    from omop_staging.cosd_staging_901
    where type = 'LU'
)
select
    distinct
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
where not (
        DateFirstSeen is null and
        DateFirstSeenCancerSpecialist is null and
        DateOfPrimaryDiagnosisClinicallyAgreed is null and
        StageDateFinalPretreatmentStage is null and
        StageDateIntegratedStage is null and
        TreatmentStartDateCancer is null and
        ProcedureDate is null
    )
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20CosdV9LungAsaScore%20mapping){: .btn }
### CosdV9LungAdultComorbidityEvaluation
* Value copied from `Date`

* `Date` Observation date [DATE FIRST SEEN](https://www.datadictionary.nhs.uk/data_elements/date_first_seen.html), [DATE FIRST SEEN (CANCER SPECIALIST)](https://www.datadictionary.nhs.uk/data_elements/date_first_seen__cancer_specialist_.html), [DIAGNOSIS DATE](https://www.datadictionary.nhs.uk/data_elements/diagnosis_date.html), [TNM STAGE GROUPING DATE (INTEGRATED)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping_date__integrated_.html), [TNM STAGE GROUPING DATE (FINAL PRETREATMENT)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping_date__final_pretreatment_.html), [TREATMENT START DATE (CANCER)](https://www.datadictionary.nhs.uk/data_elements/treatment_start_date__cancer_.html), [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

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
        Record ->> '$.CancerCarePlan.AdultComorbidityEvaluation-27Score.@code' as AdultComorbidityEvaluation,
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber
    from omop_staging.cosd_staging_901
    where type = 'LU'
)
select
    distinct
        AdultComorbidityEvaluation,
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
where o.AdultComorbidityEvaluation is not null
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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20CosdV9LungAdultComorbidityEvaluation%20mapping){: .btn }
### CosdV8LungSurgicalAccessType
* Value copied from `Date`

* `Date` Observation date [DATE FIRST SEEN](https://www.datadictionary.nhs.uk/data_elements/date_first_seen.html), [DATE FIRST SEEN (CANCER SPECIALIST)](https://www.datadictionary.nhs.uk/data_elements/date_first_seen__cancer_specialist_.html), [DIAGNOSIS DATE](https://www.datadictionary.nhs.uk/data_elements/diagnosis_date.html), [TNM STAGE GROUPING DATE (INTEGRATED)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping_date__integrated_.html), [TNM STAGE GROUPING DATE (FINAL PRETREATMENT)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping_date__final_pretreatment_.html), [TREATMENT START DATE (CANCER)](https://www.datadictionary.nhs.uk/data_elements/treatment_start_date__cancer_.html), [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

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
        Record ->> '$.Lung.LungCore.LungCoreTreatment.LungCoreSurgeryAndOtherProcedures.SurgicalAccessType.@code' as SurgicalAccessType,
        Record ->> '$.Lung.LungCore.LungCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber
    from omop_staging.cosd_staging_81
    where Type = 'LU'
)
select
      distinct
          SurgicalAccessType,
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
where o.SurgicalAccessType is not null
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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20CosdV8LungSurgicalAccessType%20mapping){: .btn }
### CosdV8LungSourceOfReferralOutPatients
* Value copied from `Date`

* `Date` Observation date [DATE FIRST SEEN](https://www.datadictionary.nhs.uk/data_elements/date_first_seen.html), [DATE FIRST SEEN (CANCER SPECIALIST)](https://www.datadictionary.nhs.uk/data_elements/date_first_seen__cancer_specialist_.html), [DIAGNOSIS DATE](https://www.datadictionary.nhs.uk/data_elements/diagnosis_date.html), [TNM STAGE GROUPING DATE (INTEGRATED)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping_date__integrated_.html), [TNM STAGE GROUPING DATE (FINAL PRETREATMENT)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping_date__final_pretreatment_.html), [TREATMENT START DATE (CANCER)](https://www.datadictionary.nhs.uk/data_elements/treatment_start_date__cancer_.html), [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

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
        Record ->> '$.Lung.LungCore.LungCoreReferralAndFirstStageOfPatientPathway.SourceOfReferralOutPatients.@code' as SourceOfReferralOutPatients,
        Record ->> '$.Lung.LungCore.LungCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber
    from omop_staging.cosd_staging_81
    where Type = 'LU'
)
select
      distinct
          SourceOfReferralOutPatients,
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
where o.SourceOfReferralOutPatients is not null
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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20CosdV8LungSourceOfReferralOutPatients%20mapping){: .btn }
### CosdV8LungSourceOfReferralForOutPatientsNonPrimaryCancerPathway
* Value copied from `Date`

* `Date` Observation date [DATE FIRST SEEN](https://www.datadictionary.nhs.uk/data_elements/date_first_seen.html), [DATE FIRST SEEN (CANCER SPECIALIST)](https://www.datadictionary.nhs.uk/data_elements/date_first_seen__cancer_specialist_.html), [DIAGNOSIS DATE](https://www.datadictionary.nhs.uk/data_elements/diagnosis_date.html), [TNM STAGE GROUPING DATE (INTEGRATED)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping_date__integrated_.html), [TNM STAGE GROUPING DATE (FINAL PRETREATMENT)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping_date__final_pretreatment_.html), [TREATMENT START DATE (CANCER)](https://www.datadictionary.nhs.uk/data_elements/treatment_start_date__cancer_.html), [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

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
        Record ->> '$.Lung.LungCore.LungCoreReferralAndFirstStageOfPatientPathway.SourceOfReferralOutPatients.@code' as SourceOfReferralOutPatients,
        Record ->> '$.Lung.LungCore.LungCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber
    from omop_staging.cosd_staging_81
    where Type = 'LU'
)
select
      distinct
          SourceOfReferralOutPatients,
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
where o.SourceOfReferralOutPatients is not null
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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20CosdV8LungSourceOfReferralForOutPatientsNonPrimaryCancerPathway%20mapping){: .btn }
### CosdV8LungSmokingStatusCode
* Value copied from `Date`

* `Date` Observation date [DATE FIRST SEEN](https://www.datadictionary.nhs.uk/data_elements/date_first_seen.html), [DATE FIRST SEEN (CANCER SPECIALIST)](https://www.datadictionary.nhs.uk/data_elements/date_first_seen__cancer_specialist_.html), [DIAGNOSIS DATE](https://www.datadictionary.nhs.uk/data_elements/diagnosis_date.html), [TNM STAGE GROUPING DATE (INTEGRATED)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping_date__integrated_.html), [TNM STAGE GROUPING DATE (FINAL PRETREATMENT)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping_date__final_pretreatment_.html), [TREATMENT START DATE (CANCER)](https://www.datadictionary.nhs.uk/data_elements/treatment_start_date__cancer_.html), [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

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
        Record ->> '$.Lung.LungCore.LungCoreClinicalNurseSpecialistAndRiskFactorAssessments.SmokingStatusCode.@code' as SmokingStatusCode,
        Record ->> '$.Lung.LungCore.LungCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber
    from omop_staging.cosd_staging_81
    where Type = 'LU'
)
select
      distinct
          SmokingStatusCode,
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
where o.SmokingStatusCode is not null
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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20CosdV8LungSmokingStatusCode%20mapping){: .btn }
### CosdV8LungPersonStatedSexualOrientationCodeAtDiagnosis
* Value copied from `Date`

* `Date` Observation date [DIAGNOSIS DATE](https://www.datadictionary.nhs.uk/data_elements/diagnosis_date.html), [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html), [TREATMENT START DATE (CANCER)](https://www.datadictionary.nhs.uk/data_elements/treatment_start_date__cancer_.html)

```sql
with LU as (
    select 
        Record ->> '$.Lung.LungCore.LungCoreDemographics.PersonStatedSexualOrientationCodeAtDiagnosis.@code' as PersonStatedSexualOrientationCodeAtDiagnosis,
        Record ->> '$.Lung.LungCore.LungCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
        Record ->> '$.Lung.LungCore.LungCoreTreatment.LungCoreSurgeryAndOtherProcedures.ProcedureDate' as ProcedureDate,
        unnest ([[Record ->> '$.Lung.LungCore.LungCoreTreatment.CancerTreatmentStartDate'], Record ->> '$.Lung.LungCore.LungCoreTreatment[*].CancerTreatmentStartDate'], recursive := true) as CancerTreatmentStartDate,
        Record ->> '$.Lung.LungCore.LungCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber
    from omop_staging.cosd_staging_81
    where Type = 'LU'
)
select
      distinct
          PersonStatedSexualOrientationCodeAtDiagnosis,
          NhsNumber,
          least(
                cast (ClinicalDateCancerDiagnosis as date),
                cast (ProcedureDate as date),
                cast (CancerTreatmentStartDate as date)
          ) as Date
from LU o
where o.PersonStatedSexualOrientationCodeAtDiagnosis is not null
  and not (
    ClinicalDateCancerDiagnosis is null and
    ProcedureDate is null and
    CancerTreatmentStartDate is null
    )
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20CosdV8LungPersonStatedSexualOrientationCodeAtDiagnosis%20mapping){: .btn }
### CosdV8LungFamilialCancerSyndromeIndicator
* Value copied from `Date`

* `Date` Observation date [DATE FIRST SEEN](https://www.datadictionary.nhs.uk/data_elements/date_first_seen.html), [DATE FIRST SEEN (CANCER SPECIALIST)](https://www.datadictionary.nhs.uk/data_elements/date_first_seen__cancer_specialist_.html), [DIAGNOSIS DATE](https://www.datadictionary.nhs.uk/data_elements/diagnosis_date.html), [TNM STAGE GROUPING DATE (INTEGRATED)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping_date__integrated_.html), [TNM STAGE GROUPING DATE (FINAL PRETREATMENT)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping_date__final_pretreatment_.html), [TREATMENT START DATE (CANCER)](https://www.datadictionary.nhs.uk/data_elements/treatment_start_date__cancer_.html), [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

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
        Record ->> '$.Lung.LungCore.LungCoreDiagnosis.LungCoreDiagnosisAdditionalItems.FamilialCancerSyndromeIndicator.@code' as FamilialCancerSyndromeIndicator,
        Record ->> '$.Lung.LungCore.LungCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber
    from omop_staging.cosd_staging_81
    where Type = 'LU'
)
select
      distinct
          FamilialCancerSyndromeIndicator,
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
where o.FamilialCancerSyndromeIndicator is not null
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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20CosdV8LungFamilialCancerSyndromeIndicator%20mapping){: .btn }
### CosdV8LungAlcoholHistoryCancerInLastThreeMonths
* Value copied from `Date`

* `Date` Observation date [DATE FIRST SEEN](https://www.datadictionary.nhs.uk/data_elements/date_first_seen.html), [DATE FIRST SEEN (CANCER SPECIALIST)](https://www.datadictionary.nhs.uk/data_elements/date_first_seen__cancer_specialist_.html), [DIAGNOSIS DATE](https://www.datadictionary.nhs.uk/data_elements/diagnosis_date.html), [TNM STAGE GROUPING DATE (INTEGRATED)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping_date__integrated_.html), [TNM STAGE GROUPING DATE (FINAL PRETREATMENT)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping_date__final_pretreatment_.html), [TREATMENT START DATE (CANCER)](https://www.datadictionary.nhs.uk/data_elements/treatment_start_date__cancer_.html), [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

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
        Record ->> '$.Lung.LungCore.LungCoreClinicalNurseSpecialistAndRiskFactorAssessments.AlcoholHistoryCancerInLastThreeMonths.@code' as AlcoholHistoryCancerInLastThreeMonths,
        Record ->> '$.Lung.LungCore.LungCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber
    from omop_staging.cosd_staging_81
    where Type = 'LU'
)
select
      distinct
          AlcoholHistoryCancerInLastThreeMonths,
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
where o.AlcoholHistoryCancerInLastThreeMonths is not null
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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20CosdV8LungAlcoholHistoryCancerInLastThreeMonths%20mapping){: .btn }
### CosdV8LungAlcoholHistoryCancerBeforeLastThreeMonths
* Value copied from `Date`

* `Date` Observation date [DATE FIRST SEEN](https://www.datadictionary.nhs.uk/data_elements/date_first_seen.html), [DATE FIRST SEEN (CANCER SPECIALIST)](https://www.datadictionary.nhs.uk/data_elements/date_first_seen__cancer_specialist_.html), [DIAGNOSIS DATE](https://www.datadictionary.nhs.uk/data_elements/diagnosis_date.html), [TNM STAGE GROUPING DATE (INTEGRATED)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping_date__integrated_.html), [TNM STAGE GROUPING DATE (FINAL PRETREATMENT)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping_date__final_pretreatment_.html), [TREATMENT START DATE (CANCER)](https://www.datadictionary.nhs.uk/data_elements/treatment_start_date__cancer_.html), [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

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
        Record ->> '$.Lung.LungCore.LungCoreClinicalNurseSpecialistAndRiskFactorAssessments.AlcoholHistoryCancerBeforeLastThreeMonths.@code' as AlcoholHistoryCancerBeforeLastThreeMonths,
        Record ->> '$.Lung.LungCore.LungCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber
    from omop_staging.cosd_staging_81
    where Type = 'LU'
)
select
      distinct
          AlcoholHistoryCancerBeforeLastThreeMonths,
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
where o.AlcoholHistoryCancerBeforeLastThreeMonths is not null
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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20CosdV8LungAlcoholHistoryCancerBeforeLastThreeMonths%20mapping){: .btn }
### CosdV8LungAdultPerformanceStatus
* Value copied from `Date`

* `Date` Observation date [DATE FIRST SEEN](https://www.datadictionary.nhs.uk/data_elements/date_first_seen.html), [DATE FIRST SEEN (CANCER SPECIALIST)](https://www.datadictionary.nhs.uk/data_elements/date_first_seen__cancer_specialist_.html), [DIAGNOSIS DATE](https://www.datadictionary.nhs.uk/data_elements/diagnosis_date.html), [TNM STAGE GROUPING DATE (INTEGRATED)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping_date__integrated_.html), [TNM STAGE GROUPING DATE (FINAL PRETREATMENT)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping_date__final_pretreatment_.html), [TREATMENT START DATE (CANCER)](https://www.datadictionary.nhs.uk/data_elements/treatment_start_date__cancer_.html), [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

```sql
with LU as (
    select 
        Record ->> '$.Lung.LungCore.LungCoreReferralAndFirstStageOfPatientPathway.DateFirstSeen' as DateFirstSeen,
        Record ->> '$.Lung.LungCore.LungCoreReferralAndFirstStageOfPatientPathway.SpecialistDateFirstSeen' as SpecialistDateFirstSeen,
        Record ->> '$.Lung.LungCore.LungCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
        Record ->> '$.Lung.LungCore.LungCoreStaging.IntegratedStageTNMStageGroupingDate' as IntegratedStageTNMStageGroupingDate,
        Record ->> '$.Lung.LungCore.LungCoreStaging.FinalPreTreatmentTNMStageGroupingDate' as FinalPreTreatmentTNMStageGroupingDate,
        coalesce(Record ->> '$.Lung.LungCore.LungCoreTreatment[0].CancerTreatmentStartDate', Record ->> '$.Lung.LungCore.LungCoreTreatment.CancerTreatmentStartDate') as CancerTreatmentStartDate,
        coalesce(Record ->> '$.Lung.LungCore.LungCoreTreatment[0].LungCoreSurgeryAndOtherProcedures.ProcedureDate', Record ->> '$.Lung.LungCore.LungCoreTreatment.LungCoreSurgeryAndOtherProcedures.ProcedureDate') as ProcedureDate,
        Record ->> '$.Lung.LungCore.LungCoreDiagnosis.AdultPerformanceStatus.@code' as AdultPerformanceStatus,
        Record ->> '$.Lung.LungCore.LungCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber
    from omop_staging.cosd_staging_81
    where Type = 'LU'
)
select
      distinct
          AdultPerformanceStatus,
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
where o.AdultPerformanceStatus is not null
 and not (
    DateFirstSeen is null  and
    SpecialistDateFirstSeen is null  and
    ClinicalDateCancerDiagnosis is null  and
    IntegratedStageTNMStageGroupingDate is null  and
    FinalPreTreatmentTNMStageGroupingDate is null and
    CancerTreatmentStartDate is null and
    ProcedureDate is null 
  )
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20CosdV8LungAdultPerformanceStatus%20mapping){: .btn }
### CosdV8LungAdultComorbidityEvaluation
* Value copied from `Date`

* `Date` Observation date [DATE FIRST SEEN](https://www.datadictionary.nhs.uk/data_elements/date_first_seen.html), [DATE FIRST SEEN (CANCER SPECIALIST)](https://www.datadictionary.nhs.uk/data_elements/date_first_seen__cancer_specialist_.html), [DIAGNOSIS DATE](https://www.datadictionary.nhs.uk/data_elements/diagnosis_date.html), [TNM STAGE GROUPING DATE (INTEGRATED)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping_date__integrated_.html), [TNM STAGE GROUPING DATE (FINAL PRETREATMENT)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping_date__final_pretreatment_.html), [TREATMENT START DATE (CANCER)](https://www.datadictionary.nhs.uk/data_elements/treatment_start_date__cancer_.html), [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

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
        Record ->> '$.Lung.LungCore.LungCoreCancerCarePlan.AdultComorbidityEvaluation.@code' as AdultComorbidityEvaluation,
        Record ->> '$.Lung.LungCore.LungCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber
    from omop_staging.cosd_staging_81
    where Type = 'LU'
)
select
      distinct
          AdultComorbidityEvaluation,
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
where o.AdultComorbidityEvaluation is not null
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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20CosdV8LungAdultComorbidityEvaluation%20mapping){: .btn }
### COSD V9 HN Observation Smoking Status Cancer
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` The date the Primary Cancer was confirmed or the Primary Cancer diagnosis was clinically agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
-- Selects SMOKING STATUS (CANCER) for Head and Neck (area HN) records in
-- COSD v9.01, routed to the OMOP observation table as a lifestyle /
-- risk-factor attribute. The source path TobaccoSmokingStatus carries the
-- patient's tobacco smoking status.
--
-- The DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) is used as the
-- observation_date.
--
-- Downstream ETL responsibilities:
--   * Resolve NhsNumber against cdm.person to obtain person_id.
--   * Map SmokingStatusCancer (NHS National Code) to the standard
--     observation_concept_id and retain the verbatim code in
--     observation_source_value / value_source_value.
--   * Cast DateOfPrimaryDiagnosisClinicallyAgreed (varchar) to a DATE and
--     assign to observation_date / observation_datetime.
select distinct
    -- NHS NUMBER - patient identifier, mandatory; used to join to cdm.person.
    Record ->> '$.LinkagePatientId.NhsNumber.@extension'
        as NhsNumber,
    -- DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) - becomes
    -- observation_date / observation_datetime.
    Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    -- SMOKING STATUS (CANCER) - the observation value; mapped downstream to
    -- observation_concept_id and retained as observation_source_value.
    Record ->> '$.ClinicalNurseSpecialistAndRiskFactorAssessments.TobaccoSmokingStatus.@code'
        as SmokingStatusCancer
from omop_staging.cosd_staging_901
where type = 'HN'
  and NhsNumber is not null
  and SmokingStatusCancer is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20COSD%20V9%20HN%20Observation%20Smoking%20Status%20Cancer%20mapping){: .btn }
### COSD V9 HN Observation Performance Status Adult
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` The date the Primary Cancer was confirmed or the Primary Cancer diagnosis was clinically agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
-- Selects PERFORMANCE STATUS (ADULT) for Head and Neck (area HN) records in
-- COSD v9.01, routed to the OMOP observation table. This WHO performance
-- status is a clinical assessment of the patient's functional status.
--
-- The DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) is used as the
-- observation_date.
--
-- Downstream ETL responsibilities:
--   * Resolve NhsNumber against cdm.person to obtain person_id.
--   * Map PerformanceStatusAdult (NHS National Code) to the standard
--     observation_concept_id and retain the verbatim code in
--     observation_source_value / value_source_value.
--   * Cast DateOfPrimaryDiagnosisClinicallyAgreed (varchar) to a DATE and
--     assign to observation_date / observation_datetime.
select distinct
    -- NHS NUMBER - patient identifier, mandatory; used to join to cdm.person.
    Record ->> '$.LinkagePatientId.NhsNumber.@extension'
        as NhsNumber,
    -- DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) - becomes
    -- observation_date / observation_datetime.
    Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    -- PERFORMANCE STATUS (ADULT) - the observation value; mapped downstream
    -- to observation_concept_id and retained as observation_source_value.
    Record ->> '$.PrimaryPathway.Diagnosis.PerformanceStatusAdult.@code'
        as PerformanceStatusAdult
from omop_staging.cosd_staging_901
where type = 'HN'
  and NhsNumber is not null
  and PerformanceStatusAdult is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20COSD%20V9%20HN%20Observation%20Performance%20Status%20Adult%20mapping){: .btn }
### COSD V9 HN Observation Familial Cancer Syndrome Indicator
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` The date the Primary Cancer was confirmed or the Primary Cancer diagnosis was clinically agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
-- Selects FAMILIAL CANCER SYNDROME INDICATOR for Head and Neck (area HN)
-- records in COSD v9.01, routed to the OMOP observation table as a
-- family-history / risk attribute (source path FamilialCancerSyndrome).
--
-- The DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) is used as the
-- observation_date.
--
-- Downstream ETL responsibilities:
--   * Resolve NhsNumber against cdm.person to obtain person_id.
--   * Map FamilialCancerSyndromeIndicator (NHS National Code) to the
--     standard observation_concept_id and retain the verbatim code in
--     observation_source_value / value_source_value.
--   * Cast DateOfPrimaryDiagnosisClinicallyAgreed (varchar) to a DATE and
--     assign to observation_date / observation_datetime.
select distinct
    -- NHS NUMBER - patient identifier, mandatory; used to join to cdm.person.
    Record ->> '$.LinkagePatientId.NhsNumber.@extension'
        as NhsNumber,
    -- DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) - becomes
    -- observation_date / observation_datetime.
    Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    -- FAMILIAL CANCER SYNDROME INDICATOR - the observation value; mapped
    -- downstream to observation_concept_id and retained as
    -- observation_source_value.
    Record ->> '$.PrimaryPathway.Diagnosis.DiagnosisAdditionalItems.FamilialCancerSyndrome.@code'
        as FamilialCancerSyndromeIndicator
from omop_staging.cosd_staging_901
where type = 'HN'
  and NhsNumber is not null
  and FamilialCancerSyndromeIndicator is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20COSD%20V9%20HN%20Observation%20Familial%20Cancer%20Syndrome%20Indicator%20mapping){: .btn }
### COSD V9 HN Observation Cancer Treatment Intent
Source column  `TreatmentStartDateCancer`.
Converts text to dates.

* `TreatmentStartDateCancer` The start date of a cancer treatment during a Cancer Care Spell. [TREATMENT START DATE (CANCER)](https://www.datadictionary.nhs.uk/data_elements/treatment_start_date__cancer_.html)

```sql
-- Selects CANCER TREATMENT INTENT for Head and Neck (area HN) records in
-- COSD v9.01, routed to the OMOP observation table. Each record's Treatment
-- array carries one (intent, start date) pair per entry, so the JSON paths
-- are unnested in lockstep so each treatment intent keeps its own start
-- date. The first element of each array list covers the singular-object
-- encoding and the second the JSON-array encoding.
--
-- The TREATMENT START DATE (CANCER) is used as the observation_date.
--
-- Downstream ETL responsibilities:
--   * Resolve NhsNumber against cdm.person to obtain person_id.
--   * Map CancerTreatmentIntent (NHS National Code) to the standard
--     observation_concept_id and retain the verbatim code in
--     observation_source_value / value_source_value.
--   * Cast TreatmentStartDateCancer (varchar) to a DATE and assign to
--     observation_date / observation_datetime.
with hn as (
    select
        -- NHS NUMBER - patient identifier, mandatory; joins to cdm.person.
        Record ->> '$.LinkagePatientId.NhsNumber.@extension'
            as NhsNumber,
        -- CANCER TREATMENT INTENT - the observation value; unnested in
        -- lockstep with the treatment start date.
        unnest([
            [Record ->> '$.Treatment.CancerTreatmentIntent.@code'],
            Record ->> '$.Treatment[*].CancerTreatmentIntent.@code'
        ], recursive := true) as CancerTreatmentIntent,
        -- TREATMENT START DATE (CANCER) - becomes observation_date /
        -- observation_datetime. Paired one-to-one with CancerTreatmentIntent.
        unnest([
            [Record ->> '$.Treatment.TreatmentStartDateCancer'],
            Record ->> '$.Treatment[*].TreatmentStartDateCancer'
        ], recursive := true) as TreatmentStartDateCancer
    from omop_staging.cosd_staging_901
    where type = 'HN'
)
select distinct
    NhsNumber,
    TreatmentStartDateCancer,
    CancerTreatmentIntent
from hn
where NhsNumber is not null
  and CancerTreatmentIntent is not null
  and TreatmentStartDateCancer is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20COSD%20V9%20HN%20Observation%20Cancer%20Treatment%20Intent%20mapping){: .btn }
### COSD V9 HN Observation Alcohol History Cancer In Last Three Months
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` The date the Primary Cancer was confirmed or the Primary Cancer diagnosis was clinically agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
-- Selects ALCOHOL HISTORY (CANCER IN LAST THREE MONTHS) for Head and Neck
-- (area HN) records in COSD v9.01, routed to the OMOP observation table as a
-- lifestyle / risk-factor attribute describing current alcohol consumption
-- history (source path HistoryOfAlcoholCurrent).
--
-- The DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) is used as the
-- observation_date.
--
-- Downstream ETL responsibilities:
--   * Resolve NhsNumber against cdm.person to obtain person_id.
--   * Map AlcoholHistoryCancerInLastThreeMonths (NHS National Code) to the
--     standard observation_concept_id and retain the verbatim code in
--     observation_source_value / value_source_value.
--   * Cast DateOfPrimaryDiagnosisClinicallyAgreed (varchar) to a DATE and
--     assign to observation_date / observation_datetime.
select distinct
    -- NHS NUMBER - patient identifier, mandatory; used to join to cdm.person.
    Record ->> '$.LinkagePatientId.NhsNumber.@extension'
        as NhsNumber,
    -- DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) - becomes
    -- observation_date / observation_datetime.
    Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    -- ALCOHOL HISTORY (CANCER IN LAST THREE MONTHS) - the observation value;
    -- mapped downstream to observation_concept_id and retained as
    -- observation_source_value.
    Record ->> '$.ClinicalNurseSpecialistAndRiskFactorAssessments.HistoryOfAlcoholCurrent.@code'
        as AlcoholHistoryCancerInLastThreeMonths
from omop_staging.cosd_staging_901
where type = 'HN'
  and NhsNumber is not null
  and AlcoholHistoryCancerInLastThreeMonths is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20COSD%20V9%20HN%20Observation%20Alcohol%20History%20Cancer%20In%20Last%20Three%20Months%20mapping){: .btn }
### COSD V9 HN Observation Alcohol History Cancer Before Last Three Months
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` The date the Primary Cancer was confirmed or the Primary Cancer diagnosis was clinically agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
-- Selects ALCOHOL HISTORY (CANCER BEFORE LAST THREE MONTHS) for Head and
-- Neck (area HN) records in COSD v9.01, routed to the OMOP observation table
-- as a lifestyle / risk-factor attribute describing past alcohol consumption
-- history (source path HistoryOfAlcoholPast).
--
-- The DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) is used as the
-- observation_date.
--
-- Downstream ETL responsibilities:
--   * Resolve NhsNumber against cdm.person to obtain person_id.
--   * Map AlcoholHistoryCancerBeforeLastThreeMonths (NHS National Code) to
--     the standard observation_concept_id and retain the verbatim code in
--     observation_source_value / value_source_value.
--   * Cast DateOfPrimaryDiagnosisClinicallyAgreed (varchar) to a DATE and
--     assign to observation_date / observation_datetime.
select distinct
    -- NHS NUMBER - patient identifier, mandatory; used to join to cdm.person.
    Record ->> '$.LinkagePatientId.NhsNumber.@extension'
        as NhsNumber,
    -- DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) - becomes
    -- observation_date / observation_datetime.
    Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    -- ALCOHOL HISTORY (CANCER BEFORE LAST THREE MONTHS) - the observation
    -- value; mapped downstream to observation_concept_id and retained as
    -- observation_source_value.
    Record ->> '$.ClinicalNurseSpecialistAndRiskFactorAssessments.HistoryOfAlcoholPast.@code'
        as AlcoholHistoryCancerBeforeLastThreeMonths
from omop_staging.cosd_staging_901
where type = 'HN'
  and NhsNumber is not null
  and AlcoholHistoryCancerBeforeLastThreeMonths is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20COSD%20V9%20HN%20Observation%20Alcohol%20History%20Cancer%20Before%20Last%20Three%20Months%20mapping){: .btn }
### COSD V8 HN Observation Smoking Status Cancer
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` The date the Primary Cancer was confirmed or the Primary Cancer diagnosis was clinically agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
-- Selects SMOKING STATUS (CANCER) for Head and Neck (area HN) records in
-- COSD v8.1 (Head and Neck core structure), routed to the OMOP observation
-- table as a lifestyle / risk-factor attribute. The source path
-- SmokingStatusCode carries the patient's tobacco smoking status.
--
-- The DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) - held in the
-- Head and Neck core as ClinicalDateCancerDiagnosis - is used as the
-- observation_date.
--
-- Downstream ETL responsibilities:
--   * Resolve NhsNumber against cdm.person to obtain person_id.
--   * Map SmokingStatusCancer (NHS National Code) to the standard
--     observation_concept_id and retain the verbatim code in
--     observation_source_value / value_source_value.
--   * Cast DateOfPrimaryDiagnosisClinicallyAgreed (varchar) to a DATE and
--     assign to observation_date / observation_datetime.
select distinct
    -- NHS NUMBER - patient identifier, mandatory; used to join to cdm.person.
    Record ->> '$.HeadNeck.HeadNeckCore.HeadNeckCoreLinkagePatientId.NHSNumber.@extension'
        as NhsNumber,
    -- DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) - becomes
    -- observation_date / observation_datetime.
    Record ->> '$.HeadNeck.HeadNeckCore.HeadNeckCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    -- SMOKING STATUS (CANCER) - the observation value; mapped downstream to
    -- observation_concept_id and retained as observation_source_value.
    Record ->> '$.HeadNeck.HeadNeckCore.HeadNeckCoreClinicalNurseSpecialistAndRiskFactorAssessments.SmokingStatusCode.@code'
        as SmokingStatusCancer
from omop_staging.cosd_staging_81
where type = 'HN'
  and NhsNumber is not null
  and SmokingStatusCancer is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20COSD%20V8%20HN%20Observation%20Smoking%20Status%20Cancer%20mapping){: .btn }
### COSD V8 HN Observation Performance Status Adult
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` The date the Primary Cancer was confirmed or the Primary Cancer diagnosis was clinically agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
-- Selects PERFORMANCE STATUS (ADULT) for Head and Neck (area HN) records in
-- COSD v8.1 (Head and Neck core structure), routed to the OMOP observation
-- table. This WHO performance status is a clinical assessment of the
-- patient's functional status.
--
-- The DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) - held in the
-- Head and Neck core as ClinicalDateCancerDiagnosis - is used as the
-- observation_date.
--
-- Downstream ETL responsibilities:
--   * Resolve NhsNumber against cdm.person to obtain person_id.
--   * Map PerformanceStatusAdult (NHS National Code) to the standard
--     observation_concept_id and retain the verbatim code in
--     observation_source_value / value_source_value.
--   * Cast DateOfPrimaryDiagnosisClinicallyAgreed (varchar) to a DATE and
--     assign to observation_date / observation_datetime.
select distinct
    -- NHS NUMBER - patient identifier, mandatory; used to join to cdm.person.
    Record ->> '$.HeadNeck.HeadNeckCore.HeadNeckCoreLinkagePatientId.NHSNumber.@extension'
        as NhsNumber,
    -- DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) - becomes
    -- observation_date / observation_datetime.
    Record ->> '$.HeadNeck.HeadNeckCore.HeadNeckCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    -- PERFORMANCE STATUS (ADULT) - the observation value; mapped downstream
    -- to observation_concept_id and retained as observation_source_value.
    Record ->> '$.HeadNeck.HeadNeckCore.HeadNeckCoreDiagnosis.AdultPerformanceStatus.@code'
        as PerformanceStatusAdult
from omop_staging.cosd_staging_81
where type = 'HN'
  and NhsNumber is not null
  and PerformanceStatusAdult is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20COSD%20V8%20HN%20Observation%20Performance%20Status%20Adult%20mapping){: .btn }
### COSD V8 HN Observation Familial Cancer Syndrome Indicator
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` The date the Primary Cancer was confirmed or the Primary Cancer diagnosis was clinically agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
-- Selects FAMILIAL CANCER SYNDROME INDICATOR for Head and Neck (area HN)
-- records in COSD v8.1 (Head and Neck core structure), routed to the OMOP
-- observation table as a family-history / risk attribute.
--
-- The DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) - held in the
-- Head and Neck core as ClinicalDateCancerDiagnosis - is used as the
-- observation_date.
--
-- Downstream ETL responsibilities:
--   * Resolve NhsNumber against cdm.person to obtain person_id.
--   * Map FamilialCancerSyndromeIndicator (NHS National Code) to the
--     standard observation_concept_id and retain the verbatim code in
--     observation_source_value / value_source_value.
--   * Cast DateOfPrimaryDiagnosisClinicallyAgreed (varchar) to a DATE and
--     assign to observation_date / observation_datetime.
select distinct
    -- NHS NUMBER - patient identifier, mandatory; used to join to cdm.person.
    Record ->> '$.HeadNeck.HeadNeckCore.HeadNeckCoreLinkagePatientId.NHSNumber.@extension'
        as NhsNumber,
    -- DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) - becomes
    -- observation_date / observation_datetime.
    Record ->> '$.HeadNeck.HeadNeckCore.HeadNeckCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    -- FAMILIAL CANCER SYNDROME INDICATOR - the observation value; mapped
    -- downstream to observation_concept_id and retained as
    -- observation_source_value.
    Record ->> '$.HeadNeck.HeadNeckCore.HeadNeckCoreDiagnosis.HeadNeckCoreDiagnosisAdditionalItems.FamilialCancerSyndromeIndicator.@code'
        as FamilialCancerSyndromeIndicator
from omop_staging.cosd_staging_81
where type = 'HN'
  and NhsNumber is not null
  and FamilialCancerSyndromeIndicator is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20COSD%20V8%20HN%20Observation%20Familial%20Cancer%20Syndrome%20Indicator%20mapping){: .btn }
### COSD V8 HN Observation Cancer Treatment Intent
Source column  `TreatmentStartDateCancer`.
Converts text to dates.

* `TreatmentStartDateCancer` The start date of a cancer treatment during a Cancer Care Spell. [TREATMENT START DATE (CANCER)](https://www.datadictionary.nhs.uk/data_elements/treatment_start_date__cancer_.html)

```sql
-- Selects CANCER TREATMENT INTENT for Head and Neck (area HN) records in
-- COSD v8.1 (Head and Neck core structure), routed to the OMOP observation
-- table. The Treatment section is a repeating array, so the intent and its
-- associated TREATMENT START DATE (CANCER) are unnested in lockstep: the
-- first element of each array list covers the singular-object encoding and
-- the second the JSON-array encoding, keeping each intent paired with its
-- own start date.
--
-- The TREATMENT START DATE (CANCER) is used as the observation_date because
-- the treatment intent is recorded against an individual treatment event.
--
-- Downstream ETL responsibilities:
--   * Resolve NhsNumber against cdm.person to obtain person_id.
--   * Map CancerTreatmentIntent (NHS National Code) to the standard
--     observation_concept_id and retain the verbatim code in
--     observation_source_value / value_source_value.
--   * Cast TreatmentStartDateCancer (varchar) to a DATE and assign to
--     observation_date / observation_datetime.
with hn as (
    select
        -- NHS NUMBER - patient identifier, mandatory; joins to cdm.person.
        Record ->> '$.HeadNeck.HeadNeckCore.HeadNeckCoreLinkagePatientId.NHSNumber.@extension'
            as NhsNumber,
        -- CANCER TREATMENT INTENT - unnested in lockstep with the start date;
        -- the observation value mapped downstream to observation_concept_id.
        unnest(
            [
                [ Record ->> '$.HeadNeck.HeadNeckCore.HeadNeckCoreTreatment.CancerTreatmentIntent.@code' ],
                Record ->> '$.HeadNeck.HeadNeckCore.HeadNeckCoreTreatment[*].CancerTreatmentIntent.@code'
            ],
            recursive := true
        ) as CancerTreatmentIntent,
        -- TREATMENT START DATE (CANCER) - unnested in lockstep with the
        -- intent; becomes observation_date / observation_datetime.
        unnest(
            [
                [ Record ->> '$.HeadNeck.HeadNeckCore.HeadNeckCoreTreatment.CancerTreatmentStartDate' ],
                Record ->> '$.HeadNeck.HeadNeckCore.HeadNeckCoreTreatment[*].CancerTreatmentStartDate'
            ],
            recursive := true
        ) as TreatmentStartDateCancer
    from omop_staging.cosd_staging_81
    where type = 'HN'
)
select distinct
    NhsNumber,
    TreatmentStartDateCancer,
    CancerTreatmentIntent
from hn
where NhsNumber is not null
  and CancerTreatmentIntent is not null
  and TreatmentStartDateCancer is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20COSD%20V8%20HN%20Observation%20Cancer%20Treatment%20Intent%20mapping){: .btn }
### COSD V8 HN Observation Alcohol History Cancer In Last Three Months
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` The date the Primary Cancer was confirmed or the Primary Cancer diagnosis was clinically agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
-- Selects ALCOHOL HISTORY (CANCER IN LAST THREE MONTHS) for Head and Neck
-- (area HN) records in COSD v8.1 (Head and Neck core structure), routed to
-- the OMOP observation table as a lifestyle / risk-factor attribute
-- describing current alcohol consumption history.
--
-- The DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) - held in the
-- Head and Neck core as ClinicalDateCancerDiagnosis - is used as the
-- observation_date.
--
-- Downstream ETL responsibilities:
--   * Resolve NhsNumber against cdm.person to obtain person_id.
--   * Map AlcoholHistoryCancerInLastThreeMonths (NHS National Code) to the
--     standard observation_concept_id and retain the verbatim code in
--     observation_source_value / value_source_value.
--   * Cast DateOfPrimaryDiagnosisClinicallyAgreed (varchar) to a DATE and
--     assign to observation_date / observation_datetime.
select distinct
    -- NHS NUMBER - patient identifier, mandatory; used to join to cdm.person.
    Record ->> '$.HeadNeck.HeadNeckCore.HeadNeckCoreLinkagePatientId.NHSNumber.@extension'
        as NhsNumber,
    -- DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) - becomes
    -- observation_date / observation_datetime.
    Record ->> '$.HeadNeck.HeadNeckCore.HeadNeckCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    -- ALCOHOL HISTORY (CANCER IN LAST THREE MONTHS) - the observation value;
    -- mapped downstream to observation_concept_id and retained as
    -- observation_source_value.
    Record ->> '$.HeadNeck.HeadNeckCore.HeadNeckCoreClinicalNurseSpecialistAndRiskFactorAssessments.AlcoholHistoryCancerInLastThreeMonths.@code'
        as AlcoholHistoryCancerInLastThreeMonths
from omop_staging.cosd_staging_81
where type = 'HN'
  and NhsNumber is not null
  and AlcoholHistoryCancerInLastThreeMonths is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20COSD%20V8%20HN%20Observation%20Alcohol%20History%20Cancer%20In%20Last%20Three%20Months%20mapping){: .btn }
### COSD V8 HN Observation Alcohol History Cancer Before Last Three Months
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` The date the Primary Cancer was confirmed or the Primary Cancer diagnosis was clinically agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
-- Selects ALCOHOL HISTORY (CANCER BEFORE LAST THREE MONTHS) for Head and
-- Neck (area HN) records in COSD v8.1 (Head and Neck core structure), routed
-- to the OMOP observation table as a lifestyle / risk-factor attribute
-- describing past alcohol consumption history.
--
-- The DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) - held in the
-- Head and Neck core as ClinicalDateCancerDiagnosis - is used as the
-- observation_date.
--
-- Downstream ETL responsibilities:
--   * Resolve NhsNumber against cdm.person to obtain person_id.
--   * Map AlcoholHistoryCancerBeforeLastThreeMonths (NHS National Code) to
--     the standard observation_concept_id and retain the verbatim code in
--     observation_source_value / value_source_value.
--   * Cast DateOfPrimaryDiagnosisClinicallyAgreed (varchar) to a DATE and
--     assign to observation_date / observation_datetime.
select distinct
    -- NHS NUMBER - patient identifier, mandatory; used to join to cdm.person.
    Record ->> '$.HeadNeck.HeadNeckCore.HeadNeckCoreLinkagePatientId.NHSNumber.@extension'
        as NhsNumber,
    -- DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) - becomes
    -- observation_date / observation_datetime.
    Record ->> '$.HeadNeck.HeadNeckCore.HeadNeckCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    -- ALCOHOL HISTORY (CANCER BEFORE LAST THREE MONTHS) - the observation
    -- value; mapped downstream to observation_concept_id and retained as
    -- observation_source_value.
    Record ->> '$.HeadNeck.HeadNeckCore.HeadNeckCoreClinicalNurseSpecialistAndRiskFactorAssessments.AlcoholHistoryCancerBeforeLastThreeMonths.@code'
        as AlcoholHistoryCancerBeforeLastThreeMonths
from omop_staging.cosd_staging_81
where type = 'HN'
  and NhsNumber is not null
  and AlcoholHistoryCancerBeforeLastThreeMonths is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20COSD%20V8%20HN%20Observation%20Alcohol%20History%20Cancer%20Before%20Last%20Three%20Months%20mapping){: .btn }
### COSD V9 HA Observation Smoking Status Cancer
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` The date the Primary Cancer was confirmed or the Primary Cancer diagnosis was clinically agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
-- Selects SMOKING STATUS (CANCER) for Haematological (area HA) records in
-- COSD v9.01, routed to the OMOP observation table as a lifestyle /
-- risk-factor attribute. The source path TobaccoSmokingStatus carries the
-- patient's tobacco smoking status.
--
-- The DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) is used as the
-- observation_date.
--
-- Downstream ETL responsibilities:
--   * Resolve NhsNumber against cdm.person to obtain person_id.
--   * Map SmokingStatusCancer (NHS National Code) to the standard
--     observation_concept_id and retain the verbatim code in
--     observation_source_value / value_source_value.
--   * Cast DateOfPrimaryDiagnosisClinicallyAgreed (varchar) to a DATE and
--     assign to observation_date / observation_datetime.
select distinct
    -- NHS NUMBER - patient identifier, mandatory; used to join to cdm.person.
    Record ->> '$.LinkagePatientId.NhsNumber.@extension'
        as NhsNumber,
    -- DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) - becomes
    -- observation_date / observation_datetime.
    Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    -- SMOKING STATUS (CANCER) - the observation value; mapped downstream to
    -- observation_concept_id and retained as observation_source_value.
    Record ->> '$.ClinicalNurseSpecialistAndRiskFactorAssessments.TobaccoSmokingStatus.@code'
        as SmokingStatusCancer
from omop_staging.cosd_staging_901
where type = 'HA'
  and NhsNumber is not null
  and SmokingStatusCancer is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20COSD%20V9%20HA%20Observation%20Smoking%20Status%20Cancer%20mapping){: .btn }
### COSD V9 HA Observation Performance Status Adult
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` The date the Primary Cancer was confirmed or the Primary Cancer diagnosis was clinically agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
-- Selects PERFORMANCE STATUS (ADULT) for Haematological (area HA) records in
-- COSD v9.01, routed to the OMOP observation table. This WHO performance
-- status is a clinical assessment of the patient's functional status.
--
-- The DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) is used as the
-- observation_date.
--
-- Downstream ETL responsibilities:
--   * Resolve NhsNumber against cdm.person to obtain person_id.
--   * Map PerformanceStatusAdult (NHS National Code) to the standard
--     observation_concept_id and retain the verbatim code in
--     observation_source_value / value_source_value.
--   * Cast DateOfPrimaryDiagnosisClinicallyAgreed (varchar) to a DATE and
--     assign to observation_date / observation_datetime.
select distinct
    -- NHS NUMBER - patient identifier, mandatory; used to join to cdm.person.
    Record ->> '$.LinkagePatientId.NhsNumber.@extension'
        as NhsNumber,
    -- DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) - becomes
    -- observation_date / observation_datetime.
    Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    -- PERFORMANCE STATUS (ADULT) - the observation value; mapped downstream
    -- to observation_concept_id and retained as observation_source_value.
    Record ->> '$.PrimaryPathway.Diagnosis.PerformanceStatusAdult.@code'
        as PerformanceStatusAdult
from omop_staging.cosd_staging_901
where type = 'HA'
  and NhsNumber is not null
  and PerformanceStatusAdult is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20COSD%20V9%20HA%20Observation%20Performance%20Status%20Adult%20mapping){: .btn }
### COSD V9 HA Observation Familial Cancer Syndrome Indicator
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` The date the Primary Cancer was confirmed or the Primary Cancer diagnosis was clinically agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
-- Selects FAMILIAL CANCER SYNDROME INDICATOR for Haematological (area HA)
-- records in COSD v9.01, routed to the OMOP observation table as a
-- family-history / risk attribute (source path FamilialCancerSyndrome).
--
-- The DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) is used as the
-- observation_date.
--
-- Downstream ETL responsibilities:
--   * Resolve NhsNumber against cdm.person to obtain person_id.
--   * Map FamilialCancerSyndromeIndicator (NHS National Code) to the
--     standard observation_concept_id and retain the verbatim code in
--     observation_source_value / value_source_value.
--   * Cast DateOfPrimaryDiagnosisClinicallyAgreed (varchar) to a DATE and
--     assign to observation_date / observation_datetime.
select distinct
    -- NHS NUMBER - patient identifier, mandatory; used to join to cdm.person.
    Record ->> '$.LinkagePatientId.NhsNumber.@extension'
        as NhsNumber,
    -- DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) - becomes
    -- observation_date / observation_datetime.
    Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    -- FAMILIAL CANCER SYNDROME INDICATOR - the observation value; mapped
    -- downstream to observation_concept_id and retained as
    -- observation_source_value.
    Record ->> '$.PrimaryPathway.Diagnosis.DiagnosisAdditionalItems.FamilialCancerSyndrome.@code'
        as FamilialCancerSyndromeIndicator
from omop_staging.cosd_staging_901
where type = 'HA'
  and NhsNumber is not null
  and FamilialCancerSyndromeIndicator is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20COSD%20V9%20HA%20Observation%20Familial%20Cancer%20Syndrome%20Indicator%20mapping){: .btn }
### COSD V9 HA Observation Cancer Treatment Intent
Source column  `TreatmentStartDateCancer`.
Converts text to dates.

* `TreatmentStartDateCancer` The start date of a cancer treatment during a Cancer Care Spell. [TREATMENT START DATE (CANCER)](https://www.datadictionary.nhs.uk/data_elements/treatment_start_date__cancer_.html)

```sql
-- Selects CANCER TREATMENT INTENT for Haematological (area HA) records in
-- COSD v9.01, routed to the OMOP observation table. Each record's Treatment
-- array carries one (intent, start date) pair per entry, so the JSON paths
-- are unnested in lockstep so each treatment intent keeps its own start
-- date. The first element of each array list covers the singular-object
-- encoding and the second the JSON-array encoding.
--
-- The TREATMENT START DATE (CANCER) is used as the observation_date.
--
-- Downstream ETL responsibilities:
--   * Resolve NhsNumber against cdm.person to obtain person_id.
--   * Map CancerTreatmentIntent (NHS National Code) to the standard
--     observation_concept_id and retain the verbatim code in
--     observation_source_value / value_source_value.
--   * Cast TreatmentStartDateCancer (varchar) to a DATE and assign to
--     observation_date / observation_datetime.
with ha as (
    select
        -- NHS NUMBER - patient identifier, mandatory; joins to cdm.person.
        Record ->> '$.LinkagePatientId.NhsNumber.@extension'
            as NhsNumber,
        -- CANCER TREATMENT INTENT - the observation value; unnested in
        -- lockstep with the treatment start date.
        unnest([
            [Record ->> '$.Treatment.CancerTreatmentIntent.@code'],
            Record ->> '$.Treatment[*].CancerTreatmentIntent.@code'
        ], recursive := true) as CancerTreatmentIntent,
        -- TREATMENT START DATE (CANCER) - becomes observation_date /
        -- observation_datetime. Paired one-to-one with CancerTreatmentIntent.
        unnest([
            [Record ->> '$.Treatment.TreatmentStartDateCancer'],
            Record ->> '$.Treatment[*].TreatmentStartDateCancer'
        ], recursive := true) as TreatmentStartDateCancer
    from omop_staging.cosd_staging_901
    where type = 'HA'
)
select distinct
    NhsNumber,
    TreatmentStartDateCancer,
    CancerTreatmentIntent
from ha
where NhsNumber is not null
  and CancerTreatmentIntent is not null
  and TreatmentStartDateCancer is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20COSD%20V9%20HA%20Observation%20Cancer%20Treatment%20Intent%20mapping){: .btn }
### COSD V9 HA Observation Alcohol History Cancer In Last Three Months
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` The date the Primary Cancer was confirmed or the Primary Cancer diagnosis was clinically agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
-- Selects ALCOHOL HISTORY (CANCER IN LAST THREE MONTHS) for Haematological
-- (area HA) records in COSD v9.01, routed to the OMOP observation table as a
-- lifestyle / risk-factor attribute describing current alcohol consumption
-- history (source path HistoryOfAlcoholCurrent).
--
-- The DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) is used as the
-- observation_date.
--
-- Downstream ETL responsibilities:
--   * Resolve NhsNumber against cdm.person to obtain person_id.
--   * Map AlcoholHistoryCancerInLastThreeMonths (NHS National Code) to the
--     standard observation_concept_id and retain the verbatim code in
--     observation_source_value / value_source_value.
--   * Cast DateOfPrimaryDiagnosisClinicallyAgreed (varchar) to a DATE and
--     assign to observation_date / observation_datetime.
select distinct
    -- NHS NUMBER - patient identifier, mandatory; used to join to cdm.person.
    Record ->> '$.LinkagePatientId.NhsNumber.@extension'
        as NhsNumber,
    -- DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) - becomes
    -- observation_date / observation_datetime.
    Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    -- ALCOHOL HISTORY (CANCER IN LAST THREE MONTHS) - the observation value;
    -- mapped downstream to observation_concept_id and retained as
    -- observation_source_value.
    Record ->> '$.ClinicalNurseSpecialistAndRiskFactorAssessments.HistoryOfAlcoholCurrent.@code'
        as AlcoholHistoryCancerInLastThreeMonths
from omop_staging.cosd_staging_901
where type = 'HA'
  and NhsNumber is not null
  and AlcoholHistoryCancerInLastThreeMonths is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20COSD%20V9%20HA%20Observation%20Alcohol%20History%20Cancer%20In%20Last%20Three%20Months%20mapping){: .btn }
### COSD V9 HA Observation Alcohol History Cancer Before Last Three Months
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` The date the Primary Cancer was confirmed or the Primary Cancer diagnosis was clinically agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
-- Selects ALCOHOL HISTORY (CANCER BEFORE LAST THREE MONTHS) for
-- Haematological (area HA) records in COSD v9.01, routed to the OMOP
-- observation table as a lifestyle / risk-factor attribute describing past
-- alcohol consumption history (source path HistoryOfAlcoholPast).
--
-- The DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) is used as the
-- observation_date.
--
-- Downstream ETL responsibilities:
--   * Resolve NhsNumber against cdm.person to obtain person_id.
--   * Map AlcoholHistoryCancerBeforeLastThreeMonths (NHS National Code) to
--     the standard observation_concept_id and retain the verbatim code in
--     observation_source_value / value_source_value.
--   * Cast DateOfPrimaryDiagnosisClinicallyAgreed (varchar) to a DATE and
--     assign to observation_date / observation_datetime.
select distinct
    -- NHS NUMBER - patient identifier, mandatory; used to join to cdm.person.
    Record ->> '$.LinkagePatientId.NhsNumber.@extension'
        as NhsNumber,
    -- DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) - becomes
    -- observation_date / observation_datetime.
    Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    -- ALCOHOL HISTORY (CANCER BEFORE LAST THREE MONTHS) - the observation
    -- value; mapped downstream to observation_concept_id and retained as
    -- observation_source_value.
    Record ->> '$.ClinicalNurseSpecialistAndRiskFactorAssessments.HistoryOfAlcoholPast.@code'
        as AlcoholHistoryCancerBeforeLastThreeMonths
from omop_staging.cosd_staging_901
where type = 'HA'
  and NhsNumber is not null
  and AlcoholHistoryCancerBeforeLastThreeMonths is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20COSD%20V9%20HA%20Observation%20Alcohol%20History%20Cancer%20Before%20Last%20Three%20Months%20mapping){: .btn }
### COSD V8 HA Observation Smoking Status Cancer
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` The date the Primary Cancer was confirmed or the Primary Cancer diagnosis was clinically agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
-- Selects SMOKING STATUS (CANCER) for Haematological (area HA) records in
-- COSD v8.1 (Haematological core structure), routed to the OMOP observation
-- table as a lifestyle / risk-factor attribute. The source path
-- SmokingStatusCode carries the patient's tobacco smoking status.
--
-- The DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) - held in the
-- Haematological core as ClinicalDateCancerDiagnosis - is used as the
-- observation_date.
--
-- Downstream ETL responsibilities:
--   * Resolve NhsNumber against cdm.person to obtain person_id.
--   * Map SmokingStatusCancer (NHS National Code) to the standard
--     observation_concept_id and retain the verbatim code in
--     observation_source_value / value_source_value.
--   * Cast DateOfPrimaryDiagnosisClinicallyAgreed (varchar) to a DATE and
--     assign to observation_date / observation_datetime.
select distinct
    -- NHS NUMBER - patient identifier, mandatory; used to join to cdm.person.
    Record ->> '$.Haematological.HaematologicalCore.HaematologicalCoreLinkagePatientId.NHSNumber.@extension'
        as NhsNumber,
    -- DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) - becomes
    -- observation_date / observation_datetime.
    Record ->> '$.Haematological.HaematologicalCore.HaematologicalCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    -- SMOKING STATUS (CANCER) - the observation value; mapped downstream to
    -- observation_concept_id and retained as observation_source_value.
    Record ->> '$.Haematological.HaematologicalCore.HaematologicalCoreClinicalNurseSpecialistAndRiskFactorAssessments.SmokingStatusCode.@code'
        as SmokingStatusCancer
from omop_staging.cosd_staging_81
where type = 'HA'
  and NhsNumber is not null
  and SmokingStatusCancer is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20COSD%20V8%20HA%20Observation%20Smoking%20Status%20Cancer%20mapping){: .btn }
### COSD V8 HA Observation Performance Status Adult
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` The date the Primary Cancer was confirmed or the Primary Cancer diagnosis was clinically agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
-- Selects PERFORMANCE STATUS (ADULT) for Haematological (area HA) records in
-- COSD v8.1 (Haematological core structure), routed to the OMOP observation
-- table. This WHO performance status is a clinical assessment of the
-- patient's functional status.
--
-- The DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) - held in the
-- Haematological core as ClinicalDateCancerDiagnosis - is used as the
-- observation_date.
--
-- Downstream ETL responsibilities:
--   * Resolve NhsNumber against cdm.person to obtain person_id.
--   * Map PerformanceStatusAdult (NHS National Code) to the standard
--     observation_concept_id and retain the verbatim code in
--     observation_source_value / value_source_value.
--   * Cast DateOfPrimaryDiagnosisClinicallyAgreed (varchar) to a DATE and
--     assign to observation_date / observation_datetime.
select distinct
    -- NHS NUMBER - patient identifier, mandatory; used to join to cdm.person.
    Record ->> '$.Haematological.HaematologicalCore.HaematologicalCoreLinkagePatientId.NHSNumber.@extension'
        as NhsNumber,
    -- DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) - becomes
    -- observation_date / observation_datetime.
    Record ->> '$.Haematological.HaematologicalCore.HaematologicalCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    -- PERFORMANCE STATUS (ADULT) - the observation value; mapped downstream
    -- to observation_concept_id and retained as observation_source_value.
    Record ->> '$.Haematological.HaematologicalCore.HaematologicalCoreDiagnosis.AdultPerformanceStatus.@code'
        as PerformanceStatusAdult
from omop_staging.cosd_staging_81
where type = 'HA'
  and NhsNumber is not null
  and PerformanceStatusAdult is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20COSD%20V8%20HA%20Observation%20Performance%20Status%20Adult%20mapping){: .btn }
### COSD V8 HA Observation Familial Cancer Syndrome Indicator
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` The date the Primary Cancer was confirmed or the Primary Cancer diagnosis was clinically agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
-- Selects FAMILIAL CANCER SYNDROME INDICATOR for Haematological (area HA)
-- records in COSD v8.1 (Haematological core structure), routed to the OMOP
-- observation table as a family-history / risk attribute.
--
-- The DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) - held in the
-- Haematological core as ClinicalDateCancerDiagnosis - is used as the
-- observation_date.
--
-- Downstream ETL responsibilities:
--   * Resolve NhsNumber against cdm.person to obtain person_id.
--   * Map FamilialCancerSyndromeIndicator (NHS National Code) to the
--     standard observation_concept_id and retain the verbatim code in
--     observation_source_value / value_source_value.
--   * Cast DateOfPrimaryDiagnosisClinicallyAgreed (varchar) to a DATE and
--     assign to observation_date / observation_datetime.
select distinct
    -- NHS NUMBER - patient identifier, mandatory; used to join to cdm.person.
    Record ->> '$.Haematological.HaematologicalCore.HaematologicalCoreLinkagePatientId.NHSNumber.@extension'
        as NhsNumber,
    -- DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) - becomes
    -- observation_date / observation_datetime.
    Record ->> '$.Haematological.HaematologicalCore.HaematologicalCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    -- FAMILIAL CANCER SYNDROME INDICATOR - the observation value; mapped
    -- downstream to observation_concept_id and retained as
    -- observation_source_value.
    Record ->> '$.Haematological.HaematologicalCore.HaematologicalCoreDiagnosis.HaematologicalCoreDiagnosisAdditionalItems.FamilialCancerSyndromeIndicator.@code'
        as FamilialCancerSyndromeIndicator
from omop_staging.cosd_staging_81
where type = 'HA'
  and NhsNumber is not null
  and FamilialCancerSyndromeIndicator is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20COSD%20V8%20HA%20Observation%20Familial%20Cancer%20Syndrome%20Indicator%20mapping){: .btn }
### COSD V8 HA Observation Cancer Treatment Intent
Source column  `TreatmentStartDateCancer`.
Converts text to dates.

* `TreatmentStartDateCancer` The start date of a cancer treatment during a Cancer Care Spell. [TREATMENT START DATE (CANCER)](https://www.datadictionary.nhs.uk/data_elements/treatment_start_date__cancer_.html)

```sql
-- Selects CANCER TREATMENT INTENT for Haematological (area HA) records in
-- COSD v8.1 (Haematological core structure), routed to the OMOP observation
-- table. The Treatment section is a repeating array, so the intent and its
-- associated TREATMENT START DATE (CANCER) are unnested in lockstep: the
-- first element of each array list covers the singular-object encoding and
-- the second the JSON-array encoding, keeping each intent paired with its
-- own start date.
--
-- The TREATMENT START DATE (CANCER) is used as the observation_date because
-- the treatment intent is recorded against an individual treatment event.
--
-- Downstream ETL responsibilities:
--   * Resolve NhsNumber against cdm.person to obtain person_id.
--   * Map CancerTreatmentIntent (NHS National Code) to the standard
--     observation_concept_id and retain the verbatim code in
--     observation_source_value / value_source_value.
--   * Cast TreatmentStartDateCancer (varchar) to a DATE and assign to
--     observation_date / observation_datetime.
with ha as (
    select
        -- NHS NUMBER - patient identifier, mandatory; joins to cdm.person.
        Record ->> '$.Haematological.HaematologicalCore.HaematologicalCoreLinkagePatientId.NHSNumber.@extension'
            as NhsNumber,
        -- CANCER TREATMENT INTENT - unnested in lockstep with the start date;
        -- the observation value mapped downstream to observation_concept_id.
        unnest(
            [
                [ Record ->> '$.Haematological.HaematologicalCore.HaematologicalCoreTreatment.CancerTreatmentIntent.@code' ],
                Record ->> '$.Haematological.HaematologicalCore.HaematologicalCoreTreatment[*].CancerTreatmentIntent.@code'
            ],
            recursive := true
        ) as CancerTreatmentIntent,
        -- TREATMENT START DATE (CANCER) - unnested in lockstep with the
        -- intent; becomes observation_date / observation_datetime.
        unnest(
            [
                [ Record ->> '$.Haematological.HaematologicalCore.HaematologicalCoreTreatment.CancerTreatmentStartDate' ],
                Record ->> '$.Haematological.HaematologicalCore.HaematologicalCoreTreatment[*].CancerTreatmentStartDate'
            ],
            recursive := true
        ) as TreatmentStartDateCancer
    from omop_staging.cosd_staging_81
    where type = 'HA'
)
select distinct
    NhsNumber,
    TreatmentStartDateCancer,
    CancerTreatmentIntent
from ha
where NhsNumber is not null
  and CancerTreatmentIntent is not null
  and TreatmentStartDateCancer is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20COSD%20V8%20HA%20Observation%20Cancer%20Treatment%20Intent%20mapping){: .btn }
### COSD V8 HA Observation Alcohol History Cancer In Last Three Months
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` The date the Primary Cancer was confirmed or the Primary Cancer diagnosis was clinically agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
-- Selects ALCOHOL HISTORY (CANCER IN LAST THREE MONTHS) for Haematological
-- (area HA) records in COSD v8.1 (Haematological core structure), routed to
-- the OMOP observation table as a lifestyle / risk-factor attribute
-- describing current alcohol consumption history.
--
-- The DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) - held in the
-- Haematological core as ClinicalDateCancerDiagnosis - is used as the
-- observation_date.
--
-- Downstream ETL responsibilities:
--   * Resolve NhsNumber against cdm.person to obtain person_id.
--   * Map AlcoholHistoryCancerInLastThreeMonths (NHS National Code) to the
--     standard observation_concept_id and retain the verbatim code in
--     observation_source_value / value_source_value.
--   * Cast DateOfPrimaryDiagnosisClinicallyAgreed (varchar) to a DATE and
--     assign to observation_date / observation_datetime.
select distinct
    -- NHS NUMBER - patient identifier, mandatory; used to join to cdm.person.
    Record ->> '$.Haematological.HaematologicalCore.HaematologicalCoreLinkagePatientId.NHSNumber.@extension'
        as NhsNumber,
    -- DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) - becomes
    -- observation_date / observation_datetime.
    Record ->> '$.Haematological.HaematologicalCore.HaematologicalCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    -- ALCOHOL HISTORY (CANCER IN LAST THREE MONTHS) - the observation value;
    -- mapped downstream to observation_concept_id and retained as
    -- observation_source_value.
    Record ->> '$.Haematological.HaematologicalCore.HaematologicalCoreClinicalNurseSpecialistAndRiskFactorAssessments.AlcoholHistoryCancerInLastThreeMonths.@code'
        as AlcoholHistoryCancerInLastThreeMonths
from omop_staging.cosd_staging_81
where type = 'HA'
  and NhsNumber is not null
  and AlcoholHistoryCancerInLastThreeMonths is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20COSD%20V8%20HA%20Observation%20Alcohol%20History%20Cancer%20In%20Last%20Three%20Months%20mapping){: .btn }
### COSD V8 HA Observation Alcohol History Cancer Before Last Three Months
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` The date the Primary Cancer was confirmed or the Primary Cancer diagnosis was clinically agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
-- Selects ALCOHOL HISTORY (CANCER BEFORE LAST THREE MONTHS) for
-- Haematological (area HA) records in COSD v8.1 (Haematological core
-- structure), routed to the OMOP observation table as a lifestyle /
-- risk-factor attribute describing past alcohol consumption history.
--
-- The DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) - held in the
-- Haematological core as ClinicalDateCancerDiagnosis - is used as the
-- observation_date.
--
-- Downstream ETL responsibilities:
--   * Resolve NhsNumber against cdm.person to obtain person_id.
--   * Map AlcoholHistoryCancerBeforeLastThreeMonths (NHS National Code) to
--     the standard observation_concept_id and retain the verbatim code in
--     observation_source_value / value_source_value.
--   * Cast DateOfPrimaryDiagnosisClinicallyAgreed (varchar) to a DATE and
--     assign to observation_date / observation_datetime.
select distinct
    -- NHS NUMBER - patient identifier, mandatory; used to join to cdm.person.
    Record ->> '$.Haematological.HaematologicalCore.HaematologicalCoreLinkagePatientId.NHSNumber.@extension'
        as NhsNumber,
    -- DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) - becomes
    -- observation_date / observation_datetime.
    Record ->> '$.Haematological.HaematologicalCore.HaematologicalCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    -- ALCOHOL HISTORY (CANCER BEFORE LAST THREE MONTHS) - the observation
    -- value; mapped downstream to observation_concept_id and retained as
    -- observation_source_value.
    Record ->> '$.Haematological.HaematologicalCore.HaematologicalCoreClinicalNurseSpecialistAndRiskFactorAssessments.AlcoholHistoryCancerBeforeLastThreeMonths.@code'
        as AlcoholHistoryCancerBeforeLastThreeMonths
from omop_staging.cosd_staging_81
where type = 'HA'
  and NhsNumber is not null
  and AlcoholHistoryCancerBeforeLastThreeMonths is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20COSD%20V8%20HA%20Observation%20Alcohol%20History%20Cancer%20Before%20Last%20Three%20Months%20mapping){: .btn }
### COSD V9 GY Observation Smoking Status Cancer
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` The date the Primary Cancer was confirmed or the Primary Cancer diagnosis was clinically agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
-- Selects SMOKING STATUS (CANCER) for Gynaecological (area GY) records in
-- COSD v9.01, routed to the OMOP observation table as a lifestyle /
-- risk-factor attribute.
--
-- The DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) is used as the
-- observation_date.
--
-- Downstream ETL responsibilities:
--   * Resolve NhsNumber against cdm.person to obtain person_id.
--   * Map SmokingStatusCancer (NHS National Code) to the standard
--     observation_concept_id and retain the verbatim code in
--     observation_source_value / value_source_value.
--   * Cast DateOfPrimaryDiagnosisClinicallyAgreed (varchar) to a DATE and
--     assign to observation_date / observation_datetime.
select distinct
    -- NHS NUMBER - patient identifier, mandatory; used to join to cdm.person.
    Record ->> '$.LinkagePatientId.NhsNumber.@extension'
        as NhsNumber,
    -- DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) - becomes
    -- observation_date / observation_datetime.
    Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    -- SMOKING STATUS (CANCER) - the observation value; mapped downstream to
    -- observation_concept_id and retained as observation_source_value.
    Record ->> '$.ClinicalNurseSpecialistAndRiskFactorAssessments.TobaccoSmokingStatus.@code'
        as SmokingStatusCancer
from omop_staging.cosd_staging_901
where type = 'GY'
  and NhsNumber is not null
  and SmokingStatusCancer is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20COSD%20V9%20GY%20Observation%20Smoking%20Status%20Cancer%20mapping){: .btn }
### COSD V9 GY Observation Performance Status Adult
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` The date the Primary Cancer was confirmed or the Primary Cancer diagnosis was clinically agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
-- Selects PERFORMANCE STATUS (ADULT) for Gynaecological (area GY) records
-- in COSD v9.01, routed to the OMOP observation table. This WHO performance
-- status is a clinical assessment of the patient's functional status.
--
-- The DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) is used as the
-- observation_date.
--
-- Downstream ETL responsibilities:
--   * Resolve NhsNumber against cdm.person to obtain person_id.
--   * Map PerformanceStatusAdult (NHS National Code) to the standard
--     observation_concept_id and retain the verbatim code in
--     observation_source_value / value_source_value.
--   * Cast DateOfPrimaryDiagnosisClinicallyAgreed (varchar) to a DATE and
--     assign to observation_date / observation_datetime.
select distinct
    -- NHS NUMBER - patient identifier, mandatory; used to join to cdm.person.
    Record ->> '$.LinkagePatientId.NhsNumber.@extension'
        as NhsNumber,
    -- DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) - becomes
    -- observation_date / observation_datetime.
    Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    -- PERFORMANCE STATUS (ADULT) - the observation value; mapped downstream
    -- to observation_concept_id and retained as observation_source_value.
    Record ->> '$.PrimaryPathway.Diagnosis.PerformanceStatusAdult.@code'
        as PerformanceStatusAdult
from omop_staging.cosd_staging_901
where type = 'GY'
  and NhsNumber is not null
  and PerformanceStatusAdult is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20COSD%20V9%20GY%20Observation%20Performance%20Status%20Adult%20mapping){: .btn }
### COSD V9 GY Observation Familial Cancer Syndrome Indicator
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` The date the Primary Cancer was confirmed or the Primary Cancer diagnosis was clinically agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
-- Selects FAMILIAL CANCER SYNDROME INDICATOR for Gynaecological (area GY)
-- records in COSD v9.01, routed to the OMOP observation table as a
-- family-history / risk attribute.
--
-- The DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) is used as the
-- observation_date.
--
-- Downstream ETL responsibilities:
--   * Resolve NhsNumber against cdm.person to obtain person_id.
--   * Map FamilialCancerSyndromeIndicator (NHS National Code) to the
--     standard observation_concept_id and retain the verbatim code in
--     observation_source_value / value_source_value.
--   * Cast DateOfPrimaryDiagnosisClinicallyAgreed (varchar) to a DATE and
--     assign to observation_date / observation_datetime.
select distinct
    -- NHS NUMBER - patient identifier, mandatory; used to join to cdm.person.
    Record ->> '$.LinkagePatientId.NhsNumber.@extension'
        as NhsNumber,
    -- DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) - becomes
    -- observation_date / observation_datetime.
    Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    -- FAMILIAL CANCER SYNDROME INDICATOR - the observation value; mapped
    -- downstream to observation_concept_id and retained as
    -- observation_source_value.
    Record ->> '$.PrimaryPathway.Diagnosis.DiagnosisAdditionalItems.FamilialCancerSyndrome.@code'
        as FamilialCancerSyndromeIndicator
from omop_staging.cosd_staging_901
where type = 'GY'
  and NhsNumber is not null
  and FamilialCancerSyndromeIndicator is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20COSD%20V9%20GY%20Observation%20Familial%20Cancer%20Syndrome%20Indicator%20mapping){: .btn }
### COSD V9 GY Observation Cancer Treatment Intent
Source column  `TreatmentStartDateCancer`.
Converts text to dates.

* `TreatmentStartDateCancer` The start date of a cancer treatment during a Cancer Care Spell. [TREATMENT START DATE (CANCER)](https://www.datadictionary.nhs.uk/data_elements/treatment_start_date__cancer_.html)

```sql
-- Selects CANCER TREATMENT INTENT paired with TREATMENT START DATE (CANCER)
-- for Gynaecological (area GY) records in COSD v9.01, routed to the OMOP
-- observation table. Each record's Treatment array carries one
-- (intent, start date) pair per entry, so the JSON paths are unnested in
-- lockstep so each treatment intent keeps its own start date.
--
-- The TREATMENT START DATE (CANCER) is used as the observation_date.
--
-- Downstream ETL responsibilities:
--   * Resolve NhsNumber against cdm.person to obtain person_id.
--   * Map CancerTreatmentIntent (NHS National Code) to the standard
--     observation_concept_id and retain the verbatim code in
--     observation_source_value / value_source_value.
--   * Cast TreatmentStartDateCancer (varchar) to a DATE and assign to
--     observation_date / observation_datetime.
with gy as (
    select
        -- NHS NUMBER - patient identifier, mandatory; used to join to cdm.person.
        Record ->> '$.LinkagePatientId.NhsNumber.@extension'
            as NhsNumber,
        -- CANCER TREATMENT INTENT - the observation value; unnested in
        -- lockstep with the treatment start date.
        unnest([
            [Record ->> '$.Treatment.CancerTreatmentIntent.@code'],
            Record ->> '$.Treatment[*].CancerTreatmentIntent.@code'
        ], recursive := true) as CancerTreatmentIntent,
        -- TREATMENT START DATE (CANCER) - becomes observation_date /
        -- observation_datetime. Paired one-to-one with CancerTreatmentIntent.
        unnest([
            [Record ->> '$.Treatment.TreatmentStartDateCancer'],
            Record ->> '$.Treatment[*].TreatmentStartDateCancer'
        ], recursive := true) as TreatmentStartDateCancer
    from omop_staging.cosd_staging_901
    where type = 'GY'
)
select distinct
    NhsNumber,
    TreatmentStartDateCancer,
    CancerTreatmentIntent
from gy
where NhsNumber is not null
  and CancerTreatmentIntent is not null
  and TreatmentStartDateCancer is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20COSD%20V9%20GY%20Observation%20Cancer%20Treatment%20Intent%20mapping){: .btn }
### COSD V9 GY Observation Alcohol History Cancer In Last Three Months
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` The date the Primary Cancer was confirmed or the Primary Cancer diagnosis was clinically agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
-- Selects ALCOHOL HISTORY (CANCER IN LAST THREE MONTHS) for Gynaecological
-- (area GY) records in COSD v9.01, routed to the OMOP observation table as
-- a lifestyle / risk-factor attribute describing current alcohol
-- consumption history.
--
-- The DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) is used as the
-- observation_date.
--
-- Downstream ETL responsibilities:
--   * Resolve NhsNumber against cdm.person to obtain person_id.
--   * Map AlcoholHistoryCancerInLastThreeMonths (NHS National Code) to the
--     standard observation_concept_id and retain the verbatim code in
--     observation_source_value / value_source_value.
--   * Cast DateOfPrimaryDiagnosisClinicallyAgreed (varchar) to a DATE and
--     assign to observation_date / observation_datetime.
select distinct
    -- NHS NUMBER - patient identifier, mandatory; used to join to cdm.person.
    Record ->> '$.LinkagePatientId.NhsNumber.@extension'
        as NhsNumber,
    -- DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) - becomes
    -- observation_date / observation_datetime.
    Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    -- ALCOHOL HISTORY (CANCER IN LAST THREE MONTHS) - the observation value;
    -- mapped downstream to observation_concept_id and retained as
    -- observation_source_value.
    Record ->> '$.ClinicalNurseSpecialistAndRiskFactorAssessments.HistoryOfAlcoholCurrent.@code'
        as AlcoholHistoryCancerInLastThreeMonths
from omop_staging.cosd_staging_901
where type = 'GY'
  and NhsNumber is not null
  and AlcoholHistoryCancerInLastThreeMonths is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20COSD%20V9%20GY%20Observation%20Alcohol%20History%20Cancer%20In%20Last%20Three%20Months%20mapping){: .btn }
### COSD V9 GY Observation Alcohol History Cancer Before Last Three Months
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` The date the Primary Cancer was confirmed or the Primary Cancer diagnosis was clinically agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
-- Selects ALCOHOL HISTORY (CANCER BEFORE LAST THREE MONTHS) for
-- Gynaecological (area GY) records in COSD v9.01, routed to the OMOP
-- observation table as a lifestyle / risk-factor attribute describing past
-- alcohol consumption history.
--
-- The DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) is used as the
-- observation_date.
--
-- Downstream ETL responsibilities:
--   * Resolve NhsNumber against cdm.person to obtain person_id.
--   * Map AlcoholHistoryCancerBeforeLastThreeMonths (NHS National Code) to
--     the standard observation_concept_id and retain the verbatim code in
--     observation_source_value / value_source_value.
--   * Cast DateOfPrimaryDiagnosisClinicallyAgreed (varchar) to a DATE and
--     assign to observation_date / observation_datetime.
select distinct
    -- NHS NUMBER - patient identifier, mandatory; used to join to cdm.person.
    Record ->> '$.LinkagePatientId.NhsNumber.@extension'
        as NhsNumber,
    -- DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) - becomes
    -- observation_date / observation_datetime.
    Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    -- ALCOHOL HISTORY (CANCER BEFORE LAST THREE MONTHS) - the observation
    -- value; mapped downstream to observation_concept_id and retained as
    -- observation_source_value.
    Record ->> '$.ClinicalNurseSpecialistAndRiskFactorAssessments.HistoryOfAlcoholPast.@code'
        as AlcoholHistoryCancerBeforeLastThreeMonths
from omop_staging.cosd_staging_901
where type = 'GY'
  and NhsNumber is not null
  and AlcoholHistoryCancerBeforeLastThreeMonths is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20COSD%20V9%20GY%20Observation%20Alcohol%20History%20Cancer%20Before%20Last%20Three%20Months%20mapping){: .btn }
### COSD V8 GY Observation Smoking Status Cancer
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` The date the Primary Cancer was confirmed or the Primary Cancer diagnosis was clinically agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
-- Selects SMOKING STATUS (CANCER) for Gynaecological (area GY) records in
-- COSD v8.1 (Gynaecological core structure), routed to the OMOP observation
-- table as a lifestyle / risk-factor attribute. The source path
-- SmokingStatusCode carries the patient's tobacco smoking status.
--
-- The DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) - held in the
-- Gynaecological core as ClinicalDateCancerDiagnosis - is used as the
-- observation_date.
--
-- Downstream ETL responsibilities:
--   * Resolve NhsNumber against cdm.person to obtain person_id.
--   * Map SmokingStatusCancer (NHS National Code) to the standard
--     observation_concept_id and retain the verbatim code in
--     observation_source_value / value_source_value.
--   * Cast DateOfPrimaryDiagnosisClinicallyAgreed (varchar) to a DATE and
--     assign to observation_date / observation_datetime.
select distinct
    -- NHS NUMBER - patient identifier, mandatory; used to join to cdm.person.
    Record ->> '$.Gynaecological.GynaecologicalCore.GynaecologicalCoreLinkagePatientId.NHSNumber.@extension'
        as NhsNumber,
    -- DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) - becomes
    -- observation_date / observation_datetime.
    Record ->> '$.Gynaecological.GynaecologicalCore.GynaecologicalCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    -- SMOKING STATUS (CANCER) - the observation value; mapped downstream to
    -- observation_concept_id and retained as observation_source_value.
    Record ->> '$.Gynaecological.GynaecologicalCore.GynaecologicalCoreClinicalNurseSpecialistAndRiskFactorAssessments.SmokingStatusCode.@code'
        as SmokingStatusCancer
from omop_staging.cosd_staging_81
where type = 'GY'
  and NhsNumber is not null
  and SmokingStatusCancer is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20COSD%20V8%20GY%20Observation%20Smoking%20Status%20Cancer%20mapping){: .btn }
### COSD V8 GY Observation Performance Status Adult
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` The date the Primary Cancer was confirmed or the Primary Cancer diagnosis was clinically agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
-- Selects PERFORMANCE STATUS (ADULT) for Gynaecological (area GY) records in
-- COSD v8.1 (Gynaecological core structure), routed to the OMOP observation
-- table. This WHO performance status is a clinical assessment of the
-- patient's functional status.
--
-- The DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) - held in the
-- Gynaecological core as ClinicalDateCancerDiagnosis - is used as the
-- observation_date.
--
-- Downstream ETL responsibilities:
--   * Resolve NhsNumber against cdm.person to obtain person_id.
--   * Map PerformanceStatusAdult (NHS National Code) to the standard
--     observation_concept_id and retain the verbatim code in
--     observation_source_value / value_source_value.
--   * Cast DateOfPrimaryDiagnosisClinicallyAgreed (varchar) to a DATE and
--     assign to observation_date / observation_datetime.
select distinct
    -- NHS NUMBER - patient identifier, mandatory; used to join to cdm.person.
    Record ->> '$.Gynaecological.GynaecologicalCore.GynaecologicalCoreLinkagePatientId.NHSNumber.@extension'
        as NhsNumber,
    -- DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) - becomes
    -- observation_date / observation_datetime.
    Record ->> '$.Gynaecological.GynaecologicalCore.GynaecologicalCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    -- PERFORMANCE STATUS (ADULT) - the observation value; mapped downstream
    -- to observation_concept_id and retained as observation_source_value.
    Record ->> '$.Gynaecological.GynaecologicalCore.GynaecologicalCoreDiagnosis.AdultPerformanceStatus.@code'
        as PerformanceStatusAdult
from omop_staging.cosd_staging_81
where type = 'GY'
  and NhsNumber is not null
  and PerformanceStatusAdult is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20COSD%20V8%20GY%20Observation%20Performance%20Status%20Adult%20mapping){: .btn }
### COSD V8 GY Observation Familial Cancer Syndrome Indicator
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` The date the Primary Cancer was confirmed or the Primary Cancer diagnosis was clinically agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
-- Selects FAMILIAL CANCER SYNDROME INDICATOR for Gynaecological (area GY)
-- records in COSD v8.1 (Gynaecological core structure), routed to the OMOP
-- observation table as a family-history / risk attribute.
--
-- The DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) - held in the
-- Gynaecological core as ClinicalDateCancerDiagnosis - is used as the
-- observation_date.
--
-- Downstream ETL responsibilities:
--   * Resolve NhsNumber against cdm.person to obtain person_id.
--   * Map FamilialCancerSyndromeIndicator (NHS National Code) to the
--     standard observation_concept_id and retain the verbatim code in
--     observation_source_value / value_source_value.
--   * Cast DateOfPrimaryDiagnosisClinicallyAgreed (varchar) to a DATE and
--     assign to observation_date / observation_datetime.
select distinct
    -- NHS NUMBER - patient identifier, mandatory; used to join to cdm.person.
    Record ->> '$.Gynaecological.GynaecologicalCore.GynaecologicalCoreLinkagePatientId.NHSNumber.@extension'
        as NhsNumber,
    -- DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) - becomes
    -- observation_date / observation_datetime.
    Record ->> '$.Gynaecological.GynaecologicalCore.GynaecologicalCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    -- FAMILIAL CANCER SYNDROME INDICATOR - the observation value; mapped
    -- downstream to observation_concept_id and retained as
    -- observation_source_value.
    Record ->> '$.Gynaecological.GynaecologicalCore.GynaecologicalCoreDiagnosis.GynaecologicalCoreDiagnosisAdditionalItems.FamilialCancerSyndromeIndicator.@code'
        as FamilialCancerSyndromeIndicator
from omop_staging.cosd_staging_81
where type = 'GY'
  and NhsNumber is not null
  and FamilialCancerSyndromeIndicator is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20COSD%20V8%20GY%20Observation%20Familial%20Cancer%20Syndrome%20Indicator%20mapping){: .btn }
### COSD V8 GY Observation Cancer Treatment Intent
Source column  `TreatmentStartDateCancer`.
Converts text to dates.

* `TreatmentStartDateCancer` The start date of a cancer treatment during a Cancer Care Spell. [TREATMENT START DATE (CANCER)](https://www.datadictionary.nhs.uk/data_elements/treatment_start_date__cancer_.html)

```sql
-- Selects CANCER TREATMENT INTENT for Gynaecological (area GY) records in
-- COSD v8.1 (Gynaecological core structure), routed to the OMOP observation
-- table. The Treatment section is a repeating array, so the intent and its
-- associated TREATMENT START DATE (CANCER) are unnested in lockstep: the
-- first element of each array list covers the singular-object encoding and
-- the second the JSON-array encoding, keeping each intent paired with its
-- own start date.
--
-- The TREATMENT START DATE (CANCER) is used as the observation_date because
-- the treatment intent is recorded against an individual treatment event.
--
-- Downstream ETL responsibilities:
--   * Resolve NhsNumber against cdm.person to obtain person_id.
--   * Map CancerTreatmentIntent (NHS National Code) to the standard
--     observation_concept_id and retain the verbatim code in
--     observation_source_value / value_source_value.
--   * Cast TreatmentStartDateCancer (varchar) to a DATE and assign to
--     observation_date / observation_datetime.
with gy as (
    select distinct
        -- NHS NUMBER - patient identifier, mandatory; joins to cdm.person.
        Record ->> '$.Gynaecological.GynaecologicalCore.GynaecologicalCoreLinkagePatientId.NHSNumber.@extension'
            as NhsNumber,
        -- TREATMENT START DATE (CANCER) - unnested in lockstep with the
        -- intent; becomes observation_date / observation_datetime.
        unnest(
            [
                [ Record ->> '$.Gynaecological.GynaecologicalCore.GynaecologicalCoreTreatment.CancerTreatmentStartDate' ],
                Record ->> '$.Gynaecological.GynaecologicalCore.GynaecologicalCoreTreatment[*].CancerTreatmentStartDate'
            ],
            recursive := true
        ) as TreatmentStartDateCancer,
        -- CANCER TREATMENT INTENT - unnested in lockstep with the start date;
        -- the observation value mapped downstream to observation_concept_id.
        unnest(
            [
                [ Record ->> '$.Gynaecological.GynaecologicalCore.GynaecologicalCoreTreatment.CancerTreatmentIntent.@code' ],
                Record ->> '$.Gynaecological.GynaecologicalCore.GynaecologicalCoreTreatment[*].CancerTreatmentIntent.@code'
            ],
            recursive := true
        ) as CancerTreatmentIntent
    from omop_staging.cosd_staging_81
    where type = 'GY'
)
select distinct
    NhsNumber,
    TreatmentStartDateCancer,
    CancerTreatmentIntent
from gy
where NhsNumber is not null
  and CancerTreatmentIntent is not null
  and TreatmentStartDateCancer is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20COSD%20V8%20GY%20Observation%20Cancer%20Treatment%20Intent%20mapping){: .btn }
### COSD V8 GY Observation Alcohol History Cancer In Last Three Months
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` The date the Primary Cancer was confirmed or the Primary Cancer diagnosis was clinically agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
-- Selects ALCOHOL HISTORY (CANCER IN LAST THREE MONTHS) for Gynaecological
-- (area GY) records in COSD v8.1 (Gynaecological core structure), routed to
-- the OMOP observation table as a lifestyle / risk-factor attribute
-- describing current alcohol consumption history.
--
-- The DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) - held in the
-- Gynaecological core as ClinicalDateCancerDiagnosis - is used as the
-- observation_date.
--
-- Downstream ETL responsibilities:
--   * Resolve NhsNumber against cdm.person to obtain person_id.
--   * Map AlcoholHistoryCancerInLastThreeMonths (NHS National Code) to the
--     standard observation_concept_id and retain the verbatim code in
--     observation_source_value / value_source_value.
--   * Cast DateOfPrimaryDiagnosisClinicallyAgreed (varchar) to a DATE and
--     assign to observation_date / observation_datetime.
select distinct
    -- NHS NUMBER - patient identifier, mandatory; used to join to cdm.person.
    Record ->> '$.Gynaecological.GynaecologicalCore.GynaecologicalCoreLinkagePatientId.NHSNumber.@extension'
        as NhsNumber,
    -- DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) - becomes
    -- observation_date / observation_datetime.
    Record ->> '$.Gynaecological.GynaecologicalCore.GynaecologicalCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    -- ALCOHOL HISTORY (CANCER IN LAST THREE MONTHS) - the observation value;
    -- mapped downstream to observation_concept_id and retained as
    -- observation_source_value.
    Record ->> '$.Gynaecological.GynaecologicalCore.GynaecologicalCoreClinicalNurseSpecialistAndRiskFactorAssessments.AlcoholHistoryCancerInLastThreeMonths.@code'
        as AlcoholHistoryCancerInLastThreeMonths
from omop_staging.cosd_staging_81
where type = 'GY'
  and NhsNumber is not null
  and AlcoholHistoryCancerInLastThreeMonths is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20COSD%20V8%20GY%20Observation%20Alcohol%20History%20Cancer%20In%20Last%20Three%20Months%20mapping){: .btn }
### COSD V8 GY Observation Alcohol History Cancer Before Last Three Months
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` The date the Primary Cancer was confirmed or the Primary Cancer diagnosis was clinically agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
-- Selects ALCOHOL HISTORY (CANCER BEFORE LAST THREE MONTHS) for
-- Gynaecological (area GY) records in COSD v8.1 (Gynaecological core
-- structure), routed to the OMOP observation table as a lifestyle /
-- risk-factor attribute describing past alcohol consumption history.
--
-- The DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) - held in the
-- Gynaecological core as ClinicalDateCancerDiagnosis - is used as the
-- observation_date.
--
-- Downstream ETL responsibilities:
--   * Resolve NhsNumber against cdm.person to obtain person_id.
--   * Map AlcoholHistoryCancerBeforeLastThreeMonths (NHS National Code) to
--     the standard observation_concept_id and retain the verbatim code in
--     observation_source_value / value_source_value.
--   * Cast DateOfPrimaryDiagnosisClinicallyAgreed (varchar) to a DATE and
--     assign to observation_date / observation_datetime.
select distinct
    -- NHS NUMBER - patient identifier, mandatory; used to join to cdm.person.
    Record ->> '$.Gynaecological.GynaecologicalCore.GynaecologicalCoreLinkagePatientId.NHSNumber.@extension'
        as NhsNumber,
    -- DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) - becomes
    -- observation_date / observation_datetime.
    Record ->> '$.Gynaecological.GynaecologicalCore.GynaecologicalCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    -- ALCOHOL HISTORY (CANCER BEFORE LAST THREE MONTHS) - the observation
    -- value; mapped downstream to observation_concept_id and retained as
    -- observation_source_value.
    Record ->> '$.Gynaecological.GynaecologicalCore.GynaecologicalCoreClinicalNurseSpecialistAndRiskFactorAssessments.AlcoholHistoryCancerBeforeLastThreeMonths.@code'
        as AlcoholHistoryCancerBeforeLastThreeMonths
from omop_staging.cosd_staging_81
where type = 'GY'
  and NhsNumber is not null
  and AlcoholHistoryCancerBeforeLastThreeMonths is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20COSD%20V8%20GY%20Observation%20Alcohol%20History%20Cancer%20Before%20Last%20Three%20Months%20mapping){: .btn }
### COSD V9 CT Observation Tobacco Smoking Cessation Treatment Indication Code
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` The date the Primary Cancer was confirmed or the Primary Cancer diagnosis was clinically agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
-- Selects TOBACCO SMOKING CESSATION TREATMENT INDICATION CODE for Children,
-- Teenagers and Young Adults (area CT) records in COSD v9.01, routed to the
-- OMOP observation table as a lifestyle / risk-factor attribute.
--
-- The DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) is used as the
-- observation_date.
--
-- Downstream ETL responsibilities:
--   * Resolve NhsNumber against cdm.person to obtain person_id.
--   * Map TobaccoSmokingCessationTreatmentIndicationCode (NHS National Code)
--     to the standard observation_concept_id and retain the verbatim code in
--     observation_source_value / value_source_value.
--   * Cast DateOfPrimaryDiagnosisClinicallyAgreed (varchar) to a DATE and
--     assign to observation_date / observation_datetime.
select distinct
    -- NHS NUMBER - patient identifier, mandatory; used to join to cdm.person.
    Record ->> '$.LinkagePatientId.NhsNumber.@extension'
        as NhsNumber,
    -- DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) - becomes
    -- observation_date / observation_datetime.
    Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    -- TOBACCO SMOKING CESSATION TREATMENT INDICATION CODE - the observation
    -- value; mapped downstream to observation_concept_id and retained as
    -- observation_source_value.
    Record ->> '$.ClinicalNurseSpecialistAndRiskFactorAssessments.TobaccoSmokingCessation.@code'
        as TobaccoSmokingCessationTreatmentIndicationCode
from omop_staging.cosd_staging_901
where type = 'CT'
  and NhsNumber is not null
  and TobaccoSmokingCessationTreatmentIndicationCode is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20COSD%20V9%20CT%20Observation%20Tobacco%20Smoking%20Cessation%20Treatment%20Indication%20Code%20mapping){: .btn }
### COSD V9 CT Observation Smoking Status Cancer
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` The date the Primary Cancer was confirmed or the Primary Cancer diagnosis was clinically agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
-- Selects SMOKING STATUS (CANCER) for Children, Teenagers and Young Adults
-- (area CT) records in COSD v9.01, routed to the OMOP observation table as
-- a lifestyle / risk-factor attribute.
--
-- The DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) is used as the
-- observation_date.
--
-- Downstream ETL responsibilities:
--   * Resolve NhsNumber against cdm.person to obtain person_id.
--   * Map SmokingStatusCancer (NHS National Code) to the standard
--     observation_concept_id and retain the verbatim code in
--     observation_source_value / value_source_value.
--   * Cast DateOfPrimaryDiagnosisClinicallyAgreed (varchar) to a DATE and
--     assign to observation_date / observation_datetime.
select distinct
    -- NHS NUMBER - patient identifier, mandatory; used to join to cdm.person.
    Record ->> '$.LinkagePatientId.NhsNumber.@extension'
        as NhsNumber,
    -- DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) - becomes
    -- observation_date / observation_datetime.
    Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    -- SMOKING STATUS (CANCER) - the observation value; mapped downstream to
    -- observation_concept_id and retained as observation_source_value.
    Record ->> '$.ClinicalNurseSpecialistAndRiskFactorAssessments.TobaccoSmokingStatus.@code'
        as SmokingStatusCancer
from omop_staging.cosd_staging_901
where type = 'CT'
  and NhsNumber is not null
  and SmokingStatusCancer is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20COSD%20V9%20CT%20Observation%20Smoking%20Status%20Cancer%20mapping){: .btn }
### COSD V9 CT Observation Performance Status Adult
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` The date the Primary Cancer was confirmed or the Primary Cancer diagnosis was clinically agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
-- Selects PERFORMANCE STATUS (ADULT) for Children, Teenagers and Young
-- Adults (area CT) records in COSD v9.01, routed to the OMOP observation
-- table. This WHO performance status is a clinical assessment of the
-- patient's functional status.
--
-- The DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) is used as the
-- observation_date.
--
-- Downstream ETL responsibilities:
--   * Resolve NhsNumber against cdm.person to obtain person_id.
--   * Map PerformanceStatusAdult (NHS National Code) to the standard
--     observation_concept_id and retain the verbatim code in
--     observation_source_value / value_source_value.
--   * Cast DateOfPrimaryDiagnosisClinicallyAgreed (varchar) to a DATE and
--     assign to observation_date / observation_datetime.
select distinct
    -- NHS NUMBER - patient identifier, mandatory; used to join to cdm.person.
    Record ->> '$.LinkagePatientId.NhsNumber.@extension'
        as NhsNumber,
    -- DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) - becomes
    -- observation_date / observation_datetime.
    Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    -- PERFORMANCE STATUS (ADULT) - the observation value; mapped downstream
    -- to observation_concept_id and retained as observation_source_value.
    Record ->> '$.PrimaryPathway.Diagnosis.PerformanceStatusAdult.@code'
        as PerformanceStatusAdult
from omop_staging.cosd_staging_901
where type = 'CT'
  and NhsNumber is not null
  and PerformanceStatusAdult is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20COSD%20V9%20CT%20Observation%20Performance%20Status%20Adult%20mapping){: .btn }
### COSD V9 CT Observation Familial Cancer Syndrome Indicator
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` The date the Primary Cancer was confirmed or the Primary Cancer diagnosis was clinically agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
-- Selects FAMILIAL CANCER SYNDROME INDICATOR for Children, Teenagers and
-- Young Adults (area CT) records in COSD v9.01, routed to the OMOP
-- observation table as a family-history / risk attribute.
--
-- The DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) is used as the
-- observation_date.
--
-- Downstream ETL responsibilities:
--   * Resolve NhsNumber against cdm.person to obtain person_id.
--   * Map FamilialCancerSyndromeIndicator (NHS National Code) to the
--     standard observation_concept_id and retain the verbatim code in
--     observation_source_value / value_source_value.
--   * Cast DateOfPrimaryDiagnosisClinicallyAgreed (varchar) to a DATE and
--     assign to observation_date / observation_datetime.
select distinct
    -- NHS NUMBER - patient identifier, mandatory; used to join to cdm.person.
    Record ->> '$.LinkagePatientId.NhsNumber.@extension'
        as NhsNumber,
    -- DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) - becomes
    -- observation_date / observation_datetime.
    Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    -- FAMILIAL CANCER SYNDROME INDICATOR - the observation value; mapped
    -- downstream to observation_concept_id and retained as
    -- observation_source_value.
    Record ->> '$.PrimaryPathway.Diagnosis.DiagnosisAdditionalItems.FamilialCancerSyndrome.@code'
        as FamilialCancerSyndromeIndicator
from omop_staging.cosd_staging_901
where type = 'CT'
  and NhsNumber is not null
  and FamilialCancerSyndromeIndicator is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20COSD%20V9%20CT%20Observation%20Familial%20Cancer%20Syndrome%20Indicator%20mapping){: .btn }
### COSD V9 CT Observation Cancer Treatment Intent
Source column  `TreatmentStartDateCancer`.
Converts text to dates.

* `TreatmentStartDateCancer` The start date of a cancer treatment during a Cancer Care Spell. [TREATMENT START DATE (CANCER)](https://www.datadictionary.nhs.uk/data_elements/treatment_start_date__cancer_.html)

```sql
-- Selects CANCER TREATMENT INTENT paired with TREATMENT START DATE (CANCER)
-- for Children, Teenagers and Young Adults (area CT) records in COSD v9.01,
-- routed to the OMOP observation table. Each record's Treatment array
-- carries one (intent, start date) pair per entry, so the JSON paths are
-- unnested in lockstep so each treatment intent keeps its own start date.
--
-- The TREATMENT START DATE (CANCER) is used as the observation_date.
--
-- Downstream ETL responsibilities:
--   * Resolve NhsNumber against cdm.person to obtain person_id.
--   * Map CancerTreatmentIntent (NHS National Code) to the standard
--     observation_concept_id and retain the verbatim code in
--     observation_source_value / value_source_value.
--   * Cast TreatmentStartDateCancer (varchar) to a DATE and assign to
--     observation_date / observation_datetime.
with ct as (
    select
        -- NHS NUMBER - patient identifier, mandatory; used to join to cdm.person.
        Record ->> '$.LinkagePatientId.NhsNumber.@extension'
            as NhsNumber,
        -- CANCER TREATMENT INTENT - the observation value; unnested in
        -- lockstep with the treatment start date.
        unnest([
            [Record ->> '$.Treatment.CancerTreatmentIntent.@code'],
            Record ->> '$.Treatment[*].CancerTreatmentIntent.@code'
        ], recursive := true) as CancerTreatmentIntent,
        -- TREATMENT START DATE (CANCER) - becomes observation_date /
        -- observation_datetime. Paired one-to-one with CancerTreatmentIntent.
        unnest([
            [Record ->> '$.Treatment.TreatmentStartDateCancer'],
            Record ->> '$.Treatment[*].TreatmentStartDateCancer'
        ], recursive := true) as TreatmentStartDateCancer
    from omop_staging.cosd_staging_901
    where type = 'CT'
)
select distinct
    NhsNumber,
    TreatmentStartDateCancer,
    CancerTreatmentIntent
from ct
where NhsNumber is not null
  and CancerTreatmentIntent is not null
  and TreatmentStartDateCancer is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20COSD%20V9%20CT%20Observation%20Cancer%20Treatment%20Intent%20mapping){: .btn }
### COSD V9 CT Observation Alcohol History Cancer In Last Three Months
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` The date the Primary Cancer was confirmed or the Primary Cancer diagnosis was clinically agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
-- Selects ALCOHOL HISTORY (CANCER IN LAST THREE MONTHS) for Children,
-- Teenagers and Young Adults (area CT) records in COSD v9.01, routed to the
-- OMOP observation table as a lifestyle / risk-factor attribute describing
-- current alcohol consumption history.
--
-- The DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) is used as the
-- observation_date.
--
-- Downstream ETL responsibilities:
--   * Resolve NhsNumber against cdm.person to obtain person_id.
--   * Map AlcoholHistoryCancerInLastThreeMonths (NHS National Code) to the
--     standard observation_concept_id and retain the verbatim code in
--     observation_source_value / value_source_value.
--   * Cast DateOfPrimaryDiagnosisClinicallyAgreed (varchar) to a DATE and
--     assign to observation_date / observation_datetime.
select distinct
    -- NHS NUMBER - patient identifier, mandatory; used to join to cdm.person.
    Record ->> '$.LinkagePatientId.NhsNumber.@extension'
        as NhsNumber,
    -- DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) - becomes
    -- observation_date / observation_datetime.
    Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    -- ALCOHOL HISTORY (CANCER IN LAST THREE MONTHS) - the observation value;
    -- mapped downstream to observation_concept_id and retained as
    -- observation_source_value.
    Record ->> '$.ClinicalNurseSpecialistAndRiskFactorAssessments.HistoryOfAlcoholCurrent.@code'
        as AlcoholHistoryCancerInLastThreeMonths
from omop_staging.cosd_staging_901
where type = 'CT'
  and NhsNumber is not null
  and AlcoholHistoryCancerInLastThreeMonths is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20COSD%20V9%20CT%20Observation%20Alcohol%20History%20Cancer%20In%20Last%20Three%20Months%20mapping){: .btn }
### COSD V9 CT Observation Alcohol History Cancer Before Last Three Months
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` The date the Primary Cancer was confirmed or the Primary Cancer diagnosis was clinically agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
-- Selects ALCOHOL HISTORY (CANCER BEFORE LAST THREE MONTHS) for Children,
-- Teenagers and Young Adults (area CT) records in COSD v9.01, routed to the
-- OMOP observation table as a lifestyle / risk-factor attribute describing
-- past alcohol consumption history.
--
-- The DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) is used as the
-- observation_date.
--
-- Downstream ETL responsibilities:
--   * Resolve NhsNumber against cdm.person to obtain person_id.
--   * Map AlcoholHistoryCancerBeforeLastThreeMonths (NHS National Code) to
--     the standard observation_concept_id and retain the verbatim code in
--     observation_source_value / value_source_value.
--   * Cast DateOfPrimaryDiagnosisClinicallyAgreed (varchar) to a DATE and
--     assign to observation_date / observation_datetime.
select distinct
    -- NHS NUMBER - patient identifier, mandatory; used to join to cdm.person.
    Record ->> '$.LinkagePatientId.NhsNumber.@extension'
        as NhsNumber,
    -- DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) - becomes
    -- observation_date / observation_datetime.
    Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    -- ALCOHOL HISTORY (CANCER BEFORE LAST THREE MONTHS) - the observation
    -- value; mapped downstream to observation_concept_id and retained as
    -- observation_source_value.
    Record ->> '$.ClinicalNurseSpecialistAndRiskFactorAssessments.HistoryOfAlcoholPast.@code'
        as AlcoholHistoryCancerBeforeLastThreeMonths
from omop_staging.cosd_staging_901
where type = 'CT'
  and NhsNumber is not null
  and AlcoholHistoryCancerBeforeLastThreeMonths is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20COSD%20V9%20CT%20Observation%20Alcohol%20History%20Cancer%20Before%20Last%20Three%20Months%20mapping){: .btn }
### COSD V8 CT Observation Smoking Status Cancer
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` The date the Primary Cancer was confirmed or the Primary Cancer diagnosis was clinically agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
-- Selects SMOKING STATUS (CANCER) for Children, Teenagers and Young Adults
-- (area CT) records in COSD v8.1 (CTYA core structure), routed to the OMOP
-- observation table as a lifestyle / risk-factor attribute. The source path
-- SmokingStatusCode carries the patient's tobacco smoking status.
--
-- The DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) - held in the
-- CTYA core as ClinicalDateCancerDiagnosis - is used as the observation_date.
--
-- Downstream ETL responsibilities:
--   * Resolve NhsNumber against cdm.person to obtain person_id.
--   * Map SmokingStatusCancer (NHS National Code) to the standard
--     observation_concept_id and retain the verbatim code in
--     observation_source_value / value_source_value.
--   * Cast DateOfPrimaryDiagnosisClinicallyAgreed (varchar) to a DATE and
--     assign to observation_date / observation_datetime.
select distinct
    -- NHS NUMBER - patient identifier, mandatory; used to join to cdm.person.
    Record ->> '$.CTYA.CTYACore.CTYACoreLinkagePatientId.NHSNumber.@extension'
        as NhsNumber,
    -- DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) - becomes
    -- observation_date / observation_datetime.
    Record ->> '$.CTYA.CTYACore.CTYACoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    -- SMOKING STATUS (CANCER) - the observation value; mapped downstream to
    -- observation_concept_id and retained as observation_source_value.
    Record ->> '$.CTYA.CTYACore.CTYACoreClinicalNurseSpecialistAndRiskFactorAssessments.SmokingStatusCode.@code'
        as SmokingStatusCancer
from omop_staging.cosd_staging_81
where type = 'CT'
  and NhsNumber is not null
  and SmokingStatusCancer is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20COSD%20V8%20CT%20Observation%20Smoking%20Status%20Cancer%20mapping){: .btn }
### COSD V8 CT Observation Performance Status Adult
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` The date the Primary Cancer was confirmed or the Primary Cancer diagnosis was clinically agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
-- Selects PERFORMANCE STATUS (ADULT) for Children, Teenagers and Young
-- Adults (area CT) records in COSD v8.1 (CTYA core structure), routed to the
-- OMOP observation table. This WHO performance status is a clinical
-- assessment of the patient's functional status.
--
-- The DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) - held in the
-- CTYA core as ClinicalDateCancerDiagnosis - is used as the observation_date.
--
-- Downstream ETL responsibilities:
--   * Resolve NhsNumber against cdm.person to obtain person_id.
--   * Map PerformanceStatusAdult (NHS National Code) to the standard
--     observation_concept_id and retain the verbatim code in
--     observation_source_value / value_source_value.
--   * Cast DateOfPrimaryDiagnosisClinicallyAgreed (varchar) to a DATE and
--     assign to observation_date / observation_datetime.
select distinct
    -- NHS NUMBER - patient identifier, mandatory; used to join to cdm.person.
    Record ->> '$.CTYA.CTYACore.CTYACoreLinkagePatientId.NHSNumber.@extension'
        as NhsNumber,
    -- DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) - becomes
    -- observation_date / observation_datetime.
    Record ->> '$.CTYA.CTYACore.CTYACoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    -- PERFORMANCE STATUS (ADULT) - the observation value; mapped downstream
    -- to observation_concept_id and retained as observation_source_value.
    Record ->> '$.CTYA.CTYACore.CTYACoreDiagnosis.AdultPerformanceStatus.@code'
        as PerformanceStatusAdult
from omop_staging.cosd_staging_81
where type = 'CT'
  and NhsNumber is not null
  and PerformanceStatusAdult is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20COSD%20V8%20CT%20Observation%20Performance%20Status%20Adult%20mapping){: .btn }
### COSD V8 CT Observation Familial Cancer Syndrome Indicator
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` The date the Primary Cancer was confirmed or the Primary Cancer diagnosis was clinically agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
-- Selects FAMILIAL CANCER SYNDROME INDICATOR for Children, Teenagers and
-- Young Adults (area CT) records in COSD v8.1 (CTYA core structure), routed
-- to the OMOP observation table as a family-history / risk attribute.
--
-- The DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) - held in the
-- CTYA core as ClinicalDateCancerDiagnosis - is used as the observation_date.
--
-- Downstream ETL responsibilities:
--   * Resolve NhsNumber against cdm.person to obtain person_id.
--   * Map FamilialCancerSyndromeIndicator (NHS National Code) to the
--     standard observation_concept_id and retain the verbatim code in
--     observation_source_value / value_source_value.
--   * Cast DateOfPrimaryDiagnosisClinicallyAgreed (varchar) to a DATE and
--     assign to observation_date / observation_datetime.
select distinct
    -- NHS NUMBER - patient identifier, mandatory; used to join to cdm.person.
    Record ->> '$.CTYA.CTYACore.CTYACoreLinkagePatientId.NHSNumber.@extension'
        as NhsNumber,
    -- DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) - becomes
    -- observation_date / observation_datetime.
    Record ->> '$.CTYA.CTYACore.CTYACoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    -- FAMILIAL CANCER SYNDROME INDICATOR - the observation value; mapped
    -- downstream to observation_concept_id and retained as
    -- observation_source_value.
    Record ->> '$.CTYA.CTYACore.CTYACoreDiagnosis.CTYACoreDiagnosisAdditionalItems.FamilialCancerSyndromeIndicator.@code'
        as FamilialCancerSyndromeIndicator
from omop_staging.cosd_staging_81
where type = 'CT'
  and NhsNumber is not null
  and FamilialCancerSyndromeIndicator is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20COSD%20V8%20CT%20Observation%20Familial%20Cancer%20Syndrome%20Indicator%20mapping){: .btn }
### COSD V8 CT Observation Alcohol History Cancer In Last Three Months
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` The date the Primary Cancer was confirmed or the Primary Cancer diagnosis was clinically agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
-- Selects ALCOHOL HISTORY (CANCER IN LAST THREE MONTHS) for Children,
-- Teenagers and Young Adults (area CT) records in COSD v8.1 (CTYA core
-- structure), routed to the OMOP observation table as a lifestyle /
-- risk-factor attribute describing current alcohol consumption history.
--
-- The DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) - held in the
-- CTYA core as ClinicalDateCancerDiagnosis - is used as the observation_date.
--
-- Downstream ETL responsibilities:
--   * Resolve NhsNumber against cdm.person to obtain person_id.
--   * Map AlcoholHistoryCancerInLastThreeMonths (NHS National Code) to the
--     standard observation_concept_id and retain the verbatim code in
--     observation_source_value / value_source_value.
--   * Cast DateOfPrimaryDiagnosisClinicallyAgreed (varchar) to a DATE and
--     assign to observation_date / observation_datetime.
select distinct
    -- NHS NUMBER - patient identifier, mandatory; used to join to cdm.person.
    Record ->> '$.CTYA.CTYACore.CTYACoreLinkagePatientId.NHSNumber.@extension'
        as NhsNumber,
    -- DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) - becomes
    -- observation_date / observation_datetime.
    Record ->> '$.CTYA.CTYACore.CTYACoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    -- ALCOHOL HISTORY (CANCER IN LAST THREE MONTHS) - the observation value;
    -- mapped downstream to observation_concept_id and retained as
    -- observation_source_value.
    Record ->> '$.CTYA.CTYACore.CTYACoreClinicalNurseSpecialistAndRiskFactorAssessments.AlcoholHistoryCancerInLastThreeMonths.@code'
        as AlcoholHistoryCancerInLastThreeMonths
from omop_staging.cosd_staging_81
where type = 'CT'
  and NhsNumber is not null
  and AlcoholHistoryCancerInLastThreeMonths is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20COSD%20V8%20CT%20Observation%20Alcohol%20History%20Cancer%20In%20Last%20Three%20Months%20mapping){: .btn }
### COSD V8 CT Observation Alcohol History Cancer Before Last Three Months
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` The date the Primary Cancer was confirmed or the Primary Cancer diagnosis was clinically agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
-- Selects ALCOHOL HISTORY (CANCER BEFORE LAST THREE MONTHS) for Children,
-- Teenagers and Young Adults (area CT) records in COSD v8.1 (CTYA core
-- structure), routed to the OMOP observation table as a lifestyle /
-- risk-factor attribute describing past alcohol consumption history.
--
-- The DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) - held in the
-- CTYA core as ClinicalDateCancerDiagnosis - is used as the observation_date.
--
-- Downstream ETL responsibilities:
--   * Resolve NhsNumber against cdm.person to obtain person_id.
--   * Map AlcoholHistoryCancerBeforeLastThreeMonths (NHS National Code) to
--     the standard observation_concept_id and retain the verbatim code in
--     observation_source_value / value_source_value.
--   * Cast DateOfPrimaryDiagnosisClinicallyAgreed (varchar) to a DATE and
--     assign to observation_date / observation_datetime.
select distinct
    -- NHS NUMBER - patient identifier, mandatory; used to join to cdm.person.
    Record ->> '$.CTYA.CTYACore.CTYACoreLinkagePatientId.NHSNumber.@extension'
        as NhsNumber,
    -- DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) - becomes
    -- observation_date / observation_datetime.
    Record ->> '$.CTYA.CTYACore.CTYACoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    -- ALCOHOL HISTORY (CANCER BEFORE LAST THREE MONTHS) - the observation
    -- value; mapped downstream to observation_concept_id and retained as
    -- observation_source_value.
    Record ->> '$.CTYA.CTYACore.CTYACoreClinicalNurseSpecialistAndRiskFactorAssessments.AlcoholHistoryCancerBeforeLastThreeMonths.@code'
        as AlcoholHistoryCancerBeforeLastThreeMonths
from omop_staging.cosd_staging_81
where type = 'CT'
  and NhsNumber is not null
  and AlcoholHistoryCancerBeforeLastThreeMonths is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20COSD%20V8%20CT%20Observation%20Alcohol%20History%20Cancer%20Before%20Last%20Three%20Months%20mapping){: .btn }
### COSD V9 CR Observation Tobacco Smoking Cessation Treatment Indication Code
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` The date the Primary Cancer was confirmed or the Primary Cancer diagnosis was clinically agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
-- Selects TOBACCO SMOKING CESSATION TREATMENT INDICATION CODE for
-- Colorectal (CR) records in COSD v9.01, routed to the OMOP observation
-- table as a lifestyle / risk-factor attribute indicating whether the
-- patient received tobacco smoking cessation treatment.
--
-- The DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) is used as the
-- observation_date because the risk-factor assessment is recorded around
-- the point of diagnosis.
--
-- Downstream ETL responsibilities:
--   * Resolve NhsNumber against cdm.person to obtain person_id.
--   * Map TobaccoSmokingCessationTreatmentIndicationCode (NHS National Code)
--     to the standard observation_concept_id and retain the verbatim code in
--     observation_source_value / value_source_value.
--   * Cast DateOfPrimaryDiagnosisClinicallyAgreed (varchar) to a DATE and
--     assign to observation_date / observation_datetime.
select distinct
    -- NHS NUMBER - patient identifier, mandatory; used to join to cdm.person.
    Record ->> '$.LinkagePatientId.NhsNumber.@extension'
        as NhsNumber,
    -- DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) - becomes
    -- observation_date / observation_datetime.
    Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    -- TOBACCO SMOKING CESSATION TREATMENT INDICATION CODE - the observation
    -- value; mapped downstream to observation_concept_id and retained as
    -- observation_source_value.
    Record ->> '$.ClinicalNurseSpecialistAndRiskFactorAssessments.TobaccoSmokingCessation.@code'
        as TobaccoSmokingCessationTreatmentIndicationCode
from omop_staging.cosd_staging_901
where type = 'CR'
  and NhsNumber is not null
  and TobaccoSmokingCessationTreatmentIndicationCode is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20COSD%20V9%20CR%20Observation%20Tobacco%20Smoking%20Cessation%20Treatment%20Indication%20Code%20mapping){: .btn }
### COSD V9 CR Observation Smoking Status Cancer
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` The date the Primary Cancer was confirmed or the Primary Cancer diagnosis was clinically agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
-- Selects SMOKING STATUS (CANCER) for Colorectal (CR) records in COSD
-- v9.01, routed to the OMOP observation table as a lifestyle / risk-factor
-- attribute. The source path TobaccoSmokingStatus carries the patient's
-- tobacco smoking status.
--
-- The DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) is used as the
-- observation_date because the risk-factor assessment is recorded around
-- the point of diagnosis.
--
-- Downstream ETL responsibilities:
--   * Resolve NhsNumber against cdm.person to obtain person_id.
--   * Map SmokingStatusCancer (NHS National Code) to the standard
--     observation_concept_id and retain the verbatim code in
--     observation_source_value / value_source_value.
--   * Cast DateOfPrimaryDiagnosisClinicallyAgreed (varchar) to a DATE and
--     assign to observation_date / observation_datetime.
select distinct
    -- NHS NUMBER - patient identifier, mandatory; used to join to cdm.person.
    Record ->> '$.LinkagePatientId.NhsNumber.@extension'
        as NhsNumber,
    -- DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) - becomes
    -- observation_date / observation_datetime.
    Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    -- SMOKING STATUS (CANCER) - the observation value; mapped downstream to
    -- observation_concept_id and retained as observation_source_value.
    Record ->> '$.ClinicalNurseSpecialistAndRiskFactorAssessments.TobaccoSmokingStatus.@code'
        as SmokingStatusCancer
from omop_staging.cosd_staging_901
where type = 'CR'
  and NhsNumber is not null
  and SmokingStatusCancer is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20COSD%20V9%20CR%20Observation%20Smoking%20Status%20Cancer%20mapping){: .btn }
### COSD V9 CR Observation Performance Status Adult
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` The date the Primary Cancer was confirmed or the Primary Cancer diagnosis was clinically agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
-- Selects PERFORMANCE STATUS (ADULT) for Colorectal (CR) records in
-- COSD v9.01, routed to the OMOP observation table. This WHO performance
-- status is a clinical assessment of the patient's functional status.
--
-- The DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) is used as the
-- observation_date because the performance status is recorded around the
-- point of diagnosis.
--
-- Downstream ETL responsibilities:
--   * Resolve NhsNumber against cdm.person to obtain person_id.
--   * Map PerformanceStatusAdult (NHS National Code) to the standard
--     observation_concept_id and retain the verbatim code in
--     observation_source_value / value_source_value.
--   * Cast DateOfPrimaryDiagnosisClinicallyAgreed (varchar) to a DATE and
--     assign to observation_date / observation_datetime.
select distinct
    -- NHS NUMBER - patient identifier, mandatory; used to join to cdm.person.
    Record ->> '$.LinkagePatientId.NhsNumber.@extension'
        as NhsNumber,
    -- DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) - becomes
    -- observation_date / observation_datetime.
    Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    -- PERFORMANCE STATUS (ADULT) - the observation value; mapped downstream
    -- to observation_concept_id and retained as observation_source_value.
    Record ->> '$.PrimaryPathway.Diagnosis.PerformanceStatusAdult.@code'
        as PerformanceStatusAdult
from omop_staging.cosd_staging_901
where type = 'CR'
  and NhsNumber is not null
  and PerformanceStatusAdult is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20COSD%20V9%20CR%20Observation%20Performance%20Status%20Adult%20mapping){: .btn }
### COSD V9 CR Observation Familial Cancer Syndrome Indicator
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` The date the Primary Cancer was confirmed or the Primary Cancer diagnosis was clinically agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
-- Selects FAMILIAL CANCER SYNDROME INDICATOR for Colorectal (CR) records in
-- COSD v9.01, routed to the OMOP observation table as a family / medical
-- history indicator showing whether a familial cancer syndrome is possible
-- or confirmed.
--
-- The DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) is used as the
-- observation_date because the indicator is recorded as part of the
-- diagnosis additional items.
--
-- Downstream ETL responsibilities:
--   * Resolve NhsNumber against cdm.person to obtain person_id.
--   * Map FamilialCancerSyndromeIndicator (NHS National Code) to the
--     standard observation_concept_id and retain the verbatim code in
--     observation_source_value / value_source_value.
--   * Cast DateOfPrimaryDiagnosisClinicallyAgreed (varchar) to a DATE and
--     assign to observation_date / observation_datetime.
select distinct
    -- NHS NUMBER - patient identifier, mandatory; used to join to cdm.person.
    Record ->> '$.LinkagePatientId.NhsNumber.@extension'
        as NhsNumber,
    -- DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) - becomes
    -- observation_date / observation_datetime.
    Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    -- FAMILIAL CANCER SYNDROME INDICATOR - the observation value; mapped
    -- downstream to observation_concept_id and retained as
    -- observation_source_value.
    Record ->> '$.PrimaryPathway.Diagnosis.DiagnosisAdditionalItems.FamilialCancerSyndrome.@code'
        as FamilialCancerSyndromeIndicator
from omop_staging.cosd_staging_901
where type = 'CR'
  and NhsNumber is not null
  and FamilialCancerSyndromeIndicator is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20COSD%20V9%20CR%20Observation%20Familial%20Cancer%20Syndrome%20Indicator%20mapping){: .btn }
### COSD V9 CR Observation Cancer Treatment Intent
Source column  `TreatmentStartDateCancer`.
Converts text to dates.

* `TreatmentStartDateCancer` The start date of a cancer treatment during a Cancer Care Spell. [TREATMENT START DATE (CANCER)](https://www.datadictionary.nhs.uk/data_elements/treatment_start_date__cancer_.html)

```sql
-- Selects CANCER TREATMENT INTENT paired with TREATMENT START DATE (CANCER)
-- for Colorectal (CR) records in COSD v9.01, routed to the OMOP observation
-- table. Each record's Treatment array carries one (intent, start date)
-- pair per entry, so the JSON paths are unnested in lockstep so each
-- treatment intent keeps its own start date.
--
-- The TREATMENT START DATE (CANCER) is used as the observation_date because
-- the treatment intent applies to that treatment event.
--
-- Downstream ETL responsibilities:
--   * Resolve NhsNumber against cdm.person to obtain person_id.
--   * Map CancerTreatmentIntent (NHS National Code) to the standard
--     observation_concept_id and retain the verbatim code in
--     observation_source_value / value_source_value.
--   * Cast TreatmentStartDateCancer (varchar) to a DATE and assign to
--     observation_date / observation_datetime.
with cr as (
    select
        -- NHS NUMBER - patient identifier, mandatory; used to join to cdm.person.
        Record ->> '$.LinkagePatientId.NhsNumber.@extension'
            as NhsNumber,
        -- CANCER TREATMENT INTENT - the observation value; unnested in
        -- lockstep with the treatment start date.
        unnest([
            [Record ->> '$.Treatment.CancerTreatmentIntent.@code'],
            Record ->> '$.Treatment[*].CancerTreatmentIntent.@code'
        ], recursive := true) as CancerTreatmentIntent,
        -- TREATMENT START DATE (CANCER) - becomes observation_date /
        -- observation_datetime. Paired one-to-one with CancerTreatmentIntent.
        unnest([
            [Record ->> '$.Treatment.TreatmentStartDateCancer'],
            Record ->> '$.Treatment[*].TreatmentStartDateCancer'
        ], recursive := true) as TreatmentStartDateCancer
    from omop_staging.cosd_staging_901
    where type = 'CR'
)
select distinct
    NhsNumber,
    TreatmentStartDateCancer,
    CancerTreatmentIntent
from cr
where NhsNumber is not null
  and CancerTreatmentIntent is not null
  and TreatmentStartDateCancer is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20COSD%20V9%20CR%20Observation%20Cancer%20Treatment%20Intent%20mapping){: .btn }
### COSD V9 CR Observation Alcohol History Cancer In Last Three Months
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` The date the Primary Cancer was confirmed or the Primary Cancer diagnosis was clinically agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
-- Selects ALCOHOL HISTORY (CANCER IN LAST THREE MONTHS) for Colorectal (CR)
-- records in COSD v9.01, routed to the OMOP observation table as a
-- lifestyle / risk-factor attribute. The source path HistoryOfAlcoholCurrent
-- carries the current alcohol consumption history.
--
-- The DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) is used as the
-- observation_date because the risk-factor assessment is recorded around
-- the point of diagnosis.
--
-- Downstream ETL responsibilities:
--   * Resolve NhsNumber against cdm.person to obtain person_id.
--   * Map AlcoholHistoryCancerInLastThreeMonths (NHS National Code) to the
--     standard observation_concept_id and retain the verbatim code in
--     observation_source_value / value_source_value.
--   * Cast DateOfPrimaryDiagnosisClinicallyAgreed (varchar) to a DATE and
--     assign to observation_date / observation_datetime.
select distinct
    -- NHS NUMBER - patient identifier, mandatory; used to join to cdm.person.
    Record ->> '$.LinkagePatientId.NhsNumber.@extension'
        as NhsNumber,
    -- DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) - becomes
    -- observation_date / observation_datetime.
    Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    -- ALCOHOL HISTORY (CANCER IN LAST THREE MONTHS) - the observation value;
    -- mapped downstream to observation_concept_id and retained as
    -- observation_source_value.
    Record ->> '$.ClinicalNurseSpecialistAndRiskFactorAssessments.HistoryOfAlcoholCurrent.@code'
        as AlcoholHistoryCancerInLastThreeMonths
from omop_staging.cosd_staging_901
where type = 'CR'
  and NhsNumber is not null
  and AlcoholHistoryCancerInLastThreeMonths is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20COSD%20V9%20CR%20Observation%20Alcohol%20History%20Cancer%20In%20Last%20Three%20Months%20mapping){: .btn }
### COSD V9 CR Observation Alcohol History Cancer Before Last Three Months
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` The date the Primary Cancer was confirmed or the Primary Cancer diagnosis was clinically agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
-- Selects ALCOHOL HISTORY (CANCER BEFORE LAST THREE MONTHS) for Colorectal
-- (CR) records in COSD v9.01, routed to the OMOP observation table as a
-- lifestyle / risk-factor attribute. The source path HistoryOfAlcoholPast
-- carries the past alcohol consumption history.
--
-- The DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) is used as the
-- observation_date because the risk-factor assessment is recorded around
-- the point of diagnosis.
--
-- Downstream ETL responsibilities:
--   * Resolve NhsNumber against cdm.person to obtain person_id.
--   * Map AlcoholHistoryCancerBeforeLastThreeMonths (NHS National Code) to
--     the standard observation_concept_id and retain the verbatim code in
--     observation_source_value / value_source_value.
--   * Cast DateOfPrimaryDiagnosisClinicallyAgreed (varchar) to a DATE and
--     assign to observation_date / observation_datetime.
select distinct
    -- NHS NUMBER - patient identifier, mandatory; used to join to cdm.person.
    Record ->> '$.LinkagePatientId.NhsNumber.@extension'
        as NhsNumber,
    -- DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) - becomes
    -- observation_date / observation_datetime.
    Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    -- ALCOHOL HISTORY (CANCER BEFORE LAST THREE MONTHS) - the observation
    -- value; mapped downstream to observation_concept_id and retained as
    -- observation_source_value.
    Record ->> '$.ClinicalNurseSpecialistAndRiskFactorAssessments.HistoryOfAlcoholPast.@code'
        as AlcoholHistoryCancerBeforeLastThreeMonths
from omop_staging.cosd_staging_901
where type = 'CR'
  and NhsNumber is not null
  and AlcoholHistoryCancerBeforeLastThreeMonths is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20COSD%20V9%20CR%20Observation%20Alcohol%20History%20Cancer%20Before%20Last%20Three%20Months%20mapping){: .btn }
### COSD V8 CR Observation Smoking Status Cancer
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` The date the Primary Cancer was confirmed or the Primary Cancer diagnosis was clinically agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
-- Selects SMOKING STATUS (CANCER) for Colorectal (CR) records in COSD v8.1
-- (Core structure), routed to the OMOP observation table as a lifestyle /
-- risk-factor attribute. The source path SmokingStatusCode carries the
-- patient's tobacco smoking status.
--
-- The DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) - held in the
-- Core as ClinicalDateCancerDiagnosis - is used as the observation_date.
--
-- Downstream ETL responsibilities:
--   * Resolve NhsNumber against cdm.person to obtain person_id.
--   * Map SmokingStatusCancer (NHS National Code) to the standard
--     observation_concept_id and retain the verbatim code in
--     observation_source_value / value_source_value.
--   * Cast DateOfPrimaryDiagnosisClinicallyAgreed (varchar) to a DATE and
--     assign to observation_date / observation_datetime.
select distinct
    -- NHS NUMBER - patient identifier, mandatory; used to join to cdm.person.
    Record ->> '$.Core.CoreCore.CoreLinkagePatientId.NHSNumber.@extension'
        as NhsNumber,
    -- DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) - becomes
    -- observation_date / observation_datetime.
    Record ->> '$.Core.CoreCore.CoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    -- SMOKING STATUS (CANCER) - the observation value; mapped downstream to
    -- observation_concept_id and retained as observation_source_value.
    Record ->> '$.Core.CoreCore.CoreClinicalNurseSpecialistAndRiskFactorAssessments.SmokingStatusCode.@code'
        as SmokingStatusCancer
from omop_staging.cosd_staging_81
where type = 'CR'
  and NhsNumber is not null
  and SmokingStatusCancer is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20COSD%20V8%20CR%20Observation%20Smoking%20Status%20Cancer%20mapping){: .btn }
### COSD V8 CR Observation Performance Status Adult
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` The date the Primary Cancer was confirmed or the Primary Cancer diagnosis was clinically agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
-- Selects PERFORMANCE STATUS (ADULT) for Colorectal (CR) records in COSD
-- v8.1 (Core structure), routed to the OMOP observation table. This WHO
-- performance status is a clinical assessment of the patient's functional
-- status.
--
-- The DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) - held in the
-- Core as ClinicalDateCancerDiagnosis - is used as the observation_date.
--
-- Downstream ETL responsibilities:
--   * Resolve NhsNumber against cdm.person to obtain person_id.
--   * Map PerformanceStatusAdult (NHS National Code) to the standard
--     observation_concept_id and retain the verbatim code in
--     observation_source_value / value_source_value.
--   * Cast DateOfPrimaryDiagnosisClinicallyAgreed (varchar) to a DATE and
--     assign to observation_date / observation_datetime.
select distinct
    -- NHS NUMBER - patient identifier, mandatory; used to join to cdm.person.
    Record ->> '$.Core.CoreCore.CoreLinkagePatientId.NHSNumber.@extension'
        as NhsNumber,
    -- DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) - becomes
    -- observation_date / observation_datetime.
    Record ->> '$.Core.CoreCore.CoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    -- PERFORMANCE STATUS (ADULT) - the observation value; mapped downstream
    -- to observation_concept_id and retained as observation_source_value.
    Record ->> '$.Core.CoreCore.CoreDiagnosis.AdultPerformanceStatus.@code'
        as PerformanceStatusAdult
from omop_staging.cosd_staging_81
where type = 'CR'
  and NhsNumber is not null
  and PerformanceStatusAdult is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20COSD%20V8%20CR%20Observation%20Performance%20Status%20Adult%20mapping){: .btn }
### COSD V8 CR Observation Cancer Treatment Intent
Source column  `TreatmentStartDateCancer`.
Converts text to dates.

* `TreatmentStartDateCancer` The start date of a cancer treatment during a Cancer Care Spell. [TREATMENT START DATE (CANCER)](https://www.datadictionary.nhs.uk/data_elements/treatment_start_date__cancer_.html)

```sql
-- Selects CANCER TREATMENT INTENT paired with TREATMENT START DATE (CANCER)
-- for Colorectal (CR) records in COSD v8.1 (Core structure), routed to the
-- OMOP observation table. Each record's CoreTreatment array carries one
-- (intent, start date) pair per entry, so the JSON paths are unnested in
-- lockstep so each treatment intent keeps its own start date.
--
-- The TREATMENT START DATE (CANCER) is used as the observation_date because
-- the treatment intent applies to that treatment event.
--
-- Downstream ETL responsibilities:
--   * Resolve NhsNumber against cdm.person to obtain person_id.
--   * Map CancerTreatmentIntent (NHS National Code) to the standard
--     observation_concept_id and retain the verbatim code in
--     observation_source_value / value_source_value.
--   * Cast TreatmentStartDateCancer (varchar) to a DATE and assign to
--     observation_date / observation_datetime.
with cr as (
    select
        -- NHS NUMBER - patient identifier, mandatory; used to join to cdm.person.
        Record ->> '$.Core.CoreCore.CoreLinkagePatientId.NHSNumber.@extension'
            as NhsNumber,
        -- CANCER TREATMENT INTENT - the observation value; unnested in
        -- lockstep with the treatment start date.
        unnest([
            [Record ->> '$.Core.CoreCore.CoreTreatment.CancerTreatmentIntent.@code'],
            Record ->> '$.Core.CoreCore.CoreTreatment[*].CancerTreatmentIntent.@code'
        ], recursive := true) as CancerTreatmentIntent,
        -- TREATMENT START DATE (CANCER) - becomes observation_date /
        -- observation_datetime. Paired one-to-one with CancerTreatmentIntent.
        unnest([
            [Record ->> '$.Core.CoreCore.CoreTreatment.CancerTreatmentStartDate'],
            Record ->> '$.Core.CoreCore.CoreTreatment[*].CancerTreatmentStartDate'
        ], recursive := true) as TreatmentStartDateCancer
    from omop_staging.cosd_staging_81
    where type = 'CR'
)
select distinct
    NhsNumber,
    TreatmentStartDateCancer,
    CancerTreatmentIntent
from cr
where NhsNumber is not null
  and CancerTreatmentIntent is not null
  and TreatmentStartDateCancer is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20COSD%20V8%20CR%20Observation%20Cancer%20Treatment%20Intent%20mapping){: .btn }
### COSD V8 CR Observation Alcohol History Cancer In Last Three Months
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` The date the Primary Cancer was confirmed or the Primary Cancer diagnosis was clinically agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
-- Selects ALCOHOL HISTORY (CANCER IN LAST THREE MONTHS) for Colorectal (CR)
-- records in COSD v8.1 (Core structure), routed to the OMOP observation
-- table as a lifestyle / risk-factor attribute describing current alcohol
-- consumption history.
--
-- The DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) - held in the
-- Core as ClinicalDateCancerDiagnosis - is used as the observation_date.
--
-- Downstream ETL responsibilities:
--   * Resolve NhsNumber against cdm.person to obtain person_id.
--   * Map AlcoholHistoryCancerInLastThreeMonths (NHS National Code) to the
--     standard observation_concept_id and retain the verbatim code in
--     observation_source_value / value_source_value.
--   * Cast DateOfPrimaryDiagnosisClinicallyAgreed (varchar) to a DATE and
--     assign to observation_date / observation_datetime.
select distinct
    -- NHS NUMBER - patient identifier, mandatory; used to join to cdm.person.
    Record ->> '$.Core.CoreCore.CoreLinkagePatientId.NHSNumber.@extension'
        as NhsNumber,
    -- DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) - becomes
    -- observation_date / observation_datetime.
    Record ->> '$.Core.CoreCore.CoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    -- ALCOHOL HISTORY (CANCER IN LAST THREE MONTHS) - the observation value;
    -- mapped downstream to observation_concept_id and retained as
    -- observation_source_value.
    Record ->> '$.Core.CoreCore.CoreClinicalNurseSpecialistAndRiskFactorAssessments.AlcoholHistoryCancerInLastThreeMonths.@code'
        as AlcoholHistoryCancerInLastThreeMonths
from omop_staging.cosd_staging_81
where type = 'CR'
  and NhsNumber is not null
  and AlcoholHistoryCancerInLastThreeMonths is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20COSD%20V8%20CR%20Observation%20Alcohol%20History%20Cancer%20In%20Last%20Three%20Months%20mapping){: .btn }
### COSD V8 CR Observation Alcohol History Cancer Before Last Three Months
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` The date the Primary Cancer was confirmed or the Primary Cancer diagnosis was clinically agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
-- Selects ALCOHOL HISTORY (CANCER BEFORE LAST THREE MONTHS) for Colorectal
-- (CR) records in COSD v8.1 (Core structure), routed to the OMOP
-- observation table as a lifestyle / risk-factor attribute describing past
-- alcohol consumption history.
--
-- The DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) - held in the
-- Core as ClinicalDateCancerDiagnosis - is used as the observation_date.
--
-- Downstream ETL responsibilities:
--   * Resolve NhsNumber against cdm.person to obtain person_id.
--   * Map AlcoholHistoryCancerBeforeLastThreeMonths (NHS National Code) to
--     the standard observation_concept_id and retain the verbatim code in
--     observation_source_value / value_source_value.
--   * Cast DateOfPrimaryDiagnosisClinicallyAgreed (varchar) to a DATE and
--     assign to observation_date / observation_datetime.
select distinct
    -- NHS NUMBER - patient identifier, mandatory; used to join to cdm.person.
    Record ->> '$.Core.CoreCore.CoreLinkagePatientId.NHSNumber.@extension'
        as NhsNumber,
    -- DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) - becomes
    -- observation_date / observation_datetime.
    Record ->> '$.Core.CoreCore.CoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    -- ALCOHOL HISTORY (CANCER BEFORE LAST THREE MONTHS) - the observation
    -- value; mapped downstream to observation_concept_id and retained as
    -- observation_source_value.
    Record ->> '$.Core.CoreCore.CoreClinicalNurseSpecialistAndRiskFactorAssessments.AlcoholHistoryCancerBeforeLastThreeMonths.@code'
        as AlcoholHistoryCancerBeforeLastThreeMonths
from omop_staging.cosd_staging_81
where type = 'CR'
  and NhsNumber is not null
  and AlcoholHistoryCancerBeforeLastThreeMonths is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20COSD%20V8%20CR%20Observation%20Alcohol%20History%20Cancer%20Before%20Last%20Three%20Months%20mapping){: .btn }
### CosdV9TobaccoSmokingStatus
* Value copied from `Date`

* `Date` Observation date [DATE FIRST SEEN](https://www.datadictionary.nhs.uk/data_elements/date_first_seen.html), [DATE FIRST SEEN (CANCER SPECIALIST)](https://www.datadictionary.nhs.uk/data_elements/date_first_seen__cancer_specialist_.html), [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html), [TNM STAGE GROUPING DATE (FINAL PRETREATMENT)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping_date__final_pretreatment_.html), [TNM STAGE GROUPING DATE (INTEGRATED)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping_date__integrated_.html), [TREATMENT START DATE (CANCER)](https://www.datadictionary.nhs.uk/data_elements/treatment_start_date__cancer_.html), [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

```sql
with CO as (
	select
		Record ->> '$.PrimaryPathway.ReferralAndFirstStageOfPatientPathway.DateFirstSeen' as DateFirstSeen,
		Record ->> '$.PrimaryPathway.ReferralAndFirstStageOfPatientPathway.DateFirstSeenCancerSpecialist' as DateFirstSeenCancerSpecialist,
		Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed' as DateOfPrimaryDiagnosisClinicallyAgreed,
		Record ->> '$.PrimaryPathway.Staging.StageDateFinalPretreatmentStage' as StageDateFinalPretreatmentStage,
		Record ->> '$.PrimaryPathway.Staging.StageDateIntegratedStage' as StageDateIntegratedStage,
		  coalesce(Record ->> '$.Treatment[0].TreatmentStartDateCancer', Record ->> '$.Treatment.TreatmentStartDateCancer') as TreatmentStartDateCancer,
		coalesce(Record ->> '$.Treatment[0].Surgery.ProcedureDate', Record ->> '$.Treatment.Surgery.ProcedureDate') as ProcedureDate,
		Record ->> '$.ClinicalNurseSpecialistAndRiskFactorAssessments.TobaccoSmokingStatus.@code' as TobaccoSmokingStatus,
		Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber
	from omop_staging.cosd_staging_901
	where type = 'CO'
)
select
	distinct
		TobaccoSmokingStatus,
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
from CO o
where o.TobaccoSmokingStatus is not null
  and not (
		DateFirstSeen is null and
		DateFirstSeenCancerSpecialist is null and
		DateOfPrimaryDiagnosisClinicallyAgreed is null and
		StageDateFinalPretreatmentStage is null and
		StageDateIntegratedStage is null and
		TreatmentStartDateCancer is null and
		ProcedureDate is null
    );
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20CosdV9TobaccoSmokingStatus%20mapping){: .btn }
### CosdV9TobaccoSmokingCessation
* Value copied from `Date`

* `Date` Observation date [DATE FIRST SEEN](https://www.datadictionary.nhs.uk/data_elements/date_first_seen.html), [DATE FIRST SEEN (CANCER SPECIALIST)](https://www.datadictionary.nhs.uk/data_elements/date_first_seen__cancer_specialist_.html), [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html), [TNM STAGE GROUPING DATE (FINAL PRETREATMENT)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping_date__final_pretreatment_.html), [TNM STAGE GROUPING DATE (INTEGRATED)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping_date__integrated_.html), [TREATMENT START DATE (CANCER)](https://www.datadictionary.nhs.uk/data_elements/treatment_start_date__cancer_.html), [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

```sql
with CO as (
	select
		Record ->> '$.PrimaryPathway.ReferralAndFirstStageOfPatientPathway.DateFirstSeen' as DateFirstSeen,
		Record ->> '$.PrimaryPathway.ReferralAndFirstStageOfPatientPathway.DateFirstSeenCancerSpecialist' as DateFirstSeenCancerSpecialist,
		Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed' as DateOfPrimaryDiagnosisClinicallyAgreed,
		Record ->> '$.PrimaryPathway.Staging.StageDateFinalPretreatmentStage' as StageDateFinalPretreatmentStage,
		Record ->> '$.PrimaryPathway.Staging.StageDateIntegratedStage' as StageDateIntegratedStage,
		  coalesce(Record ->> '$.Treatment[0].TreatmentStartDateCancer', Record ->> '$.Treatment.TreatmentStartDateCancer') as TreatmentStartDateCancer,
		coalesce(Record ->> '$.Treatment[0].Surgery.ProcedureDate', Record ->> '$.Treatment.Surgery.ProcedureDate') as ProcedureDate,
		Record ->> '$.ClinicalNurseSpecialistAndRiskFactorAssessments.TobaccoSmokingCessation.@code' as TobaccoSmokingCessation,
		Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber
	from omop_staging.cosd_staging_901
	where type = 'CO'
)
select
	distinct
		TobaccoSmokingCessation,
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
from CO o
where o.TobaccoSmokingCessation is not null
  and not (
		DateFirstSeen is null and
		DateFirstSeenCancerSpecialist is null and
		DateOfPrimaryDiagnosisClinicallyAgreed is null and
		StageDateFinalPretreatmentStage is null and
		StageDateIntegratedStage is null and
		TreatmentStartDateCancer is null and
		ProcedureDate is null
    );
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20CosdV9TobaccoSmokingCessation%20mapping){: .btn }
### CosdV9SourceOfReferralForOutpatients
* Value copied from `Date`

* `Date` Observation date [DATE FIRST SEEN](https://www.datadictionary.nhs.uk/data_elements/date_first_seen.html), [DATE FIRST SEEN (CANCER SPECIALIST)](https://www.datadictionary.nhs.uk/data_elements/date_first_seen__cancer_specialist_.html), [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html), [TNM STAGE GROUPING DATE (FINAL PRETREATMENT)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping_date__final_pretreatment_.html), [TNM STAGE GROUPING DATE (INTEGRATED)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping_date__integrated_.html), [TREATMENT START DATE (CANCER)](https://www.datadictionary.nhs.uk/data_elements/treatment_start_date__cancer_.html), [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

```sql
with CO as (
	select
		Record ->> '$.PrimaryPathway.ReferralAndFirstStageOfPatientPathway.DateFirstSeen' as DateFirstSeen,
		Record ->> '$.PrimaryPathway.ReferralAndFirstStageOfPatientPathway.DateFirstSeenCancerSpecialist' as DateFirstSeenCancerSpecialist,
		Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed' as DateOfPrimaryDiagnosisClinicallyAgreed,
		Record ->> '$.PrimaryPathway.Staging.StageDateFinalPretreatmentStage' as StageDateFinalPretreatmentStage,
		Record ->> '$.PrimaryPathway.Staging.StageDateIntegratedStage' as StageDateIntegratedStage,
		  coalesce(Record ->> '$.Treatment[0].TreatmentStartDateCancer', Record ->> '$.Treatment.TreatmentStartDateCancer') as TreatmentStartDateCancer,
		coalesce(Record ->> '$.Treatment[0].Surgery.ProcedureDate', Record ->> '$.Treatment.Surgery.ProcedureDate') as ProcedureDate,
		Record ->> '$.PrimaryPathway.ReferralAndFirstStageOfPatientPathway."SourceOfReferralForOut-patients"."@code"' as SourceOfReferralForOutpatients,
		Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber
	from omop_staging.cosd_staging_901
	where type = 'CO'
)
select
	distinct
		SourceOfReferralForOutpatients,
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
from CO o
where o.SourceOfReferralForOutpatients is not null
  and not (
		DateFirstSeen is null and
		DateFirstSeenCancerSpecialist is null and
		DateOfPrimaryDiagnosisClinicallyAgreed is null and
		StageDateFinalPretreatmentStage is null and
		StageDateIntegratedStage is null and
		TreatmentStartDateCancer is null and
		ProcedureDate is null
    );
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20CosdV9SourceOfReferralForOutpatients%20mapping){: .btn }
### CosdV9SourceOfReferralForNonPrimaryCancerPathway
* Value copied from `Date`

* `Date` Observation date [DATE FIRST SEEN](https://www.datadictionary.nhs.uk/data_elements/date_first_seen.html), [DATE FIRST SEEN (CANCER SPECIALIST)](https://www.datadictionary.nhs.uk/data_elements/date_first_seen__cancer_specialist_.html), [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html), [TNM STAGE GROUPING DATE (FINAL PRETREATMENT)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping_date__final_pretreatment_.html), [TNM STAGE GROUPING DATE (INTEGRATED)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping_date__integrated_.html), [TREATMENT START DATE (CANCER)](https://www.datadictionary.nhs.uk/data_elements/treatment_start_date__cancer_.html), [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

```sql
with CO as (
	select
		Record ->> '$.PrimaryPathway.ReferralAndFirstStageOfPatientPathway.DateFirstSeen' as DateFirstSeen,
		Record ->> '$.PrimaryPathway.ReferralAndFirstStageOfPatientPathway.DateFirstSeenCancerSpecialist' as DateFirstSeenCancerSpecialist,
		Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed' as DateOfPrimaryDiagnosisClinicallyAgreed,
		Record ->> '$.PrimaryPathway.Staging.StageDateFinalPretreatmentStage' as StageDateFinalPretreatmentStage,
		Record ->> '$.PrimaryPathway.Staging.StageDateIntegratedStage' as StageDateIntegratedStage,
		coalesce(Record ->> '$.Treatment[0].TreatmentStartDateCancer', Record ->> '$.Treatment.TreatmentStartDateCancer') as TreatmentStartDateCancer,
		coalesce(Record ->> '$.Treatment[0].Surgery.ProcedureDate', Record ->> '$.Treatment.Surgery.ProcedureDate') as ProcedureDate,
		Record ->> '$.NonPrimaryPathway.NonPrimaryCancerPathwayReferral.SourceOfReferralForNonPrimaryCancerPathway.@code' as SourceOfReferralForNonPrimaryCancerPathway,
		Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber
	from omop_staging.cosd_staging_901
	where type = 'CO'
)
select
	distinct
		SourceOfReferralForNonPrimaryCancerPathway,
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
from CO o
where o.SourceOfReferralForNonPrimaryCancerPathway is not null
  and not (
		DateFirstSeen is null and
		DateFirstSeenCancerSpecialist is null and
		DateOfPrimaryDiagnosisClinicallyAgreed is null and
		StageDateFinalPretreatmentStage is null and
		StageDateIntegratedStage is null and
		TreatmentStartDateCancer is null and
		ProcedureDate is null
    );
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20CosdV9SourceOfReferralForNonPrimaryCancerPathway%20mapping){: .btn }
### CosdV9PersonSexualOrientationCodeAtDiagnosis
* Value copied from `Date`

* `Date` Observation date [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html), [TREATMENT START DATE (CANCER)](https://www.datadictionary.nhs.uk/data_elements/treatment_start_date__cancer_.html), [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

```sql
with CO as (
	select
		Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed' as DateOfPrimaryDiagnosisClinicallyAgreed,
		  coalesce(Record ->> '$.Treatment[0].TreatmentStartDateCancer', Record ->> '$.Treatment.TreatmentStartDateCancer') as TreatmentStartDateCancer,
		coalesce(Record ->> '$.Treatment[0].Surgery.ProcedureDate', Record ->> '$.Treatment.Surgery.ProcedureDate') as ProcedureDate,
		Record ->> '$.Demographics.PersonSexualOrientationCodeAtDiagnosis.@code' as PersonSexualOrientationCodeAtDiagnosis,
		Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber
	from omop_staging.cosd_staging_901
	where type = 'CO'
)
select
	distinct
		PersonSexualOrientationCodeAtDiagnosis,
		NhsNumber,
		least(
			cast(DateOfPrimaryDiagnosisClinicallyAgreed as date),
			cast(TreatmentStartDateCancer as date),
			cast(ProcedureDate as date)
		) as Date
from CO o
where o.PersonSexualOrientationCodeAtDiagnosis is not null
  and not (
		DateOfPrimaryDiagnosisClinicallyAgreed is null and
		TreatmentStartDateCancer is null and
		ProcedureDate is null
    );
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20CosdV9PersonSexualOrientationCodeAtDiagnosis%20mapping){: .btn }
### CosdV9PerformanceStatusAdult
* Value copied from `Date`

* `Date` Observation date [DATE FIRST SEEN](https://www.datadictionary.nhs.uk/data_elements/date_first_seen.html), [DATE FIRST SEEN (CANCER SPECIALIST)](https://www.datadictionary.nhs.uk/data_elements/date_first_seen__cancer_specialist_.html), [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html), [TNM STAGE GROUPING DATE (FINAL PRETREATMENT)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping_date__final_pretreatment_.html), [TNM STAGE GROUPING DATE (INTEGRATED)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping_date__integrated_.html), [TREATMENT START DATE (CANCER)](https://www.datadictionary.nhs.uk/data_elements/treatment_start_date__cancer_.html), [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

```sql
with CO as (
	select
		Record ->> '$.PrimaryPathway.ReferralAndFirstStageOfPatientPathway.DateFirstSeen' as DateFirstSeen,
		Record ->> '$.PrimaryPathway.ReferralAndFirstStageOfPatientPathway.DateFirstSeenCancerSpecialist' as DateFirstSeenCancerSpecialist,
		Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed' as DateOfPrimaryDiagnosisClinicallyAgreed,
		Record ->> '$.PrimaryPathway.Staging.StageDateFinalPretreatmentStage' as StageDateFinalPretreatmentStage,
		Record ->> '$.PrimaryPathway.Staging.StageDateIntegratedStage' as StageDateIntegratedStage,
		  coalesce(Record ->> '$.Treatment[0].TreatmentStartDateCancer', Record ->> '$.Treatment.TreatmentStartDateCancer') as TreatmentStartDateCancer,
		coalesce(Record ->> '$.Treatment[0].Surgery.ProcedureDate', Record ->> '$.Treatment.Surgery.ProcedureDate') as ProcedureDate,
		Record ->> '$.PrimaryPathway.Diagnosis.PerformanceStatusAdult.@code' as PerformanceStatusAdult,
		Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber
	from omop_staging.cosd_staging_901
	where type = 'CO'
)
select
	distinct
		PerformanceStatusAdult,
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
from CO o
where o.PerformanceStatusAdult is not null
  and not (
		DateFirstSeen is null and
		DateFirstSeenCancerSpecialist is null and
		DateOfPrimaryDiagnosisClinicallyAgreed is null and
		StageDateFinalPretreatmentStage is null and
		StageDateIntegratedStage is null and
		TreatmentStartDateCancer is null and
		ProcedureDate is null
    );
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20CosdV9PerformanceStatusAdult%20mapping){: .btn }
### CosdV9MenopausalStatus
* Value copied from `Date`

* `Date` Observation date [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html), [TREATMENT START DATE (CANCER)](https://www.datadictionary.nhs.uk/data_elements/treatment_start_date__cancer_.html), [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

```sql
with CO as (
	select
		Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed' as DateOfPrimaryDiagnosisClinicallyAgreed,
		  coalesce(Record ->> '$.Treatment[0].TreatmentStartDateCancer', Record ->> '$.Treatment.TreatmentStartDateCancer') as TreatmentStartDateCancer,
		coalesce(Record ->> '$.Treatment[0].Surgery.ProcedureDate', Record ->> '$.Treatment.Surgery.ProcedureDate') as ProcedureDate,
		Record ->> '$.ClinicalNurseSpecialistAndRiskFactorAssessments.MenopausalStatus.@code' as MenopausalStatus,
		Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber
	from omop_staging.cosd_staging_901
	where type = 'CO'
)
select
	distinct
		MenopausalStatus,
		NhsNumber,
		least(
			cast(DateOfPrimaryDiagnosisClinicallyAgreed as date),
			cast(TreatmentStartDateCancer as date),
			cast(ProcedureDate as date)
		) as Date
from CO o
where o.MenopausalStatus is not null
  and not (
		DateOfPrimaryDiagnosisClinicallyAgreed is null and
		TreatmentStartDateCancer is null and
		ProcedureDate is null
    );
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20CosdV9MenopausalStatus%20mapping){: .btn }
### CosdV9HistoryOfAlcoholPast
* Value copied from `Date`

* `Date` Observation date [DATE FIRST SEEN](https://www.datadictionary.nhs.uk/data_elements/date_first_seen.html), [DATE FIRST SEEN (CANCER SPECIALIST)](https://www.datadictionary.nhs.uk/data_elements/date_first_seen__cancer_specialist_.html), [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html), [TNM STAGE GROUPING DATE (FINAL PRETREATMENT)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping_date__final_pretreatment_.html), [TNM STAGE GROUPING DATE (INTEGRATED)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping_date__integrated_.html), [TREATMENT START DATE (CANCER)](https://www.datadictionary.nhs.uk/data_elements/treatment_start_date__cancer_.html), [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

```sql
with CO as (
	select
		Record ->> '$.PrimaryPathway.ReferralAndFirstStageOfPatientPathway.DateFirstSeen' as DateFirstSeen,
		Record ->> '$.PrimaryPathway.ReferralAndFirstStageOfPatientPathway.DateFirstSeenCancerSpecialist' as DateFirstSeenCancerSpecialist,
		Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed' as DateOfPrimaryDiagnosisClinicallyAgreed,
		Record ->> '$.PrimaryPathway.Staging.StageDateFinalPretreatmentStage' as StageDateFinalPretreatmentStage,
		Record ->> '$.PrimaryPathway.Staging.StageDateIntegratedStage' as StageDateIntegratedStage,
		  coalesce(Record ->> '$.Treatment[0].TreatmentStartDateCancer', Record ->> '$.Treatment.TreatmentStartDateCancer') as TreatmentStartDateCancer,
		coalesce(Record ->> '$.Treatment[0].Surgery.ProcedureDate', Record ->> '$.Treatment.Surgery.ProcedureDate') as ProcedureDate,
		Record ->> '$.ClinicalNurseSpecialistAndRiskFactorAssessments.HistoryOfAlcoholPast.@code' as HistoryOfAlcoholPast,
		Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber
	from omop_staging.cosd_staging_901
	where type = 'CO'
)
select
	distinct
		HistoryOfAlcoholPast,
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
from CO o
where o.HistoryOfAlcoholPast is not null
  and not (
		DateFirstSeen is null and
		DateFirstSeenCancerSpecialist is null and
		DateOfPrimaryDiagnosisClinicallyAgreed is null and
		StageDateFinalPretreatmentStage is null and
		StageDateIntegratedStage is null and
		TreatmentStartDateCancer is null and
		ProcedureDate is null
    );
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20CosdV9HistoryOfAlcoholPast%20mapping){: .btn }
### CosdV9HistoryOfAlcoholCurrent
* Value copied from `Date`

* `Date` Observation date [DATE FIRST SEEN](https://www.datadictionary.nhs.uk/data_elements/date_first_seen.html), [DATE FIRST SEEN (CANCER SPECIALIST)](https://www.datadictionary.nhs.uk/data_elements/date_first_seen__cancer_specialist_.html), [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html), [TNM STAGE GROUPING DATE (FINAL PRETREATMENT)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping_date__final_pretreatment_.html), [TNM STAGE GROUPING DATE (INTEGRATED)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping_date__integrated_.html), [TREATMENT START DATE (CANCER)](https://www.datadictionary.nhs.uk/data_elements/treatment_start_date__cancer_.html), [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

```sql
with CO as (
	select
		Record ->> '$.PrimaryPathway.ReferralAndFirstStageOfPatientPathway.DateFirstSeen' as DateFirstSeen,
		Record ->> '$.PrimaryPathway.ReferralAndFirstStageOfPatientPathway.DateFirstSeenCancerSpecialist' as DateFirstSeenCancerSpecialist,
		Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed' as DateOfPrimaryDiagnosisClinicallyAgreed,
		Record ->> '$.PrimaryPathway.Staging.StageDateFinalPretreatmentStage' as StageDateFinalPretreatmentStage,
		Record ->> '$.PrimaryPathway.Staging.StageDateIntegratedStage' as StageDateIntegratedStage,
		  coalesce(Record ->> '$.Treatment[0].TreatmentStartDateCancer', Record ->> '$.Treatment.TreatmentStartDateCancer') as TreatmentStartDateCancer,
		coalesce(Record ->> '$.Treatment[0].Surgery.ProcedureDate', Record ->> '$.Treatment.Surgery.ProcedureDate') as ProcedureDate,
		Record ->> '$.ClinicalNurseSpecialistAndRiskFactorAssessments.HistoryOfAlcoholCurrent.@code' as HistoryOfAlcoholCurrent,
		Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber
	from omop_staging.cosd_staging_901
	where type = 'CO'
)
select
	distinct
		HistoryOfAlcoholCurrent,
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
from CO o
where o.HistoryOfAlcoholCurrent is not null
  and not (
		DateFirstSeen is null and
		DateFirstSeenCancerSpecialist is null and
		DateOfPrimaryDiagnosisClinicallyAgreed is null and
		StageDateFinalPretreatmentStage is null and
		StageDateIntegratedStage is null and
		TreatmentStartDateCancer is null and
		ProcedureDate is null
    );
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20CosdV9HistoryOfAlcoholCurrent%20mapping){: .btn }
### CosdV9FamilialCancerSyndrome
* Value copied from `Date`

* `Date` Observation date [DATE FIRST SEEN](https://www.datadictionary.nhs.uk/data_elements/date_first_seen.html), [DATE FIRST SEEN (CANCER SPECIALIST)](https://www.datadictionary.nhs.uk/data_elements/date_first_seen__cancer_specialist_.html), [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html), [TNM STAGE GROUPING DATE (FINAL PRETREATMENT)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping_date__final_pretreatment_.html), [TNM STAGE GROUPING DATE (INTEGRATED)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping_date__integrated_.html), [TREATMENT START DATE (CANCER)](https://www.datadictionary.nhs.uk/data_elements/treatment_start_date__cancer_.html), [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

```sql
with CO as (
	select
		Record ->> '$.PrimaryPathway.ReferralAndFirstStageOfPatientPathway.DateFirstSeen' as DateFirstSeen,
		Record ->> '$.PrimaryPathway.ReferralAndFirstStageOfPatientPathway.DateFirstSeenCancerSpecialist' as DateFirstSeenCancerSpecialist,
		Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed' as DateOfPrimaryDiagnosisClinicallyAgreed,
		Record ->> '$.PrimaryPathway.Staging.StageDateFinalPretreatmentStage' as StageDateFinalPretreatmentStage,
		Record ->> '$.PrimaryPathway.Staging.StageDateIntegratedStage' as StageDateIntegratedStage,
		  coalesce(Record ->> '$.Treatment[0].TreatmentStartDateCancer', Record ->> '$.Treatment.TreatmentStartDateCancer') as TreatmentStartDateCancer,
		coalesce(Record ->> '$.Treatment[0].Surgery.ProcedureDate', Record ->> '$.Treatment.Surgery.ProcedureDate') as ProcedureDate,
		Record ->> '$.PrimaryPathway.Diagnosis.DiagnosisAdditionalItems.FamilialCancerSyndrome.@code' as FamilialCancerSyndrome,
		Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber
	from omop_staging.cosd_staging_901
	where type = 'CO'
)
select
	distinct
		FamilialCancerSyndrome,
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
from CO o
where o.FamilialCancerSyndrome is not null
  and not (
		DateFirstSeen is null and
		DateFirstSeenCancerSpecialist is null and
		DateOfPrimaryDiagnosisClinicallyAgreed is null and
		StageDateFinalPretreatmentStage is null and
		StageDateIntegratedStage is null and
		TreatmentStartDateCancer is null and
		ProcedureDate is null
    );
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20CosdV9FamilialCancerSyndrome%20mapping){: .btn }
### CosdV9FamilialCancerSyndromeSubsidiaryComment
* Value copied from `Date`

* `Date` Observation date [DATE FIRST SEEN](https://www.datadictionary.nhs.uk/data_elements/date_first_seen.html), [DATE FIRST SEEN (CANCER SPECIALIST)](https://www.datadictionary.nhs.uk/data_elements/date_first_seen__cancer_specialist_.html), [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html), [TNM STAGE GROUPING DATE (FINAL PRETREATMENT)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping_date__final_pretreatment_.html), [TNM STAGE GROUPING DATE (INTEGRATED)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping_date__integrated_.html), [TREATMENT START DATE (CANCER)](https://www.datadictionary.nhs.uk/data_elements/treatment_start_date__cancer_.html), [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

```sql
with CO as (
	select
		Record ->> '$.PrimaryPathway.ReferralAndFirstStageOfPatientPathway.DateFirstSeen' as DateFirstSeen,
		Record ->> '$.PrimaryPathway.ReferralAndFirstStageOfPatientPathway.DateFirstSeenCancerSpecialist' as DateFirstSeenCancerSpecialist,
		Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed' as DateOfPrimaryDiagnosisClinicallyAgreed,
		Record ->> '$.PrimaryPathway.Staging.StageDateFinalPretreatmentStage' as StageDateFinalPretreatmentStage,
		Record ->> '$.PrimaryPathway.Staging.StageDateIntegratedStage' as StageDateIntegratedStage,
		  coalesce(Record ->> '$.Treatment[0].TreatmentStartDateCancer', Record ->> '$.Treatment.TreatmentStartDateCancer') as TreatmentStartDateCancer,
		coalesce(Record ->> '$.Treatment[0].Surgery.ProcedureDate', Record ->> '$.Treatment.Surgery.ProcedureDate') as ProcedureDate,
		Record ->> '$.PrimaryPathway.Diagnosis.DiagnosisAdditionalItems.FamilialCancerSyndromeSubsidiaryComment.#cdata-section' as FamilialCancerSyndromeSubsidiaryComment,
		Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber
	from omop_staging.cosd_staging_901
	where type = 'CO'
)
select
	distinct
		FamilialCancerSyndromeSubsidiaryComment,
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
from CO o
where o.FamilialCancerSyndromeSubsidiaryComment is not null
  and not (
		DateFirstSeen is null and
		DateFirstSeenCancerSpecialist is null and
		DateOfPrimaryDiagnosisClinicallyAgreed is null and
		StageDateFinalPretreatmentStage is null and
		StageDateIntegratedStage is null and
		TreatmentStartDateCancer is null and
		ProcedureDate is null
    );
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20CosdV9FamilialCancerSyndromeSubsidiaryComment%20mapping){: .btn }
### CosdV9AsaScore
* Value copied from `Date`

* `Date` Observation date [DATE FIRST SEEN](https://www.datadictionary.nhs.uk/data_elements/date_first_seen.html), [DATE FIRST SEEN (CANCER SPECIALIST)](https://www.datadictionary.nhs.uk/data_elements/date_first_seen__cancer_specialist_.html), [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html), [TNM STAGE GROUPING DATE (FINAL PRETREATMENT)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping_date__final_pretreatment_.html), [TNM STAGE GROUPING DATE (INTEGRATED)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping_date__integrated_.html), [TREATMENT START DATE (CANCER)](https://www.datadictionary.nhs.uk/data_elements/treatment_start_date__cancer_.html), [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

```sql
with CO as (
	select
		Record ->> '$.PrimaryPathway.ReferralAndFirstStageOfPatientPathway.DateFirstSeen' as DateFirstSeen,
		Record ->> '$.PrimaryPathway.ReferralAndFirstStageOfPatientPathway.DateFirstSeenCancerSpecialist' as DateFirstSeenCancerSpecialist,
		Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed' as DateOfPrimaryDiagnosisClinicallyAgreed,
		Record ->> '$.PrimaryPathway.Staging.StageDateFinalPretreatmentStage' as StageDateFinalPretreatmentStage,
		Record ->> '$.PrimaryPathway.Staging.StageDateIntegratedStage' as StageDateIntegratedStage,
		coalesce(Record ->> '$.Treatment[0].TreatmentStartDateCancer', Record ->> '$.Treatment.TreatmentStartDateCancer') as TreatmentStartDateCancer,
		coalesce(Record ->> '$.Treatment[0].Surgery.ProcedureDate', Record ->> '$.Treatment.Surgery.ProcedureDate') as ProcedureDate,
		coalesce(Record ->> '$.Treatment[0].Surgery.AsaScore.@code', Record ->> '$.Treatment.Surgery.AsaScore.@code') as AsaScore,
		Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber
	from omop_staging.cosd_staging_901
	where type = 'CO'
)
select
	distinct
		AsaScore,
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
from CO o
where o.AsaScore is not null
  and not (
		DateFirstSeen is null and
		DateFirstSeenCancerSpecialist is null and
		DateOfPrimaryDiagnosisClinicallyAgreed is null and
		StageDateFinalPretreatmentStage is null and
		StageDateIntegratedStage is null and
		TreatmentStartDateCancer is null and
		ProcedureDate is null
    );
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20CosdV9AsaScore%20mapping){: .btn }
### CosdV8SourceOfReferralOutPatients
* Value copied from `Date`

* `Date` Observation date [DATE FIRST SEEN](https://www.datadictionary.nhs.uk/data_elements/date_first_seen.html), [DATE FIRST SEEN (CANCER SPECIALIST)](https://www.datadictionary.nhs.uk/data_elements/date_first_seen__cancer_specialist_.html), [DIAGNOSIS DATE](https://www.datadictionary.nhs.uk/data_elements/diagnosis_date.html), [TNM STAGE GROUPING DATE (INTEGRATED)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping_date__integrated_.html), [TNM STAGE GROUPING DATE (FINAL PRETREATMENT)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping_date__final_pretreatment_.html), [TREATMENT START DATE (CANCER)](https://www.datadictionary.nhs.uk/data_elements/treatment_start_date__cancer_.html), [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

```sql
with CO as (
select 
  Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreReferralAndFirstStageOfPatientPathway.DateFirstSeen' as DateFirstSeen,
Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreReferralAndFirstStageOfPatientPathway.SpecialistDateFirstSeen' as SpecialistDateFirstSeen,
Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreStaging.IntegratedStageTNMStageGroupingDate' as IntegratedStageTNMStageGroupingDate,
Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreStaging.FinalPreTreatmentTNMStageGroupingDate' as FinalPreTreatmentTNMStageGroupingDate,
Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreTreatment.CancerTreatmentStartDate' as CancerTreatmentStartDate,
Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreTreatment.ColorectalCoreSurgeryAndOtherProcedures.ProcedureDate' as ProcedureDate,
Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreReferralAndFirstStageOfPatientPathway.SourceOfReferralOutPatients.@code' as SourceOfReferralOutPatients,
Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber
from omop_staging.cosd_staging_81
where Type = 'CO'
)
select
      distinct
          SourceOfReferralOutPatients,
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
from CO o
where o.SourceOfReferralOutPatients is not null
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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20CosdV8SourceOfReferralOutPatients%20mapping){: .btn }
### CosdV8SourceOfReferralForOutPatientsNonPrimaryCancerPathway
* Value copied from `Date`

* `Date` Observation date [DATE FIRST SEEN](https://www.datadictionary.nhs.uk/data_elements/date_first_seen.html), [DATE FIRST SEEN (CANCER SPECIALIST)](https://www.datadictionary.nhs.uk/data_elements/date_first_seen__cancer_specialist_.html), [DIAGNOSIS DATE](https://www.datadictionary.nhs.uk/data_elements/diagnosis_date.html), [TNM STAGE GROUPING DATE (INTEGRATED)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping_date__integrated_.html), [TNM STAGE GROUPING DATE (FINAL PRETREATMENT)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping_date__final_pretreatment_.html), [TREATMENT START DATE (CANCER)](https://www.datadictionary.nhs.uk/data_elements/treatment_start_date__cancer_.html), [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

```sql
with CO as (
select 
  Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreReferralAndFirstStageOfPatientPathway.DateFirstSeen' as DateFirstSeen,
Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreReferralAndFirstStageOfPatientPathway.SpecialistDateFirstSeen' as SpecialistDateFirstSeen,
Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreStaging.IntegratedStageTNMStageGroupingDate' as IntegratedStageTNMStageGroupingDate,
Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreStaging.FinalPreTreatmentTNMStageGroupingDate' as FinalPreTreatmentTNMStageGroupingDate,
coalesce(Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreTreatment[0].CancerTreatmentStartDate', Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreTreatment.CancerTreatmentStartDate') as CancerTreatmentStartDate,
coalesce(Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreTreatment[0].ColorectalCoreSurgeryAndOtherProcedures.ProcedureDate', Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreTreatment.ColorectalCoreSurgeryAndOtherProcedures.ProcedureDate') as ProcedureDate,
Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreReferralAndFirstStageOfPatientPathway.SourceOfReferralOutPatients.@code' as SourceOfReferralOutPatients,
Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber
from omop_staging.cosd_staging_81
where Type = 'CO'
)
select
      distinct
          SourceOfReferralOutPatients,
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
from CO o
where o.SourceOfReferralOutPatients is not null
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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20CosdV8SourceOfReferralForOutPatientsNonPrimaryCancerPathway%20mapping){: .btn }
### CosdV8SmokingStatusCode
* Value copied from `Date`

* `Date` Observation date [DATE FIRST SEEN](https://www.datadictionary.nhs.uk/data_elements/date_first_seen.html), [DATE FIRST SEEN (CANCER SPECIALIST)](https://www.datadictionary.nhs.uk/data_elements/date_first_seen__cancer_specialist_.html), [DIAGNOSIS DATE](https://www.datadictionary.nhs.uk/data_elements/diagnosis_date.html), [TNM STAGE GROUPING DATE (INTEGRATED)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping_date__integrated_.html), [TNM STAGE GROUPING DATE (FINAL PRETREATMENT)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping_date__final_pretreatment_.html), [TREATMENT START DATE (CANCER)](https://www.datadictionary.nhs.uk/data_elements/treatment_start_date__cancer_.html), [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

```sql
with CO as (
select 
  Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreReferralAndFirstStageOfPatientPathway.DateFirstSeen' as DateFirstSeen,
Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreReferralAndFirstStageOfPatientPathway.SpecialistDateFirstSeen' as SpecialistDateFirstSeen,
Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreStaging.IntegratedStageTNMStageGroupingDate' as IntegratedStageTNMStageGroupingDate,
Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreStaging.FinalPreTreatmentTNMStageGroupingDate' as FinalPreTreatmentTNMStageGroupingDate,
coalesce(Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreTreatment[0].CancerTreatmentStartDate', Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreTreatment.CancerTreatmentStartDate') as CancerTreatmentStartDate,
coalesce(Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreTreatment[0].ColorectalCoreSurgeryAndOtherProcedures.ProcedureDate', Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreTreatment.ColorectalCoreSurgeryAndOtherProcedures.ProcedureDate') as ProcedureDate,
Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreClinicalNurseSpecialistAndRiskFactorAssessments.SmokingStatusCode.@code' as SmokingStatusCode,
Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber
from omop_staging.cosd_staging_81
where Type = 'CO'
)
select
      distinct
          SmokingStatusCode,
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
from CO o
where o.SmokingStatusCode is not null
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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20CosdV8SmokingStatusCode%20mapping){: .btn }
### CosdV8PersonStatedSexualOrientationCodeAtDiagnosis
* Value copied from `Date`

* `Date` Observation date [DIAGNOSIS DATE](https://www.datadictionary.nhs.uk/data_elements/diagnosis_date.html), [TREATMENT START DATE (CANCER)](https://www.datadictionary.nhs.uk/data_elements/treatment_start_date__cancer_.html), [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

```sql
with CO as (
select 
Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreDemographics.PersonStatedSexualOrientationCodeAtDiagnosis.@code' as PersonStatedSexualOrientationCodeAtDiagnosis,
Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreTreatment.ColorectalCoreSurgeryAndOtherProcedures.ProcedureDate' as ProcedureDate,
Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreTreatment.CancerTreatmentStartDate' as CancerTreatmentStartDate,
Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber
from omop_staging.cosd_staging_81
where Type = 'CO'
)
select
      distinct
          PersonStatedSexualOrientationCodeAtDiagnosis,
          NhsNumber,
          least(
                cast (ClinicalDateCancerDiagnosis as date),
                cast (ProcedureDate as date),
                cast (CancerTreatmentStartDate as date)
          ) as Date
from CO o
where o.PersonStatedSexualOrientationCodeAtDiagnosis is not null
  and not (
		ClinicalDateCancerDiagnosis is null and
		ProcedureDate is null and
		CancerTreatmentStartDate is null
    )
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20CosdV8PersonStatedSexualOrientationCodeAtDiagnosis%20mapping){: .btn }
### CosdV8FamilialCancerSyndromeIndicator
* Value copied from `Date`

* `Date` Observation date [DATE FIRST SEEN](https://www.datadictionary.nhs.uk/data_elements/date_first_seen.html), [DATE FIRST SEEN (CANCER SPECIALIST)](https://www.datadictionary.nhs.uk/data_elements/date_first_seen__cancer_specialist_.html), [DIAGNOSIS DATE](https://www.datadictionary.nhs.uk/data_elements/diagnosis_date.html), [TNM STAGE GROUPING DATE (INTEGRATED)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping_date__integrated_.html), [TNM STAGE GROUPING DATE (FINAL PRETREATMENT)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping_date__final_pretreatment_.html), [TREATMENT START DATE (CANCER)](https://www.datadictionary.nhs.uk/data_elements/treatment_start_date__cancer_.html), [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

```sql
with CO as (
select 
  Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreReferralAndFirstStageOfPatientPathway.DateFirstSeen' as DateFirstSeen,
Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreReferralAndFirstStageOfPatientPathway.SpecialistDateFirstSeen' as SpecialistDateFirstSeen,
Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreStaging.IntegratedStageTNMStageGroupingDate' as IntegratedStageTNMStageGroupingDate,
Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreStaging.FinalPreTreatmentTNMStageGroupingDate' as FinalPreTreatmentTNMStageGroupingDate,
Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreTreatment.CancerTreatmentStartDate' as CancerTreatmentStartDate,
Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreTreatment.ColorectalCoreSurgeryAndOtherProcedures.ProcedureDate' as ProcedureDate,
Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreDiagnosis.ColorectalCoreDiagnosisAdditionalItems.FamilialCancerSyndromeIndicator.@code' as FamilialCancerSyndromeIndicator,
Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber
from omop_staging.cosd_staging_81
where Type = 'CO'
)
select
      distinct
          FamilialCancerSyndromeIndicator,
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
from CO o
where o.FamilialCancerSyndromeIndicator is not null
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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20CosdV8FamilialCancerSyndromeIndicator%20mapping){: .btn }
### CosdV8AlcoholHistoryCancerInLastThreeMonths
* Value copied from `Date`

* `Date` Observation date [DATE FIRST SEEN](https://www.datadictionary.nhs.uk/data_elements/date_first_seen.html), [DATE FIRST SEEN (CANCER SPECIALIST)](https://www.datadictionary.nhs.uk/data_elements/date_first_seen__cancer_specialist_.html), [DIAGNOSIS DATE](https://www.datadictionary.nhs.uk/data_elements/diagnosis_date.html), [TNM STAGE GROUPING DATE (INTEGRATED)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping_date__integrated_.html), [TNM STAGE GROUPING DATE (FINAL PRETREATMENT)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping_date__final_pretreatment_.html), [TREATMENT START DATE (CANCER)](https://www.datadictionary.nhs.uk/data_elements/treatment_start_date__cancer_.html), [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

```sql
with CO as (
select 
  Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreReferralAndFirstStageOfPatientPathway.DateFirstSeen' as DateFirstSeen,
Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreReferralAndFirstStageOfPatientPathway.SpecialistDateFirstSeen' as SpecialistDateFirstSeen,
Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreStaging.IntegratedStageTNMStageGroupingDate' as IntegratedStageTNMStageGroupingDate,
Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreStaging.FinalPreTreatmentTNMStageGroupingDate' as FinalPreTreatmentTNMStageGroupingDate,
Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreTreatment.CancerTreatmentStartDate' as CancerTreatmentStartDate,
Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreTreatment.ColorectalCoreSurgeryAndOtherProcedures.ProcedureDate' as ProcedureDate,
Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreClinicalNurseSpecialistAndRiskFactorAssessments.AlcoholHistoryCancerInLastThreeMonths.@code' as AlcoholHistoryCancerInLastThreeMonths,
Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber
from omop_staging.cosd_staging_81
where Type = 'CO'
)
select
      distinct
          AlcoholHistoryCancerInLastThreeMonths,
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
from CO o
where o.AlcoholHistoryCancerInLastThreeMonths is not null
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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20CosdV8AlcoholHistoryCancerInLastThreeMonths%20mapping){: .btn }
### CosdV8AlcoholHistoryCancerBeforeLastThreeMonths
* Value copied from `Date`

* `Date` Observation date [DATE FIRST SEEN](https://www.datadictionary.nhs.uk/data_elements/date_first_seen.html), [DATE FIRST SEEN (CANCER SPECIALIST)](https://www.datadictionary.nhs.uk/data_elements/date_first_seen__cancer_specialist_.html), [DIAGNOSIS DATE](https://www.datadictionary.nhs.uk/data_elements/diagnosis_date.html), [TNM STAGE GROUPING DATE (INTEGRATED)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping_date__integrated_.html), [TNM STAGE GROUPING DATE (FINAL PRETREATMENT)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping_date__final_pretreatment_.html), [TREATMENT START DATE (CANCER)](https://www.datadictionary.nhs.uk/data_elements/treatment_start_date__cancer_.html), [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

```sql
with CO as (
select 
  Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreReferralAndFirstStageOfPatientPathway.DateFirstSeen' as DateFirstSeen,
Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreReferralAndFirstStageOfPatientPathway.SpecialistDateFirstSeen' as SpecialistDateFirstSeen,
Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreStaging.IntegratedStageTNMStageGroupingDate' as IntegratedStageTNMStageGroupingDate,
Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreStaging.FinalPreTreatmentTNMStageGroupingDate' as FinalPreTreatmentTNMStageGroupingDate,
Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreTreatment.CancerTreatmentStartDate' as CancerTreatmentStartDate,
Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreTreatment.ColorectalCoreSurgeryAndOtherProcedures.ProcedureDate' as ProcedureDate,
Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreClinicalNurseSpecialistAndRiskFactorAssessments.AlcoholHistoryCancerBeforeLastThreeMonths.@code' as AlcoholHistoryCancerBeforeLastThreeMonths,
Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber
from omop_staging.cosd_staging_81
where Type = 'CO'
)
select
      distinct
          AlcoholHistoryCancerBeforeLastThreeMonths,
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
from CO o
where o.AlcoholHistoryCancerBeforeLastThreeMonths is not null
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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20CosdV8AlcoholHistoryCancerBeforeLastThreeMonths%20mapping){: .btn }
### CosdV8AdultPerformanceStatus
* Value copied from `Date`

* `Date` Observation date [DATE FIRST SEEN](https://www.datadictionary.nhs.uk/data_elements/date_first_seen.html), [DATE FIRST SEEN (CANCER SPECIALIST)](https://www.datadictionary.nhs.uk/data_elements/date_first_seen__cancer_specialist_.html), [DIAGNOSIS DATE](https://www.datadictionary.nhs.uk/data_elements/diagnosis_date.html), [TNM STAGE GROUPING DATE (INTEGRATED)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping_date__integrated_.html), [TNM STAGE GROUPING DATE (FINAL PRETREATMENT)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping_date__final_pretreatment_.html), [TREATMENT START DATE (CANCER)](https://www.datadictionary.nhs.uk/data_elements/treatment_start_date__cancer_.html), [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

```sql
with CO as (
select 
  Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreReferralAndFirstStageOfPatientPathway.DateFirstSeen' as DateFirstSeen,
Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreReferralAndFirstStageOfPatientPathway.SpecialistDateFirstSeen' as SpecialistDateFirstSeen,
Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreStaging.IntegratedStageTNMStageGroupingDate' as IntegratedStageTNMStageGroupingDate,
Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreStaging.FinalPreTreatmentTNMStageGroupingDate' as FinalPreTreatmentTNMStageGroupingDate,
coalesce(Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreTreatment[0].CancerTreatmentStartDate', Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreTreatment.CancerTreatmentStartDate') as CancerTreatmentStartDate,
coalesce(Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreTreatment[0].ColorectalCoreSurgeryAndOtherProcedures.ProcedureDate', Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreTreatment.ColorectalCoreSurgeryAndOtherProcedures.ProcedureDate') as ProcedureDate,
Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreDiagnosis.AdultPerformanceStatus.@code' as AdultPerformanceStatus,
Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber
from omop_staging.cosd_staging_81
where Type = 'CO'
)
select
      distinct
          AdultPerformanceStatus,
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
from CO o
where o.AdultPerformanceStatus is not null
 and not (
		DateFirstSeen is null  and
		SpecialistDateFirstSeen is null  and
		ClinicalDateCancerDiagnosis is null  and
  	IntegratedStageTNMStageGroupingDate is null  and
		FinalPreTreatmentTNMStageGroupingDate is null and
		CancerTreatmentStartDate is null and
		ProcedureDate is null 
  )
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20CosdV8AdultPerformanceStatus%20mapping){: .btn }
### CosdV9BreastSourceOfReferralForOutpatients
* Value copied from `Date`

* `Date` Observation date [DATE FIRST SEEN](https://www.datadictionary.nhs.uk/data_elements/date_first_seen.html), [DATE FIRST SEEN (CANCER SPECIALIST)](https://www.datadictionary.nhs.uk/data_elements/date_first_seen__cancer_specialist_.html), [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html), [TNM STAGE GROUPING DATE (FINAL PRETREATMENT)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping_date__final_pretreatment_.html), [TNM STAGE GROUPING DATE (INTEGRATED)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping_date__integrated_.html), [TREATMENT START DATE (CANCER)](https://www.datadictionary.nhs.uk/data_elements/treatment_start_date__cancer_.html), [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

```sql
with BR as (
    select
        Record ->> '$.PrimaryPathway.ReferralAndFirstStageOfPatientPathway.DateFirstSeen' as DateFirstSeen,
        Record ->> '$.PrimaryPathway.ReferralAndFirstStageOfPatientPathway.DateFirstSeenCancerSpecialist' as DateFirstSeenCancerSpecialist,
        Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed' as DateOfPrimaryDiagnosisClinicallyAgreed,
        Record ->> '$.PrimaryPathway.Staging.StageDateFinalPretreatmentStage' as StageDateFinalPretreatmentStage,
        Record ->> '$.PrimaryPathway.Staging.StageDateIntegratedStage' as StageDateIntegratedStage,
        coalesce(
            Record ->> '$.Treatment[0].TreatmentStartDateCancer', 
            Record ->> '$.Treatment.TreatmentStartDateCancer'
        ) as TreatmentStartDateCancer,
        coalesce(
            Record ->> '$.Treatment[0].Surgery.ProcedureDate', 
            Record ->> '$.Treatment.Surgery.ProcedureDate'
        ) as ProcedureDate,
        -- Quoting is required to handle the hyphen in "SourceOfReferralForOut-patients"
        Record ->> '$.PrimaryPathway.ReferralAndFirstStageOfPatientPathway."SourceOfReferralForOut-patients"."@code"' as SourceOfReferralForOutpatients,
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber
    from omop_staging.cosd_staging_901
    where type = 'BR'
)
select
    distinct
        SourceOfReferralForOutpatients,
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
from BR o
where o.SourceOfReferralForOutpatients is not null
  and not (
        DateFirstSeen is null and
        DateFirstSeenCancerSpecialist is null and
        DateOfPrimaryDiagnosisClinicallyAgreed is null and
        StageDateFinalPretreatmentStage is null and
        StageDateIntegratedStage is null and
        TreatmentStartDateCancer is null and
        ProcedureDate is null
    );
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20CosdV9BreastSourceOfReferralForOutpatients%20mapping){: .btn }
### CosdV9BreastSourceOfReferralForNonPrimaryCancerPathway
* Value copied from `Date`

* `Date` Observation date [DATE FIRST SEEN](https://www.datadictionary.nhs.uk/data_elements/date_first_seen.html), [DATE FIRST SEEN (CANCER SPECIALIST)](https://www.datadictionary.nhs.uk/data_elements/date_first_seen__cancer_specialist_.html), [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html), [TNM STAGE GROUPING DATE (FINAL PRETREATMENT)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping_date__final_pretreatment_.html), [TNM STAGE GROUPING DATE (INTEGRATED)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping_date__integrated_.html), [TREATMENT START DATE (CANCER)](https://www.datadictionary.nhs.uk/data_elements/treatment_start_date__cancer_.html), [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

```sql
with BR as (
    select
        Record ->> '$.PrimaryPathway.ReferralAndFirstStageOfPatientPathway.DateFirstSeen' as DateFirstSeen,
        Record ->> '$.PrimaryPathway.ReferralAndFirstStageOfPatientPathway.DateFirstSeenCancerSpecialist' as DateFirstSeenCancerSpecialist,
        Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed' as DateOfPrimaryDiagnosisClinicallyAgreed,
        Record ->> '$.PrimaryPathway.Staging.StageDateFinalPretreatmentStage' as StageDateFinalPretreatmentStage,
        Record ->> '$.PrimaryPathway.Staging.StageDateIntegratedStage' as StageDateIntegratedStage,
        coalesce(
            Record ->> '$.Treatment[0].TreatmentStartDateCancer', 
            Record ->> '$.Treatment.TreatmentStartDateCancer'
        ) as TreatmentStartDateCancer,
        coalesce(
            Record ->> '$.Treatment[0].Surgery.ProcedureDate', 
            Record ->> '$.Treatment.Surgery.ProcedureDate'
        ) as ProcedureDate,
        Record ->> '$.NonPrimaryPathway.NonPrimaryCancerPathwayReferral.SourceOfReferralForNonPrimaryCancerPathway.@code' as SourceOfReferralForNonPrimaryCancerPathway,
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber
    from omop_staging.cosd_staging_901
    where type = 'BR'
)
select
    distinct
        SourceOfReferralForNonPrimaryCancerPathway,
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
from BR o
where o.SourceOfReferralForNonPrimaryCancerPathway is not null
  and not (
        DateFirstSeen is null and
        DateFirstSeenCancerSpecialist is null and
        DateOfPrimaryDiagnosisClinicallyAgreed is null and
        StageDateFinalPretreatmentStage is null and
        StageDateIntegratedStage is null and
        TreatmentStartDateCancer is null and
        ProcedureDate is null
    );
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20CosdV9BreastSourceOfReferralForNonPrimaryCancerPathway%20mapping){: .btn }
### CosdV9BreastPerformanceStatusAdult
* Value copied from `Date`

* `Date` Observation date [DATE FIRST SEEN](https://www.datadictionary.nhs.uk/data_elements/date_first_seen.html), [DATE FIRST SEEN (CANCER SPECIALIST)](https://www.datadictionary.nhs.uk/data_elements/date_first_seen__cancer_specialist_.html), [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html), [TNM STAGE GROUPING DATE (FINAL PRETREATMENT)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping_date__final_pretreatment_.html), [TNM STAGE GROUPING DATE (INTEGRATED)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping_date__integrated_.html), [TREATMENT START DATE (CANCER)](https://www.datadictionary.nhs.uk/data_elements/treatment_start_date__cancer_.html), [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

```sql
with BR as (
    select
        Record ->> '$.PrimaryPathway.ReferralAndFirstStageOfPatientPathway.DateFirstSeen' as DateFirstSeen,
        Record ->> '$.PrimaryPathway.ReferralAndFirstStageOfPatientPathway.DateFirstSeenCancerSpecialist' as DateFirstSeenCancerSpecialist,
        Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed' as DateOfPrimaryDiagnosisClinicallyAgreed,
        Record ->> '$.PrimaryPathway.Staging.StageDateFinalPretreatmentStage' as StageDateFinalPretreatmentStage,
        Record ->> '$.PrimaryPathway.Staging.StageDateIntegratedStage' as StageDateIntegratedStage,
        coalesce(
            Record ->> '$.Treatment[0].TreatmentStartDateCancer', 
            Record ->> '$.Treatment.TreatmentStartDateCancer'
        ) as TreatmentStartDateCancer,
        coalesce(
            Record ->> '$.Treatment[0].Surgery.ProcedureDate', 
            Record ->> '$.Treatment.Surgery.ProcedureDate'
        ) as ProcedureDate,
        Record ->> '$.PrimaryPathway.Diagnosis.PerformanceStatusAdult.@code' as PerformanceStatusAdult,
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber
    from omop_staging.cosd_staging_901
    where type = 'BR'
)
select
    distinct
        PerformanceStatusAdult,
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
from BR o
where o.PerformanceStatusAdult is not null
  and not (
        DateFirstSeen is null and
        DateFirstSeenCancerSpecialist is null and
        DateOfPrimaryDiagnosisClinicallyAgreed is null and
        StageDateFinalPretreatmentStage is null and
        StageDateIntegratedStage is null and
        TreatmentStartDateCancer is null and
        ProcedureDate is null
    );
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20CosdV9BreastPerformanceStatusAdult%20mapping){: .btn }
### CosdV9BreastMenopausalStatus
* Value copied from `Date`

* `Date` Observation date [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html), [TREATMENT START DATE (CANCER)](https://www.datadictionary.nhs.uk/data_elements/treatment_start_date__cancer_.html), [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

```sql
with BR as (
    select
        Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed' as DateOfPrimaryDiagnosisClinicallyAgreed,
        coalesce(
            Record ->> '$.Treatment[0].TreatmentStartDateCancer', 
            Record ->> '$.Treatment.TreatmentStartDateCancer'
        ) as TreatmentStartDateCancer,
        coalesce(
            Record ->> '$.Treatment[0].Surgery.ProcedureDate', 
            Record ->> '$.Treatment.Surgery.ProcedureDate'
        ) as ProcedureDate,
        Record ->> '$.ClinicalNurseSpecialistAndRiskFactorAssessments.MenopausalStatus.@code' as MenopausalStatus,
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber
    from omop_staging.cosd_staging_901
    where type = 'BR'
)
select
    distinct
        MenopausalStatus,
        NhsNumber,
        least(
            cast(DateOfPrimaryDiagnosisClinicallyAgreed as date),
            cast(TreatmentStartDateCancer as date),
            cast(ProcedureDate as date)
        ) as Date
from BR o
where o.MenopausalStatus is not null
  and not (
        DateOfPrimaryDiagnosisClinicallyAgreed is null and
        TreatmentStartDateCancer is null and
        ProcedureDate is null
    );
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20CosdV9BreastMenopausalStatus%20mapping){: .btn }
### CosdV9BreastHistoryOfAlcoholPast
* Value copied from `Date`

* `Date` Observation date [DATE FIRST SEEN](https://www.datadictionary.nhs.uk/data_elements/date_first_seen.html), [DATE FIRST SEEN (CANCER SPECIALIST)](https://www.datadictionary.nhs.uk/data_elements/date_first_seen__cancer_specialist_.html), [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html), [TNM STAGE GROUPING DATE (FINAL PRETREATMENT)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping_date__final_pretreatment_.html), [TNM STAGE GROUPING DATE (INTEGRATED)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping_date__integrated_.html), [TREATMENT START DATE (CANCER)](https://www.datadictionary.nhs.uk/data_elements/treatment_start_date__cancer_.html), [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

```sql
with BR as (
    select
        Record ->> '$.PrimaryPathway.ReferralAndFirstStageOfPatientPathway.DateFirstSeen' as DateFirstSeen,
        Record ->> '$.PrimaryPathway.ReferralAndFirstStageOfPatientPathway.DateFirstSeenCancerSpecialist' as DateFirstSeenCancerSpecialist,
        Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed' as DateOfPrimaryDiagnosisClinicallyAgreed,
        Record ->> '$.PrimaryPathway.Staging.StageDateFinalPretreatmentStage' as StageDateFinalPretreatmentStage,
        Record ->> '$.PrimaryPathway.Staging.StageDateIntegratedStage' as StageDateIntegratedStage,
        coalesce(
            Record ->> '$.Treatment[0].TreatmentStartDateCancer', 
            Record ->> '$.Treatment.TreatmentStartDateCancer'
        ) as TreatmentStartDateCancer,
        coalesce(
            Record ->> '$.Treatment[0].Surgery.ProcedureDate', 
            Record ->> '$.Treatment.Surgery.ProcedureDate'
        ) as ProcedureDate,
        Record ->> '$.ClinicalNurseSpecialistAndRiskFactorAssessments.HistoryOfAlcoholPast.@code' as HistoryOfAlcoholPast,
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber
    from omop_staging.cosd_staging_901
    where type = 'BR'
)
select
    distinct
        HistoryOfAlcoholPast,
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
from BR o
where o.HistoryOfAlcoholPast is not null
  and not (
        DateFirstSeen is null and
        DateFirstSeenCancerSpecialist is null and
        DateOfPrimaryDiagnosisClinicallyAgreed is null and
        StageDateFinalPretreatmentStage is null and
        StageDateIntegratedStage is null and
        TreatmentStartDateCancer is null and
        ProcedureDate is null
    );
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20CosdV9BreastHistoryOfAlcoholPast%20mapping){: .btn }
### CosdV9BreastHistoryOfAlcoholCurrent
* Value copied from `Date`

* `Date` Observation date [DATE FIRST SEEN](https://www.datadictionary.nhs.uk/data_elements/date_first_seen.html), [DATE FIRST SEEN (CANCER SPECIALIST)](https://www.datadictionary.nhs.uk/data_elements/date_first_seen__cancer_specialist_.html), [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html), [TNM STAGE GROUPING DATE (FINAL PRETREATMENT)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping_date__final_pretreatment_.html), [TNM STAGE GROUPING DATE (INTEGRATED)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping_date__integrated_.html), [TREATMENT START DATE (CANCER)](https://www.datadictionary.nhs.uk/data_elements/treatment_start_date__cancer_.html), [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

```sql
with BR as (
    select
        Record ->> '$.PrimaryPathway.ReferralAndFirstStageOfPatientPathway.DateFirstSeen' as DateFirstSeen,
        Record ->> '$.PrimaryPathway.ReferralAndFirstStageOfPatientPathway.DateFirstSeenCancerSpecialist' as DateFirstSeenCancerSpecialist,
        Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed' as DateOfPrimaryDiagnosisClinicallyAgreed,
        Record ->> '$.PrimaryPathway.Staging.StageDateFinalPretreatmentStage' as StageDateFinalPretreatmentStage,
        Record ->> '$.PrimaryPathway.Staging.StageDateIntegratedStage' as StageDateIntegratedStage,
        coalesce(
            Record ->> '$.Treatment[0].TreatmentStartDateCancer', 
            Record ->> '$.Treatment.TreatmentStartDateCancer'
        ) as TreatmentStartDateCancer,
        coalesce(
            Record ->> '$.Treatment[0].Surgery.ProcedureDate', 
            Record ->> '$.Treatment.Surgery.ProcedureDate'
        ) as ProcedureDate,
        Record ->> '$.ClinicalNurseSpecialistAndRiskFactorAssessments.HistoryOfAlcoholCurrent.@code' as HistoryOfAlcoholCurrent,
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber
    from omop_staging.cosd_staging_901
    where type = 'BR'
)
select
    distinct
        HistoryOfAlcoholCurrent,
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
from BR o
where o.HistoryOfAlcoholCurrent is not null
  and not (
        DateFirstSeen is null and
        DateFirstSeenCancerSpecialist is null and
        DateOfPrimaryDiagnosisClinicallyAgreed is null and
        StageDateFinalPretreatmentStage is null and
        StageDateIntegratedStage is null and
        TreatmentStartDateCancer is null and
        ProcedureDate is null
    );
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20CosdV9BreastHistoryOfAlcoholCurrent%20mapping){: .btn }
### CosdV9BreastFamilialCancerSyndrome
* Value copied from `Date`

* `Date` Observation date [DATE FIRST SEEN](https://www.datadictionary.nhs.uk/data_elements/date_first_seen.html), [DATE FIRST SEEN (CANCER SPECIALIST)](https://www.datadictionary.nhs.uk/data_elements/date_first_seen__cancer_specialist_.html), [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html), [TNM STAGE GROUPING DATE (FINAL PRETREATMENT)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping_date__final_pretreatment_.html), [TNM STAGE GROUPING DATE (INTEGRATED)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping_date__integrated_.html), [TREATMENT START DATE (CANCER)](https://www.datadictionary.nhs.uk/data_elements/treatment_start_date__cancer_.html), [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

```sql
with BR as (
    select
        Record ->> '$.PrimaryPathway.ReferralAndFirstStageOfPatientPathway.DateFirstSeen' as DateFirstSeen,
        Record ->> '$.PrimaryPathway.ReferralAndFirstStageOfPatientPathway.DateFirstSeenCancerSpecialist' as DateFirstSeenCancerSpecialist,
        Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed' as DateOfPrimaryDiagnosisClinicallyAgreed,
        Record ->> '$.PrimaryPathway.Staging.StageDateFinalPretreatmentStage' as StageDateFinalPretreatmentStage,
        Record ->> '$.PrimaryPathway.Staging.StageDateIntegratedStage' as StageDateIntegratedStage,
        coalesce(
            Record ->> '$.Treatment[0].TreatmentStartDateCancer', 
            Record ->> '$.Treatment.TreatmentStartDateCancer'
        ) as TreatmentStartDateCancer,
        coalesce(
            Record ->> '$.Treatment[0].Surgery.ProcedureDate', 
            Record ->> '$.Treatment.Surgery.ProcedureDate'
        ) as ProcedureDate,
        Record ->> '$.PrimaryPathway.Diagnosis.DiagnosisAdditionalItems.FamilialCancerSyndrome.@code' as FamilialCancerSyndrome,
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber
    from omop_staging.cosd_staging_901
    where type = 'BR'
)
select
    distinct
        FamilialCancerSyndrome,
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
from BR o
where o.FamilialCancerSyndrome is not null
  and not (
        DateFirstSeen is null and
        DateFirstSeenCancerSpecialist is null and
        DateOfPrimaryDiagnosisClinicallyAgreed is null and
        StageDateFinalPretreatmentStage is null and
        StageDateIntegratedStage is null and
        TreatmentStartDateCancer is null and
        ProcedureDate is null
    );
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20CosdV9BreastFamilialCancerSyndrome%20mapping){: .btn }
### CosdV9BreastFamilialCancerSyndromeSubsidiaryComment
* Value copied from `Date`

* `Date` Observation date [DATE FIRST SEEN](https://www.datadictionary.nhs.uk/data_elements/date_first_seen.html), [DATE FIRST SEEN (CANCER SPECIALIST)](https://www.datadictionary.nhs.uk/data_elements/date_first_seen__cancer_specialist_.html), [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html), [TNM STAGE GROUPING DATE (FINAL PRETREATMENT)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping_date__final_pretreatment_.html), [TNM STAGE GROUPING DATE (INTEGRATED)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping_date__integrated_.html), [TREATMENT START DATE (CANCER)](https://www.datadictionary.nhs.uk/data_elements/treatment_start_date__cancer_.html), [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

```sql
with BR as (
    select
        Record ->> '$.PrimaryPathway.ReferralAndFirstStageOfPatientPathway.DateFirstSeen' as DateFirstSeen,
        Record ->> '$.PrimaryPathway.ReferralAndFirstStageOfPatientPathway.DateFirstSeenCancerSpecialist' as DateFirstSeenCancerSpecialist,
        Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed' as DateOfPrimaryDiagnosisClinicallyAgreed,
        Record ->> '$.PrimaryPathway.Staging.StageDateFinalPretreatmentStage' as StageDateFinalPretreatmentStage,
        Record ->> '$.PrimaryPathway.Staging.StageDateIntegratedStage' as StageDateIntegratedStage,
        coalesce(
            Record ->> '$.Treatment[0].TreatmentStartDateCancer', 
            Record ->> '$.Treatment.TreatmentStartDateCancer'
        ) as TreatmentStartDateCancer,
        coalesce(
            Record ->> '$.Treatment[0].Surgery.ProcedureDate', 
            Record ->> '$.Treatment.Surgery.ProcedureDate'
        ) as ProcedureDate,
        Record ->> '$.PrimaryPathway.Diagnosis.DiagnosisAdditionalItems.FamilialCancerSyndromeSubsidiaryComment.#cdata-section' as FamilialCancerSyndromeSubsidiaryComment,
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber
    from omop_staging.cosd_staging_901
    where type = 'BR'
)
select
    distinct
        FamilialCancerSyndromeSubsidiaryComment,
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
from BR o
where o.FamilialCancerSyndromeSubsidiaryComment is not null
  and not (
        DateFirstSeen is null and
        DateFirstSeenCancerSpecialist is null and
        DateOfPrimaryDiagnosisClinicallyAgreed is null and
        StageDateFinalPretreatmentStage is null and
        StageDateIntegratedStage is null and
        TreatmentStartDateCancer is null and
        ProcedureDate is null
    );
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20CosdV9BreastFamilialCancerSyndromeSubsidiaryComment%20mapping){: .btn }
### CosdV9BreastAsaScore
* Value copied from `Date`

* `Date` Observation date [DATE FIRST SEEN](https://www.datadictionary.nhs.uk/data_elements/date_first_seen.html), [DATE FIRST SEEN (CANCER SPECIALIST)](https://www.datadictionary.nhs.uk/data_elements/date_first_seen__cancer_specialist_.html), [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html), [TNM STAGE GROUPING DATE (FINAL PRETREATMENT)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping_date__final_pretreatment_.html), [TNM STAGE GROUPING DATE (INTEGRATED)](https://www.datadictionary.nhs.uk/data_elements/tnm_stage_grouping_date__integrated_.html), [TREATMENT START DATE (CANCER)](https://www.datadictionary.nhs.uk/data_elements/treatment_start_date__cancer_.html), [PROCEDURE DATE](https://www.datadictionary.nhs.uk/data_elements/procedure_date.html)

```sql
with BR as (
    select
        Record ->> '$.PrimaryPathway.ReferralAndFirstStageOfPatientPathway.DateFirstSeen' as DateFirstSeen,
        Record ->> '$.PrimaryPathway.ReferralAndFirstStageOfPatientPathway.DateFirstSeenCancerSpecialist' as DateFirstSeenCancerSpecialist,
        Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed' as DateOfPrimaryDiagnosisClinicallyAgreed,
        Record ->> '$.PrimaryPathway.Staging.StageDateFinalPretreatmentStage' as StageDateFinalPretreatmentStage,
        Record ->> '$.PrimaryPathway.Staging.StageDateIntegratedStage' as StageDateIntegratedStage,
        coalesce(
            Record ->> '$.Treatment[0].TreatmentStartDateCancer', 
            Record ->> '$.Treatment.TreatmentStartDateCancer'
        ) as TreatmentStartDateCancer,
        coalesce(
            Record ->> '$.Treatment[0].Surgery.ProcedureDate', 
            Record ->> '$.Treatment.Surgery.ProcedureDate'
        ) as ProcedureDate,
        coalesce(
            Record ->> '$.Treatment[0].Surgery.AsaScore.@code', 
            Record ->> '$.Treatment.Surgery.AsaScore.@code'
        ) as AsaScore,
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber
    from omop_staging.cosd_staging_901
    where type = 'BR'
)
select
    distinct
        AsaScore,
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
from BR o
where o.AsaScore is not null
  and not (
        DateFirstSeen is null and
        DateFirstSeenCancerSpecialist is null and
        DateOfPrimaryDiagnosisClinicallyAgreed is null and
        StageDateFinalPretreatmentStage is null and
        StageDateIntegratedStage is null and
        TreatmentStartDateCancer is null and
        ProcedureDate is null
    );
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20CosdV9BreastAsaScore%20mapping){: .btn }
### COSD V8 Breast Source Of Referral Out Patients
* Value copied from `Date`

* `Date` Approximated date from earliest available date field (first seen, diagnosis, staging, or treatment dates) [Multiple date sources]()

```sql
with BR as (
select 
    Record ->> '$.Breast.BreastCore.BreastCoreReferralAndFirstStageOfPatientPathway.DateFirstSeen' as DateFirstSeen,
    Record ->> '$.Breast.BreastCore.BreastCoreReferralAndFirstStageOfPatientPathway.DateFirstSeenCancerSpecialist' as SpecialistDateFirstSeen,
    Record ->> '$.Breast.BreastCore.BreastCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
    Record ->> '$.Breast.BreastCore.BreastCoreStaging.IntegratedStageTNMStageGroupingDate' as IntegratedStageTNMStageGroupingDate,
    Record ->> '$.Breast.BreastCore.BreastCoreStaging.FinalPreTreatmentTNMStageGroupingDate' as FinalPreTreatmentTNMStageGroupingDate,
    coalesce(
        Record ->> '$.Breast.BreastCore.BreastCoreTreatment[0].CancerTreatmentStartDate', 
        Record ->> '$.Breast.BreastCore.BreastCoreTreatment.CancerTreatmentStartDate'
    ) as CancerTreatmentStartDate,
    coalesce(
        Record ->> '$.Breast.BreastCore.BreastCoreTreatment[0].BreastCoreSurgery.ProcedureDate', 
        Record ->> '$.Breast.BreastCore.BreastCoreTreatment.BreastCoreSurgery.ProcedureDate'
    ) as ProcedureDate,
    Record ->> '$.Breast.BreastCore.BreastCoreReferralAndFirstStageOfPatientPathway.SourceOfReferralForOut-patients.@code' as SourceOfReferralOutPatients,
    Record ->> '$.Breast.BreastCore.BreastCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber
from omop_staging.cosd_staging_81
where Type = 'BR'
)
select
      distinct
          SourceOfReferralOutPatients,
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
from BR o
where o.SourceOfReferralOutPatients is not null
  and not (
    DateFirstSeen is null and
    SpecialistDateFirstSeen is null and
    ClinicalDateCancerDiagnosis is null and
    IntegratedStageTNMStageGroupingDate is null and
    FinalPreTreatmentTNMStageGroupingDate is null and
    CancerTreatmentStartDate is null and
    ProcedureDate is null
    );
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20COSD%20V8%20Breast%20Source%20Of%20Referral%20Out%20Patients%20mapping){: .btn }
### COSD V8 Breast Source Of Referral For Out Patients Non Primary Cancer Pathway
* Value copied from `Date`

* `Date` Approximated date from earliest available date field (first seen, diagnosis, staging, or treatment dates) [Multiple date sources]()

```sql
with BR as (
select 
    Record ->> '$.Breast.BreastCore.BreastCoreReferralAndFirstStageOfPatientPathway.DateFirstSeen' as DateFirstSeen,
    Record ->> '$.Breast.BreastCore.BreastCoreReferralAndFirstStageOfPatientPathway.DateFirstSeenCancerSpecialist' as SpecialistDateFirstSeen,
    Record ->> '$.Breast.BreastCore.BreastCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
    Record ->> '$.Breast.BreastCore.BreastCoreStaging.IntegratedStageTNMStageGroupingDate' as IntegratedStageTNMStageGroupingDate,
    Record ->> '$.Breast.BreastCore.BreastCoreStaging.FinalPreTreatmentTNMStageGroupingDate' as FinalPreTreatmentTNMStageGroupingDate,
    coalesce(
        Record ->> '$.Breast.BreastCore.BreastCoreTreatment[0].CancerTreatmentStartDate', 
        Record ->> '$.Breast.BreastCore.BreastCoreTreatment.CancerTreatmentStartDate'
    ) as CancerTreatmentStartDate,
    coalesce(
        Record ->> '$.Breast.BreastCore.BreastCoreTreatment[0].BreastCoreSurgery.ProcedureDate', 
        Record ->> '$.Breast.BreastCore.BreastCoreTreatment.BreastCoreSurgery.ProcedureDate'
    ) as ProcedureDate,
    Record ->> '$.Breast.BreastCore.BreastCoreReferralAndFirstStageOfPatientPathway.SourceOfReferralForOut-patients.@code' as SourceOfReferralOutPatients,
    Record ->> '$.Breast.BreastCore.BreastCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber
from omop_staging.cosd_staging_81
where Type = 'BR'
)
select
      distinct
          SourceOfReferralOutPatients,
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
from BR o
where o.SourceOfReferralOutPatients is not null
  and not (
    DateFirstSeen is null and
    SpecialistDateFirstSeen is null and
    ClinicalDateCancerDiagnosis is null and
    IntegratedStageTNMStageGroupingDate is null and
    FinalPreTreatmentTNMStageGroupingDate is null and
    CancerTreatmentStartDate is null and
    ProcedureDate is null
    );
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20COSD%20V8%20Breast%20Source%20Of%20Referral%20For%20Out%20Patients%20Non%20Primary%20Cancer%20Pathway%20mapping){: .btn }
### COSD V8 Breast Smoking Status Code
* Value copied from `Date`

* `Date` Approximated date from earliest available date field (first seen, diagnosis, staging, or treatment dates) [Multiple date sources]()

```sql
with BR as (
    select 
        Record ->> '$.Breast.BreastCore.BreastCoreReferralAndFirstStageOfPatientPathway.DateFirstSeen' as DateFirstSeen,
        Record ->> '$.Breast.BreastCore.BreastCoreReferralAndFirstStageOfPatientPathway.DateFirstSeenCancerSpecialist' as SpecialistDateFirstSeen,
        Record ->> '$.Breast.BreastCore.BreastCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
        Record ->> '$.Breast.BreastCore.BreastCoreStaging.IntegratedStageTNMStageGroupingDate' as IntegratedStageTNMStageGroupingDate,
        Record ->> '$.Breast.BreastCore.BreastCoreStaging.FinalPreTreatmentTNMStageGroupingDate' as FinalPreTreatmentTNMStageGroupingDate,
        unnest(
            [
                [Record ->> '$.Breast.BreastCore.BreastCoreTreatment.CancerTreatmentStartDate'], 
                Record ->> '$.Breast.BreastCore.BreastCoreTreatment[*].CancerTreatmentStartDate'
            ], 
            recursive := true
        ) as CancerTreatmentStartDate,
        unnest(
            [
                [Record ->> '$.Breast.BreastCore.BreastCoreTreatment.BreastCoreSurgery.ProcedureDate'], 
                Record ->> '$.Breast.BreastCore.BreastCoreTreatment[*].BreastCoreSurgery.ProcedureDate'
            ], 
            recursive := true
        ) as ProcedureDate,
        Record ->> '$.Breast.BreastCore.BreastCoreClinicalNurseSpecialistAndRiskFactorAssessments.TobaccoSmokingStatus.@code' as SmokingStatusCode,
        Record ->> '$.Breast.BreastCore.BreastCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber
    from omop_staging.cosd_staging_81
    where Type = 'BR'
)
select
      distinct
          SmokingStatusCode,
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
from BR o
where o.SmokingStatusCode is not null
  and not (
    DateFirstSeen is null and
    SpecialistDateFirstSeen is null and
    ClinicalDateCancerDiagnosis is null and
    IntegratedStageTNMStageGroupingDate is null and
    FinalPreTreatmentTNMStageGroupingDate is null and
    CancerTreatmentStartDate is null and
    ProcedureDate is null
    );
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20COSD%20V8%20Breast%20Smoking%20Status%20Code%20mapping){: .btn }
### COSD V8 Breast Person Stated Sexual Orientation Code At Diagnosis
* Value copied from `Date`

* `Date` Approximated date from earliest available date field (diagnosis, procedure or treatment dates) [Multiple date sources]()

```sql
with BR as (
select 
    Record ->> '$.Breast.BreastCore.BreastCoreDemographics.PersonStatedSexualOrientationCodeAtDiagnosis.@code' as PersonStatedSexualOrientationCodeAtDiagnosis,
    Record ->> '$.Breast.BreastCore.BreastCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
    coalesce(
        Record ->> '$.Breast.BreastCore.BreastCoreTreatment[0].BreastCoreSurgery.ProcedureDate',
        Record ->> '$.Breast.BreastCore.BreastCoreTreatment.BreastCoreSurgery.ProcedureDate'
    ) as ProcedureDate,
    coalesce(
        Record ->> '$.Breast.BreastCore.BreastCoreTreatment[0].CancerTreatmentStartDate',
        Record ->> '$.Breast.BreastCore.BreastCoreTreatment.CancerTreatmentStartDate'
    ) as CancerTreatmentStartDate,
    Record ->> '$.Breast.BreastCore.BreastCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber
from omop_staging.cosd_staging_81
where Type = 'BR'
)
select
      distinct
          PersonStatedSexualOrientationCodeAtDiagnosis,
          NhsNumber,
          least(
                cast (ClinicalDateCancerDiagnosis as date),
                cast (ProcedureDate as date),
                cast (CancerTreatmentStartDate as date)
          ) as Date
from BR o
where o.PersonStatedSexualOrientationCodeAtDiagnosis is not null
  and not (
    ClinicalDateCancerDiagnosis is null and
    ProcedureDate is null and
    CancerTreatmentStartDate is null
    );
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20COSD%20V8%20Breast%20Person%20Stated%20Sexual%20Orientation%20Code%20At%20Diagnosis%20mapping){: .btn }
### COSD V8 Breast Familial Cancer Syndrome Indicator
* Value copied from `Date`

* `Date` Approximated date from earliest available date field (first seen, diagnosis, staging, or treatment dates) [Multiple date sources]()

```sql
with BR as (
select 
    Record ->> '$.Breast.BreastCore.BreastCoreReferralAndFirstStageOfPatientPathway.DateFirstSeen' as DateFirstSeen,
    Record ->> '$.Breast.BreastCore.BreastCoreReferralAndFirstStageOfPatientPathway.DateFirstSeenCancerSpecialist' as SpecialistDateFirstSeen,
    Record ->> '$.Breast.BreastCore.BreastCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
    Record ->> '$.Breast.BreastCore.BreastCoreStaging.IntegratedStageTNMStageGroupingDate' as IntegratedStageTNMStageGroupingDate,
    Record ->> '$.Breast.BreastCore.BreastCoreStaging.FinalPreTreatmentTNMStageGroupingDate' as FinalPreTreatmentTNMStageGroupingDate,
    coalesce(
        Record ->> '$.Breast.BreastCore.BreastCoreTreatment[0].CancerTreatmentStartDate',
        Record ->> '$.Breast.BreastCore.BreastCoreTreatment.CancerTreatmentStartDate'
    ) as CancerTreatmentStartDate,
    coalesce(
        Record ->> '$.Breast.BreastCore.BreastCoreTreatment[0].BreastCoreSurgery.ProcedureDate',
        Record ->> '$.Breast.BreastCore.BreastCoreTreatment.BreastCoreSurgery.ProcedureDate'
    ) as ProcedureDate,
    Record ->> '$.Breast.BreastCore.BreastCoreDiagnosis.FamilialCancerSyndrome.@code' as FamilialCancerSyndromeIndicator,
    Record ->> '$.Breast.BreastCore.BreastCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber
from omop_staging.cosd_staging_81
where Type = 'BR'
)
select
      distinct
          FamilialCancerSyndromeIndicator,
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
from BR o
where o.FamilialCancerSyndromeIndicator is not null
  and not (
    DateFirstSeen is null and
    SpecialistDateFirstSeen is null and
    ClinicalDateCancerDiagnosis is null and
    IntegratedStageTNMStageGroupingDate is null and
    FinalPreTreatmentTNMStageGroupingDate is null and
    CancerTreatmentStartDate is null and
    ProcedureDate is null
    );
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20COSD%20V8%20Breast%20Familial%20Cancer%20Syndrome%20Indicator%20mapping){: .btn }
### COSD V9 BA Observation Performance Status Adult
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` The date the Primary Cancer was confirmed or the Primary Cancer diagnosis was clinically agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
-- Selects PERFORMANCE STATUS (ADULT) for CNS / Brain (BA) records in
-- COSD v9.01. This WHO performance status is a clinical assessment of the
-- patient's functional status and is routed to the OMOP observation table.
--
-- The DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) is used as the
-- observation_date because the performance status is recorded around the
-- point of diagnosis.
--
-- Downstream ETL responsibilities:
--   * Resolve NhsNumber against cdm.person to obtain person_id.
--   * Map PerformanceStatusAdult (NHS National Code) to the standard
--     observation_concept_id and retain the verbatim code in
--     observation_source_value / value_source_value.
--   * Cast DateOfPrimaryDiagnosisClinicallyAgreed (varchar) to a DATE and
--     assign to observation_date / observation_datetime.
select distinct
    -- NHS NUMBER - patient identifier, mandatory; used to join to cdm.person.
    Record ->> '$.LinkagePatientId.NhsNumber.@extension'
        as NhsNumber,
    -- DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) - becomes
    -- observation_date / observation_datetime.
    Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    -- PERFORMANCE STATUS (ADULT) - the observation value; mapped downstream
    -- to observation_concept_id and retained as observation_source_value.
    Record ->> '$.PrimaryPathway.Diagnosis.PerformanceStatusAdult.@code'
        as PerformanceStatusAdult
from omop_staging.cosd_staging_901
where type = 'BA'
  and NhsNumber is not null
  and PerformanceStatusAdult is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20COSD%20V9%20BA%20Observation%20Performance%20Status%20Adult%20mapping){: .btn }
### COSD V9 BA Observation Cancer Treatment Intent
Source column  `TreatmentStartDateCancer`.
Converts text to dates.

* `TreatmentStartDateCancer` The start date of a cancer treatment during a Cancer Care Spell. [TREATMENT START DATE (CANCER)](https://www.datadictionary.nhs.uk/data_elements/treatment_start_date__cancer_.html)

```sql
-- Selects CANCER TREATMENT INTENT paired with TREATMENT START DATE (CANCER)
-- for CNS / Brain (BA) records in COSD v9.01, routed to the OMOP
-- observation table. Each record's Treatment array carries one
-- (intent, start date) pair per entry, so the JSON paths are unnested in
-- lockstep so each treatment intent keeps its own start date.
--
-- The TREATMENT START DATE (CANCER) is used as the observation_date because
-- the treatment intent applies to that treatment event.
--
-- Downstream ETL responsibilities:
--   * Resolve NhsNumber against cdm.person to obtain person_id.
--   * Map CancerTreatmentIntent (NHS National Code) to the standard
--     observation_concept_id and retain the verbatim code in
--     observation_source_value / value_source_value.
--   * Cast TreatmentStartDateCancer (varchar) to a DATE and assign to
--     observation_date / observation_datetime.
with ba as (
    select
        -- NHS NUMBER - patient identifier, mandatory; used to join to cdm.person.
        Record ->> '$.LinkagePatientId.NhsNumber.@extension'
            as NhsNumber,
        -- CANCER TREATMENT INTENT - the observation value; unnested in
        -- lockstep with the treatment start date.
        unnest([
            [Record ->> '$.Treatment.CancerTreatmentIntent.@code'],
            Record ->> '$.Treatment[*].CancerTreatmentIntent.@code'
        ], recursive := true) as CancerTreatmentIntent,
        -- TREATMENT START DATE (CANCER) - becomes observation_date /
        -- observation_datetime. Paired one-to-one with CancerTreatmentIntent.
        unnest([
            [Record ->> '$.Treatment.TreatmentStartDateCancer'],
            Record ->> '$.Treatment[*].TreatmentStartDateCancer'
        ], recursive := true) as TreatmentStartDateCancer
    from omop_staging.cosd_staging_901
    where type = 'BA'
)
select distinct
    NhsNumber,
    TreatmentStartDateCancer,
    CancerTreatmentIntent
from ba
where NhsNumber is not null
  and CancerTreatmentIntent is not null
  and TreatmentStartDateCancer is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20COSD%20V9%20BA%20Observation%20Cancer%20Treatment%20Intent%20mapping){: .btn }
### COSD V8 BA Observation Performance Status Adult
Source column  `DateOfPrimaryDiagnosisClinicallyAgreed`.
Converts text to dates.

* `DateOfPrimaryDiagnosisClinicallyAgreed` The date the Primary Cancer was confirmed or the Primary Cancer diagnosis was clinically agreed. [DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED)](https://www.datadictionary.nhs.uk/data_elements/date_of_primary_cancer_diagnosis__clinically_agreed_.html)

```sql
-- Selects PERFORMANCE STATUS (ADULT) for CNS / Brain (BA) records in
-- COSD v8.1 (CNS core structure), routed to the OMOP observation table.
-- This WHO performance status is a clinical assessment of the patient's
-- functional status.
--
-- The DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) - held in the
-- CNS core as ClinicalDateCancerDiagnosis - is used as the observation_date.
--
-- Downstream ETL responsibilities:
--   * Resolve NhsNumber against cdm.person to obtain person_id.
--   * Map PerformanceStatusAdult (NHS National Code) to the standard
--     observation_concept_id and retain the verbatim code in
--     observation_source_value / value_source_value.
--   * Cast DateOfPrimaryDiagnosisClinicallyAgreed (varchar) to a DATE and
--     assign to observation_date / observation_datetime.
select distinct
    -- NHS NUMBER - patient identifier, mandatory; used to join to cdm.person.
    Record ->> '$.CNS.CNSCore.CNSCoreLinkagePatientId.NHSNumber.@extension'
        as NhsNumber,
    -- DATE OF PRIMARY CANCER DIAGNOSIS (CLINICALLY AGREED) - becomes
    -- observation_date / observation_datetime.
    Record ->> '$.CNS.CNSCore.CNSCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    -- PERFORMANCE STATUS (ADULT) - the observation value; mapped downstream
    -- to observation_concept_id and retained as observation_source_value.
    Record ->> '$.CNS.CNSCore.CNSCoreDiagnosis.AdultPerformanceStatus.@code'
        as PerformanceStatusAdult
from omop_staging.cosd_staging_81
where type = 'BA'
  and NhsNumber is not null
  and PerformanceStatusAdult is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20COSD%20V8%20BA%20Observation%20Performance%20Status%20Adult%20mapping){: .btn }
### COSD V8 BA Observation Cancer Treatment Intent
Source column  `TreatmentStartDateCancer`.
Converts text to dates.

* `TreatmentStartDateCancer` The start date of a cancer treatment during a Cancer Care Spell. [TREATMENT START DATE (CANCER)](https://www.datadictionary.nhs.uk/data_elements/treatment_start_date__cancer_.html)

```sql
-- Selects CANCER TREATMENT INTENT paired with TREATMENT START DATE (CANCER)
-- for CNS / Brain (BA) records in COSD v8.1 (CNS core structure), routed to
-- the OMOP observation table. Each record's CNSCoreTreatment array carries
-- one (intent, start date) pair per entry, so the JSON paths are unnested
-- in lockstep so each treatment intent keeps its own start date.
--
-- The TREATMENT START DATE (CANCER) is used as the observation_date because
-- the treatment intent applies to that treatment event.
--
-- Downstream ETL responsibilities:
--   * Resolve NhsNumber against cdm.person to obtain person_id.
--   * Map CancerTreatmentIntent (NHS National Code) to the standard
--     observation_concept_id and retain the verbatim code in
--     observation_source_value / value_source_value.
--   * Cast TreatmentStartDateCancer (varchar) to a DATE and assign to
--     observation_date / observation_datetime.
with ba as (
    select
        -- NHS NUMBER - patient identifier, mandatory; used to join to cdm.person.
        Record ->> '$.CNS.CNSCore.CNSCoreLinkagePatientId.NHSNumber.@extension'
            as NhsNumber,
        -- CANCER TREATMENT INTENT - the observation value; unnested in
        -- lockstep with the treatment start date.
        unnest([
            [Record ->> '$.CNS.CNSCore.CNSCoreTreatment.CancerTreatmentIntent.@code'],
            Record ->> '$.CNS.CNSCore.CNSCoreTreatment[*].CancerTreatmentIntent.@code'
        ], recursive := true) as CancerTreatmentIntent,
        -- TREATMENT START DATE (CANCER) - becomes observation_date /
        -- observation_datetime. Paired one-to-one with CancerTreatmentIntent.
        unnest([
            [Record ->> '$.CNS.CNSCore.CNSCoreTreatment.CancerTreatmentStartDate'],
            Record ->> '$.CNS.CNSCore.CNSCoreTreatment[*].CancerTreatmentStartDate'
        ], recursive := true) as TreatmentStartDateCancer
    from omop_staging.cosd_staging_81
    where type = 'BA'
)
select distinct
    NhsNumber,
    TreatmentStartDateCancer,
    CancerTreatmentIntent
from ba
where NhsNumber is not null
  and CancerTreatmentIntent is not null
  and TreatmentStartDateCancer is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_datetime%20field%20COSD%20V8%20BA%20Observation%20Cancer%20Treatment%20Intent%20mapping){: .btn }
