---
layout: default
title: value_as_concept_id
parent: Observation
grand_parent: Transformation Documentation
has_toc: false
---
# value_as_concept_id
### SACT Adjunctive Therapy Type
Source column  `Adjunctive_Therapy`.
The Adjunctive Therapy Type of the DRUG used for each Systemic Anti-Cancer Therapy Drug Administration in a Systemic Anti-Cancer Therapy Drug Cycle.


|Adjunctive_Therapy|value_as_concept_id|notes|
|------|-----|-----|
|1|4191637|Adjuvant - intent|
|2|4161587|Neoadjuvant intent|
|3|0|Not Applicable (Primary Treatment)|
|9|0|Not Known (Not Recorded)|

Notes
* [SACT ADJUNCTIVE THERAPY TYPE](https://archive.datadictionary.nhs.uk/DD%20Release%20May%202024/data_elements/adjunctive_therapy_type.html)
* [OMOP](https://athena.ohdsi.org/search-terms/terms/4194400)

* `Adjunctive_Therapy` The type of Adjunctive Therapy  given to a PATIENT  during a Cancer Care Spell. [ADJUNCTIVE THERAPY TYPE](https://www.datadictionary.nhs.uk/data_elements/adjunctive_therapy_type.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_as_concept_id%20field%20SACT%20Adjunctive%20Therapy%20Type%20mapping){: .btn }
### SACT Administration Route
Source column  `Administration_Route`.
The ADMINISTRATION ROUTE of the DRUG used for each Systemic Anti-Cancer Therapy Drug Administration in a Systemic Anti-Cancer Therapy Drug Cycle.


|Administration_Route|value_as_concept_id|notes|
|------|-----|-----|
|1|40492287|Intravascular|
|2|4186839|Oromucosal|
|3|4302788|Intraspinal|
|4|4302612|Intramuscular|
|5|4142048|Subcutaneous|
|6|40492287|Intravascular|
|7|4304882|Intraabdominal|
|8|4157757|Intracavernous|
|9|40492302|Intracorporus cavernosum of penis route|
|11|4263689|Topical|
|12|4156706|Intradermal|
|13|40491322|Intratumor|
|14|4157758|Intralesional|
|98|0||

Notes
* [SACT Drug Route of Administration](https://archive.datadictionary.nhs.uk/DD%20Release%20May%202024/data_elements/systemic_anti-cancer_therapy_drug_route_of_administration.html)
* [OMOP](https://athena.ohdsi.org/search-terms/terms/4106215)

* `Administration_Route` The prescribed route of administration for each Systemic Anti-Cancer Therapy Drug Administration in a Systemic Anti-Cancer Therapy Drug Cycle. [SYSTEMIC ANTI-CANCER THERAPY DRUG ROUTE OF ADMINISTRATION](https://www.datadictionary.nhs.uk/data_elements/systemic_anti-cancer_therapy_drug_route_of_administration.html)

```sql
		select
		distinct
  			replace(NHS_Number, ' ', '') as NHSNumber,
      		SACT_Administration_Route as Administration_Route,
		  	Administration_Date
	from omop_staging.sact_staging
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_as_concept_id%20field%20SACT%20Administration%20Route%20mapping){: .btn }
### SACT Treatment Intent
Source column  `Intent_Of_Treatment`.
The Regimen Treatment Intent of the DRUG used for each Systemic Anti-Cancer Therapy Drug Administration in a Systemic Anti-Cancer Therapy Drug Cycle.


|Intent_Of_Treatment|value_as_concept_id|notes|
|------|-----|-----|
|1|4162591|Curative|
|2|4179711|Palliative|
|3|4179711|Palliative|
|4|4179711|Palliative|
|5|4179711|Palliative|
|98|0|Other (not listed)|
|99|0|Other (not listed)|

Notes
* [SACT Drug Regimen Treatment Intent](https://archive.datadictionary.nhs.uk/DD%20Release%20May%202024/attributes/systemic_anti-cancer_therapy_drug_regimen_treatment_intent.html)
* [OMOP](https://athena.ohdsi.org/search-terms/terms/4194400)

* `Intent_Of_Treatment` The intent of the Systemic Anti-Cancer Therapy Drug Regimen. [SYSTEMIC ANTI-CANCER THERAPY DRUG REGIMEN TREATMENT INTENT](https://www.datadictionary.nhs.uk/data_elements/systemic_anti-cancer_therapy_drug_regimen_treatment_intent.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_as_concept_id%20field%20SACT%20Treatment%20Intent%20mapping){: .btn }
### RTDS Treatment Anatomical Site
* Value copied from `AnatomicalSiteConceptId`

* `AnatomicalSiteConceptId` CONCEPT ID OF ANATOMIC SITE OF RADIOTHERAPY PROCEDURE 

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_as_concept_id%20field%20RTDS%20Treatment%20Anatomical%20Site%20mapping){: .btn }
### COSD V9 UR Observation Smoking Status Cancer
Source column  `SmokingStatusCancer`.
SMOKING STATUS (CANCER)


|SmokingStatusCancer|value_as_concept_id|notes|
|------|-----|-----|
|1|903657|Current smoker|
|2|903651|Ex-smoker|
|4|903653|Never smoked|
|9|0|Unknown (Not Recorded)|


* `SmokingStatusCancer` Used in the Cancer Outcomes and Services Data Set: Core to identify if the patient smokes tobacco only. [SMOKING STATUS (CANCER)](https://www.datadictionary.nhs.uk/data_elements/smoking_status__cancer_.html)

```sql
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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_as_concept_id%20field%20COSD%20V9%20UR%20Observation%20Smoking%20Status%20Cancer%20mapping){: .btn }
### COSD V9 UR Observation Alcohol History Cancer In Last Three Months
Source column  `AlcoholHistoryCancerInLastThreeMonths`.
ALCOHOL HISTORY (CANCER IN LAST THREE MONTHS)


|AlcoholHistoryCancerInLastThreeMonths|value_as_concept_id|notes|
|------|-----|-----|
|1|4336673|Heavy (greater than 14 units per week)|
|2|4042862|Light (less than or equal to 14 units per week)|
|3|105542008|None ever|
|Z|0|Not Stated (patient asked but declined to provide a response)|
|9|0|Not Known (Not Recorded)|


* `AlcoholHistoryCancerInLastThreeMonths` Recent history of alcohol consumption for the patient during a cancer care spell. [ALCOHOL HISTORY (CANCER IN LAST THREE MONTHS)](https://www.datadictionary.nhs.uk/data_elements/alcohol_history__cancer_in_last_three_months_.html)

```sql
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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_as_concept_id%20field%20COSD%20V9%20UR%20Observation%20Alcohol%20History%20Cancer%20In%20Last%20Three%20Months%20mapping){: .btn }
### COSD V9 UR Observation Alcohol History Cancer Before Last Three Months
Source column  `AlcoholHistoryCancerBeforeLastThreeMonths`.
ALCOHOL HISTORY (CANCER BEFORE LAST THREE MONTHS)


|AlcoholHistoryCancerBeforeLastThreeMonths|value_as_concept_id|notes|
|------|-----|-----|
|1|4336673|Heavy (greater than 14 units per week)|
|2|4042862|Light (less than or equal to 14 units per week)|
|3|4022664|None ever|
|Z|0|Not Stated (patient asked but declined to provide a response)|
|9|0|Not Known (Not Recorded)|


* `AlcoholHistoryCancerBeforeLastThreeMonths` Past history of alcohol consumption for the patient during a cancer care spell. [ALCOHOL HISTORY (CANCER BEFORE LAST THREE MONTHS)](https://www.datadictionary.nhs.uk/data_elements/alcohol_history__cancer_before_last_three_months_.html)

```sql
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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_as_concept_id%20field%20COSD%20V9%20UR%20Observation%20Alcohol%20History%20Cancer%20Before%20Last%20Three%20Months%20mapping){: .btn }
### COSD V8 UR Observation Smoking Status Cancer
Source column  `SmokingStatusCancer`.
SMOKING STATUS (CANCER)


|SmokingStatusCancer|value_as_concept_id|notes|
|------|-----|-----|
|1|903657|Current smoker|
|2|903651|Ex-smoker|
|4|903653|Never smoked|
|9|0|Unknown (Not Recorded)|


* `SmokingStatusCancer` Used in the Cancer Outcomes and Services Data Set: Core to identify if the patient smokes tobacco only. [SMOKING STATUS (CANCER)](https://www.datadictionary.nhs.uk/data_elements/smoking_status__cancer_.html)

```sql
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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_as_concept_id%20field%20COSD%20V8%20UR%20Observation%20Smoking%20Status%20Cancer%20mapping){: .btn }
### COSD V8 UR Observation Person Stated Sexual Orientation Code At Diagnosis
Source column  `PersonStatedSexualOrientationCodeAtDiagnosis`.
PERSON STATED SEXUAL ORIENTATION CODE (AT DIAGNOSIS)


|PersonStatedSexualOrientationCodeAtDiagnosis|value_as_concept_id|notes|
|------|-----|-----|
|1|4069091|Heterosexual or Straight|
|2|444056|Gay or Lesbian|
|3|4170582|Bisexual|
|4|4260977|Other sexual orientation not listed|
|U|42689512|Person asked and does not know or is not sure|
|Z|4260977|Not Stated (person asked but declined to provide a response)|
|9|4260977|Not Known (Not Recorded)|


* `PersonStatedSexualOrientationCodeAtDiagnosis` The sexual orientation as self-stated by the person at the point of cancer diagnosis. [PERSON STATED SEXUAL ORIENTATION CODE (AT DIAGNOSIS)](https://www.datadictionary.nhs.uk/data_elements/person_stated_sexual_orientation_code__at_diagnosis_.html)

```sql
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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_as_concept_id%20field%20COSD%20V8%20UR%20Observation%20Person%20Stated%20Sexual%20Orientation%20Code%20At%20Diagnosis%20mapping){: .btn }
### COSD V8 UR Observation Alcohol History Cancer In Last Three Months
Source column  `AlcoholHistoryCancerInLastThreeMonths`.
ALCOHOL HISTORY (CANCER IN LAST THREE MONTHS)


|AlcoholHistoryCancerInLastThreeMonths|value_as_concept_id|notes|
|------|-----|-----|
|1|4336673|Heavy (greater than 14 units per week)|
|2|4042862|Light (less than or equal to 14 units per week)|
|3|105542008|None ever|
|Z|0|Not Stated (patient asked but declined to provide a response)|
|9|0|Not Known (Not Recorded)|


* `AlcoholHistoryCancerInLastThreeMonths` Recent history of alcohol consumption for the patient during a cancer care spell. [ALCOHOL HISTORY (CANCER IN LAST THREE MONTHS)](https://www.datadictionary.nhs.uk/data_elements/alcohol_history__cancer_in_last_three_months_.html)

```sql
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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_as_concept_id%20field%20COSD%20V8%20UR%20Observation%20Alcohol%20History%20Cancer%20In%20Last%20Three%20Months%20mapping){: .btn }
### COSD V8 UR Observation Alcohol History Cancer Before Last Three Months
Source column  `AlcoholHistoryCancerBeforeLastThreeMonths`.
ALCOHOL HISTORY (CANCER BEFORE LAST THREE MONTHS)


|AlcoholHistoryCancerBeforeLastThreeMonths|value_as_concept_id|notes|
|------|-----|-----|
|1|4336673|Heavy (greater than 14 units per week)|
|2|4042862|Light (less than or equal to 14 units per week)|
|3|4022664|None ever|
|Z|0|Not Stated (patient asked but declined to provide a response)|
|9|0|Not Known (Not Recorded)|


* `AlcoholHistoryCancerBeforeLastThreeMonths` Past history of alcohol consumption for the patient during a cancer care spell. [ALCOHOL HISTORY (CANCER BEFORE LAST THREE MONTHS)](https://www.datadictionary.nhs.uk/data_elements/alcohol_history__cancer_before_last_three_months_.html)

```sql
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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_as_concept_id%20field%20COSD%20V8%20UR%20Observation%20Alcohol%20History%20Cancer%20Before%20Last%20Three%20Months%20mapping){: .btn }
### COSD V9 UG Observation Smoking Status Cancer
Source column  `SmokingStatusCancer`.
SMOKING STATUS (CANCER)


|SmokingStatusCancer|value_as_concept_id|notes|
|------|-----|-----|
|1|903657|Current smoker|
|2|903651|Ex-smoker|
|4|903653|Never smoked|
|9|0|Unknown (Not Recorded)|


* `SmokingStatusCancer` Used in the Cancer Outcomes and Services Data Set: Core to identify if the patient smokes tobacco only. [SMOKING STATUS (CANCER)](https://www.datadictionary.nhs.uk/data_elements/smoking_status__cancer_.html)

```sql
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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_as_concept_id%20field%20COSD%20V9%20UG%20Observation%20Smoking%20Status%20Cancer%20mapping){: .btn }
### COSD V9 UG Observation Alcohol History Cancer In Last Three Months
Source column  `AlcoholHistoryCancerInLastThreeMonths`.
ALCOHOL HISTORY (CANCER IN LAST THREE MONTHS)


|AlcoholHistoryCancerInLastThreeMonths|value_as_concept_id|notes|
|------|-----|-----|
|1|4336673|Heavy (greater than 14 units per week)|
|2|4042862|Light (less than or equal to 14 units per week)|
|3|105542008|None ever|
|Z|0|Not Stated (patient asked but declined to provide a response)|
|9|0|Not Known (Not Recorded)|


* `AlcoholHistoryCancerInLastThreeMonths` Recent history of alcohol consumption for the patient during a cancer care spell. [ALCOHOL HISTORY (CANCER IN LAST THREE MONTHS)](https://www.datadictionary.nhs.uk/data_elements/alcohol_history__cancer_in_last_three_months_.html)

```sql
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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_as_concept_id%20field%20COSD%20V9%20UG%20Observation%20Alcohol%20History%20Cancer%20In%20Last%20Three%20Months%20mapping){: .btn }
### COSD V9 UG Observation Alcohol History Cancer Before Last Three Months
Source column  `AlcoholHistoryCancerBeforeLastThreeMonths`.
ALCOHOL HISTORY (CANCER BEFORE LAST THREE MONTHS)


|AlcoholHistoryCancerBeforeLastThreeMonths|value_as_concept_id|notes|
|------|-----|-----|
|1|4336673|Heavy (greater than 14 units per week)|
|2|4042862|Light (less than or equal to 14 units per week)|
|3|4022664|None ever|
|Z|0|Not Stated (patient asked but declined to provide a response)|
|9|0|Not Known (Not Recorded)|


* `AlcoholHistoryCancerBeforeLastThreeMonths` Past history of alcohol consumption for the patient during a cancer care spell. [ALCOHOL HISTORY (CANCER BEFORE LAST THREE MONTHS)](https://www.datadictionary.nhs.uk/data_elements/alcohol_history__cancer_before_last_three_months_.html)

```sql
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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_as_concept_id%20field%20COSD%20V9%20UG%20Observation%20Alcohol%20History%20Cancer%20Before%20Last%20Three%20Months%20mapping){: .btn }
### COSD V8 UG Observation Smoking Status Cancer
Source column  `SmokingStatusCancer`.
SMOKING STATUS (CANCER)


|SmokingStatusCancer|value_as_concept_id|notes|
|------|-----|-----|
|1|903657|Current smoker|
|2|903651|Ex-smoker|
|4|903653|Never smoked|
|9|0|Unknown (Not Recorded)|


* `SmokingStatusCancer` Used in the Cancer Outcomes and Services Data Set: Core to identify if the patient smokes tobacco only. [SMOKING STATUS (CANCER)](https://www.datadictionary.nhs.uk/data_elements/smoking_status__cancer_.html)

```sql
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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_as_concept_id%20field%20COSD%20V8%20UG%20Observation%20Smoking%20Status%20Cancer%20mapping){: .btn }
### COSD V8 UG Observation Alcohol History Cancer In Last Three Months
Source column  `AlcoholHistoryCancerInLastThreeMonths`.
ALCOHOL HISTORY (CANCER IN LAST THREE MONTHS)


|AlcoholHistoryCancerInLastThreeMonths|value_as_concept_id|notes|
|------|-----|-----|
|1|4336673|Heavy (greater than 14 units per week)|
|2|4042862|Light (less than or equal to 14 units per week)|
|3|105542008|None ever|
|Z|0|Not Stated (patient asked but declined to provide a response)|
|9|0|Not Known (Not Recorded)|


* `AlcoholHistoryCancerInLastThreeMonths` Recent history of alcohol consumption for the patient during a cancer care spell. [ALCOHOL HISTORY (CANCER IN LAST THREE MONTHS)](https://www.datadictionary.nhs.uk/data_elements/alcohol_history__cancer_in_last_three_months_.html)

```sql
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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_as_concept_id%20field%20COSD%20V8%20UG%20Observation%20Alcohol%20History%20Cancer%20In%20Last%20Three%20Months%20mapping){: .btn }
### COSD V8 UG Observation Alcohol History Cancer Before Last Three Months
Source column  `AlcoholHistoryCancerBeforeLastThreeMonths`.
ALCOHOL HISTORY (CANCER BEFORE LAST THREE MONTHS)


|AlcoholHistoryCancerBeforeLastThreeMonths|value_as_concept_id|notes|
|------|-----|-----|
|1|4336673|Heavy (greater than 14 units per week)|
|2|4042862|Light (less than or equal to 14 units per week)|
|3|4022664|None ever|
|Z|0|Not Stated (patient asked but declined to provide a response)|
|9|0|Not Known (Not Recorded)|


* `AlcoholHistoryCancerBeforeLastThreeMonths` Past history of alcohol consumption for the patient during a cancer care spell. [ALCOHOL HISTORY (CANCER BEFORE LAST THREE MONTHS)](https://www.datadictionary.nhs.uk/data_elements/alcohol_history__cancer_before_last_three_months_.html)

```sql
select distinct
    Record ->> '$.UpperGI.UpperGICore.UpperGICoreLinkagePatientId.NHSNumber.@extension'
        as NhsNumber,
    Record ->> '$.UpperGI.UpperGICore.UpperGICoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    Record ->> '$.UpperGI.UpperGICore.UpperGICoreClinicalNurseSpecialistAndRiskFactorAssessments.AlcoholHistoryCancerBeforeLastThreeMonths.@code'
        as AlcoholHistoryCancerBeforeLastThreeMonths
from omop_staging.cosd_staging_81
where type = 'UG'
  and NhsNumber is not null
  and AlcoholHistoryCancerBeforeLastThreeMonths is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_as_concept_id%20field%20COSD%20V8%20UG%20Observation%20Alcohol%20History%20Cancer%20Before%20Last%20Three%20Months%20mapping){: .btn }
### COSD V9 SK Observation Smoking Status Cancer
Source column  `SmokingStatusCancer`.
SMOKING STATUS (CANCER)


|SmokingStatusCancer|value_as_concept_id|notes|
|------|-----|-----|
|1|903657|Current smoker|
|2|903651|Ex-smoker|
|4|903653|Never smoked|
|9|0|Unknown (Not Recorded)|


* `SmokingStatusCancer` Used in the Cancer Outcomes and Services Data Set: Core to identify if the patient smokes tobacco only. [SMOKING STATUS (CANCER)](https://www.datadictionary.nhs.uk/data_elements/smoking_status__cancer_.html)

```sql
select distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension'
        as NhsNumber,
    Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    Record ->> '$.ClinicalNurseSpecialistAndRiskFactorAssessments.TobaccoSmokingStatus.@code'
        as SmokingStatusCancer
from omop_staging.cosd_staging_901
where type = 'SK'
  and NhsNumber is not null
  and SmokingStatusCancer is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_as_concept_id%20field%20COSD%20V9%20SK%20Observation%20Smoking%20Status%20Cancer%20mapping){: .btn }
### COSD V9 SK Observation Alcohol History Cancer In Last Three Months
Source column  `AlcoholHistoryCancerInLastThreeMonths`.
ALCOHOL HISTORY (CANCER IN LAST THREE MONTHS)


|AlcoholHistoryCancerInLastThreeMonths|value_as_concept_id|notes|
|------|-----|-----|
|1|4336673|Heavy (greater than 14 units per week)|
|2|4042862|Light (less than or equal to 14 units per week)|
|3|105542008|None ever|
|Z|0|Not Stated (patient asked but declined to provide a response)|
|9|0|Not Known (Not Recorded)|


* `AlcoholHistoryCancerInLastThreeMonths` Recent history of alcohol consumption for the patient during a cancer care spell. [ALCOHOL HISTORY (CANCER IN LAST THREE MONTHS)](https://www.datadictionary.nhs.uk/data_elements/alcohol_history__cancer_in_last_three_months_.html)

```sql
select distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension'
        as NhsNumber,
    Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    Record ->> '$.ClinicalNurseSpecialistAndRiskFactorAssessments.HistoryOfAlcoholCurrent.@code'
        as AlcoholHistoryCancerInLastThreeMonths
from omop_staging.cosd_staging_901
where type = 'SK'
  and NhsNumber is not null
  and AlcoholHistoryCancerInLastThreeMonths is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_as_concept_id%20field%20COSD%20V9%20SK%20Observation%20Alcohol%20History%20Cancer%20In%20Last%20Three%20Months%20mapping){: .btn }
### COSD V9 SK Observation Alcohol History Cancer Before Last Three Months
Source column  `AlcoholHistoryCancerBeforeLastThreeMonths`.
ALCOHOL HISTORY (CANCER BEFORE LAST THREE MONTHS)


|AlcoholHistoryCancerBeforeLastThreeMonths|value_as_concept_id|notes|
|------|-----|-----|
|1|4336673|Heavy (greater than 14 units per week)|
|2|4042862|Light (less than or equal to 14 units per week)|
|3|4022664|None ever|
|Z|0|Not Stated (patient asked but declined to provide a response)|
|9|0|Not Known (Not Recorded)|


* `AlcoholHistoryCancerBeforeLastThreeMonths` Past history of alcohol consumption for the patient during a cancer care spell. [ALCOHOL HISTORY (CANCER BEFORE LAST THREE MONTHS)](https://www.datadictionary.nhs.uk/data_elements/alcohol_history__cancer_before_last_three_months_.html)

```sql
select distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension'
        as NhsNumber,
    Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    Record ->> '$.ClinicalNurseSpecialistAndRiskFactorAssessments.HistoryOfAlcoholPast.@code'
        as AlcoholHistoryCancerBeforeLastThreeMonths
from omop_staging.cosd_staging_901
where type = 'SK'
  and NhsNumber is not null
  and AlcoholHistoryCancerBeforeLastThreeMonths is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_as_concept_id%20field%20COSD%20V9%20SK%20Observation%20Alcohol%20History%20Cancer%20Before%20Last%20Three%20Months%20mapping){: .btn }
### COSD V8 SK Observation Smoking Status Cancer
Source column  `SmokingStatusCancer`.
SMOKING STATUS (CANCER)


|SmokingStatusCancer|value_as_concept_id|notes|
|------|-----|-----|
|1|903657|Current smoker|
|2|903651|Ex-smoker|
|4|903653|Never smoked|
|9|0|Unknown (Not Recorded)|


* `SmokingStatusCancer` Used in the Cancer Outcomes and Services Data Set: Core to identify if the patient smokes tobacco only. [SMOKING STATUS (CANCER)](https://www.datadictionary.nhs.uk/data_elements/smoking_status__cancer_.html)

```sql
select distinct
    Record ->> '$.Skin.SkinCore.SkinCoreLinkagePatientId.NHSNumber.@extension'
        as NhsNumber,
    Record ->> '$.Skin.SkinCore.SkinCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    Record ->> '$.Skin.SkinCore.SkinCoreClinicalNurseSpecialistAndRiskFactorAssessments.SmokingStatusCode.@code'
        as SmokingStatusCancer
from omop_staging.cosd_staging_81
where type = 'SK'
  and NhsNumber is not null
  and SmokingStatusCancer is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_as_concept_id%20field%20COSD%20V8%20SK%20Observation%20Smoking%20Status%20Cancer%20mapping){: .btn }
### COSD V8 SK Observation Alcohol History Cancer In Last Three Months
Source column  `AlcoholHistoryCancerInLastThreeMonths`.
ALCOHOL HISTORY (CANCER IN LAST THREE MONTHS)


|AlcoholHistoryCancerInLastThreeMonths|value_as_concept_id|notes|
|------|-----|-----|
|1|4336673|Heavy (greater than 14 units per week)|
|2|4042862|Light (less than or equal to 14 units per week)|
|3|105542008|None ever|
|Z|0|Not Stated (patient asked but declined to provide a response)|
|9|0|Not Known (Not Recorded)|


* `AlcoholHistoryCancerInLastThreeMonths` Recent history of alcohol consumption for the patient during a cancer care spell. [ALCOHOL HISTORY (CANCER IN LAST THREE MONTHS)](https://www.datadictionary.nhs.uk/data_elements/alcohol_history__cancer_in_last_three_months_.html)

```sql
select distinct
    Record ->> '$.Skin.SkinCore.SkinCoreLinkagePatientId.NHSNumber.@extension'
        as NhsNumber,
    Record ->> '$.Skin.SkinCore.SkinCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    Record ->> '$.Skin.SkinCore.SkinCoreClinicalNurseSpecialistAndRiskFactorAssessments.AlcoholHistoryCancerInLastThreeMonths.@code'
        as AlcoholHistoryCancerInLastThreeMonths
from omop_staging.cosd_staging_81
where type = 'SK'
  and NhsNumber is not null
  and AlcoholHistoryCancerInLastThreeMonths is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_as_concept_id%20field%20COSD%20V8%20SK%20Observation%20Alcohol%20History%20Cancer%20In%20Last%20Three%20Months%20mapping){: .btn }
### COSD V8 SK Observation Alcohol History Cancer Before Last Three Months
Source column  `AlcoholHistoryCancerBeforeLastThreeMonths`.
ALCOHOL HISTORY (CANCER BEFORE LAST THREE MONTHS)


|AlcoholHistoryCancerBeforeLastThreeMonths|value_as_concept_id|notes|
|------|-----|-----|
|1|4336673|Heavy (greater than 14 units per week)|
|2|4042862|Light (less than or equal to 14 units per week)|
|3|4022664|None ever|
|Z|0|Not Stated (patient asked but declined to provide a response)|
|9|0|Not Known (Not Recorded)|


* `AlcoholHistoryCancerBeforeLastThreeMonths` Past history of alcohol consumption for the patient during a cancer care spell. [ALCOHOL HISTORY (CANCER BEFORE LAST THREE MONTHS)](https://www.datadictionary.nhs.uk/data_elements/alcohol_history__cancer_before_last_three_months_.html)

```sql
select distinct
    Record ->> '$.Skin.SkinCore.SkinCoreLinkagePatientId.NHSNumber.@extension'
        as NhsNumber,
    Record ->> '$.Skin.SkinCore.SkinCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    Record ->> '$.Skin.SkinCore.SkinCoreClinicalNurseSpecialistAndRiskFactorAssessments.AlcoholHistoryCancerBeforeLastThreeMonths.@code'
        as AlcoholHistoryCancerBeforeLastThreeMonths
from omop_staging.cosd_staging_81
where type = 'SK'
  and NhsNumber is not null
  and AlcoholHistoryCancerBeforeLastThreeMonths is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_as_concept_id%20field%20COSD%20V8%20SK%20Observation%20Alcohol%20History%20Cancer%20Before%20Last%20Three%20Months%20mapping){: .btn }
### COSD V9 SA Observation Smoking Status Cancer
Source column  `SmokingStatusCancer`.
SMOKING STATUS (CANCER)


|SmokingStatusCancer|value_as_concept_id|notes|
|------|-----|-----|
|1|903657|Current smoker|
|2|903651|Ex-smoker|
|4|903653|Never smoked|
|9|0|Unknown (Not Recorded)|


* `SmokingStatusCancer` Used in the Cancer Outcomes and Services Data Set: Core to identify if the patient smokes tobacco only. [SMOKING STATUS (CANCER)](https://www.datadictionary.nhs.uk/data_elements/smoking_status__cancer_.html)

```sql
select distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension'
        as NhsNumber,
    Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    Record ->> '$.ClinicalNurseSpecialistAndRiskFactorAssessments.TobaccoSmokingStatus.@code'
        as SmokingStatusCancer
from omop_staging.cosd_staging_901
where type = 'SA'
  and NhsNumber is not null
  and SmokingStatusCancer is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_as_concept_id%20field%20COSD%20V9%20SA%20Observation%20Smoking%20Status%20Cancer%20mapping){: .btn }
### COSD V9 SA Observation Alcohol History Cancer In Last Three Months
Source column  `AlcoholHistoryCancerInLastThreeMonths`.
ALCOHOL HISTORY (CANCER IN LAST THREE MONTHS)


|AlcoholHistoryCancerInLastThreeMonths|value_as_concept_id|notes|
|------|-----|-----|
|1|4336673|Heavy (greater than 14 units per week)|
|2|4042862|Light (less than or equal to 14 units per week)|
|3|105542008|None ever|
|Z|0|Not Stated (patient asked but declined to provide a response)|
|9|0|Not Known (Not Recorded)|


* `AlcoholHistoryCancerInLastThreeMonths` Current history of alcohol consumption for the patient during a cancer care spell. [ALCOHOL HISTORY (CANCER IN LAST THREE MONTHS)](https://www.datadictionary.nhs.uk/data_elements/alcohol_history__cancer_in_last_three_months_.html)

```sql
select distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension'
        as NhsNumber,
    Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    Record ->> '$.ClinicalNurseSpecialistAndRiskFactorAssessments.HistoryOfAlcoholCurrent.@code'
        as AlcoholHistoryCancerInLastThreeMonths
from omop_staging.cosd_staging_901
where type = 'SA'
  and NhsNumber is not null
  and AlcoholHistoryCancerInLastThreeMonths is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_as_concept_id%20field%20COSD%20V9%20SA%20Observation%20Alcohol%20History%20Cancer%20In%20Last%20Three%20Months%20mapping){: .btn }
### COSD V9 SA Observation Alcohol History Cancer Before Last Three Months
Source column  `AlcoholHistoryCancerBeforeLastThreeMonths`.
ALCOHOL HISTORY (CANCER BEFORE LAST THREE MONTHS)


|AlcoholHistoryCancerBeforeLastThreeMonths|value_as_concept_id|notes|
|------|-----|-----|
|1|4336673|Heavy (greater than 14 units per week)|
|2|4042862|Light (less than or equal to 14 units per week)|
|3|4022664|None ever|
|Z|0|Not Stated (patient asked but declined to provide a response)|
|9|0|Not Known (Not Recorded)|


* `AlcoholHistoryCancerBeforeLastThreeMonths` Past history of alcohol consumption for the patient during a cancer care spell. [ALCOHOL HISTORY (CANCER BEFORE LAST THREE MONTHS)](https://www.datadictionary.nhs.uk/data_elements/alcohol_history__cancer_before_last_three_months_.html)

```sql
select distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension'
        as NhsNumber,
    Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    Record ->> '$.ClinicalNurseSpecialistAndRiskFactorAssessments.HistoryOfAlcoholPast.@code'
        as AlcoholHistoryCancerBeforeLastThreeMonths
from omop_staging.cosd_staging_901
where type = 'SA'
  and NhsNumber is not null
  and AlcoholHistoryCancerBeforeLastThreeMonths is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_as_concept_id%20field%20COSD%20V9%20SA%20Observation%20Alcohol%20History%20Cancer%20Before%20Last%20Three%20Months%20mapping){: .btn }
### COSD V8 SA Observation Smoking Status Cancer
Source column  `SmokingStatusCancer`.
SMOKING STATUS (CANCER)


|SmokingStatusCancer|value_as_concept_id|notes|
|------|-----|-----|
|1|903657|Current smoker|
|2|903651|Ex-smoker|
|4|903653|Never smoked|
|9|0|Unknown (Not Recorded)|


* `SmokingStatusCancer` Used in the Cancer Outcomes and Services Data Set: Core to identify if the patient smokes tobacco only. [SMOKING STATUS (CANCER)](https://www.datadictionary.nhs.uk/data_elements/smoking_status__cancer_.html)

```sql
select distinct
    Record ->> '$.Sarcoma.SarcomaCore.SarcomaCoreLinkagePatientId.NHSNumber.@extension'
        as NhsNumber,
    Record ->> '$.Sarcoma.SarcomaCore.SarcomaCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    Record ->> '$.Sarcoma.SarcomaCore.SarcomaCoreClinicalNurseSpecialistAndRiskFactorAssessments.SmokingStatusCode.@code'
        as SmokingStatusCancer
from omop_staging.cosd_staging_81
where type = 'SA'
  and NhsNumber is not null
  and SmokingStatusCancer is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_as_concept_id%20field%20COSD%20V8%20SA%20Observation%20Smoking%20Status%20Cancer%20mapping){: .btn }
### COSD V8 SA Observation Alcohol History Cancer In Last Three Months
Source column  `AlcoholHistoryCancerInLastThreeMonths`.
ALCOHOL HISTORY (CANCER IN LAST THREE MONTHS)


|AlcoholHistoryCancerInLastThreeMonths|value_as_concept_id|notes|
|------|-----|-----|
|1|4336673|Heavy (greater than 14 units per week)|
|2|4042862|Light (less than or equal to 14 units per week)|
|3|105542008|None ever|
|Z|0|Not Stated (patient asked but declined to provide a response)|
|9|0|Not Known (Not Recorded)|


* `AlcoholHistoryCancerInLastThreeMonths` Current history of alcohol consumption for the patient during a cancer care spell. [ALCOHOL HISTORY (CANCER IN LAST THREE MONTHS)](https://www.datadictionary.nhs.uk/data_elements/alcohol_history__cancer_in_last_three_months_.html)

```sql
select distinct
    Record ->> '$.Sarcoma.SarcomaCore.SarcomaCoreLinkagePatientId.NHSNumber.@extension'
        as NhsNumber,
    Record ->> '$.Sarcoma.SarcomaCore.SarcomaCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    Record ->> '$.Sarcoma.SarcomaCore.SarcomaCoreClinicalNurseSpecialistAndRiskFactorAssessments.AlcoholHistoryCancerInLastThreeMonths.@code'
        as AlcoholHistoryCancerInLastThreeMonths
from omop_staging.cosd_staging_81
where type = 'SA'
  and NhsNumber is not null
  and AlcoholHistoryCancerInLastThreeMonths is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_as_concept_id%20field%20COSD%20V8%20SA%20Observation%20Alcohol%20History%20Cancer%20In%20Last%20Three%20Months%20mapping){: .btn }
### COSD V8 SA Observation Alcohol History Cancer Before Last Three Months
Source column  `AlcoholHistoryCancerBeforeLastThreeMonths`.
ALCOHOL HISTORY (CANCER BEFORE LAST THREE MONTHS)


|AlcoholHistoryCancerBeforeLastThreeMonths|value_as_concept_id|notes|
|------|-----|-----|
|1|4336673|Heavy (greater than 14 units per week)|
|2|4042862|Light (less than or equal to 14 units per week)|
|3|4022664|None ever|
|Z|0|Not Stated (patient asked but declined to provide a response)|
|9|0|Not Known (Not Recorded)|


* `AlcoholHistoryCancerBeforeLastThreeMonths` Past history of alcohol consumption for the patient during a cancer care spell. [ALCOHOL HISTORY (CANCER BEFORE LAST THREE MONTHS)](https://www.datadictionary.nhs.uk/data_elements/alcohol_history__cancer_before_last_three_months_.html)

```sql
select distinct
    Record ->> '$.Sarcoma.SarcomaCore.SarcomaCoreLinkagePatientId.NHSNumber.@extension'
        as NhsNumber,
    Record ->> '$.Sarcoma.SarcomaCore.SarcomaCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    Record ->> '$.Sarcoma.SarcomaCore.SarcomaCoreClinicalNurseSpecialistAndRiskFactorAssessments.AlcoholHistoryCancerBeforeLastThreeMonths.@code'
        as AlcoholHistoryCancerBeforeLastThreeMonths
from omop_staging.cosd_staging_81
where type = 'SA'
  and NhsNumber is not null
  and AlcoholHistoryCancerBeforeLastThreeMonths is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_as_concept_id%20field%20COSD%20V8%20SA%20Observation%20Alcohol%20History%20Cancer%20Before%20Last%20Three%20Months%20mapping){: .btn }
