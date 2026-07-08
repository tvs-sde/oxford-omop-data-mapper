---
layout: default
title: value_source_value
parent: Observation
grand_parent: Transformation Documentation
has_toc: false
---
# value_source_value
### SACT Adjunctive Therapy Type
* Value copied from `Source_value`

* `Source_value` Source value of the type of Adjunctive Therapy  given to a PATIENT  during a Cancer Care Spell. [ADJUNCTIVE THERAPY TYPE](https://www.datadictionary.nhs.uk/data_elements/adjunctive_therapy_type.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_source_value%20field%20SACT%20Adjunctive%20Therapy%20Type%20mapping){: .btn }
### SACT Administration Route
* Value copied from `Administration_Route`

* `Administration_Route` The prescribed route of administration for each Systemic Anti-Cancer Therapy Drug Administration in a Systemic Anti-Cancer Therapy Drug Cycle. [SYSTEMIC ANTI-CANCER THERAPY DRUG ROUTE OF ADMINISTRATION](https://www.datadictionary.nhs.uk/data_elements/systemic_anti-cancer_therapy_drug_route_of_administration.html)

```sql
		select
		distinct
  			replace(NHS_Number, ' ', '') as NHSNumber,
      		SACT_Administration_Route as Administration_Route,
		  	Administration_Date
	from omop_staging.sact_staging
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_source_value%20field%20SACT%20Administration%20Route%20mapping){: .btn }
### SACT Treatment Intent
* Value copied from `Source_value`

* `Source_value` Source value of the intent of the Systemic Anti-Cancer Therapy Drug Regimen. [SYSTEMIC ANTI-CANCER THERAPY DRUG REGIMEN TREATMENT INTENT](https://www.datadictionary.nhs.uk/data_elements/systemic_anti-cancer_therapy_drug_regimen_treatment_intent.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_source_value%20field%20SACT%20Treatment%20Intent%20mapping){: .btn }
### RTDS External Beam Radiation Therapy Energy
* Value copied from `NominalEnergy`

* `NominalEnergy` RADIOTHERAPY PRESCRIBED BEAM ENERGY  is the prescribed beam energy of a Radiotherapy Exposure used in External Beam Radiotherapy [RADIOTHERAPY PRESCRIBED BEAM ENERGY](https://www.datadictionary.nhs.uk/data_elements/radiotherapy_prescribed_beam_energy.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_source_value%20field%20RTDS%20External%20Beam%20Radiation%20Therapy%20Energy%20mapping){: .btn }
### RTDS Number Of Fractions
* Value copied from `NoFracs`

* `NoFracs` The prescribed number of Radiotherapy Fractions delivered to a PATIENT as described in the Radiotherapy Plan [RADIOTHERAPY PRESCRIBED FRACTIONS](https://www.datadictionary.nhs.uk/data_elements/radiotherapy_prescribed_fractions.html)

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_source_value%20field%20RTDS%20Number%20Of%20Fractions%20mapping){: .btn }
### RTDS Treatment Anatomical Site
* Value copied from `AttributeValue`

* `AttributeValue` ANATOMIC SITE OF RADIOTHERAPY PROCEDURE 

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_source_value%20field%20RTDS%20Treatment%20Anatomical%20Site%20mapping){: .btn }
### COSD V9 UR Observation Smoking Status Cancer
* Value copied from `SmokingStatusCancer`

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_source_value%20field%20COSD%20V9%20UR%20Observation%20Smoking%20Status%20Cancer%20mapping){: .btn }
### COSD V9 UR Observation Alcohol History Cancer In Last Three Months
* Value copied from `AlcoholHistoryCancerInLastThreeMonths`

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_source_value%20field%20COSD%20V9%20UR%20Observation%20Alcohol%20History%20Cancer%20In%20Last%20Three%20Months%20mapping){: .btn }
### COSD V9 UR Observation Alcohol History Cancer Before Last Three Months
* Value copied from `AlcoholHistoryCancerBeforeLastThreeMonths`

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_source_value%20field%20COSD%20V9%20UR%20Observation%20Alcohol%20History%20Cancer%20Before%20Last%20Three%20Months%20mapping){: .btn }
### COSD V8 UR Observation Smoking Status Cancer
* Value copied from `SmokingStatusCancer`

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_source_value%20field%20COSD%20V8%20UR%20Observation%20Smoking%20Status%20Cancer%20mapping){: .btn }
### COSD V8 UR Observation Person Stated Sexual Orientation Code At Diagnosis
* Value copied from `PersonStatedSexualOrientationCodeAtDiagnosis`

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_source_value%20field%20COSD%20V8%20UR%20Observation%20Person%20Stated%20Sexual%20Orientation%20Code%20At%20Diagnosis%20mapping){: .btn }
### COSD V8 UR Observation Alcohol History Cancer In Last Three Months
* Value copied from `AlcoholHistoryCancerInLastThreeMonths`

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_source_value%20field%20COSD%20V8%20UR%20Observation%20Alcohol%20History%20Cancer%20In%20Last%20Three%20Months%20mapping){: .btn }
### COSD V8 UR Observation Alcohol History Cancer Before Last Three Months
* Value copied from `AlcoholHistoryCancerBeforeLastThreeMonths`

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_source_value%20field%20COSD%20V8%20UR%20Observation%20Alcohol%20History%20Cancer%20Before%20Last%20Three%20Months%20mapping){: .btn }
### COSD V9 UG Observation Smoking Status Cancer
* Value copied from `SmokingStatusCancer`

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_source_value%20field%20COSD%20V9%20UG%20Observation%20Smoking%20Status%20Cancer%20mapping){: .btn }
### COSD V9 UG Observation Alcohol History Cancer In Last Three Months
* Value copied from `AlcoholHistoryCancerInLastThreeMonths`

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_source_value%20field%20COSD%20V9%20UG%20Observation%20Alcohol%20History%20Cancer%20In%20Last%20Three%20Months%20mapping){: .btn }
### COSD V9 UG Observation Alcohol History Cancer Before Last Three Months
* Value copied from `AlcoholHistoryCancerBeforeLastThreeMonths`

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_source_value%20field%20COSD%20V9%20UG%20Observation%20Alcohol%20History%20Cancer%20Before%20Last%20Three%20Months%20mapping){: .btn }
### COSD V8 UG Observation Smoking Status Cancer
* Value copied from `SmokingStatusCancer`

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_source_value%20field%20COSD%20V8%20UG%20Observation%20Smoking%20Status%20Cancer%20mapping){: .btn }
### COSD V8 UG Observation Alcohol History Cancer In Last Three Months
* Value copied from `AlcoholHistoryCancerInLastThreeMonths`

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_source_value%20field%20COSD%20V8%20UG%20Observation%20Alcohol%20History%20Cancer%20In%20Last%20Three%20Months%20mapping){: .btn }
### COSD V8 UG Observation Alcohol History Cancer Before Last Three Months
* Value copied from `AlcoholHistoryCancerBeforeLastThreeMonths`

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_source_value%20field%20COSD%20V8%20UG%20Observation%20Alcohol%20History%20Cancer%20Before%20Last%20Three%20Months%20mapping){: .btn }
### COSD V9 SK Observation Smoking Status Cancer
* Value copied from `SmokingStatusCancer`

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_source_value%20field%20COSD%20V9%20SK%20Observation%20Smoking%20Status%20Cancer%20mapping){: .btn }
### COSD V9 SK Observation Alcohol History Cancer In Last Three Months
* Value copied from `AlcoholHistoryCancerInLastThreeMonths`

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_source_value%20field%20COSD%20V9%20SK%20Observation%20Alcohol%20History%20Cancer%20In%20Last%20Three%20Months%20mapping){: .btn }
### COSD V9 SK Observation Alcohol History Cancer Before Last Three Months
* Value copied from `AlcoholHistoryCancerBeforeLastThreeMonths`

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_source_value%20field%20COSD%20V9%20SK%20Observation%20Alcohol%20History%20Cancer%20Before%20Last%20Three%20Months%20mapping){: .btn }
### COSD V8 SK Observation Smoking Status Cancer
* Value copied from `SmokingStatusCancer`

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_source_value%20field%20COSD%20V8%20SK%20Observation%20Smoking%20Status%20Cancer%20mapping){: .btn }
### COSD V8 SK Observation Alcohol History Cancer In Last Three Months
* Value copied from `AlcoholHistoryCancerInLastThreeMonths`

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_source_value%20field%20COSD%20V8%20SK%20Observation%20Alcohol%20History%20Cancer%20In%20Last%20Three%20Months%20mapping){: .btn }
### COSD V8 SK Observation Alcohol History Cancer Before Last Three Months
* Value copied from `AlcoholHistoryCancerBeforeLastThreeMonths`

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_source_value%20field%20COSD%20V8%20SK%20Observation%20Alcohol%20History%20Cancer%20Before%20Last%20Three%20Months%20mapping){: .btn }
### COSD V9 SA Observation Smoking Status Cancer
* Value copied from `SmokingStatusCancer`

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_source_value%20field%20COSD%20V9%20SA%20Observation%20Smoking%20Status%20Cancer%20mapping){: .btn }
### COSD V9 SA Observation Alcohol History Cancer In Last Three Months
* Value copied from `AlcoholHistoryCancerInLastThreeMonths`

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_source_value%20field%20COSD%20V9%20SA%20Observation%20Alcohol%20History%20Cancer%20In%20Last%20Three%20Months%20mapping){: .btn }
### COSD V9 SA Observation Alcohol History Cancer Before Last Three Months
* Value copied from `AlcoholHistoryCancerBeforeLastThreeMonths`

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_source_value%20field%20COSD%20V9%20SA%20Observation%20Alcohol%20History%20Cancer%20Before%20Last%20Three%20Months%20mapping){: .btn }
### COSD V8 SA Observation Smoking Status Cancer
* Value copied from `SmokingStatusCancer`

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_source_value%20field%20COSD%20V8%20SA%20Observation%20Smoking%20Status%20Cancer%20mapping){: .btn }
### COSD V8 SA Observation Alcohol History Cancer In Last Three Months
* Value copied from `AlcoholHistoryCancerInLastThreeMonths`

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_source_value%20field%20COSD%20V8%20SA%20Observation%20Alcohol%20History%20Cancer%20In%20Last%20Three%20Months%20mapping){: .btn }
### COSD V8 SA Observation Alcohol History Cancer Before Last Three Months
* Value copied from `AlcoholHistoryCancerBeforeLastThreeMonths`

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_source_value%20field%20COSD%20V8%20SA%20Observation%20Alcohol%20History%20Cancer%20Before%20Last%20Three%20Months%20mapping){: .btn }
### COSD V9 LV Observation Smoking Status Cancer
* Value copied from `SmokingStatusCancer`

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
where type = 'LV'
  and NhsNumber is not null
  and SmokingStatusCancer is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_source_value%20field%20COSD%20V9%20LV%20Observation%20Smoking%20Status%20Cancer%20mapping){: .btn }
### COSD V9 LV Observation Performance Status Adult
* Value copied from `PerformanceStatusAdult`

* `PerformanceStatusAdult` A World Health Organisation classification indicating a person's status relating to activity or disability. [PERFORMANCE STATUS (ADULT)](https://www.datadictionary.nhs.uk/data_elements/performance_status__adult_.html)

```sql
select distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension'
        as NhsNumber,
    Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    Record ->> '$.PrimaryPathway.Diagnosis.PerformanceStatusAdult.@code'
        as PerformanceStatusAdult
from omop_staging.cosd_staging_901
where type = 'LV'
  and NhsNumber is not null
  and PerformanceStatusAdult is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_source_value%20field%20COSD%20V9%20LV%20Observation%20Performance%20Status%20Adult%20mapping){: .btn }
### COSD V9 LV Observation Familial Cancer Syndrome Indicator
* Value copied from `FamilialCancerSyndromeIndicator`

* `FamilialCancerSyndromeIndicator` Indicates whether there is a possible or confirmed familial cancer syndrome during a Cancer Care Spell. [FAMILIAL CANCER SYNDROME INDICATOR](https://www.datadictionary.nhs.uk/data_elements/familial_cancer_syndrome_indicator.html)

```sql
select distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension'
        as NhsNumber,
    Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    Record ->> '$.PrimaryPathway.Diagnosis.DiagnosisAdditionalItems.FamilialCancerSyndrome.@code'
        as FamilialCancerSyndromeIndicator
from omop_staging.cosd_staging_901
where type = 'LV'
  and NhsNumber is not null
  and FamilialCancerSyndromeIndicator is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_source_value%20field%20COSD%20V9%20LV%20Observation%20Familial%20Cancer%20Syndrome%20Indicator%20mapping){: .btn }
### COSD V9 LV Observation Cancer Treatment Intent
* Value copied from `CancerTreatmentIntent`

* `CancerTreatmentIntent` The intention of the cancer treatment provided during a Cancer Care Spell. [CANCER TREATMENT INTENT](https://www.datadictionary.nhs.uk/data_elements/cancer_treatment_intent.html)

```sql
with lv as (
    select
        Record ->> '$.LinkagePatientId.NhsNumber.@extension'
            as NhsNumber,
        unnest([
            [Record ->> '$.Treatment.CancerTreatmentIntent.@code'],
            Record ->> '$.Treatment[*].CancerTreatmentIntent.@code'
        ], recursive := true) as CancerTreatmentIntent,
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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_source_value%20field%20COSD%20V9%20LV%20Observation%20Cancer%20Treatment%20Intent%20mapping){: .btn }
### COSD V8 LV Observation Performance Status Adult
* Value copied from `PerformanceStatusAdult`

* `PerformanceStatusAdult` A World Health Organisation classification indicating a person's status relating to activity or disability. [PERFORMANCE STATUS (ADULT)](https://www.datadictionary.nhs.uk/data_elements/performance_status__adult_.html)

```sql
select distinct
    Record ->> '$.Liver.LiverCore.LiverCoreLinkagePatientId.NHSNumber.@extension'
        as NhsNumber,
    Record ->> '$.Liver.LiverCore.LiverCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    Record ->> '$.Liver.LiverCore.LiverCoreDiagnosis.AdultPerformanceStatus.@code'
        as PerformanceStatusAdult
from omop_staging.cosd_staging_81
where type = 'LV'
  and NhsNumber is not null
  and PerformanceStatusAdult is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_source_value%20field%20COSD%20V8%20LV%20Observation%20Performance%20Status%20Adult%20mapping){: .btn }
### COSD V8 LV Observation Cancer Treatment Intent
* Value copied from `CancerTreatmentIntent`

* `CancerTreatmentIntent` The intention of the cancer treatment provided during a Cancer Care Spell. [CANCER TREATMENT INTENT](https://www.datadictionary.nhs.uk/data_elements/cancer_treatment_intent.html)

```sql
with lv as (
    select
        Record ->> '$.Liver.LiverCore.LiverCoreLinkagePatientId.NHSNumber.@extension'
            as NhsNumber,
        unnest(
            [
                [ Record ->> '$.Liver.LiverCore.LiverCoreTreatment.CancerTreatmentIntent.@code' ],
                Record ->> '$.Liver.LiverCore.LiverCoreTreatment[*].CancerTreatmentIntent.@code'
            ],
            recursive := true
        ) as CancerTreatmentIntent,
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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_source_value%20field%20COSD%20V8%20LV%20Observation%20Cancer%20Treatment%20Intent%20mapping){: .btn }
### COSD V9 HN Observation Smoking Status Cancer
* Value copied from `SmokingStatusCancer`

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
where type = 'HN'
  and NhsNumber is not null
  and SmokingStatusCancer is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_source_value%20field%20COSD%20V9%20HN%20Observation%20Smoking%20Status%20Cancer%20mapping){: .btn }
### COSD V9 HN Observation Performance Status Adult
* Value copied from `PerformanceStatusAdult`

* `PerformanceStatusAdult` A World Health Organisation classification indicating a person's status relating to activity or disability. [PERFORMANCE STATUS (ADULT)](https://www.datadictionary.nhs.uk/data_elements/performance_status__adult_.html)

```sql
select distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension'
        as NhsNumber,
    Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    Record ->> '$.PrimaryPathway.Diagnosis.PerformanceStatusAdult.@code'
        as PerformanceStatusAdult
from omop_staging.cosd_staging_901
where type = 'HN'
  and NhsNumber is not null
  and PerformanceStatusAdult is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_source_value%20field%20COSD%20V9%20HN%20Observation%20Performance%20Status%20Adult%20mapping){: .btn }
### COSD V9 HN Observation Familial Cancer Syndrome Indicator
* Value copied from `FamilialCancerSyndromeIndicator`

* `FamilialCancerSyndromeIndicator` Indicates whether there is a possible or confirmed familial cancer syndrome during a Cancer Care Spell. [FAMILIAL CANCER SYNDROME INDICATOR](https://www.datadictionary.nhs.uk/data_elements/familial_cancer_syndrome_indicator.html)

```sql
select distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension'
        as NhsNumber,
    Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    Record ->> '$.PrimaryPathway.Diagnosis.DiagnosisAdditionalItems.FamilialCancerSyndrome.@code'
        as FamilialCancerSyndromeIndicator
from omop_staging.cosd_staging_901
where type = 'HN'
  and NhsNumber is not null
  and FamilialCancerSyndromeIndicator is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_source_value%20field%20COSD%20V9%20HN%20Observation%20Familial%20Cancer%20Syndrome%20Indicator%20mapping){: .btn }
### COSD V9 HN Observation Cancer Treatment Intent
* Value copied from `CancerTreatmentIntent`

* `CancerTreatmentIntent` The intention of the cancer treatment provided during a Cancer Care Spell. [CANCER TREATMENT INTENT](https://www.datadictionary.nhs.uk/data_elements/cancer_treatment_intent.html)

```sql
with hn as (
    select
        Record ->> '$.LinkagePatientId.NhsNumber.@extension'
            as NhsNumber,
        unnest([
            [Record ->> '$.Treatment.CancerTreatmentIntent.@code'],
            Record ->> '$.Treatment[*].CancerTreatmentIntent.@code'
        ], recursive := true) as CancerTreatmentIntent,
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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_source_value%20field%20COSD%20V9%20HN%20Observation%20Cancer%20Treatment%20Intent%20mapping){: .btn }
### COSD V9 HN Observation Alcohol History Cancer In Last Three Months
* Value copied from `AlcoholHistoryCancerInLastThreeMonths`

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
where type = 'HN'
  and NhsNumber is not null
  and AlcoholHistoryCancerInLastThreeMonths is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_source_value%20field%20COSD%20V9%20HN%20Observation%20Alcohol%20History%20Cancer%20In%20Last%20Three%20Months%20mapping){: .btn }
### COSD V9 HN Observation Alcohol History Cancer Before Last Three Months
* Value copied from `AlcoholHistoryCancerBeforeLastThreeMonths`

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
where type = 'HN'
  and NhsNumber is not null
  and AlcoholHistoryCancerBeforeLastThreeMonths is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_source_value%20field%20COSD%20V9%20HN%20Observation%20Alcohol%20History%20Cancer%20Before%20Last%20Three%20Months%20mapping){: .btn }
### COSD V8 HN Observation Smoking Status Cancer
* Value copied from `SmokingStatusCancer`

* `SmokingStatusCancer` Used in the Cancer Outcomes and Services Data Set: Core to identify if the patient smokes tobacco only. [SMOKING STATUS (CANCER)](https://www.datadictionary.nhs.uk/data_elements/smoking_status__cancer_.html)

```sql
select distinct
    Record ->> '$.HeadNeck.HeadNeckCore.HeadNeckCoreLinkagePatientId.NHSNumber.@extension'
        as NhsNumber,
    Record ->> '$.HeadNeck.HeadNeckCore.HeadNeckCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    Record ->> '$.HeadNeck.HeadNeckCore.HeadNeckCoreClinicalNurseSpecialistAndRiskFactorAssessments.SmokingStatusCode.@code'
        as SmokingStatusCancer
from omop_staging.cosd_staging_81
where type = 'HN'
  and NhsNumber is not null
  and SmokingStatusCancer is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_source_value%20field%20COSD%20V8%20HN%20Observation%20Smoking%20Status%20Cancer%20mapping){: .btn }
### COSD V8 HN Observation Performance Status Adult
* Value copied from `PerformanceStatusAdult`

* `PerformanceStatusAdult` A World Health Organisation classification indicating a person's status relating to activity or disability. [PERFORMANCE STATUS (ADULT)](https://www.datadictionary.nhs.uk/data_elements/performance_status__adult_.html)

```sql
select distinct
    Record ->> '$.HeadNeck.HeadNeckCore.HeadNeckCoreLinkagePatientId.NHSNumber.@extension'
        as NhsNumber,
    Record ->> '$.HeadNeck.HeadNeckCore.HeadNeckCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    Record ->> '$.HeadNeck.HeadNeckCore.HeadNeckCoreDiagnosis.AdultPerformanceStatus.@code'
        as PerformanceStatusAdult
from omop_staging.cosd_staging_81
where type = 'HN'
  and NhsNumber is not null
  and PerformanceStatusAdult is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_source_value%20field%20COSD%20V8%20HN%20Observation%20Performance%20Status%20Adult%20mapping){: .btn }
### COSD V8 HN Observation Familial Cancer Syndrome Indicator
* Value copied from `FamilialCancerSyndromeIndicator`

* `FamilialCancerSyndromeIndicator` Indicates whether there is a possible or confirmed familial cancer syndrome during a Cancer Care Spell. [FAMILIAL CANCER SYNDROME INDICATOR](https://www.datadictionary.nhs.uk/data_elements/familial_cancer_syndrome_indicator.html)

```sql
select distinct
    Record ->> '$.HeadNeck.HeadNeckCore.HeadNeckCoreLinkagePatientId.NHSNumber.@extension'
        as NhsNumber,
    Record ->> '$.HeadNeck.HeadNeckCore.HeadNeckCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    Record ->> '$.HeadNeck.HeadNeckCore.HeadNeckCoreDiagnosis.HeadNeckCoreDiagnosisAdditionalItems.FamilialCancerSyndromeIndicator.@code'
        as FamilialCancerSyndromeIndicator
from omop_staging.cosd_staging_81
where type = 'HN'
  and NhsNumber is not null
  and FamilialCancerSyndromeIndicator is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_source_value%20field%20COSD%20V8%20HN%20Observation%20Familial%20Cancer%20Syndrome%20Indicator%20mapping){: .btn }
### COSD V8 HN Observation Cancer Treatment Intent
* Value copied from `CancerTreatmentIntent`

* `CancerTreatmentIntent` The intention of the cancer treatment provided during a Cancer Care Spell. [CANCER TREATMENT INTENT](https://www.datadictionary.nhs.uk/data_elements/cancer_treatment_intent.html)

```sql
with hn as (
    select
        Record ->> '$.HeadNeck.HeadNeckCore.HeadNeckCoreLinkagePatientId.NHSNumber.@extension'
            as NhsNumber,
        unnest(
            [
                [ Record ->> '$.HeadNeck.HeadNeckCore.HeadNeckCoreTreatment.CancerTreatmentIntent.@code' ],
                Record ->> '$.HeadNeck.HeadNeckCore.HeadNeckCoreTreatment[*].CancerTreatmentIntent.@code'
            ],
            recursive := true
        ) as CancerTreatmentIntent,
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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_source_value%20field%20COSD%20V8%20HN%20Observation%20Cancer%20Treatment%20Intent%20mapping){: .btn }
### COSD V8 HN Observation Alcohol History Cancer In Last Three Months
* Value copied from `AlcoholHistoryCancerInLastThreeMonths`

* `AlcoholHistoryCancerInLastThreeMonths` Current history of alcohol consumption for the patient during a cancer care spell. [ALCOHOL HISTORY (CANCER IN LAST THREE MONTHS)](https://www.datadictionary.nhs.uk/data_elements/alcohol_history__cancer_in_last_three_months_.html)

```sql
select distinct
    Record ->> '$.HeadNeck.HeadNeckCore.HeadNeckCoreLinkagePatientId.NHSNumber.@extension'
        as NhsNumber,
    Record ->> '$.HeadNeck.HeadNeckCore.HeadNeckCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    Record ->> '$.HeadNeck.HeadNeckCore.HeadNeckCoreClinicalNurseSpecialistAndRiskFactorAssessments.AlcoholHistoryCancerInLastThreeMonths.@code'
        as AlcoholHistoryCancerInLastThreeMonths
from omop_staging.cosd_staging_81
where type = 'HN'
  and NhsNumber is not null
  and AlcoholHistoryCancerInLastThreeMonths is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_source_value%20field%20COSD%20V8%20HN%20Observation%20Alcohol%20History%20Cancer%20In%20Last%20Three%20Months%20mapping){: .btn }
### COSD V8 HN Observation Alcohol History Cancer Before Last Three Months
* Value copied from `AlcoholHistoryCancerBeforeLastThreeMonths`

* `AlcoholHistoryCancerBeforeLastThreeMonths` Past history of alcohol consumption for the patient during a cancer care spell. [ALCOHOL HISTORY (CANCER BEFORE LAST THREE MONTHS)](https://www.datadictionary.nhs.uk/data_elements/alcohol_history__cancer_before_last_three_months_.html)

```sql
select distinct
    Record ->> '$.HeadNeck.HeadNeckCore.HeadNeckCoreLinkagePatientId.NHSNumber.@extension'
        as NhsNumber,
    Record ->> '$.HeadNeck.HeadNeckCore.HeadNeckCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    Record ->> '$.HeadNeck.HeadNeckCore.HeadNeckCoreClinicalNurseSpecialistAndRiskFactorAssessments.AlcoholHistoryCancerBeforeLastThreeMonths.@code'
        as AlcoholHistoryCancerBeforeLastThreeMonths
from omop_staging.cosd_staging_81
where type = 'HN'
  and NhsNumber is not null
  and AlcoholHistoryCancerBeforeLastThreeMonths is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_source_value%20field%20COSD%20V8%20HN%20Observation%20Alcohol%20History%20Cancer%20Before%20Last%20Three%20Months%20mapping){: .btn }
### COSD V9 HA Observation Smoking Status Cancer
* Value copied from `SmokingStatusCancer`

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
where type = 'HA'
  and NhsNumber is not null
  and SmokingStatusCancer is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_source_value%20field%20COSD%20V9%20HA%20Observation%20Smoking%20Status%20Cancer%20mapping){: .btn }
### COSD V9 HA Observation Performance Status Adult
* Value copied from `PerformanceStatusAdult`

* `PerformanceStatusAdult` A World Health Organisation classification indicating a person's status relating to activity or disability. [PERFORMANCE STATUS (ADULT)](https://www.datadictionary.nhs.uk/data_elements/performance_status__adult_.html)

```sql
select distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension'
        as NhsNumber,
    Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    Record ->> '$.PrimaryPathway.Diagnosis.PerformanceStatusAdult.@code'
        as PerformanceStatusAdult
from omop_staging.cosd_staging_901
where type = 'HA'
  and NhsNumber is not null
  and PerformanceStatusAdult is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_source_value%20field%20COSD%20V9%20HA%20Observation%20Performance%20Status%20Adult%20mapping){: .btn }
### COSD V9 HA Observation Familial Cancer Syndrome Indicator
* Value copied from `FamilialCancerSyndromeIndicator`

* `FamilialCancerSyndromeIndicator` Indicates whether there is a possible or confirmed familial cancer syndrome during a Cancer Care Spell. [FAMILIAL CANCER SYNDROME INDICATOR](https://www.datadictionary.nhs.uk/data_elements/familial_cancer_syndrome_indicator.html)

```sql
select distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension'
        as NhsNumber,
    Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    Record ->> '$.PrimaryPathway.Diagnosis.DiagnosisAdditionalItems.FamilialCancerSyndrome.@code'
        as FamilialCancerSyndromeIndicator
from omop_staging.cosd_staging_901
where type = 'HA'
  and NhsNumber is not null
  and FamilialCancerSyndromeIndicator is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_source_value%20field%20COSD%20V9%20HA%20Observation%20Familial%20Cancer%20Syndrome%20Indicator%20mapping){: .btn }
### COSD V9 HA Observation Cancer Treatment Intent
* Value copied from `CancerTreatmentIntent`

* `CancerTreatmentIntent` The intention of the cancer treatment provided during a Cancer Care Spell. [CANCER TREATMENT INTENT](https://www.datadictionary.nhs.uk/data_elements/cancer_treatment_intent.html)

```sql
with ha as (
    select
        Record ->> '$.LinkagePatientId.NhsNumber.@extension'
            as NhsNumber,
        unnest([
            [Record ->> '$.Treatment.CancerTreatmentIntent.@code'],
            Record ->> '$.Treatment[*].CancerTreatmentIntent.@code'
        ], recursive := true) as CancerTreatmentIntent,
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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_source_value%20field%20COSD%20V9%20HA%20Observation%20Cancer%20Treatment%20Intent%20mapping){: .btn }
### COSD V9 HA Observation Alcohol History Cancer In Last Three Months
* Value copied from `AlcoholHistoryCancerInLastThreeMonths`

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
where type = 'HA'
  and NhsNumber is not null
  and AlcoholHistoryCancerInLastThreeMonths is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_source_value%20field%20COSD%20V9%20HA%20Observation%20Alcohol%20History%20Cancer%20In%20Last%20Three%20Months%20mapping){: .btn }
### COSD V9 HA Observation Alcohol History Cancer Before Last Three Months
* Value copied from `AlcoholHistoryCancerBeforeLastThreeMonths`

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
where type = 'HA'
  and NhsNumber is not null
  and AlcoholHistoryCancerBeforeLastThreeMonths is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_source_value%20field%20COSD%20V9%20HA%20Observation%20Alcohol%20History%20Cancer%20Before%20Last%20Three%20Months%20mapping){: .btn }
### COSD V8 HA Observation Smoking Status Cancer
* Value copied from `SmokingStatusCancer`

* `SmokingStatusCancer` Used in the Cancer Outcomes and Services Data Set: Core to identify if the patient smokes tobacco only. [SMOKING STATUS (CANCER)](https://www.datadictionary.nhs.uk/data_elements/smoking_status__cancer_.html)

```sql
select distinct
    Record ->> '$.Haematological.HaematologicalCore.HaematologicalCoreLinkagePatientId.NHSNumber.@extension'
        as NhsNumber,
    Record ->> '$.Haematological.HaematologicalCore.HaematologicalCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    Record ->> '$.Haematological.HaematologicalCore.HaematologicalCoreClinicalNurseSpecialistAndRiskFactorAssessments.SmokingStatusCode.@code'
        as SmokingStatusCancer
from omop_staging.cosd_staging_81
where type = 'HA'
  and NhsNumber is not null
  and SmokingStatusCancer is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_source_value%20field%20COSD%20V8%20HA%20Observation%20Smoking%20Status%20Cancer%20mapping){: .btn }
### COSD V8 HA Observation Performance Status Adult
* Value copied from `PerformanceStatusAdult`

* `PerformanceStatusAdult` A World Health Organisation classification indicating a person's status relating to activity or disability. [PERFORMANCE STATUS (ADULT)](https://www.datadictionary.nhs.uk/data_elements/performance_status__adult_.html)

```sql
select distinct
    Record ->> '$.Haematological.HaematologicalCore.HaematologicalCoreLinkagePatientId.NHSNumber.@extension'
        as NhsNumber,
    Record ->> '$.Haematological.HaematologicalCore.HaematologicalCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    Record ->> '$.Haematological.HaematologicalCore.HaematologicalCoreDiagnosis.AdultPerformanceStatus.@code'
        as PerformanceStatusAdult
from omop_staging.cosd_staging_81
where type = 'HA'
  and NhsNumber is not null
  and PerformanceStatusAdult is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_source_value%20field%20COSD%20V8%20HA%20Observation%20Performance%20Status%20Adult%20mapping){: .btn }
### COSD V8 HA Observation Familial Cancer Syndrome Indicator
* Value copied from `FamilialCancerSyndromeIndicator`

* `FamilialCancerSyndromeIndicator` Indicates whether there is a possible or confirmed familial cancer syndrome during a Cancer Care Spell. [FAMILIAL CANCER SYNDROME INDICATOR](https://www.datadictionary.nhs.uk/data_elements/familial_cancer_syndrome_indicator.html)

```sql
select distinct
    Record ->> '$.Haematological.HaematologicalCore.HaematologicalCoreLinkagePatientId.NHSNumber.@extension'
        as NhsNumber,
    Record ->> '$.Haematological.HaematologicalCore.HaematologicalCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    Record ->> '$.Haematological.HaematologicalCore.HaematologicalCoreDiagnosis.HaematologicalCoreDiagnosisAdditionalItems.FamilialCancerSyndromeIndicator.@code'
        as FamilialCancerSyndromeIndicator
from omop_staging.cosd_staging_81
where type = 'HA'
  and NhsNumber is not null
  and FamilialCancerSyndromeIndicator is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_source_value%20field%20COSD%20V8%20HA%20Observation%20Familial%20Cancer%20Syndrome%20Indicator%20mapping){: .btn }
### COSD V8 HA Observation Cancer Treatment Intent
* Value copied from `CancerTreatmentIntent`

* `CancerTreatmentIntent` The intention of the cancer treatment provided during a Cancer Care Spell. [CANCER TREATMENT INTENT](https://www.datadictionary.nhs.uk/data_elements/cancer_treatment_intent.html)

```sql
with ha as (
    select
        Record ->> '$.Haematological.HaematologicalCore.HaematologicalCoreLinkagePatientId.NHSNumber.@extension'
            as NhsNumber,
        unnest(
            [
                [ Record ->> '$.Haematological.HaematologicalCore.HaematologicalCoreTreatment.CancerTreatmentIntent.@code' ],
                Record ->> '$.Haematological.HaematologicalCore.HaematologicalCoreTreatment[*].CancerTreatmentIntent.@code'
            ],
            recursive := true
        ) as CancerTreatmentIntent,
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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_source_value%20field%20COSD%20V8%20HA%20Observation%20Cancer%20Treatment%20Intent%20mapping){: .btn }
### COSD V8 HA Observation Alcohol History Cancer In Last Three Months
* Value copied from `AlcoholHistoryCancerInLastThreeMonths`

* `AlcoholHistoryCancerInLastThreeMonths` Current history of alcohol consumption for the patient during a cancer care spell. [ALCOHOL HISTORY (CANCER IN LAST THREE MONTHS)](https://www.datadictionary.nhs.uk/data_elements/alcohol_history__cancer_in_last_three_months_.html)

```sql
select distinct
    Record ->> '$.Haematological.HaematologicalCore.HaematologicalCoreLinkagePatientId.NHSNumber.@extension'
        as NhsNumber,
    Record ->> '$.Haematological.HaematologicalCore.HaematologicalCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    Record ->> '$.Haematological.HaematologicalCore.HaematologicalCoreClinicalNurseSpecialistAndRiskFactorAssessments.AlcoholHistoryCancerInLastThreeMonths.@code'
        as AlcoholHistoryCancerInLastThreeMonths
from omop_staging.cosd_staging_81
where type = 'HA'
  and NhsNumber is not null
  and AlcoholHistoryCancerInLastThreeMonths is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_source_value%20field%20COSD%20V8%20HA%20Observation%20Alcohol%20History%20Cancer%20In%20Last%20Three%20Months%20mapping){: .btn }
### COSD V8 HA Observation Alcohol History Cancer Before Last Three Months
* Value copied from `AlcoholHistoryCancerBeforeLastThreeMonths`

* `AlcoholHistoryCancerBeforeLastThreeMonths` Past history of alcohol consumption for the patient during a cancer care spell. [ALCOHOL HISTORY (CANCER BEFORE LAST THREE MONTHS)](https://www.datadictionary.nhs.uk/data_elements/alcohol_history__cancer_before_last_three_months_.html)

```sql
select distinct
    Record ->> '$.Haematological.HaematologicalCore.HaematologicalCoreLinkagePatientId.NHSNumber.@extension'
        as NhsNumber,
    Record ->> '$.Haematological.HaematologicalCore.HaematologicalCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    Record ->> '$.Haematological.HaematologicalCore.HaematologicalCoreClinicalNurseSpecialistAndRiskFactorAssessments.AlcoholHistoryCancerBeforeLastThreeMonths.@code'
        as AlcoholHistoryCancerBeforeLastThreeMonths
from omop_staging.cosd_staging_81
where type = 'HA'
  and NhsNumber is not null
  and AlcoholHistoryCancerBeforeLastThreeMonths is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_source_value%20field%20COSD%20V8%20HA%20Observation%20Alcohol%20History%20Cancer%20Before%20Last%20Three%20Months%20mapping){: .btn }
### COSD V9 GY Observation Smoking Status Cancer
* Value copied from `SmokingStatusCancer`

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
where type = 'GY'
  and NhsNumber is not null
  and SmokingStatusCancer is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_source_value%20field%20COSD%20V9%20GY%20Observation%20Smoking%20Status%20Cancer%20mapping){: .btn }
### COSD V9 GY Observation Performance Status Adult
* Value copied from `PerformanceStatusAdult`

* `PerformanceStatusAdult` A World Health Organisation classification indicating a person's status relating to activity or disability. [PERFORMANCE STATUS (ADULT)](https://www.datadictionary.nhs.uk/data_elements/performance_status__adult_.html)

```sql
select distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension'
        as NhsNumber,
    Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    Record ->> '$.PrimaryPathway.Diagnosis.PerformanceStatusAdult.@code'
        as PerformanceStatusAdult
from omop_staging.cosd_staging_901
where type = 'GY'
  and NhsNumber is not null
  and PerformanceStatusAdult is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_source_value%20field%20COSD%20V9%20GY%20Observation%20Performance%20Status%20Adult%20mapping){: .btn }
### COSD V9 GY Observation Familial Cancer Syndrome Indicator
* Value copied from `FamilialCancerSyndromeIndicator`

* `FamilialCancerSyndromeIndicator` Indicates whether there is a possible or confirmed familial cancer syndrome during a Cancer Care Spell. [FAMILIAL CANCER SYNDROME INDICATOR](https://www.datadictionary.nhs.uk/data_elements/familial_cancer_syndrome_indicator.html)

```sql
select distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension'
        as NhsNumber,
    Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    Record ->> '$.PrimaryPathway.Diagnosis.DiagnosisAdditionalItems.FamilialCancerSyndrome.@code'
        as FamilialCancerSyndromeIndicator
from omop_staging.cosd_staging_901
where type = 'GY'
  and NhsNumber is not null
  and FamilialCancerSyndromeIndicator is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_source_value%20field%20COSD%20V9%20GY%20Observation%20Familial%20Cancer%20Syndrome%20Indicator%20mapping){: .btn }
### COSD V9 GY Observation Cancer Treatment Intent
* Value copied from `CancerTreatmentIntent`

* `CancerTreatmentIntent` The intention of the cancer treatment provided during a Cancer Care Spell. [CANCER TREATMENT INTENT](https://www.datadictionary.nhs.uk/data_elements/cancer_treatment_intent.html)

```sql
with gy as (
    select
        Record ->> '$.LinkagePatientId.NhsNumber.@extension'
            as NhsNumber,
        unnest([
            [Record ->> '$.Treatment.CancerTreatmentIntent.@code'],
            Record ->> '$.Treatment[*].CancerTreatmentIntent.@code'
        ], recursive := true) as CancerTreatmentIntent,
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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_source_value%20field%20COSD%20V9%20GY%20Observation%20Cancer%20Treatment%20Intent%20mapping){: .btn }
### COSD V9 GY Observation Alcohol History Cancer In Last Three Months
* Value copied from `AlcoholHistoryCancerInLastThreeMonths`

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
where type = 'GY'
  and NhsNumber is not null
  and AlcoholHistoryCancerInLastThreeMonths is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_source_value%20field%20COSD%20V9%20GY%20Observation%20Alcohol%20History%20Cancer%20In%20Last%20Three%20Months%20mapping){: .btn }
### COSD V9 GY Observation Alcohol History Cancer Before Last Three Months
* Value copied from `AlcoholHistoryCancerBeforeLastThreeMonths`

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
where type = 'GY'
  and NhsNumber is not null
  and AlcoholHistoryCancerBeforeLastThreeMonths is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_source_value%20field%20COSD%20V9%20GY%20Observation%20Alcohol%20History%20Cancer%20Before%20Last%20Three%20Months%20mapping){: .btn }
### COSD V8 GY Observation Smoking Status Cancer
* Value copied from `SmokingStatusCancer`

* `SmokingStatusCancer` Used in the Cancer Outcomes and Services Data Set: Core to identify if the patient smokes tobacco only. [SMOKING STATUS (CANCER)](https://www.datadictionary.nhs.uk/data_elements/smoking_status__cancer_.html)

```sql
select distinct
    Record ->> '$.Gynaecological.GynaecologicalCore.GynaecologicalCoreLinkagePatientId.NHSNumber.@extension'
        as NhsNumber,
    Record ->> '$.Gynaecological.GynaecologicalCore.GynaecologicalCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    Record ->> '$.Gynaecological.GynaecologicalCore.GynaecologicalCoreClinicalNurseSpecialistAndRiskFactorAssessments.SmokingStatusCode.@code'
        as SmokingStatusCancer
from omop_staging.cosd_staging_81
where type = 'GY'
  and NhsNumber is not null
  and SmokingStatusCancer is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_source_value%20field%20COSD%20V8%20GY%20Observation%20Smoking%20Status%20Cancer%20mapping){: .btn }
### COSD V8 GY Observation Performance Status Adult
* Value copied from `PerformanceStatusAdult`

* `PerformanceStatusAdult` A World Health Organisation classification indicating a person's status relating to activity or disability. [PERFORMANCE STATUS (ADULT)](https://www.datadictionary.nhs.uk/data_elements/performance_status__adult_.html)

```sql
select distinct
    Record ->> '$.Gynaecological.GynaecologicalCore.GynaecologicalCoreLinkagePatientId.NHSNumber.@extension'
        as NhsNumber,
    Record ->> '$.Gynaecological.GynaecologicalCore.GynaecologicalCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    Record ->> '$.Gynaecological.GynaecologicalCore.GynaecologicalCoreDiagnosis.AdultPerformanceStatus.@code'
        as PerformanceStatusAdult
from omop_staging.cosd_staging_81
where type = 'GY'
  and NhsNumber is not null
  and PerformanceStatusAdult is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_source_value%20field%20COSD%20V8%20GY%20Observation%20Performance%20Status%20Adult%20mapping){: .btn }
### COSD V8 GY Observation Familial Cancer Syndrome Indicator
* Value copied from `FamilialCancerSyndromeIndicator`

* `FamilialCancerSyndromeIndicator` Indicates whether there is a possible or confirmed familial cancer syndrome during a Cancer Care Spell. [FAMILIAL CANCER SYNDROME INDICATOR](https://www.datadictionary.nhs.uk/data_elements/familial_cancer_syndrome_indicator.html)

```sql
select distinct
    Record ->> '$.Gynaecological.GynaecologicalCore.GynaecologicalCoreLinkagePatientId.NHSNumber.@extension'
        as NhsNumber,
    Record ->> '$.Gynaecological.GynaecologicalCore.GynaecologicalCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    Record ->> '$.Gynaecological.GynaecologicalCore.GynaecologicalCoreDiagnosis.GynaecologicalCoreDiagnosisAdditionalItems.FamilialCancerSyndromeIndicator.@code'
        as FamilialCancerSyndromeIndicator
from omop_staging.cosd_staging_81
where type = 'GY'
  and NhsNumber is not null
  and FamilialCancerSyndromeIndicator is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_source_value%20field%20COSD%20V8%20GY%20Observation%20Familial%20Cancer%20Syndrome%20Indicator%20mapping){: .btn }
### COSD V8 GY Observation Cancer Treatment Intent
* Value copied from `CancerTreatmentIntent`

* `CancerTreatmentIntent` The intention of the cancer treatment provided during a Cancer Care Spell. [CANCER TREATMENT INTENT](https://www.datadictionary.nhs.uk/data_elements/cancer_treatment_intent.html)

```sql
with gy as (
    select distinct
        Record ->> '$.Gynaecological.GynaecologicalCore.GynaecologicalCoreLinkagePatientId.NHSNumber.@extension'
            as NhsNumber,
        unnest(
            [
                [ Record ->> '$.Gynaecological.GynaecologicalCore.GynaecologicalCoreTreatment.CancerTreatmentStartDate' ],
                Record ->> '$.Gynaecological.GynaecologicalCore.GynaecologicalCoreTreatment[*].CancerTreatmentStartDate'
            ],
            recursive := true
        ) as TreatmentStartDateCancer,
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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_source_value%20field%20COSD%20V8%20GY%20Observation%20Cancer%20Treatment%20Intent%20mapping){: .btn }
### COSD V8 GY Observation Alcohol History Cancer In Last Three Months
* Value copied from `AlcoholHistoryCancerInLastThreeMonths`

* `AlcoholHistoryCancerInLastThreeMonths` Current history of alcohol consumption for the patient during a cancer care spell. [ALCOHOL HISTORY (CANCER IN LAST THREE MONTHS)](https://www.datadictionary.nhs.uk/data_elements/alcohol_history__cancer_in_last_three_months_.html)

```sql
select distinct
    Record ->> '$.Gynaecological.GynaecologicalCore.GynaecologicalCoreLinkagePatientId.NHSNumber.@extension'
        as NhsNumber,
    Record ->> '$.Gynaecological.GynaecologicalCore.GynaecologicalCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    Record ->> '$.Gynaecological.GynaecologicalCore.GynaecologicalCoreClinicalNurseSpecialistAndRiskFactorAssessments.AlcoholHistoryCancerInLastThreeMonths.@code'
        as AlcoholHistoryCancerInLastThreeMonths
from omop_staging.cosd_staging_81
where type = 'GY'
  and NhsNumber is not null
  and AlcoholHistoryCancerInLastThreeMonths is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_source_value%20field%20COSD%20V8%20GY%20Observation%20Alcohol%20History%20Cancer%20In%20Last%20Three%20Months%20mapping){: .btn }
### COSD V8 GY Observation Alcohol History Cancer Before Last Three Months
* Value copied from `AlcoholHistoryCancerBeforeLastThreeMonths`

* `AlcoholHistoryCancerBeforeLastThreeMonths` Past history of alcohol consumption for the patient during a cancer care spell. [ALCOHOL HISTORY (CANCER BEFORE LAST THREE MONTHS)](https://www.datadictionary.nhs.uk/data_elements/alcohol_history__cancer_before_last_three_months_.html)

```sql
select distinct
    Record ->> '$.Gynaecological.GynaecologicalCore.GynaecologicalCoreLinkagePatientId.NHSNumber.@extension'
        as NhsNumber,
    Record ->> '$.Gynaecological.GynaecologicalCore.GynaecologicalCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    Record ->> '$.Gynaecological.GynaecologicalCore.GynaecologicalCoreClinicalNurseSpecialistAndRiskFactorAssessments.AlcoholHistoryCancerBeforeLastThreeMonths.@code'
        as AlcoholHistoryCancerBeforeLastThreeMonths
from omop_staging.cosd_staging_81
where type = 'GY'
  and NhsNumber is not null
  and AlcoholHistoryCancerBeforeLastThreeMonths is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_source_value%20field%20COSD%20V8%20GY%20Observation%20Alcohol%20History%20Cancer%20Before%20Last%20Three%20Months%20mapping){: .btn }
### COSD V9 CT Observation Tobacco Smoking Cessation Treatment Indication Code
* Value copied from `TobaccoSmokingCessationTreatmentIndicationCode`

* `TobaccoSmokingCessationTreatmentIndicationCode` Indication of whether treatment was given to the patient for tobacco smoking cessation. [TOBACCO SMOKING CESSATION TREATMENT INDICATION CODE](https://www.datadictionary.nhs.uk/data_elements/tobacco_smoking_cessation_treatment_indication_code.html)

```sql
select distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension'
        as NhsNumber,
    Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    Record ->> '$.ClinicalNurseSpecialistAndRiskFactorAssessments.TobaccoSmokingCessation.@code'
        as TobaccoSmokingCessationTreatmentIndicationCode
from omop_staging.cosd_staging_901
where type = 'CT'
  and NhsNumber is not null
  and TobaccoSmokingCessationTreatmentIndicationCode is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_source_value%20field%20COSD%20V9%20CT%20Observation%20Tobacco%20Smoking%20Cessation%20Treatment%20Indication%20Code%20mapping){: .btn }
### COSD V9 CT Observation Smoking Status Cancer
* Value copied from `SmokingStatusCancer`

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
where type = 'CT'
  and NhsNumber is not null
  and SmokingStatusCancer is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_source_value%20field%20COSD%20V9%20CT%20Observation%20Smoking%20Status%20Cancer%20mapping){: .btn }
### COSD V9 CT Observation Performance Status Adult
* Value copied from `PerformanceStatusAdult`

* `PerformanceStatusAdult` A World Health Organisation classification indicating a person's status relating to activity or disability. [PERFORMANCE STATUS (ADULT)](https://www.datadictionary.nhs.uk/data_elements/performance_status__adult_.html)

```sql
select distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension'
        as NhsNumber,
    Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    Record ->> '$.PrimaryPathway.Diagnosis.PerformanceStatusAdult.@code'
        as PerformanceStatusAdult
from omop_staging.cosd_staging_901
where type = 'CT'
  and NhsNumber is not null
  and PerformanceStatusAdult is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_source_value%20field%20COSD%20V9%20CT%20Observation%20Performance%20Status%20Adult%20mapping){: .btn }
### COSD V9 CT Observation Familial Cancer Syndrome Indicator
* Value copied from `FamilialCancerSyndromeIndicator`

* `FamilialCancerSyndromeIndicator` Indicates whether there is a possible or confirmed familial cancer syndrome during a Cancer Care Spell. [FAMILIAL CANCER SYNDROME INDICATOR](https://www.datadictionary.nhs.uk/data_elements/familial_cancer_syndrome_indicator.html)

```sql
select distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension'
        as NhsNumber,
    Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    Record ->> '$.PrimaryPathway.Diagnosis.DiagnosisAdditionalItems.FamilialCancerSyndrome.@code'
        as FamilialCancerSyndromeIndicator
from omop_staging.cosd_staging_901
where type = 'CT'
  and NhsNumber is not null
  and FamilialCancerSyndromeIndicator is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_source_value%20field%20COSD%20V9%20CT%20Observation%20Familial%20Cancer%20Syndrome%20Indicator%20mapping){: .btn }
### COSD V9 CT Observation Cancer Treatment Intent
* Value copied from `CancerTreatmentIntent`

* `CancerTreatmentIntent` The intention of the cancer treatment provided during a Cancer Care Spell. [CANCER TREATMENT INTENT](https://www.datadictionary.nhs.uk/data_elements/cancer_treatment_intent.html)

```sql
with ct as (
    select
        Record ->> '$.LinkagePatientId.NhsNumber.@extension'
            as NhsNumber,
        unnest([
            [Record ->> '$.Treatment.CancerTreatmentIntent.@code'],
            Record ->> '$.Treatment[*].CancerTreatmentIntent.@code'
        ], recursive := true) as CancerTreatmentIntent,
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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_source_value%20field%20COSD%20V9%20CT%20Observation%20Cancer%20Treatment%20Intent%20mapping){: .btn }
### COSD V9 CT Observation Alcohol History Cancer In Last Three Months
* Value copied from `AlcoholHistoryCancerInLastThreeMonths`

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
where type = 'CT'
  and NhsNumber is not null
  and AlcoholHistoryCancerInLastThreeMonths is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_source_value%20field%20COSD%20V9%20CT%20Observation%20Alcohol%20History%20Cancer%20In%20Last%20Three%20Months%20mapping){: .btn }
### COSD V9 CT Observation Alcohol History Cancer Before Last Three Months
* Value copied from `AlcoholHistoryCancerBeforeLastThreeMonths`

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
where type = 'CT'
  and NhsNumber is not null
  and AlcoholHistoryCancerBeforeLastThreeMonths is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_source_value%20field%20COSD%20V9%20CT%20Observation%20Alcohol%20History%20Cancer%20Before%20Last%20Three%20Months%20mapping){: .btn }
### COSD V8 CT Observation Smoking Status Cancer
* Value copied from `SmokingStatusCancer`

* `SmokingStatusCancer` Used in the Cancer Outcomes and Services Data Set: Core to identify if the patient smokes tobacco only. [SMOKING STATUS (CANCER)](https://www.datadictionary.nhs.uk/data_elements/smoking_status__cancer_.html)

```sql
select distinct
    Record ->> '$.CTYA.CTYACore.CTYACoreLinkagePatientId.NHSNumber.@extension'
        as NhsNumber,
    Record ->> '$.CTYA.CTYACore.CTYACoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    Record ->> '$.CTYA.CTYACore.CTYACoreClinicalNurseSpecialistAndRiskFactorAssessments.SmokingStatusCode.@code'
        as SmokingStatusCancer
from omop_staging.cosd_staging_81
where type = 'CT'
  and NhsNumber is not null
  and SmokingStatusCancer is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_source_value%20field%20COSD%20V8%20CT%20Observation%20Smoking%20Status%20Cancer%20mapping){: .btn }
### COSD V8 CT Observation Performance Status Adult
* Value copied from `PerformanceStatusAdult`

* `PerformanceStatusAdult` A World Health Organisation classification indicating a person's status relating to activity or disability. [PERFORMANCE STATUS (ADULT)](https://www.datadictionary.nhs.uk/data_elements/performance_status__adult_.html)

```sql
select distinct
    Record ->> '$.CTYA.CTYACore.CTYACoreLinkagePatientId.NHSNumber.@extension'
        as NhsNumber,
    Record ->> '$.CTYA.CTYACore.CTYACoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    Record ->> '$.CTYA.CTYACore.CTYACoreDiagnosis.AdultPerformanceStatus.@code'
        as PerformanceStatusAdult
from omop_staging.cosd_staging_81
where type = 'CT'
  and NhsNumber is not null
  and PerformanceStatusAdult is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_source_value%20field%20COSD%20V8%20CT%20Observation%20Performance%20Status%20Adult%20mapping){: .btn }
### COSD V8 CT Observation Familial Cancer Syndrome Indicator
* Value copied from `FamilialCancerSyndromeIndicator`

* `FamilialCancerSyndromeIndicator` Indicates whether there is a possible or confirmed familial cancer syndrome during a Cancer Care Spell. [FAMILIAL CANCER SYNDROME INDICATOR](https://www.datadictionary.nhs.uk/data_elements/familial_cancer_syndrome_indicator.html)

```sql
select distinct
    Record ->> '$.CTYA.CTYACore.CTYACoreLinkagePatientId.NHSNumber.@extension'
        as NhsNumber,
    Record ->> '$.CTYA.CTYACore.CTYACoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    Record ->> '$.CTYA.CTYACore.CTYACoreDiagnosis.CTYACoreDiagnosisAdditionalItems.FamilialCancerSyndromeIndicator.@code'
        as FamilialCancerSyndromeIndicator
from omop_staging.cosd_staging_81
where type = 'CT'
  and NhsNumber is not null
  and FamilialCancerSyndromeIndicator is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_source_value%20field%20COSD%20V8%20CT%20Observation%20Familial%20Cancer%20Syndrome%20Indicator%20mapping){: .btn }
### COSD V8 CT Observation Alcohol History Cancer In Last Three Months
* Value copied from `AlcoholHistoryCancerInLastThreeMonths`

* `AlcoholHistoryCancerInLastThreeMonths` Current history of alcohol consumption for the patient during a cancer care spell. [ALCOHOL HISTORY (CANCER IN LAST THREE MONTHS)](https://www.datadictionary.nhs.uk/data_elements/alcohol_history__cancer_in_last_three_months_.html)

```sql
select distinct
    Record ->> '$.CTYA.CTYACore.CTYACoreLinkagePatientId.NHSNumber.@extension'
        as NhsNumber,
    Record ->> '$.CTYA.CTYACore.CTYACoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    Record ->> '$.CTYA.CTYACore.CTYACoreClinicalNurseSpecialistAndRiskFactorAssessments.AlcoholHistoryCancerInLastThreeMonths.@code'
        as AlcoholHistoryCancerInLastThreeMonths
from omop_staging.cosd_staging_81
where type = 'CT'
  and NhsNumber is not null
  and AlcoholHistoryCancerInLastThreeMonths is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_source_value%20field%20COSD%20V8%20CT%20Observation%20Alcohol%20History%20Cancer%20In%20Last%20Three%20Months%20mapping){: .btn }
### COSD V8 CT Observation Alcohol History Cancer Before Last Three Months
* Value copied from `AlcoholHistoryCancerBeforeLastThreeMonths`

* `AlcoholHistoryCancerBeforeLastThreeMonths` Past history of alcohol consumption for the patient during a cancer care spell. [ALCOHOL HISTORY (CANCER BEFORE LAST THREE MONTHS)](https://www.datadictionary.nhs.uk/data_elements/alcohol_history__cancer_before_last_three_months_.html)

```sql
select distinct
    Record ->> '$.CTYA.CTYACore.CTYACoreLinkagePatientId.NHSNumber.@extension'
        as NhsNumber,
    Record ->> '$.CTYA.CTYACore.CTYACoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    Record ->> '$.CTYA.CTYACore.CTYACoreClinicalNurseSpecialistAndRiskFactorAssessments.AlcoholHistoryCancerBeforeLastThreeMonths.@code'
        as AlcoholHistoryCancerBeforeLastThreeMonths
from omop_staging.cosd_staging_81
where type = 'CT'
  and NhsNumber is not null
  and AlcoholHistoryCancerBeforeLastThreeMonths is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_source_value%20field%20COSD%20V8%20CT%20Observation%20Alcohol%20History%20Cancer%20Before%20Last%20Three%20Months%20mapping){: .btn }
### COSD V9 CR Observation Tobacco Smoking Cessation Treatment Indication Code
* Value copied from `TobaccoSmokingCessationTreatmentIndicationCode`

* `TobaccoSmokingCessationTreatmentIndicationCode` Indication of whether treatment was given to the patient for tobacco smoking cessation. [TOBACCO SMOKING CESSATION TREATMENT INDICATION CODE](https://www.datadictionary.nhs.uk/data_elements/tobacco_smoking_cessation_treatment_indication_code.html)

```sql
select distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension'
        as NhsNumber,
    Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    Record ->> '$.ClinicalNurseSpecialistAndRiskFactorAssessments.TobaccoSmokingCessation.@code'
        as TobaccoSmokingCessationTreatmentIndicationCode
from omop_staging.cosd_staging_901
where type = 'CR'
  and NhsNumber is not null
  and TobaccoSmokingCessationTreatmentIndicationCode is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_source_value%20field%20COSD%20V9%20CR%20Observation%20Tobacco%20Smoking%20Cessation%20Treatment%20Indication%20Code%20mapping){: .btn }
### COSD V9 CR Observation Smoking Status Cancer
* Value copied from `SmokingStatusCancer`

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
where type = 'CR'
  and NhsNumber is not null
  and SmokingStatusCancer is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_source_value%20field%20COSD%20V9%20CR%20Observation%20Smoking%20Status%20Cancer%20mapping){: .btn }
### COSD V9 CR Observation Performance Status Adult
* Value copied from `PerformanceStatusAdult`

* `PerformanceStatusAdult` A World Health Organisation classification indicating a person's status relating to activity or disability. [PERFORMANCE STATUS (ADULT)](https://www.datadictionary.nhs.uk/data_elements/performance_status__adult_.html)

```sql
select distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension'
        as NhsNumber,
    Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    Record ->> '$.PrimaryPathway.Diagnosis.PerformanceStatusAdult.@code'
        as PerformanceStatusAdult
from omop_staging.cosd_staging_901
where type = 'CR'
  and NhsNumber is not null
  and PerformanceStatusAdult is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_source_value%20field%20COSD%20V9%20CR%20Observation%20Performance%20Status%20Adult%20mapping){: .btn }
### COSD V9 CR Observation Familial Cancer Syndrome Indicator
* Value copied from `FamilialCancerSyndromeIndicator`

* `FamilialCancerSyndromeIndicator` Indicates whether there is a possible or confirmed familial cancer syndrome during a Cancer Care Spell. [FAMILIAL CANCER SYNDROME INDICATOR](https://www.datadictionary.nhs.uk/data_elements/familial_cancer_syndrome_indicator.html)

```sql
select distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension'
        as NhsNumber,
    Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    Record ->> '$.PrimaryPathway.Diagnosis.DiagnosisAdditionalItems.FamilialCancerSyndrome.@code'
        as FamilialCancerSyndromeIndicator
from omop_staging.cosd_staging_901
where type = 'CR'
  and NhsNumber is not null
  and FamilialCancerSyndromeIndicator is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_source_value%20field%20COSD%20V9%20CR%20Observation%20Familial%20Cancer%20Syndrome%20Indicator%20mapping){: .btn }
### COSD V9 CR Observation Cancer Treatment Intent
* Value copied from `CancerTreatmentIntent`

* `CancerTreatmentIntent` The intention of the cancer treatment provided during a Cancer Care Spell. [CANCER TREATMENT INTENT](https://www.datadictionary.nhs.uk/data_elements/cancer_treatment_intent.html)

```sql
with cr as (
    select
        Record ->> '$.LinkagePatientId.NhsNumber.@extension'
            as NhsNumber,
        unnest([
            [Record ->> '$.Treatment.CancerTreatmentIntent.@code'],
            Record ->> '$.Treatment[*].CancerTreatmentIntent.@code'
        ], recursive := true) as CancerTreatmentIntent,
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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_source_value%20field%20COSD%20V9%20CR%20Observation%20Cancer%20Treatment%20Intent%20mapping){: .btn }
### COSD V9 CR Observation Alcohol History Cancer In Last Three Months
* Value copied from `AlcoholHistoryCancerInLastThreeMonths`

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
where type = 'CR'
  and NhsNumber is not null
  and AlcoholHistoryCancerInLastThreeMonths is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_source_value%20field%20COSD%20V9%20CR%20Observation%20Alcohol%20History%20Cancer%20In%20Last%20Three%20Months%20mapping){: .btn }
### COSD V9 CR Observation Alcohol History Cancer Before Last Three Months
* Value copied from `AlcoholHistoryCancerBeforeLastThreeMonths`

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
where type = 'CR'
  and NhsNumber is not null
  and AlcoholHistoryCancerBeforeLastThreeMonths is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_source_value%20field%20COSD%20V9%20CR%20Observation%20Alcohol%20History%20Cancer%20Before%20Last%20Three%20Months%20mapping){: .btn }
### COSD V8 CR Observation Smoking Status Cancer
* Value copied from `SmokingStatusCancer`

* `SmokingStatusCancer` Used in the Cancer Outcomes and Services Data Set: Core to identify if the patient smokes tobacco only. [SMOKING STATUS (CANCER)](https://www.datadictionary.nhs.uk/data_elements/smoking_status__cancer_.html)

```sql
select distinct
    Record ->> '$.Core.CoreCore.CoreLinkagePatientId.NHSNumber.@extension'
        as NhsNumber,
    Record ->> '$.Core.CoreCore.CoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    Record ->> '$.Core.CoreCore.CoreClinicalNurseSpecialistAndRiskFactorAssessments.SmokingStatusCode.@code'
        as SmokingStatusCancer
from omop_staging.cosd_staging_81
where type = 'CR'
  and NhsNumber is not null
  and SmokingStatusCancer is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_source_value%20field%20COSD%20V8%20CR%20Observation%20Smoking%20Status%20Cancer%20mapping){: .btn }
### COSD V8 CR Observation Performance Status Adult
* Value copied from `PerformanceStatusAdult`

* `PerformanceStatusAdult` A World Health Organisation classification indicating a person's status relating to activity or disability. [PERFORMANCE STATUS (ADULT)](https://www.datadictionary.nhs.uk/data_elements/performance_status__adult_.html)

```sql
select distinct
    Record ->> '$.Core.CoreCore.CoreLinkagePatientId.NHSNumber.@extension'
        as NhsNumber,
    Record ->> '$.Core.CoreCore.CoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    Record ->> '$.Core.CoreCore.CoreDiagnosis.AdultPerformanceStatus.@code'
        as PerformanceStatusAdult
from omop_staging.cosd_staging_81
where type = 'CR'
  and NhsNumber is not null
  and PerformanceStatusAdult is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_source_value%20field%20COSD%20V8%20CR%20Observation%20Performance%20Status%20Adult%20mapping){: .btn }
### COSD V8 CR Observation Cancer Treatment Intent
* Value copied from `CancerTreatmentIntent`

* `CancerTreatmentIntent` The intention of the cancer treatment provided during a Cancer Care Spell. [CANCER TREATMENT INTENT](https://www.datadictionary.nhs.uk/data_elements/cancer_treatment_intent.html)

```sql
with cr as (
    select
        Record ->> '$.Core.CoreCore.CoreLinkagePatientId.NHSNumber.@extension'
            as NhsNumber,
        unnest([
            [Record ->> '$.Core.CoreCore.CoreTreatment.CancerTreatmentIntent.@code'],
            Record ->> '$.Core.CoreCore.CoreTreatment[*].CancerTreatmentIntent.@code'
        ], recursive := true) as CancerTreatmentIntent,
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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_source_value%20field%20COSD%20V8%20CR%20Observation%20Cancer%20Treatment%20Intent%20mapping){: .btn }
### COSD V8 CR Observation Alcohol History Cancer In Last Three Months
* Value copied from `AlcoholHistoryCancerInLastThreeMonths`

* `AlcoholHistoryCancerInLastThreeMonths` Current history of alcohol consumption for the patient during a cancer care spell. [ALCOHOL HISTORY (CANCER IN LAST THREE MONTHS)](https://www.datadictionary.nhs.uk/data_elements/alcohol_history__cancer_in_last_three_months_.html)

```sql
select distinct
    Record ->> '$.Core.CoreCore.CoreLinkagePatientId.NHSNumber.@extension'
        as NhsNumber,
    Record ->> '$.Core.CoreCore.CoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    Record ->> '$.Core.CoreCore.CoreClinicalNurseSpecialistAndRiskFactorAssessments.AlcoholHistoryCancerInLastThreeMonths.@code'
        as AlcoholHistoryCancerInLastThreeMonths
from omop_staging.cosd_staging_81
where type = 'CR'
  and NhsNumber is not null
  and AlcoholHistoryCancerInLastThreeMonths is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_source_value%20field%20COSD%20V8%20CR%20Observation%20Alcohol%20History%20Cancer%20In%20Last%20Three%20Months%20mapping){: .btn }
### COSD V8 CR Observation Alcohol History Cancer Before Last Three Months
* Value copied from `AlcoholHistoryCancerBeforeLastThreeMonths`

* `AlcoholHistoryCancerBeforeLastThreeMonths` Past history of alcohol consumption for the patient during a cancer care spell. [ALCOHOL HISTORY (CANCER BEFORE LAST THREE MONTHS)](https://www.datadictionary.nhs.uk/data_elements/alcohol_history__cancer_before_last_three_months_.html)

```sql
select distinct
    Record ->> '$.Core.CoreCore.CoreLinkagePatientId.NHSNumber.@extension'
        as NhsNumber,
    Record ->> '$.Core.CoreCore.CoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    Record ->> '$.Core.CoreCore.CoreClinicalNurseSpecialistAndRiskFactorAssessments.AlcoholHistoryCancerBeforeLastThreeMonths.@code'
        as AlcoholHistoryCancerBeforeLastThreeMonths
from omop_staging.cosd_staging_81
where type = 'CR'
  and NhsNumber is not null
  and AlcoholHistoryCancerBeforeLastThreeMonths is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_source_value%20field%20COSD%20V8%20CR%20Observation%20Alcohol%20History%20Cancer%20Before%20Last%20Three%20Months%20mapping){: .btn }
### COSD V9 BA Observation Performance Status Adult
* Value copied from `PerformanceStatusAdult`

* `PerformanceStatusAdult` A World Health Organisation classification indicating a person's status relating to activity or disability. [PERFORMANCE STATUS (ADULT)](https://www.datadictionary.nhs.uk/data_elements/performance_status__adult_.html)

```sql
select distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension'
        as NhsNumber,
    Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    Record ->> '$.PrimaryPathway.Diagnosis.PerformanceStatusAdult.@code'
        as PerformanceStatusAdult
from omop_staging.cosd_staging_901
where type = 'BA'
  and NhsNumber is not null
  and PerformanceStatusAdult is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_source_value%20field%20COSD%20V9%20BA%20Observation%20Performance%20Status%20Adult%20mapping){: .btn }
### COSD V9 BA Observation Cancer Treatment Intent
* Value copied from `CancerTreatmentIntent`

* `CancerTreatmentIntent` The intention of the cancer treatment provided during a Cancer Care Spell. [CANCER TREATMENT INTENT](https://www.datadictionary.nhs.uk/data_elements/cancer_treatment_intent.html)

```sql
with ba as (
    select
        Record ->> '$.LinkagePatientId.NhsNumber.@extension'
            as NhsNumber,
        unnest([
            [Record ->> '$.Treatment.CancerTreatmentIntent.@code'],
            Record ->> '$.Treatment[*].CancerTreatmentIntent.@code'
        ], recursive := true) as CancerTreatmentIntent,
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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_source_value%20field%20COSD%20V9%20BA%20Observation%20Cancer%20Treatment%20Intent%20mapping){: .btn }
### COSD V8 BA Observation Performance Status Adult
* Value copied from `PerformanceStatusAdult`

* `PerformanceStatusAdult` A World Health Organisation classification indicating a person's status relating to activity or disability. [PERFORMANCE STATUS (ADULT)](https://www.datadictionary.nhs.uk/data_elements/performance_status__adult_.html)

```sql
select distinct
    Record ->> '$.CNS.CNSCore.CNSCoreLinkagePatientId.NHSNumber.@extension'
        as NhsNumber,
    Record ->> '$.CNS.CNSCore.CNSCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis'
        as DateOfPrimaryDiagnosisClinicallyAgreed,
    Record ->> '$.CNS.CNSCore.CNSCoreDiagnosis.AdultPerformanceStatus.@code'
        as PerformanceStatusAdult
from omop_staging.cosd_staging_81
where type = 'BA'
  and NhsNumber is not null
  and PerformanceStatusAdult is not null
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_source_value%20field%20COSD%20V8%20BA%20Observation%20Performance%20Status%20Adult%20mapping){: .btn }
### COSD V8 BA Observation Cancer Treatment Intent
* Value copied from `CancerTreatmentIntent`

* `CancerTreatmentIntent` The intention of the cancer treatment provided during a Cancer Care Spell. [CANCER TREATMENT INTENT](https://www.datadictionary.nhs.uk/data_elements/cancer_treatment_intent.html)

```sql
with ba as (
    select
        Record ->> '$.CNS.CNSCore.CNSCoreLinkagePatientId.NHSNumber.@extension'
            as NhsNumber,
        unnest([
            [Record ->> '$.CNS.CNSCore.CNSCoreTreatment.CancerTreatmentIntent.@code'],
            Record ->> '$.CNS.CNSCore.CNSCoreTreatment[*].CancerTreatmentIntent.@code'
        ], recursive := true) as CancerTreatmentIntent,
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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20Observation%20table%20value_source_value%20field%20COSD%20V8%20BA%20Observation%20Cancer%20Treatment%20Intent%20mapping){: .btn }
