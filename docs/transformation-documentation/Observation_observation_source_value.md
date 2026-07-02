---
layout: default
title: observation_source_value
parent: Observation
grand_parent: Transformation Documentation
has_toc: false
---
# observation_source_value
### SUS Outpatient Procedure Observation
* Value copied from `PrimaryProcedure`

* `PrimaryProcedure` OPCS-4 Procedure code. [PROCEDURE (OPCS)](https://www.datadictionary.nhs.uk/data_elements/procedure__opcs_.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_value%20field%20SUS%20Outpatient%20Procedure%20Observation%20mapping){: .btn }
### Sus OP ICDDiagnosis table
* Value copied from `DiagnosisICD`

* `DiagnosisICD` ICD10 diagnosis code [PRIMARY DIAGNOSIS (ICD)](https://www.datadictionary.nhs.uk/data_elements/primary_diagnosis__icd_.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_value%20field%20Sus%20OP%20ICDDiagnosis%20table%20mapping){: .btn }
### Sus CCMDS High Cost Drugs
* Value copied from `ObservationSourceValue`

* `ObservationSourceValue` High cost drugs. [HIGH COST DRUGS (OPCS)](https://www.datadictionary.nhs.uk/data_elements/high_cost_drugs__opcs_.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_value%20field%20Sus%20CCMDS%20High%20Cost%20Drugs%20mapping){: .btn }
### SUS APC Procedure Occurrence
* Value copied from `PrimaryProcedure`

* `PrimaryProcedure` OPCS-4 Procedure code. [PROCEDURE (OPCS)](https://www.datadictionary.nhs.uk/data_elements/procedure__opcs_.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_value%20field%20SUS%20APC%20Procedure%20Occurrence%20mapping){: .btn }
### Sus APC Diagnosis Table
* Value copied from `DiagnosisICD`

* `DiagnosisICD` ICD10 diagnosis code [PRIMARY DIAGNOSIS (ICD)](https://www.datadictionary.nhs.uk/data_elements/primary_diagnosis__icd_.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_value%20field%20Sus%20APC%20Diagnosis%20Table%20mapping){: .btn }
### SACT Clinical Trial
* Value copied from `Source_value`

* `Source_value` Source value for the Systemic Anti-Cancer Therapy Data Set, CLINICAL TRIAL INDICATOR identifies if a PATIENT  is currently in an active Systemic Anti-Cancer Therapy CLINICAL TRIAL [CLINICAL TRIAL INDICATOR](https://www.datadictionary.nhs.uk/data_elements/clinical_trial_indicator.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_value%20field%20SACT%20Clinical%20Trial%20mapping){: .btn }
### Oxford Lab General Comment Observation
* Value copied from `EVENT`

* `EVENT` Lab test event [EVENT]()

```sql
select
    NHS_NUMBER,
    EVENT,
    EVENT_START_DT_TM,
    RESULT_VALUE
from ##duckdb_source##
where lower(EVENT) like '%comment%'
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_value%20field%20Oxford%20Lab%20General%20Comment%20Observation%20mapping){: .btn }
### COSD V9 UR Observation Smoking Status Cancer
* Value copied from `SmokingStatusCancer`

* `SmokingStatusCancer` Used in the Cancer Outcomes and Services Data Set: Core to identify if the patient smokes tobacco only. [SMOKING STATUS (CANCER)](https://www.datadictionary.nhs.uk/data_elements/smoking_status__cancer_.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_value%20field%20COSD%20V9%20UR%20Observation%20Smoking%20Status%20Cancer%20mapping){: .btn }
### COSD V9 UR Observation Alcohol History Cancer In Last Three Months
* Value copied from `AlcoholHistoryCancerInLastThreeMonths`

* `AlcoholHistoryCancerInLastThreeMonths` Recent history of alcohol consumption for the patient during a cancer care spell. [ALCOHOL HISTORY (CANCER IN LAST THREE MONTHS)](https://www.datadictionary.nhs.uk/data_elements/alcohol_history__cancer_in_last_three_months_.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_value%20field%20COSD%20V9%20UR%20Observation%20Alcohol%20History%20Cancer%20In%20Last%20Three%20Months%20mapping){: .btn }
### COSD V9 UR Observation Alcohol History Cancer Before Last Three Months
* Value copied from `AlcoholHistoryCancerBeforeLastThreeMonths`

* `AlcoholHistoryCancerBeforeLastThreeMonths` Past history of alcohol consumption for the patient during a cancer care spell. [ALCOHOL HISTORY (CANCER BEFORE LAST THREE MONTHS)](https://www.datadictionary.nhs.uk/data_elements/alcohol_history__cancer_before_last_three_months_.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_value%20field%20COSD%20V9%20UR%20Observation%20Alcohol%20History%20Cancer%20Before%20Last%20Three%20Months%20mapping){: .btn }
### COSD V8 UR Observation Smoking Status Cancer
* Value copied from `SmokingStatusCancer`

* `SmokingStatusCancer` Used in the Cancer Outcomes and Services Data Set: Core to identify if the patient smokes tobacco only. [SMOKING STATUS (CANCER)](https://www.datadictionary.nhs.uk/data_elements/smoking_status__cancer_.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_value%20field%20COSD%20V8%20UR%20Observation%20Smoking%20Status%20Cancer%20mapping){: .btn }
### COSD V8 UR Observation Person Stated Sexual Orientation Code At Diagnosis
* Value copied from `PersonStatedSexualOrientationCodeAtDiagnosis`

* `PersonStatedSexualOrientationCodeAtDiagnosis` The sexual orientation as self-stated by the person at the point of cancer diagnosis. [PERSON STATED SEXUAL ORIENTATION CODE (AT DIAGNOSIS)](https://www.datadictionary.nhs.uk/data_elements/person_stated_sexual_orientation_code__at_diagnosis_.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_value%20field%20COSD%20V8%20UR%20Observation%20Person%20Stated%20Sexual%20Orientation%20Code%20At%20Diagnosis%20mapping){: .btn }
### COSD V8 UR Observation Asa Physical Status Classification System Code
* Value copied from `AsaPhysicalStatusClassificationSystemCode`

* `AsaPhysicalStatusClassificationSystemCode` The American Society of Anesthesiologists (ASA) physical status classification system code for assessing a patient's fitness before surgery. [ASA PHYSICAL STATUS CLASSIFICATION SYSTEM CODE](https://www.datadictionary.nhs.uk/data_elements/asa_physical_status_classification_system_code.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_value%20field%20COSD%20V8%20UR%20Observation%20Asa%20Physical%20Status%20Classification%20System%20Code%20mapping){: .btn }
### COSD V8 UR Observation Alcohol History Cancer In Last Three Months
* Value copied from `AlcoholHistoryCancerInLastThreeMonths`

* `AlcoholHistoryCancerInLastThreeMonths` Recent history of alcohol consumption for the patient during a cancer care spell. [ALCOHOL HISTORY (CANCER IN LAST THREE MONTHS)](https://www.datadictionary.nhs.uk/data_elements/alcohol_history__cancer_in_last_three_months_.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_value%20field%20COSD%20V8%20UR%20Observation%20Alcohol%20History%20Cancer%20In%20Last%20Three%20Months%20mapping){: .btn }
### COSD V8 UR Observation Alcohol History Cancer Before Last Three Months
* Value copied from `AlcoholHistoryCancerBeforeLastThreeMonths`

* `AlcoholHistoryCancerBeforeLastThreeMonths` Past history of alcohol consumption for the patient during a cancer care spell. [ALCOHOL HISTORY (CANCER BEFORE LAST THREE MONTHS)](https://www.datadictionary.nhs.uk/data_elements/alcohol_history__cancer_before_last_three_months_.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_value%20field%20COSD%20V8%20UR%20Observation%20Alcohol%20History%20Cancer%20Before%20Last%20Three%20Months%20mapping){: .btn }
### COSD V9 UG Observation Smoking Status Cancer
* Value copied from `SmokingStatusCancer`

* `SmokingStatusCancer` Used in the Cancer Outcomes and Services Data Set: Core to identify if the patient smokes tobacco only. [SMOKING STATUS (CANCER)](https://www.datadictionary.nhs.uk/data_elements/smoking_status__cancer_.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_value%20field%20COSD%20V9%20UG%20Observation%20Smoking%20Status%20Cancer%20mapping){: .btn }
### COSD V9 UG Observation Alcohol History Cancer In Last Three Months
* Value copied from `AlcoholHistoryCancerInLastThreeMonths`

* `AlcoholHistoryCancerInLastThreeMonths` Recent history of alcohol consumption for the patient during a cancer care spell. [ALCOHOL HISTORY (CANCER IN LAST THREE MONTHS)](https://www.datadictionary.nhs.uk/data_elements/alcohol_history__cancer_in_last_three_months_.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_value%20field%20COSD%20V9%20UG%20Observation%20Alcohol%20History%20Cancer%20In%20Last%20Three%20Months%20mapping){: .btn }
### COSD V9 UG Observation Alcohol History Cancer Before Last Three Months
* Value copied from `AlcoholHistoryCancerBeforeLastThreeMonths`

* `AlcoholHistoryCancerBeforeLastThreeMonths` Past history of alcohol consumption for the patient during a cancer care spell. [ALCOHOL HISTORY (CANCER BEFORE LAST THREE MONTHS)](https://www.datadictionary.nhs.uk/data_elements/alcohol_history__cancer_before_last_three_months_.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_value%20field%20COSD%20V9%20UG%20Observation%20Alcohol%20History%20Cancer%20Before%20Last%20Three%20Months%20mapping){: .btn }
### COSD V8 UG Observation Smoking Status Cancer
* Value copied from `SmokingStatusCancer`

* `SmokingStatusCancer` Used in the Cancer Outcomes and Services Data Set: Core to identify if the patient smokes tobacco only. [SMOKING STATUS (CANCER)](https://www.datadictionary.nhs.uk/data_elements/smoking_status__cancer_.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_value%20field%20COSD%20V8%20UG%20Observation%20Smoking%20Status%20Cancer%20mapping){: .btn }
### COSD V8 UG Observation Asa Physical Status Classification System Code
* Value copied from `AsaPhysicalStatusClassificationSystemCode`

* `AsaPhysicalStatusClassificationSystemCode` The American Society of Anesthesiologists (ASA) physical status classification system code for assessing a patient's fitness before surgery. [ASA PHYSICAL STATUS CLASSIFICATION SYSTEM CODE](https://www.datadictionary.nhs.uk/data_elements/asa_physical_status_classification_system_code.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_value%20field%20COSD%20V8%20UG%20Observation%20Asa%20Physical%20Status%20Classification%20System%20Code%20mapping){: .btn }
### COSD V8 UG Observation Alcohol History Cancer In Last Three Months
* Value copied from `AlcoholHistoryCancerInLastThreeMonths`

* `AlcoholHistoryCancerInLastThreeMonths` Recent history of alcohol consumption for the patient during a cancer care spell. [ALCOHOL HISTORY (CANCER IN LAST THREE MONTHS)](https://www.datadictionary.nhs.uk/data_elements/alcohol_history__cancer_in_last_three_months_.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_value%20field%20COSD%20V8%20UG%20Observation%20Alcohol%20History%20Cancer%20In%20Last%20Three%20Months%20mapping){: .btn }
### COSD V8 UG Observation Alcohol History Cancer Before Last Three Months
* Value copied from `AlcoholHistoryCancerBeforeLastThreeMonths`

* `AlcoholHistoryCancerBeforeLastThreeMonths` Past history of alcohol consumption for the patient during a cancer care spell. [ALCOHOL HISTORY (CANCER BEFORE LAST THREE MONTHS)](https://www.datadictionary.nhs.uk/data_elements/alcohol_history__cancer_before_last_three_months_.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_value%20field%20COSD%20V8%20UG%20Observation%20Alcohol%20History%20Cancer%20Before%20Last%20Three%20Months%20mapping){: .btn }
### COSD V9 SK Observation Smoking Status Cancer
* Value copied from `SmokingStatusCancer`

* `SmokingStatusCancer` Used in the Cancer Outcomes and Services Data Set: Core to identify if the patient smokes tobacco only. [SMOKING STATUS (CANCER)](https://www.datadictionary.nhs.uk/data_elements/smoking_status__cancer_.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_value%20field%20COSD%20V9%20SK%20Observation%20Smoking%20Status%20Cancer%20mapping){: .btn }
### COSD V9 SK Observation Alcohol History Cancer In Last Three Months
* Value copied from `AlcoholHistoryCancerInLastThreeMonths`

* `AlcoholHistoryCancerInLastThreeMonths` Recent history of alcohol consumption for the patient during a cancer care spell. [ALCOHOL HISTORY (CANCER IN LAST THREE MONTHS)](https://www.datadictionary.nhs.uk/data_elements/alcohol_history__cancer_in_last_three_months_.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_value%20field%20COSD%20V9%20SK%20Observation%20Alcohol%20History%20Cancer%20In%20Last%20Three%20Months%20mapping){: .btn }
### COSD V9 SK Observation Alcohol History Cancer Before Last Three Months
* Value copied from `AlcoholHistoryCancerBeforeLastThreeMonths`

* `AlcoholHistoryCancerBeforeLastThreeMonths` Past history of alcohol consumption for the patient during a cancer care spell. [ALCOHOL HISTORY (CANCER BEFORE LAST THREE MONTHS)](https://www.datadictionary.nhs.uk/data_elements/alcohol_history__cancer_before_last_three_months_.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_value%20field%20COSD%20V9%20SK%20Observation%20Alcohol%20History%20Cancer%20Before%20Last%20Three%20Months%20mapping){: .btn }
### COSD V8 SK Observation Smoking Status Cancer
* Value copied from `SmokingStatusCancer`

* `SmokingStatusCancer` Used in the Cancer Outcomes and Services Data Set: Core to identify if the patient smokes tobacco only. [SMOKING STATUS (CANCER)](https://www.datadictionary.nhs.uk/data_elements/smoking_status__cancer_.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_value%20field%20COSD%20V8%20SK%20Observation%20Smoking%20Status%20Cancer%20mapping){: .btn }
### COSD V8 SK Observation Alcohol History Cancer In Last Three Months
* Value copied from `AlcoholHistoryCancerInLastThreeMonths`

* `AlcoholHistoryCancerInLastThreeMonths` Recent history of alcohol consumption for the patient during a cancer care spell. [ALCOHOL HISTORY (CANCER IN LAST THREE MONTHS)](https://www.datadictionary.nhs.uk/data_elements/alcohol_history__cancer_in_last_three_months_.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_value%20field%20COSD%20V8%20SK%20Observation%20Alcohol%20History%20Cancer%20In%20Last%20Three%20Months%20mapping){: .btn }
### COSD V8 SK Observation Alcohol History Cancer Before Last Three Months
* Value copied from `AlcoholHistoryCancerBeforeLastThreeMonths`

* `AlcoholHistoryCancerBeforeLastThreeMonths` Past history of alcohol consumption for the patient during a cancer care spell. [ALCOHOL HISTORY (CANCER BEFORE LAST THREE MONTHS)](https://www.datadictionary.nhs.uk/data_elements/alcohol_history__cancer_before_last_three_months_.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_value%20field%20COSD%20V8%20SK%20Observation%20Alcohol%20History%20Cancer%20Before%20Last%20Three%20Months%20mapping){: .btn }
### COSD V9 SA Observation Smoking Status Cancer
* Value copied from `SmokingStatusCancer`

* `SmokingStatusCancer` Used in the Cancer Outcomes and Services Data Set: Core to identify if the patient smokes tobacco only. [SMOKING STATUS (CANCER)](https://www.datadictionary.nhs.uk/data_elements/smoking_status__cancer_.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_value%20field%20COSD%20V9%20SA%20Observation%20Smoking%20Status%20Cancer%20mapping){: .btn }
### COSD V9 SA Observation Alcohol History Cancer In Last Three Months
* Value copied from `AlcoholHistoryCancerInLastThreeMonths`

* `AlcoholHistoryCancerInLastThreeMonths` Current history of alcohol consumption for the patient during a cancer care spell. [ALCOHOL HISTORY (CANCER IN LAST THREE MONTHS)](https://www.datadictionary.nhs.uk/data_elements/alcohol_history__cancer_in_last_three_months_.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_value%20field%20COSD%20V9%20SA%20Observation%20Alcohol%20History%20Cancer%20In%20Last%20Three%20Months%20mapping){: .btn }
### COSD V9 SA Observation Alcohol History Cancer Before Last Three Months
* Value copied from `AlcoholHistoryCancerBeforeLastThreeMonths`

* `AlcoholHistoryCancerBeforeLastThreeMonths` Past history of alcohol consumption for the patient during a cancer care spell. [ALCOHOL HISTORY (CANCER BEFORE LAST THREE MONTHS)](https://www.datadictionary.nhs.uk/data_elements/alcohol_history__cancer_before_last_three_months_.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_value%20field%20COSD%20V9%20SA%20Observation%20Alcohol%20History%20Cancer%20Before%20Last%20Three%20Months%20mapping){: .btn }
### COSD V8 SA Observation Smoking Status Cancer
* Value copied from `SmokingStatusCancer`

* `SmokingStatusCancer` Used in the Cancer Outcomes and Services Data Set: Core to identify if the patient smokes tobacco only. [SMOKING STATUS (CANCER)](https://www.datadictionary.nhs.uk/data_elements/smoking_status__cancer_.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_value%20field%20COSD%20V8%20SA%20Observation%20Smoking%20Status%20Cancer%20mapping){: .btn }
### COSD V8 SA Observation Alcohol History Cancer In Last Three Months
* Value copied from `AlcoholHistoryCancerInLastThreeMonths`

* `AlcoholHistoryCancerInLastThreeMonths` Current history of alcohol consumption for the patient during a cancer care spell. [ALCOHOL HISTORY (CANCER IN LAST THREE MONTHS)](https://www.datadictionary.nhs.uk/data_elements/alcohol_history__cancer_in_last_three_months_.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_value%20field%20COSD%20V8%20SA%20Observation%20Alcohol%20History%20Cancer%20In%20Last%20Three%20Months%20mapping){: .btn }
### COSD V8 SA Observation Alcohol History Cancer Before Last Three Months
* Value copied from `AlcoholHistoryCancerBeforeLastThreeMonths`

* `AlcoholHistoryCancerBeforeLastThreeMonths` Past history of alcohol consumption for the patient during a cancer care spell. [ALCOHOL HISTORY (CANCER BEFORE LAST THREE MONTHS)](https://www.datadictionary.nhs.uk/data_elements/alcohol_history__cancer_before_last_three_months_.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_value%20field%20COSD%20V8%20SA%20Observation%20Alcohol%20History%20Cancer%20Before%20Last%20Three%20Months%20mapping){: .btn }
### COSD V9 LV Observation Smoking Status Cancer
* Value copied from `SmokingStatusCancer`

* `SmokingStatusCancer` Used in the Cancer Outcomes and Services Data Set: Core to identify if the patient smokes tobacco only. [SMOKING STATUS (CANCER)](https://www.datadictionary.nhs.uk/data_elements/smoking_status__cancer_.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_value%20field%20COSD%20V9%20LV%20Observation%20Smoking%20Status%20Cancer%20mapping){: .btn }
### COSD V9 LV Observation Performance Status Adult
* Value copied from `PerformanceStatusAdult`

* `PerformanceStatusAdult` A World Health Organisation classification indicating a person's status relating to activity or disability. [PERFORMANCE STATUS (ADULT)](https://www.datadictionary.nhs.uk/data_elements/performance_status__adult_.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_value%20field%20COSD%20V9%20LV%20Observation%20Performance%20Status%20Adult%20mapping){: .btn }
### COSD V9 LV Observation Familial Cancer Syndrome Indicator
* Value copied from `FamilialCancerSyndromeIndicator`

* `FamilialCancerSyndromeIndicator` Indicates whether there is a possible or confirmed familial cancer syndrome during a Cancer Care Spell. [FAMILIAL CANCER SYNDROME INDICATOR](https://www.datadictionary.nhs.uk/data_elements/familial_cancer_syndrome_indicator.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_value%20field%20COSD%20V9%20LV%20Observation%20Familial%20Cancer%20Syndrome%20Indicator%20mapping){: .btn }
### COSD V9 LV Observation Cancer Treatment Intent
* Value copied from `CancerTreatmentIntent`

* `CancerTreatmentIntent` The intention of the cancer treatment provided during a Cancer Care Spell. [CANCER TREATMENT INTENT](https://www.datadictionary.nhs.uk/data_elements/cancer_treatment_intent.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_value%20field%20COSD%20V9%20LV%20Observation%20Cancer%20Treatment%20Intent%20mapping){: .btn }
### COSD V8 LV Observation Performance Status Adult
* Value copied from `PerformanceStatusAdult`

* `PerformanceStatusAdult` A World Health Organisation classification indicating a person's status relating to activity or disability. [PERFORMANCE STATUS (ADULT)](https://www.datadictionary.nhs.uk/data_elements/performance_status__adult_.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_value%20field%20COSD%20V8%20LV%20Observation%20Performance%20Status%20Adult%20mapping){: .btn }
### COSD V8 LV Observation Cancer Treatment Intent
* Value copied from `CancerTreatmentIntent`

* `CancerTreatmentIntent` The intention of the cancer treatment provided during a Cancer Care Spell. [CANCER TREATMENT INTENT](https://www.datadictionary.nhs.uk/data_elements/cancer_treatment_intent.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_value%20field%20COSD%20V8%20LV%20Observation%20Cancer%20Treatment%20Intent%20mapping){: .btn }
### COSD V9 HN Observation Smoking Status Cancer
* Value copied from `SmokingStatusCancer`

* `SmokingStatusCancer` Used in the Cancer Outcomes and Services Data Set: Core to identify if the patient smokes tobacco only. [SMOKING STATUS (CANCER)](https://www.datadictionary.nhs.uk/data_elements/smoking_status__cancer_.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_value%20field%20COSD%20V9%20HN%20Observation%20Smoking%20Status%20Cancer%20mapping){: .btn }
### COSD V9 HN Observation Performance Status Adult
* Value copied from `PerformanceStatusAdult`

* `PerformanceStatusAdult` A World Health Organisation classification indicating a person's status relating to activity or disability. [PERFORMANCE STATUS (ADULT)](https://www.datadictionary.nhs.uk/data_elements/performance_status__adult_.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_value%20field%20COSD%20V9%20HN%20Observation%20Performance%20Status%20Adult%20mapping){: .btn }
### COSD V9 HN Observation Familial Cancer Syndrome Indicator
* Value copied from `FamilialCancerSyndromeIndicator`

* `FamilialCancerSyndromeIndicator` Indicates whether there is a possible or confirmed familial cancer syndrome during a Cancer Care Spell. [FAMILIAL CANCER SYNDROME INDICATOR](https://www.datadictionary.nhs.uk/data_elements/familial_cancer_syndrome_indicator.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_value%20field%20COSD%20V9%20HN%20Observation%20Familial%20Cancer%20Syndrome%20Indicator%20mapping){: .btn }
### COSD V9 HN Observation Cancer Treatment Intent
* Value copied from `CancerTreatmentIntent`

* `CancerTreatmentIntent` The intention of the cancer treatment provided during a Cancer Care Spell. [CANCER TREATMENT INTENT](https://www.datadictionary.nhs.uk/data_elements/cancer_treatment_intent.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_value%20field%20COSD%20V9%20HN%20Observation%20Cancer%20Treatment%20Intent%20mapping){: .btn }
### COSD V9 HN Observation Alcohol History Cancer In Last Three Months
* Value copied from `AlcoholHistoryCancerInLastThreeMonths`

* `AlcoholHistoryCancerInLastThreeMonths` Current history of alcohol consumption for the patient during a cancer care spell. [ALCOHOL HISTORY (CANCER IN LAST THREE MONTHS)](https://www.datadictionary.nhs.uk/data_elements/alcohol_history__cancer_in_last_three_months_.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_value%20field%20COSD%20V9%20HN%20Observation%20Alcohol%20History%20Cancer%20In%20Last%20Three%20Months%20mapping){: .btn }
### COSD V9 HN Observation Alcohol History Cancer Before Last Three Months
* Value copied from `AlcoholHistoryCancerBeforeLastThreeMonths`

* `AlcoholHistoryCancerBeforeLastThreeMonths` Past history of alcohol consumption for the patient during a cancer care spell. [ALCOHOL HISTORY (CANCER BEFORE LAST THREE MONTHS)](https://www.datadictionary.nhs.uk/data_elements/alcohol_history__cancer_before_last_three_months_.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_value%20field%20COSD%20V9%20HN%20Observation%20Alcohol%20History%20Cancer%20Before%20Last%20Three%20Months%20mapping){: .btn }
### COSD V8 HN Observation Smoking Status Cancer
* Value copied from `SmokingStatusCancer`

* `SmokingStatusCancer` Used in the Cancer Outcomes and Services Data Set: Core to identify if the patient smokes tobacco only. [SMOKING STATUS (CANCER)](https://www.datadictionary.nhs.uk/data_elements/smoking_status__cancer_.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_value%20field%20COSD%20V8%20HN%20Observation%20Smoking%20Status%20Cancer%20mapping){: .btn }
### COSD V8 HN Observation Performance Status Adult
* Value copied from `PerformanceStatusAdult`

* `PerformanceStatusAdult` A World Health Organisation classification indicating a person's status relating to activity or disability. [PERFORMANCE STATUS (ADULT)](https://www.datadictionary.nhs.uk/data_elements/performance_status__adult_.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_value%20field%20COSD%20V8%20HN%20Observation%20Performance%20Status%20Adult%20mapping){: .btn }
### COSD V8 HN Observation Familial Cancer Syndrome Indicator
* Value copied from `FamilialCancerSyndromeIndicator`

* `FamilialCancerSyndromeIndicator` Indicates whether there is a possible or confirmed familial cancer syndrome during a Cancer Care Spell. [FAMILIAL CANCER SYNDROME INDICATOR](https://www.datadictionary.nhs.uk/data_elements/familial_cancer_syndrome_indicator.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_value%20field%20COSD%20V8%20HN%20Observation%20Familial%20Cancer%20Syndrome%20Indicator%20mapping){: .btn }
### COSD V8 HN Observation Cancer Treatment Intent
* Value copied from `CancerTreatmentIntent`

* `CancerTreatmentIntent` The intention of the cancer treatment provided during a Cancer Care Spell. [CANCER TREATMENT INTENT](https://www.datadictionary.nhs.uk/data_elements/cancer_treatment_intent.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_value%20field%20COSD%20V8%20HN%20Observation%20Cancer%20Treatment%20Intent%20mapping){: .btn }
### COSD V8 HN Observation Alcohol History Cancer In Last Three Months
* Value copied from `AlcoholHistoryCancerInLastThreeMonths`

* `AlcoholHistoryCancerInLastThreeMonths` Current history of alcohol consumption for the patient during a cancer care spell. [ALCOHOL HISTORY (CANCER IN LAST THREE MONTHS)](https://www.datadictionary.nhs.uk/data_elements/alcohol_history__cancer_in_last_three_months_.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_value%20field%20COSD%20V8%20HN%20Observation%20Alcohol%20History%20Cancer%20In%20Last%20Three%20Months%20mapping){: .btn }
### COSD V8 HN Observation Alcohol History Cancer Before Last Three Months
* Value copied from `AlcoholHistoryCancerBeforeLastThreeMonths`

* `AlcoholHistoryCancerBeforeLastThreeMonths` Past history of alcohol consumption for the patient during a cancer care spell. [ALCOHOL HISTORY (CANCER BEFORE LAST THREE MONTHS)](https://www.datadictionary.nhs.uk/data_elements/alcohol_history__cancer_before_last_three_months_.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_value%20field%20COSD%20V8%20HN%20Observation%20Alcohol%20History%20Cancer%20Before%20Last%20Three%20Months%20mapping){: .btn }
### COSD V9 HA Observation Smoking Status Cancer
* Value copied from `SmokingStatusCancer`

* `SmokingStatusCancer` Used in the Cancer Outcomes and Services Data Set: Core to identify if the patient smokes tobacco only. [SMOKING STATUS (CANCER)](https://www.datadictionary.nhs.uk/data_elements/smoking_status__cancer_.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_value%20field%20COSD%20V9%20HA%20Observation%20Smoking%20Status%20Cancer%20mapping){: .btn }
### COSD V9 HA Observation Performance Status Adult
* Value copied from `PerformanceStatusAdult`

* `PerformanceStatusAdult` A World Health Organisation classification indicating a person's status relating to activity or disability. [PERFORMANCE STATUS (ADULT)](https://www.datadictionary.nhs.uk/data_elements/performance_status__adult_.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_value%20field%20COSD%20V9%20HA%20Observation%20Performance%20Status%20Adult%20mapping){: .btn }
### COSD V9 HA Observation Familial Cancer Syndrome Indicator
* Value copied from `FamilialCancerSyndromeIndicator`

* `FamilialCancerSyndromeIndicator` Indicates whether there is a possible or confirmed familial cancer syndrome during a Cancer Care Spell. [FAMILIAL CANCER SYNDROME INDICATOR](https://www.datadictionary.nhs.uk/data_elements/familial_cancer_syndrome_indicator.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_value%20field%20COSD%20V9%20HA%20Observation%20Familial%20Cancer%20Syndrome%20Indicator%20mapping){: .btn }
### COSD V9 HA Observation Cancer Treatment Intent
* Value copied from `CancerTreatmentIntent`

* `CancerTreatmentIntent` The intention of the cancer treatment provided during a Cancer Care Spell. [CANCER TREATMENT INTENT](https://www.datadictionary.nhs.uk/data_elements/cancer_treatment_intent.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_value%20field%20COSD%20V9%20HA%20Observation%20Cancer%20Treatment%20Intent%20mapping){: .btn }
### COSD V9 HA Observation Alcohol History Cancer In Last Three Months
* Value copied from `AlcoholHistoryCancerInLastThreeMonths`

* `AlcoholHistoryCancerInLastThreeMonths` Current history of alcohol consumption for the patient during a cancer care spell. [ALCOHOL HISTORY (CANCER IN LAST THREE MONTHS)](https://www.datadictionary.nhs.uk/data_elements/alcohol_history__cancer_in_last_three_months_.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_value%20field%20COSD%20V9%20HA%20Observation%20Alcohol%20History%20Cancer%20In%20Last%20Three%20Months%20mapping){: .btn }
### COSD V9 HA Observation Alcohol History Cancer Before Last Three Months
* Value copied from `AlcoholHistoryCancerBeforeLastThreeMonths`

* `AlcoholHistoryCancerBeforeLastThreeMonths` Past history of alcohol consumption for the patient during a cancer care spell. [ALCOHOL HISTORY (CANCER BEFORE LAST THREE MONTHS)](https://www.datadictionary.nhs.uk/data_elements/alcohol_history__cancer_before_last_three_months_.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_value%20field%20COSD%20V9%20HA%20Observation%20Alcohol%20History%20Cancer%20Before%20Last%20Three%20Months%20mapping){: .btn }
### COSD V8 HA Observation Smoking Status Cancer
* Value copied from `SmokingStatusCancer`

* `SmokingStatusCancer` Used in the Cancer Outcomes and Services Data Set: Core to identify if the patient smokes tobacco only. [SMOKING STATUS (CANCER)](https://www.datadictionary.nhs.uk/data_elements/smoking_status__cancer_.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_value%20field%20COSD%20V8%20HA%20Observation%20Smoking%20Status%20Cancer%20mapping){: .btn }
### COSD V8 HA Observation Performance Status Adult
* Value copied from `PerformanceStatusAdult`

* `PerformanceStatusAdult` A World Health Organisation classification indicating a person's status relating to activity or disability. [PERFORMANCE STATUS (ADULT)](https://www.datadictionary.nhs.uk/data_elements/performance_status__adult_.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_value%20field%20COSD%20V8%20HA%20Observation%20Performance%20Status%20Adult%20mapping){: .btn }
### COSD V8 HA Observation Familial Cancer Syndrome Indicator
* Value copied from `FamilialCancerSyndromeIndicator`

* `FamilialCancerSyndromeIndicator` Indicates whether there is a possible or confirmed familial cancer syndrome during a Cancer Care Spell. [FAMILIAL CANCER SYNDROME INDICATOR](https://www.datadictionary.nhs.uk/data_elements/familial_cancer_syndrome_indicator.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_value%20field%20COSD%20V8%20HA%20Observation%20Familial%20Cancer%20Syndrome%20Indicator%20mapping){: .btn }
### COSD V8 HA Observation Cancer Treatment Intent
* Value copied from `CancerTreatmentIntent`

* `CancerTreatmentIntent` The intention of the cancer treatment provided during a Cancer Care Spell. [CANCER TREATMENT INTENT](https://www.datadictionary.nhs.uk/data_elements/cancer_treatment_intent.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_value%20field%20COSD%20V8%20HA%20Observation%20Cancer%20Treatment%20Intent%20mapping){: .btn }
### COSD V8 HA Observation Alcohol History Cancer In Last Three Months
* Value copied from `AlcoholHistoryCancerInLastThreeMonths`

* `AlcoholHistoryCancerInLastThreeMonths` Current history of alcohol consumption for the patient during a cancer care spell. [ALCOHOL HISTORY (CANCER IN LAST THREE MONTHS)](https://www.datadictionary.nhs.uk/data_elements/alcohol_history__cancer_in_last_three_months_.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_value%20field%20COSD%20V8%20HA%20Observation%20Alcohol%20History%20Cancer%20In%20Last%20Three%20Months%20mapping){: .btn }
### COSD V8 HA Observation Alcohol History Cancer Before Last Three Months
* Value copied from `AlcoholHistoryCancerBeforeLastThreeMonths`

* `AlcoholHistoryCancerBeforeLastThreeMonths` Past history of alcohol consumption for the patient during a cancer care spell. [ALCOHOL HISTORY (CANCER BEFORE LAST THREE MONTHS)](https://www.datadictionary.nhs.uk/data_elements/alcohol_history__cancer_before_last_three_months_.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_value%20field%20COSD%20V8%20HA%20Observation%20Alcohol%20History%20Cancer%20Before%20Last%20Three%20Months%20mapping){: .btn }
### COSD V9 GY Observation Smoking Status Cancer
* Value copied from `SmokingStatusCancer`

* `SmokingStatusCancer` Used in the Cancer Outcomes and Services Data Set: Core to identify if the patient smokes tobacco only. [SMOKING STATUS (CANCER)](https://www.datadictionary.nhs.uk/data_elements/smoking_status__cancer_.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_value%20field%20COSD%20V9%20GY%20Observation%20Smoking%20Status%20Cancer%20mapping){: .btn }
### COSD V9 GY Observation Performance Status Adult
* Value copied from `PerformanceStatusAdult`

* `PerformanceStatusAdult` A World Health Organisation classification indicating a person's status relating to activity or disability. [PERFORMANCE STATUS (ADULT)](https://www.datadictionary.nhs.uk/data_elements/performance_status__adult_.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_value%20field%20COSD%20V9%20GY%20Observation%20Performance%20Status%20Adult%20mapping){: .btn }
### COSD V9 GY Observation Familial Cancer Syndrome Indicator
* Value copied from `FamilialCancerSyndromeIndicator`

* `FamilialCancerSyndromeIndicator` Indicates whether there is a possible or confirmed familial cancer syndrome during a Cancer Care Spell. [FAMILIAL CANCER SYNDROME INDICATOR](https://www.datadictionary.nhs.uk/data_elements/familial_cancer_syndrome_indicator.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_value%20field%20COSD%20V9%20GY%20Observation%20Familial%20Cancer%20Syndrome%20Indicator%20mapping){: .btn }
### COSD V9 GY Observation Cancer Treatment Intent
* Value copied from `CancerTreatmentIntent`

* `CancerTreatmentIntent` The intention of the cancer treatment provided during a Cancer Care Spell. [CANCER TREATMENT INTENT](https://www.datadictionary.nhs.uk/data_elements/cancer_treatment_intent.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_value%20field%20COSD%20V9%20GY%20Observation%20Cancer%20Treatment%20Intent%20mapping){: .btn }
### COSD V9 GY Observation Alcohol History Cancer In Last Three Months
* Value copied from `AlcoholHistoryCancerInLastThreeMonths`

* `AlcoholHistoryCancerInLastThreeMonths` Current history of alcohol consumption for the patient during a cancer care spell. [ALCOHOL HISTORY (CANCER IN LAST THREE MONTHS)](https://www.datadictionary.nhs.uk/data_elements/alcohol_history__cancer_in_last_three_months_.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_value%20field%20COSD%20V9%20GY%20Observation%20Alcohol%20History%20Cancer%20In%20Last%20Three%20Months%20mapping){: .btn }
### COSD V9 GY Observation Alcohol History Cancer Before Last Three Months
* Value copied from `AlcoholHistoryCancerBeforeLastThreeMonths`

* `AlcoholHistoryCancerBeforeLastThreeMonths` Past history of alcohol consumption for the patient during a cancer care spell. [ALCOHOL HISTORY (CANCER BEFORE LAST THREE MONTHS)](https://www.datadictionary.nhs.uk/data_elements/alcohol_history__cancer_before_last_three_months_.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_value%20field%20COSD%20V9%20GY%20Observation%20Alcohol%20History%20Cancer%20Before%20Last%20Three%20Months%20mapping){: .btn }
### COSD V8 GY Observation Smoking Status Cancer
* Value copied from `SmokingStatusCancer`

* `SmokingStatusCancer` Used in the Cancer Outcomes and Services Data Set: Core to identify if the patient smokes tobacco only. [SMOKING STATUS (CANCER)](https://www.datadictionary.nhs.uk/data_elements/smoking_status__cancer_.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_value%20field%20COSD%20V8%20GY%20Observation%20Smoking%20Status%20Cancer%20mapping){: .btn }
### COSD V8 GY Observation Performance Status Adult
* Value copied from `PerformanceStatusAdult`

* `PerformanceStatusAdult` A World Health Organisation classification indicating a person's status relating to activity or disability. [PERFORMANCE STATUS (ADULT)](https://www.datadictionary.nhs.uk/data_elements/performance_status__adult_.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_value%20field%20COSD%20V8%20GY%20Observation%20Performance%20Status%20Adult%20mapping){: .btn }
### COSD V8 GY Observation Familial Cancer Syndrome Indicator
* Value copied from `FamilialCancerSyndromeIndicator`

* `FamilialCancerSyndromeIndicator` Indicates whether there is a possible or confirmed familial cancer syndrome during a Cancer Care Spell. [FAMILIAL CANCER SYNDROME INDICATOR](https://www.datadictionary.nhs.uk/data_elements/familial_cancer_syndrome_indicator.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_value%20field%20COSD%20V8%20GY%20Observation%20Familial%20Cancer%20Syndrome%20Indicator%20mapping){: .btn }
### COSD V8 GY Observation Cancer Treatment Intent
* Value copied from `CancerTreatmentIntent`

* `CancerTreatmentIntent` The intention of the cancer treatment provided during a Cancer Care Spell. [CANCER TREATMENT INTENT](https://www.datadictionary.nhs.uk/data_elements/cancer_treatment_intent.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_value%20field%20COSD%20V8%20GY%20Observation%20Cancer%20Treatment%20Intent%20mapping){: .btn }
### COSD V8 GY Observation Alcohol History Cancer In Last Three Months
* Value copied from `AlcoholHistoryCancerInLastThreeMonths`

* `AlcoholHistoryCancerInLastThreeMonths` Current history of alcohol consumption for the patient during a cancer care spell. [ALCOHOL HISTORY (CANCER IN LAST THREE MONTHS)](https://www.datadictionary.nhs.uk/data_elements/alcohol_history__cancer_in_last_three_months_.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_value%20field%20COSD%20V8%20GY%20Observation%20Alcohol%20History%20Cancer%20In%20Last%20Three%20Months%20mapping){: .btn }
### COSD V8 GY Observation Alcohol History Cancer Before Last Three Months
* Value copied from `AlcoholHistoryCancerBeforeLastThreeMonths`

* `AlcoholHistoryCancerBeforeLastThreeMonths` Past history of alcohol consumption for the patient during a cancer care spell. [ALCOHOL HISTORY (CANCER BEFORE LAST THREE MONTHS)](https://www.datadictionary.nhs.uk/data_elements/alcohol_history__cancer_before_last_three_months_.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_value%20field%20COSD%20V8%20GY%20Observation%20Alcohol%20History%20Cancer%20Before%20Last%20Three%20Months%20mapping){: .btn }
### COSD V9 CT Observation Tobacco Smoking Cessation Treatment Indication Code
* Value copied from `TobaccoSmokingCessationTreatmentIndicationCode`

* `TobaccoSmokingCessationTreatmentIndicationCode` Indication of whether treatment was given to the patient for tobacco smoking cessation. [TOBACCO SMOKING CESSATION TREATMENT INDICATION CODE](https://www.datadictionary.nhs.uk/data_elements/tobacco_smoking_cessation_treatment_indication_code.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_value%20field%20COSD%20V9%20CT%20Observation%20Tobacco%20Smoking%20Cessation%20Treatment%20Indication%20Code%20mapping){: .btn }
### COSD V9 CT Observation Smoking Status Cancer
* Value copied from `SmokingStatusCancer`

* `SmokingStatusCancer` Used in the Cancer Outcomes and Services Data Set: Core to identify if the patient smokes tobacco only. [SMOKING STATUS (CANCER)](https://www.datadictionary.nhs.uk/data_elements/smoking_status__cancer_.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_value%20field%20COSD%20V9%20CT%20Observation%20Smoking%20Status%20Cancer%20mapping){: .btn }
### COSD V9 CT Observation Performance Status Adult
* Value copied from `PerformanceStatusAdult`

* `PerformanceStatusAdult` A World Health Organisation classification indicating a person's status relating to activity or disability. [PERFORMANCE STATUS (ADULT)](https://www.datadictionary.nhs.uk/data_elements/performance_status__adult_.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_value%20field%20COSD%20V9%20CT%20Observation%20Performance%20Status%20Adult%20mapping){: .btn }
### COSD V9 CT Observation Familial Cancer Syndrome Indicator
* Value copied from `FamilialCancerSyndromeIndicator`

* `FamilialCancerSyndromeIndicator` Indicates whether there is a possible or confirmed familial cancer syndrome during a Cancer Care Spell. [FAMILIAL CANCER SYNDROME INDICATOR](https://www.datadictionary.nhs.uk/data_elements/familial_cancer_syndrome_indicator.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_value%20field%20COSD%20V9%20CT%20Observation%20Familial%20Cancer%20Syndrome%20Indicator%20mapping){: .btn }
### COSD V9 CT Observation Cancer Treatment Intent
* Value copied from `CancerTreatmentIntent`

* `CancerTreatmentIntent` The intention of the cancer treatment provided during a Cancer Care Spell. [CANCER TREATMENT INTENT](https://www.datadictionary.nhs.uk/data_elements/cancer_treatment_intent.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_value%20field%20COSD%20V9%20CT%20Observation%20Cancer%20Treatment%20Intent%20mapping){: .btn }
### COSD V9 CT Observation Alcohol History Cancer In Last Three Months
* Value copied from `AlcoholHistoryCancerInLastThreeMonths`

* `AlcoholHistoryCancerInLastThreeMonths` Current history of alcohol consumption for the patient during a cancer care spell. [ALCOHOL HISTORY (CANCER IN LAST THREE MONTHS)](https://www.datadictionary.nhs.uk/data_elements/alcohol_history__cancer_in_last_three_months_.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_value%20field%20COSD%20V9%20CT%20Observation%20Alcohol%20History%20Cancer%20In%20Last%20Three%20Months%20mapping){: .btn }
### COSD V9 CT Observation Alcohol History Cancer Before Last Three Months
* Value copied from `AlcoholHistoryCancerBeforeLastThreeMonths`

* `AlcoholHistoryCancerBeforeLastThreeMonths` Past history of alcohol consumption for the patient during a cancer care spell. [ALCOHOL HISTORY (CANCER BEFORE LAST THREE MONTHS)](https://www.datadictionary.nhs.uk/data_elements/alcohol_history__cancer_before_last_three_months_.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_value%20field%20COSD%20V9%20CT%20Observation%20Alcohol%20History%20Cancer%20Before%20Last%20Three%20Months%20mapping){: .btn }
### COSD V8 CT Observation Smoking Status Cancer
* Value copied from `SmokingStatusCancer`

* `SmokingStatusCancer` Used in the Cancer Outcomes and Services Data Set: Core to identify if the patient smokes tobacco only. [SMOKING STATUS (CANCER)](https://www.datadictionary.nhs.uk/data_elements/smoking_status__cancer_.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_value%20field%20COSD%20V8%20CT%20Observation%20Smoking%20Status%20Cancer%20mapping){: .btn }
### COSD V8 CT Observation Performance Status Adult
* Value copied from `PerformanceStatusAdult`

* `PerformanceStatusAdult` A World Health Organisation classification indicating a person's status relating to activity or disability. [PERFORMANCE STATUS (ADULT)](https://www.datadictionary.nhs.uk/data_elements/performance_status__adult_.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_value%20field%20COSD%20V8%20CT%20Observation%20Performance%20Status%20Adult%20mapping){: .btn }
### COSD V8 CT Observation Familial Cancer Syndrome Indicator
* Value copied from `FamilialCancerSyndromeIndicator`

* `FamilialCancerSyndromeIndicator` Indicates whether there is a possible or confirmed familial cancer syndrome during a Cancer Care Spell. [FAMILIAL CANCER SYNDROME INDICATOR](https://www.datadictionary.nhs.uk/data_elements/familial_cancer_syndrome_indicator.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_value%20field%20COSD%20V8%20CT%20Observation%20Familial%20Cancer%20Syndrome%20Indicator%20mapping){: .btn }
### COSD V8 CT Observation Alcohol History Cancer In Last Three Months
* Value copied from `AlcoholHistoryCancerInLastThreeMonths`

* `AlcoholHistoryCancerInLastThreeMonths` Current history of alcohol consumption for the patient during a cancer care spell. [ALCOHOL HISTORY (CANCER IN LAST THREE MONTHS)](https://www.datadictionary.nhs.uk/data_elements/alcohol_history__cancer_in_last_three_months_.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_value%20field%20COSD%20V8%20CT%20Observation%20Alcohol%20History%20Cancer%20In%20Last%20Three%20Months%20mapping){: .btn }
### COSD V8 CT Observation Alcohol History Cancer Before Last Three Months
* Value copied from `AlcoholHistoryCancerBeforeLastThreeMonths`

* `AlcoholHistoryCancerBeforeLastThreeMonths` Past history of alcohol consumption for the patient during a cancer care spell. [ALCOHOL HISTORY (CANCER BEFORE LAST THREE MONTHS)](https://www.datadictionary.nhs.uk/data_elements/alcohol_history__cancer_before_last_three_months_.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_value%20field%20COSD%20V8%20CT%20Observation%20Alcohol%20History%20Cancer%20Before%20Last%20Three%20Months%20mapping){: .btn }
### COSD V9 CR Observation Tobacco Smoking Cessation Treatment Indication Code
* Value copied from `TobaccoSmokingCessationTreatmentIndicationCode`

* `TobaccoSmokingCessationTreatmentIndicationCode` Indication of whether treatment was given to the patient for tobacco smoking cessation. [TOBACCO SMOKING CESSATION TREATMENT INDICATION CODE](https://www.datadictionary.nhs.uk/data_elements/tobacco_smoking_cessation_treatment_indication_code.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_value%20field%20COSD%20V9%20CR%20Observation%20Tobacco%20Smoking%20Cessation%20Treatment%20Indication%20Code%20mapping){: .btn }
### COSD V9 CR Observation Smoking Status Cancer
* Value copied from `SmokingStatusCancer`

* `SmokingStatusCancer` Used in the Cancer Outcomes and Services Data Set: Core to identify if the patient smokes tobacco only. [SMOKING STATUS (CANCER)](https://www.datadictionary.nhs.uk/data_elements/smoking_status__cancer_.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_value%20field%20COSD%20V9%20CR%20Observation%20Smoking%20Status%20Cancer%20mapping){: .btn }
### COSD V9 CR Observation Performance Status Adult
* Value copied from `PerformanceStatusAdult`

* `PerformanceStatusAdult` A World Health Organisation classification indicating a person's status relating to activity or disability. [PERFORMANCE STATUS (ADULT)](https://www.datadictionary.nhs.uk/data_elements/performance_status__adult_.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_value%20field%20COSD%20V9%20CR%20Observation%20Performance%20Status%20Adult%20mapping){: .btn }
### COSD V9 CR Observation Familial Cancer Syndrome Indicator
* Value copied from `FamilialCancerSyndromeIndicator`

* `FamilialCancerSyndromeIndicator` Indicates whether there is a possible or confirmed familial cancer syndrome during a Cancer Care Spell. [FAMILIAL CANCER SYNDROME INDICATOR](https://www.datadictionary.nhs.uk/data_elements/familial_cancer_syndrome_indicator.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_value%20field%20COSD%20V9%20CR%20Observation%20Familial%20Cancer%20Syndrome%20Indicator%20mapping){: .btn }
### COSD V9 CR Observation Cancer Treatment Intent
* Value copied from `CancerTreatmentIntent`

* `CancerTreatmentIntent` The intention of the cancer treatment provided during a Cancer Care Spell. [CANCER TREATMENT INTENT](https://www.datadictionary.nhs.uk/data_elements/cancer_treatment_intent.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_value%20field%20COSD%20V9%20CR%20Observation%20Cancer%20Treatment%20Intent%20mapping){: .btn }
### COSD V9 CR Observation Alcohol History Cancer In Last Three Months
* Value copied from `AlcoholHistoryCancerInLastThreeMonths`

* `AlcoholHistoryCancerInLastThreeMonths` Current history of alcohol consumption for the patient during a cancer care spell. [ALCOHOL HISTORY (CANCER IN LAST THREE MONTHS)](https://www.datadictionary.nhs.uk/data_elements/alcohol_history__cancer_in_last_three_months_.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_value%20field%20COSD%20V9%20CR%20Observation%20Alcohol%20History%20Cancer%20In%20Last%20Three%20Months%20mapping){: .btn }
### COSD V9 CR Observation Alcohol History Cancer Before Last Three Months
* Value copied from `AlcoholHistoryCancerBeforeLastThreeMonths`

* `AlcoholHistoryCancerBeforeLastThreeMonths` Past history of alcohol consumption for the patient during a cancer care spell. [ALCOHOL HISTORY (CANCER BEFORE LAST THREE MONTHS)](https://www.datadictionary.nhs.uk/data_elements/alcohol_history__cancer_before_last_three_months_.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_value%20field%20COSD%20V9%20CR%20Observation%20Alcohol%20History%20Cancer%20Before%20Last%20Three%20Months%20mapping){: .btn }
### COSD V8 CR Observation Smoking Status Cancer
* Value copied from `SmokingStatusCancer`

* `SmokingStatusCancer` Used in the Cancer Outcomes and Services Data Set: Core to identify if the patient smokes tobacco only. [SMOKING STATUS (CANCER)](https://www.datadictionary.nhs.uk/data_elements/smoking_status__cancer_.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_value%20field%20COSD%20V8%20CR%20Observation%20Smoking%20Status%20Cancer%20mapping){: .btn }
### COSD V8 CR Observation Performance Status Adult
* Value copied from `PerformanceStatusAdult`

* `PerformanceStatusAdult` A World Health Organisation classification indicating a person's status relating to activity or disability. [PERFORMANCE STATUS (ADULT)](https://www.datadictionary.nhs.uk/data_elements/performance_status__adult_.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_value%20field%20COSD%20V8%20CR%20Observation%20Performance%20Status%20Adult%20mapping){: .btn }
### COSD V8 CR Observation Cancer Treatment Intent
* Value copied from `CancerTreatmentIntent`

* `CancerTreatmentIntent` The intention of the cancer treatment provided during a Cancer Care Spell. [CANCER TREATMENT INTENT](https://www.datadictionary.nhs.uk/data_elements/cancer_treatment_intent.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_value%20field%20COSD%20V8%20CR%20Observation%20Cancer%20Treatment%20Intent%20mapping){: .btn }
### COSD V8 CR Observation Alcohol History Cancer In Last Three Months
* Value copied from `AlcoholHistoryCancerInLastThreeMonths`

* `AlcoholHistoryCancerInLastThreeMonths` Current history of alcohol consumption for the patient during a cancer care spell. [ALCOHOL HISTORY (CANCER IN LAST THREE MONTHS)](https://www.datadictionary.nhs.uk/data_elements/alcohol_history__cancer_in_last_three_months_.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_value%20field%20COSD%20V8%20CR%20Observation%20Alcohol%20History%20Cancer%20In%20Last%20Three%20Months%20mapping){: .btn }
### COSD V8 CR Observation Alcohol History Cancer Before Last Three Months
* Value copied from `AlcoholHistoryCancerBeforeLastThreeMonths`

* `AlcoholHistoryCancerBeforeLastThreeMonths` Past history of alcohol consumption for the patient during a cancer care spell. [ALCOHOL HISTORY (CANCER BEFORE LAST THREE MONTHS)](https://www.datadictionary.nhs.uk/data_elements/alcohol_history__cancer_before_last_three_months_.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_value%20field%20COSD%20V8%20CR%20Observation%20Alcohol%20History%20Cancer%20Before%20Last%20Three%20Months%20mapping){: .btn }
### COSD V9 BA Observation Performance Status Adult
* Value copied from `PerformanceStatusAdult`

* `PerformanceStatusAdult` A World Health Organisation classification indicating a person's status relating to activity or disability. [PERFORMANCE STATUS (ADULT)](https://www.datadictionary.nhs.uk/data_elements/performance_status__adult_.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_value%20field%20COSD%20V9%20BA%20Observation%20Performance%20Status%20Adult%20mapping){: .btn }
### COSD V9 BA Observation Cancer Treatment Intent
* Value copied from `CancerTreatmentIntent`

* `CancerTreatmentIntent` The intention of the cancer treatment provided during a Cancer Care Spell. [CANCER TREATMENT INTENT](https://www.datadictionary.nhs.uk/data_elements/cancer_treatment_intent.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_value%20field%20COSD%20V9%20BA%20Observation%20Cancer%20Treatment%20Intent%20mapping){: .btn }
### COSD V8 BA Observation Performance Status Adult
* Value copied from `PerformanceStatusAdult`

* `PerformanceStatusAdult` A World Health Organisation classification indicating a person's status relating to activity or disability. [PERFORMANCE STATUS (ADULT)](https://www.datadictionary.nhs.uk/data_elements/performance_status__adult_.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_value%20field%20COSD%20V8%20BA%20Observation%20Performance%20Status%20Adult%20mapping){: .btn }
### COSD V8 BA Observation Cancer Treatment Intent
* Value copied from `CancerTreatmentIntent`

* `CancerTreatmentIntent` The intention of the cancer treatment provided during a Cancer Care Spell. [CANCER TREATMENT INTENT](https://www.datadictionary.nhs.uk/data_elements/cancer_treatment_intent.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20observation_source_value%20field%20COSD%20V8%20BA%20Observation%20Cancer%20Treatment%20Intent%20mapping){: .btn }
