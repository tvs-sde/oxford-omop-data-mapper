---
layout: default
title: condition_source_concept_id
parent: ConditionOccurrence
grand_parent: Transformation Documentation
has_toc: false
---
# condition_source_concept_id
### SUS Outpatient Condition Occurrence
Source column  `DiagnosisICD`.
Resolve ICD10 codes to standard or non standard OMOP concepts. If code cannot be mapped, map using the parent code.

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
	order by
		d.DiagnosisICD,
		op.GeneratedRecordIdentifier,
		op.NHSNumber,
		op.CDSActivityDate
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_source_concept_id%20field%20SUS%20Outpatient%20Condition%20Occurrence%20mapping){: .btn }
### SUS Inpatient Condition Occurrence
Source column  `DiagnosisICD`.
Resolve ICD10 codes to standard or non standard OMOP concepts. If code cannot be mapped, map using the parent code.

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_source_concept_id%20field%20SUS%20Inpatient%20Condition%20Occurrence%20mapping){: .btn }
### SUS Inpatient Condition Occurrence
Source column  `AccidentAndEmergencyDiagnosis`.
Accident and Emergency Diagnosis to OMOP Condition Concept IDs


|AccidentAndEmergencyDiagnosis|condition_source_concept_id|notes|
|------|-----|-----|
|01 02|4179823|Laceration of Head|
|01 03|443419|Laceration of Face|
|01 07|443419|Laceration of Mouth, Jaw, Teeth|
|01 09|4151524|Laceration of Neck|
|01 10|4151525|Laceration of Shoulder|
|01 12|4152933|Laceration of Upper Arm|
|01 13|4151527|Laceration of Elbow|
|01 14|4155034|Laceration of Forearm|
|01 16|4113008|Laceration of Hand|
|01 17|443419|Laceration of Digit|
|01 22|443419|Laceration of Chest|
|01 24|4152935|Laceration of Abdomen|
|01 25|443419|Laceration of Back/buttocks|
|01 26|443419|Laceration of Ano/rectal|
|01 30|4152936|Laceration of Thigh|
|01 31|4155039|Laceration of Knee|
|01 32|4155040|Laceration of Lower leg|
|01 34|4109685|Laceration of Foot|
|01 35|4107674|Laceration of Toe|
|02 02|42536696|Contusion of Head|
|02 03|4054068|Contusion of Face|
|02 05|4174369|Contusion of Ear|
|02 06|4246724|Contusion of Nose|
|02 09|4310238|Contusion of Neck|
|02 10|441737|Contusion of Shoulder|
|02 12|73923|Contusion of Upper Arm|
|02 13|78605|Contusion of Elbow|
|02 14|140273|Contusion of Forearm|
|02 15|81186|Contusion of Wrist|
|02 16|81723|Contusion of Hand|
|02 17|441737|Contusion of Digit|
|02 21|4033717|Contusion of Pelvis|
|02 22|81175|Contusion of Chest|
|02 24|1245923|Contusion of Abdomen|
|02 25|441737|Contusion of Back/buttocks|
|02 26|441737|Contusion of Ano/rectal|
|02 28|195401|Contusion of Hip|
|02 30|436278|Contusion of Thigh|
|02 31|78619|Contusion of Knee|
|02 32|77734|Contusion of Lower leg|
|02 33|80573|Contusion of Ankle|
|02 34|73090|Contusion of Foot|
|02 35|74816|Contusion of Toe|
|02136|433071|Contusion of Multiple Site|
|03|376208|Soft tissue inflammation|
|03 10|376208|Soft tissue inflammation of Shoulder|
|03 22|376208|Soft tissue inflammation of Chest|
|03 24|376208|Soft tissue inflammation of Abdomen|
|03 27|376208|Soft tissue inflammation of Genitalia|
|03 28|376208|Soft tissue inflammation of Hip|
|04 01|375415|Head injury of Brain|
|04 02|375415|Head injury of Head|
|04 03|375415|Head injury of Face|
|04 04|375415|Head injury of Eye|
|04 07|375415|Head injury of Mouth, Jaw, Teeth|
|05 03|74726|Dislocation of Face|
|05 12|74726|Dislocation of Upper Arm|
|05 13|74726|Dislocation of Elbow|
|05 16|74726|Dislocation of Hand|
|05 17|74726|Dislocation of Digit|
|05 19|74726|Dislocation of Thoracic|
|05 21|74726|Dislocation of Pelvis|
|05 24|74726|Dislocation of Abdomen|
|05 31|74726|Dislocation of Knee|
|05 32|74726|Dislocation of Lower leg|
|05 34|4050079|Dislocation of Foot|
|05 35|4004143|Dislocation of Toe|
|05110|74726|Dislocation of Shoulder|
|05113|74726|Dislocation of Elbow|
|05115|3654438|Dislocation of Wrist|
|05116|74726|Dislocation of Hand|
|05117|74726|Dislocation of Digit|
|05118|438889|Dislocation of Cervical spine|
|05128|74726|Dislocation of Hip|
|05131|74726|Dislocation of Knee|
|05133|74726|Dislocation of Ankle|
|05135|4004143|Dislocation of Toe|
|05202|45766773|Open fracture of Head|
|05203|4264281|Open fracture of Face|
|05206|4206244|Open fracture of Nose|
|05210|4264281|Open fracture of Shoulder|
|05212|4079931|Open fracture of Upper Arm|
|05213|37209103|Open fracture of Elbow|
|05214|440851|Open fracture of Forearm|
|05216|45766773|Open fracture of Hand|
|05217|4264281|Open fracture of Digit|
|05218|443248|Open fracture of Cervical spine|
|05221|75932|Open fracture of Pelvis|
|05222|4264281|Open fracture of Chest|
|05225|4264281|Open fracture of Back/buttocks|
|05230|4263628|Open fracture of Thigh|
|05231|4206244|Open fracture of Knee|
|05232|4186548|Open fracture of Lower leg|
|05233|78888|Open fracture of Ankle|
|05234|435101|Open fracture of Foot|
|05235|4206244|Open fracture of Toe|
|05302|45772685|Closed fracture of Head|
|05303|4286936|Closed fracture of Face|
|05306|4307254|Closed fracture of Nose|
|05310|45766940|Closed fracture of Shoulder|
|05312|4282857|Closed fracture of Upper Arm|
|05313|760525|Closed fracture of Elbow|
|05314|441974|Closed fracture of Forearm|
|05316|45772685|Closed fracture of Hand|
|05317|4307254|Closed fracture of Digit|
|05318|437993|Closed fracture of Cervical spine|
|05319|4307254|Closed fracture of Thoracic|
|05320|4307254|Closed fracture of Lumbosacral spine|
|05321|77129|Closed fracture of Pelvis|
|05322|4307254|Closed fracture of Chest|
|05325|4307254|Closed fracture of Back/buttocks|
|05328|4230399|Closed fracture of Hip|
|05330|4230399|Closed fracture of Thigh|
|05331|4307254|Closed fracture of Knee|
|05332|4211657|Closed fracture of Lower leg|
|05333|75095|Closed fracture of Ankle|
|05334|441980|Closed fracture of Foot|
|05335|4307254|Closed fracture of Toe|
|05505|4096479|Amputation of Ear|
|05507|4096479|Amputation of Mouth, Jaw, Teeth|
|05517|4096479|Amputation of Digit|
|06 10|4136228|Sprain of Shoulder|
|06 13|4138284|Sprain of Elbow|
|06 15|78272|Sprain of Wrist|
|06 16|73045|Sprain of Hand|
|06 17|4134309|Sprain of Digit|
|06 18|36713170|Sprain of Cervical spine|
|06 19|315947|Sprain of Thoracic|
|06 28|441701|Sprain of Hip|
|06 31|4207505|Sprain of Knee|
|06 33|81151|Sprain of Ankle|
|06 34|436253|Sprain of Foot|
|06 35|36712848|Sprain of Toe|
|07|4194894|Tendon injury|
|07 09|4194894|Tendon injury of Neck|
|07 10|4194894|Tendon injury of Shoulder|
|07 12|4194894|Tendon injury of Upper Arm|
|07 14|4194894|Tendon injury of Forearm|
|07 15|4194894|Tendon injury of Wrist|
|07 16|4134947|Tendon injury of Hand|
|07 17|4194894|Tendon injury of Digit|
|07 18|4194894|Tendon injury of Cervical spine|
|07 20|4194894|Tendon injury of Lumbosacral spine|
|07 30|4194894|Tendon injury of Thigh|
|07 31|4194894|Tendon injury of Knee|
|07 32|4194894|Tendon injury of Lower leg|
|07 33|4194894|Tendon injury of Ankle|
|07 34|4194894|Tendon injury of Foot|
|07 35|4194894|Tendon injury of Toe|
|09|192763|Vascular injury|
|10|442013|Burns|
|10 02|442013|Burns of Head|
|10 03|4096477|Burns of Face|
|10 04|442013|Burns of Eye|
|10 08|4111364|Burns of Throat|
|10 09|26286|Burns of Neck|
|10 10|73913|Burns of Shoulder|
|10 12|76304|Burns of Upper Arm|
|10 14|133655|Burns of Forearm|
|10 16|75426|Burns of Hand|
|10 17|442013|Burns of Digit|
|10 25|442013|Burns of Back/buttocks|
|10 26|442013|Burns of Ano/rectal|
|10 30|433915|Burns of Thigh|
|10 31|72516|Burns of Knee|
|10 32|75121|Burns of Lower leg|
|10 34|74250|Burns of Foot|
|10 35|80295|Burns of Toe|
|12|4053838|Foreign body|
|12 05|4053838|Foreign body of Ear|
|12 06|256571|Foreign body of Nose|
|12 08|4053838|Foreign body of Throat|
|12 17|4053838|Foreign body of Digit|
|12 26|4053838|Foreign body of Ano/rectal|
|12 27|4053838|Foreign body of Genitalia|
|12 36|4053838|Foreign body of Multiple Site|
|14|442562|Poisoning|
|144|436585|Other, including alcohol|
|14436|436585|Other, including alcohol of Multiple Site|
|15|439973|Near drowning|
|16|193631|Visceral injury|
|16 22|193631|Visceral injury of Chest|
|17|432250|Infectious Disease|
|171|432250|Notifiable disease|
|172|432250|Non-notifiable disease|
|17208|432250|Non-notifiable disease of Throat|
|17234|432250|Non-notifiable disease of Foot|
|17236|432250|Non-notifiable disease of Multiple Site|
|18|4170116|Local infection|
|18 23|4297984|Local infection of Breast|
|18 36|4297984|Local infection of Multiple Site|
|19|132797|Septicaemia|
|201|4323202|Myocardial ischaemia & infarction|
|202|40479593|Other non-ischaemia|
|20236|40479593|Other non-ischaemia of Multiple Site|
|21|381316|Cerebro-vascular condition|
|21 02|381316|Cerebro-vascular condition of Head|
|22|443784|Other vascular condition|
|22 19|443784|Other vascular condition of Thoracic|
|22 24|443784|Other vascular condition of Abdomen|
|23|36716893|Haematological|
|24|373087|Central Nervous System|
|241|380378|Epilepsy|
|242|380378|Other non-epilepsy|
|24236|380378|Other non-epilepsy of Multiple Site|
|251|317009|Bronchial asthma|
|252|320136|Other non-asthma|
|25222|320136|Other non-asthma of Chest|
|26|200447|Gastrointestinal condition|
|26 08|200447|Gastrointestinal condition of Throat|
|26 24|200447|Gastrointestinal condition of Abdomen|
|261|192671|Haemorrhage|
|262|4023573|Acute abdominal pain|
|26324|200447|Other of Abdomen|
|27|201337|Urological|
|27 27|201337|Urological of Genitalia|
|28|4150758|Obstetric|
|28 27|4150758|Obstetric of Genitalia|
|29|4028934|Gynaecological|
|29 21|4028934|Gynaecological of Pelvis|
|29 29|4028934|Gynaecological of Groin|
|30|201820|Diabetes|
|301|201820|Diabetic|
|302|31821|Other non-diabetic|
|31|4317258|Dermatological|
|32|36683564|Allergy|
|33|4134585|Facio-maxillary|
|33 02|4134585|Facio-maxillary of Head|
|33 07|4134585|Facio-maxillary of Mouth, Jaw, Teeth|
|34|4339468|Ear, Nose & Throat|
|34 05|4339468|Ear, Nose & Throat of Ear|
|34 06|4339468|Ear, Nose & Throat of Nose|
|34 08|4339468|Ear, Nose & Throat of Throat|
|35|432586|Mental disorder|
|36 04|373499|Ophthalmological of Eye|
|37|439437|Social problem|
|38||Diagnosis not classifiable|
|39||Nothing abnormal detected|

Notes
* [ACCIDENT and EMERGENCY CLINICAL CODES](https://archive.datadictionary.nhs.uk/DD%20Release%20September%202020/supporting_information/accident_and_emergency_diagnosis_tables.html)
* [OMOP Conditions](https://athena.ohdsi.org/search-terms/terms?domain=Condition&invalidReason=Valid&standardConcept=Standard&vocabulary=SNOMED&page=1&pageSize=15&query=)

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
			ae.CDSActivityDate
	from omop_staging.sus_AE_diagnosis d
		inner join omop_staging.sus_AE ae
			on d.MessageId = ae.MessageId
	where ae.NHSNumber is not null
	order by
		d.AccidentAndEmergencyDiagnosis,
		ae.GeneratedRecordIdentifier,
		ae.NHSNumber,
		ae.CDSActivityDate
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_source_concept_id%20field%20SUS%20Inpatient%20Condition%20Occurrence%20mapping){: .btn }
### SACT Condition Occurrence
Source column  `Primary_Diagnosis`.
Resolve ICD10 codes to standard or non standard OMOP concepts. If code cannot be mapped, map using the parent code.

* `Primary_Diagnosis` PRIMARY DIAGNOSIS (ICD AT START SYSTEMIC ANTI-CANCER THERAPY) is the PRIMARY DIAGNOSIS (ICD) at the start of the Systemic Anti-Cancer Therapy. [PRIMARY DIAGNOSIS (ICD AT START SYSTEMIC ANTI-CANCER THERAPY)](https://www.datadictionary.nhs.uk/data_elements/primary_diagnosis__icd_at_start_systemic_anti-cancer_therapy_.html)

```sql
	select
		Primary_Diagnosis,
		replace(NHS_Number, ' ', '') as NHS_Number,
		min(Administration_Date) as Administration_Date
	from omop_staging.sact_staging
	group by
		Primary_Diagnosis,
		NHS_Number
	order by
		NHS_Number,
		Primary_Diagnosis,
		min(Administration_Date)
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_source_concept_id%20field%20SACT%20Condition%20Occurrence%20mapping){: .btn }
### Rtds Condition Occurrence
Source column  `DiagnosisCode`.
Resolve ICD10 codes to standard or non standard OMOP concepts. If code cannot be mapped, map using the parent code.

* `DiagnosisCode` ICD10 Diagnosis Code []()

```sql
with results as (
	select 
		distinct
			(select PatientId from omop_staging.rtds_1_demographics d where d.PatientSer = dc.PatientSer limit 1) as PatientId,
			dc.DiagnosisCode,
			dc.DateStamp as event_start_date,
			dc.DateStamp as event_end_date
	from omop_staging.RTDS_5_Diagnosis_Course dc
	where dc.DiagnosisTableName = 'ICD-10'
)
select
	PatientId,
	DiagnosisCode,
	event_start_date,
	event_end_date
from results
where
    PatientId is not null
    and regexp_matches(patientid, '\d{10}');
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_source_concept_id%20field%20Rtds%20Condition%20Occurrence%20mapping){: .btn }
### Oxford Condition Occurrence
Source column  `SuppliedCode`.
Resolve Snomed codes to OMOP concepts.

* `SuppliedCode`  

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


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_source_concept_id%20field%20Oxford%20Condition%20Occurrence%20mapping){: .btn }
### COSD V9 Lung Condition Occurrence Recurrence
Source column  `NonPrimaryRecurrenceOriginalDiagnosis`.
Resolve ICD10 codes to standard or non standard OMOP concepts. If code cannot be mapped, map using the parent code.

* `NonPrimaryRecurrenceOriginalDiagnosis` ORIGINAL PRIMARY DIAGNOSIS (ICD) is the International Classification of Diseases (ICD) code of the original PATIENT DIAGNOSIS relating to the cancer recurrence. [ORIGINAL PRIMARY DIAGNOSIS (ICD)]()

```sql
select
    distinct
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
        Record ->> '$.NonPrimaryPathway.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed' as DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
        Record ->> '$.NonPrimaryPathway.Recurrence.OriginalPrimaryDiagnosisIcd.@code' as NonPrimaryRecurrenceOriginalDiagnosis
from omop_staging.cosd_staging_901
where type = 'LU'
  and NonPrimaryRecurrenceOriginalDiagnosis is not null
  and DateOfNonPrimaryCancerDiagnosisClinicallyAgreed is not null
  and NhsNumber is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_source_concept_id%20field%20COSD%20V9%20Lung%20Condition%20Occurrence%20Recurrence%20mapping){: .btn }
### COSD V9 Lung Condition Occurrence Progression
Source column  `NonPrimaryProgressionOriginalDiagnosis`.
Resolve ICD10 codes to standard or non standard OMOP concepts. If code cannot be mapped, map using the parent code.

* `NonPrimaryProgressionOriginalDiagnosis` CANCER PROGRESSION (ICD ORIGINAL) is the International Classification of Diseases (ICD) code of the original PATIENT DIAGNOSIS of the Cancer Progression. [CANCER PROGRESSION (ICD ORIGINAL)](https://www.datadictionary.nhs.uk/data_elements/cancer_progression__icd_original_.html)

```sql
select distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
    Record ->> '$.NonPrimaryPathway.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed' as NonPrimaryDiagnosisDate,
    Record ->> '$.NonPrimaryPathway.Progression.ProgressionIcd.@code' as NonPrimaryProgressionOriginalDiagnosis
from omop_staging.cosd_staging_901
where type = 'LU'
  and NonPrimaryProgressionOriginalDiagnosis is not null
  and NonPrimaryDiagnosisDate is not null
  and NhsNumber is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_source_concept_id%20field%20COSD%20V9%20Lung%20Condition%20Occurrence%20Progression%20mapping){: .btn }
### COSD V8 Lung Condition Occurrence Progression
Source column  `NonPrimaryProgressionOriginalDiagnosis`.
Resolve ICD10 codes to standard or non standard OMOP concepts. If code cannot be mapped, map using the parent code.

* `NonPrimaryProgressionOriginalDiagnosis` CANCER PROGRESSION (ICD ORIGINAL) is the International Classification of Diseases (ICD) code of the original PATIENT DIAGNOSIS of the Cancer Progression. [CANCER PROGRESSION (ICD ORIGINAL)](https://www.datadictionary.nhs.uk/data_elements/cancer_progression__icd_original_.html)

```sql
select distinct
    Record ->> '$.Lung.LungCore.LungCoreLinkagePatientId.NHSNumber.@extension' as NHSNumber,
    Record ->> '$.Lung.LungCore.LungCoreLinkageDiagnosticDetails.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed' as NonPrimaryDiagnosisDate,
    Record ->> '$.Lung.LungCore.LungCoreNonPrimaryCancerPathwayRoute.CancerProgressionICD.@code' as NonPrimaryProgressionOriginalDiagnosis
from omop_staging.cosd_staging_81
where type = 'LU'
  and NonPrimaryProgressionOriginalDiagnosis is not null
  and NonPrimaryDiagnosisDate is not null
  and NhsNumber is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_source_concept_id%20field%20COSD%20V8%20Lung%20Condition%20Occurrence%20Progression%20mapping){: .btn }
### COSD V8 Lung Condition Occurrence Primary Diagnosis
Source column  `CancerDiagnosis`.
Resolve ICD10 codes to standard or non standard OMOP concepts. If code cannot be mapped, map using the parent code.

* `CancerDiagnosis` The primary diagnosis code for the cancer. [PRIMARY DIAGNOSIS]()

```sql
with lung as (
  select 
    Record ->> '$.Lung.LungCore.LungCoreLinkagePatientId.NHSNumber.@extension' as NHSNumber,
    Record ->> '$.Lung.LungCore.LungCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as DiagnosisDate,
    Record ->> '$.Lung.LungCore.LungCoreLinkageDiagnosticDetails.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed' as NonPrimaryDiagnosisDate,
    Record ->> '$.Lung.LungCore.LungCoreDiagnosis.MorphologyICDODiagnosis.@code' as CancerHistology,
    Record ->> '$.Lung.LungCore.LungCoreDiagnosis.TopographyICDO.@code' as CancerTopography,
    Record ->> '$.Lung.LungCore.LungCoreLinkageDiagnosticDetails.PrimaryDiagnosis.@code'as CancerDiagnosis
  from omop_staging.cosd_staging_81 lu
where lu.Type = 'LU'
)

select
distinct
  NHSNumber,
  coalesce(DiagnosisDate, NonPrimaryDiagnosisDate) as DiagnosisDate,
  CancerHistology,
  CancerTopography,
  CancerDiagnosis
from lung
where NHSNumber is not null;

	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_source_concept_id%20field%20COSD%20V8%20Lung%20Condition%20Occurrence%20Primary%20Diagnosis%20mapping){: .btn }
### COSD V8 Lung Condition Occurrence Primary Diagnosis Histology Topography
Source columns  `CancerHistology`, `CancerTopography`.
Resolve ICD-o-3 codes to OMOP concepts.

* `CancerHistology` MORPHOLOGY (ICD-O CANCER TRANSFORMATION) is the morphology code of the Cancer Transformation using the ICD-O CODE. [MORPHOLOGY (ICD-O CANCER TRANSFORMATION)](https://www.datadictionary.nhs.uk/data_elements/morphology__icd-o_cancer_transformation_.html)

* `CancerTopography` TOPOGRAPHY (ICD-O) is the topographical site of the Tumour using the ICD-O CODE. [TOPOGRAPHY (ICD-O)](https://www.datadictionary.nhs.uk/data_elements/topography__icd-o_.html)

```sql
with lung as (
  select 
    Record ->> '$.Lung.LungCore.LungCoreLinkagePatientId.NHSNumber.@extension' as NHSNumber,
    Record ->> '$.Lung.LungCore.LungCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as DiagnosisDate,
    Record ->> '$.Lung.LungCore.LungCoreLinkageDiagnosticDetails.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed' as NonPrimaryDiagnosisDate,
    Record ->> '$.Lung.LungCore.LungCoreDiagnosis.MorphologyICDODiagnosis.@code' as CancerHistology,
    Record ->> '$.Lung.LungCore.LungCoreDiagnosis.TopographyICDO.@code' as CancerTopography,
    Record ->> '$.Lung.LungCore.LungCoreLinkageDiagnosticDetails.PrimaryDiagnosis.@code'as CancerDiagnosis
  from omop_staging.cosd_staging_81 lu
where lu.Type = 'LU'
)

select
distinct
  NHSNumber,
  coalesce(DiagnosisDate, NonPrimaryDiagnosisDate) as DiagnosisDate,
  CancerHistology,
  CancerTopography,
  CancerDiagnosis
from lung
where NHSNumber is not null
  and CancerHistology is not null
  and CancerTopography is not null;

	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_source_concept_id%20field%20COSD%20V8%20Lung%20Condition%20Occurrence%20Primary%20Diagnosis%20Histology%20Topography%20mapping){: .btn }
### Cosd V8 CTYA Condition Occurrence Primary Diagnosis
Source column  `CancerDiagnosis`.
Resolve ICD10 codes to standard or non standard OMOP concepts. If code cannot be mapped, map using the parent code.

* `CancerDiagnosis` PRIMARY DIAGNOSIS (ICD) is the International Classification of Diseases (ICD) code used to identify the PRIMARY DIAGNOSIS. [PRIMARY DIAGNOSIS (ICD)](https://www.datadictionary.nhs.uk/data_elements/primary_diagnosis__icd_.html)

```sql
with ct as (
  select 
    Record ->> '$.CTYA.CTYACore.CTYACoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
    Record ->> '$.CTYA.CTYACore.CTYACoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as DiagnosisDate,
    Record ->> '$.CTYA.CTYACore.CTYACoreLinkageDiagnosticDetails.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed' as NonPrimaryDiagnosisDate,
    Record ->> '$.CTYA.CTYACore.CTYACoreDiagnosis.MorphologyICDODiagnosis.@code' as CancerHistology,
    Record ->> '$.CTYA.CTYACore.CTYACoreDiagnosis.TopographyICDO.@code' as CancerTopography,
    Record ->> '$.CTYA.CTYACore.CTYACoreDiagnosis.BasisOfCancerDiagnosis.@code' as BasisOfDiagnosisCancer,
    Record ->> '$.CTYA.CTYACore.CTYACoreLinkageDiagnosticDetails.PrimaryDiagnosis.@code' as CancerDiagnosis
  from omop_staging.cosd_staging_81 co
where co.Type = 'CT'
)
select 
	distinct
		NhsNumber,
		coalesce (DiagnosisDate, NonPrimaryDiagnosisDate) as DiagnosisDate,
		BasisOfDiagnosisCancer,
		CancerDiagnosis
from ct
where NhsNumber is not null and
	(
		DiagnosisDate is not null or 
		NonPrimaryDiagnosisDate is not null
	);
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_source_concept_id%20field%20Cosd%20V8%20CTYA%20Condition%20Occurrence%20Primary%20Diagnosis%20mapping){: .btn }
### Cosd V8 CTYA Condition Occurrence Primary Diagnosis Histology Topography
Source columns  `CancerHistology`, `CancerTopography`.
Resolve ICD-o-3 codes to OMOP concepts.

* `CancerHistology` MORPHOLOGY (ICD-O CANCER TRANSFORMATION) is the morphology code of the Cancer Transformation using the ICD-O CODE. [MORPHOLOGY (ICD-O CANCER TRANSFORMATION)](https://www.datadictionary.nhs.uk/data_elements/morphology__icd-o_cancer_transformation_.html)

* `CancerTopography` TOPOGRAPHY (ICD-O) is the topographical site of the Tumour using the ICD-O CODE. [TOPOGRAPHY (ICD-O)](https://www.datadictionary.nhs.uk/data_elements/topography__icd-o_.html)

```sql
with ct as (
  select 
    Record ->> '$.CTYA.CTYACore.CTYACoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
    Record ->> '$.CTYA.CTYACore.CTYACoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as DiagnosisDate,
    Record ->> '$.CTYA.CTYACore.CTYACoreLinkageDiagnosticDetails.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed' as NonPrimaryDiagnosisDate,
    Record ->> '$.CTYA.CTYACore.CTYACoreDiagnosis.MorphologyICDODiagnosis.@code' as CancerHistology,
    Record ->> '$.CTYA.CTYACore.CTYACoreDiagnosis.TopographyICDO.@code' as CancerTopography,
    Record ->> '$.CTYA.CTYACore.CTYACoreDiagnosis.BasisOfCancerDiagnosis.@code' as BasisOfDiagnosisCancer,
    Record ->> '$.CTYA.CTYACore.CTYACoreLinkageDiagnosticDetails.PrimaryDiagnosis.@code' as CancerDiagnosis
  from omop_staging.cosd_staging_81 co
where co.Type = 'CT'
)
select 
	distinct
		NhsNumber,
		coalesce (DiagnosisDate, NonPrimaryDiagnosisDate) as DiagnosisDate,
		BasisOfDiagnosisCancer,
		CancerHistology,
		CancerTopography
from ct
where NhsNumber is not null and
	(
		DiagnosisDate is not null or 
		NonPrimaryDiagnosisDate is not null
	)
	and (CancerHistology is not null and CancerTopography is not null)
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_source_concept_id%20field%20Cosd%20V8%20CTYA%20Condition%20Occurrence%20Primary%20Diagnosis%20Histology%20Topography%20mapping){: .btn }
### Cosd V8 Condition Occurrence Primary Diagnosis
Source column  `CancerDiagnosis`.
Resolve ICD10 codes to standard or non standard OMOP concepts. If code cannot be mapped, map using the parent code.

* `CancerDiagnosis` PRIMARY DIAGNOSIS (ICD) is the International Classification of Diseases (ICD) code used to identify the PRIMARY DIAGNOSIS. [PRIMARY DIAGNOSIS (ICD)](https://www.datadictionary.nhs.uk/data_elements/primary_diagnosis__icd_.html)

```sql
with co as (
  select 
    Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
    Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as DiagnosisDate,
    Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreLinkageDiagnosticDetails.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed' as NonPrimaryDiagnosisDate,
    Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreDiagnosis.MorphologyICDODiagnosis.@code' as CancerHistology,
    Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreDiagnosis.TopographyICDO.@code' as CancerTopography,
    Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreDiagnosis.BasisOfCancerDiagnosis.@code' as BasisOfDiagnosisCancer,
    Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreLinkageDiagnosticDetails.PrimaryDiagnosis.@code' as CancerDiagnosis
  from omop_staging.cosd_staging_81 co
where co.Type = 'CO'
)
select 
	distinct
		NhsNumber,
		coalesce (DiagnosisDate, NonPrimaryDiagnosisDate) as DiagnosisDate,
		BasisOfDiagnosisCancer,
		CancerDiagnosis
from CO
where NhsNumber is not null and
	(
		DiagnosisDate is not null or 
		NonPrimaryDiagnosisDate is not null
	);
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_source_concept_id%20field%20Cosd%20V8%20Condition%20Occurrence%20Primary%20Diagnosis%20mapping){: .btn }
### Cosd V8 Condition Occurrence Primary Diagnosis Histology Topography
Source columns  `CancerHistology`, `CancerTopography`.
Resolve ICD-o-3 codes to OMOP concepts.

* `CancerHistology` MORPHOLOGY (ICD-O CANCER TRANSFORMATION) is the morphology code of the Cancer Transformation using the ICD-O CODE. [MORPHOLOGY (ICD-O CANCER TRANSFORMATION)](https://www.datadictionary.nhs.uk/data_elements/morphology__icd-o_cancer_transformation_.html)

* `CancerTopography` TOPOGRAPHY (ICD-O) is the topographical site of the Tumour using the ICD-O CODE. [TOPOGRAPHY (ICD-O)](https://www.datadictionary.nhs.uk/data_elements/topography__icd-o_.html)

```sql
with co as (
  select 
    Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
    Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as DiagnosisDate,
    Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreLinkageDiagnosticDetails.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed' as NonPrimaryDiagnosisDate,
    Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreDiagnosis.MorphologyICDODiagnosis.@code' as CancerHistology,
    Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreDiagnosis.TopographyICDO.@code' as CancerTopography,
    Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreDiagnosis.BasisOfCancerDiagnosis.@code' as BasisOfDiagnosisCancer,
    Record ->> '$.Colorectal.ColorectalCore.ColorectalCoreLinkageDiagnosticDetails.PrimaryDiagnosis.@code' as CancerDiagnosis
  from omop_staging.cosd_staging_81 co
where co.Type = 'CO'
)
select 
	distinct
		NhsNumber,
		coalesce (DiagnosisDate, NonPrimaryDiagnosisDate) as DiagnosisDate,
		BasisOfDiagnosisCancer,
		CancerHistology,
		CancerTopography
from CO
where NhsNumber is not null and
	(
		DiagnosisDate is not null or 
		NonPrimaryDiagnosisDate is not null
	)
	and (CancerHistology is not null and CancerTopography is not null)
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_source_concept_id%20field%20Cosd%20V8%20Condition%20Occurrence%20Primary%20Diagnosis%20Histology%20Topography%20mapping){: .btn }
### COSD V9 Condition Occurrence Recurrence
Source column  `SecondaryDiagnosis`.
Resolve ICD10 codes to standard or non standard OMOP concepts. If code cannot be mapped, map using the parent code.

* `SecondaryDiagnosis` SECONDARY DIAGNOSIS (ICD) is the International Classification of Diseases (ICD) code used to identify the secondary PATIENT DIAGNOSIS. [SECONDARY DIAGNOSIS (ICD)](https://www.datadictionary.nhs.uk/data_elements/secondary_diagnosis__icd_.html)

```sql
with CO as (
	select
		Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
		Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed' as DateOfPrimaryDiagnosisClinicallyAgreed,
		Record ->> '$.PrimaryPathway.Diagnosis.DiagnosisAdditionalItems.SecondaryDiagnosisIcd.@code' as SecondaryDiagnosis
	from omop_staging.cosd_staging_901
	where type = 'CO'
)
select
	NhsNumber,
	DateOfPrimaryDiagnosisClinicallyAgreed,
	max(SecondaryDiagnosis) as SecondaryDiagnosis
from CO
where DateOfPrimaryDiagnosisClinicallyAgreed is not null
  and SecondaryDiagnosis is not null
group by NhsNumber, DateOfPrimaryDiagnosisClinicallyAgreed;

	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_source_concept_id%20field%20COSD%20V9%20Condition%20Occurrence%20Recurrence%20mapping){: .btn }
### COSD V9 Condition Occurrence Recurrence
Source column  `NonPrimaryRecurrenceOriginalDiagnosis`.
Resolve ICD10 codes to standard or non standard OMOP concepts. If code cannot be mapped, map using the parent code.

* `NonPrimaryRecurrenceOriginalDiagnosis` PRIMARY DIAGNOSIS (ICD ORIGINAL) is the International Classification of Diseases (ICD) code used to identify the original PRIMARY DIAGNOSIS. [PRIMARY DIAGNOSIS (ICD ORIGINAL)](https://www.datadictionary.nhs.uk/data_elements/primary_diagnosis__icd_original_.html)

```sql
select
    distinct
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
        Record ->> '$.NonPrimaryPathway.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed' as DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
        Record ->> '$.NonPrimaryPathway.Recurrence.OriginalPrimaryDiagnosisIcd.@code' as NonPrimaryRecurrenceOriginalDiagnosis
from omop_staging.cosd_staging_901
where type = 'CO'
  and NonPrimaryRecurrenceOriginalDiagnosis is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_source_concept_id%20field%20COSD%20V9%20Condition%20Occurrence%20Recurrence%20mapping){: .btn }
### COSD V9 Condition Occurrence Progression
Source column  `NonPrimaryProgressionOriginalDiagnosis`.
Resolve ICD10 codes to standard or non standard OMOP concepts. If code cannot be mapped, map using the parent code.

* `NonPrimaryProgressionOriginalDiagnosis` CANCER PROGRESSION (ICD ORIGINAL) is the International Classification of Diseases (ICD) code of the original PATIENT DIAGNOSIS of the Cancer Progression. [CANCER PROGRESSION (ICD ORIGINAL)](https://www.datadictionary.nhs.uk/data_elements/cancer_progression__icd_original_.html)

```sql
select distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
    Record ->> '$.NonPrimaryPathway.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed' as NonPrimaryDiagnosisDate,
    Record ->> '$.NonPrimaryPathway.Progression.ProgressionIcd.@code' as NonPrimaryProgressionOriginalDiagnosis
from omop_staging.cosd_staging_901
where type = 'CO'
  and NonPrimaryProgressionOriginalDiagnosis is not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_source_concept_id%20field%20COSD%20V9%20Condition%20Occurrence%20Progression%20mapping){: .btn }
### COSD V9 Condition Occurrence Primary Diagnosis
Source column  `CancerDiagnosis`.
Resolve ICD10 codes to standard or non standard OMOP concepts. If code cannot be mapped, map using the parent code.

* `CancerDiagnosis` The basis of how a PATIENT DIAGNOSIS relating to cancer was identified. [BASIS OF DIAGNOSIS (CANCER)](https://www.datadictionary.nhs.uk/data_elements/basis_of_diagnosis__cancer_.html)

```sql
with co as (
	select
		Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
		Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed' as DateOfPrimaryDiagnosisClinicallyAgreed,
		Record ->> '$.PrimaryPathway.Diagnosis."MorphologyIcd-o-3"."@code"' as CancerHistology,
		Record ->> '$.PrimaryPathway.Diagnosis."TopographyIcd-o-3"."@code"' as CancerTopography,
		Record ->> '$.PrimaryPathway.Diagnosis.BasisOfDiagnosisCancer.@code' as BasisOfDiagnosisCancer,
		Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.PrimaryDiagnosisIcd.@code' as CancerDiagnosis
	from omop_staging.cosd_staging_901
	where type = 'CO'
)
select
	NhsNumber,
	DateOfPrimaryDiagnosisClinicallyAgreed,
	max(BasisOfDiagnosisCancer) as BasisOfDiagnosisCancer,
	CancerDiagnosis
from co
where DateOfPrimaryDiagnosisClinicallyAgreed is not null
group by NhsNumber, DateOfPrimaryDiagnosisClinicallyAgreed, CancerDiagnosis;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_source_concept_id%20field%20COSD%20V9%20Condition%20Occurrence%20Primary%20Diagnosis%20mapping){: .btn }
### COSD V9 Condition Occurrence Primary Diagnosis Histology Topography
Source columns  `CancerHistology`, `CancerTopography`.
Resolve ICD-o-3 codes to OMOP concepts.

* `CancerHistology` MORPHOLOGY (ICD-O CANCER TRANSFORMATION) is the morphology code of the Cancer Transformation using the ICD-O CODE. [MORPHOLOGY (ICD-O CANCER TRANSFORMATION)](https://www.datadictionary.nhs.uk/data_elements/morphology__icd-o_cancer_transformation_.html)

* `CancerTopography` TOPOGRAPHY (ICD-O) is the topographical site of the Tumour using the ICD-O CODE. [TOPOGRAPHY (ICD-O)](https://www.datadictionary.nhs.uk/data_elements/topography__icd-o_.html)

```sql
select distinct
    Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
    Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed' as DateOfPrimaryDiagnosisClinicallyAgreed,
    Record ->> '$.PrimaryPathway.Diagnosis.BasisOfDiagnosisCancer.@code' as BasisOfDiagnosisCancer,
    Record ->> '$.PrimaryPathway.Diagnosis."MorphologyIcd-o-3"."@code"' as CancerHistology,
    Record ->> '$.PrimaryPathway.Diagnosis."TopographyIcd-o-3"."@code"' as CancerTopography
from omop_staging.cosd_staging_901
where type = 'CO'
  and DateOfPrimaryDiagnosisClinicallyAgreed is not null
  and CancerHistology is not null
  and CancerTopography not null;
	
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_source_concept_id%20field%20COSD%20V9%20Condition%20Occurrence%20Primary%20Diagnosis%20Histology%20Topography%20mapping){: .btn }
### COSD V9 Breast Condition Occurrence Secondary Diagnosis
Source column  `SecondaryDiagnosis`.
Resolve ICD10 codes to standard or non standard OMOP concepts. If code cannot be mapped, map using the parent code.

* `SecondaryDiagnosis` SECONDARY DIAGNOSIS (ICD) is a classification denoting a disease or condition which co-exists at the time of Consultation with the Primary Diagnosis. [SECONDARY DIAGNOSIS (ICD)](https://www.datadictionary.nhs.uk/data_elements/secondary_diagnosis__icd_.html)

```sql
with BR as (
    select
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
        Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed' as DateOfPrimaryDiagnosisClinicallyAgreed,
        Record ->> '$.PrimaryPathway.Diagnosis.DiagnosisAdditionalItems.SecondaryDiagnosisIcd.@code' as SecondaryDiagnosis
    from omop_staging.cosd_staging_901
    where type = 'BR'
)
select
    NhsNumber,
    DateOfPrimaryDiagnosisClinicallyAgreed,
    max(SecondaryDiagnosis) as SecondaryDiagnosis
from BR
where DateOfPrimaryDiagnosisClinicallyAgreed is not null
  and SecondaryDiagnosis is not null
group by NhsNumber, DateOfPrimaryDiagnosisClinicallyAgreed;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_source_concept_id%20field%20COSD%20V9%20Breast%20Condition%20Occurrence%20Secondary%20Diagnosis%20mapping){: .btn }
### COSD V9 Breast Condition Occurrence Recurrence
Source column  `NonPrimaryRecurrenceOriginalDiagnosis`.
Resolve ICD10 codes to standard or non standard OMOP concepts. If code cannot be mapped, map using the parent code.

* `NonPrimaryRecurrenceOriginalDiagnosis` ORIGINAL PRIMARY DIAGNOSIS (ICD RECURRENCE) is the International Classification of Diseases (ICD) code of the original Primary Diagnosis of a Recurrence. [ORIGINAL PRIMARY DIAGNOSIS (ICD RECURRENCE)]()

```sql
with BR as (
    select
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
        Record ->> '$.NonPrimaryPathway.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed' as DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
        Record ->> '$.NonPrimaryPathway.Recurrence.OriginalPrimaryDiagnosisIcd.@code' as NonPrimaryRecurrenceOriginalDiagnosis
    from omop_staging.cosd_staging_901
    where type = 'BR'
)
select distinct
    NhsNumber,
    DateOfNonPrimaryCancerDiagnosisClinicallyAgreed,
    NonPrimaryRecurrenceOriginalDiagnosis
from BR
where NonPrimaryRecurrenceOriginalDiagnosis is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_source_concept_id%20field%20COSD%20V9%20Breast%20Condition%20Occurrence%20Recurrence%20mapping){: .btn }
### COSD V9 Breast Condition Occurrence Progression
Source column  `NonPrimaryProgressionOriginalDiagnosis`.
Resolve ICD10 codes to standard or non standard OMOP concepts. If code cannot be mapped, map using the parent code.

* `NonPrimaryProgressionOriginalDiagnosis` CANCER PROGRESSION (ICD ORIGINAL) is the International Classification of Diseases (ICD) code of the original PATIENT DIAGNOSIS of the Cancer Progression. [CANCER PROGRESSION (ICD ORIGINAL)](https://www.datadictionary.nhs.uk/data_elements/cancer_progression__icd_original_.html)

```sql
with BR as (
    select
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
        Record ->> '$.NonPrimaryPathway.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed' as NonPrimaryDiagnosisDate,
        Record ->> '$.NonPrimaryPathway.Progression.ProgressionIcd.@code' as NonPrimaryProgressionOriginalDiagnosis
    from omop_staging.cosd_staging_901
    where type = 'BR'
)
select distinct
    NhsNumber,
    NonPrimaryDiagnosisDate,
    NonPrimaryProgressionOriginalDiagnosis
from BR
where NonPrimaryProgressionOriginalDiagnosis is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_source_concept_id%20field%20COSD%20V9%20Breast%20Condition%20Occurrence%20Progression%20mapping){: .btn }
### COSD V9 Breast Condition Occurrence Primary Diagnosis
Source column  `CancerDiagnosis`.
Resolve ICD10 codes to standard or non standard OMOP concepts. If code cannot be mapped, map using the parent code.

* `CancerDiagnosis` PRIMARY DIAGNOSIS (ICD) is the International Classification of Diseases (ICD) code used to identify the PRIMARY DIAGNOSIS. [PRIMARY DIAGNOSIS (ICD)](https://www.datadictionary.nhs.uk/data_elements/primary_diagnosis__icd_.html)

```sql
with br as (
    select
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
        Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed' as DateOfPrimaryDiagnosisClinicallyAgreed,
        Record ->> '$.PrimaryPathway.Diagnosis."MorphologyIcd-o-3"."@code"' as CancerHistology,
        Record ->> '$.PrimaryPathway.Diagnosis."TopographyIcd-o-3"."@code"' as CancerTopography,
        Record ->> '$.PrimaryPathway.Diagnosis.BasisOfDiagnosisCancer.@code' as BasisOfDiagnosisCancer,
        Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.PrimaryDiagnosisIcd.@code' as CancerDiagnosis
    from omop_staging.cosd_staging_901
    where type = 'BR'
)
select
    NhsNumber,
    DateOfPrimaryDiagnosisClinicallyAgreed,
    max(BasisOfDiagnosisCancer) as BasisOfDiagnosisCancer,
    CancerDiagnosis
from br
where DateOfPrimaryDiagnosisClinicallyAgreed is not null
group by NhsNumber, DateOfPrimaryDiagnosisClinicallyAgreed, CancerDiagnosis;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_source_concept_id%20field%20COSD%20V9%20Breast%20Condition%20Occurrence%20Primary%20Diagnosis%20mapping){: .btn }
### COSD V9 Breast Condition Occurrence Primary Diagnosis Histology Topography
Source columns  `CancerHistology`, `CancerTopography`.
Resolve ICD-o-3 codes to OMOP concepts.

* `CancerHistology` MORPHOLOGY (ICD-O CANCER TRANSFORMATION) is the morphology code of the Cancer Transformation using the ICD-O CODE. [MORPHOLOGY (ICD-O CANCER TRANSFORMATION)](https://www.datadictionary.nhs.uk/data_elements/morphology__icd-o_cancer_transformation_.html)

* `CancerTopography` TOPOGRAPHY (ICD-O) is the topographical site of the Tumour using the ICD-O CODE. [TOPOGRAPHY (ICD-O)](https://www.datadictionary.nhs.uk/data_elements/topography__icd-o_.html)

```sql
with BR as (
    select
        Record ->> '$.LinkagePatientId.NhsNumber.@extension' as NhsNumber,
        Record ->> '$.PrimaryPathway.LinkageDiagnosticDetails.DateOfPrimaryDiagnosisClinicallyAgreed' as DateOfPrimaryDiagnosisClinicallyAgreed,
        Record ->> '$.PrimaryPathway.Diagnosis.BasisOfDiagnosisCancer.@code' as BasisOfDiagnosisCancer,
        Record ->> '$.PrimaryPathway.Diagnosis."MorphologyIcd-o-3"."@code"' as CancerHistology,
        Record ->> '$.PrimaryPathway.Diagnosis."TopographyIcd-o-3"."@code"' as CancerTopography
    from omop_staging.cosd_staging_901
    where type = 'BR'
)
select distinct
    NhsNumber,
    DateOfPrimaryDiagnosisClinicallyAgreed,
    BasisOfDiagnosisCancer,
    CancerHistology,
    CancerTopography
from BR
where DateOfPrimaryDiagnosisClinicallyAgreed is not null
  and CancerHistology is not null
  and CancerTopography is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_source_concept_id%20field%20COSD%20V9%20Breast%20Condition%20Occurrence%20Primary%20Diagnosis%20Histology%20Topography%20mapping){: .btn }
### COSD V8 Breast Condition Occurrence Progression
Source column  `NonPrimaryProgressionOriginalDiagnosis`.
Resolve ICD10 codes to standard or non standard OMOP concepts. If code cannot be mapped, map using the parent code.

* `NonPrimaryProgressionOriginalDiagnosis` CANCER PROGRESSION (ICD ORIGINAL) is the International Classification of Diseases (ICD) code of the original PATIENT DIAGNOSIS of the Cancer Progression. [CANCER PROGRESSION (ICD ORIGINAL)](https://www.datadictionary.nhs.uk/data_elements/cancer_progression__icd_original_.html)

```sql
with BR as (
    select
        Record ->> '$.Breast.BreastCore.BreastCoreLinkagePatientId.NHSNumber.@extension' as NHSNumber,
        Record ->> '$.Breast.BreastCore.BreastCoreLinkageDiagnosticDetails.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed' as NonPrimaryDiagnosisDate,
        Record ->> '$.Breast.BreastCore.BreastCoreNonPrimaryCancerPathwayRoute.CancerProgressionICD.@code' as NonPrimaryProgressionOriginalDiagnosis
    from omop_staging.cosd_staging_81
    where type = 'BR'
)
select distinct
    NHSNumber,
    NonPrimaryDiagnosisDate,
    NonPrimaryProgressionOriginalDiagnosis
from BR
where NonPrimaryProgressionOriginalDiagnosis is not null
  and NonPrimaryDiagnosisDate is not null
  and NHSNumber is not null;
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_source_concept_id%20field%20COSD%20V8%20Breast%20Condition%20Occurrence%20Progression%20mapping){: .btn }
### Cosd V8 Breast Condition Occurrence Primary Diagnosis
Source column  `CancerDiagnosis`.
Resolve ICD10 codes to standard or non standard OMOP concepts. If code cannot be mapped, map using the parent code.

* `CancerDiagnosis` PRIMARY DIAGNOSIS (ICD) is the International Classification of Diseases (ICD) code used to identify the PRIMARY DIAGNOSIS. [PRIMARY DIAGNOSIS (ICD)](https://www.datadictionary.nhs.uk/data_elements/primary_diagnosis__icd_.html)

```sql
with BR as (
  select 
    Record ->> '$.Breast.BreastCore.BreastCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
    Record ->> '$.Breast.BreastCore.BreastCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as DiagnosisDate,
    Record ->> '$.Breast.BreastCore.BreastCoreLinkageDiagnosticDetails.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed' as NonPrimaryDiagnosisDate,
    Record ->> '$.Breast.BreastCore.BreastCoreDiagnosis.MorphologyICDODiagnosis.@code' as CancerHistology,
    Record ->> '$.Breast.BreastCore.BreastCoreDiagnosis.TopographyICDO.@code' as CancerTopography,
    Record ->> '$.Breast.BreastCore.BreastCoreDiagnosis.BasisOfCancerDiagnosis.@code' as BasisOfDiagnosisCancer,
    Record ->> '$.Breast.BreastCore.BreastCoreLinkageDiagnosticDetails.PrimaryDiagnosis.@code' as CancerDiagnosis
  from omop_staging.cosd_staging_81 
  where Type = 'BR'
)
select 
    distinct
        NhsNumber,
        coalesce (DiagnosisDate, NonPrimaryDiagnosisDate) as DiagnosisDate,
        BasisOfDiagnosisCancer,
        CancerDiagnosis
from BR
where NhsNumber is not null and
    (
        DiagnosisDate is not null or 
        NonPrimaryDiagnosisDate is not null
    );
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_source_concept_id%20field%20Cosd%20V8%20Breast%20Condition%20Occurrence%20Primary%20Diagnosis%20mapping){: .btn }
### Cosd V8 Breast Condition Occurrence Primary Diagnosis Histology Topography
Source columns  `CancerHistology`, `CancerTopography`.
Resolve ICD-o-3 codes to OMOP concepts.

* `CancerHistology` MORPHOLOGY (ICD-O CANCER TRANSFORMATION) is the morphology code of the Cancer Transformation using the ICD-O CODE. [MORPHOLOGY (ICD-O CANCER TRANSFORMATION)](https://www.datadictionary.nhs.uk/data_elements/morphology__icd-o_cancer_transformation_.html)

* `CancerTopography` TOPOGRAPHY (ICD-O) is the topographical site of the Tumour using the ICD-O CODE. [TOPOGRAPHY (ICD-O)](https://www.datadictionary.nhs.uk/data_elements/topography__icd-o_.html)

```sql
with BR as (
  select 
    Record ->> '$.Breast.BreastCore.BreastCoreLinkagePatientId.NHSNumber.@extension' as NhsNumber,
    Record ->> '$.Breast.BreastCore.BreastCoreLinkageDiagnosticDetails.ClinicalDateCancerDiagnosis' as DiagnosisDate,
    Record ->> '$.Breast.BreastCore.BreastCoreLinkageDiagnosticDetails.DateOfNonPrimaryCancerDiagnosisClinicallyAgreed' as NonPrimaryDiagnosisDate,
    Record ->> '$.Breast.BreastCore.BreastCoreDiagnosis.MorphologyICDODiagnosis.@code' as CancerHistology,
    Record ->> '$.Breast.BreastCore.BreastCoreDiagnosis.TopographyICDO.@code' as CancerTopography,
    Record ->> '$.Breast.BreastCore.BreastCoreDiagnosis.BasisOfCancerDiagnosis.@code' as BasisOfDiagnosisCancer,
    Record ->> '$.Breast.BreastCore.BreastCoreLinkageDiagnosticDetails.PrimaryDiagnosis.@code' as CancerDiagnosis
  from omop_staging.cosd_staging_81
where Type = 'BR'
)
select 
    distinct
        NhsNumber,
        coalesce (DiagnosisDate, NonPrimaryDiagnosisDate) as DiagnosisDate,
        BasisOfDiagnosisCancer,
        CancerHistology,
        CancerTopography
from BR
where NhsNumber is not null and
    (
        DiagnosisDate is not null or 
        NonPrimaryDiagnosisDate is not null
    )
    and (CancerHistology is not null and CancerTopography is not null)
```


[Comment or raise an issue for this mapping.](https://github.com/answerdigital/oxford-omop-data-mapper/issues/new?title=OMOP%20ConditionOccurrence%20table%20condition_source_concept_id%20field%20Cosd%20V8%20Breast%20Condition%20Occurrence%20Primary%20Diagnosis%20Histology%20Topography%20mapping){: .btn }
