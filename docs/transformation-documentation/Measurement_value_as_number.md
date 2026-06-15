---
layout: default
title: value_as_number
parent: Measurement
grand_parent: Transformation Documentation
has_toc: false
---
# value_as_number
### Sus CCMDS Measurement - Gestation Length at Delivery
Source column  `ValueAsNumber`.
Converts text to number.

* `ValueAsNumber` Value of the Length of Gestation at Delivery [GESTATION LENGTH (AT DELIVERY)](https://www.datadictionary.nhs.uk/data_elements/gestation_length__at_delivery_.html)

```sql
		select distinct
				apc.NHSNumber,
				apc.GeneratedRecordIdentifier,
				cc.CriticalCareStartDate as MeasurementDate,
				coalesce(cc.CriticalCareStartTime, '00:00:00') as MeasurementDateTime,
				cc.GestationLengthAtDelivery as ValueAsNumber
		from omop_staging.sus_CCMDS cc 
		inner join omop_staging.sus_APC apc on cc.GeneratedRecordID = apc.GeneratedRecordIdentifier
		where apc.NHSNumber is not null
		and cc.GestationLengthAtDelivery is not null
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20value_as_number%20field%20Sus%20CCMDS%20Measurement%20-%20Gestation%20Length%20at%20Delivery%20mapping){: .btn }
### Sus CCMDS Measurement - Person Weight
Source column  `ValueAsNumber`.
Converts text to number.

* `ValueAsNumber` Value of the Person weight [PERSON WEIGHT](https://www.datadictionary.nhs.uk/data_elements/person_weight.html)

```sql
		select distinct
				apc.NHSNumber,
				apc.GeneratedRecordIdentifier,
				cc.CriticalCareStartDate as MeasurementDate,
				coalesce(cc.CriticalCareStartTime, '00:00:00') as MeasurementDateTime,
				cc.PersonWeight as ValueAsNumber
		from omop_staging.sus_CCMDS cc 
		inner join omop_staging.sus_APC apc on cc.GeneratedRecordID = apc.GeneratedRecordIdentifier
		where apc.NHSNumber is not null
		and cc.PersonWeight is not null
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20value_as_number%20field%20Sus%20CCMDS%20Measurement%20-%20Person%20Weight%20mapping){: .btn }
### SACT Measurement Weight at Start of Regimen
Source column  `Weight_At_Start_Of_Regimen`.
Converts text to number.

* `Weight_At_Start_Of_Regimen` Weight when the Regimen started [WEIGHT AT START OF REGIMEN]()

```sql
		select distinct 
			NHS_Number,
			Weight_At_Start_Of_Regimen,
			Start_Date_Of_Regimen
		from omop_staging.sact_staging
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20value_as_number%20field%20SACT%20Measurement%20Weight%20at%20Start%20of%20Regimen%20mapping){: .btn }
### SACT Measurement Weight at Start of Cycle
Source column  `Weight_At_Start_Of_Cycle`.
Converts text to number.

* `Weight_At_Start_Of_Cycle` Weight when the cycle started [WEIGHT AT START OF CYCLE]()

```sql
		select distinct 
			NHS_Number,
			Weight_At_Start_Of_Cycle,
			Start_Date_Of_Cycle
		from omop_staging.sact_staging
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20value_as_number%20field%20SACT%20Measurement%20Weight%20at%20Start%20of%20Cycle%20mapping){: .btn }
### SACT  Measurement Height
Source column  `Height_At_Start_Of_Regimen`.
Converts text to number.

* `Height_At_Start_Of_Regimen` Height when the treatment started [HEIGHT AT START OF TREATMENT]()

```sql
		select distinct 
			NHS_Number,
			Height_At_Start_Of_Regimen,
			Start_Date_Of_Regimen
		from omop_staging.sact_staging
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20value_as_number%20field%20SACT%20%20Measurement%20Height%20mapping){: .btn }
### COSD V9 UR Measurement Prostate Specific Antigen Diagnosis
Source column  `ProstateSpecificAntigenDiagnosis`.
Converts text to number.

* `ProstateSpecificAntigenDiagnosis` Result of the clinical investigation measuring prostate specific antigen at the time of PATIENT DIAGNOSIS for prostate cancer. Unit of measurement is nanograms per millilitre (ng/ml). [PROSTATE SPECIFIC ANTIGEN (DIAGNOSIS)](https://www.datadictionary.nhs.uk/data_elements/prostate_specific_antigen__diagnosis_.html)

```sql
-- Query to extract Prostate Specific Antigen (Diagnosis) for UR cancer area from COSD v9.
-- PSA is a numeric lab measurement in ng/ml at the time of prostate cancer diagnosis.
-- MeasurementDate uses the primary diagnosis date.
-- PsaDiagnosis is a numeric value that will be stored as value_as_number in OMOP in a later step.
select distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
    Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed' as MeasurementDate,
    Record ->> '$.PrimaryPathway.Diagnosis.DiagnosisProstate.PsaDiagnosis.@value' as ProstateSpecificAntigenDiagnosis
from omop_staging.cosd_staging_901
where type = 'UR'
  and ProstateSpecificAntigenDiagnosis is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20value_as_number%20field%20COSD%20V9%20UR%20Measurement%20Prostate%20Specific%20Antigen%20Diagnosis%20mapping){: .btn }
### COSD V9 UR Measurement Adult Comorbidity Evaluation
Source column  `AdultComorbidityEvaluation`.
Converts text to number.

* `AdultComorbidityEvaluation` The PERSON SCORE recorded during a Cancer Care Spell, where the ASSESSMENT TOOL is 'Adult Comorbidity Evaluation - 27'. [ADULT COMORBIDITY EVALUATION - 27 SCORE](https://www.datadictionary.nhs.uk/data_elements/adult_comorbidity_evaluation_-_27_score.html)

```sql
-- Query to extract Adult Comorbidity Evaluation - 27 Score for UR cancer area from COSD v9.
-- The ACE-27 score measures comorbidity severity during a cancer care spell.
-- MeasurementDate uses the earliest available date from various clinical events.
-- AdultComorbidityEvaluation will be mapped to a measurement value concept in OMOP in a later step.
with UR as (
	select
		Record ->> '$.PrimaryPathway.ReferralAndFirstStageOfPatientPathway.DateFirstSeen' as DateFirstSeen,
		Record ->> '$.PrimaryPathway.ReferralAndFirstStageOfPatientPathway.DateFirstSeenCancerSpecialist' as DateFirstSeenCancerSpecialist,
		Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed' as DateOfPrimaryDiagnosisClinicallyAgreed,
		Record ->> '$.PrimaryPathway.Staging.StageDateFinalPretreatmentStage' as StageDateFinalPretreatmentStage,
		Record ->> '$.PrimaryPathway.Staging.StageDateIntegratedStage' as StageDateIntegratedStage,
		Record ->> '$."CancerCarePlan"."AdultComorbidityEvaluation-27Score"."@code"' as AdultComorbidityEvaluation,
		Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber
	from omop_staging.cosd_staging_901
	where type = 'UR'
)
select distinct
	NhsNumber,
	AdultComorbidityEvaluation,
	least(
		cast(DateFirstSeen as date),
		cast(DateFirstSeenCancerSpecialist as date),
		cast(DateOfPrimaryDiagnosisClinicallyAgreed as date),
		cast(StageDateFinalPretreatmentStage as date),
		cast(StageDateIntegratedStage as date)
	) as MeasurementDate
from UR
where AdultComorbidityEvaluation is not null
  and not (
		DateFirstSeen is null and
		DateFirstSeenCancerSpecialist is null and
		DateOfPrimaryDiagnosisClinicallyAgreed is null and
		StageDateFinalPretreatmentStage is null and
		StageDateIntegratedStage is null
    );
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20value_as_number%20field%20COSD%20V9%20UR%20Measurement%20Adult%20Comorbidity%20Evaluation%20mapping){: .btn }
### COSD V8 UR Measurement Prostate Specific Antigen Diagnosis
Source column  `ProstateSpecificAntigenDiagnosis`.
Converts text to number.

* `ProstateSpecificAntigenDiagnosis` Result of the clinical investigation measuring prostate specific antigen at the time of PATIENT DIAGNOSIS for prostate cancer. Unit of measurement is nanograms per millilitre (ng/ml). [PROSTATE SPECIFIC ANTIGEN (DIAGNOSIS)](https://www.datadictionary.nhs.uk/data_elements/prostate_specific_antigen__diagnosis_.html)

```sql
-- Query to extract Prostate Specific Antigen (Diagnosis) for UR cancer area from COSD v8.
-- PSA is a numeric lab measurement in ng/ml at the time of prostate cancer diagnosis.
-- MeasurementDate uses the diagnosis date.
-- ProstateSpecificAntigenDiagnosis is a numeric value that will be stored as value_as_number in OMOP in a later step.
select distinct
    Record ->> '$.Urological.UrologicalCore.UrologicalCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
    Record ->> '$.Urological.UrologicalCore.UrologicalCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as MeasurementDate,
    Record ->> '$.Urological.UrologicalCore.UrologicalCoreCancerCarePlan.UrologicalCancerCarePlan.ProstateSpecificAntigenDiagnosis.@value' as ProstateSpecificAntigenDiagnosis
from omop_staging.cosd_staging_81
where type = 'UR'
  and ProstateSpecificAntigenDiagnosis is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20value_as_number%20field%20COSD%20V8%20UR%20Measurement%20Prostate%20Specific%20Antigen%20Diagnosis%20mapping){: .btn }
### COSD V8 UG Measurement Adult Comorbidity Evaluation
Source column  `AdultComorbidityEvaluation`.
Converts text to number.

* `AdultComorbidityEvaluation` The PERSON SCORE recorded during a Cancer Care Spell, where the ASSESSMENT TOOL is 'Adult Comorbidity Evaluation - 27'. [ADULT COMORBIDITY EVALUATION - 27 SCORE](https://www.datadictionary.nhs.uk/data_elements/adult_comorbidity_evaluation_-_27_score.html)

```sql
with UG as (
    select
        Record ->> '$.UpperGI.UpperGICore.UpperGICoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
        Record ->> '$.UpperGI.UpperGICore.UpperGICoreReferralAndFirstStageOfPatientPathway.DateFirstSeen' as DateFirstSeen,
        Record ->> '$.UpperGI.UpperGICore.UpperGICoreReferralAndFirstStageOfPatientPathway.SpecialistDateFirstSeen' as SpecialistDateFirstSeen,
        Record ->> '$.UpperGI.UpperGICore.UpperGICoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
        Record ->> '$.UpperGI.UpperGICore.UpperGICoreStaging.FinalPreTreatmentTNMStageGroupingDate' as FinalPreTreatmentTNMStageGroupingDate,
        Record ->> '$.UpperGI.UpperGICore.UpperGICoreStaging.IntegratedStageTNMStageGroupingDate' as IntegratedStageTNMStageGroupingDate,
        Record ->> '$.UpperGI.UpperGICore.UpperGICoreCancerCarePlan.AdultComorbidityEvaluation.@code' as AdultComorbidityEvaluation
    from omop_staging.cosd_staging_81
    where type = 'UG'
)
select distinct
    NhsNumber,
    AdultComorbidityEvaluation,
    least(
        cast(DateFirstSeen as date),
        cast(SpecialistDateFirstSeen as date),
        cast(ClinicalDateCancerDiagnosis as date),
        cast(FinalPreTreatmentTNMStageGroupingDate as date),
        cast(IntegratedStageTNMStageGroupingDate as date)
    ) as MeasurementDate
from UG
where AdultComorbidityEvaluation is not null
  and not (
      DateFirstSeen is null and
      SpecialistDateFirstSeen is null and
      ClinicalDateCancerDiagnosis is null and
      FinalPreTreatmentTNMStageGroupingDate is null and
      IntegratedStageTNMStageGroupingDate is null
  );
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20value_as_number%20field%20COSD%20V8%20UG%20Measurement%20Adult%20Comorbidity%20Evaluation%20mapping){: .btn }
### COSD v8 SK Measurement Adult Comorbidity Evaluation
Source column  `AdultComorbidityEvaluation`.
Converts text to number.

* `AdultComorbidityEvaluation` The PERSON SCORE recorded during a Cancer Care Spell, where the ASSESSMENT TOOL is 'Adult Comorbidity Evaluation - 27'. [ADULT COMORBIDITY EVALUATION - 27 SCORE](https://www.datadictionary.nhs.uk/data_elements/adult_comorbidity_evaluation_-_27_score.html)

```sql
with SK as (
	select
		Record ->> '$.Skin.SkinCore.SkinCoreReferralAndFirstStageOfPatientPathway.DateFirstSeen' as DateFirstSeen,
		Record ->> '$.Skin.SkinCore.SkinCoreReferralAndFirstStageOfPatientPathway.SpecialistDateFirstSeen' as SpecialistDateFirstSeen,
		Record ->> '$.Skin.SkinCore.SkinCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
		Record ->> '$.Skin.SkinCore.SkinCoreStaging.IntegratedStageTNMStageGroupingDate' as IntegratedStageTNMStageGroupingDate,
		Record ->> '$.Skin.SkinCore.SkinCoreStaging.FinalPreTreatmentTNMStageGroupingDate' as FinalPreTreatmentTNMStageGroupingDate,
		Record ->> '$.Skin.SkinCore.SkinCoreCancerCarePlan.AdultComorbidityEvaluation.@code' as AdultComorbidityEvaluation,
		Record ->> '$.Skin.SkinCore.SkinCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber
	from omop_staging.cosd_staging_81
	where Type = 'SK'
)
select
	distinct
		AdultComorbidityEvaluation,
		NhsNumber,
		least(
			cast(DateFirstSeen as date),
			cast(SpecialistDateFirstSeen as date),
			cast(ClinicalDateCancerDiagnosis as date),
			cast(IntegratedStageTNMStageGroupingDate as date),
			cast(FinalPreTreatmentTNMStageGroupingDate as date)
		) as MeasurementDate
from SK
where AdultComorbidityEvaluation is not null
  and not (
		DateFirstSeen is null and
		SpecialistDateFirstSeen is null and
		ClinicalDateCancerDiagnosis is null and
		IntegratedStageTNMStageGroupingDate is null and
		FinalPreTreatmentTNMStageGroupingDate is null
    );
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20value_as_number%20field%20COSD%20v8%20SK%20Measurement%20Adult%20Comorbidity%20Evaluation%20mapping){: .btn }
### COSD v8 SA Measurement Adult Comorbidity Evaluation
Source column  `AdultComorbidityEvaluation`.
Converts text to number.

* `AdultComorbidityEvaluation` The PERSON SCORE recorded during a Cancer Care Spell, where the ASSESSMENT TOOL is 'Adult Comorbidity Evaluation - 27'. [ADULT COMORBIDITY EVALUATION]()

```sql
with SA as (
    select
        Record ->> '$.Sarcoma.SarcomaCore.SarcomaCoreReferralAndFirstStageOfPatientPathway.DateFirstSeen' as DateFirstSeen,
        Record ->> '$.Sarcoma.SarcomaCore.SarcomaCoreReferralAndFirstStageOfPatientPathway.SpecialistDateFirstSeen' as SpecialistDateFirstSeen,
        Record ->> '$.Sarcoma.SarcomaCore.SarcomaCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
        Record ->> '$.Sarcoma.SarcomaCore.SarcomaCoreStaging.IntegratedStageTNMStageGroupingDate' as IntegratedStageTNMStageGroupingDate,
        Record ->> '$.Sarcoma.SarcomaCore.SarcomaCoreStaging.FinalPreTreatmentTNMStageGroupingDate' as FinalPreTreatmentTNMStageGroupingDate,
        coalesce(Record ->> '$.Sarcoma.SarcomaCore.SarcomaCoreTreatment[0].CancerTreatmentStartDate', Record ->> '$.Sarcoma.SarcomaCore.SarcomaCoreTreatment.CancerTreatmentStartDate') as CancerTreatmentStartDate,
        coalesce(Record ->> '$.Sarcoma.SarcomaCore.SarcomaCoreTreatment[0].SarcomaCoreSurgeryAndOtherProcedures.ProcedureDate', Record ->> '$.Sarcoma.SarcomaCore.SarcomaCoreTreatment.SarcomaCoreSurgeryAndOtherProcedures.ProcedureDate') as ProcedureDate,
        Record ->> '$.Sarcoma.SarcomaCore.SarcomaCoreCancerCarePlan.AdultComorbidityEvaluation.@code' as AdultComorbidityEvaluation,
        Record ->> '$.Sarcoma.SarcomaCore.SarcomaCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber
    from omop_staging.cosd_staging_81
    where type = 'SA'
)
select distinct
    NhsNumber,
    AdultComorbidityEvaluation,
    least(
        cast(DateFirstSeen as date),
        cast(SpecialistDateFirstSeen as date),
        cast(ClinicalDateCancerDiagnosis as date),
        cast(IntegratedStageTNMStageGroupingDate as date),
        cast(FinalPreTreatmentTNMStageGroupingDate as date),
        cast(CancerTreatmentStartDate as date),
        cast(ProcedureDate as date)
    ) as MeasurementDate
from SA
where AdultComorbidityEvaluation is not null
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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20value_as_number%20field%20COSD%20v8%20SA%20Measurement%20Adult%20Comorbidity%20Evaluation%20mapping){: .btn }
### COSD V9 LV Measurement Adult Comorbidity Evaluation
Source column  `AdultComorbidityEvaluation`.
Converts text to number.

* `AdultComorbidityEvaluation` The PERSON SCORE recorded during a Cancer Care Spell, where the ASSESSMENT TOOL is 'Adult Comorbidity Evaluation - 27'. [ADULT COMORBIDITY EVALUATION - 27 SCORE](https://www.datadictionary.nhs.uk/data_elements/adult_comorbidity_evaluation_-_27_score.html)

```sql
with lv as (
    select
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
        Record ->> '$.PrimaryPathway.ReferralAndFirstStageOfPatientPathway.DateFirstSeen' as DateFirstSeen,
        Record ->> '$.PrimaryPathway.ReferralAndFirstStageOfPatientPathway.DateFirstSeenCancerSpecialist' as DateFirstSeenCancerSpecialist,
        Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed' as DateOfPrimaryDiagnosisClinicallyAgreed,
        Record ->> '$.PrimaryPathway.Staging.StageDateFinalPretreatmentStage' as StageDateFinalPretreatmentStage,
        Record ->> '$.PrimaryPathway.Staging.StageDateIntegratedStage' as StageDateIntegratedStage,
        coalesce(Record ->> '$.Treatment[0].TreatmentStartDateCancer', Record ->> '$.Treatment.TreatmentStartDateCancer') as TreatmentStartDateCancer,
        coalesce(Record ->> '$.Treatment[0].Surgery.ProcedureDate', Record ->> '$.Treatment.Surgery.ProcedureDate') as ProcedureDate,
        Record ->> '$.CancerCarePlan.AdultComorbidityEvaluation-27Score.@code' as AdultComorbidityEvaluation
    from omop_staging.cosd_staging_901
    where type = 'LV'
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
        ) as MeasurementDate
from lv
where AdultComorbidityEvaluation is not null
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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20value_as_number%20field%20COSD%20V9%20LV%20Measurement%20Adult%20Comorbidity%20Evaluation%20mapping){: .btn }
### COSD v8 LV Measurement Adult Comorbidity Evaluation
Source column  `AdultComorbidityEvaluation`.
Converts text to number.

* `AdultComorbidityEvaluation` The PERSON SCORE recorded during a Cancer Care Spell, where the ASSESSMENT TOOL is 'Adult Comorbidity Evaluation - 27'. [ADULT COMORBIDITY EVALUATION - 27 SCORE](https://www.datadictionary.nhs.uk/data_elements/adult_comorbidity_evaluation_-_27_score.html)

```sql
with lv as (
    select
        Record ->> '$.Liver.LiverCore.LiverCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
        Record ->> '$.Liver.LiverCore.LiverCoreReferralAndFirstStageOfPatientPathway.DateFirstSeen' as DateFirstSeen,
        Record ->> '$.Liver.LiverCore.LiverCoreReferralAndFirstStageOfPatientPathway.SpecialistDateFirstSeen' as SpecialistDateFirstSeen,
        Record ->> '$.Liver.LiverCore.LiverCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
        Record ->> '$.Liver.LiverCore.LiverCoreStaging.IntegratedStageTNMStageGroupingDate' as IntegratedStageTNMStageGroupingDate,
        Record ->> '$.Liver.LiverCore.LiverCoreTreatment.CancerTreatmentStartDate' as CancerTreatmentStartDate,
        Record ->> '$.Liver.LiverCore.LiverCoreTreatment.LiverCoreSurgeryAndOtherProcedures.ProcedureDate' as ProcedureDate,
        Record ->> '$.Liver.LiverCore.LiverCoreCancerCarePlan.AdultComorbidityEvaluation.@code' as AdultComorbidityEvaluation
    from omop_staging.cosd_staging_81
    where Type = 'LV'
)
select
    distinct
        AdultComorbidityEvaluation,
        NhsNumber,
        least(
            cast(DateFirstSeen as date),
            cast(SpecialistDateFirstSeen as date),
            cast(ClinicalDateCancerDiagnosis as date),
            cast(IntegratedStageTNMStageGroupingDate as date),
            cast(CancerTreatmentStartDate as date),
            cast(ProcedureDate as date)
        ) as MeasurementDate
from lv
where AdultComorbidityEvaluation is not null
  and not (
        DateFirstSeen is null and
        SpecialistDateFirstSeen is null and
        ClinicalDateCancerDiagnosis is null and
        IntegratedStageTNMStageGroupingDate is null and
        CancerTreatmentStartDate is null and
        ProcedureDate is null
    );
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20value_as_number%20field%20COSD%20v8%20LV%20Measurement%20Adult%20Comorbidity%20Evaluation%20mapping){: .btn }
### COSD V9 HN Measurement Adult Comorbidity Evaluation
Source column  `AdultComorbidityEvaluation`.
Converts text to number.

* `AdultComorbidityEvaluation` The PERSON SCORE recorded during a Cancer Care Spell, where the ASSESSMENT TOOL is 'Adult Comorbidity Evaluation - 27'. [ADULT COMORBIDITY EVALUATION - 27 SCORE](https://www.datadictionary.nhs.uk/data_elements/adult_comorbidity_evaluation_-_27_score.html)

```sql
-- Query to extract Adult Comorbidity Evaluation - 27 Score for HN cancer area from COSD v9.
-- The ACE-27 score is a person score recorded during a Cancer Care Spell using the ACE-27 assessment tool.
-- MeasurementDate is the earliest available date across referral, diagnosis, staging, and procedure dates.
-- AdultComorbidityEvaluation will be mapped to a measurement concept in OMOP in a later step.
with hn as (
    select
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
        Record ->> '$.PrimaryPathway.ReferralAndFirstStageOfPatientPathway.DateFirstSeen' as DateFirstSeen,
        Record ->> '$.PrimaryPathway.ReferralAndFirstStageOfPatientPathway.DateFirstSeenCancerSpecialist' as DateFirstSeenCancerSpecialist,
        Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed' as DateOfPrimaryDiagnosisClinicallyAgreed,
        Record ->> '$.PrimaryPathway.Staging.StageDateFinalPretreatmentStage' as StageDateFinalPretreatmentStage,
        Record ->> '$.PrimaryPathway.Staging.StageDateIntegratedStage' as StageDateIntegratedStage,
        coalesce(Record ->> '$.Treatment[0].Surgery.ProcedureDate', Record ->> '$.Treatment.Surgery.ProcedureDate') as ProcedureDate,
        Record ->> '$.CancerCarePlan.AdultComorbidityEvaluation-27Score.@code' as AdultComorbidityEvaluation
    from omop_staging.cosd_staging_901
    where type = 'HN'
)
select
    distinct
        NhsNumber,
        AdultComorbidityEvaluation,
        least(
            DateFirstSeen,
            DateFirstSeenCancerSpecialist,
            DateOfPrimaryDiagnosisClinicallyAgreed,
            StageDateFinalPretreatmentStage,
            StageDateIntegratedStage,
            ProcedureDate
        ) as MeasurementDate
from hn
where AdultComorbidityEvaluation is not null
  and not (
        DateFirstSeen is null and
        DateFirstSeenCancerSpecialist is null and
        DateOfPrimaryDiagnosisClinicallyAgreed is null and
        StageDateFinalPretreatmentStage is null and
        StageDateIntegratedStage is null and
        ProcedureDate is null
    );
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20value_as_number%20field%20COSD%20V9%20HN%20Measurement%20Adult%20Comorbidity%20Evaluation%20mapping){: .btn }
### COSD V8 HN Measurement Adult Comorbidity Evaluation
Source column  `AdultComorbidityEvaluation`.
Converts text to number.

* `AdultComorbidityEvaluation` The PERSON SCORE recorded during a Cancer Care Spell, where the ASSESSMENT TOOL is 'Adult Comorbidity Evaluation - 27'. [ADULT COMORBIDITY EVALUATION - 27 SCORE](https://www.datadictionary.nhs.uk/data_elements/adult_comorbidity_evaluation_-_27_score.html)

```sql
-- Query to extract Adult Comorbidity Evaluation score for HN cancer area from COSD v8.
-- The ACE-27 score is a person score recorded during a Cancer Care Spell using the ACE-27 assessment tool.
-- MeasurementDate is the earliest available date across referral, diagnosis, staging, and procedure dates.
-- AdultComorbidityEvaluation will be mapped to a measurement concept in OMOP in a later step.
with hn as (
    select
        Record ->> '$.HeadNeck.HeadNeckCore.HeadNeckCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
        Record ->> '$.HeadNeck.HeadNeckCore.HeadNeckCoreReferralAndFirstStageOfPatientPathway.DateFirstSeen' as DateFirstSeen,
        Record ->> '$.HeadNeck.HeadNeckCore.HeadNeckCoreReferralAndFirstStageOfPatientPathway.SpecialistDateFirstSeen' as SpecialistDateFirstSeen,
        Record ->> '$.HeadNeck.HeadNeckCore.HeadNeckCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
        Record ->> '$.HeadNeck.HeadNeckCore.HeadNeckCoreStaging.FinalPreTreatmentTNMStageGroupingDate' as FinalPreTreatmentTNMStageGroupingDate,
        Record ->> '$.HeadNeck.HeadNeckCore.HeadNeckCoreStaging.IntegratedStageTNMStageGroupingDate' as IntegratedStageTNMStageGroupingDate,
        Record ->> '$.HeadNeck.HeadNeckCore.HeadNeckCoreCancerCarePlan.AdultComorbidityEvaluation.@code' as AdultComorbidityEvaluation
    from omop_staging.cosd_staging_81
    where type = 'HN'
)
select
    distinct
        NhsNumber,
        AdultComorbidityEvaluation,
        least(
            cast(DateFirstSeen as date),
            cast(SpecialistDateFirstSeen as date),
            cast(ClinicalDateCancerDiagnosis as date),
            cast(FinalPreTreatmentTNMStageGroupingDate as date),
            cast(IntegratedStageTNMStageGroupingDate as date)
        ) as MeasurementDate
from hn
where AdultComorbidityEvaluation is not null
  and not (
        DateFirstSeen is null and
        SpecialistDateFirstSeen is null and
        ClinicalDateCancerDiagnosis is null and
        FinalPreTreatmentTNMStageGroupingDate is null and
        IntegratedStageTNMStageGroupingDate is null
    );
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20value_as_number%20field%20COSD%20V8%20HN%20Measurement%20Adult%20Comorbidity%20Evaluation%20mapping){: .btn }
### COSD V8 GY Measurement Adult Comorbidity Evaluation
Source column  `AdultComorbidityEvaluation`.
Converts text to number.

* `AdultComorbidityEvaluation` The PERSON SCORE recorded during a Cancer Care Spell, where the ASSESSMENT TOOL is 'Adult Comorbidity Evaluation - 27'. [ADULT COMORBIDITY EVALUATION - 27 SCORE](https://www.datadictionary.nhs.uk/data_elements/adult_comorbidity_evaluation_-_27_score.html)

```sql
with gy as (
    select
        Record ->> '$.Gynaecological.GynaecologicalCore.GynaecologicalCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
        Record ->> '$.Gynaecological.GynaecologicalCore.GynaecologicalCoreReferralAndFirstStageOfPatientPathway.DateFirstSeen' as DateFirstSeen,
        Record ->> '$.Gynaecological.GynaecologicalCore.GynaecologicalCoreReferralAndFirstStageOfPatientPathway.SpecialistDateFirstSeen' as SpecialistDateFirstSeen,
        Record ->> '$.Gynaecological.GynaecologicalCore.GynaecologicalCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
        Record ->> '$.Gynaecological.GynaecologicalCore.GynaecologicalCoreStaging.IntegratedStageTNMStageGroupingDate' as IntegratedStageTNMStageGroupingDate,
        Record ->> '$.Gynaecological.GynaecologicalCore.GynaecologicalCoreStaging.FinalPreTreatmentTNMStageGroupingDate' as FinalPreTreatmentTNMStageGroupingDate,
        Record ->> '$.Gynaecological.GynaecologicalCore.GynaecologicalCoreTreatment.CancerTreatmentStartDate' as CancerTreatmentStartDate,
        Record ->> '$.Gynaecological.GynaecologicalCore.GynaecologicalCoreTreatment.GynaecologicalCoreSurgeryAndOtherProcedures.ProcedureDate' as ProcedureDate,
        Record ->> '$.Gynaecological.GynaecologicalCore.GynaecologicalCoreCancerCarePlan.AdultComorbidityEvaluation.@code' as AdultComorbidityEvaluation
    from omop_staging.cosd_staging_81
    where type = 'GY'
)
select distinct
    NhsNumber,
    AdultComorbidityEvaluation,
    least(
        cast(DateFirstSeen as date),
        cast(SpecialistDateFirstSeen as date),
        cast(ClinicalDateCancerDiagnosis as date),
        cast(IntegratedStageTNMStageGroupingDate as date),
        cast(FinalPreTreatmentTNMStageGroupingDate as date),
        cast(CancerTreatmentStartDate as date),
        cast(ProcedureDate as date)
    ) as MeasurementDate
from gy
where AdultComorbidityEvaluation is not null
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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20value_as_number%20field%20COSD%20V8%20GY%20Measurement%20Adult%20Comorbidity%20Evaluation%20mapping){: .btn }
### COSD V8 CT Measurement Lactate Dehydrogenase Level Peak At Diagnosis
Source column  `LactateDehydrogenaseLevelPeakAtDiagnosis`.
Converts text to number.

* `LactateDehydrogenaseLevelPeakAtDiagnosis` Result of the clinical investigation measuring peak lactate dehydrogenase (LDH) at patient diagnosis during a cancer care spell. Unit of measurement is Units per litre (U/L). [LACTATE DEHYDROGENASE LEVEL (PEAK AT DIAGNOSIS)](https://www.datadictionary.nhs.uk/data_elements/lactate_dehydrogenase_level__peak_at_diagnosis_.html)

```sql
-- Query to extract Lactate Dehydrogenase Level (Peak at Diagnosis) for CT (CTYA) cancer area from COSD v8.
-- LactateDehydrogenaseLevelPeakAtDiagnosis is a numeric lab value (max n6) representing peak LDH at diagnosis in U/L.
-- MeasurementDate uses the primary diagnosis date.
-- LactateDehydrogenaseLevelPeakAtDiagnosis will be stored as value_as_number in OMOP in a later step, with unit U/L.
select distinct
    Record ->> '$.CTYA.CTYACore.CTYACoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
    Record ->> '$.CTYA.CTYACore.CTYACoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as MeasurementDate,
    Record ->> '$.CTYA.CTYACore.CTYACoreLaboratoryResultsGeneral.LactateDehydrogenaseLevelPeakAtDiagnosis.@value' as LactateDehydrogenaseLevelPeakAtDiagnosis
from omop_staging.cosd_staging_81
where type = 'CT'
  and LactateDehydrogenaseLevelPeakAtDiagnosis is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20value_as_number%20field%20COSD%20V8%20CT%20Measurement%20Lactate%20Dehydrogenase%20Level%20Peak%20At%20Diagnosis%20mapping){: .btn }
### COSD V8 CT Measurement Lactate Dehydrogenase Level Normal Upper Limit
Source column  `LactateDehydrogenaseLevelNormalUpperLimit`.
Converts text to number.

* `LactateDehydrogenaseLevelNormalUpperLimit` Upper limit of normal for lactate dehydrogenase (LDH), where the unit of measurement is Units per litre (U/L). [LACTATE DEHYDROGENASE LEVEL (NORMAL UPPER LIMIT)](https://www.datadictionary.nhs.uk/data_elements/lactate_dehydrogenase_level__normal_upper_limit_.html)

```sql
-- Query to extract Lactate Dehydrogenase Level (Normal Upper Limit) for CT (CTYA) cancer area from COSD v8.
-- LactateDehydrogenaseLevelNormalUpperLimit is a numeric lab value (max n6) representing the upper limit of normal LDH in U/L.
-- MeasurementDate uses the primary diagnosis date.
-- LactateDehydrogenaseLevelNormalUpperLimit will be stored as value_as_number in OMOP in a later step, with unit U/L.
select distinct
    Record ->> '$.CTYA.CTYACore.CTYACoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
    Record ->> '$.CTYA.CTYACore.CTYACoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as MeasurementDate,
    Record ->> '$.CTYA.CTYACore.CTYACoreLaboratoryResultsGeneral.LactateDehydrogenaseLevelNormalUpperLimit.@value' as LactateDehydrogenaseLevelNormalUpperLimit
from omop_staging.cosd_staging_81
where type = 'CT'
  and LactateDehydrogenaseLevelNormalUpperLimit is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20value_as_number%20field%20COSD%20V8%20CT%20Measurement%20Lactate%20Dehydrogenase%20Level%20Normal%20Upper%20Limit%20mapping){: .btn }
### COSD V8 CT Measurement Adult Comorbidity Evaluation
Source column  `AdultComorbidityEvaluation`.
Converts text to number.

* `AdultComorbidityEvaluation` The PERSON SCORE recorded during a Cancer Care Spell, where the ASSESSMENT TOOL is 'Adult Comorbidity Evaluation - 27'. [ADULT COMORBIDITY EVALUATION - 27 SCORE](https://www.datadictionary.nhs.uk/data_elements/adult_comorbidity_evaluation_-_27_score.html)

```sql
-- Query to extract Adult Comorbidity Evaluation for CT (CTYA) cancer area from COSD v8.
-- AdultComorbidityEvaluation is a categorical code (0-3, 9) from the ACE-27 assessment tool.
-- MeasurementDate is the earliest available date from referral, specialist, diagnosis, staging, treatment, or procedure dates.
-- AdultComorbidityEvaluation will be mapped to a measurement value concept in OMOP in a later step.
with CT as (
    select
        Record ->> '$.CTYA.CTYACore.CTYACoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
        Record ->> '$.CTYA.CTYACore.CTYACoreReferralAndFirstStageOfPatientPathway.DateFirstSeen' as DateFirstSeen,
        Record ->> '$.CTYA.CTYACore.CTYACoreReferralAndFirstStageOfPatientPathway.SpecialistDateFirstSeen' as SpecialistDateFirstSeen,
        Record ->> '$.CTYA.CTYACore.CTYACoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
        Record ->> '$.CTYA.CTYACore.CTYACoreStaging.IntegratedStageTNMStageGroupingDate' as IntegratedStageTNMStageGroupingDate,
        Record ->> '$.CTYA.CTYACore.CTYACoreStaging.FinalPreTreatmentTNMStageGroupingDate' as FinalPreTreatmentTNMStageGroupingDate,
        Record ->> '$.CTYA.CTYACore.CTYACoreTreatment.CancerTreatmentStartDate' as CancerTreatmentStartDate,
        Record ->> '$.CTYA.CTYACore.CTYACoreTreatment.CTYACoreSurgeryAndOtherProcedures.ProcedureDate' as ProcedureDate,
        Record ->> '$.CTYA.CTYACore.CTYACoreCancerCarePlan.AdultComorbidityEvaluation.@code' as AdultComorbidityEvaluation
    from omop_staging.cosd_staging_81
    where type = 'CT'
)
select distinct
    NhsNumber,
    AdultComorbidityEvaluation,
    least(
        cast(DateFirstSeen as date),
        cast(SpecialistDateFirstSeen as date),
        cast(ClinicalDateCancerDiagnosis as date),
        cast(IntegratedStageTNMStageGroupingDate as date),
        cast(FinalPreTreatmentTNMStageGroupingDate as date),
        cast(CancerTreatmentStartDate as date),
        cast(ProcedureDate as date)
    ) as MeasurementDate
from CT
where AdultComorbidityEvaluation is not null
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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20value_as_number%20field%20COSD%20V8%20CT%20Measurement%20Adult%20Comorbidity%20Evaluation%20mapping){: .btn }
### COSD v9 CR Measurement Adult Comorbidity Evaluation
Source column  `AdultComorbidityEvaluation`.
Converts text to number.

* `AdultComorbidityEvaluation` The PERSON SCORE recorded during a Cancer Care Spell, where the ASSESSMENT TOOL is 'Adult Comorbidity Evaluation - 27'. [ADULT COMORBIDITY EVALUATION - 27 SCORE](https://www.datadictionary.nhs.uk/data_elements/adult_comorbidity_evaluation_-_27_score.html)

```sql
with cr as (
	select
		Record ->> '$.PrimaryPathway.ReferralAndFirstStageOfPatientPathway.DateFirstSeen' as DateFirstSeen,
		Record ->> '$.PrimaryPathway.ReferralAndFirstStageOfPatientPathway.DateFirstSeenCancerSpecialist' as DateFirstSeenCancerSpecialist,
		Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed' as DateOfPrimaryDiagnosisClinicallyAgreed,
		Record ->> '$.PrimaryPathway.Staging.StageDateFinalPretreatmentStage' as StageDateFinalPretreatmentStage,
		Record ->> '$.PrimaryPathway.Staging.StageDateIntegratedStage' as StageDateIntegratedStage,
		coalesce(Record ->> '$.Treatment[0].TreatmentStartDateCancer', Record ->> '$.Treatment.TreatmentStartDateCancer') as TreatmentStartDateCancer,
		coalesce(Record ->> '$.Treatment[0].Surgery.ProcedureDate', Record ->> '$.Treatment.Surgery.ProcedureDate') as ProcedureDate,
		Record ->> '$."CancerCarePlan"."AdultComorbidityEvaluation-27Score"."@code"' as AdultComorbidityEvaluation,
		Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber
	from omop_staging.cosd_staging_901
	where type = 'CR'
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
		) as MeasurementDate
from cr
where AdultComorbidityEvaluation is not null
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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20value_as_number%20field%20COSD%20v9%20CR%20Measurement%20Adult%20Comorbidity%20Evaluation%20mapping){: .btn }
### COSD V8 CR Measurement Adult Comorbidity Evaluation
Source column  `AdultComorbidityEvaluation`.
Converts text to number.

* `AdultComorbidityEvaluation` The PERSON SCORE recorded during a Cancer Care Spell, where the ASSESSMENT TOOL is 'Adult Comorbidity Evaluation - 27'. [ADULT COMORBIDITY EVALUATION - 27 SCORE](https://www.datadictionary.nhs.uk/data_elements/adult_comorbidity_evaluation_-_27_score.html)

```sql
with cr as (
	select
		Record ->> '$.Core.CoreCore.CoreReferralAndFirstStageOfPatientPathway.DateFirstSeen' as DateFirstSeen,
		Record ->> '$.Core.CoreCore.CoreReferralAndFirstStageOfPatientPathway.SpecialistDateFirstSeen' as SpecialistDateFirstSeen,
		Record ->> '$.Core.CoreCore.CoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
		Record ->> '$.Core.CoreCore.CoreStaging.IntegratedStageTNMStageGroupingDate' as IntegratedStageTNMStageGroupingDate,
		Record ->> '$.Core.CoreCore.CoreStaging.FinalPreTreatmentTNMStageGroupingDate' as FinalPreTreatmentTNMStageGroupingDate,
		Record ->> '$.Core.CoreCore.CoreTreatment.CancerTreatmentStartDate' as CancerTreatmentStartDate,
		Record ->> '$.Core.CoreCore.CoreTreatment.CoreSurgeryAndOtherProcedures.ProcedureDate' as ProcedureDate,
		Record ->> '$.Core.CoreCore.CoreCancerPlan.AdultComorbidityEvaluation.@code' as AdultComorbidityEvaluation,
		Record ->> '$.Core.CoreCore.CoreLinkagePatientId.NHSNumber.@extension' as NhsNumber
	from omop_staging.cosd_staging_81
	where type = 'CR'
)
select
      distinct
          AdultComorbidityEvaluation,
          NhsNumber,
          least(
                cast(DateFirstSeen as date),
                cast(SpecialistDateFirstSeen as date),
                cast(ClinicalDateCancerDiagnosis as date),
                cast(IntegratedStageTNMStageGroupingDate as date),
                cast(FinalPreTreatmentTNMStageGroupingDate as date),
                cast(CancerTreatmentStartDate as date),
                cast(ProcedureDate as date)
              ) as MeasurementDate
from cr
where AdultComorbidityEvaluation is not null
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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20value_as_number%20field%20COSD%20V8%20CR%20Measurement%20Adult%20Comorbidity%20Evaluation%20mapping){: .btn }
### CosdV9MeasurementAdultComorbidityEvaluation
Source column  `AdultComorbidityEvaluation`.
Converts text to number.

* `AdultComorbidityEvaluation` The PERSON SCORE recorded during a Cancer Care Spell, where the ASSESSMENT TOOL is 'Adult Comorbidity Evaluation - 27'. [ADULT COMORBIDITY EVALUATION - 27 SCORE](https://www.datadictionary.nhs.uk/data_elements/adult_comorbidity_evaluation_-_27_score.html)

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
		Record ->> '$."CancerCarePlan"."AdultComorbidityEvaluation-27Score"."@code"' as AdultComorbidityEvaluation,
		Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber
	from omop_staging.cosd_staging_901
	where type = 'CO'
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
		) as MeasurementDate
from CO o
where o.AdultComorbidityEvaluation is not null
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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20value_as_number%20field%20CosdV9MeasurementAdultComorbidityEvaluation%20mapping){: .btn }
### COSD V8 Measurement Tumour Height Above Anal Verge
Source column  `TumourHeightAboveAnalVerge`.
Converts text to number.

* `TumourHeightAboveAnalVerge` Is the approximate height of the lower limit of the Tumour above the anal verge (as measured by a rigid sigmoidoscopy) during a Colorectal Cancer Care Spell, where the UNIT OF MEASUREMENT is 'Centimetres (cm)' [TUMOUR HEIGHT ABOVE ANAL VERGE](https://www.datadictionary.nhs.uk/data_elements/tumour_height_above_anal_verge.html)

```sql
with co as (
    select
        Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
        Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
        Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreDiagnosis.ColorectalDiagnosis.TumourHeightAboveAnalVerge.@value' as TumourHeightAboveAnalVerge
    from omop_staging.cosd_staging_81
    where Type = 'CO'
)
select distinct
    NhsNumber,
    ClinicalDateCancerDiagnosis,
    TumourHeightAboveAnalVerge
from co
where TumourHeightAboveAnalVerge is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20value_as_number%20field%20COSD%20V8%20Measurement%20Tumour%20Height%20Above%20Anal%20Verge%20mapping){: .btn }
### CosdV8MeasurementAdultComorbidityEvaluation
Source column  `AdultComorbidityEvaluation`.
Converts text to number.

* `AdultComorbidityEvaluation` The PERSON SCORE recorded during a Cancer Care Spell, where the ASSESSMENT TOOL is 'Adult Comorbidity Evaluation - 27'. [ADULT COMORBIDITY EVALUATION - 27 SCORE](https://www.datadictionary.nhs.uk/data_elements/adult_comorbidity_evaluation_-_27_score.html)

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
		Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreCancerCarePlan.AdultComorbidityEvaluation.@code' as AdultComorbidityEvaluation,
		Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber
	from omop_staging.cosd_staging_81
	where Type = 'CO'
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
              ) as MeasurementDate
from CO o
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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20value_as_number%20field%20CosdV8MeasurementAdultComorbidityEvaluation%20mapping){: .btn }
### CosdV9BreastMeasurementAdultComorbidityEvaluation
Source column  `AdultComorbidityEvaluation`.
Converts text to number.

* `AdultComorbidityEvaluation` Adult Comorbidity Evaluation Score [AdultComorbidityEvaluation-27Score]()

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
        -- Quoting used to handle the hyphen in the field name safely
        Record ->> '$."CancerCarePlan"."AdultComorbidityEvaluation-27Score"."@code"' as AdultComorbidityEvaluation,
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber
    from omop_staging.cosd_staging_901
    where type = 'BR'
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
        ) as MeasurementDate
from BR o
where o.AdultComorbidityEvaluation is not null
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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20value_as_number%20field%20CosdV9BreastMeasurementAdultComorbidityEvaluation%20mapping){: .btn }
### CosdV8BreastMeasurementAdultComorbidityEvaluation
Source column  `AdultComorbidityEvaluation`.
Converts text to number.

* `AdultComorbidityEvaluation` Adult Comorbidity Evaluation-27 score indicating the severity of comorbid conditions [ADULT COMORBIDITY EVALUATION-27 SCORE]()

```sql
with BR as (
    select 
        Record ->> '$.Breast.BreastCore.BreastCoreReferralAndFirstStageOfPatientPathway.DateFirstSeen' as DateFirstSeen,
        Record ->> '$.Breast.BreastCore.BreastCoreReferralAndFirstStageOfPatientPathway.DateFirstSeenCancerSpecialist' as DateFirstSeenCancerSpecialist,
        Record ->> '$.Breast.BreastCore.BreastCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
        Record ->> '$.Breast.BreastCore.BreastCoreStaging.IntegratedStageTNMStageGroupingDate' as IntegratedStageTNMStageGroupingDate,
        Record ->> '$.Breast.BreastCore.BreastCoreStaging.FinalPreTreatmentTNMStageGroupingDate' as FinalPreTreatmentTNMStageGroupingDate,
        Record ->> '$.Breast.BreastCore.BreastCoreTreatment.CancerTreatmentStartDate' as CancerTreatmentStartDate,
        Record ->> '$.Breast.BreastCore.BreastCoreTreatment.BreastCoreSurgeryAndOtherProcedures.ProcedureDate' as ProcedureDate,
        Record ->> '$.Breast.BreastCore.BreastCoreCancerCarePlan.AdultComorbidityEvaluation.@code' as AdultComorbidityEvaluation,
        Record ->> '$.Breast.BreastCore.BreastCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber
    from omop_staging.cosd_staging_81
    where Type = 'BR'
)
select
      distinct
          AdultComorbidityEvaluation,
          NhsNumber,
          least(
                cast (DateFirstSeen as date),
                cast (DateFirstSeenCancerSpecialist as date),
                cast (ClinicalDateCancerDiagnosis as date),
                cast (IntegratedStageTNMStageGroupingDate as date),
                cast (FinalPreTreatmentTNMStageGroupingDate as date),
                cast (CancerTreatmentStartDate as date),
                cast (ProcedureDate as date)
              ) as MeasurementDate
from BR o
where o.AdultComorbidityEvaluation is not null
  and not (
        DateFirstSeen is null and
        DateFirstSeenCancerSpecialist is null and
        ClinicalDateCancerDiagnosis is null and
        IntegratedStageTNMStageGroupingDate is null and
        FinalPreTreatmentTNMStageGroupingDate is null and
        CancerTreatmentStartDate is null and
        ProcedureDate is null
    );
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20value_as_number%20field%20CosdV8BreastMeasurementAdultComorbidityEvaluation%20mapping){: .btn }
### COSD V8 BA Measurement Adult Comorbidity Evaluation
Source column  `AdultComorbidityEvaluation`.
Converts text to number.

* `AdultComorbidityEvaluation` The PERSON SCORE recorded during a Cancer Care Spell, where the ASSESSMENT TOOL is 'Adult Comorbidity Evaluation - 27'. [ADULT COMORBIDITY EVALUATION - 27 SCORE](https://www.datadictionary.nhs.uk/data_elements/adult_comorbidity_evaluation_-_27_score.html)

```sql
with BA as (
    select
        Record ->> '$.CNS.CNSCore.CNSCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
        Record ->> '$.CNS.CNSCore.CNSCoreReferralAndFirstStageOfPatientPathway.DateFirstSeen' as DateFirstSeen,
        Record ->> '$.CNS.CNSCore.CNSCoreReferralAndFirstStageOfPatientPathway.SpecialistDateFirstSeen' as SpecialistDateFirstSeen,
        Record ->> '$.CNS.CNSCore.CNSCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as ClinicalDateCancerDiagnosis,
        Record ->> '$.CNS.CNSCore.CNSCoreTreatment.CancerTreatmentStartDate' as CancerTreatmentStartDate,
        Record ->> '$.CNS.CNSCore.CNSCoreTreatment.CNSCoreSurgeryAndOtherProcedures.ProcedureDate' as ProcedureDate,
        Record ->> '$.CNS.CNSCore.CNSCoreCancerCarePlan.AdultComorbidityEvaluation.@code' as AdultComorbidityEvaluation
    from omop_staging.cosd_staging_81
    where type = 'BA'
)
select distinct
    NhsNumber,
    AdultComorbidityEvaluation,
    least(
        cast(DateFirstSeen as date),
        cast(SpecialistDateFirstSeen as date),
        cast(ClinicalDateCancerDiagnosis as date),
        cast(CancerTreatmentStartDate as date),
        cast(ProcedureDate as date)
    ) as MeasurementDate
from BA
where AdultComorbidityEvaluation is not null
  and not (
      DateFirstSeen is null and
      SpecialistDateFirstSeen is null and
      ClinicalDateCancerDiagnosis is null and
      CancerTreatmentStartDate is null and
      ProcedureDate is null
  );
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Measurement%20table%20value_as_number%20field%20COSD%20V8%20BA%20Measurement%20Adult%20Comorbidity%20Evaluation%20mapping){: .btn }
