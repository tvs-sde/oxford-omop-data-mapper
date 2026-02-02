---
layout: default
title: value_as_string
parent: Observation
grand_parent: Transformation Documentation
has_toc: false
---
# value_as_string
### SUS OP Source Of Referral For Outpatients
* Value copied from `ReferrerCode`

* `ReferrerCode` Referrer code is the code of the person making the referral request. [REFERRER CODE](https://www.datadictionary.nhs.uk/data_elements/referrer_code.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_as_string%20field%20SUS%20OP%20Source%20Of%20Referral%20For%20Outpatients%20mapping){: .btn }
### SUS OP Referral Received Date For Outpatients
* Value copied from `ReferralRequestReceivedDate`

* `ReferralRequestReceivedDate` The date the Referral request was received by the Health Care Provider. [REFERRAL REQUEST RECEIVED DATE](https://www.datadictionary.nhs.uk/data_elements/referral_request_received_date.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_as_string%20field%20SUS%20OP%20Referral%20Received%20Date%20For%20Outpatients%20mapping){: .btn }
### SUS Outpatient Carer Support Indicator Observation
* Value copied from `CarerSupportIndicator`

* `CarerSupportIndicator` An indication of whether Carer support is available to the PATIENT at their normal residence. [CARER SUPPORT INDICATOR](https://www.datadictionary.nhs.uk/data_elements/carer_support_indicator.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_as_string%20field%20SUS%20Outpatient%20Carer%20Support%20Indicator%20Observation%20mapping){: .btn }
### SUS Inpatient Total Previous Pregnancies Observation
* Value copied from `TotalPreviousPregnancies`

* `TotalPreviousPregnancies` PREGNANCY TOTAL PREVIOUS PREGNANCIES is the number of previous pregnancies resulting in one or more REGISTRABLE BIRTHS. [PREGNANCY TOTAL PREVIOUS PREGNANCIES](https://www.datadictionary.nhs.uk/data_elements/pregnancy_total_previous_pregnancies.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_as_string%20field%20SUS%20Inpatient%20Total%20Previous%20Pregnancies%20Observation%20mapping){: .btn }
### SUS APC Source Of Referral For Inpatients
* Value copied from `ReferrerCode`

* `ReferrerCode` Referrer code is the code of the person making the referral request. [REFERRER CODE](https://www.datadictionary.nhs.uk/data_elements/referrer_code.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_as_string%20field%20SUS%20APC%20Source%20Of%20Referral%20For%20Inpatients%20mapping){: .btn }
### SUS APC Referral Received Date For Inpatients
* Value copied from `ReferralToTreatmentPeriodStartDate`

* `ReferralToTreatmentPeriodStartDate` The start date of a REFERRAL TO TREATMENT PERIOD . [REFERRAL TO TREATMENT PERIOD START DATE](https://www.datadictionary.nhs.uk/data_elements/referral_to_treatment_period_start_date.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_as_string%20field%20SUS%20APC%20Referral%20Received%20Date%20For%20Inpatients%20mapping){: .btn }
### SUS Inpatient Carer Support Indicator Observation
* Value copied from `CarerSupportIndicator`

* `CarerSupportIndicator` An indication of whether Carer support is available to the PATIENT at their normal residence. [CARER SUPPORT INDICATOR](https://www.datadictionary.nhs.uk/data_elements/carer_support_indicator.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_as_string%20field%20SUS%20Inpatient%20Carer%20Support%20Indicator%20Observation%20mapping){: .btn }
### Sus APC Birth Weight Observation
* Value copied from `BirthWeight`

* `BirthWeight` BIRTH WEIGHT is the result of the Clinical Investigation which measures the Birth Weight, where the UNIT OF MEASUREMENT is Grams (g). [BIRTH WEIGHT](https://www.datadictionary.nhs.uk/data_elements/birth_weight.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_as_string%20field%20Sus%20APC%20Birth%20Weight%20Observation%20mapping){: .btn }
### SUS APC Anaesthetic Given Post Labour Delivery Observation
* Value copied from `AnaestheticGivenPostLabourDelivery`

* `AnaestheticGivenPostLabourDelivery` Records whether anaesthetic was given after Delivery, and the type used. [ANAESTHETIC GIVEN POST LABOUR OR DELIVERY CODE](https://www.datadictionary.nhs.uk/data_elements/anaesthetic_given_post_labour_or_delivery_code.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_as_string%20field%20SUS%20APC%20Anaesthetic%20Given%20Post%20Labour%20Delivery%20Observation%20mapping){: .btn }
### SUS APC Anaesthetic During Labour Delivery Observation
* Value copied from `AnaestheticDuringLabourDelivery`

* `AnaestheticDuringLabourDelivery` Records whether anaesthetic was given during Labour/ Delivery, and the type used. [ANAESTHETIC GIVEN DURING LABOUR OR DELIVERY CODE](https://www.datadictionary.nhs.uk/data_elements/anaesthetic_given_during_labour_or_delivery_code.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_as_string%20field%20SUS%20APC%20Anaesthetic%20During%20Labour%20Delivery%20Observation%20mapping){: .btn }
### SUS AE Source Of Referral For AE
* Value copied from `SourceofReferralForAE`

* `SourceofReferralForAE` The source of referral of each Accident and Emergency Episode. [SOURCE OF REFERRAL FOR A and E]()

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_as_string%20field%20SUS%20AE%20Source%20Of%20Referral%20For%20AE%20mapping){: .btn }
### SUS AE Diabetic Patient
* Value copied from `AccidentAndEmergencyDiagnosis`

* `AccidentAndEmergencyDiagnosis` 
				ACCIDENT AND EMERGENCY DIAGNOSIS is a six character code, comprising:
					Diagnosis Condition	n2
					Sub-Analysis	n1
					ACCIDENT AND EMERGENCY ANATOMICAL AREA	n2
					ACCIDENT AND EMERGENCY ANATOMICAL SIDE
			 [PRIMARY DIAGNOSIS]()

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_as_string%20field%20SUS%20AE%20Diabetic%20Patient%20mapping){: .btn }
### SUS AE Diabetic Patient
* Value copied from `AccidentAndEmergencyDiagnosis`

* `AccidentAndEmergencyDiagnosis` 
				ACCIDENT AND EMERGENCY DIAGNOSIS is a six character code, comprising:
					Diagnosis Condition	n2
					Sub-Analysis	n1
					ACCIDENT AND EMERGENCY ANATOMICAL AREA	n2
					ACCIDENT AND EMERGENCY ANATOMICAL SIDE
			 [PRIMARY DIAGNOSIS]()

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_as_string%20field%20SUS%20AE%20Diabetic%20Patient%20mapping){: .btn }
### RTDS Decision To Perform Date
* Value copied from `DateStamp`

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_as_string%20field%20RTDS%20Decision%20To%20Perform%20Date%20mapping){: .btn }
### RTDS Date of Referral
* Value copied from `DateStamp`

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_as_string%20field%20RTDS%20Date%20of%20Referral%20mapping){: .btn }
### Oxford Lab General Comment Observation
* Value copied from `RESULT_VALUE`

* `RESULT_VALUE` Lab report comment text [RESULT VALUE]()

```sql
select
    NHS_NUMBER,
    EVENT,
    EVENT_START_DT_TM,
    RESULT_VALUE
from ##duckdb_source##
where lower(EVENT) like '%comment%'
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_as_string%20field%20Oxford%20Lab%20General%20Comment%20Observation%20mapping){: .btn }
### CosdV9LungSourceOfReferralForOutpatients
* Value copied from `SourceOfReferralForOutpatients`

* `SourceOfReferralForOutpatients` For specific National Code usage, see SOURCE OF REFERRAL FOR OUT-PATIENTS. [SOURCE OF REFERRAL FOR OUT-PATIENTS](https://www.datadictionary.nhs.uk/data_elements/source_of_referral_for_out-patients.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_as_string%20field%20CosdV9LungSourceOfReferralForOutpatients%20mapping){: .btn }
### CosdV9LungSourceOfReferralForNonPrimaryCancerPathway
* Value copied from `SourceOfReferralForNonPrimaryCancerPathway`

* `SourceOfReferralForNonPrimaryCancerPathway` The SOURCE OF REFERRAL FOR NON PRIMARY CANCER PATHWAY records source of referral for the non-primary cancer pathway. [SOURCE OF REFERRAL FOR NON PRIMARY CANCER PATHWAY]()

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_as_string%20field%20CosdV9LungSourceOfReferralForNonPrimaryCancerPathway%20mapping){: .btn }
### CosdV9LungHistoryOfAlcoholPast
* Value copied from `HistoryOfAlcoholPast`

* `HistoryOfAlcoholPast` The past history of alcohol consumption for the PATIENT during a Cancer Care Spell. [HISTORY OF ALCOHOL (PAST)]()

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_as_string%20field%20CosdV9LungHistoryOfAlcoholPast%20mapping){: .btn }
### CosdV9LungHistoryOfAlcoholCurrent
* Value copied from `HistoryOfAlcoholCurrent`

* `HistoryOfAlcoholCurrent` The current history of alcohol consumption for the PATIENT during a Cancer Care Spell. [HISTORY OF ALCOHOL (CURRENT)]()

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_as_string%20field%20CosdV9LungHistoryOfAlcoholCurrent%20mapping){: .btn }
### CosdV9LungFamilialCancerSyndrome
* Value copied from `FamilialCancerSyndrome`

* `FamilialCancerSyndrome` The PERSON INDICATOR recording whether a hereditary cancer-predisposing syndrome has been identified during a Cancer Care Spell. [FAMILIAL CANCER SYNDROME]()

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_as_string%20field%20CosdV9LungFamilialCancerSyndrome%20mapping){: .btn }
### CosdV9LungFamilialCancerSyndromeSubsidiaryComment
* Value copied from `FamilialCancerSyndromeSubsidiaryComment`

* `FamilialCancerSyndromeSubsidiaryComment` Subsidiary comment for familial cancer syndrome identification during a Cancer Care Spell. [FAMILIAL CANCER SYNDROME (SUBSIDIARY COMMENT)]()

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_as_string%20field%20CosdV9LungFamilialCancerSyndromeSubsidiaryComment%20mapping){: .btn }
### CosdV8LungSourceOfReferralOutPatients
* Value copied from `SourceOfReferralOutPatients`

* `SourceOfReferralOutPatients` The SOURCE OF REFERRAL FOR OUT PATIENTS records source of referral for out patients. [SOURCE OF REFERRAL FOR OUT PATIENTS]()

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_as_string%20field%20CosdV8LungSourceOfReferralOutPatients%20mapping){: .btn }
### CosdV8LungSourceOfReferralForOutPatientsNonPrimaryCancerPathway
* Value copied from `SourceOfReferralOutPatients`

* `SourceOfReferralOutPatients` The SOURCE OF REFERRAL FOR NON PRIMARY CANCER PATHWAY records source of referral for the non-primary cancer pathway. [SOURCE OF REFERRAL FOR OUT PATIENTS (NON PRIMARY CANCER PATHWAY)]()

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_as_string%20field%20CosdV8LungSourceOfReferralForOutPatientsNonPrimaryCancerPathway%20mapping){: .btn }
### CosdV8LungPersonStatedSexualOrientationCodeAtDiagnosis
* Value copied from `PersonStatedSexualOrientationCodeAtDiagnosis`

* `PersonStatedSexualOrientationCodeAtDiagnosis` The sexual orientation of a PERSON at the time of diagnosis. [PERSON STATED SEXUAL ORIENTATION CODE AT DIAGNOSIS]()

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_as_string%20field%20CosdV8LungPersonStatedSexualOrientationCodeAtDiagnosis%20mapping){: .btn }
### CosdV8LungAlcoholHistoryCancerInLastThreeMonths
* Value copied from `AlcoholHistoryCancerInLastThreeMonths`

* `AlcoholHistoryCancerInLastThreeMonths` The alcohol consumption by a PATIENT in the 3 months before the cancer diagnosis date. [ALCOHOL HISTORY (CURRENT)]()

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_as_string%20field%20CosdV8LungAlcoholHistoryCancerInLastThreeMonths%20mapping){: .btn }
### CosdV8LungAlcoholHistoryCancerBeforeLastThreeMonths
* Value copied from `AlcoholHistoryCancerBeforeLastThreeMonths`

* `AlcoholHistoryCancerBeforeLastThreeMonths` The alcohol consumption by a PATIENT in the period prior to 3 months before the cancer diagnosis date. [ALCOHOL HISTORY (PAST)]()

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_as_string%20field%20CosdV8LungAlcoholHistoryCancerBeforeLastThreeMonths%20mapping){: .btn }
### CosdV9SourceOfReferralForOutpatients
* Value copied from `SourceOfReferralForOutpatients`

* `SourceOfReferralForOutpatients` For specific National Code usage, see SOURCE OF REFERRAL FOR OUT-PATIENTS. [SOURCE OF REFERRAL FOR OUT-PATIENTS](https://www.datadictionary.nhs.uk/data_elements/source_of_referral_for_out-patients.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_as_string%20field%20CosdV9SourceOfReferralForOutpatients%20mapping){: .btn }
### CosdV9SourceOfReferralForNonPrimaryCancerPathway
* Value copied from `SourceOfReferralForNonPrimaryCancerPathway`

* `SourceOfReferralForNonPrimaryCancerPathway` SOURCE OF REFERRAL FOR OUT-PATIENTS (NON PRIMARY CANCER PATHWAY) identifies the source of referral for a Non Primary Cancer Pathway. [SOURCE OF REFERRAL FOR OUT-PATIENTS (NON PRIMARY CANCER PATHWAY)](https://www.datadictionary.nhs.uk/data_elements/source_of_referral_for_out-patients__non_primary_cancer_pathway_.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_as_string%20field%20CosdV9SourceOfReferralForNonPrimaryCancerPathway%20mapping){: .btn }
### CosdV9PersonSexualOrientationCodeAtDiagnosis
* Value copied from `PersonSexualOrientationCodeAtDiagnosis`

* `PersonSexualOrientationCodeAtDiagnosis` PERSON STATED SEXUAL ORIENTATION CODE (AT DIAGNOSIS) is the PERSON STATED SEXUAL ORIENTATION CODE at the time of the PATIENT DIAGNOSIS. [PERSON STATED SEXUAL ORIENTATION CODE (AT DIAGNOSIS)](https://www.datadictionary.nhs.uk/data_elements/person_stated_sexual_orientation_code__at_diagnosis_.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_as_string%20field%20CosdV9PersonSexualOrientationCodeAtDiagnosis%20mapping){: .btn }
### CosdV9HistoryOfAlcoholPast
* Value copied from `HistoryOfAlcoholPast`

* `HistoryOfAlcoholPast` The past history of alcohol consumption for the PATIENT during a Cancer Care Spell. [ALCOHOL HISTORY (CANCER BEFORE LAST THREE MONTHS)](https://www.datadictionary.nhs.uk/data_elements/alcohol_history__cancer_before_last_three_months_.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_as_string%20field%20CosdV9HistoryOfAlcoholPast%20mapping){: .btn }
### CosdV9HistoryOfAlcoholCurrent
* Value copied from `HistoryOfAlcoholCurrent`

* `HistoryOfAlcoholCurrent` The current history of alcohol consumption for the PATIENT during a Cancer Care Spell. [ALCOHOL HISTORY (CANCER IN LAST THREE MONTHS)](https://www.datadictionary.nhs.uk/data_elements/alcohol_history__cancer_in_last_three_months_.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_as_string%20field%20CosdV9HistoryOfAlcoholCurrent%20mapping){: .btn }
### CosdV9FamilialCancerSyndrome
* Value copied from `FamilialCancerSyndrome`

* `FamilialCancerSyndrome` An indication of whether there is a possible or confirmed familial cancer syndrome during a Cancer Care Spell. [FAMILIAL CANCER SYNDROME INDICATOR](https://www.datadictionary.nhs.uk/data_elements/familial_cancer_syndrome_indicator.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_as_string%20field%20CosdV9FamilialCancerSyndrome%20mapping){: .btn }
### CosdV9FamilialCancerSyndromeSubsidiaryComment
* Value copied from `FamilialCancerSyndromeSubsidiaryComment`

* `FamilialCancerSyndromeSubsidiaryComment` FAMILIAL CANCER SYNDROME COMMENT is free text further information recorded where the FAMILIAL CANCER SYNDROME INDICATOR is National Code 'Y - Yes' or 'P - Possible', to identify distinct syndromes which may have different treatment decisions or outcomes that cannot be coded separately during a Cancer Care Spell. [FAMILIAL CANCER SYNDROME COMMENT](https://www.datadictionary.nhs.uk/data_elements/familial_cancer_syndrome_comment.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_as_string%20field%20CosdV9FamilialCancerSyndromeSubsidiaryComment%20mapping){: .btn }
### CosdV8SourceOfReferralOutPatients
* Value copied from `SourceOfReferralOutPatients`

* `SourceOfReferralOutPatients` For specific National Code usage, see SOURCE OF REFERRAL FOR OUT-PATIENTS. [SOURCE OF REFERRAL FOR OUT-PATIENTS](https://www.datadictionary.nhs.uk/data_elements/source_of_referral_for_out-patients.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_as_string%20field%20CosdV8SourceOfReferralOutPatients%20mapping){: .btn }
### CosdV8SourceOfReferralForOutPatientsNonPrimaryCancerPathway
* Value copied from `SourceOfReferralForOutPatientsNonPrimaryCancerPathway`

* `SourceOfReferralForOutPatientsNonPrimaryCancerPathway` SOURCE OF REFERRAL FOR OUT-PATIENTS (NON PRIMARY CANCER PATHWAY) identifies the source of referral for a Non Primary Cancer Pathway. [SOURCE OF REFERRAL FOR OUT-PATIENTS (NON PRIMARY CANCER PATHWAY)](https://www.datadictionary.nhs.uk/data_elements/source_of_referral_for_out-patients__non_primary_cancer_pathway_.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_as_string%20field%20CosdV8SourceOfReferralForOutPatientsNonPrimaryCancerPathway%20mapping){: .btn }
### CosdV8PersonStatedSexualOrientationCodeAtDiagnosis
* Value copied from `PersonStatedSexualOrientationCodeAtDiagnosis`

* `PersonStatedSexualOrientationCodeAtDiagnosis` PERSON STATED SEXUAL ORIENTATION CODE (AT DIAGNOSIS) is the PERSON STATED SEXUAL ORIENTATION CODE at the time of the PATIENT DIAGNOSIS. [PERSON STATED SEXUAL ORIENTATION CODE (AT DIAGNOSIS)](https://www.datadictionary.nhs.uk/data_elements/person_stated_sexual_orientation_code__at_diagnosis_.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_as_string%20field%20CosdV8PersonStatedSexualOrientationCodeAtDiagnosis%20mapping){: .btn }
### CosdV8FamilialCancerSyndromeIndicator
* Value copied from `FamilialCancerSyndromeIndicator`

* `FamilialCancerSyndromeIndicator` An indication of whether there is a possible or confirmed familial cancer syndrome during a Cancer Care Spell. [FAMILIAL CANCER SYNDROME INDICATOR](https://www.datadictionary.nhs.uk/data_elements/familial_cancer_syndrome_indicator.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_as_string%20field%20CosdV8FamilialCancerSyndromeIndicator%20mapping){: .btn }
### CosdV8AlcoholHistoryCancerInLastThreeMonths
* Value copied from `AlcoholHistoryCancerInLastThreeMonths`

* `AlcoholHistoryCancerInLastThreeMonths` The current history of alcohol consumption for the PATIENT during a Cancer Care Spell. [ALCOHOL HISTORY (CANCER IN LAST THREE MONTHS)](https://www.datadictionary.nhs.uk/data_elements/alcohol_history__cancer_in_last_three_months_.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_as_string%20field%20CosdV8AlcoholHistoryCancerInLastThreeMonths%20mapping){: .btn }
### CosdV8AlcoholHistoryCancerBeforeLastThreeMonths
* Value copied from `AlcoholHistoryCancerBeforeLastThreeMonths`

* `AlcoholHistoryCancerBeforeLastThreeMonths` The past history of alcohol consumption for the PATIENT during a Cancer Care Spell. [ALCOHOL HISTORY (CANCER BEFORE LAST THREE MONTHS)](https://www.datadictionary.nhs.uk/data_elements/alcohol_history__cancer_before_last_three_months_.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_as_string%20field%20CosdV8AlcoholHistoryCancerBeforeLastThreeMonths%20mapping){: .btn }
### CosdV9BreastSourceOfReferralForOutpatients
* Value copied from `SourceOfReferralForOutpatients`

* `SourceOfReferralForOutpatients` The source of referral for a series of attendances at a Consultant led out-PATIENT clinic, or a contact for a domiciliary visit, or a telephone or telemedicine consultation. [SOURCE OF REFERRAL FOR OUT-PATIENTS](https://www.datadictionary.nhs.uk/data_elements/source_of_referral_for_out-patients.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_as_string%20field%20CosdV9BreastSourceOfReferralForOutpatients%20mapping){: .btn }
### CosdV9BreastSourceOfReferralForNonPrimaryCancerPathway
* Value copied from `SourceOfReferralForNonPrimaryCancerPathway`

* `SourceOfReferralForNonPrimaryCancerPathway` The source of referral for a PATIENT with a new primary cancer diagnosis. [SOURCE OF REFERRAL FOR OUT-PATIENTS (NON PRIMARY CANCER PATHWAY)](https://www.datadictionary.nhs.uk/data_elements/source_of_referral_for_out-patients__non_primary_cancer_pathway_.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_as_string%20field%20CosdV9BreastSourceOfReferralForNonPrimaryCancerPathway%20mapping){: .btn }
### CosdV9BreastHistoryOfAlcoholPast
* Value copied from `HistoryOfAlcoholPast`

* `HistoryOfAlcoholPast` HISTORY OF ALCOHOL (PAST) [HISTORY OF ALCOHOL (PAST)]()

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_as_string%20field%20CosdV9BreastHistoryOfAlcoholPast%20mapping){: .btn }
### CosdV9BreastHistoryOfAlcoholCurrent
* Value copied from `HistoryOfAlcoholCurrent`

* `HistoryOfAlcoholCurrent` HISTORY OF ALCOHOL (CURRENT) [HISTORY OF ALCOHOL (CURRENT)]()

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_as_string%20field%20CosdV9BreastHistoryOfAlcoholCurrent%20mapping){: .btn }
### CosdV9BreastFamilialCancerSyndrome
* Value copied from `FamilialCancerSyndrome`

* `FamilialCancerSyndrome` An indication of whether there is a possible or confirmed familial cancer syndrome during a Cancer Care Spell. [FAMILIAL CANCER SYNDROME INDICATOR](https://www.datadictionary.nhs.uk/data_elements/familial_cancer_syndrome_indicator.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_as_string%20field%20CosdV9BreastFamilialCancerSyndrome%20mapping){: .btn }
### CosdV9BreastFamilialCancerSyndromeSubsidiaryComment
* Value copied from `FamilialCancerSyndromeSubsidiaryComment`

* `FamilialCancerSyndromeSubsidiaryComment` FAMILIAL CANCER SYNDROME SUBSIDIARY COMMENT [FAMILIAL CANCER SYNDROME SUBSIDIARY COMMENT]()

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_as_string%20field%20CosdV9BreastFamilialCancerSyndromeSubsidiaryComment%20mapping){: .btn }
### COSD V8 Breast Source Of Referral Out Patients
* Value copied from `SourceOfReferralOutPatients`

* `SourceOfReferralOutPatients` Source Of Referral Out Patients [SourceOfReferralForOut_patients]()

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_as_string%20field%20COSD%20V8%20Breast%20Source%20Of%20Referral%20Out%20Patients%20mapping){: .btn }
### COSD V8 Breast Source Of Referral For Out Patients Non Primary Cancer Pathway
* Value copied from `SourceOfReferralOutPatients`

* `SourceOfReferralOutPatients` Source Of Referral For Out Patients [SourceOfReferralForOut_patients]()

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_as_string%20field%20COSD%20V8%20Breast%20Source%20Of%20Referral%20For%20Out%20Patients%20Non%20Primary%20Cancer%20Pathway%20mapping){: .btn }
### COSD V8 Breast Person Stated Sexual Orientation Code At Diagnosis
* Value copied from `PersonStatedSexualOrientationCodeAtDiagnosis`

* `PersonStatedSexualOrientationCodeAtDiagnosis` Person Stated Sexual Orientation Code At Diagnosis [PersonStatedSexualOrientationCodeAtDiagnosis]()

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_as_string%20field%20COSD%20V8%20Breast%20Person%20Stated%20Sexual%20Orientation%20Code%20At%20Diagnosis%20mapping){: .btn }
### COSD V8 Breast Familial Cancer Syndrome Indicator
* Value copied from `FamilialCancerSyndromeIndicator`

* `FamilialCancerSyndromeIndicator` Familial Cancer Syndrome Indicator [FamilialCancerSyndrome]()

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_as_string%20field%20COSD%20V8%20Breast%20Familial%20Cancer%20Syndrome%20Indicator%20mapping){: .btn }
